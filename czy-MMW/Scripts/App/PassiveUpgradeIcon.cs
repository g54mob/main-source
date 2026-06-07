using UnityEngine;
using UnityEngine.UI;

public class PassiveUpgradeIcon : MonoBehaviour
{
	[SerializeField]
	private Image _upgradeImage;

	private RectTransform _upgradeRectTransform;

	private float _upgradeRadius;

	[SerializeField]
	private Image _counterImage;

	private RectTransform _counterRectTransform;

	private float _counterRadius;

	private static readonly int CutoutPositionPropertyId = Shader.PropertyToID("_CutoutPosition");

	private static readonly int CutoutRadiusPropertyId = Shader.PropertyToID("_CutoutRadius");

	private static readonly int CircleRadiusPropertyId = Shader.PropertyToID("_CircleSize");

	protected void Start()
	{
		Initialise();
	}

	private void Initialise()
	{
		_upgradeRectTransform = _upgradeImage.GetComponent<RectTransform>();
		_counterRectTransform = _counterImage.GetComponent<RectTransform>();
		_upgradeImage.material = new Material(_upgradeImage.material);
		_counterImage.material = new Material(_counterImage.material);
		_upgradeRadius = _upgradeImage.material.GetFloat(CircleRadiusPropertyId);
		_counterRadius = _counterImage.material.GetFloat(CircleRadiusPropertyId);
	}

	protected void LateUpdate()
	{
		UpdateCutoutRect(_upgradeImage, _upgradeRectTransform, _counterRadius, _counterRectTransform);
		UpdateCutoutRect(_counterImage, _counterRectTransform, _upgradeRadius, _upgradeRectTransform);
	}

	private void UpdateCutoutRect(Image imageA, RectTransform transformA, float radiusB, RectTransform transformB)
	{
		Vector3 vector = transformA.InverseTransformPoint(transformB.position) / (transformA.rect.size / 2f);
		vector *= -1f;
		float value = transformB.rect.size.x * transformB.lossyScale.x * radiusB / (transformA.rect.size.x * transformA.lossyScale.x);
		imageA.material.SetVector(CutoutPositionPropertyId, vector);
		imageA.material.SetFloat(CutoutRadiusPropertyId, value);
	}
}
