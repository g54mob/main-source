using System;
using TMPro;
using UnityEngine;

namespace UI.Elements
{
	public class ParameterInputField : MonoBehaviour
	{
		[SerializeField]
		private TMP_InputField valueInput;

		private Action<int> OnValueChanged;

		private int min;

		private int max;

		public void Init(Action<int> OnValueChanged, int? min = null, int? max = null)
		{
		}

		public void SetValue(int v)
		{
		}

		public void OnValueChanging()
		{
		}
	}
}
