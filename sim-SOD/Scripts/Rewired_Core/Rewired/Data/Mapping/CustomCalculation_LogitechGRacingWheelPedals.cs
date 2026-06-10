using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class CustomCalculation_LogitechGRacingWheelPedals : CustomCalculation
	{
		public enum Mode
		{
			SharedAxis = 0,
			SeparateAxes = 1
		}

		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

		private const float dead = 0.01f;

		[NonSerialized]
		private Mode jMduXBYjmiTVYdhbYSSNOOCTIRME;

		internal override TypeWrapper.DataType ResultType => default(TypeWrapper.DataType);

		internal override bool Process()
		{
			return false;
		}

		private float sDjoZqJmPLJtRjEnTAoheqBQFmOX()
		{
			return 0f;
		}

		private void nEWCMxshIpZoFRWNfGoRZrObIIv(float P_0, float P_1)
		{
		}
	}
}
