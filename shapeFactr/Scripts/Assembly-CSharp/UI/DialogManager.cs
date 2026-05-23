using System.Collections.Generic;
using Libs;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UI
{
	public class DialogManager : SingletonMonoBehaviour<DialogManager>
	{
		public enum OpenMode
		{
			None = 0,
			Normal = 1,
			Exclusive = 100
		}

		public List<eDialog> dialogOrder;

		private readonly string dialogAddressBase;

		private InputActionController input;

		public static bool DisableEscForOneFrame;

		public static bool EnableOpenDialog { get; set; }

		public Dictionary<eDialog, BaseDialog> dialogCollection { get; private set; }

		public Dictionary<eDialog, AsyncOperationHandle<GameObject>> prepareDialogCollection { get; private set; }

		public bool IsDialog => false;

		public static eDialog ProcessingDialog { get; private set; }

		public BaseDialog GetDialog(eDialog dialog)
		{
			return null;
		}

		public TDialog GetDialog<TDialog>(eDialog dialog) where TDialog : BaseDialog
		{
			return null;
		}

		public void ResetOrder()
		{
		}

		public bool IsActiveDialog(eDialog dialog)
		{
			return false;
		}

		public bool TryGetDialog<TDialog>(eDialog dialog, out TDialog result) where TDialog : BaseDialog
		{
			result = null;
			return false;
		}

		public bool ExistWaitDialog(eDialog dialog)
		{
			return false;
		}

		public void OpenDialog(eDialog dialogType, OpenMode mode = OpenMode.Normal)
		{
		}

		public void OpenDialog<T>(eDialog dialogType, T args, OpenMode mode = OpenMode.Normal) where T : class
		{
		}

		public void WithoutOpenProcess(eDialog dialogType)
		{
		}

		public void BackDialog(eDialog dialogType)
		{
		}

		public void BackExclusiveDialog()
		{
		}

		public void BackAllDialog(List<OpenMode> ignoreBackMode = null)
		{
		}

		public void BackAllDialog(List<eDialog> ignoreDialog)
		{
		}

		private BaseDialog CreateDialog(eDialog dialogType)
		{
			return null;
		}

		public void PreCreateDialogAsync(eDialog dialogType)
		{
		}

		public void CloseDialog(eDialog dialogType)
		{
		}

		public BaseDialog FindFrontDialog()
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void InitOnPlayMode()
		{
		}

		private void Update()
		{
		}

		public void SortDialog()
		{
		}
	}
}
