using MyBox;
using UnityEngine;

namespace Garage.Jack.InteractionZones
{
	[RequireComponent(typeof(Collider))]
	public class JackEngineRecoverZone : MonoBehaviour
	{
		[SerializeField]
		[ReadOnly(new string[] { })]
		private bool _engineInZone;

		[SerializeField]
		private EngineJackView _engineJackView;

		[SerializeField]
		private GameObject _chain;

		public bool EngineInZone { get; private set; }

		private void OnTriggerEnter(Collider other)
		{
			_engineInZone = true;
			EngineInZone = true;
		}

		private void OnTriggerExit(Collider other)
		{
			_engineInZone = false;
			EngineInZone = false;
		}
	}
}
