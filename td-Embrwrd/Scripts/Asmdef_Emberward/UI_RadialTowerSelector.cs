using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RadialTowerSelector : AUISituational
{
	[SerializeField]
	private List<Obj_UI_RadialBuildTowerItem> list_towerItems;

	[SerializeField]
	private RectTransform node_Root;

	[SerializeField]
	private RectTransform node_Content;

	[SerializeField]
	private RectTransform radialRoot;

	[SerializeField]
	private Image image_ControlIcon;

	[SerializeField]
	private float controlIconMoveRadius;

	[SerializeField]
	private Transform node_TooltipAnchor;

	private int curSelectedIndex;

	private bool isActivated;

	private bool isReceivedInputSinceActivated;

	private Vector3 startMousePos;

	private bool isUIClosedByOtherCommand;

	private bool isTooltipOn;

	private void Update()
	{
	}

	private void CloseUI(bool doBuildSelection)
	{
	}

	private int GetSectorIndex(float angle, int sectorCount)
	{
		return 0;
	}

	private float GetDegreeByMousePosition()
	{
		return 0f;
	}

	private float GetDegreeByControllerAxis(float deadZone = 0.2f)
	{
		return 0f;
	}
}
