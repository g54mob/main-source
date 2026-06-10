using System.Collections.Generic;
using NSEipix.View.UI;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class AutoplayView : ClosableUIView
	{
		[SerializeField]
		private SoundButton closeButton;

		[SerializeField]
		private SoundButton runAllButton;

		[SerializeField]
		private List<SoundButton> runSelectedButtons = new List<SoundButton>();

		[SerializeField]
		private SoundButton unselectAllButton;

		[SerializeField]
		private GameObject testListGameObject;

		[SerializeField]
		private AutoplayToggleItemView toggleItemPrefab;

		[SerializeField]
		private GameObject buttonPrefab;

		private bool initialized;

		private List<string> selectedTests = new List<string>();

		public override void Show()
		{
		}

		private void UpdateSelected()
		{
		}

		private void OnValueChanged(Toggle toggle, string test)
		{
			if (toggle.isOn)
			{
				selectedTests.Add(test);
			}
			else
			{
				selectedTests.Remove(test);
			}
			UpdateSelected();
		}

		private void Start()
		{
		}
	}
}
