public abstract class ScriptSingleton<T> where T : class, new()
{
	public static bool HasInstance => Current != null;

	public static T Current { get; private set; }

	public static T Instance
	{
		get
		{
			if (HasInstance)
			{
				return Current;
			}
			Current = new T();
			return Current;
		}
	}
}
