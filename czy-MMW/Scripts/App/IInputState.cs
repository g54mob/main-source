public interface IInputState
{
	IPointerState Mouse { get; }

	int TouchCount { get; }

	int MaxTouchCount { get; }

	bool MousePresent { get; }

	bool BlockUIInput { get; set; }

	bool BlockGameInput { get; set; }

	bool BlockAllInput { get; set; }

	bool BlockActions { get; set; }

	bool TryGetTouch(int touchIndex, out IPointerState result);

	float GetAxis(int rewiredInputAxisId);

	bool GetButton(int rewiredInputAction);

	void Start();

	void Tick(float appTime);

	void OnInputEvent(float appTime, InputEvent inputEvent);

	bool IsInputEventOverUI(InputEvent inputEvent);

	void OnWindowFocusChanged(bool appHasWindowFocus);

	void OnInternalFocusChanged(bool appHasInternalFocus);

	void SubscribeToControllerConnectionMessages(IControllerConnectionObserver controllerConnectionObserver);

	void UnsubscribeFromControllerConnectionMessages(IControllerConnectionObserver controllerConnectionObserver);

	void ControllerConnected(IController newController);

	void ControllerDisconnected(IController oldController);

	void EnsurePollingRewiredAction(int rewiredInputAction);

	void IgnoreInputAction(int rewiredInputAction);

	void EnsurePollingAxis(int rewiredInputAxisId);

	void IgnorePollingAxis(int rewiredInputAxisId);
}
