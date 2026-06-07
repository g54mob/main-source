using UnityEngine;

namespace Battle
{
	public interface IBattleCycle
	{
		eBattleTag Tag { get; }

		int TypeNum { get; }

		int UniquTypeNum { get; }

		bool Alive { get; }

		bool FinishInit { get; }

		bool Moveable { get; }

		GameObject GameObj { get; }

		Transform Tf { get; set; }

		int AttackPoint { get; }

		int CurrentHp { get; }

		int MaxHp { get; }

		int Shield { get; }

		float Speed { get; }

		double Lifetime { get; }

		void DestroyObj();

		void LastUpdate();

		string DebugDetailLog();
	}
}
