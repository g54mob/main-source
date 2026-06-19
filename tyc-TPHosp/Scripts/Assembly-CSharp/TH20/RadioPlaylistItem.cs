using UnityEngine;

namespace TH20
{
	public class RadioPlaylistItem
	{
		public float LeadOutTime = 2f;

		public AudioClip Clip;

		public string ClipVOTag;

		public AudioClip LocalisedClip
		{
			get
			{
				AudioClip localizedVO = AudioManager.VOManager.GetLocalizedVO(ClipVOTag);
				if (!(localizedVO != null))
				{
					return Clip;
				}
				return localizedVO;
			}
		}
	}
}
