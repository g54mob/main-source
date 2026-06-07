using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class UnitInfo
	{
		[HideInInspector]
		public eActionType actionType;

		[HideInInspector]
		public eEndLifeType endLifeType;

		[HideInInspector]
		public eAnimationType animationType;

		[HideInInspector]
		[Tooltip("1なら敵のHPを1削れる")]
		public int attackPoint;

		[HideInInspector]
		public double lifeTime;

		[HideInInspector]
		[Tooltip("0の場合停止")]
		public float speed;

		[HideInInspector]
		public bool enabledTarget;

		[Tooltip("上から優先に処理")]
		[HideInInspector]
		public List<SearchOption> searchOption;

		[Tooltip("0の場合全フィールド中から検索")]
		[HideInInspector]
		public float searchRadius;

		[Tooltip("検索対象からターゲット中の敵を外す")]
		[HideInInspector]
		public bool ignoreTargeted;

		[HideInInspector]
		public bool isMultiAttack;

		[HideInInspector]
		[Tooltip("範囲攻撃の発動を検知するエリアと実際の攻撃範囲を区別。0の場合ワイバーンのように当たった場所から波及するように範囲攻撃")]
		public float multiAttackSearchRadius;

		[HideInInspector]
		public float multiAttackRadius;

		[Tooltip("現在位置と街との正規化ベクトル*offsetScalar地点が範囲攻撃検索の原点になる。offsetScalarが大きいほど街から離れた場所で検索される")]
		[HideInInspector]
		public float offsetScalar;

		[HideInInspector]
		public bool enabledMoveInvincible;

		[HideInInspector]
		public bool enabledPenetrate;

		[HideInInspector]
		public float penetrateInterval;

		[HideInInspector]
		public bool enabledBoundaryReflection;

		[HideInInspector]
		public bool isRelectionComeFrom;

		[HideInInspector]
		public bool enabledKnockBack;

		[HideInInspector]
		public int knockBackLimit;

		[HideInInspector]
		public float knockBackStanSecond;

		[HideInInspector]
		public float knockBackPower;

		[HideInInspector]
		[Tooltip("forwardの向きをPathの方向に向ける")]
		public bool isLookAtPath;

		[HideInInspector]
		public Vector3 forward;

		[HideInInspector]
		[Tooltip("移動タイプがuseTweenの時のみ有効。DOTweenのpathに到達時に指定秒待つ")]
		public float wayPointWaitTime;

		[HideInInspector]
		[Tooltip("出現ユニットと実際に弾が当たるユニットが違う場合の追加要素。今のところcannonのみ")]
		public List<GameObject> additionalUnits;

		[Tooltip("additionalUnitsが出現する間隔。AdditionalUnitsが存在する場合に有効")]
		[HideInInspector]
		public float additionalSpan;

		public void OverWriteWithMstData(MstUnitDataEntities entity)
		{
		}
	}
}
