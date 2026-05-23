using UnityEngine;

public class OnDamageFeedbackHandler : MonoBehaviour
{
	public Hp target;

	public MaterialFlasherFX flasher;

	public GameObject onDmgByPlayerFX;

	[SerializeField]
	private float flashDuration = 0.25f;

	private void Start()
	{
		target.OnReceiveDamage.AddListener(TakeDamage);
	}

	private void TakeDamage(bool causedByPlayer)
	{
		if (causedByPlayer)
		{
			Object.Instantiate(onDmgByPlayerFX, target.transform.position + Vector3.up * target.hitFeedbackHeight, onDmgByPlayerFX.transform.rotation);
			flasher.TriggerFlash(special: true, flashDuration);
		}
		else
		{
			flasher.TriggerFlash(special: false, flashDuration);
		}
	}
}
