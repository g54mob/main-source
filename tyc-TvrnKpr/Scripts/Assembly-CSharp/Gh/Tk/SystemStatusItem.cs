using System;

namespace Gh.Tk
{
	public class SystemStatusItem
	{
		private readonly Func<string> _getTitle;

		private readonly Func<SystemStatus.PerformanceState> _getState;

		private readonly Func<bool> _isVisible;

		private Func<TooltipData> _getTooltip;

		public Func<TooltipData> LazyTooltip
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string DisplayCategory { get; set; }

		public string SubCategory { get; set; }

		public string CodexId { get; set; }

		protected SystemStatusItem()
		{
		}

		public SystemStatusItem(string codexId, Func<string> getTitle, Func<SystemStatus.PerformanceState> getState, string category)
		{
		}

		public string GetTitle()
		{
			return null;
		}

		protected virtual string GetTitleInternal()
		{
			return null;
		}

		public virtual SystemStatus.PerformanceState GetState()
		{
			return default(SystemStatus.PerformanceState);
		}
	}
}
