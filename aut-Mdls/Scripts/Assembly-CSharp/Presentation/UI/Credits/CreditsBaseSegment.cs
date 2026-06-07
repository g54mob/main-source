using Data.Credits;
using UnityEngine;

namespace Presentation.UI.Credits
{
	public abstract class CreditsBaseSegment : MonoBehaviour
	{
		private void Awake()
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		private void OnLanguageUpdate()
		{
			UpdateTexts();
		}

		protected abstract void UpdateTexts();

		public abstract void SetContent(CreditsSegmentData segmentData);
	}
}
