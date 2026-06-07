using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Delivery Sell Multipliers")]
	public class LevelSettingDeliverySellMultiplier : LevelSetting
	{
		[SerializeField]
		private float _successMultiplier = 5f;

		[SerializeField]
		private float _failureMultiplier = 0.5f;

		public override void Apply()
		{
			if (CTSSingleton<CharacterDeliveries>.TryGetInstance(out var outInstance))
			{
				outInstance.SetSuccessMultiplier(_successMultiplier);
				outInstance.SetFailureMultiplier(_failureMultiplier);
			}
		}
	}
}
