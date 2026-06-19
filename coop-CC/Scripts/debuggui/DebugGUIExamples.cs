using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DebugGUIExamples : MonoBehaviour
{
	[DebugGUIGraph(0f, 1f, 0f, -1f, 1f, 0, true)]
	private float SinField;

	[DebugGUIPrint]
	[DebugGUIGraph(1f, 0.3f, 0.3f, 0f, 1f, 1, true)]
	private float mouseX;

	[DebugGUIPrint]
	[DebugGUIGraph(0f, 1f, 0f, 0f, 1f, 1, true)]
	private float mouseY;

	private Queue<float> deltaTimeBuffer = new Queue<float>();

	[DebugGUIGraph(0f, 1f, 1f, -1f, 1f, 0, true)]
	private float CosProperty => Mathf.Cos(Time.time * 6f);

	[DebugGUIGraph(1f, 0.3f, 1f, -1f, 1f, 0, true)]
	private float SinProperty => Mathf.Sin((Time.time + MathF.PI / 2f) * 6f);

	private float smoothDeltaTime => deltaTimeBuffer.Sum() / (float)deltaTimeBuffer.Count;

	private void Awake()
	{
		for (int i = 0; i < 10; i++)
		{
			deltaTimeBuffer.Enqueue(0f);
		}
	}

	private void Update()
	{
		deltaTimeBuffer.Dequeue();
		deltaTimeBuffer.Enqueue(Time.deltaTime);
		SinField = Mathf.Sin(Time.time * 6f);
		Vector3 mousePosition = Input.mousePosition;
		Resolution currentResolution = Screen.currentResolution;
		mouseX = Mathf.Clamp(mousePosition.x, 0f, currentResolution.width);
		mouseY = Mathf.Clamp(mousePosition.y, 0f, currentResolution.height);
		Input.GetMouseButton(0);
		_ = smoothDeltaTime;
		_ = 0f;
		_ = Time.deltaTime;
		_ = 0f;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			UnityEngine.Object.Destroy(this);
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			Debug.Log(DebugGUI.ExportGraphs());
		}
	}

	private void FixedUpdate()
	{
	}

	private void OnDestroy()
	{
	}
}
