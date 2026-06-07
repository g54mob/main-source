using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class PutMachineDialog : BaseDialog
	{
		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private GeneralMessageSetter yesMessageSetter;

		[SerializeField]
		private GeneralMessageSetter noMessageSetter;

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

		public void OnYesButton()
		{
		}

		public void OnNoButton()
		{
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}

		public override void PushEscape()
		{
		}

		public override void SetInFront()
		{
		}
	}
}
