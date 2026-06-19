namespace Pug.UnityExtensions
{
	public class SimpleEditorProgressBar
	{
		private readonly string _title;

		private readonly int _steps;

		private int _currentStep;

		public SimpleEditorProgressBar(string title, int steps)
		{
			_title = title;
			_steps = steps;
		}

		public void Update(string message)
		{
		}

		public void Finish()
		{
		}
	}
}
