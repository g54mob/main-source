using System;

public interface INewsStore
{
	void CleanUp();

	void GetNews();

	void GetNews(string language);

	void SetLanguage(string language);

	void Initalize(Action<GenericNews> onSuccess);
}
