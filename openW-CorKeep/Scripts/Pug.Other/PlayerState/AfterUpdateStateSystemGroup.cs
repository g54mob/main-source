using Unity.Entities;
using UnityEngine.Scripting;

namespace PlayerState
{
	[UpdateAfter(typeof(UpdatePlayerStateSystem))]
	[UpdateInGroup(typeof(PlayerStateSystemGroup))]
	public class AfterUpdateStateSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public AfterUpdateStateSystemGroup()
		{
		}
	}
}
