using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Sphere Surface")]
	[Category("Random/Sphere Surface")]
	[Image(typeof(IconDice), ColorTheme.Type.White)]
	[Description("Returns a random position at the edges a spherical volume")]
	public class GetPositionRandomSphereSurface : PropertyTypeGetPosition
	{
		[SerializeField]
		protected PropertyGetDecimal m_Radius = GetDecimalConstantOne.Create;

		public override string String => "on Sphere";

		public override Vector3 Get(Args args)
		{
			float num = (float)m_Radius.Get(args);
			return UnityEngine.Random.onUnitSphere * num;
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionRandomSphereSurface());
		}
	}
}
