namespace TMPEffects.Databases
{
	public interface ITMPEffectDatabase
	{
		bool ContainsEffect(string name);
	}
	public interface ITMPEffectDatabase<out T> : ITMPEffectDatabase
	{
		T GetEffect(string name);
	}
}
