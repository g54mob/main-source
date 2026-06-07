using System;

namespace Gh.Tk
{
	public class MinRoomStarRequirement : Requirement
	{
		private readonly string _zone;

		private readonly int _star;

		private readonly int _amount;

		protected MinRoomStarRequirement()
		{
		}

		public MinRoomStarRequirement(string titleKey, string zone, int star, int amount = 1)
		{
		}

		private void OnValidPropsOrRoomsOrZonesChanged(object sender, EventArgs e)
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
