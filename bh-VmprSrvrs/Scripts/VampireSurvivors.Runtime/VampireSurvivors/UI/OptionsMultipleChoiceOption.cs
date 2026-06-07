using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class OptionsMultipleChoiceOption : MonoBehaviour
	{
		[SerializeField]
		private Image _Tick;

		[SerializeField]
		private Button _Button;

		[SerializeField]
		private TextMeshProUGUI _Label;

		private OptionsMultipleChoice _owner;

		public void Select()
		{
		}

		public void Deselect()
		{
		}

		public void Initialize(string text, Action cb, OptionsMultipleChoice owner)
		{
		}
	}
}
