namespace Febucci.TextAnimatorCore.Typing
{
	public class TypingInfo
	{
		public float speed;

		public float timePassed;

		public TypingInfo(float speed = 1f)
		{
			this.speed = speed;
			timePassed = 0f;
		}
	}
}
