using System;
using UnityEngine;

namespace Polarith.AI.Package
{
	[Serializable]
	public sealed class PidController
	{
		[SerializeField]
		private float gainP = 2f;

		[SerializeField]
		private float gainI = 0.6f;

		[SerializeField]
		private float gainD = 0.2f;

		private float errorSum;

		private float errorOld;

		private float errorLimit = 180f;

		public float GainP
		{
			get
			{
				return gainP;
			}
			set
			{
				gainP = value;
			}
		}

		public float GainI
		{
			get
			{
				return gainI;
			}
			set
			{
				gainI = value;
			}
		}

		public float GainD
		{
			get
			{
				return gainD;
			}
			set
			{
				gainD = value;
			}
		}

		public float GetOutput(float error)
		{
			errorSum += error;
			if (errorSum > errorLimit)
			{
				errorSum = errorLimit;
			}
			else if (errorSum < 0f - errorLimit)
			{
				errorSum = 0f - errorLimit;
			}
			float result = gainP * error + gainI * Time.fixedDeltaTime * errorSum + gainD * (error - errorOld) / Time.fixedDeltaTime;
			errorOld = error;
			return result;
		}
	}
}
