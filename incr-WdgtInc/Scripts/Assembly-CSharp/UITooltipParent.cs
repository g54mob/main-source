using UnityEngine;

public class UITooltipParent : MonoBehaviour
{
	[SerializeField]
	private UITooltip _tooltipPrefab;

	private void Awake()
	{
		UITooltip.SetupTooltipContext(_tooltipPrefab, base.transform as RectTransform);
	}
}
