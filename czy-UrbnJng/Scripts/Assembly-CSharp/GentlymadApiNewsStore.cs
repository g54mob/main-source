using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

public class GentlymadApiNewsStore : RemoteNewsSource
{
	private string extractedImageURL;

	public override void Initalize(Action<GenericNews> onSuccess)
	{
		genericNews = new GenericNews();
		onSuccessActions.Add(onSuccess);
	}

	public override void GetNews()
	{
		GetNewsFromRemoteRequest("https://api.gentlymad.co/api/collections/get/UrbanJungleNews");
	}

	protected override void FormatNewsSource(string body)
	{
		try
		{
			foreach (Entries entry in JsonConvert.DeserializeObject<GentlymadAPINews>(body).entries)
			{
				if (entry.pinned && entry.tags.Contains("STEAM"))
				{
					if (entry.defines != null)
					{
						entry.defines.Contains(null);
					}
					excerpt = entry.GetLocalizedExcerpt(language);
					genericNews.title = entry.GetLocalizedTitle(language);
					genericNews.urlToClick = entry.url;
					CleanUp();
					genericNews.content = excerpt;
					extractedImageURL = "https://api.gentlymad.co/storage/uploads/" + entry.image.path;
					SetImage();
					break;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(ex.Message);
			SetFallBackSource();
		}
	}

	public override void CleanUp()
	{
		excerpt = excerpt.Replace("<a href=", "<style=DefaultLink\"><link=");
		excerpt = excerpt.Replace("<ul>", "");
		excerpt = excerpt.Replace("<ol>", "");
		excerpt = excerpt.Replace("</ul>", "");
		excerpt = excerpt.Replace("</ol>", "");
		excerpt = excerpt.Replace("<li>", "<style=\"List\">");
		excerpt = excerpt.Replace("</li>", "</style>");
		excerpt = excerpt.Replace("</a>", "</link></style>");
		excerpt = excerpt.Replace("<strong>", "<b>");
		excerpt = excerpt.Replace("</strong>", "</b>");
		excerpt = excerpt.Replace("<em>", "<i>");
		excerpt = excerpt.Replace("</em>", "</i>");
		excerpt = excerpt.Replace("<h3>", "<size=25>");
		excerpt = excerpt.Replace("</h3>", "</size>");
		excerpt = Regex.Replace(excerpt, "\\[[^]]+\\]", "");
		excerpt = Regex.Replace(excerpt, "[\r\n]+", "\n\n");
		excerpt = Regex.Replace(excerpt, "^\\s*$\\n|\\r", string.Empty, RegexOptions.Multiline).TrimEnd();
		excerpt = excerpt.Replace("<br><br>", "");
		excerpt = excerpt.Replace("<br>", "");
	}

	protected override async void SetImage()
	{
		try
		{
			byte[] bytes = await new HttpClient().GetByteArrayAsync(extractedImageURL);
			genericNews.newsSprite = GetSpriteFromByteArray(bytes);
			foreach (Action<GenericNews> onSuccessAction in onSuccessActions)
			{
				onSuccessAction?.Invoke(genericNews);
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.Message);
		}
	}
}
