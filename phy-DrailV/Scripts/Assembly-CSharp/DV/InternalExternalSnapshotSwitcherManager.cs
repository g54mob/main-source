using System.Collections.Generic;
using DV.Utils;

namespace DV
{
	[ExecuteAfter(typeof(CameraTrigger))]
	public class InternalExternalSnapshotSwitcherManager : SingletonBehaviour<InternalExternalSnapshotSwitcherManager>
	{
		private const float INTERNALITY_ON = 1f;

		private const float INTERNALITY_OFF = 0f;

		private HashSet<InternalExternalSnapshotSwitcher> switchers = new HashSet<InternalExternalSnapshotSwitcher>();

		public new static string AllowAutoCreate()
		{
			return "[InternalExternalSnapshotSwitcherManager]";
		}

		protected override void Awake()
		{
			base.Awake();
			if (switchers.Count == 0)
			{
				base.enabled = false;
			}
		}

		private void LateUpdate()
		{
			bool flag = false;
			foreach (InternalExternalSnapshotSwitcher switcher in switchers)
			{
				flag |= switcher.IsInside();
				if (flag)
				{
					break;
				}
			}
			SingletonBehaviour<AudioManager>.Instance.Internality = (flag ? 1f : 0f);
		}

		public void AddSwitcher(InternalExternalSnapshotSwitcher switcher)
		{
			switchers.Add(switcher);
			base.enabled = true;
		}

		public void RemoveSwitcher(InternalExternalSnapshotSwitcher switcher)
		{
			switchers.Remove(switcher);
			if (switchers.Count == 0)
			{
				base.enabled = false;
			}
		}
	}
}
