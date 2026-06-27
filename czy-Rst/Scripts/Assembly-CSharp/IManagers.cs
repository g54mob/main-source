using System;

public interface IManagers
{
	void Initialize(Action<bool> onFinish = null);

	void StartUp(bool fullReset = false, Action<bool> onFinish = null);

	void Reset(Action<bool> onFinish = null);
}
