using FMOD.Studio;
using FMODUnity;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews
{
	public class FactoryObjectViewAudioData : MonoBehaviour
	{
		[SerializeField]
		private EventReference _fmodEventReference;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		private Transform _soundLocation;

		private Vector3 _cachedPosition;

		private bool _canEmitAudio;

		private bool _viewHidden = true;

		private EventInstance _currentAudioEvent;

		private FactoryObjectView _factoryObjectView;

		public EventReference EventReference => _fmodEventReference;

		public bool CanEmitAudio => _canEmitAudio;

		public void Awake()
		{
			_factoryObjectView = base.gameObject.GetComponent<FactoryObjectView>();
			_factoryObjectView.OnHideView += OnHideView;
			_factoryObjectView.OnShowView += OnShowView;
		}

		private void OnDestroy()
		{
			if (_currentAudioEvent.isValid())
			{
				_audioManagerLocator.AudioManager.StopFactoryObjectViewLoop(ref _currentAudioEvent);
			}
			if (_factoryObjectView != null)
			{
				_factoryObjectView.OnHideView -= OnHideView;
				_factoryObjectView.OnShowView -= OnShowView;
			}
		}

		public void OnHideView(bool wasPreview)
		{
			_viewHidden = true;
			SetAudioEmitState(canEmit: false);
		}

		public void OnShowView(bool wasPreview)
		{
			_viewHidden = false;
			UpdateCachedPosition();
			SetAudioEmitState(canEmit: true);
		}

		public void SetAudioEmitState(bool canEmit)
		{
			_canEmitAudio = canEmit && !_viewHidden;
			if (_canEmitAudio && !_currentAudioEvent.isValid())
			{
				_currentAudioEvent = _audioManagerLocator.AudioManager.PlayFactoryObjectViewLoop(_fmodEventReference, _cachedPosition);
			}
			else if (!_canEmitAudio && _currentAudioEvent.isValid())
			{
				_audioManagerLocator.AudioManager.StopFactoryObjectViewLoop(ref _currentAudioEvent);
			}
		}

		public void UpdateCachedPosition()
		{
			_cachedPosition = ((_soundLocation != null) ? _soundLocation.transform.position : base.transform.position);
		}
	}
}
