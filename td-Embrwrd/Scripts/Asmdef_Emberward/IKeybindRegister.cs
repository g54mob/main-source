public interface IKeybindRegister
{
	void RegisterKeybind(string keyName)
	{
	}

	void UnregisterKeybind()
	{
	}

	void OnTriggerKeybind(string keyName);
}
