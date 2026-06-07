using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class Tap : SlotItemServiceSourceProp
	{
		public static event EventHandler TapInventoryChanged
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

		protected override void OnInventoryChanged()
		{
		}

		public override Vector3 GetStatusIconPosition(bool worldSpace = false)
		{
			return default(Vector3);
		}

		protected override string GetNoItemConfiguredWarningText()
		{
			return null;
		}

		public float GetTapLevel()
		{
			return 0f;
		}
	}
}
