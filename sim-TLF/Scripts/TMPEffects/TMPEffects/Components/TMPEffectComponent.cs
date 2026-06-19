using System;
using System.Collections.ObjectModel;
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
		private readonly object obj = new object();

		[NonSerialized]
		private TMPMediator mediator;

		[NonSerialized]
		private TMP_Text text;

		public ReadOnlyCollection<CharData> CharData => Mediator.CharData;

		public TMP_Text TextComponent
		{
			get
			{
				if (Mediator == null)
				{
					if (!(text != null))
					{
						return text = GetComponent<TMP_Text>();
					}
					return text;
				}
				return Mediator.Text;
			}
		}

		protected TMPMediator Mediator => mediator;

		public event OnTextChangedEventHandler OnTextChanged;

		public void SetText(string text)
		{
			if (Mediator == null)
			{
				TextComponent.SetText(text);
			}
			else
			{
				Mediator.SetText(text);
			}
		}

		public void Show(int start, int length, bool skipShowProcess = false)
		{
			if (Mediator == null)
			{
				throw new InvalidOperationException("Component is not enabled!");
			}
			VisibilityState state = (skipShowProcess ? VisibilityState.Shown : VisibilityState.Showing);
			Mediator.SetVisibilityState(start, length, state);
		}

		public void Hide(int start, int length, bool skipHideProcess = false)
		{
			if (Mediator == null)
			{
				throw new InvalidOperationException("Component is not enabled!");
			}
			VisibilityState state = (skipHideProcess ? VisibilityState.Hidden : VisibilityState.Hiding);
			Mediator.SetVisibilityState(start, length, state);
		}

		public void ShowAll(bool skipShowProcess = false)
		{
			if (Mediator == null)
			{
				throw new InvalidOperationException("Component is not enabled!");
			}
			VisibilityState state = (skipShowProcess ? VisibilityState.Shown : VisibilityState.Showing);
			Mediator.SetVisibilityState(0, Mediator.Text.textInfo.characterCount, state);
		}

		public void HideAll(bool skipHideProcess = false)
		{
			if (Mediator == null)
			{
				throw new InvalidOperationException("Component is not enabled!");
			}
			VisibilityState state = (skipHideProcess ? VisibilityState.Hidden : VisibilityState.Hiding);
			Mediator.SetVisibilityState(0, Mediator.Text.textInfo.characterCount, state);
		}

		protected void FreeMediator()
		{
			TMPMediatorManager.Unsubscribe(Mediator.Text, obj);
			mediator = null;
		}

		protected void UpdateMediator()
		{
			TMP_Text component = GetComponent<TMP_Text>();
			TMPMediatorManager.Subscribe(component, obj);
			mediator = TMPMediatorManager.GetMediator(component);
		}

		protected void OnSubscribeToMediator()
		{
			Mediator.TextChanged_Late += TextChanged;
		}

		protected void OnUnsubscribeFromMediator()
		{
			Mediator.TextChanged_Late -= TextChanged;
		}

		private void TextChanged(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData, ReadOnlyCollection<VisibilityState> oldVisibilities)
		{
			this.OnTextChanged?.Invoke(textContentChanged);
		}
	}
}
