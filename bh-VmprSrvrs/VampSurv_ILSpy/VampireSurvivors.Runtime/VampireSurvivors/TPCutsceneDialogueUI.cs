using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors;

public class TPCutsceneDialogueUI : MonoBehaviour
{
	private sealed class _003CHideCharacterPortrait_003Ed__42(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene.DialogueCharacter characterToHide;

		public TPCutsceneDialogueUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_017e: Expected I4, but got I8
			//IL_0191: Expected I4, but got O
			//IL_00ac: Expected O, but got I
			//IL_00bc: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_0110: Expected O, but got I
			//IL_01a5: Expected I, but got O
			//IL_01c3: Expected I, but got O
			TPCutsceneDialogueUI tPCutsceneDialogueUI = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (characterToHide != (DraculaCutscene.DialogueCharacter)_003C_003E1__state)
				{
					if ((object)_003C_003E4__this != null && (object)tPCutsceneDialogueUI._CharacterNameText != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v5+B8]");
						object text = 0;
						tPCutsceneDialogueUI._CharacterNameText.text = (string)text;
						if ((object)tPCutsceneDialogueUI._DialogueText != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v7+B8]");
							object text2 = 0;
							tPCutsceneDialogueUI._DialogueText.text = (string)text2;
							Transform portraitTransformForCharacter = _003C_003E4__this.GetPortraitTransformForCharacter(characterToHide);
							nint num = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num2 = 0;
							nint num3 = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num4 = 0;
							_003CScaleTransform_003Ed__43 obj3 = null;
							obj3.transformToScale = portraitTransformForCharacter;
							obj3._003C_003E1__state = 0;
							obj3.startScale = Vector3.oneVector;
							obj3.endScale = Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rdx_v7 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
							_ = 0;
							obj3.duration = tPCutsceneDialogueUI._portraitScaleOutDuration;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							_ = 0;
							_003C_003E2__current = obj3;
							_003C_003E1__state = 1;
							return true;
						}
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CHideDialoguePanelOnDialogueFinished_003Ed__38(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCutsceneDialogueUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_011e: Expected I4, but got I8
			//IL_0131: Expected I4, but got O
			TPCutsceneDialogueUI tPCutsceneDialogueUI = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					if ((tPCutsceneDialogueUI._letterBoxShowing ? 1 : 0) != _003C_003E1__state)
					{
						IEnumerator routine = _003C_003E4__this.LetterBoxFadeTransition(1f, 0f, tPCutsceneDialogueUI._LetterBoxTransitionOutTime);
						Coroutine letterBoxTransitionCoroutine = _003C_003E4__this.StartCoroutine(routine);
						tPCutsceneDialogueUI._letterBoxTransitionCoroutine = letterBoxTransitionCoroutine;
					}
					tPCutsceneDialogueUI._currentCharacter = DraculaCutscene.DialogueCharacter.None;
					_003CScaleTransform_003Ed__43 obj = null;
					obj.transformToScale = tPCutsceneDialogueUI._DialoguePanelTransform;
					obj._003C_003E1__state = 0;
					Vector3 endScale = default(Vector3);
					obj.endScale = endScale;
					obj.startScale = tPCutsceneDialogueUI._dialoguePanelStartScale;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbx_v1 (VampireSurvivors.TPCutsceneDialogueUI)+A8]");
					_ = 0;
					obj.duration = tPCutsceneDialogueUI._DialoguePanelScaleOutDuration;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rbx_v1 (VampireSurvivors.TPCutsceneDialogueUI)+A8]");
					_ = 0;
					_003C_003E2__current = obj;
					_003C_003E1__state = 1;
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CLetterBoxFadeTransition_003Ed__37(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCutsceneDialogueUI _003C_003E4__this;

		public float startAlpha;

		public float endAlpha;

		public float duration;

		private float _003CfadeTime_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0038: Expected F4, but got I4
			//IL_006e: Expected I4, but got I8
			//IL_020e: Expected I4, but got O
			//IL_00ee: Invalid comparison between I4 and F4
			//IL_0139: Expected F4, but got I4
			TPCutsceneDialogueUI tPCutsceneDialogueUI = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003CfadeTime_003E5__2 = _003C_003E1__state;
			}
			else if (_003C_003E1__state != 1)
			{
				goto IL_01fa;
			}
			_003C_003E1__state = -1;
			if (duration > _003CfadeTime_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				float num = (_003CfadeTime_003E5__2 = deltaTime + _003CfadeTime_003E5__2);
				if ((object)_003C_003E4__this != null)
				{
					float num2 = num / duration;
					if (!(0f > num2))
					{
						if (num2 > 1f)
						{
							num2 = 1f;
						}
					}
					else
					{
						num2 = 0f;
					}
					if ((object)tPCutsceneDialogueUI._LetterBoxCanvasGroup != null)
					{
						float num3 = endAlpha - startAlpha;
						float num4 = num3 * num2;
						float alpha = num4 + startAlpha;
						tPCutsceneDialogueUI._LetterBoxCanvasGroup.alpha = alpha;
						_003C_003E2__current = null;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			else if ((object)_003C_003E4__this != null && (object)tPCutsceneDialogueUI._LetterBoxCanvasGroup != null)
			{
				tPCutsceneDialogueUI._LetterBoxCanvasGroup.alpha = endAlpha;
				goto IL_01fa;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_01fa:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CPlayDialogue_003Ed__39(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCutsceneDialogueUI _003C_003E4__this;

		public DraculaCutscene.TPCutsceneDialogue dialogue;

		public SfxType voiceOverID;

		public bool hidePortraitAtEnd;

		private DraculaCutscene.DialogueCharacter _003CspeakingCharacter_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 59 Invalid \"Jump target not found in method: 0x187366176\"");
			return (byte)_003C_003E1__state != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CScaleTransform_003Ed__43(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public Transform transformToScale;

		public Vector3 startScale;

		public Vector3 endScale;

		public float duration;

		private float _003CscaleTime_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_0091: Expected I4, but got I8
			//IL_00de: Invalid comparison between I4 and F4
			//IL_0129: Expected F4, but got I4
			//IL_01a2->IL0240: Incompatible stack heights: 2 vs 0
			//IL_0240->IL01a2: Incompatible stack heights: 1 vs 0
			if (_003C_003E1__state == 0)
			{
				Transform transform = transformToScale;
				_003C_003E1__state = -1;
				bool flag = (object)transformToScale == null;
				bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				_003CscaleTime_003E5__2 = 0f;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_01a2;
				}
				_003C_003E1__state = -1;
			}
			Vector3 value2 = default(Vector3);
			if (duration > _003CscaleTime_003E5__2)
			{
				float deltaTime = PauseSystem.DeltaTime;
				object obj = transformToScale;
				float num = (_003CscaleTime_003E5__2 = deltaTime + _003CscaleTime_003E5__2) / duration;
				if (!(0f > num))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				bool flag3 = (object)transformToScale == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rsi_v5 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rsi_v5 (System.Object)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref value2);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			Transform transform2 = transformToScale;
			bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
			goto IL_01a2;
			IL_01a2:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CScrollText_003Ed__45(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCutsceneDialogueUI _003C_003E4__this;

		private float _003CstartLineOffset_003E5__2;

		private float _003CendLineOffset_003E5__3;

		private float _003ClineScrollTimer_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00e7: Expected I4, but got I8
			//IL_029f: Expected I4, but got O
			//IL_014b: Invalid comparison between I4 and F4
			//IL_0196: Expected F4, but got I4
			TPCutsceneDialogueUI tPCutsceneDialogueUI = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)tPCutsceneDialogueUI._DialogueText != null)
				{
					Material fontSharedMaterial = tPCutsceneDialogueUI._DialogueText.fontSharedMaterial;
					if ((object)fontSharedMaterial != null)
					{
						float num = (_003CstartLineOffset_003E5__2 = fontSharedMaterial.GetFloatImpl(VertexOffsetY)) + tPCutsceneDialogueUI._LineScrollYOffsetPerLine;
						_003ClineScrollTimer_003E5__4 = 0f;
						_003CendLineOffset_003E5__3 = num;
						goto IL_0106;
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0283;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_0106;
				}
			}
			goto IL_0291;
			IL_0106:
			if (tPCutsceneDialogueUI._LineScrollDuration > _003ClineScrollTimer_003E5__4)
			{
				float num2 = _003ClineScrollTimer_003E5__4 / tPCutsceneDialogueUI._LineScrollDuration;
				if (!(0f > num2))
				{
					if (num2 > 1f)
					{
						num2 = 1f;
					}
				}
				else
				{
					num2 = 0f;
				}
				TextMeshProUGUI dialogueText = tPCutsceneDialogueUI._DialogueText;
				float num3 = _003CendLineOffset_003E5__3 - _003CstartLineOffset_003E5__2;
				float num4 = num3 * num2;
				float value = num4 + _003CstartLineOffset_003E5__2;
				if ((object)tPCutsceneDialogueUI._DialogueText != null)
				{
					Material material = tPCutsceneDialogueUI._DialogueText.GetMaterial(((TMP_Text)dialogueText).m_sharedMaterial);
					if ((object)material != null)
					{
						material.SetFloatImpl(VertexOffsetY, value);
						float deltaTime = PauseSystem.DeltaTime;
						float num5 = deltaTime + _003ClineScrollTimer_003E5__4;
						_003C_003E2__current = null;
						_003ClineScrollTimer_003E5__4 = num5;
						_003C_003E1__state = 1;
						return true;
					}
				}
			}
			else
			{
				TextMeshProUGUI dialogueText2 = tPCutsceneDialogueUI._DialogueText;
				if ((object)tPCutsceneDialogueUI._DialogueText != null)
				{
					Material material2 = tPCutsceneDialogueUI._DialogueText.GetMaterial(((TMP_Text)dialogueText2).m_sharedMaterial);
					if ((object)material2 != null)
					{
						material2.SetFloatImpl(VertexOffsetY, _003CendLineOffset_003E5__3);
						goto IL_0283;
					}
				}
			}
			goto IL_0291;
			IL_0291:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0283:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CShow_003Ed__35(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCutsceneDialogueUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_0097: Expected I4, but got I8
			//IL_00aa: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003CShowDialoguePanel_003Ed__40 obj = null;
				obj._003C_003E1__state = 0;
				obj._003C_003E4__this = _003C_003E4__this;
				_003C_003E2__current = obj;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CShowCharacterPortrait_003Ed__41(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public DraculaCutscene.DialogueCharacter speakingCharacter;

		public TPCutsceneDialogueUI _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_003b: Expected I4, but got I8
			//IL_00bc: Expected I4, but got I8
			//IL_00e3: Expected I, but got O
			//IL_011e: Expected I, but got O
			//IL_00cf: Expected I4, but got O
			TPCutsceneDialogueUI tPCutsceneDialogueUI = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (speakingCharacter != (DraculaCutscene.DialogueCharacter)_003C_003E1__state)
				{
					nint num = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					Transform portraitTransformForCharacter = default(Transform);
					if (speakingCharacter != DraculaCutscene.DialogueCharacter.Richter)
					{
						if ((object)_003C_003E4__this == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						portraitTransformForCharacter = _003C_003E4__this.GetPortraitTransformForCharacter(speakingCharacter);
					}
					nint num3 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v8 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num4 = 0;
					_003CScaleTransform_003Ed__43 obj = null;
					obj.transformToScale = portraitTransformForCharacter;
					obj._003C_003E1__state = 0;
					obj.startScale = Vector3.zeroVector;
					Vector3 endScale = default(Vector3);
					obj.endScale = endScale;
					obj.duration = tPCutsceneDialogueUI._portraitScaleInDuration;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v2 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					_ = 0;
					_003C_003E2__current = obj;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CShowDialoguePanel_003Ed__40(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCutsceneDialogueUI _003C_003E4__this;

		private float _003CbloodFadeTimer_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0253: Expected I4, but got I8
			//IL_0039: Expected O, but got I4
			//IL_00a9: Expected I4, but got I8
			//IL_0076: Expected I4, but got I8
			//IL_012c: Invalid comparison between I4 and F4
			//IL_0177: Expected F4, but got I4
			//IL_03f2->IL0345: Incompatible stack heights: 1 vs 0
			//IL_02db->IL0345: Incompatible stack heights: 1 vs 0
			//IL_0310->IL0345: Incompatible stack heights: 1 vs 0
			//IL_0345->IL03a0: Incompatible stack heights: 1 vs 0
			TPCutsceneDialogueUI tPCutsceneDialogueUI = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj != 1)
					{
						goto IL_0236;
					}
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this == null)
					{
						goto IL_0351;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					if ((object)_003C_003E4__this == null || (object)tPCutsceneDialogueUI._BackgroundCanvasGroup == null)
					{
						goto IL_0351;
					}
					tPCutsceneDialogueUI._BackgroundCanvasGroup.alpha = 1f;
					_003CbloodFadeTimer_003E5__2 = 0f;
				}
				if (tPCutsceneDialogueUI._BloodFadeOutDuration > _003CbloodFadeTimer_003E5__2)
				{
					float num = _003CbloodFadeTimer_003E5__2 / tPCutsceneDialogueUI._BloodFadeOutDuration;
					if (!(0f > num))
					{
						if (num > 1f)
						{
							num = 1f;
						}
					}
					else
					{
						num = 0f;
					}
					if ((object)tPCutsceneDialogueUI._BloodOverlayCanvasGroup != null)
					{
						float num2 = num * -1f;
						float alpha = num2 + 1f;
						tPCutsceneDialogueUI._BloodOverlayCanvasGroup.alpha = alpha;
						float deltaTime = PauseSystem.DeltaTime;
						float num3 = deltaTime + _003CbloodFadeTimer_003E5__2;
						_003C_003E2__current = null;
						_003CbloodFadeTimer_003E5__2 = num3;
						_003C_003E1__state = 2;
						return true;
					}
				}
				else if ((object)tPCutsceneDialogueUI._BloodOverlayCanvasGroup != null)
				{
					tPCutsceneDialogueUI._BloodOverlayCanvasGroup.alpha = 0f;
					goto IL_0236;
				}
				goto IL_0351;
			}
			_003C_003E1__state = -1;
			if ((object)_003C_003E4__this != null)
			{
				RectTransform dialoguePanelTransform = tPCutsceneDialogueUI._DialoguePanelTransform;
				if ((object)tPCutsceneDialogueUI._DialoguePanelTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)dialoguePanelTransform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)dialoguePanelTransform).m_CachedPtr, ref value);
					if ((object)tPCutsceneDialogueUI._BloodOverlayCanvasGroup != null)
					{
						tPCutsceneDialogueUI._BloodOverlayCanvasGroup.alpha = 1f;
						if ((object)tPCutsceneDialogueUI._BackgroundCanvasGroup != null)
						{
							tPCutsceneDialogueUI._BackgroundCanvasGroup.alpha = 0f;
							if ((object)tPCutsceneDialogueUI._BloodOverlayCanvasGroup != null)
							{
								Transform transform = tPCutsceneDialogueUI._BloodOverlayCanvasGroup.transform;
								_003CScaleTransform_003Ed__43 obj2 = null;
								obj2._003C_003E1__state = 0;
								obj2.transformToScale = transform;
								obj2.duration = tPCutsceneDialogueUI._BloodScaleInDuration;
								Vector3 vector = default(Vector3);
								obj2.startScale = vector;
								obj2.endScale = vector;
								_ = 1f;
								_ = 1f;
								_003C_003E2__current = obj2;
								_003C_003E1__state = 1;
								return true;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
			IL_0236:
			return false;
			IL_0351:
			throw new NullReferenceException();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CShowDialogueText_003Ed__44(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public TPCutsceneDialogueUI _003C_003E4__this;

		public DraculaCutscene.TPCutsceneDialogue dialogue;

		private float _003CdialogueTimer_003E5__2;

		private int _003CtotalCharacters_003E5__3;

		private int _003CvisibleLineIndex_003E5__4;

		private TMP_LineInfo[] _003ClineInfo_003E5__5;

		private int _003CcharactersShownBeforeLineChange_003E5__6;

		private float _003CdelayBetweenTextCharacters_003E5__7;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_00b3: Expected I4, but got I8
			//IL_00d3: Expected O, but got I
			//IL_0015: Expected O, but got I4
			//IL_0117: Expected O, but got I
			//IL_009f: Expected I4, but got I8
			//IL_05bb: Invalid comparison between I and F4
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_014e: Expected O, but got I
			//IL_008b: Expected I4, but got I8
			//IL_0164: Expected O, but got I
			//IL_0512: Expected F4, but got I
			//IL_029e: Expected O, but got I4
			//IL_019d: Expected O, but got I
			//IL_04e4: Invalid comparison between I and F4
			//IL_02b3: Expected O, but got I
			//IL_006e: Expected I4, but got I8
			//IL_0496: Expected O, but got I
			//IL_01d7: Expected F4, but got I
			//IL_01fb: Expected F4, but got I4
			//IL_0204: Expected O, but got I4
			//IL_0233: Expected F4, but got I4
			//IL_023c: Expected F4, but got I4
			//IL_0245: Expected O, but got I4
			//IL_0601: Expected I4, but got O
			//IL_036d: Expected O, but got I4
			//IL_0377: Unknown result type (might be due to invalid IL or missing references)
			//IL_037c: Expected O, but got Unknown
			MonoBehaviour monoBehaviour = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 == 1)
						{
							_003C_003E1__state = -1;
							return false;
						}
						goto IL_049b;
					}
					_003C_003E1__state = -1;
					goto IL_04f8;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				_003CdialogueTimer_003E5__2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+60]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.TPCutsceneDialogueUI+<ShowDialogueText>d__44)+40]");
				int num = 0;
				LocalizedString localizedString = default(LocalizedString);
				string text = localizedString.ToString();
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v97 @ r9_v11+558] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+60]");
				object obj5 = 0;
				object obj6 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v548 @ rax_v52+7D8] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+B0]");
				((Material)0).SetFloatImpl(VertexOffsetY, 0f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+60]");
				TMP_TextInfo textInfo = ((TMP_Text)0).textInfo;
				_003CtotalCharacters_003E5__3 = textInfo.characterCount;
				_003CvisibleLineIndex_003E5__4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+60]");
				TMP_TextInfo textInfo2 = ((TMP_Text)0).textInfo;
				_003ClineInfo_003E5__5 = textInfo2.lineInfo;
				_003CcharactersShownBeforeLineChange_003E5__6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+6C]");
				_003CdelayBetweenTextCharacters_003E5__7 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.TPCutsceneDialogueUI+<ShowDialogueText>d__44)+4C]");
				bool flag2 = (nint)0 >= (nint)_003CtotalCharacters_003E5__3;
				float num2 = 0f;
				object obj7 = 0;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.TPCutsceneDialogueUI+<ShowDialogueText>d__44)+48]");
					num = (int)((nint)0 / (nint)_003CtotalCharacters_003E5__3);
					_003CdelayBetweenTextCharacters_003E5__7 = num;
					num2 = 0f;
					obj7 = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.TPCutsceneDialogueUI+<ShowDialogueText>d__44)+48]");
			if (0f > _003CdialogueTimer_003E5__2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45AC0");
				object obj8 = default(object);
				float num3 = (_003CdialogueTimer_003E5__2 = (float)obj8 + _003CdialogueTimer_003E5__2) / _003CdelayBetweenTextCharacters_003E5__7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
				int num4 = default(int);
				object obj9 = num4 - _003CcharactersShownBeforeLineChange_003E5__6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+60]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rcx_v10+368]");
				if ((nint)0 != num4)
				{
					object obj11 = obj10;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v703 @ rax_v35+2F8] (should have been resolved before IL gen)");
				}
				if (num4 < _003CtotalCharacters_003E5__3)
				{
					TMP_LineInfo[] array = _003ClineInfo_003E5__5;
					if (_003CvisibleLineIndex_003E5__4 < array.Length)
					{
						TMP_LineInfo[] array2 = _003ClineInfo_003E5__5;
						if (_003CvisibleLineIndex_003E5__4 >= array2.Length)
						{
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							return (byte)(int)ex != 0;
						}
						object obj12 = _003CvisibleLineIndex_003E5__4 * 2;
						object obj13 = _003CvisibleLineIndex_003E5__4 + obj12;
						object obj14 = obj13 << 5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v730 @ rcx_v18+24+v408 @ rdx_v10 (TMPro.TMP_LineInfo[])]");
						if ((nint)obj9 >= 0)
						{
							int num5 = _003CvisibleLineIndex_003E5__4 + 1;
							_003CcharactersShownBeforeLineChange_003E5__6 = num4;
							_003CvisibleLineIndex_003E5__4 = num5;
							if (num5 >= 4)
							{
								_003CScrollText_003Ed__45 obj15 = null;
								obj15._003C_003E1__state = 0;
								obj15._003C_003E4__this = (TPCutsceneDialogueUI)monoBehaviour;
								Coroutine coroutine = monoBehaviour.StartCoroutine(obj15);
							}
						}
					}
				}
				WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
				_003C_003E2__current = waitForFixedUpdate;
				_003C_003E1__state = 1;
				goto IL_0626;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+C8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+B8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+B8]");
					monoBehaviour.StopCoroutine((Coroutine)0);
				}
				goto IL_049b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.TPCutsceneDialogueUI+<ShowDialogueText>d__44)+4C]");
			if ((nint)0 > (nint)_003CtotalCharacters_003E5__3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.TPCutsceneDialogueUI+<ShowDialogueText>d__44)+48]");
				if (0f > _003CdialogueTimer_003E5__2)
				{
					WaitForSeconds waitForSeconds = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.TPCutsceneDialogueUI+<ShowDialogueText>d__44)+48]");
					float seconds = 0f - _003CdialogueTimer_003E5__2;
					waitForSeconds.m_Seconds = seconds;
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 2;
					goto IL_0626;
				}
			}
			goto IL_04f8;
			IL_04f8:
			WaitForSeconds waitForSeconds2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (UnityEngine.MonoBehaviour)+78]");
			waitForSeconds2.m_Seconds = 0f;
			_003C_003E2__current = waitForSeconds2;
			_003C_003E1__state = 3;
			goto IL_0626;
			IL_0626:
			return true;
			IL_049b:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private RectTransform _DialoguePanelTransform;

	private float _DialoguePanelScaleOutDuration;

	private CanvasGroup _BackgroundCanvasGroup;

	private CanvasGroup _BloodOverlayCanvasGroup;

	private float _BloodScaleInDuration;

	private float _BloodFadeOutDuration;

	private CanvasGroup _LetterBoxCanvasGroup;

	private float _LetterBoxTransitionInTime;

	private float _LetterBoxTransitionOutTime;

	private TextMeshProUGUI _CharacterNameText;

	private TextMeshProUGUI _DialogueText;

	private float _DelayBeforeStartDialogue;

	private float _DelayBetweenTextCharacters;

	private float _LineScrollYOffsetPerLine;

	private float _LineScrollDuration;

	private float _DelayAfterDialogueFinished;

	private Image _DraculaPortraitImage;

	private Image _RichterPortraitImage;

	private Image _DeathPortraitImage;

	private float _portraitScaleOutDuration;

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
		//IL_0162: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_007a: Expected O, but got I
		//IL_00d5: Expected O, but got I
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		DraculaCutscene.TPCutsceneDialogue[] array = dialogue;
		object obj = 0;
		object obj2 = 0;
		bool ignoreRTLnumbers = default(bool);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		while ((nint)obj2 < array.Length)
		{
			DraculaCutscene.TPCutsceneDialogue[] array2 = dialogue;
			object obj3 = obj + 1;
			object obj4 = obj3 * 4;
			object obj5 = obj3 + obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v4 (TPCutsceneDialogue[])+v287 @ rax_v6*8]");
			bool flag = LocalizationManager.TryGetTranslation((string)0, out var Translation, FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage);
			DraculaCutscene.TPCutsceneDialogue tPCutsceneDialogue;
			if (Translation != null)
			{
				bool flag2 = Translation._stringLength > 0;
				tPCutsceneDialogue = (DraculaCutscene.TPCutsceneDialogue)Translation;
				if (flag2)
				{
					goto IL_0175;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v4 (TPCutsceneDialogue[])+v287 @ rax_v6*8]");
			tPCutsceneDialogue = (DraculaCutscene.TPCutsceneDialogue)0;
			goto IL_0175;
			IL_0175:
			DraculaCutscene.TPCutsceneDialogue[] array3 = dialogue;
			object obj6 = obj + 1;
			object obj7 = obj * 4;
			object obj8 = obj + obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v4 (VampireSurvivors.DraculaCutscene+TPCutsceneDialogue)+10]");
			object obj9 = 0 * _DelayBetweenTextCharacters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rdx_v4 (VampireSurvivors.DraculaCutscene+TPCutsceneDialogue)+10]");
			_ = 0;
			array = dialogue;
			obj = obj6;
			obj2 = obj6;
		}
	}

	public void Init()
	{
		//IL_0162: Expected O, but got I
		//IL_0172: Expected O, but got I
		//IL_01ac: Expected O, but got I
		//IL_01bc: Expected O, but got I
		//IL_02d0->IL0280: Incompatible stack heights: 1 vs 0
		//IL_0339->IL0280: Incompatible stack heights: 2 vs 0
		//IL_0070->IL0280: Incompatible stack heights: 2 vs 0
		//IL_00a0->IL0280: Incompatible stack heights: 2 vs 0
		if ((object)this != null)
		{
			bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
			MonoBehaviour.StopAllCoroutines_Injected(((UnityEngine.Object)this).m_CachedPtr);
			RectTransform dialoguePanelTransform = _DialoguePanelTransform;
			if ((object)_DialoguePanelTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)dialoguePanelTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)dialoguePanelTransform).m_CachedPtr, out Vector3 ret);
				TextMeshProUGUI dialogueText = _DialogueText;
				_dialoguePanelStartScale = ret;
				_ = 0;
				if ((object)_DialogueText != null)
				{
					Material material = _DialogueText.GetMaterial(((TMP_Text)dialogueText).m_sharedMaterial);
					_dialogueTextMaterial = material;
					if ((object)_DialogueText != null)
					{
						_DialogueText.fontMaterial = _dialogueTextMaterial;
						if ((object)_DraculaPortraitImage != null)
						{
							Transform transform = _DraculaPortraitImage.transform;
							bool flag3 = (object)transform == null;
							bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref ret);
							bool flag5 = (object)_RichterPortraitImage == null;
							Transform transform2 = _RichterPortraitImage.transform;
							bool flag6 = (object)transform2 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ rax_v68 (UnityEngine.Transform)+10]");
							bool flag7 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ rax_v68 (UnityEngine.Transform)+10]");
							Vector3 value = default(Vector3);
							Transform.set_localScale_Injected((IntPtr)0, ref value);
							bool flag8 = (object)_DeathPortraitImage == null;
							Transform transform3 = _DeathPortraitImage.transform;
							bool flag9 = (object)transform3 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rax_v76 (UnityEngine.Transform)+10]");
							bool flag10 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1097 @ rax_v76 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref ret);
							object dialoguePanelTransform2 = _DialoguePanelTransform;
							bool flag11 = (object)_DialoguePanelTransform == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rdi_v25 (System.Object)+10]");
							bool flag12 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rdi_v25 (System.Object)+10]");
							Vector3 value2 = default(Vector3);
							Transform.set_localScale_Injected((IntPtr)0, ref value2);
							bool flag13 = (object)_BackgroundCanvasGroup == null;
							_BackgroundCanvasGroup.alpha = 0f;
							bool flag14 = (object)_BloodOverlayCanvasGroup == null;
							Transform transform4 = _BloodOverlayCanvasGroup.transform;
							bool flag15 = (object)transform4 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1415 @ rax_v90 (UnityEngine.Transform)+10]");
							bool flag16 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1415 @ rax_v90 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref value);
							bool flag17 = (object)_DialogueText == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1468 @ rax_v98+B8]");
							object text = 0;
							_DialogueText.text = (string)text;
							bool flag18 = (object)_CharacterNameText == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1470 @ rax_v100+B8]");
							object text2 = 0;
							_CharacterNameText.text = (string)text2;
							TextMeshProUGUI dialogueText2 = _DialogueText;
							bool flag19 = (object)_DialogueText == null;
							if (((TMP_Text)dialogueText2).m_HorizontalAlignment != HorizontalAlignmentOptions.Left || ((TMP_Text)dialogueText2).m_VerticalAlignment != VerticalAlignmentOptions.Top)
							{
								((TMP_Text)dialogueText2).m_HorizontalAlignment = HorizontalAlignmentOptions.Left;
								((TMP_Text)dialogueText2).m_VerticalAlignment = VerticalAlignmentOptions.Top;
								((TMP_Text)dialogueText2).m_havePropertiesChanged = true;
								_DialogueText.SetVerticesDirty();
							}
							GameObject gameObject = base.gameObject;
							bool flag20 = (object)gameObject == null;
							gameObject.SetActive(value: true);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void SkipDialogue()
	{
		_skipDialogue = true;
	}

	public IEnumerator Show()
	{
		_003CShow_003Ed__35 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public void ShowLetterBox()
	{
		IEnumerator routine = LetterBoxFadeTransition(0f, 1f, _LetterBoxTransitionInTime);
		Coroutine letterBoxTransitionCoroutine = StartCoroutine(routine);
		_letterBoxTransitionCoroutine = letterBoxTransitionCoroutine;
		_letterBoxShowing = true;
	}

	private IEnumerator LetterBoxFadeTransition(float startAlpha, float endAlpha, float duration)
	{
		_003CLetterBoxFadeTransition_003Ed__37 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.startAlpha = startAlpha;
		obj.endAlpha = endAlpha;
		obj.duration = duration;
		return obj;
	}

	public IEnumerator HideDialoguePanelOnDialogueFinished()
	{
		_003CHideDialoguePanelOnDialogueFinished_003Ed__38 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public IEnumerator PlayDialogue(DraculaCutscene.TPCutsceneDialogue dialogue, bool hidePortraitAtEnd = false, SfxType voiceOverID = SfxType.None)
	{
		//IL_0058: Expected O, but got I4
		_003CPlayDialogue_003Ed__39 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.dialogue = (DraculaCutscene.TPCutsceneDialogue)dialogue.Character;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [dialogue @ rdx (VampireSurvivors.DraculaCutscene+TPCutsceneDialogue)+10]");
		_ = 0;
		_ = dialogue._003CEnglishShowTime_003Ek__BackingField;
		obj.hidePortraitAtEnd = hidePortraitAtEnd;
		obj.voiceOverID = voiceOverID;
		return obj;
	}

	private IEnumerator ShowDialoguePanel()
	{
		_003CShowDialoguePanel_003Ed__40 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator ShowCharacterPortrait(DraculaCutscene.DialogueCharacter speakingCharacter)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CShowCharacterPortrait_003Ed__41 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 40;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.speakingCharacter = speakingCharacter;
			return obj;
		}
		obj.speakingCharacter = speakingCharacter;
		return obj;
	}

	private IEnumerator HideCharacterPortrait(DraculaCutscene.DialogueCharacter characterToHide)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CHideCharacterPortrait_003Ed__42 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 40;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.characterToHide = characterToHide;
			return obj;
		}
		obj.characterToHide = characterToHide;
		return obj;
	}

	private IEnumerator ScaleTransform(Transform transformToScale, Vector3 startScale, Vector3 endScale, float duration)
	{
		//IL_0017: Expected O, but got F4
		//IL_0029: Expected O, but got F4
		_003CScaleTransform_003Ed__43 obj = null;
		obj._003C_003E1__state = 0;
		obj.transformToScale = transformToScale;
		obj.startScale = (Vector3)startScale.x;
		obj.endScale = (Vector3)endScale.x;
		_ = startScale.z;
		_ = endScale.z;
		float duration2 = default(float);
		obj.duration = duration2;
		return obj;
	}

	private IEnumerator ShowDialogueText(DraculaCutscene.TPCutsceneDialogue dialogue)
	{
		//IL_003e: Expected O, but got I4
		_003CShowDialogueText_003Ed__44 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.dialogue = (DraculaCutscene.TPCutsceneDialogue)dialogue.Character;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [dialogue @ rdx (VampireSurvivors.DraculaCutscene+TPCutsceneDialogue)+10]");
		_ = 0;
		_ = dialogue._003CEnglishShowTime_003Ek__BackingField;
		return obj;
	}

	private IEnumerator ScrollText()
	{
		_003CScrollText_003Ed__45 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private Transform GetPortraitTransformForCharacter(DraculaCutscene.DialogueCharacter character)
	{
		//IL_000e: Expected O, but got I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		object obj = character - 1;
		bool flag = character == DraculaCutscene.DialogueCharacter.Richter;
		Component component;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 != 1)
				{
					DraculaCutscene.DialogueCharacter dialogueCharacter = default(DraculaCutscene.DialogueCharacter);
					object actualValue = dialogueCharacter;
					ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("character", actualValue, null);
					throw ex;
				}
				component = _DeathPortraitImage;
			}
			else
			{
				component = _DraculaPortraitImage;
			}
		}
		else
		{
			component = _RichterPortraitImage;
		}
		return component.transform;
	}

	private void OnDestroy()
	{
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		MonoBehaviour.StopAllCoroutines_Injected(((UnityEngine.Object)this).m_CachedPtr);
		UnityEngine.Object.Destroy(_dialogueTextMaterial, 0f);
	}

	public TPCutsceneDialogueUI()
	{
		//IL_0057: Expected I, but got O
		_LetterBoxTransitionInTime = 0.75f;
		_LetterBoxTransitionOutTime = 0.75f;
		_DelayBeforeStartDialogue = 0.2f;
		_LineScrollYOffsetPerLine = 100f;
		_LineScrollDuration = 0.1f;
		_DelayAfterDialogueFinished = 1f;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static TPCutsceneDialogueUI()
	{
		int vertexOffsetY = Shader.PropertyToID("_VertexOffsetY");
		VertexOffsetY = vertexOffsetY;
	}
}
