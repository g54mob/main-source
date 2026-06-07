using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Away Direction")]
	[Category("Math/Away Direction")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow, typeof(OverlayMinus))]
	[Description("Inverse rotation from an Identity rotation towards a direction vector")]
	public class GetRotationAwayDirection : PropertyTypeGetRotation
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction = GetDirectionVector3Zero.Create();

		public override string String => $"Direction -{m_Direction}";

		public override Quaternion Get(Args args)
		{
			return Quaternion.LookRotation(-m_Direction.Get(args));
		}
	}
}
