using System;
using System.Collections.Generic;
using DG.Tweening;
using SE.EvilLib.AudioManager;
using UnityEngine;
using UnityEngine.Events;

public class DraggablePanel : MonoBehaviour
{
	public enum Direction
	{
		X = 0,
		Y = 1
	}

	public Transform movementRoot;

	public Direction direction;

	public float length;

	public float lengthExpansionWhenOpen;

	public float hidePoseOffset;

	public Holder.TransitionDurations transitionDuration;

	public Ease ease;

	public float closeTweenDelay;

	public float openTweenDelay;

	public bool playSoundOnOpen;

	public AudioTypeSfx openSound;

	public bool playSoundOnClose;

	public AudioTypeSfx closeSound;

	public string soundGroup;

	public WorkbenchObject workbenchObject;

	private bool _isLocked;

	private bool _forceOpen;

	public UnityEvent onOpen;

	public UnityEvent onClose;

	public UnityEvent onTryOpenWhenLocked;

	public UnityEvent onTryCloseWhenForceOpen;

	private float movementI;

	[NonSerialized]
	[HideInInspector]
	public Sequence tween;

	public Tweener movementTween;

	private Vector3 position;

	private bool hidePose;

	protected bool init;

	private DraggablePanelGroup group;

	private static Dictionary<string, float> soundGroupsTime;

	public bool isOpen { get; private set; }

	public bool isLocked
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool overrideLock { get; private set; }

	public bool forceOpen
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool overrideForceOpen { get; private set; }

	public bool isAvailable
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool isMoving => false;

	public float GetMovementI()
	{
		return 0f;
	}

	public void PauseMovement()
	{
	}

	public void ResumeMovement()
	{
	}

	public void SetMovementSpeed(float speed)
	{
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	private void CheckInit()
	{
	}

	protected virtual void Init()
	{
	}

	public void SetHidePose(bool hidePose)
	{
	}

	public float GetLength()
	{
		return 0f;
	}

	public float GetOpenLength()
	{
		return 0f;
	}

	public Vector3 GetMovementTweenOpenDestination()
	{
		return default(Vector3);
	}

	public void DoOpen()
	{
	}

	public void DoClose()
	{
	}

	public virtual void Open(bool disableGroupEvent = false, bool immediate = false, bool overrideLock = false)
	{
	}

	public virtual void Close(bool disableGroupEvent = false, bool immediate = false, bool overrideForceOpen = false)
	{
	}

	private bool CheckSoundGroup()
	{
		return false;
	}

	public void Toggle()
	{
	}

	public void RefreshPosition()
	{
	}

	private void LateUpdate()
	{
	}

	public void SetMovementRootPosition(float position)
	{
	}
}
