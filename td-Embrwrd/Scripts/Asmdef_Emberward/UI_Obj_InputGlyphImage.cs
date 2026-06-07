using DG.Tweening;
using Rewired;
using Rewired.Glyphs.UnityUI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Obj_InputGlyphImage : MonoBehaviour
{
	[SerializeField]
	private UnityUIPlayerControllerElementGlyph glyphImage;

	[SerializeField]
	private Image image_Demo;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private bool HideWithoutController;

	[SerializeField]
	private bool addOutlineToGlyph;

	[SerializeField]
	[FormerlySerializedAs("TintIconColor")]
	private Color TintOutlineColor;

	[SerializeField]
	private eInputAction inputAction;

	[SerializeField]
	private int resultIndex;

	[SerializeField]
	private AxisRange actionRange;

	[SerializeField]
	[Header("是否在收到指定的input時觸發訊號")]
	private bool triggerSelectionOnInput;

	[Header("在這個Control Scheme下才會觸發訊號")]
	[SerializeField]
	private eControlScheme limitControlScheme;

	[SerializeField]
	[Header("指定的APopupWindow是在上層才觸發訊號")]
	private APopupWindow targetPopupWindow;

	[SerializeField]
	[Header("收到指定的Input時要選取的Selectable")]
	private Selectable targetSelectable;

	private UnityUIGlyphOrTextTMPro glyphObject;

	private bool isColorSetupDone;

	private Tweener tweener_ButtonShake;

	public eInputAction InputAction => default(eInputAction);

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private bool IsInputActionAxis()
	{
		return false;
	}

	private void Update()
	{
	}
}
