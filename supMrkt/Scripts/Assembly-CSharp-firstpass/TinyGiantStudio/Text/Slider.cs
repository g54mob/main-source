using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Slider", 20005)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/ui/slider")]
	public class Slider : MonoBehaviour
	{
		[Serializable]
		public class ValueRange
		{
			public float min;

			public float max;

			public GameObject icon;

			public bool triggeredAlready;

			public UnityEvent oneTimeEvents;

			public UnityEvent repeatEvents;
		}

		public bool autoFocusOnGameStart;

		public bool interactable;

		[Tooltip("Minimum value")]
		public float minValue;

		[Tooltip("Maximum value")]
		public float maxValue;

		[SerializeField]
		private float _currentValue;

		public SliderHandle handle;

		public Renderer handleGraphic;

		public Transform progressBar;

		public GameObject progressBarPrefab;

		public Transform background;

		public float backgroundSize;

		public int directionChoice;

		[Tooltip("How much to change on key press")]
		public float keyStep;

		public bool useEvents;

		public UnityEvent onValueChanged;

		[Tooltip("Mouse/touch dragging the slider ended")]
		public UnityEvent sliderDragEnded;

		public Material selectedHandleMat;

		public Material unSelectedHandleMat;

		public Material clickedHandleMat;

		public Material disabledHandleMat;

		public bool useValueRangeEvents;

		public bool usePercentage;

		public List<ValueRange> valueRangeEvents;

		[HideInInspector]
		[SerializeField]
		private int lastValue;

		public float CurrentValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float CurrentPercentage()
		{
			return 0f;
		}

		private void Awake()
		{
		}

		public void UpdateValue()
		{
		}

		public void UpdateValue(int newValue)
		{
		}

		public void UpdateValue(float newValue)
		{
		}

		public void IncreaseValue()
		{
		}

		public void IncreaseValue(int amount)
		{
		}

		public void IncreaseValue(float amount)
		{
		}

		public void DecreaseValue()
		{
		}

		public void DecreaseValue(int amount)
		{
		}

		public void DecreaseValue(float amount)
		{
		}

		public void Focus(bool enable)
		{
		}

		public void SelectedVisual()
		{
		}

		public void UnSelectedVisual()
		{
		}

		public void ClickedVisual()
		{
		}

		public void DisabledVisual()
		{
		}

		private void ApplyVisual(Material handleMaterial)
		{
		}

		public List GetParentList()
		{
			return null;
		}

		public (bool, List) ApplyNormalStyleFromParent()
		{
			return default((bool, List));
		}

		public (bool, List) ApplySelectedStyleFromParent()
		{
			return default((bool, List));
		}

		public (bool, List) ApplyPressedStyleFromParent()
		{
			return default((bool, List));
		}

		public (bool, List) ApplyDisabledStyleFromParent()
		{
			return default((bool, List));
		}

		public void ValueChanged()
		{
		}

		private void ValueRangeEvents()
		{
		}

		private void ProcessSelectedValueRange(int i, bool firstTime)
		{
		}

		public void ValueChangeEnded()
		{
		}

		public void Uninteractable()
		{
		}

		public void Interactable()
		{
		}

		public void NewValueRange()
		{
		}

		public void GetCurrentValueFromHandle()
		{
		}

		public void UpdateGraphic()
		{
		}

		private void UpdateHandle()
		{
		}

		private void UpdateProgressBar()
		{
		}

		private float RangeConvertedValue(float oldValue, float oldMin, float oldMax, float newMin, float newMax)
		{
			return 0f;
		}

		public void UpdateBackgroundSize()
		{
		}
	}
}
