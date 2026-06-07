using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Rotation Towards")]
	[Category("Tracking/Rotation Towards")]
	[Image(typeof(IconEye), ColorTheme.Type.Green, typeof(OverlayArrowRight))]
	[Description("A rotation of the object towards the specified one")]
	public class GetLocationTrackRotationTowards : PropertyTypeGetLocation
	{
		[SerializeField]
		private PropertyGetGameObject m_Towards = GetGameObjectTarget.Create();

		public override string String => $"Towards {m_Towards}";

		public override Location Get(Args args)
		{
			Transform transform = m_Towards.Get<Transform>(args);
			return new Location(default(PositionNone), new RotationTowards(transform));
		}

		public static PropertyGetLocation Create(PropertyGetGameObject towards)
		{
			return new PropertyGetLocation(new GetLocationTrackRotationTowards
			{
				m_Towards = towards
			});
		}
	}
}
