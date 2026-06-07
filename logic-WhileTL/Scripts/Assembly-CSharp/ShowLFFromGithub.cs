using Ludenio.Operator;
using UnityEngine;
using UnityEngine.UI;

public class ShowLFFromGithub : ActiveComponent
{
	[SceneBind("Image")]
	public Button Image;

	[SceneBind("TitleImage/Title")]
	public Text Title;

	public OperatorTools OperatorTools;

	private bool inited;

	private bool newsSet;

	private void Awake()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		Title.transform.parent.gameObject.SetActive(value: false);
		Image.gameObject.SetActive(value: false);
	}

	private void SetNews()
	{
		if (!newsSet)
		{
			Image.image.sprite = OperatorTools.Config.Sprite;
			Title.text = OperatorTools.Config.Title;
			Title.transform.parent.gameObject.SetActive(value: true);
			Image.gameObject.SetActive(value: true);
			if (Title.text == "NONE")
			{
				Title.transform.parent.gameObject.SetActive(value: false);
			}
			Image.onClick.AddListener(delegate
			{
				Logic.SendAnalytics("EPIC_TO_LF_URL", null);
				Application.OpenURL(OperatorTools.Config.URL);
			});
			newsSet = true;
		}
	}

	private void OnCongigReceived(bool success)
	{
		if (inited && OperatorTools.IsConfigHealthy)
		{
			SetNews();
		}
	}

	private void FixedUpdate()
	{
		if (!inited)
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
				base.gameObject.SetActive(value: false);
			}
			else
			{
				SetNews();
			}
		}
	}
}
