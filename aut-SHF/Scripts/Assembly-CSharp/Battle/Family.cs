using UnityEngine;

namespace Battle
{
	public class Family : BaseEnemy
	{
		private FamilyMaster master;

		private bool _enterTown;

		private int _childIndex;

		private double _adulationTimer;

		private Vector3 PrevPos { get; set; }

		public bool Hide { get; set; }

		public void SetMaster(FamilyMaster value, int childIndex)
		{
		}

		public override void Init()
		{
		}

		public override void EnemyUpdate(double deltaTime)
		{
		}

		private Vector3 CulcChildDirectionVector()
		{
			return default(Vector3);
		}

		private void RegisterPos(double deltatime)
		{
		}

		protected override void AttackTown()
		{
		}

		public override void DestroyObj()
		{
		}
	}
}
