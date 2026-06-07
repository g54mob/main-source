using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Rotation Away")]
	[Category("Tracking/Rotation Away")]
	[Image(typeof(IconEye), ColorTheme.Type.Red, typeof(OverlayArrowLeft))]
	[Description("A rotation of the object away from the specified one")]
	public class GetLocationTrackRotationAway : PropertyTypeGetLocation
	{
		[SerializeField]
		private PropertyGetGameObject m_AwayFrom = GetGameObjectTarget.Create();

		public override string String => $"Away {m_AwayFrom}";

		public override Location Get(Args args)
		{
			Transform transform = m_AwayFrom.Get<Transform>(args);
			return new Location(default(PositionNone), new RotationAway(transform));
		}

		public static PropertyGetLocation Create(PropertyGetGameObject away)
		{
			return new PropertyGetLocation(new GetLocationTrackRotationAway
			{
				m_AwayFrom = away
			});
		}
	}
}
