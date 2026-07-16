using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
	[SerializeField]
	private SimpleTooltip tooltip;

	public static TooltipSystem Instance { get; private set; }

	public void Awake()
	{
		Instance = this;
	}

	public void Show(string content, string header = "", GameObject target = null)
	{
		tooltip.SetText(content, header, target);
		tooltip.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		tooltip.gameObject.SetActive(value: false);
	}
}
