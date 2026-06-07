using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Direction")]
	[Category("Direction")]
	[Description("Aligns the target with the position and direction of the Marker")]
	[Image(typeof(IconArrowRight), ColorTheme.Type.Yellow)]
	public class MarkerTypeDirection : TMarkerType
	{
		public override Vector3 GetPosition(Marker marker, GameObject user)
		{
			return marker.transform.position;
		}

		public override Vector3 GetDirection(Marker marker, GameObject user)
		{
			return marker.transform.TransformDirection(Vector3.forward);
		}

		public override void OnDrawGizmos(Marker marker)
		{
			Vector3 position = marker.transform.position + Vector3.up * 0.01f;
			Quaternion rotation = marker.transform.rotation;
			GizmosExtension.Arrow(position, rotation, 0.2f);
		}
	}
}
