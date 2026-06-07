namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface IInputController
	{
		bool Active { get; }

		string InputId { get; }

		float Value { get; }

		bool Visible { get; set; }
	}
}
