using System;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;

namespace Restory.Data.RandomBallsPoolSystems
{
	[Serializable]
	public abstract class WeightedBallSourceObject<TBallSourceObject> : IRandomnessWeightHolder
	{
		[SerializeField]
		public TBallSourceObject sourceObject;

		[SerializeField]
		private int weight;

		public TBallSourceObject SourceObject => sourceObject;

		public int Weight => weight;

		public WeightedBallSourceObject(TBallSourceObject sourceObject, int weight)
		{
			this.sourceObject = sourceObject;
			this.weight = weight;
		}
	}
}
