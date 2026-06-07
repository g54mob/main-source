using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	internal interface IProp
	{
		Transform Bone { get; }

		GameObject Instance { get; }

		void Create(Animator animator);

		void Destroy();

		void Drop();
	}
}
