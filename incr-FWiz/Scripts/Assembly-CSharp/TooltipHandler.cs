using System.Collections.Generic;
using UnityEngine;

public class TooltipHandler : MonoBehaviour
{
	[SerializeField]
	private Transform _tooltipParent;

	[SerializeField]
	private List<ObjectTooltip> _objectTooltipPrefabs;

	private List<ObjectTooltip> _activeObjectTooltips;

	public static TooltipHandler Instance { get; private set; }

	public void Initiate()
	{
	}

	public void ShowObjectTooltip(object obj, Transform tooltipParent = null)
	{
	}

	public void HideObjectTooltip(object obj)
	{
	}
}
