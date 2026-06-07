using System;
using UnityEngine;

namespace Assets.Scripts.Character.FacialExpression
{
	[Serializable]
	public class FacialExpression
	{
		[SerializeField]
		private string _expressionName;

		[SerializeField]
		private FaceShape[] _faceShapes;

		[Range(0f, 1f)]
		[SerializeField]
		private float _weight;

		public FaceShape[] FaceShapes => _faceShapes;

		public float Weight
		{
			get
			{
				return _weight;
			}
			set
			{
				_weight = Mathf.Clamp01(value);
			}
		}
	}
}
