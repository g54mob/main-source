using System;
using System.Collections.Generic;

public abstract class NewsStoreBase : INewsStore
{
	protected bool languageSupport;

	protected GenericNews genericNews;

	protected List<Action<GenericNews>> onSuccessActions = new List<Action<GenericNews>>();

	public string language;

	protected string excerpt;

	public abstract void CleanUp();

	public abstract void GetNews();

	public abstract void Initalize(Action<GenericNews> onSuccess);

	protected abstract void FormatNewsSource(string responseBody);

	protected abstract void SetImage();

	public void SetLanguage(string language)
	{
		this.language = language;
	}

	public abstract void GetNews(string language);
}
