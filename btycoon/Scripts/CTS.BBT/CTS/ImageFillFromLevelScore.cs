using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class ImageFillFromLevelScore : CTSBehaviour
	{
		[SerializeField]
		private SoftReference<MapInfoSO> _mapInfo;

		[SerializeField]
		private Image[] _images;

		[SerializeField]
		private int _maxScore = 6;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (!CTSSingleton<ProfileManager>.TryGetInstance(out var outInstance) || !(outInstance.CurrentProfile is CareerProfile careerProfile))
			{
				return;
			}
			MapInfoSO key = _mapInfo.Get();
			if (careerProfile.LevelProgress.TryGetValue(key, out var value))
			{
				float num = (float)_maxScore / (float)_images.Length;
				float num2 = value.Score;
				Image[] images = _images;
				foreach (Image obj in images)
				{
					float num3 = Mathf.Min(num, num2);
					num2 -= num3;
					obj.fillAmount = num3 / num;
				}
			}
		}
	}
}
