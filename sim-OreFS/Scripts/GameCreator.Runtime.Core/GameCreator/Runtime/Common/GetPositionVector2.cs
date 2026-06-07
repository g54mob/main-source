using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Vector2")]
	[Category("Constants/Vector2")]
	[Image(typeof(IconVector2), ColorTheme.Type.Yellow)]
	[Description("Returns a world-space point in a 2D (XY) space")]
	[HideLabelsInEditor(true)]
	public class GetPositionVector2 : PropertyTypeGetPosition
	{
		[SerializeField]
		protected Vector2 m_Point;

		public override string String => $"({m_Point.x:0.##}, {m_Point.y:0.##})";

		public override Vector3 EditorValue => m_Point;

		public override Vector3 Get(Args args)
		{
			return m_Point;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return m_Point;
		}

		public GetPositionVector2()
		{
			m_Point = Vector2.zero;
		}

		public GetPositionVector2(Vector2 position)
		{
			m_Point = position;
		}

		public static PropertyGetPosition Create()
		{
			return Create(Vector3.zero);
		}

		public static PropertyGetPosition Create(Vector2 point)
		{
			return new PropertyGetPosition(new GetPositionVector2(point));
		}
	}
}
