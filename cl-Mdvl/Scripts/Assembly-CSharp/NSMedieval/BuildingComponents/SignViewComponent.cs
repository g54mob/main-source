using System;

namespace NSMedieval.BuildingComponents
{
	public class SignViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private SignComponent signComponent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			signComponent = GetComponent<SignComponent>();
		}
	}
}
