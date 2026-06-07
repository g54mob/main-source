using UnityEngine;
using UnityEngine.UI;

public class AutoHider : MonoBehaviour
{
	private void Awake()
	{
		Image component = GetComponent<Image>();
		if (component != null)
		{
			component.enabled = false;
		}
	}
}
