using DG.Tweening;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Logic.Factory;
using Presentation.FactoryFloor;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Presentation.UI.ErrorPopUps
{
	public class OperatorStatePopUp : MonoBehaviour, IPoolableComponent
	{
		[SerializeField]
		private CameraLocator _cameraLocator;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private FactoryLoader _factoryLoader;

		[SerializeField]
		private RectTransform _content;

		[SerializeField]
		private Image _typeBg;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		[SerializeField]
		private Color _warningColor;

		[SerializeField]
		private Color _errorColor;

		[SerializeField]
		private float _punchFrequency = 5f;

		private FactoryObject _factoryObject;

		private OperatorStateBehaviour.State _state;

		private OperatorStatePopUpsCanvas _canvas;

		private Vector3 _middle;

		private Vector3 _offset;

		private bool _initialized;

		private float _punchTime;

		private Vector3 _punchScale = new Vector3(1.1f, 1.1f, 1.1f);

		public FactoryObject FactoryObject => _factoryObject;

		public void SetState(FactoryObject factoryObject, OperatorStateBehaviour.State state, OperatorStatePopUpsCanvas canvas)
		{
			_factoryObject = factoryObject;
			_state = state;
			_canvas = canvas;
			_typeBg.color = ((state.StateType == OperatorStateBehaviour.StateType.Error) ? _errorColor : _warningColor);
			_icon.sprite = state.Icon;
			if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(factoryObject.CreatedId, out var view) && view.TryGetComponent<OperatorStateOffset>(out var component))
			{
				_offset = component.Offset;
			}
			CalculateFactoryObjectAnchorPoint(factoryObject);
			base.transform.position = CalculatePosition();
			if (!_state.SFX.IsNull && _factoryLoader.HasFinishedLoadingSave)
			{
				_audioManagerLocator.AudioManager.PlayOperatorStateOneShot(_state.SFX, CalculatePosition());
			}
			_initialized = true;
		}

		public void Reset()
		{
			_canvasGroup.alpha = 1f;
			_initialized = false;
		}

		public void Show()
		{
			_canvasGroup.alpha = 1f;
		}

		public void Hide()
		{
			_canvasGroup.alpha = 0f;
		}

		private void Update()
		{
			if (_initialized)
			{
				base.transform.position = CalculatePosition();
				_punchTime += Time.deltaTime;
				if (_punchTime >= _punchFrequency)
				{
					_punchTime = 0f;
					_content.DOKill(complete: true);
					_content.DOPunchScale(_punchScale, 0.5f, 2, 0.2f);
				}
			}
		}

		private Vector3 CalculatePosition()
		{
			return _cameraLocator.Camera.WorldToScreenPoint(_middle + new Vector3(0.5f, 3f, 0.5f));
		}

		private void CalculateFactoryObjectAnchorPoint(FactoryObject factoryObject)
		{
			_middle = Vector3.zero;
			foreach (Vector3Int occupiedPosition in factoryObject.OccupiedPositions)
			{
				_middle += (Vector3)occupiedPosition;
			}
			_middle /= (float)factoryObject.OccupiedPositions.Count;
			_middle += _offset;
		}

		public void OnReturnToPool()
		{
			base.gameObject.SetActive(value: false);
			_canvasGroup.alpha = 1f;
		}

		public void OnRetrieveFromPool()
		{
			base.gameObject.SetActive(value: true);
		}
	}
}
