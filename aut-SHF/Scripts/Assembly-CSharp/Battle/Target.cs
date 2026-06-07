using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class Target
	{
		[Serializable]
		public struct SearchEnemyDetailOption
		{
			public eEnemy enemy;

			[Tooltip("子などのサブ要因を対象にする(弾は該当しない)。例：プラントの子、ナーガの子、ドラゴンの柱など")]
			public bool isSub;
		}

		public class TargetObj
		{
			public IBattleCycle battleObj;

			public int predictPower;

			public TargetObj(IBattleCycle battleObj, int predictPower)
			{
			}
		}

		[Label("有効：ターゲット")]
		public bool enabledTarget;

		[Label("検索範囲")]
		public float searchRadius;

		[Tooltip("上から優先に処理")]
		public List<SearchOption> searchOptions;

		[Tooltip("見当たらなかったときなどの再検索オプション")]
		public List<SearchOption> secondarySearchOptions;

		[Label("ノーヒットランダム")]
		[Tooltip("検索後ノーヒットの場合ランダムな敵に飛んでいくかどうか")]
		public bool noPoolRandom;

		[Header("検索詳細")]
		[Label("SearchEnemyType詳細")]
		[Tooltip("searchOptionsでSearchEnemyTypeを選択した場合のみ利用可能(上から優先)")]
		public List<SearchEnemyDetailOption> searchEnemyOrder;

		[Label("FilterEffect詳細")]
		[Tooltip("searchOptionsでFilterEffectを選択した場合のみ利用可能(上から優先してターゲットから除去)")]
		public List<eStatusEffect> filterSearchEffect;

		[Label("RemoveDistance詳細")]
		[Tooltip("RemoveDistanceを選択済みの場合有効；拠点からの半径n内の敵を検索から除去。出現範囲より狭くするとヒーローが拠点側に追いかけていく可能性あり")]
		public float removeDistanceRange;

		[Label("RemoveEnemyType詳細")]
		[Tooltip("RemoveEnemyTypeを選択済みの場合有効。指定した敵を検索から除外")]
		public List<eEnemy> removeEnemyType;

		[Space]
		[Label("扇形判定用角度")]
		public float searchAngleRanges;

		[Label("グループリーダー上書き")]
		[Tooltip("ターゲット候補にシーサーペントのような複数で１個体としている敵がいる場合にそのグループのRoot要素がターゲットされたこととする")]
		public bool overwriteGroupRoot;

		private BaseEnemy _targetEnemy;

		private int targetInstanceId;

		private const int BATTLE_ENEMY_LAYER = 8;

		private static readonly LayerMask enemyLayer;

		private List<Vector3> _searchPoints;

		public BaseEnemy TargetEnemy
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int TargetInstanceId
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool HasTarget => false;

		public void InitParameter(Target target)
		{
		}

		public List<BaseEnemy> SearchAliveTargetInCircle(Vector3 searchOrigin, float? radiusValue = null)
		{
			return null;
		}

		public void GroupByIdAndExchangeRoot(ref List<BaseEnemy> enemies, bool? exchangeGroupRoot = null)
		{
		}

		public List<BaseEnemy> FilterTarget(eSearchType[] options, List<BaseEnemy> hitEnemies, IBattleCycle battleObj, bool reSearch = true)
		{
			return null;
		}

		public List<BaseEnemy> FilterTarget(List<BaseEnemy> hitEnemies, IBattleCycle battleObj, bool reSearch = true)
		{
			return null;
		}

		public void FilterBranch(ref List<BaseEnemy> hitEnemies, IBattleCycle battleObj, SearchOption searchOption)
		{
		}

		public List<BaseEnemy> FilterEnemy(List<BaseEnemy> hitEnemies)
		{
			return null;
		}

		public List<BaseEnemy> FilterStatusEffect(List<BaseEnemy> hitEnemies)
		{
			return null;
		}

		public List<BaseEnemy> SearchMostFarDistance(List<BaseEnemy> hitEnemies)
		{
			return null;
		}

		public List<BaseEnemy> SearchMostFarDistance(List<BaseEnemy> hitEnemies, Vector3 origin)
		{
			return null;
		}

		public List<BaseEnemy> SearchMostNearDistance(List<BaseEnemy> hitEnemies)
		{
			return null;
		}

		public List<BaseEnemy> RemoveTargetedAll(List<BaseEnemy> enemies)
		{
			return null;
		}

		public List<BaseEnemy> RemoveTargetedSameHero(List<BaseEnemy> enemies, int uniquTypeNum)
		{
			return null;
		}

		public bool RegisterTarget(List<BaseEnemy> hitEnemies, BaseUnit baseUnit)
		{
			return false;
		}

		public bool RegisterTarget(List<BaseEnemy> hitEnemies, BaseMiracle baseMiracle)
		{
			return false;
		}

		public bool RegisterTarget(List<BaseEnemy> hitEnemies, TargetObj targetObj)
		{
			return false;
		}

		public bool HitTarget(BaseEnemy enemy)
		{
			return false;
		}

		private bool IsNearTown(Vector3 comparator, Vector3 myPosition)
		{
			return false;
		}

		public List<BaseEnemy> RemoveDistanceEnemy(List<BaseEnemy> enemies, Vector3 origin, float? ignoreNearDistance = null)
		{
			return null;
		}

		public void RemoveDistanceEnemy(ref List<BaseEnemy> enemies, Vector3 origin, float? ignoreNearDistance = null)
		{
		}

		public void ResetTarget(IBattleCycle battleObj, int resetLevel = 0)
		{
		}

		public List<BaseEnemy> RemovePriorityIsLarge(List<BaseEnemy> enemies, int uniquTypeNum)
		{
			return null;
		}

		public void RemovePriorityIsLarge(ref List<BaseEnemy> enemies, int uniquTypeNum)
		{
		}

		public List<BaseEnemy> RemoveEnemyType(List<BaseEnemy> enemies, int uniquTypeNum)
		{
			return null;
		}

		public void RemoveEnemyType(ref List<BaseEnemy> enemies, int uniquTypeNum)
		{
		}

		public void CheckTargetNear(Vector3 nowPosition, BaseUnit hero)
		{
		}

		public List<BaseEnemy> SearchTargetInFan(List<BaseEnemy> hitEnemies, Vector3 origin, float angle, float ignoreDistance = 0f)
		{
			return null;
		}

		public List<BaseEnemy> SearchTargetInFan(List<BaseEnemy> hitEnemies, Vector3 origin, Vector3 dir, float ignoreDistance = 0f)
		{
			return null;
		}

		public List<BaseEnemy> SearchStraightLine(Vector3 startPos, Vector3 dir, float length, float tickness)
		{
			return null;
		}

		public void DrawGizmosStraightLine()
		{
		}
	}
}
