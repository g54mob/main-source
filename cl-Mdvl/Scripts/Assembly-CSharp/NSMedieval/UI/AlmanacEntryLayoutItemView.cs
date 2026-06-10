using NSEipix.Model;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Repository;
using UnityEngine.Video;

namespace NSMedieval.UI
{
	public class AlmanacEntryLayoutItemView : LayoutGroupItemView
	{
		private int titleIndex;

		private int textIndex = 2;

		private int previousButtonIndex = 4;

		private int nextButtonIndex = 5;

		public SoundButton PreviousButton => base.GroupItems[previousButtonIndex].GetComponent<SoundButton>();

		public SoundButton NextButton => base.GroupItems[nextButtonIndex].GetComponent<SoundButton>();

		public void SetData(string titleKey, string infoKey, string spriteName, string videoName)
		{
			SetText(titleIndex, titleKey);
			SetText(textIndex, infoKey);
			if (videoName != "null")
			{
				base.GroupItems[3].GetComponent<VideoPlayer>().clip = MonoRepository<VideoClipRepository, KeyVideoClipPair>.Instance.GetClip(videoName);
				base.GroupItems[3].SetActive(value: true);
				base.GroupItems[1].SetActive(value: false);
			}
			else if (spriteName != "null")
			{
				base.GroupItems[1].SetActive(value: true);
				SetImage(1, spriteName);
				base.GroupItems[3].SetActive(value: false);
			}
			else
			{
				base.GroupItems[1].SetActive(value: false);
				base.GroupItems[3].SetActive(value: false);
			}
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
			NextButton.gameObject.SetActive(active);
			PreviousButton.gameObject.SetActive(active);
		}
	}
}
