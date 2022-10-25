using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace FFXivAutomation;

public class MouseInput
{

    [DllImport("user32.dll", SetLastError = true)]
    static extern uint SendInput(uint nInputs, ref Input pInputs, int cbSize);

    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetCursorPos(out POINT lpPoint);

    // import the necessary API function so .NET can
    // marshall parameters appropriately
    [DllImport("user32.dll")]
    static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    [StructLayout(LayoutKind.Sequential)]
    struct Input
    {
        public SendInputEventType type;
        public MouseKeybdhardwareInputUnion mkhi;
    }
    enum SendInputEventType : int
    {
        InputMouse,
        InputKeyboard,
        InputHardware
    }
    [StructLayout(LayoutKind.Explicit)]
    struct MouseKeybdhardwareInputUnion
    {
        [FieldOffset(0)]
        public MouseInputData mi;

        [FieldOffset(0)]
        public KEYBDINPUT ki;

        [FieldOffset(0)]
        public HARDWAREINPUT hi;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    struct HARDWAREINPUT
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }
    struct MouseInputData
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public MouseEventFlags dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [Flags]
    enum MouseEventFlags : uint
    {
        MOUSEEVENTF_MOVE = 0x0001,
        MOUSEEVENTF_LEFTDOWN = 0x0002,
        MOUSEEVENTF_LEFTUP = 0x0004,
        MOUSEEVENTF_RIGHTDOWN = 0x0008,
        MOUSEEVENTF_RIGHTUP = 0x0010,
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,
        MOUSEEVENTF_MIDDLEUP = 0x0040,
        MOUSEEVENTF_XDOWN = 0x0080,
        MOUSEEVENTF_XUP = 0x0100,
        MOUSEEVENTF_WHEEL = 0x0800,
        MOUSEEVENTF_VIRTUALDESK = 0x4000,
        MOUSEEVENTF_ABSOLUTE = 0x8000
    }
    
    /// <summary>
     /// Struct representing a point.
     /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int X;
        public int Y;

        public static implicit operator Point(POINT point)
        {
            return new Point(point.X, point.Y);
        }
    }
    public static Point GetCursorPosition()
    {
        POINT lpPoint;
        GetCursorPos(out lpPoint);
        // NOTE: If you need error handling
        // bool success = GetCursorPos(out lpPoint);
        // if (!success)

        return lpPoint;
    }

    public static void MoveMouseRelative(int x, int y)
    {
        Input mouseInput = new Input();
        mouseInput.type = SendInputEventType.InputMouse;
        mouseInput.mkhi.mi.dx = x;
        mouseInput.mkhi.mi.dy = y;
        mouseInput.mkhi.mi.mouseData = 0;


        mouseInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_MOVE;
        SendInput(1, ref mouseInput, Marshal.SizeOf(new Input()));
    }

    public static void MoveMouseAbsolute(int x, int y)
    {
        double yFactor = (double)((double)(y * (double)65535) / 1080);
        double xFactor = (double)((double)(x * (double)65535) / 1920);
        //double xFactor = (double)((double)(x * (double)65535) / (1920 * 2)); //This is for Dual Monitors
        //Console.WriteLine("xFactor: " + xFactor + ", " + "yFactor: " + yFactor);
        //double xFactor = 65535 / (2 * 1920);
        Input mouseInput = new Input();
        mouseInput.type = SendInputEventType.InputMouse;
        mouseInput.mkhi.mi.dx = (int)xFactor;
        mouseInput.mkhi.mi.dy = (int)yFactor;
        mouseInput.mkhi.mi.mouseData = 0;


        mouseInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_MOVE | MouseEventFlags.MOUSEEVENTF_VIRTUALDESK | MouseEventFlags.MOUSEEVENTF_ABSOLUTE;
        SendInput(1, ref mouseInput, Marshal.SizeOf(new Input()));
    }


    // simulates movement of the mouse.  parameters specify changes
    // in relative position.  positive values indicate movement
    // right or down
    public static void Move(int xDelta, int yDelta)
    {
        mouse_event((int)MouseEventFlags.MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
    }

    public static void ClickLeftMouseButton(int x, int y)
    {
        Input mouseInput = new Input();
        mouseInput.type = SendInputEventType.InputMouse;
        mouseInput.mkhi.mi.dx = x;
        mouseInput.mkhi.mi.dy = y;
        mouseInput.mkhi.mi.mouseData = 0;

        mouseInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN;
        SendInput(1, ref mouseInput, Marshal.SizeOf(new Input()));
        Thread.Sleep(100);
        mouseInput.mkhi.mi.dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP;
        SendInput(1, ref mouseInput, Marshal.SizeOf(new Input()));
    }
}
