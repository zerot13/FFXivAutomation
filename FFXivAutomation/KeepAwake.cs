using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFXivAutomation
{
    public class KeepAwake
    {        
        public KeepAwake()
        {
            _random = new Random();
        }

        public void Run()
        {
            Random random = new Random();
            Thread.Sleep(5000);
            while(true)
            {
                Console.WriteLine("Running Routine");
                RunRoutine();
                int sleepTime = 10000 + random.Next(0, 30000);
                Console.WriteLine("Routine Run, sleeping for " + sleepTime);
                Thread.Sleep(sleepTime);
            }
        }

        private void RunRoutine()
        {
            MouseInput.MoveMouseRelative(100, -100);
            SleepRandomDelay(1000, 200);
            MoveForward(1000);
            MoveRight(1000);
            MouseInput.ClickLeftMouseButton(0, 0);
            MoveBack(2250);
            MoveLeft(1000);
            SleepRandomDelay(1000, 200);
            MouseInput.MoveMouseRelative(-100, 100);
        }

        public void SleepRandomDelay(int baseInterval, int margin)
        {
            Thread.Sleep(baseInterval + _random.Next(-margin, margin));
        }

        public int CalculateRandomDelay(int baseInterval, int margin)
        {
            return baseInterval + _random.Next(-margin, margin);
        }

        private void MoveForward(int baseInterval)
        {
            KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_W, CalculateRandomDelay(baseInterval, 100));
        }

        private void MoveBack(int baseInterval)
        {
            KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_S, CalculateRandomDelay(baseInterval, 100));
        }

        private void MoveLeft(int baseInterval)
        {
            KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_A, CalculateRandomDelay(baseInterval, 100));
        }

        private void MoveRight(int baseInterval)
        {
            KeyboardInput.PressKey(KeyboardInput.ScanCodeShort.KEY_D, CalculateRandomDelay(baseInterval, 100));
        }

        Random _random;
    }
}
