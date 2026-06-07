using System.Runtime.CompilerServices;
using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	public class SettingsObject : ScriptableObject
	{
		public event Callback OnSettingsUpdated
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

		protected virtual void OnValidate()
		{
		}

		protected virtual void UpdateLoggerSettings()
		{
		}

		internal virtual void OnEditorReload()
		{
		}
	}
}
