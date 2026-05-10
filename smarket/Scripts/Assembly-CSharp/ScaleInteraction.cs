using MyBox;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class ScaleInteraction : Interaction
{
	private Scale m_Scale;

	private PlayerInstance m_OwnerPlayer;

	private NetworkScaleInteraction m_NetworkScaleInteraction;

	public override IInteractable Interactable
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Scale CurrentScale => null;

	public override bool Enable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public PlayerInstance PlayerInstance => null;

	public NetworkScaleInteraction NetworkScaleInteraction => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnBarcodeDragStarted()
	{
	}

	private void OnStateChanged(Scale.ScaleInteractionState state, Scale.ScaleInteractionState previousState)
	{
	}

	private void SwitchGamepad(bool isConnected)
	{
	}

	private void OnBarcodeDropped()
	{
	}

	public void OnBarcodeDroppedOrder(Scale scale, Vector3 hitPoint, Vector3 hitNormal)
	{
	}

	private void OnRotate(bool clockwise)
	{
	}

	private void OnClose()
	{
	}

	private void BoxUpScale()
	{
	}

	public void BoxUpScaleNetwork()
	{
	}

	public void OnBack()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void Back()
	{
	}

	public void OnBackOrder()
	{
	}

	private void PlaceFurniture()
	{
	}

	public bool CheckPlaceFurniture()
	{
		return false;
	}

	public void PlaceFurnitureOrder(bool isRemote, Vector3 playSoundPosition)
	{
	}

	private void OnUsed(bool down)
	{
	}

	private void Update()
	{
	}

	private void HandleKeyboardInput()
	{
	}

	public void SetScale(Scale scale)
	{
	}

	public void CancelInteractionForOnlyMultiplayer()
	{
	}
}
