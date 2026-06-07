using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Sea : BaseEnemy
	{
		[Serializable]
		private struct SeaChildLevel
		{
			[Label("レベル")]
			public int level;

			[Label("卵時ステータス")]
			public EnemyBaseInfo childEggStatus;

			[Label("ふ化時ステータス")]
			public EnemyBaseInfo childHatchStatus;

			[Label("個数(片側)")]
			public int childCountHalf;
		}

		private enum SeaActionState
		{
			None = 0,
			Spawn = 1,
			Move = 2,
			Wait = 3,
			Back = 4
		}

		private enum Parts
		{
			Head = 0,
			Body = 1,
			Teil = 2
		}

		[SerializeField]
		private ActionState<SeaActionState> state;

		[Header("体の設定")]
		[Label("体の最小スケール倍率")]
		[Tooltip("徐々に小さくなる体の最小スケール倍率")]
		public float minBodyScaleRate;

		[Label("体の数")]
		public int bodyCount;

		[Label("体の離れ具合(開始時)")]
		public float startOffset;

		[Label("体の離れ具合(正円時)")]
		[Tooltip("円が小さくなっていくほど見た目上遅くなっていくので補正")]
		public float endOffset;

		[Label("終了時スピード倍率")]
		[Tooltip("speed*nが一番小さい円になったときのスピード")]
		public float endSpeedIncrease;

		[Header("渦の設定")]
		[Label("楕円終了時間(s)")]
		[Tooltip("どれだけSpeedが早くなっても正円になるまでの時間はこの秒数で決まる")]
		public float finishEllipseTime;

		[Label("開始楕円半径")]
		public Vector2 ellipseRadius;

		[Label("正円移行距離")]
		[Tooltip("楕円から正円の動きに変わる地点。拠点からの距離")]
		public float stopRadius;

		[Header("子の設定")]
		[SerializeField]
		private SeaChild childPrefab;

		[SerializeField]
		[Label("生産範囲(角度)")]
		[Tooltip("片側にこの値の2倍の角度の間で卵を生産する")]
		private float produceRadius;

		[Label("卵の個数(片側)")]
		[Tooltip("生産間隔は自動計算になりました。(生産範囲 * 2 / n)の角度ごとにスポーン")]
		public int childCountHalf;

		[Label("出現場所ばらつき")]
		public float spawnRadius;

		[SerializeField]
		private List<SeaChildLevel> childLevelStatus;

		[Label("ふ化秒数(s)")]
		[Tooltip("正円モードに入ってからのふ化するまでの秒数")]
		public float hatchingTime;

		private Parts _parts;

		private float _minBodyScale;

		private float _nowRad;

		private Sea _head;

		private int _bodyIdx;

		private float _elapsedTime;

		private float _startSpeed;

		private List<SeaChild> _children;

		private int _outputChild;

		private bool _isHatched;

		private float _finishTime;

		private float _endSpeed;

		private float _initDeg;

		private int _maxChildCountHalf;

		private float _spawnIntervalCounter;

		private float _remainCount;

		private float _spawnIntervalRad;

		private SeaChildLevel _childLevelStatus;

		private List<Sea> _bodys;

		private bool IsHead => false;

		private float NormalizedTime => 0f;

		private bool CheckGateDistance => false;

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override void LastUpdate()
		{
		}

		private void Motion(double deltaTime)
		{
		}

		private void Wait()
		{
		}

		private void Move(float floatDelta)
		{
		}

		private void HatchAll()
		{
		}

		private void Back()
		{
		}

		private void WarpEnd()
		{
		}

		public override void MovePosition(Vector3 velocity)
		{
		}

		private void CreateBody(int count)
		{
		}

		private void CreateChild()
		{
		}

		public override bool ReceiveDamage(int unitAttackPoint, eLuggage giverLuggage, bool displayDamage = true, bool isAdditionalDamage = true)
		{
			return false;
		}

		public override bool ReceiveStatusDamage(int damagePoint, eLuggage giverLuggage, SpriteNo.eDamageType damageType, bool displayDamage = true)
		{
			return false;
		}

		protected override void HitEffect()
		{
		}

		public override void NockBack(float knockBackPower, float registanceMinus = 0f)
		{
		}

		private void KnockBackProcess(float backTime)
		{
		}

		public override void DestroyObj()
		{
		}

		public void DestroyBodyAll()
		{
		}

		public void DestroyChildAll()
		{
		}

		private Vector3 GetWarpPosition()
		{
			return default(Vector3);
		}

		private void PetrifactionProcess(eStopType type)
		{
		}

		private void ReleasePetrifaction(eStopType type)
		{
		}

		private void ChangeActionState(double waitTime, SeaActionState nextState)
		{
		}
	}
}
