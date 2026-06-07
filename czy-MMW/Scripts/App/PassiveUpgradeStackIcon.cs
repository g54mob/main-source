using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassiveUpgradeStackIcon : MonoBehaviour
{
	[SerializeField]
	private Material _passiveMaterial;

	private readonly List<Image> _iconImages = new List<Image>();

	private readonly List<RectTransform> _iconRectTransforms = new List<RectTransform>();

	private float _circleRadius = -1f;

	private static readonly int FrontCutoutPositionPropertyId = Shader.PropertyToID("_FrontCutoutPosition");

	private static readonly int FrontCutoutRadiusPropertyId = Shader.PropertyToID("_FrontCutoutRadius");

	private static readonly int BackCutoutPositionPropertyId = Shader.PropertyToID("_BackCutoutPosition");

	private static readonly int BackCutoutRadiusPropertyId = Shader.PropertyToID("_BackCutoutRadius");

	private static readonly int CircleRadiusPropertyId = Shader.PropertyToID("_CircleSize");

	public void AddIcon(UpgradeIcon icon)
	{
		icon.fillRenderer.material = new Material(_passiveMaterial);
		_iconImages.Add(icon.fillRenderer);
		_iconRectTransforms.Add(icon.fillRenderer.GetComponent<RectTransform>());
		if (_circleRadius < 0f)
		{
			_circleRadius = icon.fillRenderer.material.GetFloat(CircleRadiusPropertyId);
		}
	}

	public void RemoveIcon(UpgradeIcon icon)
	{
		int num = _iconImages.IndexOf(icon.fillRenderer);
		if (num >= 0)
		{
			_iconImages.RemoveAt(num);
			_iconRectTransforms.RemoveAt(num);
		}
	}

	private void LateUpdate()
	{
		if (_iconImages.Count > 1)
		{
			Image thisImage = _iconImages[0];
			RectTransform rectTransform = _iconRectTransforms[0];
			Image image = _iconImages[1];
			RectTransform rectTransform2 = _iconRectTransforms[1];
			UpdateCutoutRect(thisImage, rectTransform, rectTransform2, BackCutoutPositionPropertyId, BackCutoutRadiusPropertyId);
			RectTransform otherCircleTransform;
			for (int i = 1; i + 1 < _iconImages.Count; i++)
			{
				otherCircleTransform = rectTransform;
				thisImage = image;
				rectTransform = rectTransform2;
				image = _iconImages[i + 1];
				rectTransform2 = _iconRectTransforms[i + 1];
				UpdateCutoutRect(thisImage, rectTransform, otherCircleTransform, FrontCutoutPositionPropertyId, FrontCutoutRadiusPropertyId);
				UpdateCutoutRect(thisImage, rectTransform, rectTransform2, BackCutoutPositionPropertyId, BackCutoutRadiusPropertyId);
			}
			otherCircleTransform = rectTransform;
			thisImage = _iconImages[_iconImages.Count - 1];
			rectTransform = _iconRectTransforms[_iconImages.Count - 1];
			UpdateCutoutRect(thisImage, rectTransform, otherCircleTransform, FrontCutoutPositionPropertyId, FrontCutoutRadiusPropertyId);
			thisImage.material.SetFloat(BackCutoutRadiusPropertyId, 0f);
		}
		else if (_iconImages.Count == 1)
		{
			Image image2 = _iconImages[0];
			image2.material.SetFloat(FrontCutoutRadiusPropertyId, 0f);
			image2.material.SetFloat(BackCutoutRadiusPropertyId, 0f);
		}
	}

	private void UpdateCutoutRect(Image thisImage, RectTransform thisTransform, RectTransform otherCircleTransform, int otherCirclePositionId, int otherCircleRadiusId)
	{
		Vector2 size = thisTransform.rect.size;
		Vector3 vector = thisTransform.InverseTransformPoint(otherCircleTransform.position) / (size / 2f);
		vector *= -1f;
		float value = otherCircleTransform.rect.size.x * otherCircleTransform.lossyScale.x * _circleRadius / (size.x * thisTransform.lossyScale.x);
		thisImage.material.SetVector(otherCirclePositionId, vector);
		thisImage.material.SetFloat(otherCircleRadiusId, value);
	}
}
