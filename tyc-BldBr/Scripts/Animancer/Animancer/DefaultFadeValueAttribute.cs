namespace Animancer
{
	public class DefaultFadeValueAttribute : DefaultValueAttribute
	{
		public override object Primary => AnimancerPlayable.DefaultFadeDuration;

		public DefaultFadeValueAttribute()
		{
			Secondary = 0f;
		}
	}
}
