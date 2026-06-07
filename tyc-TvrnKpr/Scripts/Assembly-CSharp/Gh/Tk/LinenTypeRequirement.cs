using System;

namespace Gh.Tk
{
	public class LinenTypeRequirement : Requirement
	{
		private readonly string[] _linenTypes;

		private readonly Room _room;

		protected LinenTypeRequirement()
		{
		}

		public LinenTypeRequirement(string titleKey, string[] linenTypes, Room room)
		{
		}

		private void OnLinenTypeOrRoomsOrZonesChanged(object sender, EventArgs e)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}

		protected override void AttachListeners()
		{
		}

		protected override void DetachListeners()
		{
		}
	}
}
