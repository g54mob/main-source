using System;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;

namespace Restory.Data.RandomBallsPoolSystems
{
	[Serializable]
	public abstract class RandomBallSourceBase : IRandomnessWeightHolder
	{
		[SerializeField]
		protected int weight = 1;

		[SerializeField]
		protected int id = -1;

		public int ID => id;

		public int Weight => weight;
	}
}
