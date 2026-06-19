using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShroomlingCreature : CreatureBehaviour
{
	[CompilerGenerated]
	private sealed class _003CDoHitAnimation_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ShroomlingCreature _003C_003E4__this;

		private float _003Cduration_003E5__2;

		private float _003Cheight_003E5__3;

		private float _003Celapsed_003E5__4;

		private Vector3 _003CstartPos_003E5__5;

		private float _003CfinalAngle_003E5__6;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDoHitAnimation_003Ed__28(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[SerializeField]
	private DamageableCreature damageable;

	[SerializeField]
	private ItemType _dropItemType;

	[SerializeField]
	private float _dropRadius;

	[SerializeField]
	private float _itemDropDuration;

	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private List<Behaviour> _disableOnDeath;

	public int DropCount;

	public Transform GraphicTransform;

	public SpriteRenderer BodySprite;

	private Coroutine HitAnimationCoroutine;

	public float HitAnimationDuration;

	public float HitAnimationHeight;

	public float HitAnimationAngle;

	[SerializeField]
	private Rigidbody2D _rigidBody;

	[SerializeField]
	private float _idleDurationMin;

	[SerializeField]
	private float _idleDurationMax;

	private float _idleDuration;

	private float _idleTimer;

	private Vector2 _targetLocalPosition;

	private const float _targetPositionProximityGoal = 0.5f;

	[SerializeField]
	private float _movementForce;

	private bool _isMoving;

	private Vector2 _lastPosition;

	private bool Dead;

	public Action AnnounceDropItems;

	public Vector2 GetWanderPosition => default(Vector2);

	protected override void OnInitiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnHit(bool finished)
	{
	}

	[IteratorStateMachine(typeof(_003CDoHitAnimation_003Ed__28))]
	private IEnumerator DoHitAnimation()
	{
		return null;
	}

	public void Kill()
	{
	}

	public void CreateItem(ItemType itemType)
	{
	}

	public void AddDropCount(int count)
	{
	}

	private void FixedUpdate()
	{
	}

	public void CancelMovement()
	{
	}
}
