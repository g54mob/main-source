using System;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("General/Game State", Scope.Project)]
	public class GameStateSettings : CustomSettings<GameStateSettings>
	{
		[Serializable]
		private struct XPTiersFormula
		{
			[SerializeField]
			private int a;

			[SerializeField]
			private int b;

			[SerializeField]
			private float c;

			public int Compute(int levelToReach)
			{
				return a + b * (int)Mathf.Pow(levelToReach, c);
			}
		}

		[Header("Global")]
		[SerializeField]
		private bool m_demo = true;

		[SerializeField]
		private int m_demoMaxLevel;

		[Header("Money")]
		[SerializeField]
		private float m_defaultMoneyAmount = 1000f;

		[Header("Attraction Score")]
		[SerializeField]
		private int m_defaultAttractionScore = 1;

		[Header("XP Tiers")]
		[SerializeField]
		private XPTiersFormula m_xpTiersFormula;

		[SerializeField]
		private int m_shopMaxLevel;

		public static bool Demo => CustomSettings<GameStateSettings>.I.m_demo;

		public static int DemoMaxLevel => CustomSettings<GameStateSettings>.I.m_demoMaxLevel;

		public static float DefaultMoneyAmount => CustomSettings<GameStateSettings>.I.m_defaultMoneyAmount;

		public static int DefaultAttractionScore => CustomSettings<GameStateSettings>.I.m_defaultAttractionScore;

		public static int ShopMaxLevel
		{
			get
			{
				if (CustomSettings<GameStateSettings>.I.m_demo)
				{
					return CustomSettings<GameStateSettings>.I.m_demoMaxLevel;
				}
				return CustomSettings<GameStateSettings>.I.m_shopMaxLevel;
			}
		}

		public static int GetXPTierForLevelToReach(int levelToReach)
		{
			return CustomSettings<GameStateSettings>.I.m_xpTiersFormula.Compute(levelToReach);
		}
	}
}
