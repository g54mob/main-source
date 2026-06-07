using System;
using System.Collections;
using DV.Simulation.Brake;
using DV.Utils;
using UnityEngine;

public class Coupler : MonoBehaviour
{
	public delegate void HoseConnectionChangedDelegate(bool connected, bool isFront, bool playAudio);

	public const string PLACEHOLDER_FRONT_NAME = "[coupler front]";

	public const string PLACEHOLDER_REAR_NAME = "[coupler rear]";

	public const float COUPLING_SCAN_RANGE = 1.5f;

	public const float COUPLING_CONE_ANGLE = 0.2f;

	public const float BREAK_FORCE = 300000000f;

	public const float BREAK_TORQUE = 100000000f;

	public const float AUTO_COUPLE_DELAY = 0.5f;

	private const float BUFFER_PLATE_WIDTH = 0.45f;

	private const float BUFFER_COLLIDER_LENGTH = 1f;

	private const float BUFFER_SIDEWAYS_OFFSET = 0.8640631f;

	private const float BUFFER_EXTRA_SPACE = 0.1f;

	private const float SPRINGY_JOINT_LIMIT_SPRING_TIGHT = 4000000f;

	private const float SPRINGY_JOINT_LIMIT_DAMPER_TIGHT = 4000000f;

	private const float RIGID_JOINT_SPRING = 20000000f;

	private const float TARGET_DISTANCE_LOOSE = 0.3f;

	private const float TARGET_DISTANCE_TIGHT = 0.2f;

	private const float JOINT_ADAPT_STEP = 0.005f;

	public const float JOINT_ADAPT_DURATION = 5f;

	private const float COUPLER_Y_IN_PREFAB = 1.05f;

	public TrainCar train;

	[NonSerialized]
	public bool isFrontCoupler;

	[NonSerialized]
	public Coupler coupledTo;

	[NonSerialized]
	public ConfigurableJoint rigidCJ;

	[NonSerialized]
	public ChainCouplerInteraction.State state = ChainCouplerInteraction.State.Parked;

	public bool preventAutoCouple;

	private HoseAndCock _hoseAndCock;

	[HideInInspector]
	public VisualCouplerInit visualCoupler;

	private BoxCollider fakeBuffersCollider;

	private Coroutine jointCoroRigid;

	private static int _trainBigColliderLayerMask = 0;

	private const float VISUAL_COUPLER_Z_CORRECT_OFFSET = -0.25f;

	private static readonly Collider[] trainCarHits = new Collider[10];

	public Coupler CoupledToOrWithinBreakDistance
	{
		get
		{
			if (!IsCoupled())
			{
				return GetFirstCouplerInRange(1.4f);
			}
			return coupledTo;
		}
	}

	public ChainCouplerInteraction ChainScript => visualCoupler?.chainAdapter?.chainScript;

	public HoseAndCock hoseAndCock
	{
		get
		{
			if (_hoseAndCock == null && (bool)train.brakeSystem)
			{
				_hoseAndCock = (isFrontCoupler ? train.brakeSystem.Front : train.brakeSystem.Rear);
			}
			return _hoseAndCock;
		}
	}

	public bool IsCockOpen
	{
		get
		{
			return hoseAndCock.cockOpen;
		}
		set
		{
			hoseAndCock.SetCock(value);
		}
	}

	public bool IsJointAdaptationActive => jointCoroRigid != null;

	private static int TrainBigColliderLayerMask
	{
		get
		{
			if (_trainBigColliderLayerMask == 0)
			{
				_trainBigColliderLayerMask = 1 << LayerMask.NameToLayer("Train_Big_Collider");
			}
			return _trainBigColliderLayerMask;
		}
	}

	private Vector3 CouplerDistanceCheckPosition
	{
		get
		{
			if (!(visualCoupler == null))
			{
				return base.transform.position + base.transform.forward * -0.25f;
			}
			return base.transform.position;
		}
	}

	public static event Action<Coupler, Coupler> AutoCoupledGlobal;

	public event EventHandler<CoupleEventArgs> Coupled;

	public event EventHandler<UncoupleEventArgs> Uncoupled;

	public event HoseConnectionChangedDelegate HoseConnectionChanged;

	private void OnDisable()
	{
		KillJointCoroutines();
	}

	private void Awake()
	{
		fakeBuffersCollider = base.gameObject.AddComponent<BoxCollider>();
		fakeBuffersCollider.size = new Vector3(2.178126f, 0.45f, 1f);
		fakeBuffersCollider.center = new Vector3(0f, 0f, -0.6f);
		base.gameObject.layer = LayerMask.NameToLayer("Train_Big_Collider");
		if (base.transform.localPosition.x != 0f)
		{
			Debug.LogWarning("Coupler position x should be 0", this);
		}
		if (base.transform.localPosition.y != 1.05f)
		{
			Debug.LogWarning($"Coupler position y should be {1.05f}", this);
		}
		if (base.transform.localRotation.eulerAngles.x != 0f)
		{
			Debug.LogWarning("Coupler rotation x should be 0", this);
		}
		if (base.transform.localRotation.eulerAngles.z != 0f)
		{
			Debug.LogWarning("Coupler rotation z should be 0", this);
		}
		if (base.transform.localRotation.eulerAngles.y != 0f && base.transform.localRotation.eulerAngles.y != 180f)
		{
			Debug.LogWarning("Coupler rotation y should be 0 or 180", this);
		}
	}

	public void AttemptAutoCouple()
	{
		fakeBuffersCollider.enabled = false;
		StartCoroutine(AutoCouple(0.5f));
	}

	private void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading)
		{
			Uncouple(playAudio: false);
		}
	}

	private void KillJointCoroutines()
	{
		if (jointCoroRigid != null)
		{
			StopCoroutine(jointCoroRigid);
		}
		jointCoroRigid = null;
	}

	public Coupler GetFirstCouplerInRange(float range = 1.5f)
	{
		Vector3 checkPosition = CouplerDistanceCheckPosition;
		float sqrRange = range * range;
		int num = Physics.OverlapSphereNonAlloc(checkPosition, range, trainCarHits, TrainBigColliderLayerMask, QueryTriggerInteraction.Ignore);
		for (int i = 0; i < num; i++)
		{
			TrainCar trainCar = TrainCar.Resolve(trainCarHits[i].gameObject);
			if (!(trainCar == null) && !(trainCar == train) && !trainCar.preventCouple)
			{
				if (CheckCoupler(trainCar.frontCoupler))
				{
					return trainCar.frontCoupler;
				}
				if (CheckCoupler(trainCar.rearCoupler))
				{
					return trainCar.rearCoupler;
				}
			}
		}
		return null;
		bool CheckCoupler(Coupler c)
		{
			if (c == null || c.IsCoupled())
			{
				return false;
			}
			Vector3 vector = c.CouplerDistanceCheckPosition - checkPosition;
			float sqrMagnitude = vector.sqrMagnitude;
			bool flag = sqrMagnitude < sqrRange;
			bool flag2 = sqrMagnitude < 1f || Vector3.Dot(vector.normalized, base.transform.forward) > 0.8f;
			return flag && flag2;
		}
	}

	public void TryCouple(bool playAudio = true, bool viaChainInteraction = false, float scanRange = 1.5f)
	{
		if (IsCoupled())
		{
			return;
		}
		if (train.preventCouple)
		{
			Debug.LogWarning("Attempted to couple car with preventCouple flag set! Ignoring request");
			return;
		}
		Coupler firstCouplerInRange = GetFirstCouplerInRange(scanRange);
		if (firstCouplerInRange != null)
		{
			CoupleTo(firstCouplerInRange, playAudio, viaChainInteraction);
		}
	}

	public bool IsCoupled()
	{
		return coupledTo != null;
	}

	public bool IsTightened()
	{
		return state == ChainCouplerInteraction.State.Attached_Tight;
	}

	public Coupler GetCoupled()
	{
		return coupledTo;
	}

	public Coupler GetAirHoseConnectedTo()
	{
		if (hoseAndCock == null || !hoseAndCock.IsHoseConnected)
		{
			return null;
		}
		TrainCar component = hoseAndCock.connectedTo.parentSystem.GetComponent<TrainCar>();
		if (!hoseAndCock.connectedTo.isFront)
		{
			return component.rearCoupler;
		}
		return component.frontCoupler;
	}

	public Coupler GetOppositeCoupler()
	{
		if (!(train.couplers[0] != this))
		{
			return train.couplers[1];
		}
		return train.couplers[0];
	}

	public TrainCar CoupleTo(Coupler other, bool playAudio = true, bool viaChainInteraction = false)
	{
		if ((bool)coupledTo || (bool)other.coupledTo)
		{
			return null;
		}
		other.coupledTo = this;
		coupledTo = other;
		CreateJoints(!viaChainInteraction);
		if (rigidCJ == null)
		{
			return null;
		}
		try
		{
			this.Coupled?.Invoke(this, new CoupleEventArgs(this, other, viaChainInteraction));
		}
		catch (Exception exception)
		{
			Debug.LogError("The following exception was caught while firing Coupler.Coupled event", this);
			Debug.LogException(exception);
		}
		try
		{
			other.Coupled?.Invoke(this, new CoupleEventArgs(other, this, viaChainInteraction));
		}
		catch (Exception exception2)
		{
			Debug.LogError("The following exception was caught while firing Coupler.Coupled event", this);
			Debug.LogException(exception2);
		}
		if (playAudio && (bool)SingletonBehaviour<AudioManager>.Instance && SingletonBehaviour<AudioManager>.Instance.couplingClips != null)
		{
			SingletonBehaviour<AudioManager>.Instance.couplingClips.Play(base.transform.position, 1f, 1f, 150f, 5f);
		}
		Trainset.Merge(train, coupledTo.train);
		if (!viaChainInteraction)
		{
			if (state != ChainCouplerInteraction.State.Attached_Tight)
			{
				state = ChainCouplerInteraction.State.Attached_Tight;
				other.state = ChainCouplerInteraction.State.Parked;
			}
			ConnectAirHose(other, playAudio);
			IsCockOpen = true;
			other.IsCockOpen = true;
		}
		return coupledTo.train;
	}

	public void Uncouple(bool playAudio = true, bool calledOnOtherCoupler = false, bool dueToBrokenCouple = false, bool viaChainInteraction = false)
	{
		if (!Application.isPlaying || !IsCoupled())
		{
			return;
		}
		Coupler coupler = coupledTo;
		coupledTo = null;
		KillJointCoroutines();
		if ((bool)rigidCJ)
		{
			UnityEngine.Object.Destroy(rigidCJ);
		}
		if (playAudio && (bool)base.transform && (bool)SingletonBehaviour<AudioManager>.Instance && SingletonBehaviour<AudioManager>.Instance.uncouplingClips != null)
		{
			SingletonBehaviour<AudioManager>.Instance.uncouplingClips.Play(base.transform.position, 1f, 1f, 150f, 5f);
		}
		fakeBuffersCollider.enabled = true;
		if (!calledOnOtherCoupler)
		{
			if ((bool)coupler)
			{
				coupler.Uncouple(playAudio: false, calledOnOtherCoupler: true, dueToBrokenCouple, viaChainInteraction);
			}
			Trainset.Split(train, coupler.train);
		}
		if (dueToBrokenCouple)
		{
			DisconnectAirHose(playAudio);
			if (state == ChainCouplerInteraction.State.Attached_Tight)
			{
				state = ChainCouplerInteraction.State.Dangling;
			}
		}
		else if (!viaChainInteraction)
		{
			IsCockOpen = false;
			DisconnectAirHose(playAudio);
			state = ChainCouplerInteraction.State.Parked;
		}
		try
		{
			this.Uncoupled?.Invoke(this, new UncoupleEventArgs(this, coupler, viaChainInteraction, dueToBrokenCouple));
		}
		catch (Exception exception)
		{
			Debug.LogError("The following exception was caught while firing Coupler.Uncoupled event", this);
			Debug.LogException(exception);
		}
	}

	private IEnumerator AutoCouple(float delay)
	{
		if (train.preventCouple || train.preventAutoCouple || preventAutoCouple)
		{
			fakeBuffersCollider.enabled = true;
			yield break;
		}
		yield return WaitFor.Seconds(delay);
		if (IsCoupled())
		{
			if (state != ChainCouplerInteraction.State.Attached_Tight)
			{
				fakeBuffersCollider.enabled = true;
			}
			yield break;
		}
		Coupler firstCouplerInRange = GetFirstCouplerInRange();
		if (firstCouplerInRange != null && !firstCouplerInRange.train.preventAutoCouple && !firstCouplerInRange.preventAutoCouple && visualCoupler != null && firstCouplerInRange.visualCoupler != null)
		{
			CoupleTo(firstCouplerInRange, playAudio: false);
			Coupler.AutoCoupledGlobal?.Invoke(this, coupledTo);
		}
		else
		{
			fakeBuffersCollider.enabled = true;
		}
	}

	public void InitFromSave(ChainCouplerInteraction.State savedState)
	{
		if (IsCoupled() && savedState == ChainCouplerInteraction.State.Attached_Tight)
		{
			state = ChainCouplerInteraction.State.Parked;
			return;
		}
		state = savedState;
		if (state == ChainCouplerInteraction.State.Attached_Tight)
		{
			TryCouple(playAudio: false);
			SetChainTight(tight: true);
		}
		else if (state == ChainCouplerInteraction.State.Attached_Loose)
		{
			TryCouple(playAudio: false);
			SetChainTight(tight: false);
		}
		if (!IsCoupled())
		{
			fakeBuffersCollider.enabled = true;
		}
	}

	public void ConnectAirHose(Coupler other, bool playAudio)
	{
		if (hoseAndCock.IsHoseConnected || !other)
		{
			return;
		}
		hoseAndCock.Connect(other.isFrontCoupler ? other.train.brakeSystem.Front : other.train.brakeSystem.Rear);
		try
		{
			this.HoseConnectionChanged?.Invoke(connected: true, isFrontCoupler, playAudio);
			other.HoseConnectionChanged?.Invoke(connected: true, other.isFrontCoupler, playAudio);
		}
		catch (Exception exception)
		{
			Debug.LogError("Coupler caught the following exception while firing HoseConnectionChanged event:", this);
			Debug.LogException(exception);
		}
	}

	public void DisconnectAirHose(bool playAudio)
	{
		if (!hoseAndCock.IsHoseConnected)
		{
			return;
		}
		Coupler airHoseConnectedTo = GetAirHoseConnectedTo();
		hoseAndCock.Disconnect();
		try
		{
			this.HoseConnectionChanged?.Invoke(connected: false, isFrontCoupler, playAudio);
			airHoseConnectedTo.HoseConnectionChanged?.Invoke(connected: false, airHoseConnectedTo.isFrontCoupler, playAudio);
		}
		catch (Exception exception)
		{
			Debug.LogError("Coupler caught the following exception while firing HoseConnectionChanged event:", this);
			Debug.LogException(exception);
		}
	}

	private void CreateJoints(bool shouldTighten)
	{
		KillJointCoroutines();
		CreateRigidJoint();
		SetChainTight(shouldTighten);
	}

	private void CreateRigidJoint()
	{
		rigidCJ = train.gameObject.AddComponent<ConfigurableJoint>();
		rigidCJ.xMotion = ConfigurableJointMotion.Limited;
		rigidCJ.yMotion = ConfigurableJointMotion.Limited;
		rigidCJ.zMotion = ConfigurableJointMotion.Limited;
		rigidCJ.angularXMotion = ConfigurableJointMotion.Free;
		rigidCJ.angularYMotion = ConfigurableJointMotion.Limited;
		rigidCJ.angularZMotion = ConfigurableJointMotion.Limited;
		rigidCJ.autoConfigureConnectedAnchor = false;
		rigidCJ.anchor = train.transform.InverseTransformPoint(base.transform.position - base.transform.forward * 0.2f / 2f);
		rigidCJ.connectedAnchor = coupledTo.train.transform.InverseTransformPoint(coupledTo.transform.position - coupledTo.transform.forward * 0.2f / 2f);
		rigidCJ.connectedBody = coupledTo.train.gameObject.GetComponent<Rigidbody>();
		rigidCJ.linearLimit = new SoftJointLimit
		{
			limit = Mathf.Max(JointDistance(), 0.3f)
		};
		rigidCJ.linearLimitSpring = new SoftJointLimitSpring
		{
			spring = 20000000f
		};
		rigidCJ.angularYLimit = new SoftJointLimit
		{
			limit = 40f
		};
		rigidCJ.angularZLimit = new SoftJointLimit
		{
			limit = 6f
		};
		rigidCJ.angularYZLimitSpring = new SoftJointLimitSpring
		{
			spring = 4000000f,
			damper = 4000000f
		};
		rigidCJ.breakForce = 300000000f;
		rigidCJ.breakTorque = 100000000f;
		rigidCJ.enableCollision = true;
	}

	private void StartJointAdaptation(float targetDistance)
	{
		KillJointCoroutines();
		jointCoroRigid = StartCoroutine(AdaptRigidJoint(targetDistance));
	}

	private IEnumerator AdaptRigidJoint(float targetDistance)
	{
		SoftJointLimit ll = rigidCJ.linearLimit;
		while (true)
		{
			if (!rigidCJ)
			{
				jointCoroRigid = null;
				yield break;
			}
			float f = targetDistance - ll.limit;
			if (Mathf.Abs(f) <= 0.005f)
			{
				break;
			}
			ll.limit += Mathf.Sign(f) * 0.005f;
			rigidCJ.linearLimit = ll;
			yield return WaitFor.FixedUpdate;
		}
		ll.limit = targetDistance;
		rigidCJ.linearLimit = ll;
		jointCoroRigid = null;
	}

	public void SetChainTight(bool tight)
	{
		if ((bool)rigidCJ)
		{
			if (tight)
			{
				EnableBufferSpring();
				StartJointAdaptation(0.2f);
				state = ChainCouplerInteraction.State.Attached_Tight;
			}
			else
			{
				DisableBufferSpring();
				StartJointAdaptation(0.3f);
				state = ChainCouplerInteraction.State.Attached_Loose;
			}
		}
	}

	private void EnableBufferSpring()
	{
		if (!(rigidCJ == null))
		{
			rigidCJ.targetPosition = (isFrontCoupler ? Vector3.forward : Vector3.back) * 0.3f;
			rigidCJ.zDrive = new JointDrive
			{
				positionSpring = 4000000f,
				positionDamper = 4000000f,
				maximumForce = 1200000f
			};
			fakeBuffersCollider.enabled = false;
			coupledTo.fakeBuffersCollider.enabled = false;
		}
	}

	private void DisableBufferSpring()
	{
		if (!(rigidCJ == null))
		{
			rigidCJ.targetPosition = Vector3.zero;
			rigidCJ.zDrive = default(JointDrive);
			fakeBuffersCollider.enabled = true;
			coupledTo.fakeBuffersCollider.enabled = true;
		}
	}

	private float JointDistance()
	{
		Vector3 a = train.transform.TransformPoint(rigidCJ.anchor);
		Vector3 b = rigidCJ.connectedBody.transform.TransformPoint(rigidCJ.connectedAnchor);
		return Vector3.Distance(a, b);
	}

	public void TempDisableOfBufferColliders(bool disable)
	{
		fakeBuffersCollider.isTrigger = disable;
	}

	private void OnDrawGizmos()
	{
		if ((bool)rigidCJ)
		{
			Gizmos.color = Color.cyan;
			Gizmos.DrawLine(rigidCJ.transform.TransformPoint(rigidCJ.anchor) + Vector3.up * 0.02f, rigidCJ.connectedBody.transform.TransformPoint(rigidCJ.connectedAnchor) + Vector3.up * 0.02f);
		}
	}
}
