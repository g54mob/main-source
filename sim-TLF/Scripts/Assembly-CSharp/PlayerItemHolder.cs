using AssembleSystem;
using Items;
using Loxodon.Framework.Contexts;
using MateoRyhr;
using Player;
using StarterAssets;
using UI.HUD;
using UI.Inventory.Describer;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerItemHolder : MonoBehaviour
{
	[SerializeField]
	private RaycasterInfo _playerViewRaycaster;

	[SerializeField]
	private PlayerItemPicker _itemPicker;

	[SerializeField]
	private PlayerItemOutliner _outliner;

	[SerializeField]
	private GripperByJoint _gripper;

	[SerializeField]
	private JointTargetRotatorByVector2 _jointRotator;

	[SerializeField]
	private FirstPersonController _fpsController;

	[SerializeField]
	private Transform _dropPoint;

	[SerializeField]
	private float _dropForce;

	[SerializeField]
	private float _timeForHoldAppear = 0.2f;

	[SerializeField]
	private float _timeForHolding = 0.3f;

	[SerializeField]
	private float _rotateSensitivity = 5f;

	private float _currentHoldTime;

	private bool _canCountToHold;

	private bool _grabbed;

	private Rigidbody _grabbedBody;

	private InfoCursorsViewModel _infoCursorsViewModel;

	private InventoryDescriberViewModel _describerViewModel;

	private PartObject _grabbedPart;

	[Inject]
	private IPlayerInputService _inputService;

	[Inject]
	private IPlayerEquipService _equipService;

	[Inject]
	private PlayerHUDView _hudView;

	private void Start()
	{
		_infoCursorsViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InfoCursorsViewModel>();
		_describerViewModel = Loxodon.Framework.Contexts.Context.GetApplicationContext().GetService<InventoryDescriberViewModel>();
		_jointRotator.enabled = false;
	}

	private void OnEnable()
	{
		_inputService.OnInteract += TryHoldViewedItem;
		_inputService.OnRotateHolder += RotateHolder;
		_inputService.OnLook += RotateOnLook;
		_inputService.OnDrop += OnThrow;
	}

	private void OnDisable()
	{
		_inputService.OnInteract -= TryHoldViewedItem;
		_inputService.OnRotateHolder -= RotateHolder;
		_inputService.OnLook -= RotateOnLook;
		_inputService.OnDrop -= OnThrow;
	}

	private void OnThrow(InputAction.CallbackContext context)
	{
		if (context.started && !(_grabbedBody == null))
		{
			if (_grabbedBody.TryGetComponent<IThrowable>(out var component))
			{
				component.Throw(_dropPoint.forward * _dropForce);
				DropGrabbed();
			}
			else
			{
				DropGrabbed();
			}
		}
	}

	private void RotateOnLook(Vector2 vector)
	{
		_jointRotator.SetInput(vector * _rotateSensitivity);
	}

	private void RotateHolder(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			_fpsController.SetCanRotateCamera(value: false);
			_jointRotator.enabled = true;
		}
		if (context.canceled)
		{
			_fpsController.SetCanRotateCamera(value: true);
			_jointRotator.enabled = false;
		}
	}

	private void Update()
	{
		if (_canCountToHold)
		{
			_currentHoldTime += Time.deltaTime;
			if (_currentHoldTime >= _timeForHoldAppear && _currentHoldTime <= _timeForHolding)
			{
				_itemPicker.enabled = false;
				_hudView.HoldingIndicatorVM.Enabled = true;
				_hudView.HoldingIndicatorVM.Progress.Value = Mathf.Lerp(1f, -1f, _currentHoldTime / _timeForHolding);
			}
			else
			{
				_hudView.HoldingIndicatorVM.Progress.Value = 1f;
				_hudView.HoldingIndicatorVM.Enabled = false;
			}
			if (_currentHoldTime >= _timeForHolding && !_grabbed)
			{
				Grab();
			}
		}
	}

	public void Grab(Rigidbody rb)
	{
		GrabLogic(rb);
	}

	private void Grab()
	{
		Rigidbody rigidbody = _playerViewRaycaster.Hit.rigidbody;
		if (rigidbody != null)
		{
			GrabLogic(rigidbody);
		}
	}

	private void GrabLogic(Rigidbody hitRB)
	{
		_itemPicker.enabled = false;
		_grabbedBody = hitRB;
		_grabbedBody.interpolation = RigidbodyInterpolation.Interpolate;
		_outliner.SetOutlinedObject(hitRB.GetComponent<Collider>());
		_describerViewModel.Enabled.Value = true;
		_describerViewModel.InfoText = "Hold R to rotate \nRMB to Throw";
		_infoCursorsViewModel.Visible.Value = false;
		Vector3 position = hitRB.transform.position;
		position = ((!(_playerViewRaycaster.Hit.rigidbody == hitRB)) ? hitRB.GetComponentInChildren<MeshRenderer>().bounds.center : _playerViewRaycaster.Hit.point);
		_gripper.Grab(hitRB, position);
		_grabbed = true;
		if (hitRB.TryGetComponent<PartObject>(out var component))
		{
			if (component.StateMachine != null && !component.StateMachine.Placed)
			{
				_grabbedPart = component;
				component.StateMachine.IsHeldByPlayer = true;
			}
			((IHoldFunctional)component).Grab();
		}
	}

	private void TryHoldViewedItem(InputAction.CallbackContext context)
	{
		if (context.started)
		{
			Transform transform = _playerViewRaycaster.Hit.transform;
			if (transform != null)
			{
				transform.TryGetComponent<IInventoryManagable>(out var component);
				if (component is PartObject partObject && partObject.StateMachine.Placed)
				{
					return;
				}
				if (component != null)
				{
					_canCountToHold = true;
				}
				else
				{
					_canCountToHold = false;
				}
			}
		}
		if (context.canceled)
		{
			DropGrabbed();
		}
	}

	private void DropGrabbed()
	{
		if (_grabbedBody != null)
		{
			_grabbedBody.interpolation = RigidbodyInterpolation.None;
		}
		_grabbedBody = null;
		if (_grabbedPart != null)
		{
			_grabbedPart.StateMachine.IsHeldByPlayer = false;
			((IHoldFunctional)_grabbedPart).Release();
			_grabbedPart = null;
		}
		_gripper.Drop();
		_infoCursorsViewModel.Visible.Value = true;
		_describerViewModel.Enabled.Value = false;
		_describerViewModel.InfoText = "";
		_grabbed = false;
		_itemPicker.enabled = true;
		_outliner.ClearOutlinedObject();
		_canCountToHold = false;
		_currentHoldTime = 0f;
		_hudView.HoldingIndicatorVM.Enabled = false;
		_hudView.HoldingIndicatorVM.Progress.Value = 1f;
	}
}
