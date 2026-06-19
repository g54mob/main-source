using UnityEngine;

namespace Items
{
	public interface IGrabable
	{
		Rigidbody Rigidbody { get; }

		void Grab();

		void Ungrab();
	}
}
