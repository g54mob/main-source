using TMPro;
using UnityEngine;

public class MissionScanner : MonoBehaviour
{
	private enum STATE
	{
		STARTING = 0,
		SCANNING = 1,
		RESULTS = 2,
		DONE = 3
	}

	public GameObject scannerMeshProjector;

	public RectTransform scanLine;

	public TextMeshProUGUI scanText;

	public RectTransform adaLogButton;

	private const float scanTime = 0.5f;

	private const float resultsTime = 0.25f;

	private STATE state;

	private float startElapsedTime;

	private float startFontSize;

	private float _scanLinePos;

	private float _scanTextAlpha;

	private float _scanningTextPos;

	private float scanLinePos
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private float scanTextAlpha
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private float scanningTextPos
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}

	public void Scan()
	{
	}

	public void Update()
	{
	}

	private void SetState(STATE state)
	{
	}

	private void PulseText()
	{
	}

	public bool IsDone()
	{
		return false;
	}

	public void SetDone()
	{
	}
}
