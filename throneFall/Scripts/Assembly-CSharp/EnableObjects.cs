using UnityEngine;

public class EnableObjects : MonoBehaviour
{
	[SerializeField]
	private GameObject[] gameObjectsToEnable;

	[SerializeField]
	private MonoBehaviour[] componentsToEnable;

	[SerializeField]
	private Animator[] animationsToEnable;

	private void OnEnable()
	{
		GameObject[] array = gameObjectsToEnable;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(value: true);
		}
		MonoBehaviour[] array2 = componentsToEnable;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].enabled = true;
		}
		Animator[] array3 = animationsToEnable;
		for (int i = 0; i < array3.Length; i++)
		{
			array3[i].enabled = true;
		}
	}
}
