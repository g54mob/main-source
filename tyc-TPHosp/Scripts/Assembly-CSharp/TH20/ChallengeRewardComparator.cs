using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public struct ChallengeRewardComparator
	{
		public enum Type
		{
			GreaterThan = 0,
			GreaterThanOrEqual = 1,
			LessThan = 2,
			LessThanOrEqual = 3,
			Equal = 4,
			NotEqual = 5
		}

		[SerializeField]
		private Type _comparatorType;

		[SerializeField]
		private int _amount;

		public bool PassComparator(int score)
		{
			return _comparatorType switch
			{
				Type.GreaterThan => score > _amount, 
				Type.GreaterThanOrEqual => score >= _amount, 
				Type.LessThan => score < _amount, 
				Type.LessThanOrEqual => score <= _amount, 
				Type.Equal => score == _amount, 
				Type.NotEqual => score != _amount, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
