using System;
using System.Collections;
using DV.Customization.Gadgets;
using DV.Interaction;
using DV.Items;
using DV.Utils;
using UnityEngine;

public class TeleGrab : MonoBehaviour
{
	public struct TelegrabData
	{
		public static readonly TelegrabData Empty = new TelegrabData(null, null, null, default(RaycastHitDV));

		public Telegrabbable PointedTelegrabbable { get; }

		public Telegrabbable PointedTeleinteractable { get; }

		public GameObject PointedGameObject { get; }

		public RaycastHitDV SphereCastHit { get; }

		public TelegrabData(Telegrabbable pointedTelegrabbable, Telegrabbable pointedTeleinteractable, GameObject pointedGameObject, RaycastHitDV sphereCastHit)
		{
			PointedTelegrabbable = pointedTelegrabbable;
			PointedTeleinteractable = pointedTeleinteractable;
			PointedGameObject = pointedGameObject;
			SphereCastHit = sphereCastHit;
		}
	}

	private enum State
	{
		Idle = 0,
		Scanning = 1,
		TryAttract = 2,
		Attracting = 3,
		Holding = 4
	}

	public float maxDistance = 3f;

	public float grabDistance = 0.05f;

	public float sphereCastRadius = 0.015f;

	public float attractMaxDuration = 0.25f;

	public float attractMinDuration = 0.15f;

	public LayerMask layers;

	public bool scanButtonPressed;

	public bool attractButtonPressed;

	public float telegrabPointerScale = 0.03f;

	[NonSerialized]
	public GameObject telegrabBeam;

	private RaycastHit[] sphereHits = new RaycastHit[16];

	private Coroutine finishAttractCoro;

	private bool isRight;

	private float currentAttractDuration;

	private State state;

	private Telegrabbable attractingObject;

	private Transform pipaTransform;

	private float elapsedAttractTime;

	public TelegrabData CurrentTelegrabData { get; private set; } = TelegrabData.Empty;

	public event Action<Telegrabbable> TeleGrabbed;

	private void Start()
	{
		pipaTransform = PipaUtils.PipaTransform(base.transform.parent.gameObject);
	}

	private void OnDisable()
	{
		StopAllCoroutines();
		finishAttractCoro = null;
	}

	public void SetHandiness(bool isRight)
	{
		this.isRight = isRight;
	}

	private void Update()
	{
		switch (state)
		{
		case State.Idle:
			if (scanButtonPressed)
			{
				state = State.Scanning;
				ToggleTelegrabCursor(on: true);
			}
			break;
		case State.Scanning:
			if (!scanButtonPressed)
			{
				state = State.TryAttract;
			}
			else
			{
				UpdateTelegrabData();
			}
			break;
		case State.TryAttract:
		{
			UpdateTelegrabData();
			Telegrabbable pointedTelegrabbable = CurrentTelegrabData.PointedTelegrabbable;
			Telegrabbable pointedTeleinteractable = CurrentTelegrabData.PointedTeleinteractable;
			if ((bool)pointedTelegrabbable || (bool)pointedTeleinteractable)
			{
				if ((bool)pointedTelegrabbable)
				{
					ForceUnsnapPointedObject(pointedTelegrabbable);
					pointedTelegrabbable.SetHighlight(on: false);
					SetAttractingItemValues(pointedTelegrabbable);
					state = State.Attracting;
				}
				else
				{
					state = State.Idle;
				}
				ClearTelegrabData();
			}
			else
			{
				state = State.Idle;
			}
			ToggleTelegrabCursor(on: false);
			break;
		}
		case State.Attracting:
			if (AttractObject())
			{
				GrabAttractingObject();
				state = State.Holding;
			}
			break;
		case State.Holding:
			break;
		}
	}

	private void ForceUnsnapPointedObject(Telegrabbable telegrabbable)
	{
		SnappableItem component = telegrabbable.GetComponent<SnappableItem>();
		if (!(component == null) && !(component.SnappedTo == null))
		{
			component.SnappedTo.UnsnapItem(forced: true);
		}
	}

	private void ToggleTelegrabCursor(bool on)
	{
		if ((bool)telegrabBeam)
		{
			telegrabBeam.SetActive(on);
		}
	}

	private void ClearTelegrabData()
	{
		Telegrabbable pointedTelegrabbable = CurrentTelegrabData.PointedTelegrabbable;
		Telegrabbable pointedTeleinteractable = CurrentTelegrabData.PointedTeleinteractable;
		if ((bool)pointedTeleinteractable)
		{
			pointedTeleinteractable.SetHighlight(on: false);
		}
		if ((bool)pointedTelegrabbable)
		{
			pointedTelegrabbable.SetHighlight(on: false);
		}
		CurrentTelegrabData = TelegrabData.Empty;
	}

	private void UpdateTelegrabData()
	{
		if (PhysicsQueryBuilder.SphereCast(base.transform.position, sphereCastRadius, base.transform.forward, maxDistance, layers, QueryTriggerInteraction.Collide).Where(delegate(RaycastHitDV h)
		{
			if (h.collider.TryGetComponent<GrabberRaycastPassThrough>(out var _))
			{
				return false;
			}
			Telegrabbable telegrabbable4;
			Telegrabbable teleinteractable2;
			return (!h.collider.isTrigger || TryPointObject(h.rigidbody, h.collider, out telegrabbable4, out teleinteractable2)) ? true : false;
		}).FilterGadgetDepthHack()
			.TryGetFirst(out var hit) && TryPointObject(hit.rigidbody, hit.collider, out var telegrabbable, out var teleinteractable))
		{
			Telegrabbable telegrabbable2 = telegrabbable;
			Telegrabbable telegrabbable3 = teleinteractable;
			GameObject pointedGameObject = ((telegrabbable3 != null) ? telegrabbable3.gameObject : telegrabbable.gameObject);
			if (CurrentTelegrabData.PointedTelegrabbable != null && (telegrabbable3 != null || CurrentTelegrabData.PointedTelegrabbable != telegrabbable2))
			{
				CurrentTelegrabData.PointedTelegrabbable.SetHighlight(on: false);
			}
			if (CurrentTelegrabData.PointedTeleinteractable != null && CurrentTelegrabData.PointedTeleinteractable != telegrabbable3)
			{
				CurrentTelegrabData.PointedTeleinteractable.SetHighlight(on: false);
			}
			if (telegrabbable3 != null)
			{
				telegrabbable3.SetHighlight(on: true);
			}
			else if (telegrabbable2 != null)
			{
				telegrabbable2.SetHighlight(on: true);
			}
			CurrentTelegrabData = new TelegrabData(telegrabbable2, telegrabbable3, pointedGameObject, hit);
		}
		else
		{
			ClearTelegrabData();
		}
	}

	private void SetAttractingItemValues(Telegrabbable telegrabbable)
	{
		if (telegrabbable != null)
		{
			telegrabbable = ((telegrabbable.RedirectTo != null) ? telegrabbable.RedirectTo : telegrabbable);
			attractingObject = telegrabbable;
			attractingObject.SetState_internal(isBeingTelegrabbed: true);
			float sqrMagnitude = (attractingObject.transform.position - base.transform.position).sqrMagnitude;
			currentAttractDuration = Mathf.Clamp(attractMaxDuration * (sqrMagnitude / (maxDistance * maxDistance)), attractMinDuration, attractMaxDuration);
		}
		else
		{
			attractingObject.SetState_internal(isBeingTelegrabbed: false);
			attractingObject = null;
			elapsedAttractTime = 0f;
		}
	}

	private bool AttractObject()
	{
		Transform obj = attractingObject.transform;
		var (b, b2) = GetTargetValues(attractingObject);
		elapsedAttractTime += Time.deltaTime;
		float num = Ease(0f, 1f, elapsedAttractTime / currentAttractDuration);
		obj.rotation = Quaternion.Slerp(obj.rotation, b2, num);
		obj.position = Vector3.Lerp(obj.position, b, num);
		return num >= 0.99f;
	}

	private (Vector3 targetPosition, Quaternion targetRotation) GetTargetValues(Telegrabbable obj)
	{
		Transform transform = obj.transform;
		Transform anchor = obj.GetAnchor(isRight);
		Vector3 item;
		Quaternion item2;
		if (anchor != null)
		{
			(item, item2) = TransformUtils.CalculateAlignmentTargets(transform, pipaTransform, anchor);
		}
		else
		{
			item2 = ((!obj.ShouldRotateToController()) ? transform.rotation : pipaTransform.rotation);
			item = pipaTransform.position;
		}
		return (targetPosition: item, targetRotation: item2);
	}

	private float Ease(float from, float to, float t)
	{
		t = Mathf.Clamp01(t);
		if (t >= 1f)
		{
			return to;
		}
		if (t <= 0f)
		{
			return from;
		}
		float num = to - from;
		return from + num * t * t * t * t;
	}

	private IEnumerator FinishAttractCoro(bool success)
	{
		Telegrabbable obj = attractingObject;
		SetAttractingItemValues(null);
		if (success)
		{
			yield return WaitFor.FixedUpdate;
			var (position, rotation) = GetTargetValues(obj);
			obj.transform.SetPositionAndRotation(position, rotation);
			this.TeleGrabbed?.Invoke(obj);
		}
		finishAttractCoro = null;
	}

	private void GrabAttractingObject()
	{
		Transform transform = attractingObject.transform;
		Transform anchor = attractingObject.GetAnchor(isRight);
		var (position, rotation) = GetTargetValues(attractingObject);
		if ((bool)anchor)
		{
			PipaUtils.AlignTransformToPipa(transform, pipaTransform, anchor);
		}
		else
		{
			transform.SetPositionAndRotation(position, rotation);
		}
		if (finishAttractCoro != null)
		{
			StopCoroutine(finishAttractCoro);
		}
		finishAttractCoro = StartCoroutine(FinishAttractCoro(success: true));
	}

	private bool TryPointObject(Rigidbody rb, Collider col, out Telegrabbable telegrabbable, out Telegrabbable teleinteractable)
	{
		telegrabbable = null;
		teleinteractable = null;
		Telegrabbable telegrabbable2 = ((rb != null) ? rb.GetComponent<Telegrabbable>() : null);
		if (!telegrabbable2)
		{
			telegrabbable2 = ((col != null) ? col.GetComponentInParent<Telegrabbable>() : null);
		}
		if (telegrabbable2 == null)
		{
			return false;
		}
		Telegrabbable telegrabbable3 = (telegrabbable2.RemoteInteractionOnly ? telegrabbable2 : null);
		Transform parent = telegrabbable2.transform.parent;
		if (parent != null)
		{
			Telegrabbable componentInParent = parent.GetComponentInParent<Telegrabbable>();
			if ((bool)componentInParent)
			{
				telegrabbable2 = componentInParent;
			}
		}
		Vector3 position = base.transform.position;
		int num;
		if (!telegrabbable2.RemoteInteractionOnly)
		{
			num = (telegrabbable2.IsTelegrabAllowed_internal(position) ? 1 : 0);
			if (num != 0)
			{
				telegrabbable = telegrabbable2;
			}
		}
		else
		{
			num = 0;
		}
		bool flag = telegrabbable3 != null && telegrabbable3.IsTelegrabAllowed_internal(position);
		if (flag)
		{
			teleinteractable = telegrabbable3;
		}
		return (byte)((uint)num | (flag ? 1u : 0u)) != 0;
	}

	public void ChangeStateToHoldAndTurnOffVisuals()
	{
		if ((bool)attractingObject)
		{
			SetAttractingItemValues(null);
		}
		ClearTelegrabData();
		state = State.Holding;
		ToggleTelegrabCursor(on: false);
	}

	public void ChangeStateToIdleAndTurnOffVisuals()
	{
		state = State.Idle;
		ClearTelegrabData();
		ToggleTelegrabCursor(on: false);
	}

	public void AbortTelegrab()
	{
		ChangeStateToIdleAndTurnOffVisuals();
		if (attractingObject != null)
		{
			if (finishAttractCoro != null)
			{
				StopCoroutine(finishAttractCoro);
			}
			finishAttractCoro = StartCoroutine(FinishAttractCoro(success: false));
		}
	}

	private void AddDebug()
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		gameObject.GetComponent<Collider>().enabled = false;
		gameObject.transform.SetParent(base.transform, worldPositionStays: false);
		gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.4f);
		gameObject.transform.localPosition = new Vector3(0f, 0f, gameObject.transform.localScale.z / 2f);
	}
}
