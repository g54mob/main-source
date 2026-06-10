using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.Construction
{
	public class FoundationSetup : MonoBehaviour
	{
		private List<Vec3Int> positions;

		[SerializeField]
		private Transform parent;

		[SerializeField]
		private List<GameObject> foundationsPrefabs;

		[SerializeField]
		private List<GameObject> cornerFoundation;

		private int xmin;

		private int xmax;

		private int zmin;

		private int zmax;

		private Vector3 cornera;

		private Vector3 cornerb;

		private Vector3 cornerc;

		private Vector3 cornerd;

		public void SetDynamicSize(List<Vec3Int> positions)
		{
			this.positions = positions;
			SetBounds();
			MakeDynamicFoundation();
		}

		private void SetBounds()
		{
			xmin = positions[0].x;
			xmax = positions[0].x;
			zmin = positions[0].z;
			zmax = positions[0].z;
			for (int i = 0; i < positions.Count; i++)
			{
				if (xmin > positions[i].x)
				{
					xmin = positions[i].x;
				}
				if (xmax < positions[i].x)
				{
					xmax = positions[i].x;
				}
				if (zmin > positions[i].z)
				{
					zmin = positions[i].z;
				}
				if (zmax < positions[i].z)
				{
					zmax = positions[i].z;
				}
				Vector3 position = parent.transform.position;
				cornera = new Vector3(xmin, position.y, zmin);
				cornerb = new Vector3(xmin, position.y, zmax);
				cornerc = new Vector3(xmax, position.y, zmin);
				cornerd = new Vector3(xmax, position.y, zmax);
			}
		}

		private void MakeDynamicFoundation()
		{
			for (int i = 0; i < positions.Count; i++)
			{
				PlaceFoundation(i);
			}
		}

		private void PlaceFoundation(int i)
		{
			if ((float)positions[i].x == cornera.x && (float)positions[i].z == cornera.z)
			{
				InstantiateCorner(i, 90f);
			}
			else if ((float)positions[i].x == cornerb.x && (float)positions[i].z == cornerb.z)
			{
				InstantiateCorner(i, 180f);
			}
			else if ((float)positions[i].x == cornerc.x && (float)positions[i].z == cornerc.z)
			{
				InstantiateCorner(i, 0f);
			}
			else if ((float)positions[i].x == cornerd.x && (float)positions[i].z == cornerd.z)
			{
				InstantiateCorner(i, 270f);
			}
			else
			{
				InstantiateRandom(i);
			}
		}

		private void InstantiateCorner(int i, float angle)
		{
			if (cornerFoundation.Capacity > 0)
			{
				Vector3 position = new Vector3(positions[i].x, parent.transform.position.y, positions[i].z);
				Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
				int index = Random.Range(0, cornerFoundation.Capacity);
				Object.Instantiate(cornerFoundation[index], position, rotation, parent);
			}
			else
			{
				InstantiateRandom(i);
			}
		}

		private void InstantiateRandom(int i)
		{
			int index = Random.Range(0, foundationsPrefabs.Capacity);
			Object.Instantiate(position: new Vector3(positions[i].x, parent.transform.position.y, positions[i].z), original: foundationsPrefabs[index], rotation: Quaternion.identity, parent: parent);
		}
	}
}
