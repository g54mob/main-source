using System;

public interface IBaseView
{
	object Controller { get; set; }

	event Action<string, object[]> NotifyChangeEvent;

	void NotifyChange(string eventName, params object[] data);
}
