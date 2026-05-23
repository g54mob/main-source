using Battle;
using Factory.FieldData;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public class CustomRuleSetting : ScriptableObject
	{
		[Header("カスタムルール適用時設定")]
		[Header("敵倒すまで終わらないルール(finishWaveAllEliminate)")]
		[Label("タイムオーバーダメージ間隔(s)")]
		public double timeOverDamageInterval;

		[Label("タイムオーバーダメージ量")]
		public int timeOverDamageValue;

		[Label("ダメージAudio回数")]
		public int timeOverDamageSplit;

		[Label("duration")]
		public double timeOverDamageDuration;

		[Header("試練の設定")]
		[Label("知識の試練のイベントタイプ")]
		public eRouteEvent ordealKnowledgeEvent;

		[Label("魂の試練必要エネルギー（経験値）")]
		public int needSpiritEnergy;

		[Label("魂の試練必要エネルギー（資源）")]
		public int needSpiritEnergyShigen;

		public double GetTimeOverDamageInterval => 0.0;

		public int GetNeedSpiritEnergy(FactoryContext.AltarOfSpiritType alterType)
		{
			return 0;
		}
	}
}
