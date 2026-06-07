namespace Gh.Tk.UI.InfoPanels
{
	public class PatienceStat3DUIView : BaseInteractable3DUIView
	{
		private PatienceStat _sourceValue;

		public virtual PatienceStat SourceValue
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
