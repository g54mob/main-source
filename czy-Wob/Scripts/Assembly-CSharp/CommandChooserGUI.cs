using UnityEngine;
using UnityEngine.UI;

public class CommandChooserGUI : MonoBehaviour
{
	public Animator swapAnimator;

	public PlayModeController playModeRef;

	public Image swapButtonSprite;

	public Image swapButtonGrabSprite;

	public Color swapButtonUpColor;

	public Color swapButtonDownColor;

	public Color swapButtonUpGrabColor;

	public Color swapButtonDownGrabColor;

	public Canvas petCanvas;

	public Canvas grabCanvas;

	private int canvasOrderFront = -10;

	private int canvasOrderBehind = -11;

	private bool shiftDown;

	private bool primaryCommandIsGrab = true;

	private bool grabActive = true;

	private string swapVar = "GrabActive";

	private GUIManagerPens guiRef;

	private ObjectGrabber grabberRef;

	private DogPettingController pettingRef;

	private void Start()
	{
		guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		grabberRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ObjectGrabber>(GlobalObject.OBJECT_GRABBER);
		pettingRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogPettingController>(GlobalObject.DOG_PETTING_CONTROLLER);
	}

	private void OnEnable()
	{
		SetGrabActive();
	}

	private void Update()
	{
		if (guiRef.GetGUIInteractiveStatus() && !PauseController.IsPaused())
		{
			HandleInput();
		}
	}

	public void OnGUIHidden()
	{
		petCanvas.enabled = false;
		grabCanvas.enabled = false;
	}

	public void OnGUIUnhidden()
	{
		petCanvas.enabled = true;
		grabCanvas.enabled = true;
	}

	public void OnSwapButtonClicked(bool fromShift = false)
	{
		if (!PauseController.IsPaused() && !grabberRef.IsCarryingInventoryObject())
		{
			playModeRef.SwapCommands();
			if (!fromShift)
			{
				primaryCommandIsGrab = !primaryCommandIsGrab;
			}
		}
	}

	public void OnMouseOverCommandSwapButton()
	{
		pettingRef.SetMouseOverPettingModeButton(val: true);
	}

	public void OnMouseOffCommandSwapButton()
	{
		pettingRef.SetMouseOverPettingModeButton(val: false);
	}

	public void SetGrabActive()
	{
		grabActive = false;
		swapAnimator.SetBool(swapVar, grabActive);
		petCanvas.sortingOrder = canvasOrderBehind;
		grabCanvas.sortingOrder = canvasOrderFront;
	}

	public void SetPetActive()
	{
		grabActive = true;
		swapAnimator.SetBool(swapVar, grabActive);
		petCanvas.sortingOrder = canvasOrderFront;
		grabCanvas.sortingOrder = canvasOrderBehind;
	}

	private void HandleInput()
	{
		if (!shiftDown && GameControls.actions.PettingGrabSwap.IsPressed)
		{
			shiftDown = true;
			OnSwapButtonClicked(fromShift: true);
		}
		else if (shiftDown && !GameControls.actions.PettingGrabSwap.IsPressed)
		{
			shiftDown = false;
			OnSwapButtonClicked(fromShift: true);
		}
		else if (!shiftDown && GameControls.actions.PettingGrabSwapGamepad.WasPressed)
		{
			OnSwapButtonClicked();
		}
		if (primaryCommandIsGrab)
		{
			swapButtonSprite.transform.parent.gameObject.SetActive(value: true);
			swapButtonGrabSprite.transform.parent.gameObject.SetActive(value: false);
		}
		else
		{
			swapButtonSprite.transform.parent.gameObject.SetActive(value: false);
			swapButtonGrabSprite.transform.parent.gameObject.SetActive(value: true);
		}
		if (GameControls.actions.PettingGrabSwap.IsPressed)
		{
			swapButtonSprite.color = swapButtonDownColor;
			swapButtonGrabSprite.color = swapButtonDownGrabColor;
		}
		else
		{
			swapButtonSprite.color = swapButtonUpColor;
			swapButtonGrabSprite.color = swapButtonUpGrabColor;
		}
	}
}
