using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Maps;
using Data.Notifications;
using Data.SaveData.PersistentSOs;
using Events.FactoryFloor;
using Events.Islands;
using Events.UI.Notifications;
using Events.UI.Overlays;
using Presentation.FactoryFloor.FactoryObjectViews.Buildings;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor.Islands
{
	public class GNNIslandView : BaseIslandLockView
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FadeToBlackEvent _fadeToBlackEvent;

		[SerializeField]
		private FadeFromBlackEvent _fadeFromBlackEvent;

		[SerializeField]
		private CameraViewLocator _cameraViewLocator;

		[SerializeField]
		private AnimationFinishedHandler _animationFinishedHandler;

		[SerializeField]
		private Animation _animation;

		[SerializeField]
		private Transform _container;

		[SerializeField]
		private GameObject _grass;

		[Header("Notification")]
		[SerializeField]
		private NotificationEvent _notificationEvent;

		[SerializeField]
		private Sprite _chargeNotificationSprite;

		[SerializeField]
		[LocaKey]
		private string _chargeAvailableLocaKey;

		[Header("Unlocking")]
		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private UnlockedIslandEventSO _unlockedIslandEvent;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private readonly Dictionary<FactoryObjectView, Transform> _viewToParent = new Dictionary<FactoryObjectView, Transform>();

		private IslandObject _islandObject;

		public override void Setup(IslandViewBottom bottomPrefab, IslandObject islandObject)
		{
			_islandObject = islandObject;
			if (_unlockedIslandsPersistentSO.IsIslandUnlocked(_islandObject))
			{
				SetIdleUnlockedState();
				return;
			}
			SetIdleLockState();
			_unlockedIslandEvent.Register(OnIslandUnlocked);
		}

		private void OnDestroy()
		{
			_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
		}

		private void OnIslandUnlocked(IslandObject islandObject)
		{
			if (islandObject == _islandObject)
			{
				Unlock();
				_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
			}
		}

		private void SetIdleLockState()
		{
			_container.gameObject.SetActive(value: false);
		}

		private void SetIdleUnlockedState()
		{
			_container.gameObject.SetActive(value: true);
		}

		public void Unlock()
		{
			_audioManagerLocator.AudioManager.PlayGNNIslandUnlock();
			StartUnlockAnimation();
		}

		private void StartUnlockAnimation()
		{
			_grass.SetActive(value: false);
			_container.gameObject.SetActive(value: true);
			_cameraViewLocator.CameraView.LerpToTargetPosition(base.transform.position, 1f, blockInput: true);
			_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: false);
			_animationFinishedHandler.OnAnimationFinishedEvent += HandleAnimationFinished;
			_animation.Play();
			_fadeFromBlackEvent.Fire((null, false));
			_viewToParent.Clear();
			foreach (FactoryObject allDistinctObject in _islandObject.GetAllDistinctObjects(_factoryLayer))
			{
				Vector3 position = allDistinctObject.Position + new Vector3(0.5f, 0.5f, 0.5f);
				FactoryObjectViewManager.Instance.CreateFactoryObjectView(new CreateFactoryObjectDto(position, allDistinctObject.Rotation, allDistinctObject.Mirrored, allDistinctObject, 0));
				if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(allDistinctObject.CreatedId, out var view))
				{
					_viewToParent.Add(view, view.transform.parent);
					view.gameObject.SetActive(value: false);
					view.transform.SetParent(_container);
				}
			}
		}

		private void HandleAnimationFinished()
		{
			_animationFinishedHandler.OnAnimationFinishedEvent -= HandleAnimationFinished;
			_fadeToBlackEvent.Fire(delegate
			{
				_cameraViewLocator.CameraView.ToggleCameraEnabled(enabled: true);
				_fadeFromBlackEvent.Fire((delegate
				{
					_notificationEvent.Fire(new GenericNotificationData(_chargeNotificationSprite, _chargeAvailableLocaKey));
				}, true));
			});
			foreach (KeyValuePair<FactoryObjectView, Transform> item in _viewToParent)
			{
				item.Key.transform.SetParent(item.Value);
				FactoryObjectViewCullingController componentInChildren = item.Key.GetComponentInChildren<FactoryObjectViewCullingController>(includeInactive: true);
				if (componentInChildren != null)
				{
					componentInChildren.RefreshCullingPosition();
				}
			}
			_grass.SetActive(value: true);
		}

		public override void Hover()
		{
		}

		public override void HoverStopped()
		{
		}

		public override void Cull(bool cull)
		{
		}
	}
}
