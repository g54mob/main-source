using UnityEngine;

namespace Tayx.Graphy.Ram
{
	public class RamMonitor : MonoBehaviour
	{
		private float m_allocatedRam;

		private float m_reservedRam;

		private float m_monoRam;

		public float AllocatedRam => 0f;

		public float ReservedRam => 0f;

		public float MonoRam => 0f;

		private void Update()
		{
		}
	}
}
