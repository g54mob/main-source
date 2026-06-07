using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Material")]
	[Category("Constants/Material")]
	[Image(typeof(IconMaterial), ColorTheme.Type.Blue)]
	[Description("A reference to a Material asset")]
	[Keywords(new string[] { "Material", "Shader" })]
	[HideLabelsInEditor(true)]
	public class GetMaterialInstance : PropertyTypeGetMaterial
	{
		[SerializeField]
		protected Material m_Material;

		public override string String
		{
			get
			{
				if (!(m_Material != null))
				{
					return "(none)";
				}
				return m_Material.name;
			}
		}

		public override Material EditorValue => m_Material;

		public override Material Get(Args args)
		{
			return m_Material;
		}

		public override Material Get(GameObject gameObject)
		{
			return m_Material;
		}

		public GetMaterialInstance()
		{
		}

		public GetMaterialInstance(Material Material)
			: this()
		{
			m_Material = Material;
		}

		public static PropertyGetMaterial Create(Material value = null)
		{
			return new PropertyGetMaterial(new GetMaterialInstance(value));
		}
	}
}
