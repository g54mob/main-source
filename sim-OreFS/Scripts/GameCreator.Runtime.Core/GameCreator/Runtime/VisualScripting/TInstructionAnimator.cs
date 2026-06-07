using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Animator", "The Animator component attached to the game object")]
	public abstract class TInstructionAnimator : Instruction
	{
		[SerializeField]
		protected PropertyGetGameObject m_Animator = new PropertyGetGameObject();
	}
}
