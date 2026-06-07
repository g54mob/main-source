using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ModApi.Ui
{
	public static class MessageDialogScriptExtensions
	{
		public static TaskAwaiter<MessageDialogResult> GetAwaiter(this MessageDialogScript dialog)
		{
			TaskCompletionSource<MessageDialogResult> tcs = new TaskCompletionSource<MessageDialogResult>();
			dialog.Closed += delegate(IDialog d)
			{
				tcs.SetResult(((MessageDialogScript)d).Result ?? MessageDialogResult.Cancel);
			};
			if (dialog.Result.HasValue)
			{
				tcs.SetResult(dialog.Result.Value);
			}
			return tcs.Task.GetAwaiter();
		}
	}
}
