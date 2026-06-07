using UnityEngine;

public class ExtinguisherManagerScript : ImportantObjectClass
{
	public GameObject Extinguisher;

	public bool ExtinguisherState;

	public FireManagerScript Manager;

	public AudioSource GrabSound;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		Extinguisher.SetActive(ExtinguisherState);
	}

	public override void DoInteraction()
	{
		ExtinguisherState = !ExtinguisherState;
		GameObject.Find("PlayerCamera").GetComponent<InteractScript>().HasExtinguisher = !ExtinguisherState;
		GrabSound.Play();
	}
}
