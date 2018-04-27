using System;
using System.Diagnostics;

namespace nival_task {

    /******************************************************
     * TimerManager:
     * Класс для манипуляций со временем, в данном случае
     * нужен для того, чтобы подсчитать время выполнения
     * программы в миллисекундах.
     *****************************************************/

    class TimerManager {
        private Stopwatch stopWatch;
        public TimeSpan timeSpan { get;  private set; }

        public TimerManager() {
            stopWatch = new Stopwatch();
        }

        public void Start() {
            stopWatch.Start();
        }

        public void Stop(OutputManager om) {
            stopWatch.Stop();
            timeSpan = stopWatch.Elapsed;
            string curLog = string.Format("> Время выполнения программы составило {0} миллисекунд.", timeSpan.Milliseconds);
            om.addLog(curLog);
        }
    }
}