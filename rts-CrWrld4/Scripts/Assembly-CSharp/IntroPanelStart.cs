using TMPro;
using UnityEngine;

public class IntroPanelStart : MonoBehaviour
{
	private enum State
	{
		INITIALWAIT = 0,
		FADEINCREEPERWORLD = 1,
		FADEINQUOTE0 = 2,
		FADEINQUOTE1 = 3,
		WAIT = 4,
		DONE = 5
	}

	public Intro intro;

	public TextMeshProUGUI creeperWorldText;

	public TextMeshProUGUI quote0Text;

	public TextMeshProUGUI quote1Text;

	public float initialTime;

	public float fadeInTime;

	public float fadeInTimeQuote0;

	public float fadeInTimeQuote1;

	public float waitTime;

	private float a;

	private State state;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetState(State state)
	{
	}
}
