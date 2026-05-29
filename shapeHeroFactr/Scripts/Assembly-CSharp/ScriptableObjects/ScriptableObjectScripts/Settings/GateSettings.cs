using System;
using System.Collections.Generic;
using Battle;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Settings
{
	public class GateSettings : ScriptableObject
	{
		[Serializable]
		public struct HpGateStr
		{
			public float percent;

			[Label("基本固定")]
			public string animationStr;

			[Label("出現アニメーション名")]
			public string spawnStr;

			[Label("フェードアニメーション名")]
			public string fadeStr;
		}

		[Label("初期ゲートHP")]
		public int initialGateHp;

		[Label("ゲートの当たり判定(半径)")]
		public float gateCollisionRadius;

		[Label("有効：待機中のユニット放出")]
		public bool enableStandbyUnitSally;

		[Label("ゲート変化HP割合")]
		[Tooltip("HPがn*100%を切ったとき、ゲートアニメーションが変化上から(普通時、微ダメージ、深刻)ダメージ、回復、最大HP増加ごとに更新")]
		public List<HpGateStr> hpStrs;
	}
}
