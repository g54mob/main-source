using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Material Texture")]
	[Description("Changes the main texture of an instantiated material of a Renderer component")]
	[Image(typeof(IconTexture), ColorTheme.Type.Yellow)]
	[Category("Renderer/Change Material Texture")]
	[Parameter("Texture", "Texture that replaces the Renderer's instantiated material")]
	[Keywords(new string[] { "Set", "Shader" })]
	public class InstructionRendererChangeMaterialTexture : TInstructionRenderer
	{
		private enum MaterialType
		{
			Shared = 0,
			Instance = 1
		}

		[SerializeField]
		private MaterialType m_Material = MaterialType.Instance;

		[SerializeField]
		private PropertyGetString m_TextureName = new PropertyGetString("_MainTex");

		[SerializeField]
		private PropertyGetTexture m_Texture = new PropertyGetTexture();

		public override string Title => $"Change Texture of {m_Renderer}[{m_TextureName}] to {m_Texture}";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_Renderer.Get(args);
			if (gameObject == null)
			{
				return Instruction.DefaultResult;
			}
			Renderer renderer = gameObject.Get<Renderer>();
			if (renderer == null)
			{
				return Instruction.DefaultResult;
			}
			Material material = m_Material switch
			{
				MaterialType.Shared => renderer.sharedMaterial, 
				MaterialType.Instance => renderer.material, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
			if (material == null)
			{
				return Instruction.DefaultResult;
			}
			string name = m_TextureName.Get(args);
			if (!material.HasTexture(name))
			{
				return Instruction.DefaultResult;
			}
			material.SetTexture(name, m_Texture.Get(args));
			return Instruction.DefaultResult;
		}
	}
}
