using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class CollectionListElement : ChoiceMenuButtonBase
	{
		public eWriterId writerId;

		public int enumNumber;

		public Image selectedImage;

		public Image decidedImage;

		public GameObject questionMarkObj;

		private static readonly int PROPERTY_IS_SECRET;

		protected bool _isSecret;

		public bool isSecret => false;

		public event Action<ChoiceMenuButtonBase> OnPadDecideAction
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

		public override void InitComponent(ChoiceMenuButtonInitBase init)
		{
		}

		public void InitComponent(ChoiceMenuButtonInitBase init, bool isSecret)
		{
		}

		public void SetSecret(bool isSecret)
		{
		}

		public void SetPadDecide()
		{
		}
	}
}
