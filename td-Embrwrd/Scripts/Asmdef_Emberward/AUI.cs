using UnityEngine;

public class AUI : MonoBehaviour, IKeybindRegister
{
	protected void RegisterKeybind(string Key)
	{
	}

	protected void UnregisterKeybind()
	{
	}

	public virtual void OnTriggerKeybind(string keyName)
	{
	}
}
