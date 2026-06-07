using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts
{
	public class ZeroNormalHunterScript : MonoBehaviour
	{
		public static void Hunt(Transform t)
		{
			MeshRenderer component = t.GetComponent<MeshRenderer>();
			if (component != null)
			{
				MeshFilter component2 = component.GetComponent<MeshFilter>();
				if (component2 != null)
				{
					Vector3[] normals = component2.sharedMesh.normals;
					for (int i = 0; i < normals.Length; i++)
					{
						if (normals[i].magnitude < 0.01f)
						{
							PartScript componentInParent = t.GetComponentInParent<PartScript>();
							Debug.LogFormat(t.gameObject, "Found zero normal on mesh on {0}.", componentInParent?.name);
							break;
						}
					}
				}
			}
			for (int j = 0; j < t.childCount; j++)
			{
				Hunt(t.GetChild(j));
			}
		}

		private void Start()
		{
			Hunt(base.transform);
		}
	}
}
