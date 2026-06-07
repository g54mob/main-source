using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Vector")]
	[Category("Constants/Vector")]
	[Image(typeof(IconVector3), ColorTheme.Type.Green)]
	[Description("A Vector3 that defines a direction")]
	[HideLabelsInEditor(true)]
	public class GetDirectionVector : PropertyTypeGetDirection
	{
		[SerializeField]
		protected Vector3 m_Direction = Vector3.forward;

		public override string String => $"({m_Direction.x:0.##}, {m_Direction.y:0.##}, {m_Direction.z:0.##})";

		public override Vector3 EditorValue => m_Direction;

		public GetDirectionVector()
		{
		}

		public GetDirectionVector(Vector3 direction)
		{
			m_Direction = direction;
		}

		public override Vector3 Get(Args args)
		{
			return m_Direction;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return m_Direction;
		}

		public static PropertyGetDirection Create(Vector3 direction)
		{
			return new PropertyGetDirection(new GetDirectionVector(direction));
		}

		public static PropertyGetDirection Create()
		{
			return Create(Vector3.zero);
		}
	}
}
