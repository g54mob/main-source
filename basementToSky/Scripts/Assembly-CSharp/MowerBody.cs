using UnityEngine;

public class MowerBody : MonoBehaviour
{
	private Rigidbody rb;

	[SerializeField]
	private Animator animator;

	public float animSpeedMultiplier = 2f;

	public bool isUsing;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
	}

	private void OnDestroy()
	{
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
	}

	private void PauseUI_OnSaveAndQuit()
	{
		isUsing = false;
		Object.Destroy(base.gameObject);
	}

	private void FixedUpdate()
	{
		if (isUsing)
		{
			Vector3 velocity = FirstPersonController.S.playerController.velocity;
			velocity.y = 0f;
			float value = Vector3.Dot(velocity.normalized, base.transform.forward) * animSpeedMultiplier;
			animator.SetFloat("Speed", value);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Grass"))
		{
			other.gameObject.SetActive(value: false);
			QuestManager.S.GrassCutted();
			AudioManager.S.PlayMowingSound();
		}
	}
}
