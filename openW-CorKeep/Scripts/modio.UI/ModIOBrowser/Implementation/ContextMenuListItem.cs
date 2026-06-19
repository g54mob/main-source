using System;
using ModIO.Util;
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
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(optionButton);
		}

		public override void Setup(string title, Action onClick)
		{
			base.Setup(title);
			optionText.text = title;
			optionButton.onClick.RemoveAllListeners();
			optionButton.onClick.AddListener(delegate
			{
				onClick();
			});
			base.gameObject.SetActive(value: true);
			optionButton.enabled = true;
		}
	}
}
