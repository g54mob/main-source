using NSEipix.Model;
using NSEipix.Repository;
using UnityEngine.Video;

namespace NSMedieval.Repository
{
	public class VideoClipRepository : MonoRepository<VideoClipRepository, KeyVideoClipPair>
	{
		public VideoClip GetClip(string clipName)
		{
			KeyVideoClipPair byID = GetByID(clipName);
			if (!(byID == null))
			{
				return byID.Value;
			}
			return null;
		}
	}
}
