using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class NintendoSwitchPlatformSettings
	{
		[SerializeField]
		private string appId;

		[SerializeField]
		private string mountName;

		[SerializeField]
		private bool writeFrequencyLimit;

		[SerializeField]
		private int writeFrequencyBudget;

		[SerializeField]
		private bool writeAmountLimit;

		[SerializeField]
		private int writeAmountBudget;

		public string AppID => null;

		public string MountName => null;

		public bool WriteFrequencyLimit => false;

		public int WriteFrequencyBudget => 0;

		public bool WriteAmountLimit => false;

		public int WriteAmountBudget => 0;
	}
}
