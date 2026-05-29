using Ookii.Dialogs.Interop;

namespace Ookii.Dialogs
{
	internal class VistaFileDialogEvents : IFileDialogEvents, IFileDialogControlEvents
	{
		private VistaFileDialog _dialog;

		public VistaFileDialogEvents(VistaFileDialog dialog)
		{
		}

		public HRESULT OnFileOk(IFileDialog pfd)
		{
			return default(HRESULT);
		}

		public HRESULT OnFolderChanging(IFileDialog pfd, IShellItem psiFolder)
		{
			return default(HRESULT);
		}

		public void OnFolderChange(IFileDialog pfd)
		{
		}

		public void OnSelectionChange(IFileDialog pfd)
		{
		}

		public void OnShareViolation(IFileDialog pfd, IShellItem psi)
		{
		}

		public void OnTypeChange(IFileDialog pfd)
		{
		}

		public void OnOverwrite(IFileDialog pfd, IShellItem psi)
		{
		}

		public void OnItemSelected(IFileDialogCustomize pfdc, int dwIDCtl, int dwIDItem)
		{
		}

		public void OnButtonClicked(IFileDialogCustomize pfdc, int dwIDCtl)
		{
		}

		public void OnCheckButtonToggled(IFileDialogCustomize pfdc, int dwIDCtl, bool bChecked)
		{
		}

		public void OnControlActivating(IFileDialogCustomize pfdc, int dwIDCtl)
		{
		}
	}
}
