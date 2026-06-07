using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Track Target")]
	[Category("Tracking/Track Target")]
	[Image(typeof(IconCubeSolid), ColorTheme.Type.Yellow, typeof(OverlayArrowRight))]
	[Description("A translation towards a specific target and an optional rotation")]
	[Keywords(new string[] { "Track", "Follow", "Towards", "Away" })]
	public class GetLocationTrackLocation : TGetLocationTrackLocation
	{
		[SerializeField]
		private PropertyGetGameObject m_From = GetGameObjectSelf.Create();

		[SerializeField]
		private PropertyGetGameObject m_To = GetGameObjectTarget.Create();

		public override string String => $"{m_From} Track {m_To}";

		public static PropertyGetLocation Create()
		{
			return new PropertyGetLocation(new GetLocationTrackLocation());
		}

		protected override GameObject GetFrom(Args args)
		{
			return m_From.Get(args);
		}

		protected override GameObject GetTo(Args args)
		{
			return m_To.Get(args);
		}
	}
}
