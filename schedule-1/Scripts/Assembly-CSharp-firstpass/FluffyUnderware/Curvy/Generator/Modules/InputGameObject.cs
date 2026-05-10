using System.Collections.Generic;
using System.Diagnostics;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cginputgameobject")]
	[ModuleInfo("Input/GameObjects", ModuleName = "Input GameObjects", Description = null)]
	public class InputGameObject : CGModule
	{
		[HideInInspector]
		[OutputSlotInfo(typeof(CGGameObject), Array = true)]
		public CGModuleOutputSlot OutGameObject;

		[SerializeField]
		[ArrayEx]
		private List<CGGameObjectProperties> m_GameObjects;

		public List<CGGameObjectProperties> GameObjects => null;

		public bool SupportsIPE => false;

		public override void Reset()
		{
		}

		public override void Refresh()
		{
		}

		public override void OnTemplateCreated()
		{
		}

		[System.Diagnostics.Conditional("UNITY_EDITOR")]
		private void WarnAboutInvalidInputs()
		{
		}
	}
}
