using Unity.Entities;
using UnityEngine.Scripting;

namespace PlayerState
{
	[UpdateBefore(typeof(UpdatePlayerStateSystem))]
	[UpdateAfter(typeof(ChangePlayerStateSystem))]
	[UpdateInGroup(typeof(PlayerStateSystemGroup))]
	public class BeforeUpdateStateSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public BeforeUpdateStateSystemGroup()
		{
		}
	}
}
