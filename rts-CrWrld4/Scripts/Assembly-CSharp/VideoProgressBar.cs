using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoProgressBar : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler
{
	public VideoPlayer videoPlayer;

	public Image progress;

	public TextMeshProUGUI timeText;

	public GameObject playAgain;

	public GameObject playButton;

	public GameObject pauseButton;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void PlayAgain()
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	private void TrySkip(PointerEventData eventData)
	{
	}

	private void SkipToPercent(float pct)
	{
	}

	public static string GetTimeString(float sec, bool onlySec = false)
	{
		return null;
	}
}
