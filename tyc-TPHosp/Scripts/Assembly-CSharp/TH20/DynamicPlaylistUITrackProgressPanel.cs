using TH20.ExtContent;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	public class DynamicPlaylistUITrackProgressPanel : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _textSongTitle;

		[SerializeField]
		private TMP_Text _textArtistName;

		[SerializeField]
		private Image _imageProgressBarBG;

		[SerializeField]
		private Image _imageProgressBar;

		[SerializeField]
		private float _progressBarMarginVert = 1f;

		[SerializeField]
		private float _progressBarMarginHoriz = 1f;

		private DynamicPlaylistManager _dynamicPlaylistManager;

		private bool _bAllUIItemsValid;

		public void Init(DynamicPlaylistManager dynamicPlaylistManager)
		{
			_dynamicPlaylistManager = dynamicPlaylistManager;
			_bAllUIItemsValid = _textSongTitle != null && _textArtistName != null && _imageProgressBarBG != null && _imageProgressBar != null;
			ExtContentTextureUtils.FitGameObjectToParent(base.gameObject);
			RefreshUI();
		}

		public void DeInit()
		{
		}

		public void Update()
		{
		}

		public void RefreshUI()
		{
			if (!_bAllUIItemsValid)
			{
				return;
			}
			if (_dynamicPlaylistManager.IsAnyTrackCurrentlyPlayingAndNotPaused())
			{
				string retArtistName = string.Empty;
				string retSongTitle = string.Empty;
				float retDurationSecs = 0f;
				_dynamicPlaylistManager.GetCurrentlyPlayingTrackStaticData(ref retArtistName, ref retSongTitle, ref retDurationSecs);
				float currentlyPlayingTrackPositionSecs = _dynamicPlaylistManager.GetCurrentlyPlayingTrackPositionSecs();
				float progressBarDisplayValue = 0f;
				if (retDurationSecs > 0f)
				{
					progressBarDisplayValue = currentlyPlayingTrackPositionSecs / retDurationSecs;
				}
				_textSongTitle.text = retSongTitle;
				_textArtistName.text = DynamicPlaylistManager.GetArtistDisplayName(retArtistName);
				SetProgressBarDisplayValue(progressBarDisplayValue);
			}
			else
			{
				_textSongTitle.text = string.Empty;
				_textArtistName.text = string.Empty;
				SetProgressBarDisplayValue(0f);
			}
		}

		private void SetProgressBarDisplayValue(float progressFactor)
		{
			RectTransform rectTransform = (RectTransform)_imageProgressBarBG.gameObject.transform;
			if (rectTransform != null)
			{
				RectTransform rectTransform2 = (RectTransform)_imageProgressBar.gameObject.transform;
				if (rectTransform2 != null)
				{
					rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, _progressBarMarginVert, rectTransform.rect.height - 2f * _progressBarMarginVert);
					rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, _progressBarMarginHoriz, rectTransform.rect.width * progressFactor - 2f * _progressBarMarginHoriz);
				}
			}
		}
	}
}
