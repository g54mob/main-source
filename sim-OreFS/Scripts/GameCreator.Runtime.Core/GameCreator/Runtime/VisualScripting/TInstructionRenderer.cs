using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Renderer", "The game object with a Renderer component attached")]
	[Keywords(new string[] { "Change" })]
	public abstract class TInstructionRenderer : Instruction
	{
		[SerializeField]
		protected PropertyGetGameObject m_Renderer = new PropertyGetGameObject();
	}
}
