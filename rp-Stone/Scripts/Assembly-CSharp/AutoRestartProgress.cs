using UnityEngine;

[RequireComponent(typeof(GameStates))]
public class AutoRestartProgress : MonoBehaviour
{
	private GameStates gameStates;

	private float idleTime;

	private Vector3 lastMousePos;

	private void Update()
	{
		base.enabled = false;
	}

	private void UpdateIdleTime()
	{
		idleTime += Utils.deltaTime;
		if (lastMousePos != Input.mousePosition)
		{
			lastMousePos = Input.mousePosition;
			idleTime = 0f;
		}
		if (Input.touchCount > 0)
		{
			idleTime = 0f;
		}
	}

	private void Awake()
	{
		gameStates = GetComponent<GameStates>();
	}
}
