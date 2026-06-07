using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Collider))]
	public class FloorTypeAudioVolume : MonoBehaviour
	{
		public static List<FloorTypeAudioVolume> AllVolumes;

		[DropDownChoice(typeof(AudioSwitch.FootstepMaterial), "GetAllMaterials")]
		public string floorSoundOverride;

		[SerializeField]
		private Collider _collider;

		public GameObject positionDebugger;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		public bool IsInsideVolume(Collider otherCol)
		{
			return false;
		}
	}
}
