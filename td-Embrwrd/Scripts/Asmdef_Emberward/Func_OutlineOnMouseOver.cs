using System.Collections.Generic;
using UnityEngine;

public class Func_OutlineOnMouseOver : MonoBehaviour
{
	[SerializeField]
	private List<Renderer> list_Renderers;

	[Header("邊框類型")]
	[SerializeField]
	private OutlineController.eOutlineType outlineType;

	[SerializeField]
	private bool showInEditMode;

	[SerializeField]
	private bool showInNotEditMode;

	[SerializeField]
	private bool showInBattle;

	[SerializeField]
	private bool showInNotBattle;

	private bool isOutlineOn;

	private void Reset()
	{
	}

	private void OnMouseEnter()
	{
	}

	private void OnMouseExit()
	{
	}
}
