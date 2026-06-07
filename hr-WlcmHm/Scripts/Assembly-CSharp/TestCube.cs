using UnityEngine;

public class TestCube : MonoBehaviour, IInteractable
{
	public string objectName;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void PlayInteractSound()
	{
	}

	public void Interact()
	{
		MonoBehaviour.print("I HAVE BEEN INTERACTED WITH! My name: " + base.gameObject.name);
	}

	public void Activate()
	{
		GetComponent<MeshRenderer>().material.color = Color.green;
	}

	public void Deactivate()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}

	public string GetName()
	{
		return objectName;
	}

	public string GetActionName()
	{
		return "interact with";
	}

	public string GetActionType()
	{
		return "Press";
	}
}
