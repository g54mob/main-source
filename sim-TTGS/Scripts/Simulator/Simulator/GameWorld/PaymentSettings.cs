using System;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Payment", Scope.Project)]
	public class PaymentSettings : CustomSettings<PaymentSettings>
	{
		[Header("Max Values")]
		[SerializeField]
		private int m_maxIntegerCount = 7;

		[SerializeField]
		private int m_maxDecimalCount = 2;

		public static int MaxIntegerCount => CustomSettings<PaymentSettings>.I.m_maxIntegerCount;

		public static int MaxDecimalCount => CustomSettings<PaymentSettings>.I.m_maxDecimalCount;

		private bool IsAmountEqualMember(float currentValue, float targetValue)
		{
			float num = MathF.Round(currentValue, MaxDecimalCount, MidpointRounding.AwayFromZero);
			return Mathf.Abs(MathF.Round(targetValue, MaxDecimalCount, MidpointRounding.AwayFromZero) - num) < Mathf.Pow(0.09f, MaxDecimalCount);
		}

		public static bool IsAmountEqual(float currentValue, float targetValue)
		{
			return CustomSettings<PaymentSettings>.I.IsAmountEqualMember(currentValue, targetValue);
		}
	}
}
