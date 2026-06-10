using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RevealResolveController : MonoBehaviour
{
	[Header("Components")]
	public RectTransform rect;

	public TextMeshProUGUI questionText;

	public GameObject tick;

	public GameObject cross;

	public JuiceController tickJuice;

	public JuiceController crossJuice;

	public List<CanvasRenderer> fadeInRenderers;

	[Header("State")]
	public bool isCorrect;

	public float revealAfterTimer;

	public float fadeIn;

	public float revealCorrectTimer;

	public float waitTimer;

	public float removeTimer;

	public string qText;

	public int revealPhase;

	private Case.ResolveQuestion question;

	public void Setup(Case.ResolveQuestion newQuestion, Case newCase, float newRevealAfter)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}
}
