using UnityEngine;
using UnityEngine.UI;

namespace VoxelBusters.CoreLibrary.NativePlugins.UnityUI
{
	public sealed class DefaultUnityUIAlertDialog : UnityUIAlertDialog
	{
		[SerializeField]
		private Text m_title;

		[SerializeField]
		private Text m_message;

		[SerializeField]
		private Button[] m_buttons;

		[SerializeField]
		private InputField[] m_inputFields;

		public override void Show()
		{
		}

		private string[] GetCurrentInputValues()
		{
			return null;
		}
	}
}
