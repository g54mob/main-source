using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class MachineBloodQuality : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		public int CurrentBloodQuality = 1;

		public static int BloodQualityMin => 1;

		public static int BloodQualityMax => 10;

		public event Action<int> BloodyQualityChanged;

		public void SetBloodQuality(int value)
		{
			value = Math.Clamp(value, BloodQualityMin, BloodQualityMax);
			if (value != CurrentBloodQuality)
			{
				CurrentBloodQuality = value;
				this.BloodyQualityChanged?.Invoke(CurrentBloodQuality);
			}
		}
	}
}
