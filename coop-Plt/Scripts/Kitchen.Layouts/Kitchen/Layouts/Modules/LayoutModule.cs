using UnityEngine;
using XNode;

namespace Kitchen.Layouts.Modules
{
	[NodeWidth(300)]
	public abstract class LayoutModule : Module<LayoutBlueprint>
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Override, TypeConstraint.None, false)]
		public LayoutGraphConnection Input;

		public int FixSeed;

		public abstract void ActOn(LayoutBlueprint blueprint);

		protected override LayoutBlueprint Generate()
		{
			if (TryGetInput<LayoutBlueprint>("Input", out LayoutBlueprint result))
			{
				LayoutBlueprint layoutBlueprint = new LayoutBlueprint(result);
				Random.State state = Random.state;
				if (FixSeed != 0)
				{
					Random.InitState(FixSeed);
				}
				ActOn(layoutBlueprint);
				if (FixSeed != 0)
				{
					Random.state = state;
				}
				return layoutBlueprint;
			}
			return null;
		}

		public override Texture2D GenerateTexture()
		{
			return null;
		}
	}
}
