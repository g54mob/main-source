using UnityEngine;

namespace MateoRyhr
{
	public class MultipleObjectsActivator : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] _objects;

		public void SetActiveOfObjects(bool state)
		{
			GameObject[] objects = _objects;
			for (int i = 0; i < objects.Length; i++)
			{
				objects[i].SetActive(state);
			}
		}
	}
}
