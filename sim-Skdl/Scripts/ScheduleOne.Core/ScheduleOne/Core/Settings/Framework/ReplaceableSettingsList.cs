using System;
using UnityEngine;

namespace ScheduleOne.Core.Settings.Framework
{
	[Serializable]
	public class ReplaceableSettingsList<T> : ExtendibleSettingsList<T>
	{
		public enum EMode
		{
			Replace = 0,
			Add = 1
		}

		[Tooltip("Leave as 'add' unless you have good reason not to. 'Add' will append the items below to the game's internal list, 'Replace' will replace the internal list with the items below.")]
		public EMode Mode;

		public ReplaceableSettingsList(string name)
			: base((string)null)
		{
		}

		public override void OverwriteWith(ExtendibleSettingsList<T> other)
		{
		}
	}
}
