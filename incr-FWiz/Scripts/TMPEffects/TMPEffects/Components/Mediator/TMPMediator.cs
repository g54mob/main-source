using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using TMPEffects.CharacterData;
using TMPEffects.TextProcessing;
using TMPro;
using UnityEngine;

namespace TMPEffects.Components.Mediator
{
	public class TMPMediator : IDisposable
	{
		public delegate void VisibilityEventHandler(int index, VisibilityState previous);

		public delegate void TextChangedEarlyEventHandler(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData);

		public delegate void TextChangedLateEventHandler(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData, ReadOnlyCollection<VisibilityState> oldVisibilities);

		public readonly ReadOnlyCollection<VisibilityState> VisibilityStates;

		public readonly ReadOnlyCollection<CharData> CharData;

		public readonly TMPEffectsTextProcessor Processor;

		public readonly TMP_Text Text;

		private readonly List<VisibilityState> visibilityStates;

		private readonly List<CharData> charData;

		private object visibilityProcessor;

		private bool disposed;

		private bool settingText;

		public event TextChangedEarlyEventHandler TextChanged_Early
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

		public event TextChangedLateEventHandler TextChanged_Late
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

		public event VisibilityEventHandler VisibilityStateUpdated
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

		internal TMPMediator(TMP_Text text)
		{
		}

		public void ForceReprocess()
		{
		}

		public void Dispose()
		{
		}

		public bool RegisterVisibilityProcessor(object obj)
		{
			return false;
		}

		public bool UnregisterVisibilityProcessor(object obj)
		{
			return false;
		}

		public VisibilityState GetVisibilityState(CharData cData)
		{
			return default(VisibilityState);
		}

		public void SetVisibilityState(int startIndex, int length, VisibilityState state)
		{
		}

		public void SetVisibilityState(CharData cData, VisibilityState state)
		{
		}

		public void SetVisibilityState(int index, VisibilityState state)
		{
		}

		public void SetText(string text)
		{
		}

		internal void ApplyMesh(CharData cData)
		{
		}

		private void OnTextChanged(UnityEngine.Object obj)
		{
		}

		private void TextChangedProcedure()
		{
		}

		private bool CompareCharData(ReadOnlyCollection<CharData> oldData)
		{
			return false;
		}

		private void SetPreprocessor()
		{
		}

		private void UnsetPreprocessor()
		{
		}

		private void PopulateCharData()
		{
		}

		private void ResetVisibilityStates()
		{
		}

		private void Hide(int index)
		{
		}

		private void Show(int index)
		{
		}
	}
}
