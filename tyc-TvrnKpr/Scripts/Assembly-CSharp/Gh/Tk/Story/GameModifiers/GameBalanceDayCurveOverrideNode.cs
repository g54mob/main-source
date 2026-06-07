using Gh.Tk.Story.Config;
using XNode;

namespace Gh.Tk.Story.GameModifiers
{
	public class GameBalanceDayCurveOverrideNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		public DayCurveOverrideConfig[] overrides;

		public static string GetOverride(DayCurveTypes type, string key)
		{
			return null;
		}
	}
}
