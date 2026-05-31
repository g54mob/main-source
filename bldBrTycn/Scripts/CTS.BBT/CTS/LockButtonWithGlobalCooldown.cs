using CTS.BBT;
using CTS.Core;
using CTS.UI;
using CTS.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class LockButtonWithGlobalCooldown : CTSBehaviour, IRepaint
	{
		[SerializeField]
		private StringKey _cooldown;

		[SerializeField]
		[Inject(false)]
		private SoftReference<ISelectable> _objToLock;

		[SerializeField]
		private GameObject _cooldownObject;

		[SerializeField]
		private TMP_Text _cooldownText;

		[SerializeField]
		private UnityEvent _onLock;

		[InjectScope(EGetScope.Singleton)]
		[Inject(false)]
		private LevelParameters _levelParameters;

		private LockToggle _lockableLocker = new LockToggle();

		private CooldownManager _cooldownManager => _levelParameters.GlobalCooldowns;

		protected override void OnAwake()
		{
			base.OnAwake();
			_cooldownManager.CooldownStarted += OnCooldownStarted;
			_lockableLocker.Add(_objToLock.Get());
		}

		private void Start()
		{
			Repaint();
		}

		private void Update()
		{
			if (!_cooldownManager.IsOnCooldown(_cooldown))
			{
				EndCooldown();
			}
			else
			{
				UpdateText();
			}
		}

		private void EndCooldown()
		{
			base.enabled = false;
			if ((bool)_cooldownObject)
			{
				_cooldownObject.SetActive(value: false);
			}
			_lockableLocker.Unlock();
		}

		private void OnDestroy()
		{
			_cooldownManager.CooldownStarted -= OnCooldownStarted;
		}

		private void OnCooldownStarted(StringKey obj)
		{
			if (!(obj != _cooldown) && _cooldownManager.IsOnCooldown(_cooldown) && !base.enabled)
			{
				if ((bool)_cooldownObject)
				{
					_cooldownObject.SetActive(value: true);
				}
				UpdateText();
				_onLock.Invoke();
				_lockableLocker.Lock();
				base.enabled = true;
			}
		}

		private void UpdateText()
		{
			if (!_cooldownText)
			{
				return;
			}
			if (_cooldownManager.Cooldowns.TryGetValue(_cooldown, out var value))
			{
				if (value.IsTimeScaled)
				{
					_cooldownText.text = (value.EndTime.Value - Time.time).ToString("N0");
				}
				else
				{
					_cooldownText.text = (value.EndTime.Value - Time.unscaledTime).ToString("N0");
				}
			}
			else
			{
				_cooldownText.text = "0";
			}
		}

		public void Repaint()
		{
			if (_cooldownManager.IsOnCooldown(_cooldown))
			{
				OnCooldownStarted(_cooldown);
			}
			else
			{
				EndCooldown();
			}
		}
	}
}
