using UnityEngine;

public class ButtonInformation : MonoBehaviour
{
	public static ButtonInformation Instance;

	public RectTransform ListDevice;

	public void Awake()
	{
	}

	private void Start()
	{
	}

	public static void Invoke(BIDeviceKey device, BITagKey key, bool active)
	{
	}
}
