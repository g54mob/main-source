using System;
using TMPro;
using UnityEngine;

namespace UI.Elements
{
	public class UIInputField : MonoBehaviour
	{
		[NonSerialized]
		[HideInInspector]
		public TMP_InputField inputField;

		[HideInInspector]
		public string text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[HideInInspector]
		public string placeholder
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Init(string text = null, string placeholder = null)
		{
		}

		public void SetTextWithoutNotify(string text)
		{
		}

		public void EnableInputField(bool activate)
		{
		}
	}
}
