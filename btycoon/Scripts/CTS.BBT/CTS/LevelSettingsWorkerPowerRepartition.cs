using CTS.Core;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Levels/Settings/Power Repartition")]
	public class LevelSettingsWorkerPowerRepartition : LevelSetting
	{
		[SerializeField]
		private PercentageList<WorkerPowerFeature.e_PowerFeatures> _repartition;

		public override void Apply()
		{
			MonoSingleton<WorkerSpawner>.Instance.SetPowerRepartition(_repartition);
		}
	}
}
