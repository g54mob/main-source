using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Vector")]
	[Category("Constants/Vector")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
	[Description("A Vector3 that represents the scale on each axis")]
	[HideLabelsInEditor(true)]
	public class GetScaleVector3 : PropertyTypeGetScale
	{
		[SerializeField]
		protected Vector3 m_Scale;

		public override string String => m_Scale.ToString();

		public override Vector3 Get(Args args)
		{
			return m_Scale;
		}

		public override Vector3 Get(GameObject gameObject)
		{
			return m_Scale;
		}

		public GetScaleVector3()
		{
			m_Scale = Vector3.zero;
		}

		public GetScaleVector3(Vector3 scale)
		{
			m_Scale = scale;
		}

		public static PropertyGetScale Create(Vector3 scale)
		{
			return new PropertyGetScale(new GetScaleVector3(scale));
		}
	}
}
