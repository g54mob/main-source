using UnityEngine;

namespace SoulGames.EasyGridBuilderPro
{
	public class UITriggerAnimation : MonoBehaviour
	{
		[Space]
		[SerializeField]
		private Animator animator;

		[SerializeField]
		private string firstTriggerParameter;

		[SerializeField]
		private string secondTriggerParameter;

		[Space]
		[SerializeField]
		private GameObject[] firstObject;

		[SerializeField]
		private GameObject[] secondObject;

		[Space]
		[SerializeField]
		private GameObject[] toggleObject;

		private bool triggered;

		public void TriggerAnimation()
		{
			GameObject[] array;
			if (!triggered)
			{
				triggered = true;
				animator.SetTrigger(firstTriggerParameter);
				array = firstObject;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
				array = secondObject;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: true);
				}
			}
			else
			{
				triggered = false;
				animator.SetTrigger(secondTriggerParameter);
				array = firstObject;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: true);
				}
				array = secondObject;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
			}
			array = toggleObject;
			foreach (GameObject gameObject in array)
			{
				if (gameObject.activeSelf)
				{
					gameObject.SetActive(value: false);
				}
				else
				{
					gameObject.SetActive(value: true);
				}
			}
		}
	}
}
