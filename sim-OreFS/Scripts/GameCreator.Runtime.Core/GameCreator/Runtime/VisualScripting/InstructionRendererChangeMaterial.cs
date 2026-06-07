using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Change Material")]
	[Description("Changes instantiated material of a Renderer component")]
	[Image(typeof(IconSphereSolid), ColorTheme.Type.Yellow)]
	[Category("Renderer/Change Material")]
	[Parameter("Material", "Material that is set as the primary type of the Renderer")]
	[Keywords(new string[] { "Set", "Shader", "Texture" })]
	public class InstructionRendererChangeMaterial : TInstructionRenderer
	{
		[SerializeField]
		private PropertyGetMaterial m_Material = GetMaterialInstance.Create();

		public override string Title => $"{m_Renderer} Material = {m_Material}";

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
			renderer.material = m_Material.Get(args);
			return Instruction.DefaultResult;
		}
	}
}
