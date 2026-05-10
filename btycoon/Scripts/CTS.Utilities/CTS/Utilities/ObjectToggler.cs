using UnityEngine;

namespace CTS.Utilities
{
	public class ObjectToggler : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _objects;

		public void SetActive(bool value)
		{
			GameObject[] objects = _objects;
			for (int i = 0; i < objects.Length; i++)
			{
				objects[i].SetActive(value);
			}
		}
	}
}
