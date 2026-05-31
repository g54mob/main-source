using UnityEngine;

public class CartMaxedIndicator : MonoBehaviour
{
	[SerializeField]
	private CanvasGroup m_CanvasGroup;

	[SerializeField]
	private RectTransform m_RectTransform;

	[Header("Settings")]
	[SerializeField]
	private float m_FadingTime;

	[SerializeField]
	private float m_FadingDuration;

	[SerializeField]
	private float m_TargetY;

	[SerializeField]
	private float m_RisingDuration;

	private float m_Height;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}
}
