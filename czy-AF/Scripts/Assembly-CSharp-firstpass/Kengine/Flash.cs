using UnityEngine;
using UnityEngine.UI;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Flash")]
	public class Flash : MonoBehaviour
	{
		public float interval = 0.5f;

		public float flashes;

		public GameObject child;

		private void Start()
		{
			InvokeRepeating("PerformFlash", 0f, interval);
		}

		private void PerformFlash()
		{
			if ((bool)child)
			{
				child.SetActive(!child.activeInHierarchy);
			}
			else
			{
				if ((bool)GetComponent<Renderer>())
				{
					GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
				}
				if ((bool)GetComponent<Light>())
				{
					GetComponent<Light>().enabled = !GetComponent<Light>().enabled;
				}
				if ((bool)GetComponent<RawImage>())
				{
					GetComponent<RawImage>().enabled = !GetComponent<RawImage>().enabled;
				}
				if ((bool)GetComponent<Image>())
				{
					GetComponent<Image>().enabled = !GetComponent<Image>().enabled;
				}
			}
			if (flashes != 0f)
			{
				flashes -= 0.5f;
				if (flashes <= 0f)
				{
					Object.Destroy(this);
				}
			}
		}
	}
}
