using UnityEngine;

namespace MateoRyhr
{
	public interface IMover
	{
		IMovement Movement { get; }

		Vector3 Move(Vector3 direction, float timeLapsed);
	}
}
