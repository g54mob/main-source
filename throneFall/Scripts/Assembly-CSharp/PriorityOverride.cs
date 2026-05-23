using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PriorityOverride : MonoBehaviour
{
	public int prio = 1;

	private AudioSource target;

	private void Start()
	{
		target = GetComponent<AudioSource>();
		target.priority = prio;
	}

	private void Update()
	{
		target.priority = prio;
	}
}
