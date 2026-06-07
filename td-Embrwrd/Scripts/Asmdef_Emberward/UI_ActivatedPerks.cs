using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ActivatedPerks : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private Transform note_Grid;

	[SerializeField]
	private GridLayoutGroup gridLayout;

	[SerializeField]
	private GameObject prefab_PerkIcon;

	private List<Obj_UI_PerkIcon> list_PerkIcons;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	private void OnPerkChanged(APerkBase perk)
	{
	}
}
