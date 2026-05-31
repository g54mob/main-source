using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DLCElement : MonoBehaviour
{
	[Header("UI")]
	[SerializeField]
	private TextMeshProUGUI text;

	[SerializeField]
	private DLCTestController.DLCs type;

	[Header("[-- Toggle --]")]
	[SerializeField]
	private Color closeColor;

	[SerializeField]
	private Color openColor;

	[SerializeField]
	private Image toggleBackground;

	[SerializeField]
	private RectTransform toggleGraphic;

	[SerializeField]
	private Button toggleButton;

	[Header("Anim")]
	[SerializeField]
	private float offX;

	[SerializeField]
	private float onX;

	[SerializeField]
	private float duration;

	[SerializeField]
	private Ease ease;

	private bool _isOn;

	private Sequence _seq;

	private static readonly List<DLCElement> s_All;

	private static bool s_Suppress;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnToggleClicked()
	{
	}

	private void SetState(bool on, bool animate, bool fromUser)
	{
	}

	private void ApplyVisual(bool on, bool animate)
	{
	}

	private void WriteToController(bool on)
	{
	}

	private static void OpenAllIndividuals(bool animate)
	{
	}

	private static void EvaluateAllAutoRules()
	{
	}
}
