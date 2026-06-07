using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class TavernSign3DUIView : BaseInteractable3DUIView, IContextMenuProvider
	{
		[SerializeField]
		private Transform _closedLabel;

		private List<ContextMenuItem> _contextMenuItems;

		protected override void Start()
		{
		}

		public override void CheckState()
		{
		}

		public IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}
	}
}
