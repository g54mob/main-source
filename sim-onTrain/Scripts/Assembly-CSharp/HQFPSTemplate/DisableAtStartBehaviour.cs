using UnityEngine;

namespace HQFPSTemplate
{
	public class DisableAtStartBehaviour : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] m_Objects;

		private void Start()
		{
			GameObject[] objects = m_Objects;
			for (int i = 0; i < objects.Length; i++)
			{
				objects[i].SetActive(value: false);
			}
		}
	}
}
