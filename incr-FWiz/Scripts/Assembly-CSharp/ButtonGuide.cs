using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class ButtonGuide : MonoBehaviour
{
	public RectTransform ThisTransform;

	public TextMeshProUGUI Text;

	private RectTransform _targetTransform;

	public static ButtonGuide Instance { get; private set; }

	public void Initiate()
	{
	}

	public void AddRequest(RectTransform rectTransform, LocalizedString text, List<string> smartVariables)
	{
	}

	public void RemoveRequest(RectTransform transform)
	{
	}
}
