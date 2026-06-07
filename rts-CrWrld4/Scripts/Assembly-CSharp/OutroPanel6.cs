using TMPro;
using UnityEngine;

public class OutroPanel6 : MonoBehaviour
{
	private enum State
	{
		FADEIN = 0,
		WAITONINPUT = 1,
		WAIT = 2,
		DONE = 3
	}

	public Outro outro;

	public TextMeshProUGUI text;

	public GameObject button;

	public float fadeInTime;

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

	public void OnDone()
	{
	}
}
