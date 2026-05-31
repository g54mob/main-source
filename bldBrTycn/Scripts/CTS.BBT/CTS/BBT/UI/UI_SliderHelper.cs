using System;
using CTS.ScriptableSettings;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.BBT.UI
{
	public class UI_SliderHelper : MonoBehaviour
	{
		[SerializeField]
		[Space(10f)]
		[Foldout("Dev")]
		private Slider _slider;

		[SerializeField]
		[Foldout("Dev")]
		private Image _backgroundImage;

		[SerializeField]
		[Foldout("Dev")]
		private Image _fillImage;

		[SerializeField]
		[Foldout("Dev")]
		private Image _handleImage;

		[SerializeField]
		[Foldout("Dev")]
		private bool _isIntSlider;

		[SerializeField]
		[Foldout("Dev")]
		[ShowIf("_isIntSlider")]
		private IntSetting _intSetting;

		[SerializeField]
		[Foldout("Dev")]
		[HideIf("_isIntSlider")]
		private FloatSetting _floatSetting;

		[SerializeField]
		[Foldout("Dev")]
		private TMP_Text _startValueDisplay;

		[SerializeField]
		[Foldout("Dev")]
		private TMP_Text _endValueDisplay;

		[SerializeField]
		[Foldout("Dev")]
		private TMP_Text _currentValueDisplay;

		[SerializeField]
		[Foldout("Dev")]
		private float _offset;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Background")]
		private Color _backGroundColor;

		[SerializeField]
		[BoxGroup("Background")]
		[ShowAssetPreview(64, 64)]
		private Sprite _newBackgroundImage;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Fill")]
		private Color _fillColor;

		[SerializeField]
		[ShowAssetPreview(64, 64)]
		[BoxGroup("Fill")]
		private Sprite _newFillImage;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Handle")]
		private Color _handleColor;

		[SerializeField]
		[ShowAssetPreview(64, 64)]
		[BoxGroup("Handle")]
		private Sprite _newHandleImage;

		[SerializeField]
		[Space(10f)]
		[MinMaxSlider(-100f, 200f)]
		[BoxGroup("Slider Values")]
		private Vector2 _sliderValues;

		[SerializeField]
		[BoxGroup("Slider Values")]
		[Obsolete("Use the new var _sliderNameValue")]
		private string _sliderName;

		private void OnEnable()
		{
			UpdateSliderValue();
		}

		private void Start()
		{
			if (_isIntSlider)
			{
				_intSetting.ValueChanged += OnIntChanged;
			}
			else
			{
				_floatSetting.ValueChanged += OnFloatChanged;
			}
			UpdateSliderValue();
		}

		private void OnDestroy()
		{
			if (_isIntSlider)
			{
				_intSetting.ValueChanged += OnIntChanged;
			}
			else
			{
				_floatSetting.ValueChanged += OnFloatChanged;
			}
		}

		private void OnIntChanged(int obj)
		{
			UpdateSliderValue();
		}

		private void OnFloatChanged(float obj)
		{
			UpdateSliderValue();
		}

		private void UpdateSliderValue()
		{
			_slider.value = (_isIntSlider ? ((float)_intSetting.GetValue()) : _floatSetting.GetValue());
			float num = Mathf.RoundToInt(_slider.value);
			_currentValueDisplay.text = (_isIntSlider ? _slider.value.ToString() : (num + _offset).ToString());
		}

		public void OnSliderEventChanged()
		{
			if (_isIntSlider)
			{
				_intSetting.SetValue(Mathf.RoundToInt(_slider.value));
			}
			else
			{
				_floatSetting.SetValue(_slider.value);
			}
		}
	}
}
