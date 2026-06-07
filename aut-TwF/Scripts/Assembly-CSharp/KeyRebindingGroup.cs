using UnityEngine;

public class KeyRebindingGroup : MonoBehaviour
{
	private SettingsElement_keyRebind[] keyRebindElements;

	public SettingsElement_keyRebind[] KeyRebindElements => keyRebindElements;

	private void Awake()
	{
		keyRebindElements = GetComponentsInChildren<SettingsElement_keyRebind>();
		SettingsElement_keyRebind[] array = KeyRebindElements;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].KeyRebindingGroup = this;
		}
	}
}
