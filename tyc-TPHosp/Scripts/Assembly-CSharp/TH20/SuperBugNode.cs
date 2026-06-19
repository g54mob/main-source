using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SuperBugNode : CollaborativeNode
	{
		public Vector2 Position;

		public int ProgressBoost;

		public List<IRewardMetagame> Rewards;

		public SuperBugNodeRewardInfo RewardInfo;
	}
}
