using UnityEngine;

[ExecuteInEditMode]
public class CNJoystick : CNAbstractController
{
	[SerializeField]
	[HideInInspector]
	private float _dragRadius;

	[SerializeField]
	[HideInInspector]
	private bool _snapsToFinger;

	[SerializeField]
	[HideInInspector]
	private bool _isHiddenIfNotTweaking;

	private Transform _stickTransform;

	private Transform _baseTransform;

	private GameObject _stickGameObject;

	private GameObject _baseGameObject;

	public float DragRadius
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool SnapsToFinger
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool IsHiddenIfNotTweaking
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override void OnEnable()
	{
	}

	protected override void ResetControlState()
	{
	}

	protected override void OnFingerLifted()
	{
	}

	protected override void OnFingerTouched()
	{
	}

	protected virtual void Update()
	{
	}

	protected override void TweakControl(Vector2 touchPosition)
	{
	}

	protected virtual void PlaceJoystickBaseUnderTheFinger(Touch touch)
	{
	}
}
