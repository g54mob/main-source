using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public abstract class NativeAlertDialogInterfaceBase : NativeObjectBase, INativeAlertDialogInterface, INativeObject, IDisposable
	{
		public event AlertButtonClickInternalCallback OnButtonClick
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public abstract void SetTitle(string value);

		public abstract string GetTitle();

		public abstract void SetMessage(string value);

		public abstract string GetMessage();

		public abstract void AddTextInputField(TextInputFieldOptions options = null);

		public abstract void AddButton(string text, bool isCancelType);

		public abstract void Show();

		public abstract void Dismiss();

		protected void SendButtonClickEvent(int selectedButtonIndex, string[] inputValues = null)
		{
		}
	}
}
