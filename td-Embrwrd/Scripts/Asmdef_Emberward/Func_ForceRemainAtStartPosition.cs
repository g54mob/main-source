using UnityEngine;

public class Func_ForceRemainAtStartPosition : MonoBehaviour
{
	[SerializeField]
	private bool doUpdateEveryFrame;

	[SerializeField]
	private float updateInterval;

	private Vector3 startPosition;

	private float updateTimer;

	private void OnEnable()
	{
	}

	private void LateUpdate()
	{
	}
}
