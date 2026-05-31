using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public abstract class CNAbstractController : MonoBehaviour
{
	[Flags]
	protected enum AnchorsBase
	{
		Left = 1,
		Right = 2,
		Top = 4,
		Bottom = 8
	}

	public enum Anchors
	{
		LeftTop = 5,
		LeftBottom = 9,
		RightTop = 6,
		RightBottom = 10
	}

	private const string AxisNameHorizontal = "Horizontal";

	private const string AxisNameVertical = "Vertical";

	[SerializeField]
	[HideInInspector]
	private Anchors _anchor;

	[SerializeField]
	[HideInInspector]
	private string _axisNameX;

	[SerializeField]
	[HideInInspector]
	private string _axisNameY;

	[SerializeField]
	[HideInInspector]
	private Vector2 _touchZoneSize;

	[SerializeField]
	[HideInInspector]
	private Vector2 _margins;

	public Anchors Anchor
	{
		get
		{
			return default(Anchors);
		}
		set
		{
		}
	}

	public string AxisNameX
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string AxisNameY
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Vector2 Margins
	{
		get
		{
			return default(Vector2);
		}
		set
		{
		}
	}

	public Vector2 TouchZoneSize
	{
		get
		{
			return default(Vector2);
		}
		set
		{
		}
	}

	protected Transform TransformCache { get; set; }

	protected Camera ParentCamera { get; set; }

	protected Rect CalculatedTouchZone { get; set; }

	protected Vector2 CurrentAxisValues { get; set; }

	protected int CurrentFingerId { get; set; }

	protected Vector3? CalculatedPosition { get; set; }

	protected bool IsCurrentlyTweaking { get; set; }

	public event Action<Vector3, CNAbstractController> ControllerMovedEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<CNAbstractController> FingerTouchedEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<CNAbstractController> FingerLiftedEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public virtual float GetAxis(string axisName)
	{
		return 0f;
	}

	public virtual void Disable()
	{
	}

	public virtual void Enable()
	{
	}

	public virtual void OnEnable()
	{
	}

	protected virtual Touch? GetTouchByFingerId(int fingerId)
	{
		return null;
	}

	protected virtual void OnControllerMoved(Vector2 input)
	{
	}

	protected virtual void OnFingerTouched()
	{
	}

	protected virtual void OnFingerLifted()
	{
	}

	protected Vector3 InitializePosition()
	{
		return default(Vector3);
	}

	protected virtual void ResetControlState()
	{
	}

	protected virtual bool TweakIfNeeded()
	{
		return false;
	}

	protected virtual bool IsTouchCaptured(out Touch capturedTouch)
	{
		capturedTouch = default(Touch);
		return false;
	}

	private bool IsTouchInZone(Vector2 touchPosition)
	{
		return false;
	}

	protected abstract void TweakControl(Vector2 touchPosition);
}
