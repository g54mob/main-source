using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class ConfirmRequireDialog : BaseDialog
	{
		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private OptionToggleItem requireToggle;

		[SerializeField]
		private RectTransform requireToggleRectTransform;

		[SerializeField]
		private eMessageId defaultYesMessage;

		[SerializeField]
		private eMessageId defaultNoMessage;

		[SerializeField]
		private GeneralMessageSetter yesMessageSetter;

		[SerializeField]
		private GeneralMessageSetter noMessageSetter;

		private bool enableEscape;

		private bool enableFrontButton;

		private bool autoClose;

		private event UnityAction pushYesAction
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

		private event UnityAction pushNoAction
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

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		public void UpdateConfirm(ConfirmDialogParam param)
		{
		}

		public void OnYesButton()
		{
		}

		public void OnNoButton()
		{
		}

		public override void PushEscape()
		{
		}

		public override void SetInFront()
		{
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}
	}
}
