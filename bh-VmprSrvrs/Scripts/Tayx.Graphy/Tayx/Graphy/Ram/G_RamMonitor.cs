using UnityEngine;

namespace Tayx.Graphy.Ram
{
	public class G_RamMonitor : MonoBehaviour
	{
		public float AllocatedRam { get; private set; }

		public float ReservedRam { get; private set; }

		public float MonoRam { get; private set; }

		private void Update()
		{
		}
	}
}
