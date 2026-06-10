using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

public class Bobber : MonoBehaviour
{
	[Header("Bobber Events")]
	public UnityEvent onFishBite;

	[Header("Object References")]
	[Tooltip("The child object containing the bobber's sprite/model.")]
	[SerializeField]
	private Transform bobberVisuals;

	[Tooltip("The child object containing the shadow sprite.")]
	[SerializeField]
	private Transform shadowVisuals;

	[Tooltip("The SpriteRenderers to fade out. Assign in editor to save performance.")]
	[SerializeField]
	private SpriteRenderer[] fadeRenderers;

	[Header("Casting Animation")]
	[Tooltip("How long the cast animation takes.")]
	public float castDuration = 1f;

	[Tooltip("The starting position offset relative to the final landing spot. (e.g., (0, -5, 0) to start from below)")]
	public Vector3 castStartOffset = new Vector3(0f, -5f, 0f);

	[Tooltip("The curve controlling the bobber's main travel speed (start to end).")]
	public AnimationCurve castCurve;

	[Header("Arc & Shadow (2.5D Effect)")]
	[Tooltip("The max height of the 'arc' the bobber visual travels, relative to its base position.")]
	public float arcMaxHeight = 3f;

	[Tooltip("An animation curve for the 'arc' (should be 0 -> 1 -> 0).")]
	public AnimationCurve arcHeightCurve;

	[Tooltip("An animation curve for the shadow's scale (should be 0.1 -> 1).")]
	public AnimationCurve shadowScaleCurve;

	[Tooltip("How fast the bobber spins during the cast (degrees per second).")]
	public float rotationSpeed = 720f;

	[Tooltip("The axis around which the bobber spins during the cast.")]
	public Vector3 rotationAxis = new Vector3(0f, 1f, 1f);

	[Header("Bobbing Animation")]
	[Tooltip("How high (in units) the bobber bobs up and down in the water.")]
	public float bobHeight = 0.1f;

	[Tooltip("How fast the bobber bobs (cycles per second).")]
	public float bobSpeed = 1.5f;

	private Vector3 endPosition;

	private Vector3 initialShadowScale;

	private bool isBiteRegistered;

	private Coroutine bobbingCoroutine;

	[SerializeField]
	private Transform extraFloatPrefab;

	[SerializeField]
	private Transform extraFloatRoot;

	[SerializeField]
	private float sideOffset = 0.35f;

	[SerializeField]
	private float checkRadius = 0.02f;

	private readonly List<Transform> extraFloats = new List<Transform>();

	private bool isVisualOnly;

	private bool isReelingOut;

	public void SetAsVisualOnly()
	{
		isVisualOnly = true;
		UnityEngine.Object.Destroy(base.gameObject, 20f);
	}

	public void TriggerVisualBite()
	{
		if (bobbingCoroutine != null)
		{
			StopCoroutine(bobbingCoroutine);
		}
		bobbingCoroutine = null;
		StartCoroutine(BiteBobbingEffect());
	}

	private void Start()
	{
		if (bobberVisuals == null || shadowVisuals == null)
		{
			Debug.LogError("Bobber visuals or shadow visuals are not assigned!");
			return;
		}
		endPosition = base.transform.position;
		base.transform.position = endPosition + castStartOffset;
		initialShadowScale = shadowVisuals.localScale;
		StartCoroutine(CastBobber());
	}

	private IEnumerator CastBobber()
	{
		Vector3 currentStartPosition = base.transform.position;
		float elapsedTime = 0f;
		bobberVisuals.localPosition = Vector3.zero;
		bobberVisuals.localRotation = Quaternion.identity;
		shadowVisuals.localScale = initialShadowScale * shadowScaleCurve.Evaluate(0f);
		while (elapsedTime < castDuration)
		{
			elapsedTime += Time.deltaTime;
			float time = Mathf.Clamp01(elapsedTime / castDuration);
			float t = castCurve.Evaluate(time);
			base.transform.position = Vector3.Lerp(currentStartPosition, endPosition, t);
			float num = arcHeightCurve.Evaluate(time);
			bobberVisuals.localPosition = new Vector3(0f, num * arcMaxHeight, 0f);
			float t2 = shadowScaleCurve.Evaluate(time);
			shadowVisuals.localScale = Vector3.Lerp(initialShadowScale * 0.1f, initialShadowScale, t2);
			float angle = rotationSpeed * Time.deltaTime;
			bobberVisuals.Rotate(rotationAxis, angle, Space.Self);
			yield return null;
		}
		base.transform.position = endPosition;
		bobberVisuals.localPosition = Vector3.zero;
		bobberVisuals.rotation = Quaternion.Euler(0f, base.transform.eulerAngles.y, 0f);
		shadowVisuals.localScale = initialShadowScale;
		VFXPooler.Instance.PlayEffect("WaterRipple", base.transform.position);
		bobbingCoroutine = StartCoroutine(BobbingEffect());
		if (!isVisualOnly)
		{
			StartCoroutine(WaitForBite());
		}
	}

	public void SetExtraFloatCount(int count)
	{
		for (int i = 0; i < extraFloats.Count; i++)
		{
			if (extraFloats[i] != null)
			{
				UnityEngine.Object.Destroy(extraFloats[i].gameObject);
			}
		}
		extraFloats.Clear();
		if (!(extraFloatPrefab == null) && !(extraFloatRoot == null))
		{
			for (int j = 0; j < count; j++)
			{
				Transform transform = UnityEngine.Object.Instantiate(extraFloatPrefab, extraFloatRoot);
				float x = ((j == 0) ? (-0.15f) : 0.15f);
				transform.localPosition = new Vector3(x, 0f, 0f);
				SetFloatDim(transform, dim: true);
				extraFloats.Add(transform);
			}
		}
	}

	public void SetExtraFloatOffsets(List<Vector3> localOffsets)
	{
		for (int i = 0; i < extraFloats.Count; i++)
		{
			if (extraFloats[i] != null)
			{
				UnityEngine.Object.Destroy(extraFloats[i].gameObject);
			}
		}
		extraFloats.Clear();
		if (extraFloatPrefab == null || extraFloatRoot == null)
		{
			return;
		}
		foreach (Vector3 localOffset in localOffsets)
		{
			Transform transform = UnityEngine.Object.Instantiate(extraFloatPrefab, extraFloatRoot);
			transform.localPosition = localOffset;
			SetFloatDim(transform, dim: true);
			extraFloats.Add(transform);
		}
	}

	private void SetFloatDim(Transform f, bool dim)
	{
		SpriteRenderer componentInChildren = f.GetComponentInChildren<SpriteRenderer>();
		if (componentInChildren != null)
		{
			Color color = componentInChildren.color;
			color.a = (dim ? 0.95f : 1f);
			componentInChildren.color = color;
		}
	}

	private IEnumerator BobbingEffect()
	{
		Vector3 bobCenterPosition = bobberVisuals.localPosition;
		while (true)
		{
			float y = Mathf.Sin(Time.time * bobSpeed * 2f * MathF.PI) * bobHeight;
			bobberVisuals.localPosition = bobCenterPosition + new Vector3(0f, y, 0f);
			yield return null;
		}
	}

	private IEnumerator WaitForBite()
	{
		SoundManager.PlaySound("bobberThrowInWater");
		float num = UnityEngine.Random.Range(1f, 3f);
		float num2 = ((PlayerStats.Instance != null) ? PlayerStats.Instance.FasterCatchingBonus : 0f);
		float seconds = Mathf.Max(0.1f, num - num2);
		yield return new WaitForSeconds(seconds);
		if (!isBiteRegistered)
		{
			isBiteRegistered = true;
			if (bobbingCoroutine != null)
			{
				StopCoroutine(bobbingCoroutine);
			}
			bobbingCoroutine = null;
			StartCoroutine(BiteBobbingEffect());
			LocalizedString localizedString = new LocalizedString("Skills", "#ui.notif.bite");
			NotificationManager.Instance.ShowNotification(localizedString.GetLocalizedString(), base.transform.position + new Vector3(0f, 0.5f, 0f), Color.green);
			SoundManager.PlaySound("bite");
			onFishBite.Invoke();
			float num3 = ((PlayerStats.Instance != null) ? PlayerStats.Instance.ReactionTime : 0.7f);
			UnityEngine.Object.Destroy(base.gameObject, num3 + 15f);
		}
	}

	private IEnumerator BiteBobbingEffect()
	{
		Vector3 bobCenterPosition = bobberVisuals.localPosition;
		float franticSpeed = bobSpeed * 3f;
		float franticHeight = bobHeight * 3f;
		while (true)
		{
			float y = Mathf.Sin(Time.time * franticSpeed * 2f * MathF.PI) * franticHeight;
			bobberVisuals.localPosition = bobCenterPosition + new Vector3(0f, y, 0f);
			yield return null;
		}
	}

	public void AnimateReelOut(Vector3 targetCenterPos, float duration = 0.5f)
	{
		if (isReelingOut)
		{
			return;
		}
		isReelingOut = true;
		if (bobbingCoroutine != null)
		{
			StopCoroutine(bobbingCoroutine);
		}
		base.transform.DOMove(targetCenterPos, duration).SetEase(Ease.InOutQuad);
		Vector3 endValue = bobberVisuals.localScale * 0.5f;
		Vector3 endValue2 = shadowVisuals.localScale * 0.5f;
		bobberVisuals.DOScale(endValue, duration).SetEase(Ease.InOutQuad);
		shadowVisuals.DOScale(endValue2, duration).SetEase(Ease.InOutQuad);
		if (fadeRenderers != null)
		{
			SpriteRenderer[] array = fadeRenderers;
			foreach (SpriteRenderer spriteRenderer in array)
			{
				if (spriteRenderer != null)
				{
					spriteRenderer.DOFade(0f, duration).SetEase(Ease.InOutQuad);
				}
			}
		}
		UnityEngine.Object.Destroy(base.gameObject, duration + 0.1f);
	}
}
