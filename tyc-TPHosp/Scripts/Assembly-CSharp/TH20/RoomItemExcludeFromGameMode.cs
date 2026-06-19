using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly]
	public class RoomItemExcludeFromGameMode : EntityComponent
	{
		[SerializeField]
		private bool _excludeInSandbox = true;

		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		public bool IsExcluded(Level level)
		{
			if (_excludeInSandbox && level.IsSandbox())
			{
				return true;
			}
			return false;
		}
	}
}
