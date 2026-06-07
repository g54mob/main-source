using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Store In", "The list where the colliders (if any) are stored")]
	[Parameter("Layer Mask", "A mask that determines which colliders are ignored and which aren't")]
	[Keywords(new string[] { "Cast", "Collect" })]
	[Keywords(new string[] { "Physics", "Rigidbody" })]
	public abstract class TInstructionPhysics3DOverlap : Instruction
	{
		protected const int LENGTH = 30;

		private static readonly Collider[] COLLIDERS = new Collider[30];

		[SerializeField]
		protected CollectorListVariable m_StoreIn = new CollectorListVariable();

		[SerializeField]
		protected LayerMask m_LayerMask = -5;

		protected override Task Run(Args args)
		{
			int colliders = GetColliders(COLLIDERS, args);
			GameObject[] array = new GameObject[colliders];
			for (int i = 0; i < colliders; i++)
			{
				array[i] = COLLIDERS[i].gameObject;
			}
			m_StoreIn.Fill(array, args);
			return Instruction.DefaultResult;
		}

		protected abstract int GetColliders(Collider[] colliders, Args args);
	}
}
