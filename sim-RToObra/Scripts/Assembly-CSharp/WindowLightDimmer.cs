using UnityEngine;

public class WindowLightDimmer : MonoBehaviour
{
	public string familyId;

	private LightDimmerKnob lightDimmerKnob;

	private bool applyMovement;

	private Vector3 originalPosition;

	private Vector3 originalTargetPosition;

	private void Start()
	{
		if (!string.IsNullOrEmpty(familyId))
		{
			lightDimmerKnob = LightDimmer.AttachKnob(base.gameObject, familyId);
			return;
		}
		lightDimmerKnob = LightDimmer.AttachKnob(base.gameObject);
		Light component = GetComponent<Light>();
		if (component != null)
		{
			applyMovement = true;
			originalPosition = base.transform.position;
			originalTargetPosition = base.transform.position + base.transform.forward;
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
		if (lightDimmerKnob != null)
		{
			lightDimmerKnob.illum = 0f;
		}
	}

	private void Update()
	{
		if (lightDimmerKnob != null)
		{
			lightDimmerKnob.illum = WaveMotion.GetWindowLight();
		}
		if (applyMovement)
		{
			Matrix4x4 skyMatrix = WaveMotion.GetSkyMatrix();
			Vector3 position = Vector3.Lerp(originalPosition, skyMatrix.MultiplyPoint(originalPosition), 0.25f);
			Vector3 worldPosition = Vector3.Lerp(originalTargetPosition, skyMatrix.MultiplyPoint(originalTargetPosition), 0.25f);
			base.transform.position = position;
			base.transform.LookAt(worldPosition);
		}
	}
}
