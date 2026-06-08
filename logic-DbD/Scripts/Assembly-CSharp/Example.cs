using UnityEngine;

public class Example : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(Object.FindObjectOfType<SubtitleDisplayer>().Begin());
	}
}
