using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class Grabbable : NetworkEntityBehaviourBase
{
	private struct IgnoredCollision
	{
		public Collider other;

		public int frameEnabled;
	}

	[Serializable]
	public class SpringData
	{
		[Min(0f)]
		public float angularFrequency;

		[Min(0f)]
		public float dampingRatio;

		[Range(0f, 3f)]
		public float distanceMultiplier = 1f;

		[Range(0f, 1f)]
		public float lerpMultiplier = 1f;

		public Spring Create(float deltaTime)
		{
			return Spring.Create(angularFrequency, dampingRatio, deltaTime);
		}
	}

	private struct BoxSpring : IComparable<BoxSpring>
	{
		public BoxSpringSide side;

		public Vector3 position;

		public BoxSpring(BoxSpringSide side, Vector3 position)
		{
			this.side = side;
			this.position = position;
		}

		public int CompareTo(BoxSpring other)
		{
			return position.y.CompareTo(other.position.y);
		}
	}

	private enum BoxSpringSide
	{
		Left = 0,
		Right = 1,
		Forward = 2,
		Back = 3
	}

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct EvBrokeEntireStack : IEntityEvent, IEntityTyped
	{
	}

	public bool canBeStackedOn = true;

	public Collider physicsCollider;

	[Header("Placement")]
	[Min(0f)]
	public float placementForce = 8f;

	[Min(0f)]
	public float placementUpwardsModifier = 15f;

	[Min(0f)]
	public float placementIgnoreColliderDuration = 1f;

	[Header("Stack Break")]
	[Range(0f, 1f)]
	public float breakStackSpringDistance = 0.35f;

	[Min(0f)]
	public float breakStackForceAmount = 10f;

	public SpringData[] springs = new SpringData[4];

	[Space]
	public Renderer[] boxMeshRenderers;

	public GameObject stackTrigger;

	[Header("Audio")]
	public EventReference pickUpSfx;

	[SyncVar]
	private int _stackLevel = 1;

	[SyncVar]
	private int _stackSlotsRemaining;

	[SyncVar]
	private bool _syncCanPutBoxOn;

	[NonSerialized]
	[SyncVar]
	public int syncStackIndex = -1;

	[SyncVar]
	public Entity syncHeldByPlayer;

	[SyncVar]
	public bool syncHeldInHolder;

	[NonSerialized]
	public readonly SyncList<Entity> _stack = new SyncList<Entity>();

	[NonSerialized]
	[SyncVar]
	private NetworkIdentity _baseGrabbable;

	private bool _isKinematic;

	private bool _isInteractable;

	private bool _serverIsOutbounding;

	private MaterialPropertyBlock boxMpb;

	private Spring[] _springs;

	private Queue<IgnoredCollision> _ignoredQueue = new Queue<IgnoredCollision>();

	private static List<Collider> _colliders;

	private static List<GrabbableHolder> _holders;

	private static List<Entity> _entities;

	private static List<BoxSpring> _boxSprings;

	private static List<IBoxStackedOn> _boxStackedOns;

	private static List<Vector3> _positions;

	private static readonly int SELECTED;

	private static bool _loggedException;

	private const float POSITION_CORRECTION_THRESHOLD = 0.1f;

	private const float POSITION_CORRECTION_THRESHOLD_SQR = 0.010000001f;

	private const float DOT_45_DEGREES = 0.70710677f;

	public const int MAX_STACK_COUNT = 4;

	protected uint ____baseGrabbableNetId;

	public int stackLevel => _stackLevel;

	public bool isKinematic => _isKinematic;

	public bool isInteractable => _isInteractable;

	public bool serverIsOutbounding => _serverIsOutbounding;

	public bool isBase => (object)Network_baseGrabbable == null;

	public bool isInStack
	{
		get
		{
			if (isBase)
			{
				return GetStackCount() > 1;
			}
			return true;
		}
	}

	public bool isInStackAndNotBase
	{
		get
		{
			if (isInStack)
			{
				return !isBase;
			}
			return false;
		}
	}

	public bool canPutBoxOn => _syncCanPutBoxOn;

	public Entity serverPlayerEntity { get; private set; }

	public Entity serverHolderEntity { get; private set; }

	public int serverHolderId { get; private set; }

	public Vector3 stackCorrectionVelocity { get; set; }

	public Vector3 stackCorrectionTorque { get; set; }

	public Entity baseEntity
	{
		get
		{
			if (isBase)
			{
				return Entity.invalid;
			}
			return Network_baseGrabbable.GetEntity();
		}
	}

	public bool tutorialStackBroken { get; set; }

	public int Network_stackLevel
	{
		get
		{
			return _stackLevel;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _stackLevel, 1uL, null);
		}
	}

	public int Network_stackSlotsRemaining
	{
		get
		{
			return _stackSlotsRemaining;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _stackSlotsRemaining, 2uL, null);
		}
	}

	public bool Network_syncCanPutBoxOn
	{
		get
		{
			return _syncCanPutBoxOn;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _syncCanPutBoxOn, 4uL, null);
		}
	}

	public int NetworksyncStackIndex
	{
		get
		{
			return syncStackIndex;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncStackIndex, 8uL, null);
		}
	}

	public Entity NetworksyncHeldByPlayer
	{
		get
		{
			return syncHeldByPlayer;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncHeldByPlayer, 16uL, null);
		}
	}

	public bool NetworksyncHeldInHolder
	{
		get
		{
			return syncHeldInHolder;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref syncHeldInHolder, 32uL, null);
		}
	}

	public NetworkIdentity Network_baseGrabbable
	{
		get
		{
			return GetSyncVarNetworkIdentity(____baseGrabbableNetId, ref _baseGrabbable);
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter_NetworkIdentity(value, ref _baseGrabbable, 64uL, null, ref ____baseGrabbableNetId);
		}
	}

	protected override void OnInitializeBehaviour()
	{
		_springs = new Spring[springs.Length];
		for (int i = 0; i < springs.Length; i++)
		{
			_springs[i] = springs[i].Create(1f / 60f);
		}
		if (base.isServer)
		{
			Network_stackSlotsRemaining = 3;
		}
	}

	protected override void OnEntityCreated()
	{
		boxMpb = new MaterialPropertyBlock();
		Renderer[] array = boxMeshRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetPropertyBlock(boxMpb);
		}
		_isInteractable = true;
	}

	protected override void OnUpdateSimulation()
	{
		try
		{
			if (_isKinematic && isBase)
			{
				base.entity.transform.localPosition = Vector3.zero;
				base.entity.transform.localRotation = Quaternion.identity;
				Vector3 position = base.entity.transform.position;
				for (int i = 0; i < _stack.Count; i++)
				{
					Entity entity = _stack[i];
					if (entity.TryGetObject<Grabbable>(out var obj) && obj._isKinematic)
					{
						entity.transform.position = position + Vector3.up * (i + 1);
						entity.transform.localRotation = Quaternion.identity;
					}
				}
			}
			while (_ignoredQueue.Count > 0 && _ignoredQueue.Peek().frameEnabled <= TimeUtil.frame)
			{
				IgnoredCollision ignoredCollision = _ignoredQueue.Dequeue();
				if (ignoredCollision.other != null)
				{
					Physics.IgnoreCollision(physicsCollider, ignoredCollision.other, ignore: false);
				}
			}
			if (base.isServer)
			{
				if (isInStack)
				{
					if (isBase)
					{
						NetworksyncStackIndex = 0;
						for (int j = 0; j < _stack.Count; j++)
						{
							_stack[j].GetObject<Grabbable>().NetworksyncStackIndex = j + 1;
						}
					}
				}
				else
				{
					NetworksyncStackIndex = -1;
				}
			}
			if (isBase && isInStack && syncStackIndex >= 0)
			{
				bool flag = true;
				for (int k = 0; k < _stack.Count; k++)
				{
					if (!_stack[k].GetObject<Grabbable>()._isKinematic)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					if (base.isServer)
					{
						GetGroundedSpringPositions(1f, out var left, out var right, out var fwd, out var back);
						Vector3 left2 = left;
						Vector3 right2 = right;
						Vector3 fwd2 = fwd;
						Vector3 back2 = back;
						if (ShouldBreakStack(left2, right2, fwd2, back2))
						{
							ServerBreakEntireStack();
						}
						else
						{
							GetTopBoxSpringPositions(1f, out left2, out right2, out fwd2, out back2);
							int num = -1;
							for (int l = 0; l < _stack.Count; l++)
							{
								Grabbable grabbable = _stack[l].GetObject<Grabbable>();
								if (grabbable.ShouldBreakStack(left2, right2, fwd2, back2))
								{
									num = l;
									break;
								}
								grabbable.GetTopBoxSpringPositions(1f, out left2, out right2, out fwd2, out back2);
							}
							if (num >= 0)
							{
								ServerBreakEntireStack();
							}
						}
					}
					if (isInStack)
					{
						int num2 = springs.Length - (_stack.Count + 1);
						float distanceMultiplier = springs[num2].distanceMultiplier;
						GetGroundedSpringPositions(distanceMultiplier, out var left3, out var right3, out var fwd3, out var back3);
						Vector3 left4 = left3;
						Vector3 right4 = right3;
						Vector3 fwd4 = fwd3;
						Vector3 back4 = back3;
						CorrectInStack(num2, torqueOnly: true, left4, right4, fwd4, back4);
						distanceMultiplier = springs[num2 + 1].distanceMultiplier;
						GetTopBoxSpringPositions(distanceMultiplier, out left4, out right4, out fwd4, out back4);
						Grabbable obj2;
						for (int m = 0; m < _stack.Count && _stack[m].TryGetObject<Grabbable>(out obj2); m++)
						{
							obj2.CorrectInStack(num2 + m + 1, torqueOnly: false, left4, right4, fwd4, back4);
							if (m + 1 < _stack.Count)
							{
								distanceMultiplier = springs[m + 2].distanceMultiplier;
								obj2.GetTopBoxSpringPositions(distanceMultiplier, out left4, out right4, out fwd4, out back4);
							}
						}
					}
				}
			}
			if (isInStack)
			{
				if (isBase)
				{
					int num3 = springs.Length - (_stack.Count + 1);
					base.entity.GetObject<NetworkTransformFollow>().speedMultiplier = springs[num3].lerpMultiplier;
					for (int n = 0; n < _stack.Count; n++)
					{
						if (_stack[n].TryGetObject<NetworkTransformFollow>(out var obj3))
						{
							obj3.speedMultiplier = springs[num3 + n + 1].lerpMultiplier;
						}
					}
				}
			}
			else
			{
				base.entity.GetObject<NetworkTransformFollow>().speedMultiplier = 1f;
			}
			if (base.isServer)
			{
				if (isBase)
				{
					if (base.entity.transform.position.y < 1f)
					{
						Network_stackLevel = 1;
					}
					else
					{
						Network_stackLevel = 2;
					}
				}
				if (isBase && isInStack)
				{
					for (int num4 = 0; num4 < _stack.Count; num4++)
					{
						_stack[num4].GetObject<Grabbable>().Network_stackLevel = _stackLevel + num4 + 1;
					}
				}
				if (isBase)
				{
					if (_stack.Count == 0)
					{
						if (canBeStackedOn)
						{
							Network_stackSlotsRemaining = 3;
							Network_syncCanPutBoxOn = true;
						}
						else
						{
							Network_stackSlotsRemaining = 0;
							Network_syncCanPutBoxOn = false;
						}
					}
					else
					{
						Network_syncCanPutBoxOn = false;
						Grabbable grabbable2 = _stack[_stack.Count - 1].GetObject<Grabbable>();
						if (!grabbable2.canBeStackedOn)
						{
							Network_stackSlotsRemaining = 0;
							grabbable2.Network_syncCanPutBoxOn = false;
						}
						else
						{
							Network_stackSlotsRemaining = 4 - (_stack.Count + 1);
							grabbable2.Network_syncCanPutBoxOn = _stackSlotsRemaining > 0;
						}
						for (int num5 = 0; num5 < _stack.Count - 1; num5++)
						{
							_stack[num5].GetObject<Grabbable>().Network_syncCanPutBoxOn = false;
						}
					}
				}
				else
				{
					Network_stackSlotsRemaining = 0;
				}
			}
			if (isInteractable)
			{
				if (isInStack && Network_baseGrabbable != null)
				{
					SyncList<Entity> stack = Network_baseGrabbable.GetEntity().GetObject<Grabbable>()._stack;
					stackTrigger.SetActive(stack.Count > 0 && stack[stack.Count - 1] == base.entity);
				}
				else
				{
					stackTrigger.SetActive(value: true);
				}
				if (stackTrigger.activeSelf)
				{
					Vector3 vector = ((!isInStack) ? (base.entity.transform.position + Vector3.up) : (base.entity.transform.position + base.entity.transform.up));
					if (math.distancesq(vector, stackTrigger.transform.position) > 0.010000001f)
					{
						stackTrigger.transform.position = vector;
					}
				}
			}
			else
			{
				stackTrigger.SetActive(value: false);
			}
		}
		catch
		{
			if (!_loggedException)
			{
				_loggedException = true;
				try
				{
					string text = "Exception caught in Grabbable.OnUpdateSimulation - State Dump\n";
					text += $"  IsServer: {NetworkServer.active}\n";
					text = text + "  BoxName: " + base.entity.name + "\n";
					text += $"  IsKinematic: {_isKinematic}\n";
					text += $"  RB.IsKinematic: {base.entity.rigidbody.isKinematic}\n";
					text += $"  IsBase: {isBase}\n";
					if (!isBase)
					{
						text = ((!(Network_baseGrabbable != null)) ? (text + "  BaseGrabbable: NULL\n") : ((!Network_baseGrabbable.GetEntity().Exists()) ? (text + "  BaseGrabbable: ENTITY DOES NOT EXIST\n") : (text + "  BaseGrabbable: " + Network_baseGrabbable.GetEntity().name + "\n")));
					}
					else
					{
						text += $"  StackCount: {_stack.Count + 1}\n";
						for (int num6 = 0; num6 < _stack.Count; num6++)
						{
							Entity entity2 = _stack[num6];
							text = ((!entity2.Exists()) ? (text + $"    {num6}: ENTITY DOES NOT EXIST\n") : (text + $"    {num6}: {entity2.name}\n"));
						}
					}
					Debug.LogError(text);
				}
				catch
				{
					Debug.LogError("Exception caught in Grabbable.OnUpdateSimulation - Exception doing state dump");
				}
			}
			throw;
		}
	}

	protected override void OnUpdatePresentation()
	{
		if (_isKinematic && isBase)
		{
			base.entity.transform.localPosition = Vector3.zero;
			base.entity.transform.localRotation = Quaternion.identity;
			Vector3 position = base.entity.transform.position;
			for (int i = 0; i < _stack.Count; i++)
			{
				Entity entity = _stack[i];
				if (entity.TryGetObject<Grabbable>(out var obj) && obj._isKinematic)
				{
					entity.transform.position = position + Vector3.up * (i + 1);
					entity.transform.localRotation = Quaternion.identity;
				}
			}
		}
		if (base.isServer)
		{
			NetworksyncHeldByPlayer = ServerGetHoldingPlayer();
			NetworksyncHeldInHolder = ServerIsBeingHeldByHolder();
		}
	}

	private void CorrectInStack(int index, bool torqueOnly, Vector3 toLeft, Vector3 toRight, Vector3 toFwd, Vector3 toBack)
	{
		GetBottomBoxSpringPositions(springs[index].distanceMultiplier, out var left, out var right, out var fwd, out var back);
		Spring spring = _springs[index];
		Vector3 velocity = Vector3.zero;
		Vector3 velocity2 = Vector3.zero;
		Vector3 velocity3 = Vector3.zero;
		Vector3 velocity4 = Vector3.zero;
		Correct(spring, left, toLeft, torqueOnly, ref velocity);
		Correct(spring, right, toRight, torqueOnly, ref velocity2);
		Correct(spring, fwd, toFwd, torqueOnly, ref velocity3);
		Correct(spring, back, toBack, torqueOnly, ref velocity4);
	}

	private bool ShouldBreakStack(Vector3 toLeft, Vector3 toRight, Vector3 toFwd, Vector3 toBack)
	{
		GetBottomBoxSpringPositions(1f, out var left, out var right, out var fwd, out var back);
		float num = breakStackSpringDistance * breakStackSpringDistance;
		if (!(math.distancesq(left, toLeft) > num) && !(math.distancesq(right, toRight) > num) && !(math.distancesq(fwd, toFwd) > num))
		{
			return math.distancesq(back, toBack) > num;
		}
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void Correct(Spring spring, Vector3 from, Vector3 to, bool torqueOnly, ref Vector3 velocity)
	{
		if (math.distancesq(from, to) < 0.010000001f)
		{
			velocity = Vector3.zero;
			return;
		}
		Vector3 pPos = from;
		spring.Update(to, ref pPos, ref velocity);
		Rigidbody rigidbody = base.entity.rigidbody;
		if (!torqueOnly)
		{
			stackCorrectionVelocity += PhysicsUtil.GetForceVelocity(velocity, rigidbody.mass, ForceMode.VelocityChange);
		}
		stackCorrectionTorque += PhysicsUtil.GetForceTorque(velocity, from, rigidbody.worldCenterOfMass, rigidbody.rotation, rigidbody.mass, rigidbody.inertiaTensor, ForceMode.VelocityChange);
	}

	private void GetGroundedSpringPositions(float springDistanceMultiplier, out Vector3 left, out Vector3 right, out Vector3 fwd, out Vector3 back)
	{
		Transform obj = base.entity.transform;
		Vector3 position = obj.TransformPoint(new Vector3(-0.5f * springDistanceMultiplier, -0.5f, 0f));
		Vector3 position2 = obj.TransformPoint(new Vector3(0.5f * springDistanceMultiplier, -0.5f, 0f));
		Vector3 position3 = obj.TransformPoint(new Vector3(0f, -0.5f, 0.5f * springDistanceMultiplier));
		Vector3 position4 = obj.TransformPoint(new Vector3(0f, -0.5f, -0.5f * springDistanceMultiplier));
		_boxSprings.Clear();
		_boxSprings.Add(new BoxSpring(BoxSpringSide.Left, position));
		_boxSprings.Add(new BoxSpring(BoxSpringSide.Right, position2));
		_boxSprings.Add(new BoxSpring(BoxSpringSide.Forward, position3));
		_boxSprings.Add(new BoxSpring(BoxSpringSide.Back, position4));
		_boxSprings.Sort();
		Matrix4x4 matrix4x = Matrix4x4.Translate(-_boxSprings[0].position);
		Vector3 vector = _boxSprings[3].position - _boxSprings[0].position;
		vector.Normalize();
		Vector3 toDirection = vector;
		toDirection.y = 0f;
		toDirection.Normalize();
		Matrix4x4 matrix4x2 = Matrix4x4.Rotate(Quaternion.FromToRotation(vector, toDirection));
		Matrix4x4 matrix4x3 = matrix4x.inverse * matrix4x2 * matrix4x;
		for (int i = 0; i < _boxSprings.Count; i++)
		{
			BoxSpring value = _boxSprings[i];
			value.position = matrix4x3 * value.position.XYZW();
			_boxSprings[i] = value;
		}
		Matrix4x4 matrix4x4 = Matrix4x4.Translate(-_boxSprings[1].position);
		Vector3 vector2 = _boxSprings[2].position - _boxSprings[1].position;
		vector2.Normalize();
		Vector3 toDirection2 = vector2;
		toDirection2.y = 0f;
		toDirection2.Normalize();
		Matrix4x4 matrix4x5 = Matrix4x4.Rotate(Quaternion.FromToRotation(vector2, toDirection2));
		Matrix4x4 matrix4x6 = matrix4x4.inverse * matrix4x5 * matrix4x4;
		for (int j = 0; j < _boxSprings.Count; j++)
		{
			BoxSpring value2 = _boxSprings[j];
			value2.position = matrix4x6 * value2.position.XYZW();
			_boxSprings[j] = value2;
		}
		for (int k = 0; k < _boxSprings.Count; k++)
		{
			BoxSpring value3 = _boxSprings[k];
			value3.position = new Vector3(_boxSprings[k].position.x, math.max(_boxSprings[k].position.y, 0f), _boxSprings[k].position.z);
			_boxSprings[k] = value3;
		}
		left = Vector3.zero;
		right = Vector3.zero;
		fwd = Vector3.zero;
		back = Vector3.zero;
		for (int l = 0; l < _boxSprings.Count; l++)
		{
			BoxSpring boxSpring = _boxSprings[l];
			switch (boxSpring.side)
			{
			case BoxSpringSide.Left:
				left = boxSpring.position;
				break;
			case BoxSpringSide.Right:
				right = boxSpring.position;
				break;
			case BoxSpringSide.Forward:
				fwd = boxSpring.position;
				break;
			case BoxSpringSide.Back:
				back = boxSpring.position;
				break;
			default:
				throw new InvalidEnumException();
			}
		}
	}

	private void GetBottomBoxSpringPositions(float springDistanceMultiplier, out Vector3 left, out Vector3 right, out Vector3 fwd, out Vector3 back)
	{
		Transform transform = base.entity.transform;
		left = transform.TransformPoint(new Vector3(-0.5f * springDistanceMultiplier, -0.5f, 0f));
		right = transform.TransformPoint(new Vector3(0.5f * springDistanceMultiplier, -0.5f, 0f));
		fwd = transform.TransformPoint(new Vector3(0f, -0.5f, 0.5f * springDistanceMultiplier));
		back = transform.TransformPoint(new Vector3(0f, -0.5f, -0.5f * springDistanceMultiplier));
	}

	private void GetTopBoxSpringPositions(float springDistanceMultiplier, out Vector3 left, out Vector3 right, out Vector3 fwd, out Vector3 back)
	{
		Transform transform = base.entity.transform;
		left = transform.TransformPoint(new Vector3(-0.5f * springDistanceMultiplier, 0.5f, 0f));
		right = transform.TransformPoint(new Vector3(0.5f * springDistanceMultiplier, 0.5f, 0f));
		fwd = transform.TransformPoint(new Vector3(0f, 0.5f, 0.5f * springDistanceMultiplier));
		back = transform.TransformPoint(new Vector3(0f, 0.5f, -0.5f * springDistanceMultiplier));
	}

	public void MarkIsCandidate()
	{
		boxMpb.SetFloat(SELECTED, 1f);
		Renderer[] array = boxMeshRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetPropertyBlock(boxMpb);
		}
	}

	[Server]
	public void ServerFixStack(Vector3 startPos, Quaternion rotation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerFixStack(UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerFixStack(startPos, rotation);
			return;
		}
		Vector3 up = base.entity.transform.up;
		_positions.Clear();
		_positions.Add(startPos);
		for (int i = 0; i < _stack.Count; i++)
		{
			_positions.Add(startPos + up * (i + 1));
		}
		base.entity.predictedRigidbodyGroup.ServerTeleport(_positions, rotation);
	}

	[Server]
	public void ServerFixStack(Vector3 startPos, Vector3 velocity, Quaternion rotation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerFixStack(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerFixStack(startPos, velocity, rotation);
			return;
		}
		Vector3 up = base.entity.transform.up;
		_positions.Clear();
		_positions.Add(startPos);
		for (int i = 0; i < _stack.Count; i++)
		{
			_positions.Add(startPos + up * (i + 1));
		}
		base.entity.predictedRigidbodyGroup.ServerTeleport(_positions, velocity, rotation);
	}

	[Server]
	public void ServerAddToStack(Grabbable other)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerAddToStack(Grabbable)' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerAddToStack(other);
			return;
		}
		if (other.Network_baseGrabbable != null)
		{
			ServerAddToStack(other.Network_baseGrabbable.GetEntity().GetObject<Grabbable>());
			return;
		}
		bool flag = false;
		if (!isInStack)
		{
			Vector3 up = base.entity.transform.up;
			float num = math.dot(up, Vector3.up);
			if (num < 0.70710677f)
			{
				Vector3 right = base.entity.transform.right;
				Vector3 forward = base.entity.transform.forward;
				float x = math.dot(right, Vector3.up);
				float x2 = math.dot(forward, Vector3.up);
				Vector3 axis;
				Vector3 vector;
				if (math.abs(x) < math.abs(x2))
				{
					axis = Vector3.right;
					vector = right;
				}
				else
				{
					axis = Vector3.forward;
					vector = forward;
				}
				float angle;
				if (num < -0.70710677f)
				{
					angle = 180f;
				}
				else
				{
					float x3 = math.dot((Vector3)math.cross(up, Vector3.up), vector);
					angle = 90f * math.sign(x3);
				}
				base.transform.localRotation *= Quaternion.AngleAxis(angle, axis);
			}
			flag = true;
		}
		Quaternion rotation = base.entity.transform.rotation;
		Vector3 position = base.entity.transform.position;
		rotation = Quaternion.FromToRotation(base.entity.transform.up, Vector3.up) * rotation;
		other.SetBaseGrabbable(this);
		_stack.Add(other.entity);
		base.entity.predictedRigidbodyGroup.ServerAddToGroup(other.entity);
		if (other._stack.Count > 0)
		{
			for (int i = 0; i < other._stack.Count; i++)
			{
				Grabbable grabbable = other._stack[i].GetObject<Grabbable>();
				grabbable.SetBaseGrabbable(this);
				_stack.Add(grabbable.entity);
				base.entity.predictedRigidbodyGroup.ServerAddToGroup(grabbable.entity);
			}
			other._stack.Clear();
			other.entity.predictedRigidbodyGroup.ServerClearGroup();
		}
		_positions.Clear();
		_positions.Add(position);
		for (int j = 0; j < _stack.Count; j++)
		{
			_positions.Add(position + Vector3.up * (j + 1));
		}
		base.entity.predictedRigidbodyGroup.ServerTeleport(_positions, rotation);
		base.entity.GetObject<NetworkTransformFollow>().ServerTeleported();
		for (int k = 0; k < _stack.Count; k++)
		{
			_stack[k].GetObject<NetworkTransformFollow>().ServerTeleported();
		}
		if (flag)
		{
			_boxStackedOns.Clear();
			base.entity.GetObjects(_boxStackedOns);
			for (int l = 0; l < _boxStackedOns.Count; l++)
			{
				_boxStackedOns[l].ServerBoxStackedOn();
			}
		}
	}

	[Server]
	public void ServerSplitStackAtMe()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerSplitStackAtMe()' called when server was not active");
			return;
		}
		int index = ServerGetStackIndex(this);
		ServerSplitStack(index);
	}

	[Server]
	private void ServerSplitStack(int index)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerSplitStack(System.Int32)' called when server was not active");
		}
		else
		{
			if (index == 0)
			{
				return;
			}
			if (Network_baseGrabbable != null)
			{
				Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerSplitStack(index);
				return;
			}
			int num = math.max(index - 1, 0);
			if (num < _stack.Count)
			{
				Grabbable grabbable = _stack[num].GetObject<Grabbable>();
				grabbable.Network_baseGrabbable = null;
				grabbable.entity.predictedRigidbodyGroup.ServerResetGroup();
				for (int i = num + 1; i < _stack.Count; i++)
				{
					Grabbable grabbable2 = _stack[i].GetObject<Grabbable>();
					grabbable2.SetBaseGrabbable(grabbable);
					grabbable._stack.Add(grabbable2.entity);
					grabbable.entity.predictedRigidbodyGroup.ServerAddToGroup(grabbable2.entity);
				}
				for (int num2 = _stack.Count - 1; num2 >= num; num2--)
				{
					_stack.RemoveAt(num2);
				}
				base.entity.predictedRigidbodyGroup.ServerResetGroup();
				for (int j = 0; j < _stack.Count; j++)
				{
					base.entity.predictedRigidbodyGroup.ServerAddToGroup(_stack[j]);
				}
			}
		}
	}

	[Server]
	public void ServerBreakStackAtMe()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerBreakStackAtMe()' called when server was not active");
			return;
		}
		ServerSplitStackAtMe();
		ServerBreakEntireStack();
	}

	[ClientRpc]
	private void RpcBreakStack(Entity e1, Entity e2, Entity e3, Entity e4, RoomType room)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e1);
		writer.WriteEntity(e2);
		writer.WriteEntity(e3);
		writer.WriteEntity(e4);
		GeneratedNetworkCode._Write_RoomType(writer, room);
		SendRPCInternal("System.Void Grabbable::RpcBreakStack(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", -2004398196, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	private int ServerGetStackIndex(Grabbable grabbable)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Int32 Grabbable::ServerGetStackIndex(Grabbable)' called when server was not active");
			return default(int);
		}
		if (Network_baseGrabbable != null)
		{
			return Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerGetStackIndex(grabbable);
		}
		if (base.entity == grabbable.entity)
		{
			return 0;
		}
		for (int i = 0; i < _stack.Count; i++)
		{
			if (_stack[i] == grabbable.entity)
			{
				return i + 1;
			}
		}
		return -1;
	}

	[Server]
	public int ServerGetStackIndex()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Int32 Grabbable::ServerGetStackIndex()' called when server was not active");
			return default(int);
		}
		return ServerGetStackIndex(this);
	}

	[ClientRpc]
	public void RpcQueueEvBrokeEntireStack()
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		SendRPCInternal("System.Void Grabbable::RpcQueueEvBrokeEntireStack()", -1419133334, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerBreakEntireStack()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerBreakEntireStack()' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerBreakEntireStack();
			return;
		}
		if (serverHolderEntity != Entity.invalid)
		{
			_holders.Clear();
			serverHolderEntity.GetObjects(_holders);
			for (int i = 0; i < _holders.Count; i++)
			{
				GrabbableHolder grabbableHolder = _holders[i];
				if (grabbableHolder.id == serverHolderId)
				{
					grabbableHolder.ServerRemoveItem();
					break;
				}
			}
			serverHolderEntity = Entity.invalid;
		}
		if (serverPlayerEntity != Entity.invalid)
		{
			serverPlayerEntity.GetObject<PlayerGrabber>().ServerDropBoxesSimple();
			serverPlayerEntity = Entity.invalid;
		}
		RoomType currentRoomType = GameUtil.GetCurrentRoomType();
		ServerGetStack(out var e, out var e2, out var e3);
		SetPhysics(base.entity, currentRoomType);
		SetPhysics(e, currentRoomType);
		SetPhysics(e2, currentRoomType);
		SetPhysics(e3, currentRoomType);
		RpcBreakStack(base.entity, e, e2, e3, currentRoomType);
		base.entity.predictedRigidbodyGroup.ServerResetGroup();
		for (int j = 0; j < _stack.Count; j++)
		{
			Entity entity = _stack[j];
			Grabbable grabbable = entity.GetObject<Grabbable>();
			grabbable.RpcQueueEvBrokeEntireStack();
			Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
			onUnitSphere.y = math.abs(onUnitSphere.y);
			onUnitSphere = entity.transform.TransformDirection(onUnitSphere);
			entity.rigidbody.AddForce(onUnitSphere * grabbable.breakStackForceAmount, ForceMode.Impulse);
			grabbable.Network_baseGrabbable = null;
			entity.predictedRigidbodyGroup.ServerResetGroup();
		}
		_stack.Clear();
		tutorialStackBroken = true;
	}

	[Server]
	public void ServerPlayerGrabbed(PlayerGrabber grabber)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerPlayerGrabbed(PlayerGrabber)' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerPlayerGrabbed(grabber);
			return;
		}
		Transform grabbedContainer = grabber.grabbedContainer;
		serverPlayerEntity = grabber.entity;
		serverHolderEntity = Entity.invalid;
		ServerGetStack(out var e, out var e2, out var e3);
		SetKinematic(base.entity, grabbedContainer, 0, interactable: false, colliders: false);
		SetKinematic(e, grabbedContainer, 1, interactable: false, colliders: false);
		SetKinematic(e2, grabbedContainer, 2, interactable: false, colliders: false);
		SetKinematic(e3, grabbedContainer, 3, interactable: false, colliders: false);
		RpcSetPlaceInPlayerGrabber(grabber.entity, e, e2, e3);
	}

	[ClientRpc]
	private void RpcSetPlaceInPlayerGrabber(Entity player, Entity e2, Entity e3, Entity e4)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(player);
		writer.WriteEntity(e2);
		writer.WriteEntity(e3);
		writer.WriteEntity(e4);
		SendRPCInternal("System.Void Grabbable::RpcSetPlaceInPlayerGrabber(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity)", -892631996, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerPlayerPrepareForStacked()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerPlayerPrepareForStacked()' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerPlayerPrepareForStacked();
			return;
		}
		ServerGetStack(out var e, out var e2, out var e3);
		RoomType currentRoomType = GameUtil.GetCurrentRoomType();
		serverPlayerEntity = Entity.invalid;
		SetPhysics(base.entity, currentRoomType);
		SetPhysics(e, currentRoomType);
		SetPhysics(e2, currentRoomType);
		SetPhysics(e3, currentRoomType);
		RpcPlayerPrepareForStacked(e, e2, e3, currentRoomType);
	}

	[ClientRpc]
	private void RpcPlayerPrepareForStacked(Entity e2, Entity e3, Entity e4, RoomType room)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e2);
		writer.WriteEntity(e3);
		writer.WriteEntity(e4);
		GeneratedNetworkCode._Write_RoomType(writer, room);
		SendRPCInternal("System.Void Grabbable::RpcPlayerPrepareForStacked(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", -1379168493, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerPlaceInHolder(GrabbableHolder holder)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerPlaceInHolder(GrabbableHolder)' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerPlaceInHolder(holder);
			return;
		}
		Transform container = holder.container;
		serverPlayerEntity = Entity.invalid;
		serverHolderEntity = holder.entity;
		serverHolderId = holder.id;
		ServerGetStack(out var e, out var e2, out var e3);
		RoomType currentRoomType = GameUtil.GetCurrentRoomType();
		SetKinematic(base.entity, container, 0, interactable: true, colliders: true);
		SetKinematic(e, container, 1, interactable: true, colliders: true);
		SetKinematic(e2, container, 2, interactable: true, colliders: true);
		SetKinematic(e3, container, 3, interactable: true, colliders: true);
		ServerFixStack(container.position, container.rotation);
		RpcPlaceInHolder(holder.entity, holder.id, e, e2, e3, currentRoomType);
	}

	[ClientRpc]
	private void RpcPlaceInHolder(Entity holderEntity, int holderId, Entity e2, Entity e3, Entity e4, RoomType room)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(holderEntity);
		writer.WriteVarInt(holderId);
		writer.WriteEntity(e2);
		writer.WriteEntity(e3);
		writer.WriteEntity(e4);
		GeneratedNetworkCode._Write_RoomType(writer, room);
		SendRPCInternal("System.Void Grabbable::RpcPlaceInHolder(Aggro.Core.Entity,System.Int32,Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", -210992348, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerRemoveFromHolder()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerRemoveFromHolder()' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerRemoveFromHolder();
			return;
		}
		serverHolderEntity = Entity.invalid;
		ServerGetStack(out var e, out var e2, out var e3);
		RoomType currentRoomType = GameUtil.GetCurrentRoomType();
		SetPhysics(base.entity, currentRoomType);
		SetPhysics(e, currentRoomType);
		SetPhysics(e2, currentRoomType);
		SetPhysics(e3, currentRoomType);
		RpcRemoveFromHolder(e, e2, e3, currentRoomType);
	}

	[ClientRpc]
	private void RpcRemoveFromHolder(Entity e2, Entity e3, Entity e4, RoomType room)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e2);
		writer.WriteEntity(e3);
		writer.WriteEntity(e4);
		GeneratedNetworkCode._Write_RoomType(writer, room);
		SendRPCInternal("System.Void Grabbable::RpcRemoveFromHolder(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", 556906835, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerBackFromOutbound()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerBackFromOutbound()' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerBackFromOutbound();
			return;
		}
		_isInteractable = true;
		_serverIsOutbounding = false;
		for (int i = 0; i < _stack.Count; i++)
		{
			_stack[i].GetObject<Grabbable>()._serverIsOutbounding = false;
		}
		ServerGetStack(out var e, out var e2, out var e3);
		RoomType currentRoomType = GameUtil.GetCurrentRoomType();
		SetPhysics(e, currentRoomType);
		SetPhysics(e2, currentRoomType);
		SetPhysics(e3, currentRoomType);
		ServerFixStack(base.entity.transform.position, base.entity.transform.rotation);
		RpcReadyFromInbound(e, e2, e3, currentRoomType);
	}

	[ClientRpc]
	private void RpcReadyFromInbound(Entity e2, Entity e3, Entity e4, RoomType room)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e2);
		writer.WriteEntity(e3);
		writer.WriteEntity(e4);
		GeneratedNetworkCode._Write_RoomType(writer, room);
		SendRPCInternal("System.Void Grabbable::RpcReadyFromInbound(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", -172019783, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerReadyForOutboundTransition(GrabbableHolder holder)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerReadyForOutboundTransition(GrabbableHolder)' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerReadyForOutboundTransition(holder);
			return;
		}
		_isInteractable = false;
		_serverIsOutbounding = true;
		for (int i = 0; i < _stack.Count; i++)
		{
			_stack[i].GetObject<Grabbable>()._serverIsOutbounding = true;
		}
		Transform container = holder.container;
		ServerGetStack(out var e, out var e2, out var e3);
		SetKinematic(e, container, 1, interactable: false, colliders: true);
		SetKinematic(e2, container, 2, interactable: false, colliders: true);
		SetKinematic(e3, container, 3, interactable: false, colliders: true);
		RpcReadyForOutboundTransition(holder.entity, holder.id, e, e2, e3);
	}

	[ClientRpc]
	private void RpcReadyForOutboundTransition(Entity holderEntity, int holderId, Entity e2, Entity e3, Entity e4)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(holderEntity);
		writer.WriteVarInt(holderId);
		writer.WriteEntity(e2);
		writer.WriteEntity(e3);
		writer.WriteEntity(e4);
		SendRPCInternal("System.Void Grabbable::RpcReadyForOutboundTransition(Aggro.Core.Entity,System.Int32,Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity)", 1246705508, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerSetInteractable(bool interactable)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerSetInteractable(System.Boolean)' called when server was not active");
			return;
		}
		_isInteractable = interactable;
		RpcSetInteractable(interactable);
	}

	[ClientRpc]
	private void RpcSetInteractable(bool interactable)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteBool(interactable);
		SendRPCInternal("System.Void Grabbable::RpcSetInteractable(System.Boolean)", 1042858553, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerPlayerDropped(Vector3 position, Vector3 velocity, Quaternion rotation)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerPlayerDropped(UnityEngine.Vector3,UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
			return;
		}
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerPlayerDropped(position, velocity, rotation);
			return;
		}
		ServerGetStack(out var e, out var e2, out var e3);
		RoomType currentRoomType = GameUtil.GetCurrentRoomType();
		serverPlayerEntity = Entity.invalid;
		SetPhysics(base.entity, currentRoomType);
		SetPhysics(e, currentRoomType);
		SetPhysics(e2, currentRoomType);
		SetPhysics(e3, currentRoomType);
		RpcPlayerDropped(e, e2, e3, currentRoomType);
		_entities.Clear();
		GetStack(_entities);
		for (int i = 0; i < _entities.Count; i++)
		{
			RigidbodyConstraints constraints = _entities[i].rigidbody.constraints;
			if (PhysicsUtil.IsConstrainingRotation(constraints))
			{
				rotation = PhysicsUtil.Constrain(rotation, constraints);
				break;
			}
		}
		ServerFixStack(position, velocity, rotation);
	}

	[ClientRpc]
	private void RpcPlayerDropped(Entity e2, Entity e3, Entity e4, RoomType room)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(e2);
		writer.WriteEntity(e3);
		writer.WriteEntity(e4);
		GeneratedNetworkCode._Write_RoomType(writer, room);
		SendRPCInternal("System.Void Grabbable::RpcPlayerDropped(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", 2070157802, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public void ServerGetStack(out Entity e2, out Entity e3, out Entity e4)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerGetStack(Aggro.Core.Entity&,Aggro.Core.Entity&,Aggro.Core.Entity&)' called when server was not active");
			e2 = default(Entity);
			e3 = default(Entity);
			e4 = default(Entity);
		}
		else if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerGetStack(out e2, out e3, out e4);
		}
		else
		{
			e2 = ((_stack.Count > 0) ? _stack[0] : Entity.invalid);
			e3 = ((_stack.Count > 1) ? _stack[1] : Entity.invalid);
			e4 = ((_stack.Count > 2) ? _stack[2] : Entity.invalid);
		}
	}

	[Server]
	public void ServerGetStackAtIndex(int index, out Entity e1, out Entity e2, out Entity e3, out Entity e4)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerGetStackAtIndex(System.Int32,Aggro.Core.Entity&,Aggro.Core.Entity&,Aggro.Core.Entity&,Aggro.Core.Entity&)' called when server was not active");
			e1 = default(Entity);
			e2 = default(Entity);
			e3 = default(Entity);
			e4 = default(Entity);
		}
		else if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerGetStackAtIndex(index, out e1, out e2, out e3, out e4);
		}
		else
		{
			_entities.Clear();
			GetStack(_entities);
			e1 = ((_entities.Count > index) ? _entities[index] : Entity.invalid);
			e2 = ((_entities.Count > index + 1) ? _entities[index + 1] : Entity.invalid);
			e3 = ((_entities.Count > index + 2) ? _entities[index + 2] : Entity.invalid);
			e4 = ((_entities.Count > index + 3) ? _entities[index + 3] : Entity.invalid);
		}
	}

	[Server]
	public void ServerAddPlacementForce(Entity from, Vector3 origin)
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Void Grabbable::ServerAddPlacementForce(Aggro.Core.Entity,UnityEngine.Vector3)' called when server was not active");
			return;
		}
		Vector3 vector = base.entity.rigidbody.position - origin;
		vector.y = 0f;
		if (vector.sqrMagnitude == 0f)
		{
			vector = Vector3.right;
		}
		else
		{
			vector.Normalize();
		}
		vector = Quaternion.AngleAxis(placementUpwardsModifier, MathUtil.GetOrtho(vector, Vector3.up)) * vector;
		vector *= placementForce;
		base.entity.rigidbody.AddForce(vector, ForceMode.Impulse);
		IgnoreCollision(from);
		RpcIgnoreCollision(from);
	}

	private void IgnoreCollision(Entity ignore)
	{
		IgnoredCollision item = new IgnoredCollision
		{
			other = ignore.GetObject<Grabbable>().physicsCollider,
			frameEnabled = TimeUtil.frame + TimeUtil.FramesForTime(placementIgnoreColliderDuration)
		};
		_ignoredQueue.Enqueue(item);
		if (physicsCollider == null)
		{
			Debug.LogError("Grabbable.IgnoreCollision - physicsCollider null!");
		}
		else if (item.other == null)
		{
			Debug.LogError("Grabbable.IgnoreCollision - ignoredCollision.other null!");
		}
		else
		{
			Physics.IgnoreCollision(physicsCollider, item.other, ignore: true);
		}
	}

	[ClientRpc]
	private void RpcIgnoreCollision(Entity ignore)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteEntity(ignore);
		SendRPCInternal("System.Void Grabbable::RpcIgnoreCollision(Aggro.Core.Entity)", 1923161090, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	private void SetKinematic(Entity e, Transform container, int stackIndex, bool interactable, bool colliders)
	{
		if (e.TryGetObject<Grabbable>(out var obj))
		{
			obj._isKinematic = true;
			obj._isInteractable = interactable;
			e.rigidbody.isKinematic = true;
			e.predictedRigidbodyGroup.enabled = true;
			e.transform.SetParent(container);
			e.transform.localScale = Vector3.one;
			e.transform.position = container.position + Vector3.up * stackIndex;
			e.transform.localRotation = Quaternion.identity;
			SetColliders(e, colliders);
		}
	}

	private void SetPhysics(Entity e, RoomType room)
	{
		if (e.TryGetObject<Grabbable>(out var obj))
		{
			obj._isKinematic = false;
			obj._isInteractable = true;
			e.rigidbody.isKinematic = false;
			e.predictedRigidbodyGroup.enabled = true;
			e.rigidbody.WakeUp();
			e.transform.SetParent(GameUtil.GetContainer(room));
			e.transform.localScale = Vector3.one;
			SetColliders(e, colliders: true);
			if (base.isClientOnly)
			{
				e.predictedRigidbodyGroup.ClientClearState();
			}
			if (base.isServer)
			{
				e.predictedRigidbodyGroup.SetDirty();
				obj.serverHolderEntity = Entity.invalid;
			}
		}
	}

	public int GetStackCount()
	{
		if (Network_baseGrabbable != null)
		{
			return Network_baseGrabbable.GetEntity().GetObject<Grabbable>().GetStackCount();
		}
		int num = 1;
		for (int i = 0; i < _stack.Count; i++)
		{
			if (_stack[i].Exists())
			{
				num++;
			}
		}
		return num;
	}

	public void GetStack(List<Entity> stack)
	{
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().GetStack(stack);
			return;
		}
		stack.Add(base.entity);
		for (int i = 0; i < _stack.Count; i++)
		{
			Entity item = _stack[i];
			if (item.Exists())
			{
				stack.Add(item);
			}
		}
	}

	public void GetStack(List<Grabbable> stack)
	{
		if (Network_baseGrabbable != null)
		{
			Network_baseGrabbable.GetEntity().GetObject<Grabbable>().GetStack(stack);
			return;
		}
		stack.Add(this);
		for (int i = 0; i < _stack.Count; i++)
		{
			if (_stack[i].TryGetObject<Grabbable>(out var obj))
			{
				stack.Add(obj);
			}
		}
	}

	public bool CanAddToStack(Grabbable grabbable)
	{
		if (grabbable == null)
		{
			return false;
		}
		if (Network_baseGrabbable != null)
		{
			return Network_baseGrabbable.GetEntity().GetObject<Grabbable>().CanAddToStack(grabbable);
		}
		if (grabbable.Network_baseGrabbable != null)
		{
			return CanAddToStack(grabbable.Network_baseGrabbable.GetEntity().GetObject<Grabbable>());
		}
		return _stackSlotsRemaining >= grabbable._stack.Count + 1;
	}

	[Server]
	public bool ServerIsBeingHeldByPlayer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean Grabbable::ServerIsBeingHeldByPlayer()' called when server was not active");
			return default(bool);
		}
		if (Network_baseGrabbable != null)
		{
			return Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerIsBeingHeldByPlayer();
		}
		return serverPlayerEntity.Exists();
	}

	[Server]
	public Entity ServerGetHoldingPlayer()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'Aggro.Core.Entity Grabbable::ServerGetHoldingPlayer()' called when server was not active");
			return default(Entity);
		}
		if (Network_baseGrabbable != null)
		{
			return Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerGetHoldingPlayer();
		}
		return serverPlayerEntity;
	}

	[Server]
	public bool ServerIsBeingHeldByHolder()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean Grabbable::ServerIsBeingHeldByHolder()' called when server was not active");
			return default(bool);
		}
		if (Network_baseGrabbable != null)
		{
			return Network_baseGrabbable.GetEntity().GetObject<Grabbable>().ServerIsBeingHeldByHolder();
		}
		return serverHolderEntity.Exists();
	}

	private void SetBaseGrabbable(Grabbable grabbable)
	{
		if ((object)grabbable == null)
		{
			Network_baseGrabbable = null;
		}
		else
		{
			Network_baseGrabbable = grabbable.netIdentity;
		}
	}

	protected override void OnUpdateSimulationEarly()
	{
		boxMpb.SetFloat("_selected", 0f);
		Renderer[] array = boxMeshRenderers;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetPropertyBlock(boxMpb);
		}
	}

	private void SetColliders(Entity e, bool colliders)
	{
		_colliders.Clear();
		e.GetObjects(_colliders);
		for (int i = 0; i < _colliders.Count; i++)
		{
			Collider collider = _colliders[i];
			if (!collider.isTrigger)
			{
				collider.enabled = colliders;
			}
		}
	}

	private bool TryGetHolder(Entity target, int id, out GrabbableHolder holder)
	{
		_holders.Clear();
		target.GetObjects(_holders);
		for (int i = 0; i < _holders.Count; i++)
		{
			GrabbableHolder grabbableHolder = _holders[i];
			if (grabbableHolder.id == id)
			{
				holder = grabbableHolder;
				return true;
			}
		}
		holder = null;
		return false;
	}

	public Grabbable()
	{
		InitSyncObject(_stack);
	}

	static Grabbable()
	{
		_colliders = new List<Collider>();
		_holders = new List<GrabbableHolder>();
		_entities = new List<Entity>();
		_boxSprings = new List<BoxSpring>();
		_boxStackedOns = new List<IBoxStackedOn>();
		_positions = new List<Vector3>();
		SELECTED = Shader.PropertyToID("_selected");
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcBreakStack(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", InvokeUserCode_RpcBreakStack__Entity__Entity__Entity__Entity__RoomType);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcQueueEvBrokeEntireStack()", InvokeUserCode_RpcQueueEvBrokeEntireStack);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcSetPlaceInPlayerGrabber(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity)", InvokeUserCode_RpcSetPlaceInPlayerGrabber__Entity__Entity__Entity__Entity);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcPlayerPrepareForStacked(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", InvokeUserCode_RpcPlayerPrepareForStacked__Entity__Entity__Entity__RoomType);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcPlaceInHolder(Aggro.Core.Entity,System.Int32,Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", InvokeUserCode_RpcPlaceInHolder__Entity__Int32__Entity__Entity__Entity__RoomType);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcRemoveFromHolder(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", InvokeUserCode_RpcRemoveFromHolder__Entity__Entity__Entity__RoomType);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcReadyFromInbound(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", InvokeUserCode_RpcReadyFromInbound__Entity__Entity__Entity__RoomType);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcReadyForOutboundTransition(Aggro.Core.Entity,System.Int32,Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity)", InvokeUserCode_RpcReadyForOutboundTransition__Entity__Int32__Entity__Entity__Entity);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcSetInteractable(System.Boolean)", InvokeUserCode_RpcSetInteractable__Boolean);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcPlayerDropped(Aggro.Core.Entity,Aggro.Core.Entity,Aggro.Core.Entity,RoomType)", InvokeUserCode_RpcPlayerDropped__Entity__Entity__Entity__RoomType);
		RemoteProcedureCalls.RegisterRpc(typeof(Grabbable), "System.Void Grabbable::RpcIgnoreCollision(Aggro.Core.Entity)", InvokeUserCode_RpcIgnoreCollision__Entity);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcBreakStack__Entity__Entity__Entity__Entity__RoomType(Entity e1, Entity e2, Entity e3, Entity e4, RoomType room)
	{
		if (!base.isServer)
		{
			SetPhysics(e1, room);
			SetPhysics(e2, room);
			SetPhysics(e3, room);
			SetPhysics(e4, room);
		}
	}

	protected static void InvokeUserCode_RpcBreakStack__Entity__Entity__Entity__Entity__RoomType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcBreakStack called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcBreakStack__Entity__Entity__Entity__Entity__RoomType(reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity(), GeneratedNetworkCode._Read_RoomType(reader));
		}
	}

	protected void UserCode_RpcQueueEvBrokeEntireStack()
	{
		base.entity.QueueEvent(default(EvBrokeEntireStack));
	}

	protected static void InvokeUserCode_RpcQueueEvBrokeEntireStack(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcQueueEvBrokeEntireStack called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcQueueEvBrokeEntireStack();
		}
	}

	protected void UserCode_RpcSetPlaceInPlayerGrabber__Entity__Entity__Entity__Entity(Entity player, Entity e2, Entity e3, Entity e4)
	{
		if (!base.isServer && player.TryGetObject<PlayerGrabber>(out var obj))
		{
			Transform grabbedContainer = obj.grabbedContainer;
			SetKinematic(base.entity, grabbedContainer, 0, interactable: false, colliders: false);
			SetKinematic(e2, grabbedContainer, 1, interactable: false, colliders: false);
			SetKinematic(e3, grabbedContainer, 2, interactable: false, colliders: false);
			SetKinematic(e4, grabbedContainer, 3, interactable: false, colliders: false);
			AudioManager.PlaySfx(pickUpSfx, base.entity.transform.position);
		}
	}

	protected static void InvokeUserCode_RpcSetPlaceInPlayerGrabber__Entity__Entity__Entity__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetPlaceInPlayerGrabber called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcSetPlaceInPlayerGrabber__Entity__Entity__Entity__Entity(reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity());
		}
	}

	protected void UserCode_RpcPlayerPrepareForStacked__Entity__Entity__Entity__RoomType(Entity e2, Entity e3, Entity e4, RoomType room)
	{
		if (!base.isServer)
		{
			SetPhysics(base.entity, room);
			SetPhysics(e2, room);
			SetPhysics(e3, room);
			SetPhysics(e4, room);
		}
	}

	protected static void InvokeUserCode_RpcPlayerPrepareForStacked__Entity__Entity__Entity__RoomType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayerPrepareForStacked called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcPlayerPrepareForStacked__Entity__Entity__Entity__RoomType(reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity(), GeneratedNetworkCode._Read_RoomType(reader));
		}
	}

	protected void UserCode_RpcPlaceInHolder__Entity__Int32__Entity__Entity__Entity__RoomType(Entity holderEntity, int holderId, Entity e2, Entity e3, Entity e4, RoomType room)
	{
		if (!base.isServer)
		{
			if (!TryGetHolder(holderEntity, holderId, out var holder))
			{
				Debug.LogError("Could not find holder!");
				return;
			}
			Transform container = holder.container;
			SetKinematic(base.entity, container, 0, interactable: true, colliders: true);
			SetKinematic(e2, container, 1, interactable: true, colliders: true);
			SetKinematic(e3, container, 2, interactable: true, colliders: true);
			SetKinematic(e4, container, 3, interactable: true, colliders: true);
		}
	}

	protected static void InvokeUserCode_RpcPlaceInHolder__Entity__Int32__Entity__Entity__Entity__RoomType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlaceInHolder called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcPlaceInHolder__Entity__Int32__Entity__Entity__Entity__RoomType(reader.ReadEntity(), reader.ReadVarInt(), reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity(), GeneratedNetworkCode._Read_RoomType(reader));
		}
	}

	protected void UserCode_RpcRemoveFromHolder__Entity__Entity__Entity__RoomType(Entity e2, Entity e3, Entity e4, RoomType room)
	{
		if (!base.isServer)
		{
			SetPhysics(base.entity, room);
			SetPhysics(e2, room);
			SetPhysics(e3, room);
			SetPhysics(e4, room);
		}
	}

	protected static void InvokeUserCode_RpcRemoveFromHolder__Entity__Entity__Entity__RoomType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcRemoveFromHolder called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcRemoveFromHolder__Entity__Entity__Entity__RoomType(reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity(), GeneratedNetworkCode._Read_RoomType(reader));
		}
	}

	protected void UserCode_RpcReadyFromInbound__Entity__Entity__Entity__RoomType(Entity e2, Entity e3, Entity e4, RoomType room)
	{
		if (!base.isServer)
		{
			_isInteractable = true;
			SetPhysics(e2, room);
			SetPhysics(e3, room);
			SetPhysics(e4, room);
		}
	}

	protected static void InvokeUserCode_RpcReadyFromInbound__Entity__Entity__Entity__RoomType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcReadyFromInbound called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcReadyFromInbound__Entity__Entity__Entity__RoomType(reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity(), GeneratedNetworkCode._Read_RoomType(reader));
		}
	}

	protected void UserCode_RpcReadyForOutboundTransition__Entity__Int32__Entity__Entity__Entity(Entity holderEntity, int holderId, Entity e2, Entity e3, Entity e4)
	{
		if (!base.isServer)
		{
			_isInteractable = false;
			if (!TryGetHolder(holderEntity, holderId, out var holder))
			{
				Debug.LogError("Could not find holder!");
				return;
			}
			Transform container = holder.container;
			SetKinematic(e2, container, 1, interactable: false, colliders: true);
			SetKinematic(e3, container, 2, interactable: false, colliders: true);
			SetKinematic(e4, container, 3, interactable: false, colliders: true);
		}
	}

	protected static void InvokeUserCode_RpcReadyForOutboundTransition__Entity__Int32__Entity__Entity__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcReadyForOutboundTransition called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcReadyForOutboundTransition__Entity__Int32__Entity__Entity__Entity(reader.ReadEntity(), reader.ReadVarInt(), reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity());
		}
	}

	protected void UserCode_RpcSetInteractable__Boolean(bool interactable)
	{
		if (!base.isServer)
		{
			_isInteractable = interactable;
		}
	}

	protected static void InvokeUserCode_RpcSetInteractable__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcSetInteractable called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcSetInteractable__Boolean(reader.ReadBool());
		}
	}

	protected void UserCode_RpcPlayerDropped__Entity__Entity__Entity__RoomType(Entity e2, Entity e3, Entity e4, RoomType room)
	{
		if (!base.isServer)
		{
			SetPhysics(base.entity, room);
			SetPhysics(e2, room);
			SetPhysics(e3, room);
			SetPhysics(e4, room);
		}
	}

	protected static void InvokeUserCode_RpcPlayerDropped__Entity__Entity__Entity__RoomType(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcPlayerDropped called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcPlayerDropped__Entity__Entity__Entity__RoomType(reader.ReadEntity(), reader.ReadEntity(), reader.ReadEntity(), GeneratedNetworkCode._Read_RoomType(reader));
		}
	}

	protected void UserCode_RpcIgnoreCollision__Entity(Entity ignore)
	{
		if (!base.isServer && ignore.Exists())
		{
			IgnoreCollision(ignore);
		}
	}

	protected static void InvokeUserCode_RpcIgnoreCollision__Entity(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcIgnoreCollision called on server.");
		}
		else
		{
			((Grabbable)obj).UserCode_RpcIgnoreCollision__Entity(reader.ReadEntity());
		}
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteVarInt(_stackLevel);
			writer.WriteVarInt(_stackSlotsRemaining);
			writer.WriteBool(_syncCanPutBoxOn);
			writer.WriteVarInt(syncStackIndex);
			writer.WriteEntity(syncHeldByPlayer);
			writer.WriteBool(syncHeldInHolder);
			writer.WriteNetworkIdentity(Network_baseGrabbable);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteVarInt(_stackLevel);
		}
		if ((syncVarDirtyBits & 2L) != 0L)
		{
			writer.WriteVarInt(_stackSlotsRemaining);
		}
		if ((syncVarDirtyBits & 4L) != 0L)
		{
			writer.WriteBool(_syncCanPutBoxOn);
		}
		if ((syncVarDirtyBits & 8L) != 0L)
		{
			writer.WriteVarInt(syncStackIndex);
		}
		if ((syncVarDirtyBits & 0x10L) != 0L)
		{
			writer.WriteEntity(syncHeldByPlayer);
		}
		if ((syncVarDirtyBits & 0x20L) != 0L)
		{
			writer.WriteBool(syncHeldInHolder);
		}
		if ((syncVarDirtyBits & 0x40L) != 0L)
		{
			writer.WriteNetworkIdentity(Network_baseGrabbable);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _stackLevel, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _stackSlotsRemaining, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref _syncCanPutBoxOn, null, reader.ReadBool());
			GeneratedSyncVarDeserialize(ref syncStackIndex, null, reader.ReadVarInt());
			GeneratedSyncVarDeserialize(ref syncHeldByPlayer, null, reader.ReadEntity());
			GeneratedSyncVarDeserialize(ref syncHeldInHolder, null, reader.ReadBool());
			GeneratedSyncVarDeserialize_NetworkIdentity(ref _baseGrabbable, null, reader, ref ____baseGrabbableNetId);
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _stackLevel, null, reader.ReadVarInt());
		}
		if ((num & 2L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _stackSlotsRemaining, null, reader.ReadVarInt());
		}
		if ((num & 4L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _syncCanPutBoxOn, null, reader.ReadBool());
		}
		if ((num & 8L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncStackIndex, null, reader.ReadVarInt());
		}
		if ((num & 0x10L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncHeldByPlayer, null, reader.ReadEntity());
		}
		if ((num & 0x20L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref syncHeldInHolder, null, reader.ReadBool());
		}
		if ((num & 0x40L) != 0L)
		{
			GeneratedSyncVarDeserialize_NetworkIdentity(ref _baseGrabbable, null, reader, ref ____baseGrabbableNetId);
		}
	}
}
