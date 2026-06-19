using System.Runtime.InteropServices;
using Unity.Entities;

namespace CommandMinion
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CommandMinionWeaponCD : IComponentData, IQueryTypeParameter
	{
		public const float COMMAND_MINION_MAX_RANGE = 12f;

		public const float COMMAND_MINION_RADIUS = 1f;

		public const float COMMAND_MINION_CHECK_Z_OFFSET = -0.5f;

		public const float MINION_COMMAND_TARGET_CHASE_DISTANCE = 20f;

		public const float MINION_COMMAND_TARGET_CHASE_DISTANCE_SQR = 400f;

		public const float MINION_COMMAND_MOVE_TO_TARGET_MAX_DISTANCE = 20f;
	}
}
