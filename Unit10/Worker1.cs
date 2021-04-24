using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static Unit10.Program;

namespace Unit10
{
     class Worker1: IWorker
    {
        ILogger Logger { get; }

        public Worker1(ILogger logger)
        {
            Logger = logger;
        }

        public void Work()
        {
            Logger.Event("Готов к работе");
            
        }

        public void Stop()
        {
            Logger.Event("Завершил работу");

        }

        public void Error(string mes)
        {
            Logger.Error(mes);
        }
    }

   
}
