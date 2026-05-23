using UnityEngine;

public class OcclusionDoor : MonoBehaviour
{
	public string openInTag;

	private Animator modelAnimator;

	private OcclusionPortal portal;

	public bool IsOpen
	{
		get
		{
			if (modelAnimator == null)
			{
				return true;
			}
			return modelAnimator.GetCurrentAnimatorStateInfo(0).IsTag(openInTag);
		}
	}

	private void Start()
	{
		modelAnimator = GetComponentInChildren<Animator>();
		portal = GetComponent<OcclusionPortal>();
	}

	private void Update()
	{
		portal.open = IsOpen;
	}
}
