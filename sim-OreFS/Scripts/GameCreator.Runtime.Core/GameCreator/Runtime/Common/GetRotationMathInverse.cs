using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Inverse Rotation")]
	[Category("Math/Inverse Rotation")]
	[Image(typeof(IconContrast), ColorTheme.Type.Blue)]
	[Description("Inverses the Quaternion rotation")]
	public class GetRotationMathInverse : PropertyTypeGetRotation
	{
		[SerializeField]
		protected PropertyGetRotation m_Rotation = GetRotationIdentity.Create;

		public static PropertyGetRotation Create => new PropertyGetRotation(new GetRotationMathInverse());

		public override string String => $"Inverse {m_Rotation}";

		public override Quaternion Get(Args args)
		{
			return Quaternion.Inverse(m_Rotation.Get(args));
		}
	}
}
