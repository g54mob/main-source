namespace UI
{
	public class CollectionDialogParam : BaseDialogParam
	{
		public CollectionDialog.eCollectionPage page;

		public int enumNumber;

		public eLargeTips[] _targetIds;

		public CollectionDialogParam(CollectionDialog.eCollectionPage page, int enumNumber = 0, eLargeTips[] targetIds = null, bool enabledClose = true, bool enabledPushEscale = true)
			: base(enableCloseButton: false, enableEscape: false)
		{
		}
	}
}
