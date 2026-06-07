using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public class InfestationNestAlertBadge : AlertBadgeBase
	{
		[PersistenceOptIn]
		private bool _isActive;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Changed(object sender, EventArgs e)
		{
		}

		private static void Reset()
		{
		}

		private void Invalidate()
		{
		}

		protected override bool UpdateInternal()
		{
			return false;
		}

		private IEnumerable<InfestationNest> GetUnwantedInfestationNests()
		{
			return null;
		}

		protected override void OnClick(Alert_3DUIView source)
		{
		}
	}
}
