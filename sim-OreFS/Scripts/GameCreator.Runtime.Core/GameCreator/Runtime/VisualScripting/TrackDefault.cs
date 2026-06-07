using System;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	public class TrackDefault : Track
	{
		[SerializeReference]
		private ClipDefault[] m_Clips = Array.Empty<ClipDefault>();

		public override int TrackOrder => 0;

		public override IClip[] Clips => m_Clips;

		public TrackDefault()
		{
		}

		public TrackDefault(ClipDefault[] clips)
		{
			m_Clips = clips;
		}
	}
}
