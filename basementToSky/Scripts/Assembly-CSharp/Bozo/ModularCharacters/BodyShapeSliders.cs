using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bozo.ModularCharacters
{
	public class BodyShapeSliders : MonoBehaviour
	{
		private OutfitSystem system;

		private BodyShapeModifier bodyShape;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private Transform scaleContainer;

		[SerializeField]
		private Slider scaleSlider;

		[SerializeField]
		private Slider xScaleSlider;

		[SerializeField]
		private Slider yScaleSlider;

		[SerializeField]
		private Slider zScaleSlider;

		[SerializeField]
		private Transform positionContainer;

		[SerializeField]
		private Slider xPositionSlider;

		[SerializeField]
		private Slider yPositionSlider;

		[SerializeField]
		private Slider zPositionSlider;

		[SerializeField]
		private Transform rotationContainer;

		[SerializeField]
		private Slider rotationSlider;

		private void Start()
		{
			if (system != null && bodyShape != null)
			{
				Init(system, bodyShape);
			}
		}

		public void Init(OutfitSystem system, BodyShapeModifier mod)
		{
			this.system = system;
			bodyShape = mod;
			title.text = mod.shapeName;
			if (bodyShape.useScale)
			{
				if (bodyShape.linkScaleAxis)
				{
					xScaleSlider.transform.parent.gameObject.SetActive(value: false);
					yScaleSlider.transform.parent.gameObject.SetActive(value: false);
					zScaleSlider.transform.parent.gameObject.SetActive(value: false);
				}
				else
				{
					if (!bodyShape.useXScale)
					{
						xScaleSlider.transform.parent.gameObject.SetActive(value: false);
					}
					if (!bodyShape.useYScale)
					{
						yScaleSlider.transform.parent.gameObject.SetActive(value: false);
					}
					if (!bodyShape.useZScale)
					{
						zScaleSlider.transform.parent.gameObject.SetActive(value: false);
					}
					scaleSlider.transform.parent.gameObject.SetActive(value: false);
					scaleSlider.onValueChanged.AddListener(SetScale);
				}
				scaleSlider.onValueChanged.AddListener(SetScale);
				xScaleSlider.onValueChanged.AddListener(SetScale);
				yScaleSlider.onValueChanged.AddListener(SetScale);
				zScaleSlider.onValueChanged.AddListener(SetScale);
				scaleSlider.minValue = bodyShape.scaleRange.x;
				scaleSlider.maxValue = bodyShape.scaleRange.y;
				xScaleSlider.minValue = bodyShape.scaleRange.x;
				xScaleSlider.maxValue = bodyShape.scaleRange.y;
				yScaleSlider.minValue = bodyShape.scaleRange.x;
				yScaleSlider.maxValue = bodyShape.scaleRange.y;
				zScaleSlider.minValue = bodyShape.scaleRange.x;
				zScaleSlider.maxValue = bodyShape.scaleRange.y;
			}
			else
			{
				scaleContainer.gameObject.SetActive(value: false);
			}
			if (bodyShape.usePosition)
			{
				if (!bodyShape.useXPos)
				{
					xPositionSlider.transform.parent.gameObject.SetActive(value: false);
				}
				if (!bodyShape.useYPos)
				{
					yPositionSlider.transform.parent.gameObject.SetActive(value: false);
				}
				if (!bodyShape.useZPos)
				{
					zPositionSlider.transform.parent.gameObject.SetActive(value: false);
				}
				xPositionSlider.minValue = bodyShape.posRange.x;
				xPositionSlider.maxValue = bodyShape.posRange.y;
				yPositionSlider.minValue = bodyShape.posRange.x;
				yPositionSlider.maxValue = bodyShape.posRange.y;
				zPositionSlider.minValue = bodyShape.posRange.x;
				zPositionSlider.maxValue = bodyShape.posRange.y;
				xPositionSlider.onValueChanged.AddListener(SetPosition);
				yPositionSlider.onValueChanged.AddListener(SetPosition);
				zPositionSlider.onValueChanged.AddListener(SetPosition);
			}
			else
			{
				positionContainer.gameObject.SetActive(value: false);
			}
			if (bodyShape.useRotation)
			{
				rotationSlider.onValueChanged.AddListener(SetRotation);
				rotationSlider.minValue = bodyShape.rotRange.x;
				rotationSlider.maxValue = bodyShape.rotRange.y;
			}
			else
			{
				rotationContainer.gameObject.SetActive(value: false);
			}
		}

		public void SetScale(float v)
		{
			bodyShape.SetScale(xScaleSlider.value, yScaleSlider.value, zScaleSlider.value, scaleSlider.value);
		}

		public void SetPosition(float v)
		{
			bodyShape.SetPosition(xPositionSlider.value, yPositionSlider.value, zPositionSlider.value);
		}

		public void SetRotation(float v)
		{
			bodyShape.SetRotation(rotationSlider.value);
		}
	}
}
