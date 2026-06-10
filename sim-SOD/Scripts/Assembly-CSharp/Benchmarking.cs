using NaughtyAttributes;
using TMPro;
using UnityEngine;

public class Benchmarking : MonoBehaviour
{
	[Header("State")]
	public bool benchmarkingActive;

	public int frames;

	public float secondsPassed;

	public float fpsLow;

	public float fpsHigh;

	[Header("Components")]
	public TextMeshProUGUI fpsText;

	private static Benchmarking _instance;

	public static Benchmarking Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void StartBenchmarking()
	{
	}

	public void PauseBenchmarking()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void StopBenchmarking()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ResetBenchmarking()
	{
	}
}
