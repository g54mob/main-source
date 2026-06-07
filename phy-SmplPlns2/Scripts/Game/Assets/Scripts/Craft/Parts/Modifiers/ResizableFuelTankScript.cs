using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ResizableFuelTankScript : FuelTankScript
	{
		[SerializeField]
		private Transform _scaleRoot;

		public ResizableFuelTankData ResizableFuelTank { get; set; }

		public void UpdateSize()
		{
			_scaleRoot.localScale = ResizableFuelTank.Size * Vector3.one;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			UpdateSize();
		}
	}
}
