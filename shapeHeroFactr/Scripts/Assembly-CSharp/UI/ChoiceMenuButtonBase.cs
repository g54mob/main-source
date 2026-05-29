using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace UI
{
	public class ChoiceMenuButtonBase : MonoBehaviour
	{
		public Image iconImage;

		public TMP_Text nameText;

		public TMP_Text descText;

		public GameObject levelTextBG;

		public TMP_Text levelText;

		public RectTransform resizeObj;

		public event Action<ChoiceMenuButtonBase> OnClickAction
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

		public event Action<ChoiceMenuButtonBase> OnFocusAction
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

		public event Action<ChoiceMenuButtonBase> OnBlurAction
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

		public virtual void InitComponent(ChoiceMenuButtonInitBase init)
		{
		}

		public virtual void OnClick()
		{
		}

		public virtual void OnFocus()
		{
		}

		public virtual void OnBlur()
		{
		}

		public void SetChoiceName(string text)
		{
		}

		public void SetChoiceDesc(string text)
		{
		}

		public void SetStatusLevel(int level)
		{
		}

		private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
		{
		}

		public void SetIconToResizeObj()
		{
		}
	}
}
