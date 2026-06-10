using System;
using System.Collections.Generic;
using NSEipix.View.UI;
using NSMedieval.UI;
using TMPro;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class TutorialDebugStart : UIView
	{
		[SerializeField]
		private TMP_Dropdown dropdown;

		[SerializeField]
		private SoundButton startButton;

		[SerializeField]
		private int index;

		public event Action<int> TutorialDebugStartEvent;

		public void Initialize(List<string> options)
		{
			index = 0;
			Show();
			dropdown.ClearOptions();
			dropdown.AddOptions(options);
			dropdown.value = index;
		}

		private void Start()
		{
			startButton.onClick.AddListener(delegate
			{
				this.TutorialDebugStartEvent?.Invoke(dropdown.value);
				Hide();
			});
		}
	}
}
