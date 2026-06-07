using UnityEngine;
using UnityEngine.UI;

public class NullifierControls : MonoBehaviour
{
	public GameObject overloadButton;

	public Text overloadText;

	public Text chargeText;

	public static bool CanOverload()
	{
		return false;
	}

	public void OnEnable()
	{
	}

	public void LateUpdate()
	{
	}

	public void OnOverload()
	{
	}
}
