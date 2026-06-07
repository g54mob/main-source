using System.Collections.Generic;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Input/Spots", ModuleName = "Input Spots", Description = "Defines an array of placement spots")]
	[HelpURL("https://curvyeditor.com/doclink/cginputspots")]
	public class InputSpots : CGModule
	{
		[OutputSlotInfo(typeof(CGSpots))]
		[HideInInspector]
		public CGModuleOutputSlot OutSpots;

		[ArrayEx]
		[SerializeField]
		private List<CGSpot> m_Spots;

		public List<CGSpot> Spots
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		public override void Reset()
		{
		}

		public override void Refresh()
		{
		}
	}
}
