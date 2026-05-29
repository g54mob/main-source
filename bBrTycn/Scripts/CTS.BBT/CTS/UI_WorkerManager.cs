using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerManager : CTSSingleton<UI_WorkerManager>
	{
		[SerializeField]
		private SerializableDictionary<WorkerPowerFeature.e_PowerFeatures, VampirePowerData> _powerDatas;

		[SerializeField]
		private SerializableDictionary<ChoreCategory, ChoreCategoryData> _choreCategoryDatas;

		public ReadOnlyDictionary<WorkerPowerFeature.e_PowerFeatures, VampirePowerData> PowerDatas => _powerDatas;

		public ReadOnlyDictionary<ChoreCategory, ChoreCategoryData> ChoreCategoryDatas => _choreCategoryDatas;

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
