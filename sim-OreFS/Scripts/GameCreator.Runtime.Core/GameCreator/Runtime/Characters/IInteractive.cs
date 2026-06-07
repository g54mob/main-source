using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public interface IInteractive : ISpatialHash
	{
		GameObject Instance { get; }

		int InstanceID { get; }

		bool IsInteracting { get; }

		void Interact(Character character);

		void Stop();
	}
}
