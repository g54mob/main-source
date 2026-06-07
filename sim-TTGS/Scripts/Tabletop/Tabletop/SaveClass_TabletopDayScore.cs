using System;
using System.Collections.Generic;
using Simulator;

namespace Tabletop
{
	[Serializable]
	public class SaveClass_TabletopDayScore : ISaveClass
	{
		public List<int> miniaturesSold;

		public List<float> miniaturesIncomes;

		public List<float> paintTimes;

		public List<float> paintIncomes;

		public List<float> warGameTimes;

		public List<float> warGameIncomes;

		public int eventSubscriptions;

		public SaveClass_TabletopDayScore()
		{
			miniaturesSold = new List<int>();
			miniaturesIncomes = new List<float>();
			paintTimes = new List<float>();
			paintIncomes = new List<float>();
			warGameTimes = new List<float>();
			warGameIncomes = new List<float>();
			eventSubscriptions = 0;
		}

		public void StartSaveProcess()
		{
			miniaturesSold = new List<int>();
			miniaturesIncomes = new List<float>();
			paintTimes = new List<float>();
			paintIncomes = new List<float>();
			warGameTimes = new List<float>();
			warGameIncomes = new List<float>();
		}
	}
}
