using UnityEngine;

public class FixTutorialCamera : MonoBehaviour
{
	private Camera _fixCamera;

	private bool _isFreeTime;

	private Vector3 _tutorialPosition;

	private Quaternion _tutorialRotation;

	private float _tutorialFieldOfView;

	public bool IsFreeTime
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void FixCamera(Vector3 initPosision, Quaternion initRotation, float initFieldOfView)
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}
}
