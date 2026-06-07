using System;
using UnityEngine;

public class StandaloneViewer : MonoBehaviour
{
	public GameRecorderViewer gameRecorderViewer;

	[NonSerialized]
	public GameRecorder recorder;

	private void Awake()
	{
	}

	public void OnLoad()
	{
	}
}
