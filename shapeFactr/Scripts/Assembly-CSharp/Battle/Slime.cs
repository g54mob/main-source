using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public class Slime : BaseEnemy
	{
		[Header("スライム固有設定")]
		[SerializeField]
		[Label("分割回数")]
		private int _maxSplitCount;

		[Label("分割数")]
		[SerializeField]
		private int _splitValue;

		[Label("ステータス調整")]
		[Tooltip("上から分裂回数に応じたステータス。完全体ステータスの入力不要")]
		[SerializeField]
		private List<EnemyBaseInfo> _splitBaseInfos;

		[SerializeField]
		[Tooltip("消滅時の強制ノックバックパワー")]
		private float _eliminateKnockPower;

		private int _splitNum;

		public int SplitNum
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public EnemyBaseInfo OriginalInfo { get; private set; }

		private string GetSize()
		{
			return null;
		}

		private void SetScale()
		{
		}

		private void SetPosition(Vector3 prevPos)
		{
		}

		private void SplitSlime(int prevNum)
		{
		}

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		public override void DestroyObj()
		{
		}

		public override void Withdrawal()
		{
		}
	}
}
