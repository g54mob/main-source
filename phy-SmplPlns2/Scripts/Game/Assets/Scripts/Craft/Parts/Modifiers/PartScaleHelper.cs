using Assets.Scripts.Design;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public static class PartScaleHelper
	{
		public static void ApplyScaleWithAnchor(PartData part, float size, float radius)
		{
			size = Mathf.Max(size, 0.01f);
			radius = Mathf.Max(radius, 0.01f);
			AttachPointData attachPointData = null;
			if (part.AttachPoints != null)
			{
				int num = 0;
				foreach (AttachPointData attachPoint in part.AttachPoints)
				{
					if (!attachPoint.IsAvailable)
					{
						num++;
						attachPointData = attachPoint;
					}
				}
				if (num == 0)
				{
					attachPointData = null;
				}
				else if (num > 1)
				{
					attachPointData = part.AttachPoints[part.AttachPoints.Count - 1];
				}
			}
			PartScript partScript = part.PartScript;
			Vector3? vector = null;
			if (partScript != null && attachPointData != null)
			{
				vector = partScript.transform.TransformPoint(attachPointData.Position);
			}
			float num2 = size * radius;
			part.PartScale = new Vector3(num2, size, num2);
			part.MassScale = Mathf.Pow(size, 2.2f) * radius * radius;
			if (part.PartScale.HasValue && partScript != null)
			{
				partScript.transform.localScale = part.PartScale.Value;
			}
			if (vector.HasValue && partScript != null && attachPointData != null)
			{
				Vector3 vector2 = partScript.transform.TransformPoint(attachPointData.Position);
				partScript.transform.position += vector.Value - vector2;
			}
			if (partScript != null && part.AttachPoints != null)
			{
				Vector3 localScale = new Vector3(1f / num2, 1f / size, 1f / num2);
				foreach (AttachPointData attachPoint2 in part.AttachPoints)
				{
					if (attachPoint2.AttachPointScript != null)
					{
						attachPoint2.AttachPointScript.transform.localScale = localScale;
					}
				}
			}
			Designer.Instance.SetAircraftStructureChanged();
		}
	}
}
