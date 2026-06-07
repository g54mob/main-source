using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Battle
{
	public abstract class EnemyCluster : ScriptableObject
	{
		[Serializable]
		protected struct SpawnDegree
		{
			public float start;

			public float end;
		}

		public class SpawnFilter
		{
			private float _minFilterAngle;

			private float _maxFilterAngle;

			public bool EnabledFilter { get; private set; }

			public void EnableSpawnFilter(eEnemyType type, float minAngle, float maxAngle)
			{
			}

			public void DesableSpawnFilter()
			{
			}

			public bool CheckSpawnable(float value)
			{
				return false;
			}
		}

		public class EnemyLevelInfo
		{
			public int level;

			public eEnemy enemy;

			public eEnemyType enemyType;

			public double baseFrequencyPerMinutes;

			public int maxEmissionCount;

			public float firstDeray;

			public int value;

			public float enemySpan;

			public bool waitOtherEnemy;

			public int shield;

			public int maxLevel;

			public int selectCount;

			public int hp;

			public int attack;

			public int townAttack;

			public float speed;

			public EnemyLevelInfo(eEnemy enemy, eEnemyType enemyType)
			{
			}

			public void OverwriteEnemyLevel(MstEnemyLevelEntities waveLevelData)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CSpawnEnemy_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EnemyCluster _003C_003E4__this;

			public int value;

			private int _003Ci_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSpawnEnemy_003Ed__33(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		[Label("出現円半径")]
		protected Vector2 spawnCircleRadius;

		[SerializeField]
		[Label("出現角度")]
		protected List<SpawnDegree> spawnDegrees;

		[SerializeField]
		[Label("有効：登録順")]
		protected bool isOrder;

		protected int _spawnIndex;

		private bool _spawnOk;

		private EnemyLevelInfo enemyLevelInfo;

		protected BaseEnemy _enemyObjCache;

		private int _emissionGroupCount;

		protected SpawnFilter spawnFilter;

		protected double nextRap;

		protected int spawnGroupIndex;

		public bool SpawnOk
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public EnemyLevelInfo EnemyLevelData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public BaseEnemy EnemyObjCache => null;

		private bool EmissionOk => false;

		public BaseEnemy CreateEnemyObj(bool registerCache = true)
		{
			return null;
		}

		public void OverwriteEnemyLevel(MstEnemyLevelEntities entity)
		{
		}

		public void ResetEnemyObj()
		{
		}

		public virtual void SettingCluster()
		{
		}

		public virtual void StartCluster()
		{
		}

		public void EndCluster()
		{
		}

		public virtual void UpdateCluster()
		{
		}

		public float GetIncreaseRate(float t)
		{
			return 0f;
		}

		protected virtual (bool, Vector3) PositionSetting()
		{
			return default((bool, Vector3));
		}

		[IteratorStateMachine(typeof(_003CSpawnEnemy_003Ed__33))]
		protected virtual IEnumerator SpawnEnemy(int value)
		{
			return null;
		}

		protected virtual void SpawnEnemy()
		{
		}

		protected virtual void CreateInstance(Vector3 initPos)
		{
		}

		protected virtual void PreSpawnAction(BaseEnemy enemyObj, Vector3 initPos)
		{
		}

		public void EnableSpawnFilter(float minAngle, float maxAngle)
		{
		}

		public void DesableSpawnFilter()
		{
		}
	}
}
