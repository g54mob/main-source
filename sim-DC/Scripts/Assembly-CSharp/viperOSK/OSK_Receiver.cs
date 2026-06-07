using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace viperOSK
{
	public class OSK_Receiver : MonoBehaviour
	{
		protected string text;

		public int textLimit;

		public TMP_Text textReceiver;

		[HideInInspector]
		public int cursorIndex;

		protected Vector2Int cursorSel;

		public I_OSK_Cursor cursor;

		public bool interactable;

		public bool allowTextSelection;

		public Color32 normalColor;

		public Color32 highlightColor;

		public string charMask;

		public bool useCharMask;

		[SerializeField]
		public UnityEvent<string> OnSubmit;

		[SerializeField]
		public UnityEvent<string> OnValueChanged;

		[SerializeField]
		public UnityEvent<string> onFocus;

		[SerializeField]
		public UnityEvent<string> onLostFocus;

		protected bool hasFocus;

		public virtual int selection => 0;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		public void OnMouseDown()
		{
		}

		public void OnMouseUp()
		{
		}

		public virtual int Selection(Vector3 hitpoint, bool charhit = false)
		{
			return 0;
		}

		public virtual void Deselect()
		{
		}

		public virtual void SelectionHighlight(Color32 c, bool all = false)
		{
		}

		public void ModifyLastChar(string newLastChar)
		{
		}

		public virtual void Submit()
		{
		}

		public virtual void ValueChanged()
		{
		}

		public virtual void SetText(string newText)
		{
		}

		public virtual void AddText(string newchar)
		{
		}

		public virtual void NewLine()
		{
		}

		private void NewLineFix()
		{
		}

		public virtual string Text()
		{
			return null;
		}

		public virtual string ParsedText()
		{
			return null;
		}

		public virtual void OnFocus()
		{
		}

		public virtual void ToggleCharMask()
		{
		}

		public virtual void ToggleCharMask(bool on_off_charmask)
		{
		}

		public virtual bool isFocused()
		{
			return false;
		}

		public virtual void OnFocusLost()
		{
		}

		public virtual void Backspace()
		{
		}

		public virtual void Del()
		{
		}

		public virtual void ClearText()
		{
		}
	}
}
