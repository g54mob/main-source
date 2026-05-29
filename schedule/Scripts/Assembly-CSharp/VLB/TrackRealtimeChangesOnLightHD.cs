using UnityEngine;

namespace VLB
{
	[RequireComponent(typeof(Light), typeof(VolumetricLightBeamHD))]
	[HelpURL("http://saladgamer.com/vlb-doc/comp-trackrealtimechanges-hd/")]
	[DisallowMultipleComponent]
	public class TrackRealtimeChangesOnLightHD : MonoBehaviour
	{
		public const string ClassName = "TrackRealtimeChangesOnLightHD";

		private VolumetricLightBeamHD m_Master;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
