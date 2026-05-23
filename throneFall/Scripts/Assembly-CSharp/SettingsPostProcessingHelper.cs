using UnityEngine;
using UnityEngine.Rendering;

public class SettingsPostProcessingHelper : MonoBehaviour
{
	public Volume target;

	private void Start()
	{
		Refresh();
		SettingsManager.Instance.onPPSettingsChange.AddListener(Refresh);
	}

	private void Refresh()
	{
		target.enabled = SettingsManager.Instance.PostProcessing;
	}
}
