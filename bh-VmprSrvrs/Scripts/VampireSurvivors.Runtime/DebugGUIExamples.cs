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

	[DebugGUIGraph(0f, 1f, 1f, -1f, 1f, 0, true)]
	private float CosProperty => 0f;

	[DebugGUIGraph(1f, 0.5f, 1f, -1f, 1f, 0, true)]
	private float SinProperty => 0f;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
	}

	private void OnDestroy()
	{
	}
}
