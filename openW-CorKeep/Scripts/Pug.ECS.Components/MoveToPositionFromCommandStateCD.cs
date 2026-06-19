using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

public struct MoveToPositionFromCommandStateCD : IComponentData, IQueryTypeParameter
{
	public enum InternalState : byte
	{
		Init = 0,
		Anticipation = 1,
		Attacking = 2
	}

	public Entity pathFindingEntity;

	public bool pendingMove;

	public byte consecutiveDamageAttempts;

	public InternalState damageObjectState;

	public float2 position;

	public Entity target;

	public NetworkTick lastFinishedMoveToPositionTick;

	public float timer;
}
