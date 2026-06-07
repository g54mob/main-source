using System.Collections.Generic;
using UnityEngine;

namespace SkywardRay.FileBrowser
{
	public class SfbDropMenu : MonoBehaviour
	{
		public SfbDropMenuItem prefabItem;

		public Transform content;

		public SfbDropMenuType type;

		public float maxHeight;

		private SfbInternal fileBrowser;

		private List<SfbDropMenuItem> items;

		public void Repopulate(IEnumerable<string> input)
		{
		}

		private void AddItem(string input)
		{
		}

		public void ClickItem(SfbDropMenuItem item)
		{
		}
	}
}
