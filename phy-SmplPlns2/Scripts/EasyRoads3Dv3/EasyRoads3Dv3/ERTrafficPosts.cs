using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public struct ERTrafficPosts
	{
		public bool active;

		public GameObject prefab;

		[HideInInspector]
		public GameObject instance;

		public float scale;

		public bool includeSidewalks;

		public float sidewaysOffset;

		public float forwardOffset;

		public ERTrafficPostType postType;

		public ERRoadSide roadSide;

		[HideInInspector]
		public bool isset;

		public ERTrafficPosts(GameObject _prefab, int _sidewaysOffset, int _forwardOffset, ERTrafficPostType _postType)
		{
			active = true;
			prefab = _prefab;
			scale = 1f;
			sidewaysOffset = _sidewaysOffset;
			includeSidewalks = false;
			forwardOffset = _forwardOffset;
			postType = _postType;
			instance = null;
			roadSide = ERRoadSide.Right;
			isset = false;
		}

		public void SetERPostInstance(GameObject _instance)
		{
			instance = _instance;
		}

		public static void SetERPostInstances(List<ERTrafficPosts> instances)
		{
			for (int i = 0; i < instances.Count; i++)
			{
				if (!instances[i].isset && instances[i].prefab != null)
				{
					ERTrafficPosts value = instances[i];
					ERTrafficPost component = instances[i].prefab.GetComponent<ERTrafficPost>();
					if (component != null)
					{
						value.scale = component.scale;
						value.roadSide = component.roadSide;
						value.includeSidewalks = component.includeSidewalks;
						value.postType = component.postType;
						value.sidewaysOffset = component.sidewaysOffset;
						value.forwardOffset = component.forwardOffset;
					}
					value.isset = true;
					instances[i] = value;
				}
				else if (instances[i].prefab == null && instances[i].isset)
				{
					ERTrafficPosts value2 = instances[i];
					value2.isset = false;
					instances[i] = value2;
				}
			}
		}

		public static void OCODOQDDDO(List<QDQDOOQQDQODD> roadTypes, int targetIndex, int sourceIndex)
		{
			for (int i = 0; i < roadTypes[sourceIndex].trafficPosts.Count; i++)
			{
				ERTrafficPosts item = new ERTrafficPosts
				{
					prefab = roadTypes[sourceIndex].trafficPosts[i].prefab,
					scale = roadTypes[sourceIndex].trafficPosts[i].scale,
					roadSide = roadTypes[sourceIndex].trafficPosts[i].roadSide,
					includeSidewalks = roadTypes[sourceIndex].trafficPosts[i].includeSidewalks,
					postType = roadTypes[sourceIndex].trafficPosts[i].postType,
					sidewaysOffset = roadTypes[sourceIndex].trafficPosts[i].sidewaysOffset,
					forwardOffset = roadTypes[sourceIndex].trafficPosts[i].forwardOffset,
					isset = roadTypes[sourceIndex].trafficPosts[i].isset
				};
				roadTypes[targetIndex].trafficPosts.Add(item);
			}
		}
	}
}
