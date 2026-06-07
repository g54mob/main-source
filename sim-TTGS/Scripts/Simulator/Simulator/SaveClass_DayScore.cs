using System;
using System.Collections.Generic;
using Simulator.GameWorld;

namespace Simulator
{
	[Serializable]
	public class SaveClass_DayScore : ISaveClass
	{
		public int XP;

		public int startLevel;

		public List<int> productsSold;

		public List<float> productsIncomes;

		public List<int> satisfactions;

		public float totalIncomes;

		public float supplyCost;

		public float licenseCost;

		public float startMoney;

		public SaveClass_DayScore()
		{
			XP = 0;
			startLevel = 1;
			productsSold = new List<int>();
			productsIncomes = new List<float>();
			satisfactions = new List<int>();
			totalIncomes = 0f;
			supplyCost = 0f;
			licenseCost = 0f;
			startMoney = GameStateSettings.DefaultMoneyAmount;
		}

		public virtual void StartSaveProcess()
		{
			productsSold = new List<int>();
			productsIncomes = new List<float>();
			satisfactions = new List<int>();
		}
	}
}
