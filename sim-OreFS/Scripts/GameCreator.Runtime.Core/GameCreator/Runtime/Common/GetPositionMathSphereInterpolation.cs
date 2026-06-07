using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Sphere Interpolation")]
	[Category("Math/Sphere Interpolation")]
	[Image(typeof(IconInterpolate), ColorTheme.Type.Green)]
	[Description("Calculates a new position as a sphere interpolation between two positions")]
	[Example("A sphere interpolation is a value along any intermediate points between the two provided positions. The interpolation is measured between 0 and 1.")]
	[Example("Sphere interpolation has higher growth around the middle values and slows down at the start and end edges")]
	[Example("Clamp allows to determine whether the resulting position should be extrapolated if theinterpolation value is below 0 or higher than 1.")]
	[Keywords(new string[] { "Blend", "Ease", "Smooth", "Intermediate" })]
	public class GetPositionMathSphereInterpolation : PropertyTypeGetPosition
	{
		private enum ClampMode
		{
			Clamp = 0,
			Overshoot = 1
		}

		[SerializeField]
		private PropertyGetPosition m_Position1 = GetPositionSelf.Create();

		[SerializeField]
		private PropertyGetPosition m_Position2 = GetPositionTarget.Create();

		[SerializeField]
		private PropertyGetDecimal m_Interpolation = GetDecimalDecimal.Create(0.5f);

		[SerializeField]
		private ClampMode m_Clamp;

		public override string String => $"[{m_Position1} ~ {m_Position2}]";

		public override Vector3 Get(Args args)
		{
			Vector3 a = m_Position1.Get(args);
			Vector3 b = m_Position2.Get(args);
			float t = (float)m_Interpolation.Get(args);
			return m_Clamp switch
			{
				ClampMode.Clamp => Vector3.Slerp(a, b, t), 
				ClampMode.Overshoot => Vector3.SlerpUnclamped(a, b, t), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public static PropertyGetPosition Create()
		{
			return new PropertyGetPosition(new GetPositionMathSphereInterpolation());
		}
	}
}
