using System;
using System.Runtime.CompilerServices;
using Gh.Tk.UI.Slider;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk.UI
{
	public class Slider3DUIView : MonoBehaviour
	{
		public bool onlyRaiseEventWhenHandlePressed;

		[SerializeField]
		private SliderHandle3DUIView _handle;

		[SerializeField]
		private SliderTrack3DUIView _track;

		[SerializeField]
		private Transform _startPosition;

		[SerializeField]
		private Transform _endPosition;

		public int steps;

		public bool clampToSteps;

		public string sliderTickSound;

		[SerializeField]
		private TMP_InputField _inputField;

		[SerializeField]
		private bool usePercentageValueForInputField;

		public Func<float, float> CustomValueRoundingFunction;

		public Func<float, float> CustomPercentageRoundingFunction;

		public bool automaticallyDisableScrollRectInParent;

		private bool _parentScrollRectInitialized;

		private ScrollRect _parentScrollRect;

		private bool _nextvalueIsSetSilently;

		private float _currentPercentage;

		private bool _isSliderLocked;

		public float MaxValue { get; set; }

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

		public float MinValue { get; set; }

		public float CurrentPercentage
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool IsSliderLocked
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsHandlePressed => false;

		public Vector3 StartEndScreenVectorNormal => default(Vector3);

		public event EventHandler ValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler OnIsHandlePressedChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		private void OnInputFieldValueChanged(string arg0)
		{
		}

		private void OnDestroy()
		{
		}

		private void OnTrackPressed(object sender, EventArgs e)
		{
		}

		private void UpdateParentScrollDisableState()
		{
		}

		public void SetValueSilently(float value)
		{
		}

		private void OnHandlePressedChanged(object sender, EventArgs<bool> e)
		{
		}

		private void Update()
		{
		}

		private void PositionHandle()
		{
		}

		private void OnEnable()
		{
		}

		private float CalculateMousePosition(bool withHandleOffset = true)
		{
			return 0f;
		}

		public void RaiseValueChangedEvent()
		{
		}
	}
}
