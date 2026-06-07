using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Sphere Volume")]
	[Category("Random/Sphere Volume")]
	[Image(typeof(IconDice), ColorTheme.Type.White)]
	[Description("Returns a random position inside a spherical volume")]
	public class GetPositionRandomSphere : PropertyTypeGetPosition
	{
		[SerializeField]
		protected PropertyGetDecimal m_Radius = GetDecimalConstantOne.Create;

		public override string String => "in Sphere";

		public override Vector3 Get(Args args)
		{
			float num = (float)m_Radius.Get(args);
			return UnityEngine.Random.insideUnitSphere * num;
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionRandomSphere());
		}
	}
}
