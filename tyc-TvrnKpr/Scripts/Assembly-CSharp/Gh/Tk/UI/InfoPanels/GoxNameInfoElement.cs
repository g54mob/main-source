using System;
using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class GoxNameInfoElement : GoxInfoElement
	{
		[SerializeField]
		private TextBlock3DUIView _richTextName;

		[SerializeField]
		private GameObject _customNameParent;

		[SerializeField]
		private EditGoxNameElement _customNameElement;

		protected override void OnGoxPreSet()
		{
		}

		protected override void OnGoxPostSet()
		{
		}

		private void OnNameChanged(object obj, EventArgs args)
		{
		}

		protected override void OnRefresh()
		{
		}

		private void RefreshGoxName()
		{
		}
	}
}
