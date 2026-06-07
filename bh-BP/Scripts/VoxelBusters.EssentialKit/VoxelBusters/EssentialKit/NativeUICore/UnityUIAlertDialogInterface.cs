using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins.UnityUI;

namespace VoxelBusters.EssentialKit.NativeUICore
{
	public sealed class UnityUIAlertDialogInterface : NativeAlertDialogInterfaceBase
	{
		private UnityUIAlertDialog m_unityDialog;

		public UnityUIAlertDialogInterface(UnityUIAlertDialog dialogPrefab, RectTransform parent)
		{
		}

		~UnityUIAlertDialogInterface()
		{
		}

		public override void SetTitle(string value)
		{
		}

		public override string GetTitle()
		{
			return null;
		}

		public override void SetMessage(string value)
		{
		}

		public override string GetMessage()
		{
			return null;
		}

		public override void AddTextInputField(TextInputFieldOptions options = null)
		{
		}

		public override void AddButton(string text, bool isCancelType)
		{
		}

		public override void Show()
		{
		}

		public override void Dismiss()
		{
		}

		private void DestroyDialog()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
}
