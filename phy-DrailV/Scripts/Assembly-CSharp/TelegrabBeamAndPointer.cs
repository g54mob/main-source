using DV;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public class TelegrabBeamAndPointer : MonoBehaviour
{
	private const float TRACER_SCALE_MULTIPLIER = 1.5f;

	private const float TRACER_SCALE_Z = 0.5f;

	private const float MIN_DISTANCE_TO_SHOW_TRACER = 0.25f;

	public TeleGrab teleGrab;

	private Vector3 defaultBeamLocalScale;

	private Vector3 defaultPointerLocalScale;

	[SerializeField]
	private Transform telegrabPointer;

	[SerializeField]
	private Transform telegrabTracer;

	private Vector3 pointerVelocity = new Vector3(0f, 0f, -5f);

	private Vector3 defaultTracerScale;

	[SerializeField]
	private Material validBeamMaterial;

	[SerializeField]
	private Material invalidBeamMaterial;

	private Renderer beamRenderer;

	private Transform controller;

	private TeleGrab.TelegrabData currentTelegrabData;

	private TeleGrab.TelegrabData previousTelegrabData;

	private (float distance, int frame)? overrideSettings;

	private bool HasOverride
	{
		get
		{
			if (!overrideSettings.HasValue)
			{
				return false;
			}
			return overrideSettings.Value.frame == Time.frameCount;
		}
	}

	private bool IsTelegrabDataChanged
	{
		get
		{
			bool num = currentTelegrabData.PointedTelegrabbable != previousTelegrabData.PointedTelegrabbable;
			bool flag = currentTelegrabData.PointedTeleinteractable != previousTelegrabData.PointedTeleinteractable;
			if (num || flag)
			{
				return true;
			}
			return currentTelegrabData.PointedGameObject != previousTelegrabData.PointedGameObject;
		}
	}

	private void Start()
	{
		teleGrab = GetComponentInParent<TeleGrab>();
		beamRenderer = GetComponent<Renderer>();
		controller = VRTK_DeviceFinder.GetActualController(teleGrab.transform.parent.gameObject).transform;
		InitTransforms();
		base.gameObject.SetActive(value: false);
	}

	private void OnDisable()
	{
		telegrabPointer.gameObject.SetActive(value: false);
		telegrabTracer.gameObject.SetActive(value: false);
		previousTelegrabData = (currentTelegrabData = TeleGrab.TelegrabData.Empty);
		overrideSettings = null;
	}

	private void InitTransforms()
	{
		teleGrab.telegrabBeam = base.transform.gameObject;
		defaultBeamLocalScale = new Vector3(teleGrab.sphereCastRadius, teleGrab.sphereCastRadius, teleGrab.maxDistance);
		defaultPointerLocalScale = new Vector3(teleGrab.telegrabPointerScale, teleGrab.telegrabPointerScale, teleGrab.telegrabPointerScale);
		defaultTracerScale = new Vector3(teleGrab.sphereCastRadius * 1.5f, teleGrab.sphereCastRadius * 1.5f, 0.5f);
		telegrabTracer.SetParent(base.transform.parent);
		telegrabPointer.SetParent(base.transform.parent);
		telegrabPointer.localScale = defaultPointerLocalScale;
		telegrabTracer.localScale = defaultTracerScale;
		telegrabTracer.localPosition = new Vector3(0f, 0f, teleGrab.maxDistance);
		base.transform.localScale = defaultBeamLocalScale;
	}

	public void OverrideOneFrame(float distance)
	{
		overrideSettings = (distance, Time.frameCount);
		RecalculateLocalScale();
		AnimateTracerAndPointer();
		beamRenderer.material = validBeamMaterial;
		telegrabPointer.gameObject.SetActive(value: true);
		telegrabTracer.gameObject.SetActive(value: true);
		base.gameObject.SetActive(value: true);
	}

	private void LateUpdate()
	{
		if (!HasOverride)
		{
			currentTelegrabData = teleGrab.CurrentTelegrabData;
			RecalculateLocalScale();
			AnimateTracerAndPointer();
			GiveVisualAndHapticFeedback();
			ToggleTracerAndPointer();
			previousTelegrabData = currentTelegrabData;
		}
	}

	private void ToggleTracerAndPointer()
	{
		if (IsTelegrabDataChanged)
		{
			telegrabPointer.gameObject.SetActive(currentTelegrabData.PointedGameObject != null);
			telegrabTracer.gameObject.SetActive(currentTelegrabData.PointedTelegrabbable != null || currentTelegrabData.PointedTeleinteractable != null);
		}
	}

	private void RecalculateLocalScale()
	{
		if (HasOverride)
		{
			base.transform.localScale = new Vector3(teleGrab.sphereCastRadius, teleGrab.sphereCastRadius, overrideSettings.Value.distance + teleGrab.sphereCastRadius);
		}
		else if ((bool)currentTelegrabData.PointedGameObject)
		{
			base.transform.localScale = new Vector3(teleGrab.sphereCastRadius, teleGrab.sphereCastRadius, currentTelegrabData.SphereCastHit.distance + teleGrab.sphereCastRadius);
		}
		else
		{
			base.transform.localScale = defaultBeamLocalScale;
		}
	}

	private void AnimateTracerAndPointer()
	{
		if (((bool)currentTelegrabData.PointedGameObject || HasOverride) && TimeUtil.IsFlowing)
		{
			float num = (HasOverride ? overrideSettings.Value.distance : teleGrab.CurrentTelegrabData.SphereCastHit.distance);
			Vector3 localPosition = new Vector3(0f, 0f, num);
			if (telegrabTracer.localPosition.z > num)
			{
				telegrabTracer.localPosition = localPosition;
			}
			telegrabPointer.localPosition = localPosition;
			Vector3 vector = pointerVelocity * num / teleGrab.maxDistance;
			Vector3 localScale = ((!(num > 0.25f)) ? Vector3.zero : new Vector3(defaultTracerScale.x, defaultTracerScale.y, defaultTracerScale.z * num / teleGrab.maxDistance));
			telegrabTracer.localScale = localScale;
			if (telegrabTracer.localPosition.z > float.Epsilon)
			{
				telegrabTracer.localPosition += vector * Time.deltaTime;
			}
			else
			{
				telegrabTracer.localPosition = localPosition;
			}
		}
	}

	private void GiveVisualAndHapticFeedback()
	{
		if (IsTelegrabDataChanged)
		{
			if (currentTelegrabData.PointedTelegrabbable != null || currentTelegrabData.PointedTeleinteractable != null)
			{
				beamRenderer.material = validBeamMaterial;
				HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(controller.gameObject), HapticIntensityType.Normal);
			}
			else
			{
				beamRenderer.material = invalidBeamMaterial;
			}
		}
	}
}
