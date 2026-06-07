using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Pool Destroy")]
	[Description("Destroys an existing game object pool")]
	[Category("Game Objects/Pooling/Pool Destroy")]
	[Parameter("Game Object", "The Game Object reference is used as the template for the pool")]
	[Example("Use this Instruction to dispose those pools that have been pre-warmed. Pools created at runtime are automatically disposed when their scene is unloaded.")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Red, typeof(OverlayFlame))]
	[Keywords(new string[] { "Dispose", "Destroy", "Delete", "Game Object" })]
	public class InstructionGameObjectPoolDestroy : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = GetGameObjectInstance.Create();

		public override string Title => $"Destroy {m_GameObject} Pool";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Singleton<PoolManager>.Instance.Dispose(gameObject);
			return Instruction.DefaultResult;
		}
	}
}
