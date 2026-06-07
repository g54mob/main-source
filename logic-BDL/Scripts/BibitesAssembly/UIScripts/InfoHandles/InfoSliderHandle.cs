using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts.InfoHandles
{
	public abstract class InfoSliderHandle : ValueInfoHandle<float>
	{
		[Header("Base Parameters", order = 0)]
		public float targetppu;

		public float bufferValue;

		public float bufferFactor;

		public float scale;

		[Header("Base References", order = 1)]
		[SerializeField]
		private FloatValueTextHandle textValue;

		[SerializeField]
		private FloatValueTextHandle scaleTextValue;

		[SerializeField]
		private Image background;

		protected const int CapPixelsX = 4;

		protected const int CapPixelsY = 5;

		protected Vector2 size;

		protected float ppu;

		protected float pixelLength;

		private bool ppuInitialized;

		private bool updateScale;

		[NonSerialized]
		public UnityEvent<float> OnScaleRaised = new UnityEvent<float>();

		private float ScaleRatio(float val)
		{
			return Mathf.Min(Mathf.Abs(val / scale), 1f);
		}

		protected float ScaledX(float val)
		{
			return 8f * pixelLength + ScaleRatio(val) * (size.x - 8f * pixelLength);
		}

		public override void InitHandle()
		{
			InitSliderHandle(1f);
		}

		public virtual void InitSliderHandle(float valScale, bool updatableScale = true)
		{
			value = 0f;
			scale = valScale;
			updateScale = updatableScale;
			if (scaleTextValue != null)
			{
				scaleTextValue.UpdateValue(valScale, check: false);
			}
			OnRectTransformDimensionsChange();
		}

		protected override void OnValueChange()
		{
			if (textValue != null)
			{
				textValue.UpdateValue(value, check: false);
			}
			float num = Mathf.Abs(value);
			if (updateScale && !(num < scale - Mathf.Max(scale * bufferFactor, bufferValue)))
			{
				scale = num + Mathf.Max(num / (1f / bufferFactor - 1f), bufferValue);
				OnScaleRaised.Invoke(scale);
			}
		}

		public virtual void UpdateScale(float newScale)
		{
			scale = newScale;
			if (scaleTextValue != null)
			{
				scaleTextValue.UpdateValue(newScale);
			}
			updateScale = false;
			OnValueChange();
			updateScale = true;
		}

		[ExecuteAlways]
		protected virtual void OnRectTransformDimensionsChange()
		{
			size = GetComponent<RectTransform>().sizeDelta;
			ppu = Mathf.Max(targetppu, Mathf.Max(8f / size.x, 12f / size.y));
			UpdatePixelUnitRatio(ppu);
			OnValueChange();
		}

		protected virtual void UpdatePixelUnitRatio(float ratio)
		{
			if (!Mathf.Approximately(background.pixelsPerUnitMultiplier, ratio) || !ppuInitialized)
			{
				ppuInitialized = true;
				pixelLength = 1f / ratio;
				background.pixelsPerUnitMultiplier = ratio;
			}
		}
	}
}
