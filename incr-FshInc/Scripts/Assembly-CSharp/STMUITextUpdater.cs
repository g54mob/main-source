using UnityEngine;
using UnityEngine.UI;

public class STMUITextUpdater : MonoBehaviour
{
	public Text uiText;

	public SuperTextMesh stm;

	private bool needsUpdate = true;

	private void OnEnable()
	{
		needsUpdate = true;
	}

	private void LateUpdate()
	{
		if (needsUpdate)
		{
			needsUpdate = true;
			stm.text = uiText.text;
			stm.gameObject.SetActive(uiText.enabled);
		}
	}

	public void UpdateText()
	{
		needsUpdate = true;
	}
}
