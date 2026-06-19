using UnityEngine;
using UnityEngine.UI;

public class FloraIconButton : MonoBehaviour
{
	public int index = -1;

	public FloraGUI guiRef;

	public Image mainImageRef;

	public Image highlightImageRef;

	public GameObject discoveryIndicator;

	private void Awake()
	{
		highlightImageRef.enabled = false;
		discoveryIndicator.SetActive(value: false);
	}

	public void OnClick()
	{
		guiRef.OnGutFloraIconClicked(index);
	}

	public void SetIsCompleted()
	{
	}

	public void EnableDiscoveryIndicator()
	{
		discoveryIndicator.SetActive(value: true);
	}
}
