using TMPro;
using UnityEngine;

public class InGameTextIndicator : MonoBehaviour
{
	private const float m_HeightIncrease = 40f;

	private const float m_Duration = 1.4f;

	private const float m_FadeOutDelay = 0.5f;

	[SerializeField]
	private Color m_SuccessColor;

	[SerializeField]
	private Color m_FailColor;

	[SerializeField]
	private Color m_BoostColor;

	[SerializeField]
	private TMP_Text m_Text;

	public TMP_Text Text => null;

	public void Setup(string text, bool success)
	{
	}

	public void SetupEmployee(string text)
	{
	}

	private void PlayEffect()
	{
	}
}
