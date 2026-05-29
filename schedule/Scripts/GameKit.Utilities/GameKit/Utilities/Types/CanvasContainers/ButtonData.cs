namespace GameKit.Utilities.Types.CanvasContainers
{
	public class ButtonData : IResettable
	{
		public delegate void PressedDelegate(string key);

		private PressedDelegate _delegate;

		public string Text { get; protected set; }

		public string Key { get; protected set; }

		public void Initialize(string text, PressedDelegate callback, string key = "")
		{
		}

		public virtual void OnPressed()
		{
		}

		public virtual void ResetState()
		{
		}

		public void InitializeState()
		{
		}
	}
}
