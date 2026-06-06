public static class DrifterAttributesEffectExtensions
{
	public static Agent.EGender ReturnGender(this DrifterAttributesEffect background, Agent.EGender fallback)
	{
		if ((bool)background && background.ForceGender)
		{
			return background.Gender;
		}
		return fallback;
	}
}
