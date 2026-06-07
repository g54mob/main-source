using System;
using DV.CabControls;
using RootMotion.FinalIK;
using Stateless;
using UnityEngine;

public class ChainCouplerInteraction : MonoBehaviour
{
	public enum State
	{
		Disabled = 0,
		Enabled = 1,
		Determine_Next_State = 2,
		Being_Dragged = 3,
		Parked = 4,
		Dangling = 5,
		Attached = 6,
		Attached_Loose = 7,
		Attached_Tight = 8,
		Attached_Tightening_Couple = 9,
		Attached_Loosening_Uncouple = 10,
		Other_Attached = 11,
		Other_Attached_Parked = 12,
		Other_Attached_Dangling = 13
	}

	private enum Trigger
	{
		Enable = 0,
		Disable = 1,
		UpdateVisible = 2,
		LateUpdateVisible = 3,
		Determine_Next_State = 4,
		Tick = 5,
		Picked_Up_By_Player = 6,
		Dropped_By_Player = 7,
		Our_Hook_Occupied = 8,
		Our_Hook_Freed = 9,
		Coupled_Externally = 10,
		Uncoupled_Externally = 11,
		Couple_Broken_Externally = 12,
		Screw_Used = 13
	}

	private State state;

	private StateMachine<State, Trigger> fsm;

	private const float CHAIN_LENGTH_JOINT_LIMIT = 0.9f;

	public FABRIK draggingIK;

	public CCDIK attachedIK;

	public FABRIK otherAttachedIK;

	public GameObject knobPrefab;

	public Transform parkedAnchor;

	public Transform chainRingAnchor;

	public Renderer highlightTarget;

	public GameObject screwButton;

	public CouplingAttachPoint ownAttachPoint;

	public ChainCouplerInteraction attachedTo;

	public ChainCouplerCouplerAdapter couplerAdapter;

	public HackIK hackIK;

	public Animation screwAnimation;

	public AnimationClip screwAnimationTighten;

	public AnimationClip screwAnimationLoosen;

	[Header("Sound")]
	public AudioClip grabSound;

	public AudioClip parkSound;

	public AudioClip attachSound;

	public AudioClip screwSound;

	public AudioClip unscrewSound;

	public AudioClip dangleSound;

	public AudioClip forcedDetachSound;

	private float timeEnabled;

	private Transform knobFollower;

	private GameObject knob;

	private GizmoBase knobGizmo;

	private ConfigurableJoint cj;

	private CouplingAttachPoint closestAttachPoint;

	private Vector3 originalLocalPosition;

	private ButtonBase screwButtonBase;

	private const float AUTO_DETACH_DISTANCE_SQR = 0.5184f;

	private float ROTATION_SMOOTH_DURATION = 0.1f;

	private Vector3 rotationSmoothDampVel;

	private bool isVR;

	private GameObject dangleRootGO;

	private const float parkDistanceThreshold = 0.2f;

	private const float attachDistanceThreshold = 0.1f;

	private static readonly State[] restorableStates = new State[4]
	{
		State.Parked,
		State.Dangling,
		State.Attached_Loose,
		State.Attached_Tight
	};

	private static readonly State[] statesExpectingAttachPoint = new State[4]
	{
		State.Attached_Loose,
		State.Attached_Tight,
		State.Other_Attached_Dangling,
		State.Other_Attached_Parked
	};

	public State CurrentState => state;

	public bool IsParked
	{
		get
		{
			if (fsm != null)
			{
				return fsm.State == State.Parked;
			}
			return true;
		}
	}

	public event Action<State> StateChanged;

	public event Action Attached;

	public event Action OtherAttached;

	private StateMachine<State, Trigger> MakeFSM()
	{
		StateMachine<State, Trigger> stateMachine = new StateMachine<State, Trigger>(() => state, delegate(State s)
		{
			state = s;
		});
		stateMachine.Configure(State.Disabled).Permit(Trigger.Enable, State.Enabled).Ignore(Trigger.Disable)
			.Ignore(Trigger.UpdateVisible)
			.Ignore(Trigger.LateUpdateVisible)
			.Ignore(Trigger.Coupled_Externally)
			.Ignore(Trigger.Uncoupled_Externally)
			.Ignore(Trigger.Couple_Broken_Externally);
		stateMachine.Configure(State.Enabled).OnEntry(Entry_Enabled).OnExit(Exit_Enabled)
			.InitialTransition(State.Determine_Next_State)
			.Permit(Trigger.Disable, State.Disabled)
			.Permit(Trigger.Our_Hook_Occupied, State.Other_Attached)
			.Ignore(Trigger.UpdateVisible)
			.Ignore(Trigger.LateUpdateVisible);
		stateMachine.Configure(State.Determine_Next_State).SubstateOf(State.Enabled).OnEntry(Entry_Determine_Next_State)
			.OnExit(Exit_Determine_Next_State)
			.PermitDynamic(Trigger.Determine_Next_State, DetermineNextState);
		stateMachine.Configure(State.Parked).SubstateOf(State.Enabled).OnEntry(Entry_Parked)
			.OnExit(Exit_Parked)
			.InternalTransition(Trigger.UpdateVisible, Update_Parked)
			.Permit(Trigger.Picked_Up_By_Player, State.Being_Dragged)
			.Permit(Trigger.Coupled_Externally, State.Attached_Tight)
			.Ignore(Trigger.Uncoupled_Externally)
			.Ignore(Trigger.Couple_Broken_Externally);
		stateMachine.Configure(State.Being_Dragged).SubstateOf(State.Enabled).OnEntry(Entry_Being_Dragged)
			.OnExit(Exit_Being_Dragged)
			.InternalTransition(Trigger.UpdateVisible, Update_Being_Dragged)
			.Permit(Trigger.Dropped_By_Player, State.Determine_Next_State)
			.Permit(Trigger.Coupled_Externally, State.Attached_Tight)
			.Permit(Trigger.Our_Hook_Occupied, State.Other_Attached_Dangling);
		stateMachine.Configure(State.Attached).SubstateOf(State.Enabled).OnEntry(Entry_Attached)
			.OnExit(Exit_Attached)
			.InternalTransition(Trigger.LateUpdateVisible, LateUpdate_Attached)
			.Permit(Trigger.Uncoupled_Externally, State.Parked)
			.Permit(Trigger.Couple_Broken_Externally, State.Dangling);
		stateMachine.Configure(State.Attached_Loose).SubstateOf(State.Attached).OnEntry(Entry_Attached_Loose)
			.OnExit(Exit_Attached_Loose)
			.Permit(Trigger.Picked_Up_By_Player, State.Being_Dragged)
			.Permit(Trigger.Coupled_Externally, State.Attached_Tight)
			.Permit(Trigger.Screw_Used, State.Attached_Tightening_Couple);
		stateMachine.Configure(State.Attached_Tight).SubstateOf(State.Attached).OnEntry(Entry_Attached_Tight)
			.OnExit(Exit_Attached_Tight)
			.Permit(Trigger.Screw_Used, State.Attached_Loosening_Uncouple);
		stateMachine.Configure(State.Attached_Tightening_Couple).SubstateOf(State.Attached).OnEntry(Entry_Attached_Tightening_Couple)
			.OnExit(Exit_Attached_Tightening_Couple)
			.Ignore(Trigger.Coupled_Externally)
			.Ignore(Trigger.Screw_Used)
			.Permit(Trigger.Tick, State.Attached_Tight);
		stateMachine.Configure(State.Attached_Loosening_Uncouple).SubstateOf(State.Attached).OnEntry(Entry_Attached_Loosening_Uncouple)
			.OnExit(Exit_Attached_Loosening_Uncouple)
			.Ignore(Trigger.Uncoupled_Externally)
			.Ignore(Trigger.Screw_Used)
			.Permit(Trigger.Tick, State.Attached_Loose);
		stateMachine.Configure(State.Dangling).SubstateOf(State.Enabled).OnEntry(Entry_Dangling)
			.OnExit(Exit_Dangling)
			.InternalTransition(Trigger.UpdateVisible, Update_Dangling)
			.Permit(Trigger.Picked_Up_By_Player, State.Being_Dragged)
			.Permit(Trigger.Coupled_Externally, State.Attached_Tight)
			.Permit(Trigger.Our_Hook_Occupied, State.Other_Attached_Dangling)
			.Ignore(Trigger.Uncoupled_Externally);
		stateMachine.Configure(State.Other_Attached).SubstateOf(State.Enabled).InitialTransition(State.Other_Attached_Parked)
			.OnEntry(Entry_Other_Attached)
			.OnExit(Exit_Other_Attached)
			.Ignore(Trigger.Coupled_Externally)
			.Ignore(Trigger.Uncoupled_Externally)
			.Ignore(Trigger.Couple_Broken_Externally)
			.Ignore(Trigger.Our_Hook_Occupied);
		stateMachine.Configure(State.Other_Attached_Parked).SubstateOf(State.Other_Attached).OnEntry(Entry_Other_Attached_Parked)
			.Permit(Trigger.Our_Hook_Freed, State.Parked);
		stateMachine.Configure(State.Other_Attached_Dangling).SubstateOf(State.Other_Attached).OnEntry(Entry_Other_Attached_Dangling)
			.Permit(Trigger.Our_Hook_Freed, State.Dangling);
		stateMachine.OnTransitioned(delegate(StateMachine<State, Trigger>.Transition t)
		{
			this.StateChanged?.Invoke(t.Destination);
		});
		stateMachine.OnUnhandledTrigger(delegate(State state, Trigger trigger)
		{
			Debug.LogError($"[CCI] Unhandled trigger '{trigger}' for state '{state}'", this);
		});
		return stateMachine;
	}

	private void Awake()
	{
		fsm = MakeFSM();
		originalLocalPosition = base.transform.localPosition;
	}

	private void OnEnable()
	{
		if (fsm != null)
		{
			fsm.Fire(Trigger.Enable);
		}
	}

	private void OnDisable()
	{
		if (fsm != null)
		{
			fsm.Fire(Trigger.Disable);
		}
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && (bool)attachedTo && attachedTo.fsm.IsInState(State.Attached))
		{
			Debug.Log("[CCI] being destroyed, informing the other car to disconnect coupler chain", this);
			attachedTo.fsm.Fire(Trigger.Couple_Broken_Externally);
		}
	}

	public void UpdateVisible()
	{
		if (fsm != null)
		{
			fsm.Fire(Trigger.UpdateVisible);
		}
	}

	public void LateUpdateVisible()
	{
		if (fsm != null)
		{
			fsm.Fire(Trigger.LateUpdateVisible);
		}
	}

	public void CoupledExternally(Coupler otherCoupler)
	{
		VisualCouplerInit visualCoupler = otherCoupler.visualCoupler;
		if (!otherCoupler.visualCoupler)
		{
			fsm.Fire(Trigger.Disable);
			return;
		}
		ChainCouplerInteraction component = visualCoupler.chain.GetComponent<ChainCouplerInteraction>();
		closestAttachPoint = component.ownAttachPoint;
		fsm.Fire(Trigger.Coupled_Externally);
	}

	public void UncoupledExternally()
	{
		fsm.Fire(Trigger.Uncoupled_Externally);
	}

	public void CoupleBrokenExternally()
	{
		fsm.Fire(Trigger.Couple_Broken_Externally);
	}

	private void Entry_Enabled()
	{
		base.transform.localPosition = originalLocalPosition;
		knobFollower = new GameObject("[knob follower]").transform;
		knobFollower.SetParent(base.transform, worldPositionStays: false);
		knob = UnityEngine.Object.Instantiate(knobPrefab, parkedAnchor.parent);
		knob.transform.localPosition = parkedAnchor.localPosition;
		knob.transform.localRotation = parkedAnchor.localRotation;
		knob.GetComponentInChildren<HighlightTag>().renderers.Add(highlightTarget);
		PointHandSnapper componentInChildren = knob.GetComponentInChildren<PointHandSnapper>();
		if ((bool)componentInChildren)
		{
			componentInChildren.pointMarker = chainRingAnchor;
		}
		FABRIK fABRIK = draggingIK;
		CCDIK cCDIK = attachedIK;
		bool flag = (otherAttachedIK.enabled = false);
		bool flag3 = (cCDIK.enabled = flag);
		fABRIK.enabled = flag3;
		knobGizmo = knob.GetComponentInChildren<GizmoBase>();
		knobGizmo.Grabbed += OnGrabbed;
		knobGizmo.Ungrabbed += OnUngrabbed;
		ownAttachPoint.AttachStateChanged += OnAttachPointStateChanged;
		timeEnabled = Time.time;
	}

	private void Exit_Enabled()
	{
		knobGizmo.Grabbed -= OnGrabbed;
		knobGizmo.Ungrabbed -= OnUngrabbed;
		ownAttachPoint.AttachStateChanged -= OnAttachPointStateChanged;
		UnityEngine.Object.Destroy(knob);
		knob = null;
		knobGizmo = null;
		UnityEngine.Object.Destroy(knobFollower.gameObject);
		knobFollower = null;
	}

	private void OnGrabbed(ControlImplBase ctrl)
	{
		fsm.Fire(Trigger.Picked_Up_By_Player);
	}

	private void OnUngrabbed(ControlImplBase ctrl)
	{
		fsm.Fire(Trigger.Dropped_By_Player);
	}

	private void OnAttachPointStateChanged(bool attached)
	{
		if (attached)
		{
			fsm.Fire(Trigger.Our_Hook_Occupied);
		}
		else
		{
			fsm.Fire(Trigger.Our_Hook_Freed);
		}
	}

	private void PlaySound(AudioClip clip, Vector3 position)
	{
		if (!UnloadWatcher.isUnloading && (bool)base.gameObject && base.gameObject.activeInHierarchy && !(Time.time - timeEnabled < 0.5f))
		{
			clip.Play(position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
		}
	}

	private void Entry_Attached()
	{
		attachedIK.solver.target = closestAttachPoint.transform;
		knob.transform.position = closestAttachPoint.transform.position;
		attachedTo = closestAttachPoint.transform.parent.parent.GetComponent<ChainCouplerInteraction>();
		attachedTo.attachedTo = this;
		closestAttachPoint.SetAttachState(attached: true);
		screwButton.SetActive(value: true);
		screwButtonBase = screwButton.GetComponent<ButtonBase>();
		screwButtonBase.Used += OnScrewButtonUsed;
		this.Attached?.Invoke();
		PlaySound(attachSound, knob.transform.position);
	}

	private void Exit_Attached()
	{
		attachedIK.solver.target = null;
		closestAttachPoint.SetAttachState(attached: false);
		attachedTo = null;
		screwButtonBase.Used -= OnScrewButtonUsed;
		screwButtonBase = null;
		screwButton.SetActive(value: false);
		hackIK.target = 1f;
	}

	private void LateUpdate_Attached()
	{
		attachedTo.otherAttachedIK.solver.Update();
		attachedIK.solver.Update();
	}

	private void OnScrewButtonUsed()
	{
		fsm.Fire(Trigger.Screw_Used);
	}

	private void Entry_Attached_Loose()
	{
		couplerAdapter.coupler.state = State.Attached_Loose;
		hackIK.target = 1f;
		knob.transform.position = closestAttachPoint.transform.position;
		couplerAdapter.TryCouple();
	}

	private void Exit_Attached_Loose()
	{
	}

	private void Entry_Attached_Loosening_Uncouple()
	{
		hackIK.target = 1f;
		screwAnimation.clip = screwAnimationTighten;
		screwAnimation.enabled = true;
		screwAnimation.Play();
		couplerAdapter.coupler.SetChainTight(tight: false);
		fsm.Fire(Trigger.Tick);
		PlaySound(unscrewSound, knob.transform.position);
	}

	private void Exit_Attached_Loosening_Uncouple()
	{
	}

	private void Update_Attached_Loosening_Uncouple()
	{
	}

	private void Entry_Attached_Tight()
	{
		couplerAdapter.coupler.state = State.Attached_Tight;
		hackIK.target = 0f;
		knobGizmo.InteractionAllowed = false;
	}

	private void Exit_Attached_Tight()
	{
		knobGizmo.InteractionAllowed = true;
	}

	private void Update_Attached_Tight()
	{
	}

	private void Entry_Attached_Tightening_Couple()
	{
		hackIK.target = 0f;
		screwAnimation.clip = screwAnimationLoosen;
		screwAnimation.enabled = true;
		screwAnimation.Play();
		couplerAdapter.coupler.SetChainTight(tight: true);
		fsm.Fire(Trigger.Tick);
		PlaySound(screwSound, knob.transform.position);
	}

	private void Exit_Attached_Tightening_Couple()
	{
	}

	private void Update_Attached_Tightening_Couple()
	{
	}

	private void Entry_Being_Dragged()
	{
		isVR = VRManager.IsVREnabled();
		ROTATION_SMOOTH_DURATION = (isVR ? 0.2f : 0.1f);
		rotationSmoothDampVel = Vector3.zero;
		knobFollower.position = knob.transform.position;
		draggingIK.solver.target = knobFollower;
		PlaySound(grabSound, knob.transform.position);
		couplerAdapter.TryUncouple();
	}

	private void Exit_Being_Dragged()
	{
		knob.transform.localRotation = Quaternion.identity;
		couplerAdapter.coupler.state = State.Determine_Next_State;
	}

	private void Update_Being_Dragged()
	{
		Vector3 position = knob.transform.position;
		Vector3 target = position;
		CouplingAttachPoint couplingAttachPoint = CouplingAttachPoint.FindClosestAttachPoint(chainRingAnchor.position, ownAttachPoint);
		if (couplingAttachPoint == null)
		{
			closestAttachPoint = null;
		}
		else
		{
			closestAttachPoint = couplingAttachPoint;
			Transform transform = draggingIK.solver.bones[0].transform;
			target = new Plane(transform.position, transform.position + base.transform.up, closestAttachPoint.transform.position).ClosestPointOnPlane(position);
			if (!isVR)
			{
				knob.transform.position = Vector3.SmoothDamp(position, target, ref rotationSmoothDampVel, ROTATION_SMOOTH_DURATION);
			}
		}
		knobFollower.position = Vector3.SmoothDamp(knobFollower.position, target, ref rotationSmoothDampVel, ROTATION_SMOOTH_DURATION);
		draggingIK.solver.Update();
	}

	private void Entry_Dangling()
	{
		couplerAdapter.coupler.state = State.Dangling;
		draggingIK.solver.target = knob.transform;
		_ = draggingIK.solver.bones[0].transform;
		Transform parent = draggingIK.solver.bones[1].transform;
		dangleRootGO = new GameObject("[dangle joint root]");
		dangleRootGO.transform.SetParent(parent, worldPositionStays: false);
		Rigidbody rigidbody = dangleRootGO.AddComponent<Rigidbody>();
		rigidbody.isKinematic = true;
		knob.AddComponent<Rigidbody>().drag = 1.5f;
		cj = knob.AddComponent<ConfigurableJoint>();
		cj.connectedBody = rigidbody;
		cj.autoConfigureConnectedAnchor = false;
		cj.connectedAnchor = Vector3.zero;
		cj.axis = Vector3.right;
		cj.xMotion = ConfigurableJointMotion.Locked;
		cj.yMotion = ConfigurableJointMotion.Limited;
		cj.zMotion = ConfigurableJointMotion.Limited;
		cj.angularXMotion = ConfigurableJointMotion.Locked;
		cj.angularYMotion = ConfigurableJointMotion.Locked;
		cj.angularZMotion = ConfigurableJointMotion.Locked;
		SoftJointLimit linearLimit = new SoftJointLimit
		{
			limit = 0.9f
		};
		cj.linearLimit = linearLimit;
		PlaySound(dangleSound, knob.transform.position);
	}

	private void Exit_Dangling()
	{
		UnityEngine.Object.Destroy(cj);
		UnityEngine.Object.Destroy(knob.GetComponent<Rigidbody>());
		cj = null;
		UnityEngine.Object.Destroy(dangleRootGO);
		dangleRootGO = null;
		knob.transform.localRotation = Quaternion.identity;
	}

	private void Update_Dangling()
	{
		draggingIK.solver.Update();
	}

	private bool IsRestorableState(State state)
	{
		return Array.IndexOf(restorableStates, state) >= 0;
	}

	private bool ExpectsAttachPoint(State state)
	{
		return Array.IndexOf(statesExpectingAttachPoint, state) >= 0;
	}

	private void Entry_Determine_Next_State()
	{
		fsm.Fire(Trigger.Determine_Next_State);
	}

	private void Exit_Determine_Next_State()
	{
	}

	private void Update_Determine_Next_State()
	{
	}

	private bool TryRestoreState(out State state)
	{
		state = couplerAdapter.coupler.state;
		if (!IsRestorableState(state))
		{
			return false;
		}
		Coupler coupledToOrWithinBreakDistance = couplerAdapter.coupler.CoupledToOrWithinBreakDistance;
		if (coupledToOrWithinBreakDistance != null)
		{
			if (coupledToOrWithinBreakDistance.state == State.Attached_Tight || coupledToOrWithinBreakDistance.state == State.Attached_Loose)
			{
				if (state == State.Parked)
				{
					state = State.Other_Attached_Parked;
				}
				else if (state == State.Dangling)
				{
					state = State.Other_Attached_Dangling;
				}
			}
			if (ExpectsAttachPoint(state))
			{
				attachedTo = coupledToOrWithinBreakDistance.ChainScript;
				if (attachedTo == null)
				{
					return false;
				}
				closestAttachPoint = attachedTo.ownAttachPoint;
			}
		}
		else if (state == State.Attached_Tight || state == State.Attached_Loose)
		{
			state = State.Dangling;
			attachedTo = null;
			closestAttachPoint = null;
		}
		return true;
	}

	private State DetermineNextState()
	{
		if (TryRestoreState(out var result))
		{
			return result;
		}
		bool flag = Vector3.Distance(chainRingAnchor.position, parkedAnchor.position) < 0.2f;
		bool flag2 = (bool)closestAttachPoint && closestAttachPoint.isActiveAndEnabled && (Vector3.Distance(chainRingAnchor.position, closestAttachPoint.transform.position) < 0.1f || Vector3.Dot(base.transform.forward, chainRingAnchor.position - closestAttachPoint.transform.position) > 0f);
		if (couplerAdapter.IsCoupled())
		{
			ChainCouplerInteraction chainCouplerInteraction = couplerAdapter.coupler?.coupledTo?.ChainScript;
			if (!chainCouplerInteraction)
			{
				return State.Disabled;
			}
			closestAttachPoint = chainCouplerInteraction.ownAttachPoint;
			if (chainCouplerInteraction.fsm != null && chainCouplerInteraction.fsm.IsInState(State.Attached))
			{
				return State.Other_Attached_Parked;
			}
			return State.Attached_Tight;
		}
		if (flag)
		{
			return State.Parked;
		}
		if (flag2)
		{
			return State.Attached_Loose;
		}
		return State.Dangling;
	}

	private void Entry_Other_Attached()
	{
		if (attachedTo == null)
		{
			Debug.LogWarning("attachedTo should've been assigned from other coupler's Attached state entry action", this);
			attachedTo = closestAttachPoint.transform.parent.parent.GetComponent<ChainCouplerInteraction>();
		}
		knobGizmo.InteractionAllowed = false;
		Transform target = attachedTo.draggingIK.solver.bones[0].transform;
		otherAttachedIK.solver.target = target;
		this.OtherAttached?.Invoke();
	}

	private void Exit_Other_Attached()
	{
		knobGizmo.InteractionAllowed = true;
		otherAttachedIK.solver.target = null;
	}

	private void Update_Other_Attached()
	{
	}

	private void Entry_Other_Attached_Parked()
	{
		SetParkedHackRotationParams();
		draggingIK.solver.target = parkedAnchor;
		draggingIK.solver.Update();
		draggingIK.solver.Update();
	}

	private void Entry_Other_Attached_Dangling()
	{
		knob.transform.position = draggingIK.solver.bones[1].transform.position - base.transform.up;
		draggingIK.solver.target = knob.transform;
		draggingIK.solver.Update();
		draggingIK.solver.Update();
	}

	private void Entry_Parked()
	{
		couplerAdapter.coupler.state = State.Parked;
		draggingIK.solver.target = knob.transform;
		knob.transform.localPosition = parkedAnchor.localPosition;
		SetParkedHackRotationParams();
		PlaySound(parkSound, knob.transform.position);
	}

	private void Exit_Parked()
	{
		HackRotation componentInChildren = GetComponentInChildren<HackRotation>();
		componentInChildren.angleThreshold = 58f;
		componentInChildren.targetLocalRot = new Quaternion(0.7071068f, 0f, 0f, 0.7071068f);
		componentInChildren.lerp = 0.01f;
	}

	private void Update_Parked()
	{
		draggingIK.solver.Update();
	}

	private void SetParkedHackRotationParams()
	{
		HackRotation componentInChildren = GetComponentInChildren<HackRotation>();
		componentInChildren.angleThreshold = 2f;
		componentInChildren.targetLocalRot = new Quaternion(0.7908702f, 0f, 0f, 0.6119841f);
		componentInChildren.lerp = 0.15f;
	}
}
