using Assets.Scripts.Audio;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;

namespace Assets.Scripts.UI
{
	public class MusicPlayerUIScript : WidgetScript
	{
		private TextWidget _nameText;

		private SliderWidget _volumeSlider;

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_nameText = widget.FindWidget<TextWidget>("song-name-text");
			_volumeSlider = widget.FindWidget<SliderWidget>("volume-slider");
			_volumeSlider.ValueChanged += delegate(float x)
			{
				Game.Instance.Settings.Gameplay.Audio.MusicVolume.Value = x;
				Game.Instance.Settings.Gameplay.Audio.MusicVolume.CommitChanges();
			};
			base.Widget.PointerEnter += delegate
			{
				_volumeSlider.Value = Game.Instance.Settings.Gameplay.Audio.MusicVolume.Value;
			};
		}

		protected void Update()
		{
			MusicPlayerScript musicPlayer = Game.Instance.MusicPlayer;
			bool flag = musicPlayer.PlayingSong != null && musicPlayer.Volume > 0f;
			base.Widget.EnableClass("music-playing", flag);
			if (flag)
			{
				_nameText.Text = "\"" + musicPlayer.PlayingSong.Title + "\"";
			}
			else
			{
				_nameText.Text = "Music Off";
			}
		}
	}
}
