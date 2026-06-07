using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class DCanvasScalerHandler : MonoBehaviour
{
	public Vector2 m_ReferenceResolution = new Vector2(1080f, 1920f);

	private void Start()
	{
		CanvasScaler component = GetComponent<CanvasScaler>();
		if (!component)
		{
			return;
		}
		if (Screen.width > Screen.height)
		{
			if (m_ReferenceResolution.x > m_ReferenceResolution.y)
			{
				component.referenceResolution = m_ReferenceResolution;
			}
			else
			{
				component.referenceResolution = new Vector2(m_ReferenceResolution.y, m_ReferenceResolution.x);
			}
		}
		else if (m_ReferenceResolution.x > m_ReferenceResolution.y)
		{
			component.referenceResolution = new Vector2(m_ReferenceResolution.y, m_ReferenceResolution.x);
		}
		else
		{
			component.referenceResolution = m_ReferenceResolution;
		}
	}
}
