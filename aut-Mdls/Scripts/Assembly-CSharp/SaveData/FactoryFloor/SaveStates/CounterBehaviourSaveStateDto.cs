using System;
using System.Collections.Generic;
using Data.FactoryFloor;

namespace SaveData.FactoryFloor.SaveStates
{
	[Serializable]
	public class CounterBehaviourSaveStateDto : BehaviourSaveStateDto
	{
		public InputBufferSaveData InputBufferSaveData;

		public Queue<bool> Histogram = new Queue<bool>();

		public Queue<int> Averages = new Queue<int>();

		public int Counter;

		public int CalibrationCounter;
	}
}
