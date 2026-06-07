using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations
{
	public interface IZone
	{
		bool IsMode { get; }

		bool IsState { get; }

		bool IsStance { get; }

		Collider ZCollider { get; }

		int ZoneID { get; }

		Transform transform { get; }

		bool ActivateZone(MAnimal animal);

		void RemoveAnimal(MAnimal animal);
	}
}
