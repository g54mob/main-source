using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Transform", "The Transform of the game object")]
	public abstract class TInstructionTransform : Instruction
	{
		[SerializeField]
		protected PropertyGetGameObject m_Transform = GetGameObjectTransform.Create();
	}
}
