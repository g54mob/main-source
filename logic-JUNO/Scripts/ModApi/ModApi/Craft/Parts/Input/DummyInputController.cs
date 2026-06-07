namespace ModApi.Craft.Parts.Input
{
	public class DummyInputController : IInputController
	{
		public bool Active => false;

		public string InputId { get; private set; }

		public bool InvertOnMirror { get; set; }

		public float Value => 0f;

		public bool Visible { get; set; }

		public DummyInputController(string id)
		{
			InputId = id;
		}
	}
}
