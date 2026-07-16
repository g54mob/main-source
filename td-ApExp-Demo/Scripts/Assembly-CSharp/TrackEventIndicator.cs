using AudioSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrackEventIndicator : MonoBehaviour
{
	private bool hasStarted;

	private bool isLooping;

	private Image image;

	private Animator anim;

	[SerializeField]
	private SoundData ping;

	[SerializeField]
	private GameObject scrambledIndicator;

	[SerializeField]
	private Image insideImg;

	[field: SerializeField]
	public Transform DistancePanelTf { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI DistanceText { get; private set; }

	[field: SerializeField]
	public Image SkullIcon { get; private set; }

	private void Awake()
	{
		image = GetComponent<Image>();
		anim = GetComponent<Animator>();
		DistancePanelTf = base.transform.Find("Distance Panel");
		DistanceText = DistancePanelTf.Find("Distance Text").GetComponent<TextMeshProUGUI>();
		base.gameObject.SetActive(value: false);
		image.enabled = false;
		if ((bool)insideImg)
		{
			insideImg.enabled = false;
		}
		EnemyManager.Instance.OnScramble += delegate
		{
			Scramble();
		};
		EnemyManager.Instance.OnUnscramble += Scramble;
	}

	public void StartWarning()
	{
		if (hasStarted)
		{
			return;
		}
		base.gameObject.SetActive(value: true);
		hasStarted = true;
		PersistentSingleton<SoundEmitterManager>.Instance.CreateSoundBuilder().Play(ping);
		if (EnemyManager.Instance.IsScrambling)
		{
			if ((bool)insideImg)
			{
				insideImg.enabled = false;
			}
			image.enabled = false;
			scrambledIndicator.SetActive(value: true);
			return;
		}
		scrambledIndicator.SetActive(value: false);
		if ((bool)insideImg)
		{
			insideImg.enabled = true;
		}
		image.enabled = true;
		anim.Play("Start", 0, 0f);
	}

	public void AnimStartFinished()
	{
		isLooping = true;
		if (EnemyManager.Instance.IsScrambling)
		{
			if ((bool)insideImg)
			{
				insideImg.enabled = false;
			}
			image.enabled = false;
			scrambledIndicator.SetActive(value: true);
			return;
		}
		scrambledIndicator.SetActive(value: false);
		if ((bool)insideImg)
		{
			insideImg.enabled = true;
		}
		image.enabled = true;
		anim.Play("Loop", 0, 0f);
	}

	public void StopWarning()
	{
		hasStarted = false;
		isLooping = false;
		scrambledIndicator.SetActive(value: false);
		image.enabled = false;
		if ((bool)insideImg)
		{
			insideImg.enabled = false;
		}
		base.gameObject.SetActive(value: false);
	}

	public void SetColor(Color color)
	{
		if (isLooping)
		{
			image.color = color;
		}
	}

	public void Scramble()
	{
		if (hasStarted)
		{
			AnimStartFinished();
		}
	}
}
