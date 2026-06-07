using Jundroo.Common.Utils;

namespace Assets.Scripts.Craft.Parts.Modifiers.Car
{
	public class JWheelSuspensionScript : PartModifierScript
	{
		private IWheelSuspensionComponents _suspensionComponents;

		public JWheelSuspensionData Data { get; private set; }

		public void Initialize(JWheelSuspensionData data)
		{
			Data = data;
			_suspensionComponents = Utilities.GetFirstChildWithInterface<IWheelSuspensionComponents>(base.gameObject, includeInactive: true);
			_suspensionComponents.Initialize(this);
			_suspensionComponents.UpdateComponents(repositionWheels: false);
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			Data.ShockPosition = 0f - Data.ShockPosition;
			_suspensionComponents.UpdateComponents(repositionWheels: false);
		}

		public void OnPropertiesChanged()
		{
			_suspensionComponents.UpdateComponents(repositionWheels: true);
		}

		public void UpdateSuspensionVisuals(JWheelScript wheel, AttachPointData attachPoint)
		{
			_suspensionComponents.UpdateSuspensionVisuals(wheel, attachPoint);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
		}
	}
}
