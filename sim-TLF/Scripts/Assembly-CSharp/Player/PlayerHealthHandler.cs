using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Entities;
using JSAM;
using Loxodon.Framework.Contexts;
using Services.Health;
using UI.HUD;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using Zenject;

namespace Player
{
	public class PlayerHealthHandler : MonoBehaviour, IHealthHandler
	{
		[Header("Params")]
		[SerializeField]
		private float _healthRestoreRate;

		[SerializeField]
		private float _healthRestoreCooldown;

		[Space(5f)]
		[Header("Links")]
		[SerializeField]
		private Volume _healthVolume;

		[SerializeField]
		private AssetReference _DSCanvasReference;

		[Inject(Id = "Player")]
		private IHealthService _healthService;

		[Inject]
		private PlayerHUDView _playerHUDView;

		[Inject]
		private DiContainer _diContainer;

		private CancellationTokenSource _regenCts;

		private float _lastHealth;

		public IHealthService HealthService => _healthService;

		private void Awake()
		{
			Loxodon.Framework.Contexts.Context.GetApplicationContext();
		}

		private void OnEnable()
		{
			_healthService.HealthChanged += UpdateVolumeOnHealthChanged;
			_healthService.HealthChanged += CheckForDeathOnHealthChanged;
			_healthService.HealthChanged += OnHealthChanged;
		}

		private void OnDisable()
		{
			_healthService.HealthChanged -= UpdateVolumeOnHealthChanged;
			_healthService.HealthChanged -= CheckForDeathOnHealthChanged;
			_healthService.HealthChanged -= OnHealthChanged;
			CancelRegen();
		}

		private void Start()
		{
			_healthService.SetHealth(100f);
			_lastHealth = _healthService.CurrentHealth;
		}

		private void UpdateVolumeOnHealthChanged(float currentHealth)
		{
			_healthVolume.weight = 1f - _healthService.GetHealthPercentage();
		}

		private void CheckForDeathOnHealthChanged(float currentHealth)
		{
			if (currentHealth == 0f)
			{
				HandleDeathScreen();
			}
		}

		private void OnHealthChanged(float currentHealth)
		{
			bool flag = currentHealth < _lastHealth;
			_lastHealth = currentHealth;
			if (currentHealth <= 0f)
			{
				CancelRegen();
			}
			else if (flag)
			{
				AudioManager.PlaySound(PlayerLibrarySounds.TakeDamage);
				RestartRegenCooldown();
			}
		}

		private void RestartRegenCooldown()
		{
			CancelRegen();
			_regenCts = new CancellationTokenSource();
			RegenAfterCooldown(_regenCts.Token).Forget();
		}

		private async UniTaskVoid RegenAfterCooldown(CancellationToken token)
		{
			await UniTask.WaitForSeconds(_healthRestoreCooldown, ignoreTimeScale: false, PlayerLoopTiming.Update, token);
			while (_healthService.CurrentHealth < _healthService.MaxHealth && !token.IsCancellationRequested)
			{
				float value = _healthRestoreRate * Time.deltaTime;
				_healthService.Heal(value);
				await UniTask.Yield(PlayerLoopTiming.Update, token);
			}
		}

		private void CancelRegen()
		{
			if (_regenCts != null)
			{
				_regenCts.Cancel();
				_regenCts.Dispose();
				_regenCts = null;
			}
		}

		private void HandleDeathScreen()
		{
			CancelRegen();
			_playerHUDView.gameObject.SetActive(value: false);
			CursorLockKeeper.Apply(CursorLockMode.None, visible: true);
			LoadDeathScreen().Forget();
		}

		private async UniTaskVoid LoadDeathScreen()
		{
			if (_DSCanvasReference == null || !_DSCanvasReference.RuntimeKeyIsValid())
			{
				Debug.LogWarning("[PlayerHealthHandler] Death screen AssetReference is not set or invalid.");
				return;
			}
			try
			{
				GameObject gameObject = await _DSCanvasReference.LoadAssetAsync<GameObject>().ToUniTask(null, PlayerLoopTiming.Update, this.GetCancellationTokenOnDestroy());
				if (gameObject == null)
				{
					Debug.LogWarning("[PlayerHealthHandler] Death screen prefab is null. Check AssetReference assignment.");
				}
				else
				{
					_diContainer.InstantiatePrefab(gameObject);
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception ex2)
			{
				Debug.LogWarning("[PlayerHealthHandler] Failed to load death screen: " + ex2.Message);
			}
		}
	}
}
