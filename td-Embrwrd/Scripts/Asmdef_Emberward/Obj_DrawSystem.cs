using System.Collections.Generic;
using UnityEngine;

public class Obj_DrawSystem : MonoBehaviour
{
	[SerializeField]
	private LineRenderer currentLineRenderer;

	[SerializeField]
	private LineRenderer baseLineRenderer;

	[SerializeField]
	private Gradient gradient_EditMode;

	[SerializeField]
	private Gradient gradient_BattleMode;

	[SerializeField]
	private List<LineRenderer> lineRenderers;

	private int curLineIndex;

	private float updateInterval;

	private float updateTimer;

	private Vector3 lastRaycastPoint;

	private float distanceMoved;

	private bool isDrawing;

	private bool haveGround;

	[SerializeField]
	private float totalDistance;

	private bool isInBattle;

	private int maxLineRendererCount;

	private Vector3 lastValidRaycastPoint;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnBattleStart()
	{
	}

	private void OnBattleEnd()
	{
	}

	private void SwitchToNextLineRenderer()
	{
	}

	private void ResetAllLines()
	{
	}

	private void Update()
	{
	}

	private void AddPointToCurrentLine(Vector3 pos)
	{
	}
}
