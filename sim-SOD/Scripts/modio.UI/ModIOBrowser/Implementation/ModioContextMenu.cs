using System.Collections.Generic;
using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class ModioContextMenu : SelfInstancingMonoSingleton<ModioContextMenu>
	{
		public GameObject ContextMenu;

		[SerializeField]
		public Transform ContextMenuList;

		[SerializeField]
		public GameObject ContextMenuListItemPrefab;

		[SerializeField]
		public Selectable ContextMenuPreviousSelection;

		internal void Open(Transform t, List<ContextMenuOption> options, Selectable previousSelection)
		{
		}

		public void Close()
		{
		}

		private void Update()
		{
		}

		private bool IsMouseInUse()
		{
			return false;
		}
	}
}
