using System;
using System.Collections.Generic;
using Gh.Tk.UI;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class DevCommentaryToolbar3DUIView : ShowHideAnimation3DUIView
	{
		[SerializeField]
		private List<BaseInteractable3DUIView> _closeButtons;

		[SerializeField]
		private Container3DUIView _mainBodyContainer;

		[SerializeField]
		private Slider3DUIView _playbackSlider;

		public bool usePlaybackProgressBar;

		[SerializeField]
		private BaseProgressBar3DUIView _playBackProgressBar;

		[SerializeField]
		private Button3DUIView _playbackButton;

		[SerializeField]
		private TextMeshProI18n _titleLabel;

		[SerializeField]
		private TextMeshProI18n _speakerLabel;

		[SerializeField]
		private TextMeshProUGUII18n _transcriptText;

		[SerializeField]
		private AccordionButton3DUIView _transcriptToggleButton;

		[SerializeField]
		private Slider3DUIView _transcriptSizeSlider;

		[SerializeField]
		private BoxCollider _mediaBlockContainer;

		[SerializeField]
		private DynamicContent3DUIView _mediaBlock;

		private bool _didAutoPause;

		private uint _playingClip;

		private float _durationInSeconds;

		private bool _isAudioPlaying;

		private bool _isPaused;

		public DevCommentaryMetadata CurrentData { get; private set; }

		private bool IsAudioAvailable => false;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnTranscriptSizeChanged(object sender, EventArgs e)
		{
		}

		private void UpdateTranscriptScrollSize()
		{
		}

		private void PauseClicked()
		{
		}

		private void OnPlaybackHandlePressChanged(object sender, EventArgs e)
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void UpdateTranscriptVisualState()
		{
		}

		private void OnTimeSettingChanged(object sender, EventArgs e)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		public void PlayDevCommentary(DevCommentaryMetadata item)
		{
		}

		private void SetMediaBlock(string itemMedia)
		{
		}

		private void Update()
		{
		}
	}
}
