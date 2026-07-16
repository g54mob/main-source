public interface IProgression
{
	void OnRegister()
	{
		ProgressionManager.Register(this);
	}

	void OnUnregister()
	{
		ProgressionManager.Unregister(this);
	}

	void OnUnlock(int level)
	{
	}
}
