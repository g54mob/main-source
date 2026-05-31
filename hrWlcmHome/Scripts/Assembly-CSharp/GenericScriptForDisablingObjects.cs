using UnityEngine;

public class GenericScriptForDisablingObjects : MonoBehaviour
{
	public GameObject objectToDisable;

	public GameObject objectToEnable;

	public void OnTriggerEnter(Collider c)
	{
		objectToDisable.SetActive(value: false);
		objectToEnable.SetActive(value: true);
	}
}
