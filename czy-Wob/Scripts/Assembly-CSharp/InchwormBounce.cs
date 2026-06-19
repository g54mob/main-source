using System.Collections.Generic;
using InControl;
using UnityEngine;

public class InchwormBounce : MonoBehaviour
{
	public enum BounceObject
	{
		self = 1,
		parent = 2,
		custom = 3
	}

	public delegate void BounceEvent();

	public bool bounceOnEnable;

	public bool bounceOnMouseOver = true;

	public bool bounceOnMouseDown;

	public BounceObject bounceObject = BounceObject.self;

	public GameObject customBounceObject;

	public LayerMask neededLayer = -1;

	public Inchworm.EaseStyle easeType = Inchworm.EaseStyle.ElasticOut;

	public float scaleTime = 0.5f;

	public float shrinkAmount = 0.5f;

	public float bounceStartDelay;

	public bool startInvisible;

	public bool invertBounce;

	private List<BounceEvent> bounceStartEvents = new List<BounceEvent>();

	private List<BounceEvent> bounceEndEvents = new List<BounceEvent>();

	private Segment currentEase;

	private bool canBounce = true;

	private bool needsBounce;

	private bool hasInitialized;

	private Vector3 startScale;

	private Inchworm inchworm;

	private Animator animatorRef;

	private GameObject bounceTarget;

	private List<Transform> allChildren;

	private void Start()
	{
		Initialize();
	}

	public bool IsBouncing()
	{
		if (currentEase != null)
		{
			return true;
		}
		return false;
	}

	public void Initialize()
	{
		if (!hasInitialized)
		{
			inchworm = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
			if (bounceObject == BounceObject.self)
			{
				bounceTarget = base.gameObject;
			}
			else if (bounceObject == BounceObject.parent)
			{
				bounceTarget = base.transform.parent.gameObject;
			}
			else if (bounceObject == BounceObject.custom)
			{
				bounceTarget = customBounceObject;
			}
			animatorRef = bounceTarget.GetComponent<Animator>();
			InitializeChildren();
			hasInitialized = true;
		}
	}

	private void OnEnable()
	{
		if (bounceOnEnable)
		{
			RequestBounce();
		}
	}

	private void Update()
	{
		if ((int)neededLayer != -1)
		{
			CheckLayerInput();
		}
		if (currentEase == null && needsBounce && hasInitialized)
		{
			RequestBounce();
		}
	}

	public void RegisterBounceStartEvent(BounceEvent newEvent)
	{
		bounceStartEvents.Add(newEvent);
	}

	public void RegisterBounceEndEvent(BounceEvent newEvent)
	{
		bounceEndEvents.Add(newEvent);
	}

	private void InitializeChildren()
	{
		allChildren = new List<Transform>();
		allChildren.AddRange(base.transform.GetComponentsInChildren<Transform>());
	}

	private void CheckLayerInput()
	{
		if (bounceOnMouseDown && GameControls.actions.Interact.WasPressed)
		{
			Physics.Raycast(Camera.main.ScreenPointToRay(InputManager.MouseProvider.GetPosition()), out var hitInfo, 100f, neededLayer.value);
			if (hitInfo.collider != null && allChildren.Contains(hitInfo.collider.transform))
			{
				OnMouseDown();
			}
		}
	}

	public void OnMouseOver()
	{
		if (base.enabled && bounceOnMouseOver && !GameControls.actions.Interact.IsPressed)
		{
			if (currentEase == null && canBounce)
			{
				RequestBounce();
			}
			canBounce = false;
		}
	}

	public void OnMouseDown()
	{
		if (base.enabled && bounceOnMouseDown)
		{
			RequestBounce();
		}
	}

	public void OnMouseExit()
	{
		canBounce = true;
	}

	public void StopBounce()
	{
		if (currentEase != null)
		{
			inchworm.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
	}

	public void RequestBounce()
	{
		if (bounceTarget == null)
		{
			if (!hasInitialized)
			{
				needsBounce = true;
			}
			return;
		}
		if (currentEase != null)
		{
			inchworm.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
		for (int i = 0; i < bounceStartEvents.Count; i++)
		{
			bounceStartEvents[i]();
		}
		canBounce = false;
		needsBounce = false;
		if (invertBounce)
		{
			startScale = Vector3.zero;
		}
		else
		{
			startScale = bounceTarget.transform.localScale;
			bounceTarget.transform.localScale *= shrinkAmount;
		}
		if (animatorRef != null)
		{
			animatorRef.enabled = false;
		}
		if (startInvisible && bounceOnEnable)
		{
			bounceOnEnable = false;
			Debug.LogWarning("This object will never be visible because it'll get stuck in an infinite loop of bounce requests! Resetting bounceOnEnable.");
		}
		currentEase = inchworm.RequestEaseToScale(bounceTarget, startScale, scaleTime, easeType, FinalScaleCallback, Inchworm.EasePriority.Normal, bounceStartDelay, startInvisible);
	}

	private void FinalScaleCallback()
	{
		currentEase = null;
		for (int i = 0; i < bounceEndEvents.Count; i++)
		{
			bounceEndEvents[i]();
		}
		if (animatorRef != null)
		{
			animatorRef.enabled = true;
		}
	}
}
