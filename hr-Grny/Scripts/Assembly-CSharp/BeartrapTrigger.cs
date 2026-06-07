using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BeartrapTrigger : MonoBehaviour
{
	[Header("Beartrap Activation")]
	[Tooltip("The Animation component to play the 'Beartrap' clip on.")]
	[SerializeField]
	private Animation beartrapAnimation;

	[Tooltip("The AudioSource component attached to this object or a child.")]
	[SerializeField]
	private AudioSource audioSource;

	[Tooltip("The sound played when the beartrap is triggered.")]
	[SerializeField]
	private AudioClip triggerSound;

	private bool beartrapActivated;

	private void OnMouseDown()
	{
	}

	public void DoAction()
	{
	}
}
