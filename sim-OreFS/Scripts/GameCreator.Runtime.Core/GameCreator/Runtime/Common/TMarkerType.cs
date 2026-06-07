using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Marker Type")]
	public abstract class TMarkerType
	{
		public abstract Vector3 GetPosition(Marker marker, GameObject user);

		public abstract Vector3 GetDirection(Marker marker, GameObject user);

		public abstract void OnDrawGizmos(Marker marker);
	}
}
