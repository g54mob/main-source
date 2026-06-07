using TMPro;
using UnityEngine;

public class AppStoreTooltipUI : MonoBehaviour
{
	public RectTransform tooltipTransform;

	public TMP_Text tooltipText;

	public Vector3 offset;

	public Camera cam;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private Vector3 GetWorldMousePosition()
	{
		return default(Vector3);
	}

	public void ShowTooltip(string text)
	{
	}

	public void HideTooltip()
	{
	}
}
