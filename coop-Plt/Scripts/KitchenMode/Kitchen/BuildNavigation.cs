using UnityEngine;

namespace Kitchen
{
	[FilterModes(AllowedModes = GameSetupMode.All)]
	public class BuildNavigation : GameSystemBase
	{
		protected override void Initialise()
		{
			base.Initialise();
			RebuildNavigation();
		}

		protected override void OnUpdate()
		{
			if (Random.value < 0.0001f)
			{
				RebuildNavigation();
			}
		}

		public void RebuildNavigation()
		{
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
