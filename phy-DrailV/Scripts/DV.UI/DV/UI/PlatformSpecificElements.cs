using UnityEngine;

namespace DV.UI
{
	public class PlatformSpecificElements : MonoBehaviour
	{
		public GameObject[] vrElements;

		public GameObject[] nonVRElements;

		public void SetPlatform(bool isVR)
		{
			if (!isVR)
			{
				GameObject[] array = vrElements;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
			}
			else
			{
				GameObject[] array = nonVRElements;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
			}
		}
	}
}
