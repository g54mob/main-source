using System;

public class EndingDialogParam : BaseDialogParam
{
	public Action BackAction;

	public EndingDialogParam(Action backAction, bool enableCloseButton = true, bool enableEscape = true)
		: base(enableCloseButton: false, enableEscape: false)
	{
	}
}
