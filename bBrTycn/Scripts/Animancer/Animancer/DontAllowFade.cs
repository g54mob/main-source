using System.Diagnostics;

namespace Animancer
{
	public class DontAllowFade : Key, IUpdatable, Key.IListItem
	{
		[Conditional("UNITY_ASSERTIONS")]
		public static void Assert(AnimancerPlayable animancer)
		{
		}

		private static void Validate(AnimancerNode node)
		{
			if (node != null && node.FadeSpeed != 0f)
			{
				node.Weight = node.TargetWeight;
			}
		}

		void IUpdatable.Update()
		{
			AnimancerPlayable.LayerList layers = AnimancerPlayable.Current.Layers;
			for (int num = layers.Count - 1; num >= 0; num--)
			{
				AnimancerLayer animancerLayer = layers[num];
				Validate(animancerLayer);
				Validate(animancerLayer.CurrentState);
			}
		}
	}
}
