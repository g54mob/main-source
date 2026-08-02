using System.Collections;
using UnityEngine;

namespace BloodEffectsPack
{
	public class ToggleRepeat : MonoBehaviour
	{
		public float toggleDuration = 2f;

		public GameObject[] targetGameObjects;

		private Coroutine toggleCoroutine;

		private void Start()
		{
			toggleCoroutine = StartCoroutine(Toggle());
		}

		private void Update()
		{
		}

		private IEnumerator Toggle()
		{
			while (true)
			{
				for (int i = 0; i < targetGameObjects.Length; i++)
				{
					targetGameObjects[i].SetActive(!targetGameObjects[i].activeSelf);
				}
				yield return new WaitForSeconds(toggleDuration);
			}
		}

		private void OnDestroy()
		{
			if (toggleCoroutine != null)
			{
				StopCoroutine(toggleCoroutine);
			}
		}
	}
}
