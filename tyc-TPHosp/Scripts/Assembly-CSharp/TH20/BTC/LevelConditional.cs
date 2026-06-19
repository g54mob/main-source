using BehaviorDesigner.Runtime.Tasks;

namespace TH20.BTC
{
	[DontSave]
	public abstract class LevelConditional : Conditional
	{
		public new LevelScriptBehaviorTree Owner
		{
			get
			{
				LevelScriptBehaviorTree obj = (LevelScriptBehaviorTree)base.Owner;
				if (!obj)
				{
					throw new Debug.AssertException("Trying to access level tree from an level task that isn't owned by an level behavior tree");
				}
				return obj;
			}
		}
	}
}
