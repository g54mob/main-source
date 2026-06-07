using TMPro;
using UnityEngine;

public class SaveProfileLabelUI : MonoBehaviour
{
	private void Start()
	{
		SaveSystem.instance.onActiveProfileChanged += OnSaveProfileChanged;
		OnSaveProfileChanged(SaveSystem.instance.CurrentProfile);
	}

	private void OnEnable()
	{
		OnSaveProfileChanged(SaveSystem.instance.CurrentProfile);
	}

	private void OnDestroy()
	{
		SaveSystem.instance.onActiveProfileChanged -= OnSaveProfileChanged;
	}

	private void OnSaveProfileChanged(SaveProfile profile)
	{
		GetComponentInChildren<TextMeshProUGUI>().text = profile?.DisplayName ?? "";
	}
}
