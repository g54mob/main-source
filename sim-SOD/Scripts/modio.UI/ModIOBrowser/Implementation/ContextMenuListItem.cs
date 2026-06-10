using System;
using TMPro;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class ContextMenuListItem : ListItem
	{
		[SerializeField]
		private TMP_Text optionText;

		[SerializeField]
		private MultiTargetButton optionButton;

		public override void Select()
		{
		}

		public override void Setup(string title, Action onClick)
		{
		}
	}
}
