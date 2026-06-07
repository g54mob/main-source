namespace Febucci.UI.Core
{
	public class TypingInfo
	{
		public float speed = 1f;

		public float timePassed { get; internal set; }

		public TypingInfo()
		{
			speed = 1f;
			timePassed = 0f;
		}
	}
}
