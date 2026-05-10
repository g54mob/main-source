using System;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	[Constructor("Construct")]
	public sealed class BodyBag : Item
	{
		public enum EBodyBagAnim
		{
			Drop = 0,
			DropMorgue = 1
		}

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private Animator _animator;

		[Inject(false)]
		private Renderer _meshRenderer;

		[Inject(false)]
		private Crime _crime;

		[SerializeField]
		private Transform _rootBone;

		[SerializeField]
		private float _animSpeed = 0.8f;

		private static readonly int _aSpeed = Animator.StringToHash("Speed");

		private Material _originalMat;

		private static readonly StringKey _invisibilityMatKey = "Invisibility";

		private LockToggle _crimeVisibility = new LockToggle();

		public DeadBodyData BodyData { get; private set; }

		[field: SerializeField]
		public AudioAsset AudioAsset { get; private set; }

		public WorkerChoreHub CurrentChore { get; set; }

		public EDeathChore CurrentChoreType { get; private set; }

		public bool IsHolding { get; private set; }

		public bool Initialized { get; set; } = true;

		public static event Action<DeadBodyData> BodyDropping;

		public static event Action<BodyBag, Customer> WrappingInBodyBag;

		private void Construct([InjectScope(EGetScope.Children)] Renderer meshRenderer)
		{
			_originalMat = meshRenderer.sharedMaterial;
			meshRenderer.sharedMaterial = _originalMat;
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_crimeVisibility.Add(_crime);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (IsHolding)
			{
				AnimHold();
			}
			Crime crime = _crime;
			crime.WasSeen = (Action)Delegate.Combine(crime.WasSeen, new Action(OnCrimeSeen));
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			Crime crime = _crime;
			crime.WasSeen = (Action)Delegate.Remove(crime.WasSeen, new Action(OnCrimeSeen));
		}

		private void OnCrimeSeen()
		{
			base.WasSeen?.Invoke();
		}

		private void Update()
		{
			if ((bool)base.CurrentHolder)
			{
				_animator.SetFloat(_aSpeed, base.CurrentHolder.Movement.Velocity.magnitude * 0.5f * _animSpeed);
			}
			else
			{
				_animator.SetFloat(_aSpeed, 0f);
			}
		}

		protected override void OnVisible()
		{
			base.OnVisible();
			_meshRenderer.sharedMaterial = _originalMat;
			_crimeVisibility.Unlock();
		}

		protected override void OnInvisible()
		{
			base.OnInvisible();
			Material sharedMaterial = CTSSingleton<Materials>.Instance.GetSharedMaterial(_invisibilityMatKey);
			_meshRenderer.sharedMaterial = sharedMaterial;
			_crimeVisibility.Lock();
		}

		public void AnimIdleGround()
		{
			IsHolding = false;
			_animator.CrossFadeInFixedTime("IdleGround", 0.2f);
		}

		private void AnimHold()
		{
			IsHolding = true;
			_animator.Play("Hold");
		}

		public void AnimDrop(EBodyBagAnim value = EBodyBagAnim.Drop)
		{
			BodyBag.BodyDropping?.Invoke(BodyData);
			IsHolding = false;
			_animator.CrossFadeInFixedTime((value == EBodyBagAnim.Drop) ? "Drop" : "DropMorgue", 0.2f);
		}

		public void AnimDropDrip()
		{
			BodyBag.BodyDropping?.Invoke(BodyData);
			IsHolding = false;
			_animator.CrossFadeInFixedTime("TheDipDrop", 0.2f);
		}

		public void AnimPickup()
		{
			_animator.CrossFadeInFixedTime("Pickup", 0.2f);
		}

		public void SetBodyData(Customer customer)
		{
			BodyBag.WrappingInBodyBag?.Invoke(this, customer);
			BodyData = new DeadBodyData(customer);
		}

		public void SetBodyData(DeadBodyData bodyData)
		{
			BodyData = bodyData;
		}

		public void AlignWithBody(Customer body)
		{
			Vector3 position = body.transform.position;
			Vector3 position2;
			Vector3 vector;
			if (body.SkeletonData.TryGetBone(EBone.HeadTop, out var boneTransform))
			{
				vector = (boneTransform.position - position).FlattenY();
				position2 = vector * 0.5f;
				vector = vector.normalized;
			}
			else
			{
				vector = body.transform.forward;
				position2 = position;
			}
			position2 += position;
			Quaternion rotation = Quaternion.LookRotation(vector, Vector3.up);
			base.transform.SetPositionAndRotation(position2, rotation);
			base.RoomObject.CurrentRoom = body.RoomObject.CurrentRoom;
		}

		public void CreateBodyBagCleaningChore(bool allowMorgue)
		{
			ClearChore();
			CurrentChoreType = (allowMorgue ? EDeathChore.BodyBagMorgue : EDeathChore.BodyBagSewer);
			CurrentChore = new WorkerChoreHubDiscardBody(new ActionHubDisposeBody(this, allowMorgue));
			MonoSingleton<ChoreList>.Instance.AddToList(CurrentChore);
		}

		public void SetChore(WorkerChoreHub chore)
		{
			if (chore != CurrentChore)
			{
				ClearChore();
				CurrentChore = chore;
			}
		}

		public void ClearChore()
		{
			CurrentChore?.DestroyChore();
			CurrentChore = null;
		}

		protected override void OnDropped()
		{
			base.OnDropped();
			AnimIdleGround();
			base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles.FlattenX());
		}

		protected override void OnGrab(Agent p_parent)
		{
			base.OnGrab(p_parent);
			AnimHold();
		}

		public Vector3 GetRootBone()
		{
			return _rootBone.position;
		}

		protected override void OnPulledFromPool()
		{
			base.OnPulledFromPool();
			StaticObjectSet<BodyBag>.Add(this);
		}

		protected override void OnPushedToPool()
		{
			base.OnPushedToPool();
			ClearChore();
			AnimIdleGround();
			StaticObjectSet<BodyBag>.Remove(this);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			ClearChore();
			StaticObjectSet<BodyBag>.Remove(this);
		}

		public static NavMeshQueryFilter GetAgentQueryFilter()
		{
			NavMeshQueryFilter baseQueryFilter = AgentsPathfinding.BaseQueryFilter;
			baseQueryFilter.SetAreaCost(3, 100f);
			baseQueryFilter.SetAreaCost(5, 100f);
			baseQueryFilter.SetAreaCost(7, 50f);
			return baseQueryFilter;
		}
	}
}
