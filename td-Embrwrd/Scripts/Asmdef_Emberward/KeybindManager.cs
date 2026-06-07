using System.Collections.Generic;

public class KeybindManager : Singleton<KeybindManager>
{
	public class KeybindDic : SerializableDictionary<string, List<KeybindEntry>>
	{
	}

	private KeybindDic keybindDic;

	public void RegisterKeybind(string keyName, KeybindEntry obj)
	{
	}

	public void UnregisterKeybind(IKeybindRegister obj)
	{
	}

	public bool IsHaveAnyKeybind(IKeybindRegister obj)
	{
		return false;
	}

	private void Update()
	{
	}
}
