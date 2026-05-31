using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class LockButtonWithProfileLevel : CTSBehaviour
	{
		[SerializeField]
		private SoftReference<MapInfoSO> _mapInfo;

		[SerializeField]
		[Inject(false)]
		private ISelectable _selectable;

		private readonly LockToggle _lock = new LockToggle();

		private CareerProfile _profile;

		protected override void OnAwake()
		{
			base.OnAwake();
			_lock.Add(_selectable);
			if (!(CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile profile))
			{
				base.enabled = false;
			}
			else
			{
				_profile = profile;
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			MapInfoSO level = _mapInfo.Get();
			if (!_profile.HasLevelBeenPlayedOnce(level) && !_profile.DoesLevelHaveSave(_mapInfo.Get()))
			{
				_lock.Lock();
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_lock.Unlock();
		}
	}
}
