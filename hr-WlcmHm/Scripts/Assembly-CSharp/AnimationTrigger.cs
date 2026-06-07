using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
	[SerializeField]
	private Animator anim;

	[SerializeField]
	private NPCBaseController npcBaseController;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			if (anim != null)
			{
				anim.SetTrigger("Open");
			}
			if (npcBaseController != null)
			{
				npcBaseController.Interact();
				Object.Destroy(base.gameObject);
			}
			base.transform.gameObject.SetActive(value: false);
		}
	}
}
