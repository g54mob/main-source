using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class LockButtonWithProfile : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private ISelectable _selectable;

		private readonly LockToggle _lock = new LockToggle();

		private void Start()
		{
			_lock.Add(_selectable);
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile == null)
			{
				_lock.Lock();
			}
			ProfileManager.ProfileChanged += OnProfileChanged;
		}

		private void OnDestroy()
		{
			ProfileManager.ProfileChanged -= OnProfileChanged;
		}

		private void OnProfileChanged(Profile obj)
		{
			if (obj == null)
			{
				_lock.Lock();
			}
			else
			{
				_lock.Unlock();
			}
		}
	}
}
