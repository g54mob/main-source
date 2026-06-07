using UnityEngine;

namespace VoxelBusters.CoreLibrary
{
	[SerializeField]
	public abstract class SettingsPropertyGroup
	{
		[SerializeField]
		[HideInInspector]
		private bool m_isEnabled;

		public bool IsEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string Name { get; private set; }

		protected SettingsPropertyGroup(string name, bool isEnabled = true)
		{
		}
	}
}
