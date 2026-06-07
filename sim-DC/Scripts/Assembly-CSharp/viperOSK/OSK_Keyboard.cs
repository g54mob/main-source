using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace viperOSK
{
	[ExecuteInEditMode]
	public class OSK_Keyboard : MonoBehaviour
	{
		public enum KEYBOARD_WRAP
		{
			NO_WRAP = 0,
			XY_WRAP = 1,
			X_WRAP = 2,
			Y_WRAP = 3,
			X_CASCADE = 4
		}

		[CompilerGenerated]
		private sealed class _003CReHighlightKey_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public OSK_Keyboard _003C_003E4__this;

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
			public _003CReHighlightKey_003Ed__68(int _003C_003E1__state)
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

		public bool bypassDefaultInput;

		public bool generateOnStart;

		protected bool hasFocus;

		public OSK_Receiver output;

		public GameObject KeyPrefab;

		public Transform topLeft;

		public Color keyLabelColor;

		public Vector3 keySize;

		public TMP_FontAsset keyFont;

		public OSK_LanguagePackage languageProfile;

		public bool caps;

		public bool shift;

		public bool acceptPhysicalKeyboard;

		[Header("Gamepad/Joystick")]
		public bool acceptGamePadInput;

		public KEYBOARD_WRAP gamepadKeyboardWrap;

		public Color highlighterColor;

		private OSK_Key currentSelectedKey;

		protected Vector2Int DpadSelection;

		protected float inputTimer;

		protected float inputTimerThreshold;

		[Header("Sound Effects")]
		public bool soundFX;

		protected Action<int> sound;

		protected Action selectSound;

		[Header("Keys Layout and Settings")]
		protected List<List<OSK_Key>> keyLayout;

		[SerializeField]
		[TextArea(15, 6)]
		public string layout;

		public List<OSK_SpecialKeys> specialKeys;

		public List<OSK_KeyTypeMeta> keyTypeMeta;

		protected Dictionary<OSK_KeyCode, OSK_SpecialKeys> keySounds;

		protected Dictionary<OSK_KeyCode, I_OSK_Key> keyDict;

		public OSK_Keymap osk_Keymap;

		protected Vector3 keySpanTopLeft;

		protected Vector3 keySpanBottomRight;

		public virtual Vector3 SpanTopLeft()
		{
			return default(Vector3);
		}

		public virtual Vector3 SpanBottomRight()
		{
			return default(Vector3);
		}

		public virtual Vector3 KeyScreenSize()
		{
			return default(Vector3);
		}

		public void AutoCorrectLayout()
		{
		}

		public virtual bool HasKey(OSK_KeyCode k)
		{
			return false;
		}

		public virtual void AddText(string newText)
		{
		}

		public virtual void AddString(string multichar)
		{
		}

		public virtual void AddNewLine()
		{
		}

		public virtual void AddText_ShftEnabled(string newText)
		{
		}

		public virtual void InsertText(string newText, OSK_Receiver receiver)
		{
		}

		public virtual string Text()
		{
			return null;
		}

		public virtual void HasFocus(bool isFocus)
		{
		}

		public virtual void SetInteractable(bool isInteractable)
		{
		}

		public virtual void SetOutput(OSK_Receiver newOutput)
		{
		}

		protected void AcceptPhysicalKeyboard(bool accept)
		{
		}

		protected void Prep()
		{
		}

		public virtual void LoadLayout(string lay)
		{
		}

		public static KeyCode OSK_to_KeyCode(OSK_KeyCode k)
		{
			return default(KeyCode);
		}

		public OSK_KeyCode GetOSKKeyCode(string c)
		{
			return default(OSK_KeyCode);
		}

		public KeyCode GetKeyCode(string c)
		{
			return default(KeyCode);
		}

		public virtual void Reset()
		{
		}

		public virtual void ResizeKeyToFit(Vector2 scrSize)
		{
		}

		public virtual void Generate()
		{
		}

		public virtual void Traverse()
		{
		}

		public virtual Vector3 KeyboardSizeEstimator()
		{
			return default(Vector3);
		}

		public void ClickSound(int keytypecode)
		{
		}

		public void SelectSound()
		{
		}

		protected void OutputTextUpdate(string newchar, OSK_Receiver receiver)
		{
		}

		public virtual void KeyCallBase(OSK_KeyCode k, OSK_Receiver receiver)
		{
		}

		public virtual void KeyCall(OSK_KeyCode k, OSK_Receiver receiver)
		{
		}

		public virtual void KeyBackspace(OSK_Receiver receiver)
		{
		}

		public virtual void KeyDelete(OSK_Receiver receiver)
		{
		}

		public virtual void Submit()
		{
		}

		public virtual void KeyShift()
		{
		}

		public virtual void ButtonA()
		{
		}

		[IteratorStateMachine(typeof(_003CReHighlightKey_003Ed__68))]
		protected IEnumerator ReHighlightKey()
		{
			return null;
		}

		public virtual void SetSelectedKey(OSK_KeyCode k)
		{
		}

		public virtual void SetSelectedKey(string c)
		{
		}

		public OSK_Key GetSelectedKey()
		{
			return null;
		}

		public OSK_Key GetOSKKey(string k)
		{
			return null;
		}

		public virtual void DpadMove(Vector2 dir)
		{
		}

		public virtual OSK_Key SelectedKeyMove(Vector2 dir, Vector2Int currentLoc, bool makeSoundIfMove = true)
		{
			return null;
		}

		protected virtual void OnPhysicalKeyStroke(char c)
		{
		}

		protected void InputFromPointerDevice()
		{
		}

		public virtual void RemapPhysicalKeyboard()
		{
		}

		public virtual void GamepadInput_Horizontal(float f)
		{
		}

		public virtual void GamepadInput_Vertical(float f)
		{
		}

		public virtual void GamepadInput_Submit()
		{
		}

		public virtual void GamepadInput_Cancel()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnGUI()
		{
		}

		private void Update()
		{
		}
	}
}
