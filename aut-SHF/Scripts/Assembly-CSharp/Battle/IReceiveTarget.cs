using System;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
	public interface IReceiveTarget
	{
		[Serializable]
		public class TargetPriority
		{
			public eBattleTag battleTag;

			[Header("どちらか片方入力")]
			public eUnit unitType;

			public eMiracle miracleType;

			public int priority;

			public int GetUniquTypeNum()
			{
				return 0;
			}
		}

		bool InvalidTarget { get; }

		eSpecialTargetLabel SpecialTargetLabel { get; }

		bool IsTarget { get; }

		bool TargetOk { get; }

		int TargetCount { get; }

		List<Target.TargetObj> TargetObjs { get; set; }

		TargetPriority[] TargetPriorities { get; }

		List<Target.TargetObj> PriorityHero { get; set; }

		int GetMaxPriority { get; }

		int? TargetGroupId { get; set; }

		BaseEnemy TargetGroupRoot { get; set; }

		bool IsOverKill(bool plusStatus);

		int GetTargetPriority(int uniquTypeNum);

		void SettingTargetGroup(BaseEnemy root)
		{
		}

		void ReceiveTarget(Target.TargetObj unit);
	}
}
