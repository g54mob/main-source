using Localization;
using Ludenio.Operator;
using UnityEngine;
using UnityEngine.UI;

public class NewsTimer : ActiveComponent
{
	[SceneBind("Link/StringHolder/Timer")]
	public Text Timer;

	[SceneBind("Link")]
	public Button Link;

	[SceneBind("Link/StringHolder/Title")]
	public Text Title;

	public OperatorTools OperatorTools;

	private bool inited;

	private bool newsSet;

	private void Awake()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		Timer.enabled = false;
		Link.enabled = false;
		Title.enabled = false;
		base.gameObject.GetComponent<Image>().enabled = false;
		Link.gameObject.SetActive(value: false);
	}

	private void SetNews()
	{
		if (newsSet)
		{
			return;
		}
		Link.image.sprite = OperatorTools.Config.Sprite;
		Title.text = OperatorTools.Config.Title;
		if (Title.text == "NONE")
		{
			Title.gameObject.SetActive(value: false);
		}
		Link.onClick.AddListener(delegate
		{
			if (Steam.IsAvailable())
			{
				Steam.ActivateGameOverlayToWebPage(OperatorTools.Config.URL);
			}
			else
			{
				Logic.OpenUrl(OperatorTools.Config.URL);
			}
		});
		Timer.enabled = true;
		Link.enabled = true;
		Title.enabled = true;
		base.gameObject.GetComponent<Image>().enabled = true;
		Link.gameObject.SetActive(value: true);
		newsSet = true;
	}

	private void OnCongigReceived(bool success)
	{
		if (inited && OperatorTools.IsConfigHealthy)
		{
			SetNews();
		}
	}

	public void OnApplicationQuit()
	{
		if (OperatorTools != null)
		{
			OperatorTools.StopAllCoroutines();
		}
	}

	private void FixedUpdate()
	{
		if (Timer == null)
		{
			return;
		}
		if (TextResources.IsReady && !inited)
		{
			OperatorTools = Object.FindObjectOfType<OperatorTools>();
			OperatorTools.OnConfigReceived.RemoveAllListeners();
			OperatorTools.OnConfigReceived.AddListener(OnCongigReceived);
			OperatorTools.TryDonwloadConfig();
			inited = true;
		}
		if (inited && OperatorTools.IsConfigHealthy)
		{
			if (!OperatorTools.IsNextDateInFuture)
			{
				Timer.gameObject.SetActive(value: false);
			}
			else
			{
				Timer.gameObject.SetActive(value: true);
			}
			SetNews();
			if (!(Timer == null) && !(OperatorTools == null) && OperatorTools.Config != null)
			{
				Timer.text = TextResources.GetString("TIME_BEFORE_UPDATE") + " " + OperatorTools.Config.GetRemainingTimeString();
			}
		}
	}
}
