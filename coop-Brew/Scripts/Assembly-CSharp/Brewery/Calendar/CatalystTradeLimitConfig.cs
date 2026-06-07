using System;
using System.Collections.Generic;
using Brewery.Data;
using UnityEngine;

namespace Brewery.Calendar
{
	[CreateAssetMenu(fileName = "CatalystTradeLimitConfig", menuName = "Brewery/Calendar/Catalyst Trade Limit Config", order = 11)]
	public class CatalystTradeLimitConfig : ScriptableObject
	{
		[Serializable]
		public struct CatalystOverride
		{
			public CatalystData Catalyst;

			[Min(1f)]
			public int DailyLimit;
		}

		[Tooltip("Master enable — when false, no catalyst daily cap is enforced at all.")]
		[SerializeField]
		private bool m_Enabled;

		[Tooltip("Default catalyst purchases allowed per day when no override is set.")]
		[Min(1f)]
		[SerializeField]
		private int m_DefaultDailyLimit;

		[Tooltip("Per-catalyst overrides. Drop a catalyst asset and type its special cap.")]
		[SerializeField]
		private CatalystOverride[] m_PerCatalystOverrides;

		public bool Enabled => false;

		public int DefaultDailyLimit => 0;

		public IReadOnlyList<CatalystOverride> PerCatalystOverrides => null;

		public int GetBaseLimit(string catalystId)
		{
			return 0;
		}

		public int GetBaseLimit(CatalystData catalyst)
		{
			return 0;
		}

		private void OnValidate()
		{
		}
	}
}
