using System.Collections;
using Data.FactoryFloor.Maps;
using Data.FactoryFloor.Resources;
using Data.SaveData.PersistentSOs;
using Events.FactoryFloor;
using Events.Islands;
using Logic.FactoryTools;
using Presentation.Locators;
using UnityEngine;
using UnityEngine.VFX;

namespace Presentation.FactoryFloor.Islands
{
	public class IslandLockView : BaseIslandLockView
	{
		private enum LockState
		{
			CantBuy = 0,
			CanBuy = 1,
			Hovering = 2,
			Unlocked = 3
		}

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		private UnlockedIslandEventSO _unlockedIslandEvent;

		[SerializeField]
		private VisualEffect _unlockingEffect;

		[SerializeField]
		private Material _lockedMaterialRef;

		[SerializeField]
		private float _unlockAnimationDuration;

		[SerializeField]
		private UnlockIslandTool _unlockIslandTool;

		[SerializeField]
		private AddCurrencyEvent _addCurrencyEvent;

		[SerializeField]
		private ResourceDataSO _islandCurrencyType;

		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private IslandObject _islandObject;

		private GameObject _lockedContainer;

		private Material _lockedMaterialInstance;

		private bool _unlocked;

		private static readonly int SHADER_ID_START_TIME = Shader.PropertyToID("_startTime");

		private static readonly int SHADER_ID_ANIM_TIME = Shader.PropertyToID("_animationTime");

		private static readonly int SHADER_ID_LOCKED_STATE = Shader.PropertyToID("_lockedState");

		public VisualEffect UnlockingEffect => _unlockingEffect;

		public override void Setup(IslandViewBottom bottomPrefab, IslandObject islandObject)
		{
			_lockedContainer = bottomPrefab.LockedContainer;
			_islandObject = islandObject;
			_lockedMaterialInstance = Object.Instantiate(_lockedMaterialRef);
			_lockedMaterialInstance.SetFloat(SHADER_ID_ANIM_TIME, _unlockAnimationDuration);
			foreach (MeshRenderer lockedContainerRend in bottomPrefab.LockedContainerRends)
			{
				lockedContainerRend.material = _lockedMaterialInstance;
			}
			if (_unlockedIslandsPersistentSO.IsIslandUnlocked(_islandObject))
			{
				HideLockEffect();
				return;
			}
			SetIdleLockState();
			_unlockedIslandEvent.Register(OnIslandUnlocked);
			_addCurrencyEvent.Register(OnCurrencyAdded);
		}

		private void OnDestroy()
		{
			_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
			_addCurrencyEvent.UnRegister(OnCurrencyAdded);
		}

		private void OnCurrencyAdded(AddCurrencyEventDto currency)
		{
			if (currency.CurrencyType == _islandCurrencyType)
			{
				SetIdleLockState();
			}
		}

		private void OnIslandUnlocked(IslandObject islandObject)
		{
			if (islandObject == _islandObject)
			{
				Unlock();
				_unlockedIslandEvent.UnRegister(OnIslandUnlocked);
			}
			else
			{
				SetIdleLockState();
			}
		}

		private void HideLockEffect()
		{
			_lockedContainer.SetActive(value: false);
		}

		public void Unlock()
		{
			_audioManagerLocator.AudioManager.PlayIslandPurchase();
			SetLockState(LockState.Unlocked);
		}

		private void SetLockState(LockState locked)
		{
			if (!_unlocked)
			{
				switch (locked)
				{
				case LockState.CantBuy:
					_lockedMaterialInstance.SetFloat(SHADER_ID_LOCKED_STATE, 0f);
					break;
				case LockState.CanBuy:
					_lockedMaterialInstance.SetFloat(SHADER_ID_LOCKED_STATE, 1f);
					break;
				case LockState.Hovering:
					_lockedMaterialInstance.SetFloat(SHADER_ID_LOCKED_STATE, 2f);
					break;
				case LockState.Unlocked:
					_unlocked = true;
					_lockedMaterialInstance.SetFloat(SHADER_ID_LOCKED_STATE, 3f);
					_lockedMaterialInstance.SetFloat(SHADER_ID_START_TIME, Time.time);
					_unlockingEffect.Play();
					StartCoroutine(DisableLockedContainer());
					break;
				}
			}
		}

		private IEnumerator DisableLockedContainer()
		{
			yield return new WaitForSeconds(_unlockAnimationDuration);
			HideLockEffect();
		}

		public override void Hover()
		{
			if (CanUnlock())
			{
				_audioManagerLocator.AudioManager.PlayIslandHover();
				SetLockState(LockState.Hovering);
			}
		}

		public override void HoverStopped()
		{
			if (_unlockedIslandsPersistentSO.IsIslandUnlocked(_islandObject))
			{
				SetLockState(LockState.Unlocked);
			}
			else
			{
				SetIdleLockState();
			}
		}

		private void SetIdleLockState()
		{
			if (CanUnlock())
			{
				SetLockState(LockState.CanBuy);
			}
			else
			{
				SetLockState(LockState.CantBuy);
			}
		}

		private bool CanUnlock()
		{
			if (_unlockedIslandsPersistentSO.IsIslandAvaliable(_islandObject))
			{
				return _unlockIslandTool.CanBuyIsland();
			}
			return false;
		}

		public override void Cull(bool cull)
		{
			UnlockingEffect.gameObject.SetActive(!cull);
		}
	}
}
