using UnityEngine;

namespace GRP
{
	public class VolumePartSim : PartSim<VolumePart>
	{
		public VolumeVisual visual;

		private Mission mission;

		protected override void Setup()
		{
		}

		protected override void Begin()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}
	}
}
