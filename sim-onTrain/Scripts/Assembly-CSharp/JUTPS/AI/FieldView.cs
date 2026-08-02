using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JUTPS.AI
{
	[Serializable]
	public class FieldView
	{
		[Range(0f, 500f)]
		public float Radious;

		[Range(0f, 360f)]
		public float Angle;

		public FieldView(float radious, float angle)
		{
			Radious = radious;
			Angle = angle;
		}

		public Collider[] CheckViewCollider(Vector3 position, Vector3 forward, LayerMask targetMask, GameObject viewerToIgnore = null)
		{
			List<Collider> list = Physics.OverlapSphere(position, Radious, targetMask).ToList();
			Collider[] array = list.ToArray();
			foreach (Collider collider in array)
			{
				Vector3 position2 = collider.transform.position;
				position2.y = position.y;
				Vector3 normalized = (position2 - position).normalized;
				if (Vector3.Angle(forward, normalized) > Angle / 2f || collider.gameObject == viewerToIgnore)
				{
					list.Remove(collider);
				}
			}
			return list.ToArray();
		}

		public bool IsVisibleToThisFieldOfView(Transform LookedTarget, Vector3 ViewPosition, Vector3 ViewForward, LayerMask LayerMask, float threshold = 0.6f, string[] TagsToConsiderVisible = null)
		{
			if (LookedTarget == null)
			{
				return false;
			}
			bool result = true;
			Vector3 normalized = (LookedTarget.position - ViewPosition).normalized;
			if (Vector3.Angle(ViewForward, normalized) > Angle / 2f)
			{
				result = false;
			}
			else
			{
				float num = Vector3.Distance(ViewPosition, LookedTarget.position);
				Vector3 end = ViewPosition + normalized * num;
				Physics.Linecast(ViewPosition, end, out var hitInfo, LayerMask);
				if (hitInfo.collider != null)
				{
					if (!JUCharacterArtificialInteligenceBrain.TagMatches(hitInfo.collider.tag, TagsToConsiderVisible))
					{
						Debug.DrawLine(hitInfo.point, ViewPosition, Color.cyan);
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			return result;
		}

		public static void DrawFieldOfView(Vector3 position, Vector3 forward, FieldView view)
		{
		}
	}
}
