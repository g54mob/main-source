using UnityEngine;

public class WinOSX : MonoBehaviour
{
	[Header("Activate for:")]
	public bool windows;

	public bool macOS;

	private void Awake()
	{
		if (macOS)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			_ = windows;
		}
	}
}
