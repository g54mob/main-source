using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoController : MonoBehaviour
{
	public static DemoController Instance;

	[SerializeField]
	private bool isDemo;

	[SerializeField]
	private bool canPlayDemo;

	[SerializeField]
	private GameObject demoObjects;

	[SerializeField]
	private GameObject demoTextLogo;

	[SerializeField]
	private TextMeshProUGUI demoTimer;

	[SerializeField]
	private float minutes;

	[SerializeField]
	private float seconds;

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		demoObjects.SetActive(isDemo);
		demoTextLogo.SetActive(isDemo);
		canPlayDemo = !PlayerPrefs.HasKey("canPlayDemo") || ((PlayerPrefs.GetInt("canPlayDemo") != 0) ? true : false);
		minutes = (PlayerPrefs.HasKey("minutes") ? PlayerPrefs.GetFloat("minutes") : 60f);
		seconds = (PlayerPrefs.HasKey("seconds") ? PlayerPrefs.GetFloat("seconds") : 0f);
		if (!canPlayDemo)
		{
			DontAllowPlaying();
		}
	}

	private void Update()
	{
		if (isDemo && canPlayDemo)
		{
			seconds -= Time.deltaTime;
			if (seconds < 0f)
			{
				minutes -= 1f;
				if (minutes < 0f)
				{
					canPlayDemo = false;
					seconds = 0f;
					minutes = 0f;
					DontAllowPlaying();
				}
				else
				{
					seconds = 59f;
				}
			}
		}
		demoTimer.text = "Demo time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
		PlayerPrefs.SetFloat("minutes", minutes);
		PlayerPrefs.SetFloat("seconds", seconds);
	}

	public bool IsDemo()
	{
		return isDemo;
	}

	public void DontAllowPlaying()
	{
		PlayerPrefs.SetInt("canPlayDemo", 0);
		SceneManager.LoadScene("DemoFinished");
	}
}
