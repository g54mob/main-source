public class InGameShopDialogParam : BaseDialogParam
{
	public bool reloadLineup;

	public InGameShopDialogParam(bool reloadLineup, bool enableCloseButton = true, bool enableEscape = true)
		: base(enableCloseButton: false, enableEscape: false)
	{
	}
}
