using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public class AlertDialogBuilder
	{
		private AlertDialog m_alertDialog;

		public AlertDialogBuilder(AlertDialogStyle alertStyle = AlertDialogStyle.Default)
		{
		}

		public AlertDialogBuilder SetTitle(string value)
		{
			return null;
		}

		public AlertDialogBuilder SetMessage(string value)
		{
			return null;
		}

		public AlertDialogBuilder AddTextInputField(TextInputFieldOptions options = null)
		{
			return null;
		}

		public AlertDialogBuilder AddButton(string title, Callback callback)
		{
			return null;
		}

		public AlertDialogBuilder AddButton(string title, Callback<string[]> callback)
		{
			return null;
		}

		public AlertDialogBuilder AddCancelButton(string title, Callback callback)
		{
			return null;
		}

		public AlertDialog Build()
		{
			return null;
		}
	}
}
