using UnityEngine;

public class OutdoorSpotLight : MonoBehaviour
{
	[SerializeField]
	private Light m_Light;

	private bool m_IsOn;

	[SerializeField]
	private Renderer m_EmissiveRenderer;

	[SerializeField]
	private int m_EmissiveMaterialIndex;

	private Color m_EmissiveMaterialColor;

	public bool IsOn
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}
