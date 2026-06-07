using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[HelpURL("https://docs.gamecreator.io/gamecreator/characters/markers")]
	[AddComponentMenu("Game Creator/Characters/Marker", 200)]
	[DisallowMultipleComponent]
	public class Marker : MonoBehaviour, ISpatialHash
	{
		private static readonly Color COLOR_GIZMO_CAPSULE = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.25f);

		[SerializeField]
		private float m_StopDistance = 0.01f;

		[SerializeReference]
		private TMarkerType m_MarkerType = new MarkerTypeDirection();

		[SerializeField]
		private UniqueID m_UniqueID = new UniqueID();

		[field: NonSerialized]
		private static Dictionary<IdString, Marker> Markers { get; set; } = new Dictionary<IdString, Marker>();

		public float StopDistance => Mathf.Max(0f, m_StopDistance);

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnSubsystemsInit()
		{
			Markers = new Dictionary<IdString, Marker>();
		}

		private void Awake()
		{
			SpatialHashMarkers.Insert(this);
			Markers[m_UniqueID.Get] = this;
		}

		private void OnDestroy()
		{
			SpatialHashMarkers.Remove(this);
			Markers.Remove(m_UniqueID.Get);
		}

		public bool IsWithinRange(Vector3 target, float stopThreshold = 0f)
		{
			float num = Mathf.Max(m_StopDistance, stopThreshold);
			return Vector3.Distance(base.transform.position, target) <= num;
		}

		public Vector3 GetPosition(GameObject user)
		{
			return m_MarkerType.GetPosition(this, user);
		}

		public Vector3 GetDirection(GameObject user)
		{
			return m_MarkerType.GetDirection(this, user);
		}

		public Quaternion GetRotation(GameObject user)
		{
			return Quaternion.LookRotation(GetDirection(user));
		}

		public static Marker GetMarkerByID(string makerId)
		{
			return GetMarkerByID(new IdString(makerId));
		}

		public static Marker GetMarkerByID(IdString markerId)
		{
			if (!Markers.TryGetValue(markerId, out var value))
			{
				return null;
			}
			return value;
		}

		private void OnDrawGizmos()
		{
			Vector3 position = base.transform.position + Vector3.up * 0.01f;
			Gizmos.color = Color.yellow;
			m_MarkerType?.OnDrawGizmos(this);
			GizmosExtension.Cross(position, GizmosExtension.CrossDirection.Upwards, 0.05f);
			GizmosExtension.Circle(position, 0.05f);
			if (m_StopDistance >= 0.2f)
			{
				GizmosExtension.Circle(position, m_StopDistance);
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = COLOR_GIZMO_CAPSULE;
			float radius = 0.2f;
			float height = 2f;
			GizmosExtension.Cylinder(base.transform.position + Vector3.up * 0.01f, height, radius);
		}
	}
}
