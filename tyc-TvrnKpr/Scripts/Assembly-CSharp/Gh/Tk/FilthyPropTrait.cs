using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class FilthyPropTrait : PropTraitBase
	{
		private static float? _threshold;

		public static float Threshold => 0f;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void FilthOutputChanged(object sender, EventArgs<Prop> e)
		{
		}

		protected FilthyPropTrait()
		{
		}

		public FilthyPropTrait(Prop owner)
		{
		}

		private void PropOnUsageFinished(object sender, UsageEventArgs e)
		{
		}

		public override void OnRemoving()
		{
		}

		public override void Update()
		{
		}
	}
}
