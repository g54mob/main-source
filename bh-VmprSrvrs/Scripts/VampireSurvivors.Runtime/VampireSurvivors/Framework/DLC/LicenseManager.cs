using System;
using System.Collections.Generic;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC
{
	public class LicenseManager
	{
		private const string _freeDlcActivatedKey = "freedlcactivated";

		public List<DlcType> OwnedDlc { get; }

		public List<DlcType> IncludedDlc { get; }

		public List<DlcType> AvailableDlc { get; }

		public void CheckDlcLicenses(Action callback)
		{
		}

		public void AddIncludedDlc()
		{
		}

		public bool IsFreeDlcActivated(DlcType dlcType)
		{
			return false;
		}

		public void SetFreeDlcActivated(DlcType dlcType, bool activated = true)
		{
		}

		public void CheckAvailableDlc(Action callback)
		{
		}

		public void SortDlcLists()
		{
		}
	}
}
