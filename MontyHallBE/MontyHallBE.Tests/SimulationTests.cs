﻿using MontyHallBE.Service;

namespace MontyHallBE.Tests
{
    public class SimulationTests
    {
        public class When_getting_simulation_result
        {
            [Fact]
            public async Task Win_rate_should_be_calculated_correctly()
            {
                var simulator = new Simulator(1000, true);
                var result = await simulator.GetSimulationResult();
                var expectedWinRate = (Convert.ToDecimal(result.NumberOfGamesWon) / 1000) * 100;
                Assert.Equal(expectedWinRate, result.WinRate);
            }

            [Fact]
            public async Task Win_rate_should_be_higher_in_the_long_run_if_switching_door()
            {
                var simulatorWhereSwitchWasChosen = new Simulator(100000, true);
                var simulatorWhereSwitchWasNotChosen = new Simulator(100000, false);

                var resultForSwitch = await simulatorWhereSwitchWasChosen.GetSimulationResult();
                var resultForNoSwitch = await simulatorWhereSwitchWasNotChosen.GetSimulationResult();

                Assert.True(resultForSwitch.WinRate > resultForNoSwitch.WinRate);
            }
        }
    }
}
