using System;
using System.Net.Http;
using UnityEngine;

public abstract class RemoteNewsSource : NewsStoreBase
{
	private FileBasedNewsStore fallBackNews;

	protected abstract override void FormatNewsSource(string responseBody);

	protected abstract override void SetImage();

	protected void SetFallBackSource()
	{
		fallBackNews = new FileBasedNewsStore();
		fallBackNews.RerouteActions(onSuccessActions, language);
		fallBackNews.GetNews();
	}

	protected async void GetNewsFromRemoteRequest(string url)
	{
		string body = null;
		try
		{
			body = await new HttpClient().GetStringAsync(url);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
		FormatNewsSource(body);
	}

	public override void GetNews(string language)
	{
		SetLanguage(language);
		GetNewsFromRemoteRequest("https://api.gentlymad.co/api/collections/get/UrbanJungleNews");
	}

	protected Sprite GetSpriteFromByteArray(byte[] bytes)
	{
		Texture2D texture2D = new Texture2D(2, 2);
		texture2D.LoadImage(bytes);
		Rect rect = new Rect(0f, 0f, texture2D.width, texture2D.height);
		return Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f), 100f);
	}
}
