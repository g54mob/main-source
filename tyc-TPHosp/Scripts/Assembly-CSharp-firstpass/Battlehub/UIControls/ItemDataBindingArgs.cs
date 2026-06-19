using System;
using UnityEngine;

namespace Battlehub.UIControls
{
	public class ItemDataBindingArgs : EventArgs
	{
		public object Item { get; set; }

		public GameObject ItemPresenter { get; set; }
	}
}
