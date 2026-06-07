using UnityEngine;

public sealed class OVRTouchpadHelper : MonoBehaviour
{
	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		OVRTouchpad.AddListener(LocalTouchEventCallback);
	}

	private void Update()
	{
		OVRTouchpad.Update();
	}

	public void OnDisable()
	{
		OVRTouchpad.OnDisable();
	}

	private void LocalTouchEventCallback(OVRTouchpad.TouchEvent touchEvent)
	{
		switch (touchEvent)
		{
		}
	}
}
