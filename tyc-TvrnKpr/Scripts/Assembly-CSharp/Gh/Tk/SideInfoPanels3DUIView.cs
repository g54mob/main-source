using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class SideInfoPanels3DUIView : MonoBehaviour
	{
		private Dictionary<string, SideInfoPanel3DUIView> _sideInfos;

		public bool IsSideInfoOpen => false;

		public static event EventHandler SideInfoToggledEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public SideInfoPanel3DUIView GetSideInfoPanel(string id)
		{
			return null;
		}

		private void Start()
		{
		}

		private void SideInfoPanelChanged(object sender, EventArgs e)
		{
		}
	}
}
