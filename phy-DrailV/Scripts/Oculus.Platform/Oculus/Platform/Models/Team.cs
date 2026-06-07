using System;

namespace Oculus.Platform.Models
{
	public class Team
	{
		public readonly UserList AssignedUsers;

		public readonly int MaxUsers;

		public readonly int MinUsers;

		public readonly string Name;

		public Team(IntPtr o)
		{
			AssignedUsers = new UserList(CAPI.ovr_Team_GetAssignedUsers(o));
			MaxUsers = CAPI.ovr_Team_GetMaxUsers(o);
			MinUsers = CAPI.ovr_Team_GetMinUsers(o);
			Name = CAPI.ovr_Team_GetName(o);
		}
	}
}
