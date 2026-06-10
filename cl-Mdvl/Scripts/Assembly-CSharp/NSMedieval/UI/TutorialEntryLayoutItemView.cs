using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Repository;
using UnityEngine.Video;

namespace NSMedieval.UI
{
	public class TutorialEntryLayoutItemView : LayoutGroupItemView
	{
		private int textIndex;

		public void SetData(string infoKey, string videoName)
		{
			SetText(textIndex, infoKey);
			base.GroupItems[1].GetComponent<VideoPlayer>().clip = MonoRepository<VideoClipRepository, KeyVideoClipPair>.Instance.GetClip(videoName);
		}
	}
}
