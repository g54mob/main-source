using System;

namespace Gh.Tk.UI
{
	public abstract class AiComponent3DUIView : BaseProgressValue3DUIView, IUpdateable
	{
		private AiComponent _sourceValue;

		protected float _nextPeriodicTooltipUpdate;

		public AiComponent SourceValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected virtual void RefreshValues()
		{
		}

		private void UpdateParentContainer()
		{
		}

		private void SourceValue_IsHiddenChanged(object sender, EventArgs<bool> e)
		{
		}

		private void OnSourceTooltipChanged(object sender, EventArgs e)
		{
		}

		public void UpdateObject()
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		public bool IsHidden()
		{
			return false;
		}
	}
}
