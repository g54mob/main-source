using CTS.Core;
using CTS.ScriptableSettings;
using UnityEngine;

namespace CTS
{
	public class AutoSave : CTSBehaviour
	{
		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private ProfileManager _profileManager;

		[SerializeField]
		private SettingObject<int> _autoSaveInterval;

		[SerializeField]
		private SettingObject<bool> _doAutoSave;

		private float _nextAutoSave;

		public float NextAutoSave => _nextAutoSave;

		protected override void OnAwake()
		{
			base.OnAwake();
			SetNextAutoSave();
			_doAutoSave.ValueChanged += OnAutoSaveSettingChanged;
		}

		private void OnDestroy()
		{
			_doAutoSave.ValueChanged -= OnAutoSaveSettingChanged;
		}

		private void OnAutoSaveSettingChanged(bool obj)
		{
			SetNextAutoSave();
		}

		private void Update()
		{
			if (!_doAutoSave.GetValue())
			{
				SetNextAutoSave();
				return;
			}
			float unscaledTime = Time.unscaledTime;
			if (_profileManager.IsSaveLocked)
			{
				float b = 0f - (unscaledTime - _nextAutoSave);
				b = Mathf.Max(10f, b);
				_nextAutoSave = unscaledTime + b;
			}
			else if (unscaledTime >= _nextAutoSave)
			{
				SetNextAutoSave();
				_profileManager.Save();
			}
		}

		private void SetNextAutoSave()
		{
			_nextAutoSave = Time.unscaledTime + (float)_autoSaveInterval.GetValue() * 60f;
		}
	}
}
