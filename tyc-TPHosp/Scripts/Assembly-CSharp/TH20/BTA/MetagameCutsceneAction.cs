namespace TH20.BTA
{
	[DontSave]
	public abstract class MetagameCutsceneAction : MetagameAction
	{
		public new MetagameCutsceneBehaviorTree Owner
		{
			get
			{
				MetagameCutsceneBehaviorTree obj = (MetagameCutsceneBehaviorTree)base.Owner;
				if (!obj)
				{
					throw new Debug.AssertException("Trying to access metagame cutscene tree from an metagame task that isn't owned by an metagame cutscene behavior tree");
				}
				return obj;
			}
		}
	}
}
