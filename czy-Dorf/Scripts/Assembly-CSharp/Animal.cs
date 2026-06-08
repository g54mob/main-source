using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Element))]
public class Animal : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<AnimalPathPoint, bool> _003C_003E9__17_0;

		public static Func<AnimalPathPoint, bool> _003C_003E9__17_1;

		internal bool _003CSelectRandomPathPoint_003Eb__17_0(AnimalPathPoint x)
		{
			return x.OccupiedBy == null;
		}

		internal bool _003CSelectRandomPathPoint_003Eb__17_1(AnimalPathPoint x)
		{
			return x.OccupiedBy == null;
		}
	}

	private sealed class _003CIdle_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Animal _003C_003E4__this;

		public int animationCount;

		private int _003CcurrentAnimationIndex_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CIdle_003Ed__18(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			Animal animal = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
			{
				_003C_003E1__state = -1;
				animal.state = AnimalState.Idle;
				Animator animator = animal.Animator;
				if (animal.element.ElementVisual.GameObject.activeInHierarchy)
				{
					animator.SetBool("Moving", value: false);
				}
				_003CcurrentAnimationIndex_003E5__2 = 0;
				break;
			}
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (animal.state == AnimalState.Idle && (animationCount == -1 || _003CcurrentAnimationIndex_003E5__2 < animationCount))
			{
				Animator animator = animal.Animator;
				AnimalAnimationTrigger animalAnimationTrigger = Randomizer.SelectWeightedRandom(animal.idleAnimationTriggers);
				if (animal.element.ElementVisual.GameObject.activeInHierarchy)
				{
					animator.SetInteger("IdleIndex", animalAnimationTrigger.triggerIndex);
					animator.SetTrigger("BeginIdleAnimation");
				}
				_003CcurrentAnimationIndex_003E5__2++;
				_003C_003E2__current = new WaitForSeconds(animalAnimationTrigger.clipDuration);
				_003C_003E1__state = 1;
				return true;
			}
			if (animationCount != -1)
			{
				animal.StartCoroutine(animal.Move());
			}
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
			throw new NotSupportedException();
		}
	}

	private sealed class _003CMove_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Animal _003C_003E4__this;

		private Vector3 _003CtargetPosition_003E5__2;

		private float _003Cangle_003E5__3;

		private Quaternion _003CtargetRotation_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CMove_003Ed__19(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			Animal animal = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				if (!animal.nextPathPoint.hidingSpot)
				{
					animal.element.ElementVisual.GameObject.SetActive(value: true);
				}
				animal.state = AnimalState.Moving;
				animal.currentPathPoint.OccupyBy(null);
				if (animal.element.ElementVisual.GameObject.activeInHierarchy)
				{
					animal.Animator.SetBool("Moving", value: true);
				}
				_003CtargetPosition_003E5__2 = animal.nextPathPoint.transform.position;
				if (_003CtargetPosition_003E5__2 != animal.currentPathPoint.transform.position)
				{
					Quaternion rotation = Quaternion.LookRotation((_003CtargetPosition_003E5__2 - animal.currentPathPoint.transform.position).normalized, Vector3.up);
					if (!animal.doesTurnSlowly)
					{
						animal.transform.rotation = rotation;
					}
				}
				if (!animal.doesTurnSlowly)
				{
					break;
				}
				animal.Animator.SetBool("Turning", value: true);
				_003Cangle_003E5__3 = Vector3.SignedAngle(animal.transform.forward, _003CtargetPosition_003E5__2 - animal.currentPathPoint.transform.position, Vector3.up);
				_003CtargetRotation_003E5__4 = Quaternion.LookRotation((_003CtargetPosition_003E5__2 - animal.currentPathPoint.transform.position).normalized, Vector3.up);
				goto IL_0230;
			case 1:
				_003C_003E1__state = -1;
				goto IL_0230;
			case 2:
				{
					_003C_003E1__state = -1;
					break;
				}
				IL_0230:
				if (Mathf.Abs(_003Cangle_003E5__3) > 0.5f)
				{
					Debug.Log($"turning, angle: {_003Cangle_003E5__3}");
					animal.transform.rotation = Quaternion.RotateTowards(animal.transform.rotation, _003CtargetRotation_003E5__4, animal.turnSpeed * Time.deltaTime);
					_003Cangle_003E5__3 = Vector3.SignedAngle(animal.transform.forward, _003CtargetPosition_003E5__2 - animal.currentPathPoint.transform.position, Vector3.up);
					animal.Animator.SetFloat("TurnAngle", _003Cangle_003E5__3);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				animal.Animator.SetBool("Turning", value: false);
				_003CtargetRotation_003E5__4 = default(Quaternion);
				break;
			}
			if (Vector3.Distance(animal.transform.position, animal.nextPathPoint.transform.position) > 0.01f)
			{
				animal.MoveTowards(animal.nextPathPoint.transform.position);
				_003C_003E2__current = null;
				_003C_003E1__state = 2;
				return true;
			}
			animal.currentPathPoint = animal.nextPathPoint;
			animal.nextPathPoint = animal.SelectRandomPathPoint();
			animal.nextPathPoint.OccupyBy(animal);
			if (animal.currentPathPoint.hidingSpot)
			{
				animal.StartCoroutine(animal.Hide(UnityEngine.Random.Range(animal.hidingTime.x, animal.hidingTime.y)));
			}
			else
			{
				animal.StartCoroutine(animal.Idle(UnityEngine.Random.Range(animal.consecutiveIdleAnimationCount.x, animal.consecutiveIdleAnimationCount.y)));
			}
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
			throw new NotSupportedException();
		}
	}

	private sealed class _003CHide_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Animal _003C_003E4__this;

		public float duration;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CHide_003Ed__20(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			Animal animal = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				animal.element.ElementVisual.GameObject.SetActive(value: false);
				_003C_003E2__current = new WaitForSeconds(duration);
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				animal.StartCoroutine(animal.Move());
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private List<AnimalPathPoint> pathPoints;

	[SerializeField]
	private Vector2 hidingTime = new Vector2(5f, 30f);

	[FormerlySerializedAs("idleAnimationCount")]
	[SerializeField]
	private Vector2Int consecutiveIdleAnimationCount = new Vector2Int(1, 4);

	[SerializeField]
	private float Speed;

	[SerializeField]
	private bool doesTurnSlowly;

	[SerializeField]
	private float turnSpeed = 45f;

	[SerializeField]
	private List<AnimalAnimationTrigger> idleAnimationTriggers;

	private AnimalPathPoint currentPathPoint;

	private AnimalPathPoint nextPathPoint;

	private Element element;

	private Tile questTile;

	private AnimalState state;

	private Animator Animator => GetComponentInChildren<ElementVisual>()?.GetComponentInChildren<Animator>(includeInactive: true);

	private void OnEnable()
	{
		questTile = GetComponentInParent<Tile>();
		element = GetComponent<Element>();
		element.Randomize();
		if (currentPathPoint == null)
		{
			currentPathPoint = SelectRandomPathPoint(questTile.Seed);
			currentPathPoint.OccupyBy(this);
			base.transform.position = currentPathPoint.transform.position;
			element.ElementVisual.GameObject.SetActive(!currentPathPoint.hidingSpot);
		}
		if (nextPathPoint == null)
		{
			nextPathPoint = SelectRandomPathPoint();
		}
		nextPathPoint.OccupyBy(this);
		if ((nextPathPoint.transform.position - currentPathPoint.transform.position).magnitude > 0f)
		{
			base.transform.rotation = Quaternion.LookRotation((nextPathPoint.transform.position - currentPathPoint.transform.position).normalized, Vector3.up);
		}
	}

	private void StartMoving(Tile placedTile)
	{
		state = AnimalState.Moving;
		element.ElementVisual.GameObject.SetActive(value: true);
		StartCoroutine(Move());
		questTile.OnPlaced -= StartMoving;
		ActivateTrail(showTrail: true);
	}

	private void Start()
	{
		if (questTile.State == TileState.placed)
		{
			StartMoving(questTile);
			return;
		}
		StartCoroutine(Idle(-1));
		questTile.OnPlaced += StartMoving;
	}

	private AnimalPathPoint SelectRandomPathPoint(int seed = -1)
	{
		if (seed != -1)
		{
			UnityEngine.Random.InitState(questTile.Seed);
		}
		List<AnimalPathPoint> list = (((bool)currentPathPoint && currentPathPoint.hasRestrictedNeighborPathPoints) ? new List<AnimalPathPoint>(currentPathPoint.neighborPathPoints) : new List<AnimalPathPoint>(pathPoints));
		if (Enumerable.Count(list, (AnimalPathPoint x) => x.OccupiedBy == null) > 0)
		{
			list = Enumerable.ToList(Enumerable.Where(list, (AnimalPathPoint x) => x.OccupiedBy == null));
		}
		AnimalPathPoint result = list[UnityEngine.Random.Range(0, list.Count)];
		Randomizer.RandomizeSeed();
		return result;
	}

	private IEnumerator Idle(int animationCount)
	{
		return new _003CIdle_003Ed__18(0)
		{
			_003C_003E4__this = this,
			animationCount = animationCount
		};
	}

	private IEnumerator Move()
	{
		return new _003CMove_003Ed__19(0)
		{
			_003C_003E4__this = this
		};
	}

	private IEnumerator Hide(float duration)
	{
		return new _003CHide_003Ed__20(0)
		{
			_003C_003E4__this = this,
			duration = duration
		};
	}

	protected void MoveTowards(Vector3 nextPathPointPosition)
	{
		if (!(Vector3.Distance(base.transform.position, nextPathPointPosition) < 0.01f))
		{
			float maxDistanceDelta = Speed * Time.deltaTime;
			Vector3 position = Vector3.MoveTowards(base.transform.position, nextPathPointPosition, maxDistanceDelta);
			base.transform.position = position;
		}
	}

	public void ActivateTrail(bool showTrail)
	{
		TrailRenderer trailRenderer = GetComponentInChildren<ElementVisual>()?.GetComponentInChildren<TrailRenderer>(includeInactive: true);
		if (trailRenderer != null)
		{
			trailRenderer.gameObject.SetActive(showTrail);
		}
	}

	public void UpdateAnimationState()
	{
		if (!element)
		{
			element = GetComponent<Element>();
		}
		if ((bool)Animator)
		{
			Animator.SetBool("Moving", state == AnimalState.Moving);
		}
		ActivateTrail(state == AnimalState.Moving);
		if ((bool)currentPathPoint && currentPathPoint.hidingSpot)
		{
			element.ElementVisual.GameObject.SetActive(value: false);
		}
	}
}
