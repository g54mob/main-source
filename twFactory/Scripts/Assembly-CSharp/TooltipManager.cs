using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class TooltipManager : MonoBehaviour
{
	[SerializeField]
	private float tooltipTime2D = 0.75f;

	[SerializeField]
	private float tooltipTime3D = 0.2f;

	[SerializeField]
	private LayerMask Tooltip3DLayerMask;

	[SerializeField]
	private Transform tooltipsContainer;

	private TooltipComponent currentTooltipComponent;

	private TooltipComponent auxTooltipComponent;

	private bool isTooltipOpen;

	private HUD currentHud;

	private bool tooltip2dEnabled = true;

	private bool tooltip3dEnabled = true;

	private bool currentObjectIs2d;

	private PlacementComponent auxPlacementComponent;

	private Camera mainCamera;

	private Coroutine checkTooltipCoroutine;

	public Camera MainCamera
	{
		get
		{
			if (!mainCamera)
			{
				mainCamera = Camera.main;
			}
			return mainCamera;
		}
	}

	public TooltipComponent CurrentTooltipComponent
	{
		get
		{
			return currentTooltipComponent;
		}
		set
		{
			if (currentTooltipComponent == value)
			{
				return;
			}
			if ((bool)currentTooltipComponent)
			{
				if (isTooltipOpen)
				{
					currentTooltipComponent.HideTooltip();
				}
				else
				{
					this.StopCoroutineCheckingVar(ref checkTooltipCoroutine);
				}
			}
			currentTooltipComponent = value;
			if ((bool)currentTooltipComponent)
			{
				if (isTooltipOpen)
				{
					CurrentTooltipComponent.ShowTooltip(TooltipsContainer);
				}
				else
				{
					this.StartCoroutineCheckingVar(CheckTooltipTimeCoroutine(), ref checkTooltipCoroutine);
				}
			}
			else
			{
				isTooltipOpen = false;
			}
		}
	}

	public bool Tooltip2dEnabled
	{
		get
		{
			return tooltip2dEnabled;
		}
		set
		{
			tooltip2dEnabled = value;
			if (!tooltip2dEnabled && (bool)currentTooltipComponent && currentObjectIs2d)
			{
				CurrentTooltipComponent = null;
			}
		}
	}

	public bool Tooltip3dEnabled
	{
		get
		{
			return tooltip3dEnabled;
		}
		set
		{
			tooltip3dEnabled = value;
			if (!tooltip3dEnabled && (bool)currentTooltipComponent && !currentObjectIs2d)
			{
				CurrentTooltipComponent = null;
			}
		}
	}

	public Transform TooltipsContainer
	{
		get
		{
			if (tooltipsContainer != null)
			{
				return tooltipsContainer;
			}
			if (currentHud != null)
			{
				return currentHud.transform;
			}
			return base.transform;
		}
	}

	private void Start()
	{
		if ((bool)LTFunctionLibrary.GetLTPlayerController())
		{
			currentHud = LTFunctionLibrary.GetLTPlayerController().CurrentHUD;
			if (currentHud is LTHUD)
			{
				(currentHud as LTHUD).LtPlayerController.onInputModeChanged += OnInputModeChanged;
			}
			(currentHud.PlayerController as LTPlayerController).onPlayerInputLocked += OnPlayerInputLocked;
		}
	}

	private void Update()
	{
		RaycastMousePosition();
	}

	private void RaycastMousePosition()
	{
		auxTooltipComponent = null;
		if (EventSystem.current.IsPointerOverGameObject())
		{
			if (Tooltip2dEnabled)
			{
				currentObjectIs2d = true;
				RaycastResult lastRaycastResult = (EventSystem.current.currentInputModule as InputSystemUIInputModule).GetLastRaycastResult(0);
				if (lastRaycastResult.gameObject != null)
				{
					auxTooltipComponent = lastRaycastResult.gameObject.GetComponentInParent<TooltipComponent>();
				}
			}
		}
		else if (Tooltip3dEnabled)
		{
			currentObjectIs2d = false;
			if (Physics.Raycast(MainCamera.ScreenPointToRay(Mouse.current.position.value), out var hitInfo, 100f, Tooltip3DLayerMask))
			{
				auxPlacementComponent = hitInfo.collider.gameObject.GetComponentInParent<PlacementComponent>();
				if (((bool)auxPlacementComponent && auxPlacementComponent.IsVisible()) || FogOfWarController.instance.IsPositionVisible(hitInfo.collider.transform.position))
				{
					auxTooltipComponent = hitInfo.collider.gameObject.GetComponentInParent<TooltipComponent>();
				}
			}
		}
		CurrentTooltipComponent = auxTooltipComponent;
	}

	private IEnumerator CheckTooltipTimeCoroutine()
	{
		isTooltipOpen = false;
		yield return new WaitForSecondsRealtime(GetTooltipTime());
		if ((bool)CurrentTooltipComponent)
		{
			CurrentTooltipComponent.ShowTooltip(TooltipsContainer);
			isTooltipOpen = true;
		}
		checkTooltipCoroutine = null;
	}

	private void OnInputModeChanged(InputMode newInputMode, InputMode oldInputMode)
	{
		switch (newInputMode.InputModeType)
		{
		case EInputMode.Standard:
			Tooltip3dEnabled = true;
			break;
		case EInputMode.EditMode:
			Tooltip3dEnabled = false;
			break;
		case EInputMode.BuyMode:
			Tooltip3dEnabled = false;
			break;
		}
	}

	private float GetTooltipTime()
	{
		if (CurrentTooltipComponent.HasCustomTooltipTime)
		{
			return CurrentTooltipComponent.CustomTooltipTime;
		}
		if (!currentObjectIs2d)
		{
			return tooltipTime3D;
		}
		return tooltipTime2D;
	}

	private void OnPlayerInputLocked(bool locked)
	{
		if (locked)
		{
			Tooltip3dEnabled = false;
		}
		else
		{
			OnInputModeChanged(LTFunctionLibrary.GetLTPlayerController().CurrentInputMode, null);
		}
	}
}
