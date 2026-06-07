using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace EasyRoads3Dv3
{
	[Serializable]
	[AddComponentMenu("")]
	public class ERSideWalkInstance
	{
		public ERSideWalk sidewalk;

		public GameObject swObject;

		public double id;

		[HideInInspector]
		public float start = 0f;

		[HideInInspector]
		public float end = 1f;

		[HideInInspector]
		public Vector3 startPos = Vector3.zero;

		[HideInInspector]
		public Vector3 endPos = Vector3.zero;

		[HideInInspector]
		public Material mat = null;

		public ERSideWalkInstance(ERSideWalk msidewalk, float mStart, float mEnd, Vector3 mStartPos, Vector3 mEndPos, ERModularRoad road, string side)
		{
			sidewalk = msidewalk;
			id = sidewalk.id;
			start = mStart;
			end = mEnd;
			startPos = mStartPos;
			endPos = mEndPos;
			CreateObject(road, side);
		}

		public void CreateObject(ERModularRoad road, string side)
		{
			swObject = new GameObject(sidewalk.name + " " + side);
			swObject.transform.parent = road.transform;
			swObject.AddComponent<MeshRenderer>().sharedMaterial = sidewalk.material;
			swObject.AddComponent<MeshFilter>().sharedMesh = new Mesh();
			swObject.AddComponent<MeshCollider>().sharedMesh = swObject.GetComponent<MeshFilter>().sharedMesh;
			swObject.AddComponent<ERSideWalkInstanceScript>().instance = this;
			if (sidewalk.castShadow)
			{
				swObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				swObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
		}

		public static GameObject CreateObject(Transform parent, ERSideWalk sidewalk, string side)
		{
			GameObject gameObject = new GameObject(sidewalk.name + " " + side);
			gameObject.transform.parent = parent.transform;
			gameObject.transform.position = parent.transform.position;
			gameObject.transform.eulerAngles = parent.transform.eulerAngles;
			gameObject.AddComponent<MeshRenderer>().sharedMaterial = sidewalk.material;
			gameObject.AddComponent<MeshFilter>().sharedMesh = new Mesh();
			gameObject.AddComponent<MeshCollider>().sharedMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
			if (sidewalk.castShadow)
			{
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.On;
			}
			else
			{
				gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			}
			return gameObject;
		}

		public void GetObject(ERModularRoad road, string side)
		{
			if (road.gameObject.GetComponentsInChildren(typeof(ERSideWalkInstanceScript)) is ERSideWalkInstanceScript[] array)
			{
				ERSideWalkInstanceScript[] array2 = array;
				foreach (ERSideWalkInstanceScript eRSideWalkInstanceScript in array2)
				{
					if (eRSideWalkInstanceScript.instance != this)
					{
						continue;
					}
					swObject = eRSideWalkInstanceScript.gameObject;
					if (mat != sidewalk.material)
					{
						mat = sidewalk.material;
						if (swObject.GetComponent<MeshRenderer>() == null)
						{
							swObject.AddComponent<MeshRenderer>();
						}
						swObject.GetComponent<MeshRenderer>().sharedMaterial = mat;
					}
					return;
				}
			}
			if (swObject == null)
			{
				CreateObject(road, side);
			}
		}
	}
}
