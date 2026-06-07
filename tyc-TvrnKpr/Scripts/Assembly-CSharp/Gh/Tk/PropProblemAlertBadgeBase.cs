using System.Collections.Generic;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[InitializeOnGameStarted]
	public abstract class PropProblemAlertBadgeBase : AlertBadgeBase
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void Reset()
		{
		}

		private PropProblemAlertBadgeBase()
		{
		}

		protected PropProblemAlertBadgeBase(string alertType)
		{
		}

		public IEnumerable<Prop> GetPropsWithIssues()
		{
			return null;
		}

		private void Invalidate()
		{
		}

		protected override bool UpdateInternal()
		{
			return false;
		}

		private string GetTooltipTextKey(IEnumerable<Prop> props)
		{
			return null;
		}

		protected override void OnClick(Alert_3DUIView source)
		{
		}
	}
}
