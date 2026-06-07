using System;
using System.Collections.Generic;
using VoxelBusters.CoreLibrary;
using VoxelBusters.CoreLibrary.NativePlugins;
using VoxelBusters.EssentialKit.NativeUICore;

namespace VoxelBusters.EssentialKit
{
	public class AlertDialog : NativeFeatureBehaviour
	{
		public interface ICallbackWrapper
		{
			void Invoke(object arg = null);
		}

		public class CallbackWrapper : ICallbackWrapper
		{
			private readonly Action _callback;

			public CallbackWrapper(Action callback)
			{
			}

			public void Invoke(object arg = null)
			{
			}
		}

		public class CallbackWrapper<T> : ICallbackWrapper
		{
			private readonly Action<T> _callback;

			public CallbackWrapper(Action<T> callback)
			{
			}

			public void Invoke(object arg = null)
			{
			}
		}

		private INativeAlertDialogInterface m_nativeDialog;

		private List<ICallbackWrapper> m_buttonActions;

		public string Title
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Message
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static AlertDialog CreateInstance(AlertDialogStyle alertStyle = AlertDialogStyle.Default)
		{
			return null;
		}

		protected override void AwakeInternal(object[] args)
		{
		}

		protected override void DestroyInternal()
		{
		}

		public override bool IsAvailable()
		{
			return false;
		}

		protected override string GetFeatureName()
		{
			return null;
		}

		public void AddTextInputField(TextInputFieldOptions options = null)
		{
		}

		public void AddButton(string title, Callback callback)
		{
		}

		public void AddButton(string title, Callback<string[]> callback)
		{
		}

		public void AddCancelButton(string title, Callback callback)
		{
		}

		public void Show()
		{
		}

		public void Dismiss()
		{
		}

		private void SetTitleInternal(string value)
		{
		}

		private void SetMessageInternal(string value)
		{
		}

		private void AddButtonInternal(string title, ICallbackWrapper callbackWrapper, bool isCancelType = false)
		{
		}

		private void HandleButtonClickInternalCallback(int selectedButtonIndex, string[] inputValues)
		{
		}
	}
}
