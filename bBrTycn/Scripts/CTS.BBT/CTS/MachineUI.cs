using CTS.UI;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class MachineUI : MonoBehaviour
	{
		public enum EMachineUIType
		{
			ProgressAuto = 0,
			ProgressDefine = 1
		}

		public enum EMachineClockwiseType
		{
			Clockwise = 0,
			CounterClockwise = 1
		}

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Link Settings")]
		private MachineBase _machineBase;

		[SerializeField]
		[BoxGroup("Link Settings")]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		[BoxGroup("Link Settings")]
		private Image _fillArea;

		[SerializeField]
		[BoxGroup("Link Settings")]
		private Image _icon;

		[Space(10f)]
		[BoxGroup("Sprites Settings")]
		public Sprite DefaultSprite;

		[BoxGroup("Sprites Settings")]
		public Sprite ProgressSprite;

		[BoxGroup("Sprites Settings")]
		public Sprite DangerSprite;

		[BoxGroup("Sprites Settings")]
		public Sprite HumanSadSprite;

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Color Settings")]
		public Color _greenColor;

		[SerializeField]
		[BoxGroup("Color Settings")]
		public Color _orangeColor;

		[SerializeField]
		[BoxGroup("Color Settings")]
		public Color _redColor;

		[SerializeField]
		[BoxGroup("Color Settings")]
		public Color _blueColor;

		private bool _currentState;

		private Sprite _currentIcon;

		private float _durationFillArea;

		private float _tmpTime;

		private float _fillValue;

		private bool _needToBeNormalized;

		[SerializeField]
		private EMachineUIType _machineUIType;

		[SerializeField]
		private EMachineClockwiseType _machineClockwiseType;

		public bool IsDisplayed => _currentState;

		private void OnEnable()
		{
			if ((bool)_machineBase)
			{
				_machineBase.DisplayOrHideUI += DisplayOrHide;
			}
		}

		private void OnDisable()
		{
			if ((bool)_machineBase)
			{
				_machineBase.DisplayOrHideUI -= DisplayOrHide;
			}
		}

		public void SetupMachineUI(EMachineUIType _tmpMachineUIType, EMachineClockwiseType _clockwiseType, Sprite _tmpIcon = null, Color? _tmpFillColor = null, bool _normalizeValue = false)
		{
			_machineUIType = _tmpMachineUIType;
			if (_tmpIcon != null)
			{
				_icon.sprite = _tmpIcon;
			}
			_machineClockwiseType = _clockwiseType;
			switch (_machineClockwiseType)
			{
			case EMachineClockwiseType.Clockwise:
				_fillArea.fillClockwise = true;
				break;
			case EMachineClockwiseType.CounterClockwise:
				_fillArea.fillClockwise = false;
				break;
			}
			_fillArea.color = ((!_tmpFillColor.HasValue) ? _redColor : _tmpFillColor.Value);
			_needToBeNormalized = _normalizeValue;
		}

		public void TrySetIcon(Sprite sprite)
		{
			if (!(_currentIcon == sprite))
			{
				_icon.sprite = sprite;
				_currentIcon = sprite;
			}
		}

		public void ChanceColor(Color _color)
		{
			_fillArea.color = _color;
		}

		public void DisplayOrHide(bool _value)
		{
			_currentState = _value;
			_canvasGroupController.ShowCanvasGroup(_value, 0.1f);
		}

		public void ResetFillArea(float _tmpValue)
		{
			_fillArea.fillAmount = _tmpValue;
		}

		public Tween RunFillArea(float _tmpValue)
		{
			Tween result = null;
			_fillValue = _tmpValue;
			if (_needToBeNormalized)
			{
				_fillValue = Normalize(_fillValue);
			}
			if (_machineUIType == EMachineUIType.ProgressAuto)
			{
				_fillArea.fillAmount = ((_machineClockwiseType != EMachineClockwiseType.Clockwise) ? 1 : 0);
				_fillArea.DOFade(1f, 0f);
				result = DOTween.To(() => _fillArea.fillAmount, delegate(float x)
				{
					_fillArea.fillAmount = x;
				}, (_machineClockwiseType != EMachineClockwiseType.Clockwise) ? 1 : 0, _fillValue).OnComplete(delegate
				{
					_fillArea.DOFade(0f, 0.5f);
				});
			}
			else if (_machineUIType == EMachineUIType.ProgressDefine)
			{
				_fillArea.DOFade(1f, 0f);
				result = DOTween.To(() => _fillArea.fillAmount, delegate(float x)
				{
					_fillArea.fillAmount = x;
				}, _fillValue, 0.5f);
			}
			return result;
		}

		private float Normalize(float value)
		{
			if (value > 1000f)
			{
				value /= 10000f;
			}
			else if (value > 100f)
			{
				value /= 1000f;
			}
			else if (value > 10f)
			{
				value /= 100f;
			}
			else if (value < 10f)
			{
				value /= 100f;
			}
			return value;
		}
	}
}
