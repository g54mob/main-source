using Reactivity;
using Reactivity.Unity.Components;
using TMPro;
using UnityEngine;

namespace FractureField.UI.Popups.Changelog
{
	public class ChangelogEntry : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private RText _bodyText;

		[SerializeField]
		private RImage _caret;

		private RBool IsExpanded { get; }

		public void Setup(string title, string body, bool isFirstEntry)
		{
		}

		public void Clicked()
		{
		}
	}
}
