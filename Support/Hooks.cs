using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestProject1.Support
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario("ui")] // Только для сценариев с тегом @ui
        public void BeforeUIScenario()
        {
            //Driver.Initialize();
        }

        [AfterScenario("ui")]
        public void AfterUIScenario()
        {
            Driver.Quit();
        }
    }
}
