using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
	public delegate void OnInteract(ref Interaction interaction);

	public delegate void OnEndInteract(Interaction interaction);

	[SerializeField]
	[Range(0f, 360f)]
	private float interactionAngle = 360f;

	[SerializeField]
	private InteractionOption[] options;

	[SerializeField]
	private LayerMask blockingLayers = 0;

	private Interaction currentInteraction;

	private bool interactionDisabled;

	public InteractionOption[] Options => options;

	public float InteractionAngle => interactionAngle;

	public bool InteractionDisabled
	{
		get
		{
			return interactionDisabled;
		}
		set
		{
			interactionDisabled = value;
		}
	}

	public event OnInteract onInteract;

	public event OnEndInteract onEndInteract;

	public bool CanInteract(GameObject involvedObject)
	{
		InteractiveAgent component = involvedObject.GetComponent<InteractiveAgent>();
		if ((bool)component && component.CanInteract && !InteractionDisabled && !IsBusy())
		{
			return IsInInteractionArea(involvedObject);
		}
		return false;
	}

	public bool IsInInteractionArea(GameObject involvedObject)
	{
		InteractiveAgent component = involvedObject.GetComponent<InteractiveAgent>();
		if (!component)
		{
			return false;
		}
		if (Vector3.Angle(component.transform.position - base.transform.position, base.transform.forward) > interactionAngle * 0.5f)
		{
			return false;
		}
		float totalInteractionRadius = component.GetTotalInteractionRadius();
		float objectRadius = FunctionLibrary.GetObjectRadius(base.gameObject);
		bool flag = false;
		if (objectRadius > 0f)
		{
			totalInteractionRadius += objectRadius;
			flag = totalInteractionRadius * totalInteractionRadius >= (base.transform.position - component.transform.position).sqrMagnitude;
		}
		else
		{
			Ray ray = new Ray(component.transform.position, base.transform.position - component.transform.position);
			flag = GetComponent<Collider>().Raycast(ray, out var _, totalInteractionRadius);
		}
		if (flag)
		{
			return !Physics.Linecast(component.transform.position, base.transform.position, blockingLayers);
		}
		return false;
	}

	public bool IsBusy()
	{
		return currentInteraction.state != Interaction.EInteractionState.Undefined;
	}

	public bool GetPositionToInteract(GameObject involvedObject, out Vector3 outPosition)
	{
		outPosition = Vector3.zero;
		InteractiveAgent component = involvedObject.GetComponent<InteractiveAgent>();
		if (!component)
		{
			return false;
		}
		Ray ray = new Ray(base.transform.position + base.transform.forward * 10f, base.transform.forward * -1f);
		float totalInteractionRadius = component.GetTotalInteractionRadius();
		totalInteractionRadius -= Mathf.Max(component.interactionRadius - 0.2f, 0f);
		if (base.gameObject.GetComponent<Collider>().Raycast(ray, out var hitInfo, 10f))
		{
			outPosition = hitInfo.point + base.transform.forward * totalInteractionRadius;
			return true;
		}
		return false;
	}

	public bool HasInteractionAngle()
	{
		if (interactionAngle > 0f)
		{
			return interactionAngle < 360f;
		}
		return false;
	}

	public bool Interact(GameObject involvedObject, InteractionOption option, Dictionary<string, string> data = null)
	{
		if (CanInteract(involvedObject))
		{
			InteractiveAgent component = involvedObject.GetComponent<InteractiveAgent>();
			if (component.CanInteract)
			{
				Interaction interaction = new Interaction(component, this, option, data);
				return Interact(ref interaction, checkCanInteract: false);
			}
		}
		return false;
	}

	public bool Interact(ref Interaction interaction, bool checkCanInteract = true)
	{
		if ((!checkCanInteract || CanInteract(interaction.involvedAgent.gameObject)) && interaction.involvedAgent.CanInteract)
		{
			currentInteraction = interaction;
			currentInteraction.state = Interaction.EInteractionState.Processing;
			interaction.involvedAgent?.InteractionStarted(currentInteraction);
			if (this.onInteract != null)
			{
				this.onInteract(ref currentInteraction);
			}
			else
			{
				EndInteract(Interaction.EInteractionState.Failed);
			}
			return true;
		}
		interaction.state = Interaction.EInteractionState.Failed;
		return false;
	}

	public void EndInteract(Interaction.EInteractionState interactionResult)
	{
		if (IsBusy())
		{
			currentInteraction.state = interactionResult;
			currentInteraction.involvedAgent?.InteractionEnded(currentInteraction);
			this.onEndInteract?.Invoke(currentInteraction);
			currentInteraction.state = Interaction.EInteractionState.Undefined;
		}
	}
}
