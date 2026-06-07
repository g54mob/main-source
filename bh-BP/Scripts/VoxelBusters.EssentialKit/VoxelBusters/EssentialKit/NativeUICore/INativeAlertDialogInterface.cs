using System;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public interface INativeAlertDialogInterface : INativeObject, IDisposable
	{
		event AlertButtonClickInternalCallback OnButtonClick;

		void SetTitle(string value);

		string GetTitle();

		void SetMessage(string value);

		string GetMessage();

		void AddTextInputField(TextInputFieldOptions options = null);

		void AddButton(string text, bool isCancelType);

		void Show();

		void Dismiss();
	}
}
