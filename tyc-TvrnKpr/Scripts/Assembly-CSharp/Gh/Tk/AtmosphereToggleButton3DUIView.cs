using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class AtmosphereToggleButton3DUIView : Button3DUIView
	{
		public AtmosphereMenu3DUIView menuView;

		public GameObject iconsParent;

		private Dictionary<string, GameObject> _overlayIcons;

		protected override void Start()
		{
		}

		private void OnOverlayChanged(object sender, EventArgs e)
		{
		}

		public void SetIcon(string id)
		{
		}

		public override void OnClicked()
		{
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}
	}
}
