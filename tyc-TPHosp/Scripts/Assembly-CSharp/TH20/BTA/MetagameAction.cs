using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTA
{
	[DontSave]
	public abstract class MetagameAction : Action
	{
		public new MetagameBehaviorTree Owner
		{
			get
			{
				MetagameBehaviorTree obj = (MetagameBehaviorTree)base.Owner;
				if (!obj)
				{
					throw new Debug.AssertException("Trying to access metagame tree from an metagame task that isn't owned by an metagame behavior tree");
				}
				return obj;
			}
		}
	}
}
