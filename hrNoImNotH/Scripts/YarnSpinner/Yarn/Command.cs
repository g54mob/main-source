namespace Yarn
{
	public struct Command
	{
		public string Text { get; private set; }

		internal Command(string text)
		{
			Text = null;
		}
	}
}
