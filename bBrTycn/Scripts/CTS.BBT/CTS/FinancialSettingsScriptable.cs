using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Financial/Create New Financial Settings", fileName = "New Financial Settings")]
	public class FinancialSettingsScriptable : LevelSetting
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Base Settings")]
		public float InsuranceCosts;

		[SerializeField]
		[BoxGroup("Base Settings")]
		public float EnergyCosts;

		public override void Apply()
		{
			MonoSingleton<ChargesHandlers>.Instance.SetFinancialSettings(this);
		}
	}
}
