namespace Assets.Scripts.Craft.Parts.Modifiers.Car
{
	public interface IWheelSuspensionComponents
	{
		void Initialize(JWheelSuspensionScript suspension);

		void UpdateComponents(bool repositionWheels);

		void UpdateSuspensionVisuals(JWheelScript wheel, AttachPointData attachPoint);
	}
}
