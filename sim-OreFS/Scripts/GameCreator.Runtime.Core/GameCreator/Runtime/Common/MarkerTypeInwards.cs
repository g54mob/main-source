using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Inwards")]
	[Category("Inwards")]
	[Description("Moves the target on the outer ring and rotates it towards the center")]
	[Image(typeof(IconCircleOutline), ColorTheme.Type.Yellow)]
	public class MarkerTypeInwards : TMarkerType
	{
		[SerializeField]
		private PropertyGetDecimal m_Radius = GetDecimalConstantPointFive.Create;

		[NonSerialized]
		private Args m_Args;

		public override Vector3 GetPosition(Marker marker, GameObject user)
		{
			if (user == null)
			{
				return marker.transform.position;
			}
			Character character = user.Get<Character>();
			Vector3 position = ((character != null) ? character.Feet : user.transform.position);
			if (m_Args == null)
			{
				m_Args = new Args(marker);
			}
			m_Args.ChangeTarget(user);
			Vector3 normalized = marker.transform.InverseTransformPoint(position).normalized;
			float num = (float)m_Radius.Get(m_Args);
			return marker.transform.TransformPoint(normalized * num);
		}

		public override Vector3 GetDirection(Marker marker, GameObject user)
		{
			if (user == null)
			{
				return marker.transform.TransformDirection(Vector3.forward);
			}
			Vector3 position = GetPosition(marker, user);
			if (position != marker.transform.position)
			{
				Vector3 vector = marker.transform.position - position;
				vector.y = 0f;
				return vector.normalized;
			}
			return user.transform.TransformDirection(Vector3.forward);
		}

		public override void OnDrawGizmos(Marker marker)
		{
			float num = MathUtils.Max(marker.transform.lossyScale.x, marker.transform.lossyScale.y, marker.transform.lossyScale.z);
			GizmosExtension.Circle(marker.transform.position + Vector3.up * 0.01f, num * (float)m_Radius.EditorValue);
		}
	}
}
