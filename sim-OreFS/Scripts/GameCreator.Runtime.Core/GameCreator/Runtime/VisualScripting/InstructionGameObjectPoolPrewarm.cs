using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Pool Prewarm")]
	[Description("Creates or makes sure an existing game object pool has enough instances")]
	[Category("Game Objects/Pooling/Pool Prewarm")]
	[Parameter("Game Object", "The Game Object reference is used as the template for the pool")]
	[Parameter("Pool Size", "The size of the pool of game objects")]
	[Example("Pre-warming a Pool moves it to the DontDestroyOnLoad scene. This means its contents will never be destroyed even after loading new scenes. To delete a pre-warmed pool use the Pool Destroy instruction.")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Green, typeof(OverlayFlame))]
	[Keywords(new string[] { "Create", "New", "Initialize", "Game Object" })]
	public class InstructionGameObjectPoolPrewarm : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_GameObject = GetGameObjectInstance.Create();

		[SerializeField]
		private PropertyGetInteger m_PoolSize = new PropertyGetInteger(5);

		public override string Title => $"Prewarm {m_GameObject} with {m_PoolSize}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_GameObject.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			int num = (int)m_PoolSize.Get(args);
			if (num <= 0)
			{
				return Instruction.DefaultResult;
			}
			Singleton<PoolManager>.Instance.Prewarm(gameObject, num);
			Singleton<PoolManager>.Instance.DontDestroyOnLoadPool(gameObject);
			return Instruction.DefaultResult;
		}
	}
}
