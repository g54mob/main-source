using UnityEngine;

namespace Gh.Tk
{
	public class Earthquake : WeatherEffectBase, ICustomSaveState
	{
		[Header("Earthquake specific")]
		[Tooltip("use this instead of minDurationInHours")]
		public int minDurationInSeconds;

		[Tooltip("use this instead of maxDurationInHours")]
		public int maxDurationInSeconds;

		private GametimeTimer _timer;

		private void Start()
		{
		}

		public override float GetTargetDurationInGameHours()
		{
			return 0f;
		}

		public override void StartEffect(float intensity)
		{
		}

		public override void UpdateEffect(float progress)
		{
		}

		public override void StopEffect()
		{
		}

		public override string GetAlertType()
		{
			return null;
		}

		private void ApplyPropDamageTick()
		{
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}
	}
}
