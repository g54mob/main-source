using Assets.Source.World;
using UnityEngine;
using UnityEngine.Events;

public class T3PowerSwitch : MonoBehaviour
{
	[SerializeField]
	private UnityEvent _onActivate;

	[SerializeField]
	private float _resetTime = 0.5f;

	[SerializeField]
	private bool _requiresFullReset;

	[SerializeField]
	private float _switchToggleAngle = 90f;

	[SerializeField]
	private float _resetSpeed = 90f;

	private ActiveWorldFrame _parentFrame;

	private bool _mouseDown;

	private float _baseAngle;

	private float _maxAngle;

	private float _leverAngle;

	private float _activateTimer;

	private bool _isReset = true;

	public float Progress
	{
		get
		{
			return (_leverAngle - _baseAngle) / _switchToggleAngle;
		}
		set
		{
			_leverAngle = _baseAngle + value * _switchToggleAngle;
		}
	}

	public float ResetSpeed
	{
		set
		{
			_resetSpeed = value;
		}
	}

	private void Awake()
	{
		_parentFrame = GetComponentInParent<ActiveWorldFrame>();
		_baseAngle = base.transform.localEulerAngles.z;
		_leverAngle = _baseAngle;
		_maxAngle = _baseAngle + _switchToggleAngle;
	}

	private void Update()
	{
		if (_mouseDown)
		{
			_mouseDown = false;
			Vector3 vector = PlayerControls.MouseWorld;
			float value = 360f - Vector2.SignedAngle(base.transform.position - vector, Vector2.up);
			_leverAngle = Mathf.Clamp(value, _baseAngle, _maxAngle);
			base.transform.localEulerAngles = new Vector3(0f, 0f, _leverAngle);
		}
		else if (_leverAngle > _baseAngle)
		{
			_leverAngle = Mathf.Max(_baseAngle, _leverAngle - _resetSpeed * Time.deltaTime);
			base.transform.localEulerAngles = new Vector3(0f, 0f, _leverAngle);
		}
		if (_leverAngle == _maxAngle && _isReset)
		{
			_activateTimer -= Time.deltaTime;
			if (_activateTimer < 0f)
			{
				_onActivate.Invoke();
				_activateTimer = _resetTime;
				if (_requiresFullReset)
				{
					_isReset = false;
				}
			}
		}
		else
		{
			_activateTimer = 0f;
		}
		if (_leverAngle < _maxAngle)
		{
			_isReset = true;
		}
	}

	public void TriggerCraft()
	{
		if (_parentFrame.ActiveFrame is CraftingFrame craftingFrame && !craftingFrame.GetManualCrafter(0).Active)
		{
			UISounds.CraftStep();
			_parentFrame.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
		}
	}

	private void OnMouseDrag()
	{
		_mouseDown = true;
	}
}
