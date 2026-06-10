using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuspectListEntryController : MonoBehaviour
{
	public RectTransform rect;

	public ButtonController button;

	public Evidence evidence;

	public GameplayController.History key;

	public TextMeshProUGUI nameText;

	public TextMeshProUGUI timeText;

	public RawImage evidenceImage;

	public void Setup(GameplayController.History sec)
	{
	}

	public void OpenEvidence(ButtonController press)
	{
	}

	public void VisualUpdate()
	{
	}

	private void OnDestroy()
	{
	}
}
