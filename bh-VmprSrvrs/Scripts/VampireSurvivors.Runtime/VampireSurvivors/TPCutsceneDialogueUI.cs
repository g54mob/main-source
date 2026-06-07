using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors
{
	public class TPCutsceneDialogueUI : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CHideCharacterPortrait_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene.DialogueCharacter characterToHide;

			public TPCutsceneDialogueUI _003C_003E4__this;

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
			public _003CHideCharacterPortrait_003Ed__42(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CHideDialoguePanelOnDialogueFinished_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCutsceneDialogueUI _003C_003E4__this;

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
			public _003CHideDialoguePanelOnDialogueFinished_003Ed__38(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CLetterBoxFadeTransition_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCutsceneDialogueUI _003C_003E4__this;

			public float startAlpha;

			public float endAlpha;

			public float duration;

			private float _003CfadeTime_003E5__2;

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
			public _003CLetterBoxFadeTransition_003Ed__37(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CPlayDialogue_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCutsceneDialogueUI _003C_003E4__this;

			public DraculaCutscene.TPCutsceneDialogue dialogue;

			public SfxType voiceOverID;

			public bool hidePortraitAtEnd;

			private DraculaCutscene.DialogueCharacter _003CspeakingCharacter_003E5__2;

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
			public _003CPlayDialogue_003Ed__39(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CScaleTransform_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Transform transformToScale;

			public Vector3 startScale;

			public Vector3 endScale;

			public float duration;

			private float _003CscaleTime_003E5__2;

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
			public _003CScaleTransform_003Ed__43(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CScrollText_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCutsceneDialogueUI _003C_003E4__this;

			private float _003CstartLineOffset_003E5__2;

			private float _003CendLineOffset_003E5__3;

			private float _003ClineScrollTimer_003E5__4;

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
			public _003CScrollText_003Ed__45(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CShow_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCutsceneDialogueUI _003C_003E4__this;

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
			public _003CShow_003Ed__35(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CShowCharacterPortrait_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DraculaCutscene.DialogueCharacter speakingCharacter;

			public TPCutsceneDialogueUI _003C_003E4__this;

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
			public _003CShowCharacterPortrait_003Ed__41(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CShowDialoguePanel_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCutsceneDialogueUI _003C_003E4__this;

			private float _003CbloodFadeTimer_003E5__2;

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
			public _003CShowDialoguePanel_003Ed__40(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CShowDialogueText_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TPCutsceneDialogueUI _003C_003E4__this;

			public DraculaCutscene.TPCutsceneDialogue dialogue;

			private float _003CdialogueTimer_003E5__2;

			private int _003CtotalCharacters_003E5__3;

			private int _003CvisibleLineIndex_003E5__4;

			private TMP_LineInfo[] _003ClineInfo_003E5__5;

			private int _003CcharactersShownBeforeLineChange_003E5__6;

			private float _003CdelayBetweenTextCharacters_003E5__7;

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
			public _003CShowDialogueText_003Ed__44(int _003C_003E1__state)
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
		private RectTransform _DialoguePanelTransform;

		[SerializeField]
		private float _DialoguePanelScaleOutDuration;

		[SerializeField]
		private CanvasGroup _BackgroundCanvasGroup;

		[SerializeField]
		private CanvasGroup _BloodOverlayCanvasGroup;

		[SerializeField]
		private float _BloodScaleInDuration;

		[SerializeField]
		private float _BloodFadeOutDuration;

		[SerializeField]
		private CanvasGroup _LetterBoxCanvasGroup;

		[SerializeField]
		private float _LetterBoxTransitionInTime;

		[SerializeField]
		private float _LetterBoxTransitionOutTime;

		[Header("Dialogue")]
		[SerializeField]
		private TextMeshProUGUI _CharacterNameText;

		[SerializeField]
		private TextMeshProUGUI _DialogueText;

		[SerializeField]
		private float _DelayBeforeStartDialogue;

		[SerializeField]
		private float _DelayBetweenTextCharacters;

		[SerializeField]
		private float _LineScrollYOffsetPerLine;

		[SerializeField]
		private float _LineScrollDuration;

		[SerializeField]
		private float _DelayAfterDialogueFinished;

		[Header("Portraits")]
		[SerializeField]
		private Image _DraculaPortraitImage;

		[SerializeField]
		private Image _RichterPortraitImage;

		[SerializeField]
		private Image _DeathPortraitImage;

		[SerializeField]
		private float _portraitScaleOutDuration;

		[SerializeField]
		private float _portraitScaleInDuration;

		private Vector3 _dialoguePanelStartScale;

		private DraculaCutscene.DialogueCharacter _currentCharacter;

		private Material _dialogueTextMaterial;

		private static readonly int VertexOffsetY;

		private const string RichterName = "characterLang/{TP_RICHTER}charName";

		private const string DraculaName = "characterLang/{TP_DRACULA}charName";

		private const string DeathName = "characterLang/{TP_DEATH}charName";

		private Coroutine _scrollTextCoroutine;

		private Coroutine _letterBoxTransitionCoroutine;

		private bool _skipDialogue;

		private bool _letterBoxShowing;

		public void InitDialogue(ref DraculaCutscene.TPCutsceneDialogue[] dialogue)
		{
		}

		public void Init()
		{
		}

		public void SkipDialogue()
		{
		}

		[IteratorStateMachine(typeof(_003CShow_003Ed__35))]
		public IEnumerator Show()
		{
			return null;
		}

		public void ShowLetterBox()
		{
		}

		[IteratorStateMachine(typeof(_003CLetterBoxFadeTransition_003Ed__37))]
		private IEnumerator LetterBoxFadeTransition(float startAlpha, float endAlpha, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHideDialoguePanelOnDialogueFinished_003Ed__38))]
		public IEnumerator HideDialoguePanelOnDialogueFinished()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPlayDialogue_003Ed__39))]
		public IEnumerator PlayDialogue(DraculaCutscene.TPCutsceneDialogue dialogue, bool hidePortraitAtEnd = false, SfxType voiceOverID = SfxType.None)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CShowDialoguePanel_003Ed__40))]
		private IEnumerator ShowDialoguePanel()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CShowCharacterPortrait_003Ed__41))]
		private IEnumerator ShowCharacterPortrait(DraculaCutscene.DialogueCharacter speakingCharacter)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHideCharacterPortrait_003Ed__42))]
		private IEnumerator HideCharacterPortrait(DraculaCutscene.DialogueCharacter characterToHide)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CScaleTransform_003Ed__43))]
		private IEnumerator ScaleTransform(Transform transformToScale, Vector3 startScale, Vector3 endScale, float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CShowDialogueText_003Ed__44))]
		private IEnumerator ShowDialogueText(DraculaCutscene.TPCutsceneDialogue dialogue)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CScrollText_003Ed__45))]
		private IEnumerator ScrollText()
		{
			return null;
		}

		private Transform GetPortraitTransformForCharacter(DraculaCutscene.DialogueCharacter character)
		{
			return null;
		}

		private void OnDestroy()
		{
		}
	}
}
