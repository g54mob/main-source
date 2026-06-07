using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayNews : MonoBehaviour
{
	public TextMeshProUGUI scrollView;

	public TextMeshProUGUI header;

	public Image newsImage;

	public Button button;

	public RectTransform mainPanel;

	[SerializeField]
	private NewsSource source;

	[SerializeField]
	private Language language;

	private INewsStore newsStore;

	private GenericNews genericNews;

	private void Start()
	{
		button.onClick.AddListener(OnURLButtonClick);
		newsImage.canvasRenderer.SetAlpha(0.01f);
		switch (source)
		{
		case NewsSource.SteamNews:
			newsStore = new SteamNewsStore();
			break;
		case NewsSource.GenlymadNews:
			newsStore = new GentlymadApiNewsStore();
			newsStore.SetLanguage(language.ToString());
			break;
		case NewsSource.FileBasedNews:
			newsStore = new FileBasedNewsStore();
			newsStore.SetLanguage(language.ToString());
			break;
		}
		newsStore.Initalize(SetContent);
		newsStore.GetNews();
	}

	public void OnDestroy()
	{
		button.onClick.RemoveAllListeners();
	}

	public void OnURLButtonClick()
	{
		Application.OpenURL(genericNews.urlToClick);
	}

	private void SetContent(GenericNews genericNews)
	{
		this.genericNews = genericNews;
		scrollView.text = genericNews.content;
		header.text = genericNews.title;
		newsImage.CrossFadeAlpha(1f, 0.4f, ignoreTimeScale: true);
		newsImage.sprite = genericNews.newsSprite;
	}

	public void CallGetNews(string language)
	{
		if (newsStore != null)
		{
			newsStore.GetNews(language);
		}
	}
}
