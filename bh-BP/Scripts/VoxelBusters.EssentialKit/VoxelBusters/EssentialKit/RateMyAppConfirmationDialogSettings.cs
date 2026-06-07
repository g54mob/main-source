using System;
using UnityEngine;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[Serializable]
	public class RateMyAppConfirmationDialogSettings
	{
		[SerializeField]
		[DefaultValue(true)]
		[Tooltip("If enabled, confirmation dialog is shown prior to prompting rating window.")]
		private bool m_canShow;

		[SerializeField]
		[DefaultValue("Rate My App")]
		[Tooltip("Title.")]
		private string m_promptTitle;

		[SerializeField]
		[TextArea]
		[DefaultValue("If you enjoy using Native Plugins would you mind taking a moment to rate it? It wont take more than a minute. Thanks for your support.")]
		[Tooltip("Description.")]
		private string m_promptDescription;

		[SerializeField]
		[DefaultValue("Ok")]
		[Tooltip("Positive action button label.")]
		private string m_okButtonLabel;

		[SerializeField]
		[DefaultValue("Cancel")]
		[Tooltip("Negative action button label.")]
		private string m_cancelButtonLabel;

		[SerializeField]
		[DefaultValue("Remind Me Later")]
		[Tooltip("Neutral action button label.")]
		private string m_remindLaterButtonLabel;

		[SerializeField]
		[DefaultValue(true)]
		[Tooltip("Determines whether neutral action button is required.")]
		private bool m_canShowRemindMeLaterButton;

		public bool CanShow => false;

		public string PromptTitle => null;

		public string PromptDescription => null;

		public string OkButtonLabel => null;

		public string CancelButtonLabel => null;

		public string RemindLaterButtonLabel => null;

		public bool CanShowRemindMeLaterButton => false;

		public RateMyAppConfirmationDialogSettings(bool canShow = true, string title = null, string description = null, string okButtonLabel = null, string cancelButtonLabel = null, string remindLaterButtonLabel = null, bool canShowRemindMeLaterButton = true)
		{
		}
	}
}
