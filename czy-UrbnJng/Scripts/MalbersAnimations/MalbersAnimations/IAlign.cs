using UnityEngine;

namespace MalbersAnimations
{
	public interface IAlign
	{
		bool Active { get; set; }

		Transform MainPoint { get; }

		void Align(Transform Target);

		void Align(GameObject Target);
	}
}
