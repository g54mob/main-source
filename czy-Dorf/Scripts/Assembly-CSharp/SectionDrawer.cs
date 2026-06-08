using System.Collections.Generic;
using UnityEngine;

public class SectionDrawer : MonoBehaviour
{
	[SerializeField]
	private SectionManager sectionManager;

	private void OnDrawGizmos()
	{
		if (sectionManager.sectionsByGridPos == null)
		{
			return;
		}
		foreach (KeyValuePair<Section, float> item in sectionManager.sectionInfluence)
		{
			Vector3 position = item.Key.transform.position;
			Gizmos.color = Color.Lerp(Color.clear, Color.white, item.Value);
			Gizmos.DrawLine(position + new Vector3(-1f, 0f, -1f) * sectionManager.SectionSize / 2f, position + new Vector3(-1f, 0f, 1f) * sectionManager.SectionSize / 2f);
			Gizmos.DrawLine(position + new Vector3(-1f, 0f, 1f) * sectionManager.SectionSize / 2f, position + new Vector3(1f, 0f, 1f) * sectionManager.SectionSize / 2f);
			Gizmos.DrawLine(position + new Vector3(1f, 0f, 1f) * sectionManager.SectionSize / 2f, position + new Vector3(1f, 0f, -1f) * sectionManager.SectionSize / 2f);
			Gizmos.DrawLine(position + new Vector3(1f, 0f, -1f) * sectionManager.SectionSize / 2f, position + new Vector3(-1f, 0f, -1f) * sectionManager.SectionSize / 2f);
		}
		Gizmos.color = Color.white;
	}
}
