using System;
using System.Collections.Generic;
using TMPro;

namespace Gh.Tk
{
	public class DecorationTreeNodeUIView : TreeNodeUIView
	{
		private TMP_InputField _inputField;

		protected override List<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}

		public override void SetNode(ITreeNode node, TreeNodeUIView nodeParent, TreeList3DUIView listParent)
		{
		}

		protected override void OnDestroy()
		{
		}

		private void UpdateVisuals(object sender, EventArgs e)
		{
		}

		protected override void OnClickedInternal()
		{
		}
	}
}
