using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Vector3")]
	[Category("Constants/Vector3")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
	[Description("Returns a world-space point in space")]
	[HideLabelsInEditor(true)]
	public class GetPositionVector3 : PropertyTypeGetPosition
	{
		[SerializeField]
		protected Vector3 m_Position;

		public override string String => $"({m_Position.x:0.##}, {m_Position.y:0.##}, {m_Position.z:0.##})";

		public override Vector3 EditorValue => m_Position;

		public override Vector3 Get(Args args)
		{
			return m_Position;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return m_Position;
		}

		public GetPositionVector3()
		{
			m_Position = Vector3.zero;
		}

		public GetPositionVector3(Vector3 position)
		{
			m_Position = position;
		}

		public static PropertyGetPosition Create()
		{
			return Create(Vector3.zero);
		}

		public static PropertyGetPosition Create(Vector3 position)
		{
			return new PropertyGetPosition(new GetPositionVector3(position));
		}
	}
}
