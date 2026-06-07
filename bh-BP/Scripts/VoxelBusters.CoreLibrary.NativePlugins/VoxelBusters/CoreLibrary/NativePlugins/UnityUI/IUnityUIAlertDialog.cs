using System;

namespace VoxelBusters.CoreLibrary.NativePlugins.UnityUI
{
	public interface IUnityUIAlertDialog
	{
		string Title { get; set; }

		string Message { get; set; }

		void AddTextField(string placeholderText);

		void AddActionButton(string title);

		void Show();

		void Dismiss();

		void SetCompletionCallback(Action<int, string[]> callback);
	}
}
