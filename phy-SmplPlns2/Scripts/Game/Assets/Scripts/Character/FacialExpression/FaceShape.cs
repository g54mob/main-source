using System;
using UnityEngine;

namespace Assets.Scripts.Character.FacialExpression
{
	[Serializable]
	public class FaceShape
	{
		[SerializeField]
		private FaceBlendShape _blendShape;

		[SerializeField]
		[Range(0f, 100f)]
		private int _value;

		public FaceBlendShape BlendShape => _blendShape;

		public int ShapeIndex => (int)BlendShape;

		public int Value => _value;

		public FaceShape(FaceBlendShape blendShape, int value)
		{
			_blendShape = blendShape;
			_value = value;
		}
	}
}
