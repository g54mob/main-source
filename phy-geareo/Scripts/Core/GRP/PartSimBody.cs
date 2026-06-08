using UnityEngine;

namespace GRP
{
	public class PartSimBody : MonoBehaviour
	{
		public Rigidbody rb;

		public ProjectSim project;

		public PartSimBodyListener listener;

		public Settings settings;

		private int counter;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void HandleCollision(Collision collision)
		{
		}
	}
}
