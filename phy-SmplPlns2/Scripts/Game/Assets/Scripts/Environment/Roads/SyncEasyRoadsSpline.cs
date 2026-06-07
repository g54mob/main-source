using System;
using System.Collections.Generic;
using EasyRoads3Dv3;
using JBooth.MicroVerseCore;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads
{
	[ExecuteInEditMode]
	public class SyncEasyRoadsSpline : MonoBehaviour
	{
		private static MicroVerse _cachedMicroVerse;

		private static ERRoadNetwork _cachedERNetwork;

		[SerializeField]
		private Vector3 _offset;

		[SerializeField]
		private GameObject _splinePrefab;

		[ContextMenu("Sync Splines")]
		public void SyncSplines()
		{
			if (_cachedERNetwork == null)
			{
				_cachedERNetwork = new ERRoadNetwork();
			}
			ERRoad[] roadObjects = _cachedERNetwork.GetRoadObjects();
			List<ERRoad> list = new List<ERRoad>();
			ERRoad[] array = roadObjects;
			foreach (ERRoad eRRoad in array)
			{
				if (eRRoad.roadScript.terrainDeformation)
				{
					list.Add(eRRoad);
				}
			}
			SyncedSplineScript[] componentsInChildren = GetComponentsInChildren<SyncedSplineScript>();
			Dictionary<Transform, SyncedSplineScript> dictionary = new Dictionary<Transform, SyncedSplineScript>(componentsInChildren.Length);
			SyncedSplineScript[] array2 = componentsInChildren;
			foreach (SyncedSplineScript syncedSplineScript in array2)
			{
				if (syncedSplineScript.Road != null)
				{
					dictionary[syncedSplineScript.Road] = syncedSplineScript;
				}
			}
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>(list.Count);
			foreach (ERRoad item in list)
			{
				Transform transform = item.gameObject.transform;
				string roadTypeName = item.GetRoadType().roadTypeName;
				bool isTrack = roadTypeName.Contains("racetrack", StringComparison.OrdinalIgnoreCase);
				if (!dictionary2.TryGetValue(roadTypeName, out var value))
				{
					value = (dictionary2[roadTypeName] = 0);
				}
				item.SetName($"{roadTypeName} - {value}");
				dictionary2[roadTypeName] = value + 1;
				if (dictionary.TryGetValue(transform, out var value2))
				{
					value2.Sync(_offset);
					dictionary.Remove(transform);
				}
				else
				{
					CreateNewSpline(transform, isTrack).Sync(_offset);
				}
			}
			if (_cachedMicroVerse == null)
			{
				_cachedMicroVerse = MicroVerse.instance;
			}
			_cachedMicroVerse.Invalidate();
			foreach (SyncedSplineScript value3 in dictionary.Values)
			{
				value3.DestroySpline();
			}
		}

		private SyncedSplineScript CreateNewSpline(Transform roadTransform, bool isTrack)
		{
			GameObject obj = UnityEngine.Object.Instantiate(_splinePrefab);
			obj.transform.SetParent(base.transform, worldPositionStays: false);
			SyncedSplineScript syncedSplineScript = obj.AddComponent<SyncedSplineScript>();
			syncedSplineScript.Road = roadTransform;
			syncedSplineScript.Track = isTrack;
			return syncedSplineScript;
		}
	}
}
