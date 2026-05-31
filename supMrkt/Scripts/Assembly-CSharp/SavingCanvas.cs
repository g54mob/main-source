using UnityEngine;

public class SavingCanvas : NoktaSingleton<SavingCanvas>
{
	[SerializeField]
	private CanvasGroup m_SavingIndicator;

	[Space]
	[SerializeField]
	private float m_FadeInDuration;

	[SerializeField]
	private float m_FadeOutDuration;

	[SerializeField]
	private float m_Lifetime;

	public void PlaySavingIndicator()
	{
	}
}
