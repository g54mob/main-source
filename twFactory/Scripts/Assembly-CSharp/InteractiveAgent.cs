using UnityEngine;

public class InteractiveAgent : MonoBehaviour
{
	public delegate void OnInteract(Interaction interaction);

	public delegate void OnEndInteract(Interaction interaction);

	public float interactionRadius = 1.5f;

	private bool canInteract = true;

	public bool CanInteract => canInteract;

	public event OnInteract onInteract;

	public event OnEndInteract onEndInteract;

	public float GetTotalInteractionRadius()
	{
		return interactionRadius + FunctionLibrary.GetObjectRadius(base.gameObject);
	}

	public void InteractionStarted(Interaction interaction)
	{
		canInteract = false;
		if ((bool)GetComponent<MovementComponent>())
		{
			GetComponent<MovementComponent>().MovementEnabled = false;
		}
		Vector3 vector = interaction.interactive.transform.position - base.transform.position;
		vector.y = 0f;
		base.transform.rotation = Quaternion.LookRotation(vector.normalized);
		this.onInteract?.Invoke(interaction);
	}

	public void InteractionEnded(Interaction interaction)
	{
		canInteract = true;
		if ((bool)GetComponent<MovementComponent>())
		{
			GetComponent<MovementComponent>().MovementEnabled = true;
		}
		this.onEndInteract?.Invoke(interaction);
	}

	public void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(base.transform.position, GetTotalInteractionRadius());
	}
}
