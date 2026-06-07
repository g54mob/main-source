using UnityEngine.Events;

namespace UI
{
	public class AltarOfSpiritSelectParam : BaseDialogParam
	{
		public UnityAction closeAction;

		public AltarOfSpiritSelectParam(UnityAction closeAction)
			: base(enableCloseButton: false, enableEscape: false)
		{
		}
	}
}
