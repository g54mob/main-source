using TMPro;
using UnityEngine;
using UnityEngine.Localization;

[RequireComponent(typeof(Canvas))]
public class TutorialObjectiveDisplay : MonoBehaviour
{
	[SerializeField]
	private TMP_Text m_TitleText;

	[SerializeField]
	private TMP_Text m_DescriptionText;

	private Canvas m_Canvas;

	private void Awake()
	{
	}

	public void SetObjectiveDataWithArgs(TutorialObjectiveData data, params object[] args)
	{
	}

	public void SetObjectiveData(TutorialObjectiveData data)
	{
	}

	private void UpdateText(TMP_Text text, LocalizedString localizedString, params object[] args)
	{
	}

	private void UpdateText(TMP_Text text, LocalizedString localizedString)
	{
	}

	public void Toggle(bool value)
	{
	}
}
