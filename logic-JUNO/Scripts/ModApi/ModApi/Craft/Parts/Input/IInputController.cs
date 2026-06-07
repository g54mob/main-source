namespace ModApi.Craft.Parts.Input
{
	public interface IInputController
	{
		bool Active { get; }

		string InputId { get; }

		bool InvertOnMirror { get; set; }

		float Value { get; }

		bool Visible { get; set; }
	}
}
