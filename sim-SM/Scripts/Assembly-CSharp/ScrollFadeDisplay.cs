using UnityEngine;
using UnityEngine.UI;

public class ScrollFadeDisplay : MonoBehaviour
{
	[SerializeField]
	private Image m_FadeTop;

	[SerializeField]
	private Image m_FadeBottom;

	[SerializeField]
	private float m_FadeStartDistance;

	[SerializeField]
	private ScrollRect m_ScrollRect;

	private float m_MaxAlpha;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetAlpha(Image image, float alpha)
	{
	}
}
