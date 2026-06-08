using Unity.Entities;

namespace Kitchen
{
	public abstract class GenericChoicePopupManager : PopupManager
	{
		protected abstract bool HandleDecision(Entity popup, GenericChoiceDecision decision);

		public override bool UpdatePopup(Entity popup)
		{
			if (!Require<CGenericChoicePopup>(popup, out CGenericChoicePopup comp))
			{
				return true;
			}
			if (comp.Decision == GenericChoiceDecision.None)
			{
				return false;
			}
			return HandleDecision(popup, comp.Decision);
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
