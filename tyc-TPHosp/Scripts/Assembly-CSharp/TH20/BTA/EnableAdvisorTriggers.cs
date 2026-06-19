using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA
{
	[TaskCategory(" TH20/Advisor")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/AdvisorIcon.png")]
	public class EnableAdvisorTriggers : ExpiringLevelAction
	{
		[UsedImplicitly]
		public List<SharedInstance_TH20TH20_Advisor_ConfigCollection> AdvisorTriggerList;

		public override TaskStatus OnUpdate()
		{
			if (HasTaskExpired())
			{
				return TaskStatus.Success;
			}
			if (AdvisorTriggerList != null)
			{
				foreach (SharedInstance_TH20TH20_Advisor_ConfigCollection advisorTrigger in AdvisorTriggerList)
				{
					if (!advisorTrigger.IsNull())
					{
						base.Owner.Level.Advisor.AddTriggerCollection(advisorTrigger.Instance);
					}
				}
			}
			return TaskStatus.Success;
		}
	}
}
