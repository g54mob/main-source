using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField]
	private InteractObject interactObject;

	[SerializeField]
	private Animator anim;

	public void Open()
	{
		StartCoroutine(IOpen());
	}

	private IEnumerator IOpen()
	{
		anim.Play("Open");
		interactObject.interactable = false;
		yield return new WaitForSeconds(3.5f);
		interactObject.interactable = true;
	}
}
