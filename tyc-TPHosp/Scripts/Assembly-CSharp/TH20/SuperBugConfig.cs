using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SuperBugConfig
	{
		public List<SharedInstance<SuperBugObjectiveDefinition>> SuperBugObjectiveList;

		public List<SuperBugNodeRewardInfo> SuperBugRewardInfos;

		public List<Sprite> SuperBugUnreferencedSprites;
	}
}
