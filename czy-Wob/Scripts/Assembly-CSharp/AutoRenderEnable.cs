using UnityEngine;
using UnityEngine.UI;

public class AutoRenderEnable : MonoBehaviour
{
	public bool enable = true;

	private void Start()
	{
		Renderer component = GetComponent<Renderer>();
		if (component != null)
		{
			component.enabled = enable;
		}
		else
		{
			Image component2 = GetComponent<Image>();
			if (component2 != null)
			{
				component2.enabled = enable;
			}
		}
		Object.Destroy(this);
	}
}
