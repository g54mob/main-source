using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class ContextMenuItemGroup3DUIView : BaseInteractable3DUIView
	{
		public List<ContextMenuItem> SubItems;

		private bool _isSubItemListOpen;

		[SerializeField]
		private ContextMenu3DUIView _contextMenuPrefab;

		private ContextMenu3DUIView _currentContextMenuInstance;

		private ContextMenu3DUIView _parentContextMenu;

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		private void OnIsHoveredChangedEvent(object sender, EventArgs<bool> e)
		{
		}

		private void CheckHoveredState()
		{
		}

		private void Update()
		{
		}

		private bool IsHoveringAnythingWeOwn()
		{
			return false;
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
