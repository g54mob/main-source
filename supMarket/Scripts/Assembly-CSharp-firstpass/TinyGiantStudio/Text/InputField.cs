using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Input field", 20003)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/ui/input-field")]
	public class InputField : MonoBehaviour
	{
		public enum ContentType
		{
			Anything = 0,
			IntegarNumber = 1,
			FloatNumber = 2,
			Password = 3,
			Pin = 4
		}

		[CompilerGenerated]
		private sealed class _003CFocusRoutine_003Ed__48 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InputField _003C_003E4__this;

			public bool enable;

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
			public _003CFocusRoutine_003Ed__48(int _003C_003E1__state)
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

		public UIState state;

		[Tooltip("If set to true, the inputfield is focused on awake.\r\nIf it is in a list, the list controls who to focus on.")]
		public bool autoFocusOnGameStart;

		public bool interactable;

		[SerializeField]
		private string _text;

		public string placeHolderText;

		public int maxCharacter;

		public string caret;

		public bool hideCaretIfMaxCharacter;

		public ContentType contentType;

		public Modular3DText textComponent;

		public Renderer background;

		public bool enterKeyEndsInput;

		public Material placeHolderTextMat;

		public Material inFocusTextMat;

		public Material inFocusBackgroundMat;

		public Material outOfFocusTextMat;

		public Material normalBackgroundMaterial;

		public Material hoveredBackgroundMaterial;

		public Material disabledTextMat;

		public Material disabledBackgroundMat;

		private Material currentTextMaterial;

		[SerializeField]
		private AudioClip typeSound;

		[SerializeField]
		private AudioSource audioSource;

		public UnityEvent onInput;

		public UnityEvent onBackspace;

		public UnityEvent onInputEnd;

		private TouchScreenKeyboard screenKeyboard;

		public string Text
		{
			get
			{
				return null;
			}
			set
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

		private void OnTextInput(char ch)
		{
		}

		private void ProcessNewChar(char c)
		{
		}

		public void InputComplete()
		{
		}

		public void UpdateText()
		{
		}

		public void UpdateText(string newText)
		{
		}

		public void UpdateText(int newTextInt)
		{
		}

		public void UpdateText(float newTextFloat)
		{
		}

		public void UpdateText(bool sound, bool ignoreCaret = false)
		{
		}

		private string GetText()
		{
			return null;
		}

		public void EmptyText()
		{
		}

		public void Select()
		{
		}

		public void Focused(object sender, EventArgs e)
		{
		}

		public void Unfocused(object sender, EventArgs e)
		{
		}

		public void FocusToggle()
		{
		}

		public void Focus(bool enable)
		{
		}

		[IteratorStateMachine(typeof(_003CFocusRoutine_003Ed__48))]
		private IEnumerator FocusRoutine(bool enable)
		{
			return null;
		}

		public void Focus(bool enable, bool delay)
		{
		}

		private void FocusFunction(bool enable)
		{
		}

		public void OpenTouchScreenKeyboard()
		{
		}

		public void CloseTouchScreenKeyboard()
		{
		}

		public void Interactable()
		{
		}

		public void Uninteractable()
		{
		}

		public void HoverEnter()
		{
		}

		public void HoverEnter(object sender, EventArgs e)
		{
		}

		public void HoverExit()
		{
		}

		public void HoverExit(object sender, EventArgs e)
		{
		}

		public void PressStart()
		{
		}

		public void PressStart(object sender, EventArgs e)
		{
		}

		public void PressComplete()
		{
		}

		public void PressComplete(object sender, EventArgs e)
		{
		}

		private void SelectedVisual()
		{
		}

		private void UnselectedVisual()
		{
		}

		public void DisableVisual()
		{
		}

		private void UpdateMaterials(Material textMat, Material backgroundMat)
		{
		}

		private List GetParentList()
		{
			return null;
		}

		public (bool, List) ApplyNormalStyleFromParent()
		{
			return default((bool, List));
		}

		public (bool, List) ApplySelectedStyleFromParent()
		{
			return default((bool, List));
		}

		public (bool, List) ApplyDisabledStyleFromParent()
		{
			return default((bool, List));
		}
	}
}
