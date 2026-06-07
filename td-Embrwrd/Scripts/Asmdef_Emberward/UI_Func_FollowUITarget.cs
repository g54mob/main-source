using UnityEngine;

public class UI_Func_FollowUITarget : MonoBehaviour
{
	[SerializeField]
	private RectTransform target;

	[SerializeField]
	private float lerpSpeed;

	private Vector3 lastPosition;

	private float rotationMomentum;

	private bool doFollow;

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	public void PreservePosition()
	{
	}

	public void ToggleFollowing(bool isOn)
	{
	}

	public void ForceCompleteFollowing()
	{
	}
}
