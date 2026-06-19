using Unity.Entities;
using UnityEngine.Scripting;

namespace PlayerState
{
	[UpdateBefore(typeof(ChangePlayerStateSystem))]
	[UpdateInGroup(typeof(PlayerStateSystemGroup))]
	public class BeforeChangeStateSystemGroup : ComponentSystemGroup
	{
		[Preserve]
		public BeforeChangeStateSystemGroup()
		{
		}
	}
}
