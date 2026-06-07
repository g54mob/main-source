using UnityEngine;

public class PlatformDependentCoolButton : MonoBehaviour
{
	public CoolButton Btn;

	public bool OverrideMobile;

	public CoolButtonViz MobileViz;

	private void Awake()
	{
	}

	private void OnValidate()
	{
	}
}
