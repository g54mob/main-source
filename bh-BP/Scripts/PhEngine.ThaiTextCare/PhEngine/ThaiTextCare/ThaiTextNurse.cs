using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace PhEngine.ThaiTextCare
{
	[RequireComponent(typeof(TMP_Text))]
	[ExecuteAlways]
	public class ThaiTextNurse : MonoBehaviour, ITextPreprocessor
	{
		[CompilerGenerated]
		private sealed class _003CRebuildDictionaryAsync_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action<float> onProgress;

			public Action onFail;

			public bool isUpdateNursesInScene;

			private string _003Cpath_003E5__2;

			private ResourceRequest _003Crequest_003E5__3;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRebuildDictionaryAsync_003Ed__60(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private ThaiGlyphCorrection correction;

		[Tooltip("Force inject <line-height=100%> tag to the output string to fix the issue where line spacing increase as you modify the Glyph adjusment Y offset.")]
		[SerializeField]
		private bool isForceFullLineHeight;

		[SerializeField]
		private bool isTokenize;

		[SerializeField]
		private string separator;

		[SerializeField]
		private TMP_Text tmpText;

		[SerializeField]
		[HideInInspector]
		private string lastKnownText;

		[SerializeField]
		[HideInInspector]
		private string outputString;

		[SerializeField]
		[HideInInspector]
		private int lastWordCount;

		public WordBreakGUIMode guiMode;

		public Color guiColor;

		private static PhTokenizer tokenizer;

		private bool isRebuildRequired;

		[SerializeField]
		[HideInInspector]
		private bool isInitialized;

		public ThaiGlyphCorrection Correction
		{
			get
			{
				return default(ThaiGlyphCorrection);
			}
			set
			{
			}
		}

		public bool IsForceFullLineHeight
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsTokenize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string Separator
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TMP_Text TextComponent => null;

		public string OutputString => null;

		public int LastWordCount => 0;

		public int CharacterInfoLength => 0;

		public static bool IsDictionaryLoaded { get; private set; }

		public event Action<TokenizeResult> OnTokenized
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

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		public void NotifyChange()
		{
		}

		public string PreprocessText(string text)
		{
			return null;
		}

		private string RebuildOutputString(string text)
		{
			return null;
		}

		private string Tokenize()
		{
			return null;
		}

		private TMP_CharacterInfo GetCharacterInfo(int index)
		{
			return default(TMP_CharacterInfo);
		}

		private bool IsShouldDrawGizmos()
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}

		public static string SafeTokenize(string input)
		{
			return null;
		}

		public static string SafeTokenize(TokenizeRequest request)
		{
			return null;
		}

		public static bool TryTokenize(string input, out TokenizeResult result)
		{
			result = null;
			return false;
		}

		public static bool TryTokenize(TokenizeRequest tokenizeRequest, out TokenizeResult result)
		{
			result = null;
			return false;
		}

		public static string GetWordBreakCharacter(ThaiTextCareSettings settings)
		{
			return null;
		}

		public static void RebuildDictionary(bool isUpdateNursesInScene = true)
		{
		}

		public static void UpdateAllNursesInScene()
		{
		}

		public static void EnableAllTokenizerInScene()
		{
		}

		public static void DisableAllTokenizerInScene()
		{
		}

		[IteratorStateMachine(typeof(_003CRebuildDictionaryAsync_003Ed__60))]
		public static IEnumerator RebuildDictionaryAsync(bool isUpdateNursesInScene = true, Action<float> onProgress = null, Action onFail = null)
		{
			return null;
		}

		private static bool TryRebuildDictionary(ThaiTextCareSettings settings)
		{
			return false;
		}

		public static bool TryLoadDictionaryAsset(ThaiTextCareSettings settings, out TextAsset textAsset)
		{
			textAsset = null;
			return false;
		}

		public static string GetDictionaryPath(ThaiTextCareSettings settings)
		{
			return null;
		}

		private static void RebuildTokenizer(TextAsset textAsset)
		{
		}

		public static string[] WordsFromDictionary(TextAsset textAsset)
		{
			return null;
		}

		public static void VisualizeInEditor(ThaiTextNurse nurse)
		{
		}
	}
}
