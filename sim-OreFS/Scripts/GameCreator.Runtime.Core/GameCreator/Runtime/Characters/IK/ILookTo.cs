using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	public interface ILookTo
	{
		int Layer { get; }

		bool Exists { get; }

		Vector3 Position { get; }

		GameObject Target { get; }
	}
}
