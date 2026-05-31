using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerControllerDepthOfField : MonoBehaviour
{
	private Ray raycast;

	private RaycastHit hit;

	private bool isHit;

	public float hitDistance;

	public PostProcessProfile processProfile;

	public Collider playerCollider;

	public float previousFocusDistance;

	public float focusTransitionSpeed;

	public float maxFocusDistance;

	public bool focus;

	public static bool inTablet;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetFocus()
	{
	}
}
