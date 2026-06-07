using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Direction")]
	[Category("Values/Direction")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Description("A Position vector from a Direction value")]
	public class GetPositionValueDirection : PropertyTypeGetPosition
	{
		[SerializeField]
		private PropertyGetDirection m_Direction = new PropertyGetDirection();

		public static PropertyGetPosition Create => new PropertyGetPosition(new GetPositionValueDirection());

		public override string String => m_Direction.ToString();

		public override Vector3 EditorValue => m_Direction.EditorValue;

		public override Vector3 Get(Args args)
		{
			return m_Direction.Get(args);
		}

		public override Vector3 Get(GameObject args)
		{
			return m_Direction.Get(args);
		}
	}
}
