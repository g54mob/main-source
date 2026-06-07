using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class MessageDialog : BaseDialog
	{
		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private GameObject backFactoryObj;

		private bool enableEscape;

		private bool enableFrontButton;

		private bool playCloseSound;

		private event UnityAction onClickAction
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

		public override void Back()
		{
		}

		public void OnClick()
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

		public void OnClickReturnFactory()
		{
		}
	}
}
