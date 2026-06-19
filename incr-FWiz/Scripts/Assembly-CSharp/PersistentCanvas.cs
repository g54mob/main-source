using UnityEngine;

public class PersistentCanvas : MonoBehaviour
{
	[SerializeField]
	private CustomCursorCanvas _customCursorCanvas;

	[SerializeField]
	private TooltipHandler _tooltipHandler;

	[SerializeField]
	private HoverText _hoverText;

	[SerializeField]
	private ScreenRaycastBlocker _screenRaycastBlocker;

	[SerializeField]
	private WholeScreenFadeEffect _wholeScreenFade;

	[SerializeField]
	private TutorialBox _tutorialBox;

	[SerializeField]
	private PopupHandler _popupScreen;

	public static PersistentCanvas Instance { get; private set; }

	public void Awake()
	{
	}
}
