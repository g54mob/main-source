using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TMPEffects.CharacterData;
using TMPEffects.Components.Mediator;
using TMPro;
using UnityEngine;

namespace TMPEffects.Components
{
	public abstract class TMPEffectComponent : MonoBehaviour
	{
		public delegate void OnTextChangedEventHandler(bool textContentChanged);

		[NonSerialized]
		private readonly object obj;

		[NonSerialized]
		private TMPMediator mediator;

		[NonSerialized]
		private TMP_Text text;

		public ReadOnlyCollection<CharData> CharData => null;

		public TMP_Text TextComponent => null;

		protected TMPMediator Mediator => null;

		public event OnTextChangedEventHandler OnTextChanged
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

		public void SetText(string text)
		{
		}

		public void Show(int start, int length, bool skipShowProcess = false)
		{
		}

		public void Hide(int start, int length, bool skipHideProcess = false)
		{
		}

		public void ShowAll(bool skipShowProcess = false)
		{
		}

		public void HideAll(bool skipHideProcess = false)
		{
		}

		protected void FreeMediator()
		{
		}

		protected void UpdateMediator()
		{
		}

		protected void OnSubscribeToMediator()
		{
		}

		protected void OnUnsubscribeFromMediator()
		{
		}

		private void TextChanged(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData, ReadOnlyCollection<VisibilityState> oldVisibilities)
		{
		}
	}
}
