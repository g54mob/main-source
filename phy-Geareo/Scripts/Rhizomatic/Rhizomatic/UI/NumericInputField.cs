using UnityEngine;
using UnityEngine.UI;

namespace Rhizomatic.UI
{
	public class NumericInputField : MonoBehaviour
	{
		public InputFieldAdapter inputField;

		public float _value;

		public bool integer;

		public Button.ButtonClickedEvent onStartEdit;

		public Button.ButtonClickedEvent onValueChanged;

		public Button.ButtonClickedEvent onEndEdit;

		private bool _isEditing;

		public float value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void SetValue(float value)
		{
		}

		public void SetValueWithoutNotify(float value)
		{
		}

		public float GetValue()
		{
			return 0f;
		}
	}
}
