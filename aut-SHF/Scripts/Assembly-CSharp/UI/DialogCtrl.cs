using System.Collections.Generic;
using Libs;
using UI.InitParam;

namespace UI
{
	public class DialogCtrl : SingletonMonoBehaviour<DialogCtrl>
	{
		public ChoiceMenuCtrl choiceMenuPrefab;

		private ChoiceMenuCtrl _choiceObj;

		private readonly Queue<DialoglInit> initQueue;

		private static Stack<ChoiceMenuCtrl> _choiceStack;

		public bool IsDialog => false;

		public static void CloseDialogTop()
		{
		}

		public void OpenDialog(DialoglInit initParam)
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
