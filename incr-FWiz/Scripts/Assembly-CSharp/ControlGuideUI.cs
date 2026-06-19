using TMPro;
using UnityEngine;

public class ControlGuideUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _controlText;

	public ControlGuide ControlGuide { get; private set; }

	public string ControlName => null;

	public void Set(ControlGuide controlGuide)
	{
	}
}
