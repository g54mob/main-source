using Rewired;
using Rewired.Glyphs.UnityUI;
using UnityEngine;

public class UI_ControllerActionTip : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private ControllerActionTipData controllerActionTipData;

	[SerializeField]
	private UnityUITextMeshProGlyphHelper text_ActionTips;

	[SerializeField]
	private GameObject node_Content;

	private void OnEnable()
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnHideCommonIngameUI()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void OnControlSchemeChanged(eControlScheme scheme)
	{
	}
}
