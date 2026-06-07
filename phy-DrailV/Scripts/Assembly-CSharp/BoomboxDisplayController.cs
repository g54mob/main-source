using TMPro;
using UnityEngine;

public class BoomboxDisplayController : MonoBehaviour
{
	private const string TEXT_TEMPLATE_CASSETTE_PLAYING_TOP = "{0}";

	private const string TEXT_TEMPLATE_CASSETTE_IDLE_TOP = "Stopped";

	private const string TEXT_TEMPLATE_PLAYING_CASSETTE_BOTTOM = "Volume: {0} - Tape: {1} - Song {2}";

	private const string TEXT_TEMPLATE_RADIO_TOP = "{0}";

	private const string TEXT_TEMPLATE_RADIO_TOP_BUFFERING = "{0} - Buffering: {1}%";

	private const string TEXT_TEMPLATE_RADIO_BOTTOM = "Volume: {0} - Station: {1} - Signal strength: {2}";

	public TextMeshPro topText;

	public TextMeshPro bottomText;

	private bool isOn;

	private int volumeX10 = 4;

	private bool isRadio;

	private bool radioIsPlaying;

	private bool radioIsBuffering;

	private float radioSignal = 1f;

	private string radioStationName = "";

	private int radioStationIndex;

	private float radioBufferingProgress = 1f;

	private string radioSong = "";

	private bool cassetteIsPlaying;

	private string cassetteSong = "";

	private string cassetteName = "";

	private int cassetteSongIndex;

	private void Awake()
	{
		OnPowerAndModeChanged(isOn: false, isRadio: false);
	}

	public void OnPowerAndModeChanged(bool isOn, bool isRadio)
	{
		this.isOn = isOn;
		this.isRadio = isRadio;
		UpdateDisplay();
	}

	public void OnVolumeChanged(float volume)
	{
		volumeX10 = Mathf.RoundToInt(Mathf.Clamp01(volume) * 10f);
		UpdateDisplay();
	}

	public void OnRadioBufferingStarted()
	{
		radioIsBuffering = true;
		radioBufferingProgress = 0f;
		UpdateDisplay();
	}

	public void OnRadioBufferingEnded()
	{
		radioIsBuffering = false;
		radioBufferingProgress = 1f;
		UpdateDisplay();
	}

	public void OnRadioBufferingProgress(float progress)
	{
		radioBufferingProgress = progress;
		UpdateDisplay();
	}

	public void OnRadioSongChanged(string songInfo)
	{
		radioSong = songInfo;
		UpdateDisplay();
	}

	public void OnRadioStationIndexChanged(int index)
	{
		radioStationIndex = index;
		UpdateDisplay();
	}

	public void OnRadioStationNameChanged(string name)
	{
		radioStationName = (string.IsNullOrWhiteSpace(name) ? "Radio" : name);
		UpdateDisplay();
	}

	public void OnRadioStopped()
	{
		radioIsPlaying = false;
		UpdateDisplay();
	}

	public void OnCassetteStartedPlaying()
	{
		cassetteIsPlaying = true;
		UpdateDisplay();
	}

	public void OnCassetteStoppedPlaying()
	{
		cassetteIsPlaying = false;
		UpdateDisplay();
	}

	public void OnCassetteSongChanged(string songInfo)
	{
		cassetteSong = songInfo;
		UpdateDisplay();
	}

	public void OnCassetteTrackIndexChanged(int trackIndex)
	{
		cassetteSongIndex = trackIndex;
		UpdateDisplay();
	}

	public void OnAntennaSignalChanged(float signal)
	{
		radioSignal = signal;
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		if (topText == null || bottomText == null)
		{
			return;
		}
		topText.enabled = isOn;
		bottomText.enabled = isOn;
		if (!isOn)
		{
			return;
		}
		if (isRadio)
		{
			if (radioIsBuffering)
			{
				topText.text = $"{Snip(radioStationName, 10)} - Buffering: {Mathf.Round(radioBufferingProgress * 100f)}%";
			}
			else
			{
				topText.text = string.Format("{0}", Snip(radioStationName, 20), Mathf.Round(radioBufferingProgress * 100f));
			}
			bottomText.text = $"Volume: {volumeX10} - Station: {radioStationIndex + 1} - Signal strength: {(int)Mathf.Clamp(radioSignal * 100f, 0f, 100f)}";
		}
		else
		{
			if (cassetteIsPlaying)
			{
				topText.text = $"{cassetteSong}";
			}
			else
			{
				topText.text = "Stopped";
			}
			bottomText.text = $"Volume: {volumeX10} - Tape: {cassetteName} - Song {cassetteSongIndex + 1}";
		}
	}

	private static string Snip(string s, int maxLength)
	{
		if (string.IsNullOrEmpty(s))
		{
			return "";
		}
		if (s.Length <= maxLength)
		{
			return s;
		}
		return s.Substring(0, maxLength);
	}
}
