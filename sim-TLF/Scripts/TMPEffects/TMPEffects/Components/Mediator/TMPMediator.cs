using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

		public event TextChangedEarlyEventHandler TextChanged_Early;

		public event TextChangedLateEventHandler TextChanged_Late;

		public event VisibilityEventHandler VisibilityStateUpdated;

		internal TMPMediator(TMP_Text text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			Text = text;
			charData = new List<CharData>();
			CharData = new ReadOnlyCollection<CharData>(charData);
			Processor = new TMPEffectsTextProcessor(Text);
			visibilityStates = new List<VisibilityState>();
			VisibilityStates = new ReadOnlyCollection<VisibilityState>(visibilityStates);
			SetPreprocessor();
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
		}

		public void ForceReprocess()
		{
			if (Text != null)
			{
				Text.ForceMeshUpdate(ignoreActiveState: true, forceTextReparsing: true);
			}
		}

		public void Dispose()
		{
			if (disposed)
			{
				TMPEffectsBugReport.BugReportPrompt("Tried to dispose TMPMediator multiple times:\n" + new StackTrace());
				return;
			}
			UnsetPreprocessor();
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChanged);
		}

		public bool RegisterVisibilityProcessor(object obj)
		{
			if (visibilityProcessor != null)
			{
				return false;
			}
			if (obj == null)
			{
				return false;
			}
			visibilityProcessor = obj;
			return true;
		}

		public bool UnregisterVisibilityProcessor(object obj)
		{
			if (visibilityProcessor != obj)
			{
				return false;
			}
			visibilityProcessor = null;
			return true;
		}

		public VisibilityState GetVisibilityState(CharData cData)
		{
			return visibilityStates[cData.info.index];
		}

		public void SetVisibilityState(int startIndex, int length, VisibilityState state)
		{
			if (startIndex < 0 || length < 0 || startIndex + length > Text.textInfo.characterCount)
			{
				throw new ArgumentOutOfRangeException("Invalid input: Start = " + startIndex + "; Length = " + length + "; Length of string: " + Text.textInfo.characterCount);
			}
			VisibilityState visibilityState = state;
			bool flag = visibilityProcessor != null;
			if (!flag)
			{
				if (state == VisibilityState.Showing)
				{
					visibilityState = VisibilityState.Shown;
				}
				if (state == VisibilityState.Hiding)
				{
					visibilityState = VisibilityState.Hidden;
				}
			}
			for (int i = startIndex; i < startIndex + length; i++)
			{
				VisibilityState visibilityState2 = visibilityStates[i];
				if (visibilityState == visibilityState2)
				{
					continue;
				}
				if (!flag)
				{
					switch (visibilityState)
					{
					case VisibilityState.Shown:
						Show(i);
						break;
					case VisibilityState.Hidden:
						Hide(i);
						break;
					default:
						throw new ArgumentException("state");
					}
				}
				visibilityStates[i] = visibilityState;
				this.VisibilityStateUpdated?.Invoke(i, visibilityState2);
			}
			if (!flag && Text.mesh != null)
			{
				Text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
			}
		}

		public void SetVisibilityState(CharData cData, VisibilityState state)
		{
			SetVisibilityState(cData.info.index, 1, state);
		}

		public void SetVisibilityState(int index, VisibilityState state)
		{
			SetVisibilityState(index, 1, state);
		}

		public void SetText(string text)
		{
			settingText = true;
			Text.SetText(text);
		}

		internal void ApplyMesh(CharData cData)
		{
			int index = cData.info.index;
			TMP_TextInfo textInfo = Text.textInfo;
			TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[cData.info.index];
			int vertexIndex = tMP_CharacterInfo.vertexIndex;
			int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
			Color32[] colors = textInfo.meshInfo[materialReferenceIndex].colors32;
			Vector3[] vertices = textInfo.meshInfo[materialReferenceIndex].vertices;
			Vector4[] uvs = textInfo.meshInfo[materialReferenceIndex].uvs0;
			Vector2[] uvs2 = textInfo.meshInfo[materialReferenceIndex].uvs2;
			for (int i = 0; i < 4; i++)
			{
				vertices[vertexIndex + i] = CharData[index].mesh.GetPosition(i);
				colors[vertexIndex + i] = CharData[index].mesh.GetColor(i);
				Vector4 vector = uvs[vertexIndex + i];
				Vector2 uV = CharData[index].mesh.GetUV0(i);
				vector.x = uV.x;
				vector.y = uV.y;
				uvs[vertexIndex + i] = vector;
				uvs2[vertexIndex + i] = CharData[index].mesh.GetUV2(i);
			}
		}

		private void OnTextChanged(UnityEngine.Object obj)
		{
			if (!(Text == null) && obj as TMP_Text == Text)
			{
				TextChangedProcedure();
			}
		}

		private void TextChangedProcedure()
		{
			Processor.AdjustIndices();
			ReadOnlyCollection<CharData> readOnlyCollection = new ReadOnlyCollection<CharData>(new List<CharData>(charData));
			PopulateCharData();
			bool flag = settingText || CompareCharData(readOnlyCollection);
			settingText = false;
			this.TextChanged_Early?.Invoke(flag, readOnlyCollection);
			ReadOnlyCollection<VisibilityState> readOnlyCollection2 = new ReadOnlyCollection<VisibilityState>(new List<VisibilityState>(VisibilityStates));
			if (!flag)
			{
				for (int i = 0; i < readOnlyCollection2.Count; i++)
				{
					if (readOnlyCollection2[i] == VisibilityState.Hidden)
					{
						visibilityStates[i] = VisibilityState.Shown;
						SetVisibilityState(i, VisibilityState.Hidden);
					}
					else
					{
						visibilityStates[i] = readOnlyCollection2[i];
					}
				}
			}
			else
			{
				ResetVisibilityStates();
			}
			this.TextChanged_Late?.Invoke(flag, readOnlyCollection, readOnlyCollection2);
		}

		private bool CompareCharData(ReadOnlyCollection<CharData> oldData)
		{
			if (oldData.Count == CharData.Count)
			{
				for (int i = 0; i < oldData.Count; i++)
				{
					if (oldData[i].info.character != CharData[i].info.character)
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		private void SetPreprocessor()
		{
			Text.textPreprocessor = Processor;
		}

		private void UnsetPreprocessor()
		{
			if (Text.textPreprocessor == Processor)
			{
				Text.textPreprocessor = null;
			}
		}

		private void PopulateCharData()
		{
			charData.Clear();
			int num = -1;
			TMP_TextInfo textInfo = Text.textInfo;
			for (int i = 0; i < textInfo.characterCount; i++)
			{
				TMP_CharacterInfo cInfo = textInfo.characterInfo[i];
				TMP_WordInfo? tMP_WordInfo = null;
				int num2 = -1;
				if (cInfo.isVisible)
				{
					for (int j = ((num != -1) ? num : 0); j < textInfo.wordCount; j++)
					{
						tMP_WordInfo = textInfo.wordInfo[j];
						if (tMP_WordInfo.Value.firstCharacterIndex <= i && tMP_WordInfo.Value.lastCharacterIndex >= i)
						{
							num2 = j;
							num = num2;
							break;
						}
					}
				}
				if (num2 == -1)
				{
					num2 = ((num != -1) ? num : 0);
				}
				CharData item = ((!tMP_WordInfo.HasValue) ? new CharData(i, cInfo, num2) : new CharData(i, cInfo, num2, tMP_WordInfo.Value));
				charData.Add(item);
			}
			charData.TrimExcess();
		}

		private void ResetVisibilityStates()
		{
			visibilityStates.Clear();
			for (int i = 0; i < Text.textInfo.characterCount; i++)
			{
				visibilityStates.Add(VisibilityState.Shown);
			}
		}

		private void Hide(int index)
		{
			CharData charData = this.charData[index];
			if (charData.info.isVisible)
			{
				for (int i = 0; i < 4; i++)
				{
					charData.mesh.SetPosition(i, Vector3.zero);
				}
				ApplyMesh(charData);
			}
		}

		private void Show(int index)
		{
			CharData charData = this.charData[index];
			if (charData.info.isVisible)
			{
				for (int i = 0; i < 4; i++)
				{
					charData.mesh.SetPosition(i, charData.mesh.initial.GetPosition(i));
				}
				ApplyMesh(charData);
			}
		}
	}
}
