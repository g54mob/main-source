using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class LockButtonOnNoSceneSave : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private ISelectable _selectable;

		private readonly LockToggle _lock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_lock.Add(_selectable);
		}

		private void Start()
		{
			ProfileManager.Saved += OnProfileManagerSaved;
			ProfileManager.ProfileChanged += OnProfileChanged;
			OnProfileChanged(CTSSingleton<ProfileManager>.Instance.CurrentProfile);
		}

		private void OnProfileChanged(Profile obj)
		{
			GameMode outInstance;
			if (obj == null)
			{
				_lock.SetLock(locked: true);
			}
			else if (CTSSingleton<GameMode>.TryGetInstance(out outInstance))
			{
				_lock.SetLock(!obj.DoesLevelHaveSave(outInstance.LevelInfo));
			}
		}

		private void OnProfileManagerSaved()
		{
			OnProfileChanged(CTSSingleton<ProfileManager>.Instance.CurrentProfile);
		}

		private void OnDestroy()
		{
			_lock.Unlock();
			ProfileManager.Saved -= OnProfileManagerSaved;
			ProfileManager.ProfileChanged -= OnProfileChanged;
		}
	}
}
