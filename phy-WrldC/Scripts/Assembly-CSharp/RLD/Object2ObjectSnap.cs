using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class Object2ObjectSnap
	{
		[Flags]
		public enum Prefs
		{
			None = 0,
			TryMatchArea = 1,
			All = 1
		}

		public enum SnapFailReson
		{
			None = 0,
			MaxObjectsExceeded = 1,
			InvalidSourceObjects = 2,
			NoDestinationFound = 3
		}

		public struct SnapResult
		{
			private bool _success;

			private Vector3 _snapPivot;

			private Vector3 _snapDestination;

			private float _snapDistance;

			private SnapFailReson _failReason;

			public bool Success => _success;

			public Vector3 SnapPivot => _snapPivot;

			public Vector3 SnapDestination => _snapDestination;

			public float SnapDistance => _snapDistance;

			public SnapFailReson FailReason => _failReason;

			public SnapResult(SnapFailReson failReson)
			{
				_success = false;
				_snapPivot = Vector3.zero;
				_snapDestination = Vector3.zero;
				_snapDistance = 0f;
				_failReason = failReson;
			}

			public SnapResult(Vector3 snapPivot, Vector3 snapDestination, float snapDistance)
			{
				_success = true;
				_snapPivot = snapPivot;
				_snapDestination = snapDestination;
				_snapDistance = snapDistance;
				_failReason = SnapFailReson.None;
			}
		}

		public struct Config
		{
			private float _areaMatchEps;

			public List<GameObject> IgnoreDestObjects;

			public int DestinationLayers;

			public float SnapRadius;

			public Prefs Prefs;

			public float AreaMatchEps
			{
				get
				{
					return _areaMatchEps;
				}
				set
				{
					_areaMatchEps = Mathf.Abs(value);
				}
			}
		}

		private struct SnapSortData
		{
			public GameObject SrcObject;

			public GameObject DestObject;

			public BoxFace SrcSnapFace;

			public BoxFace DestSnapFace;

			public bool FaceAreasMatch;

			public float FaceAreaDiff;

			public Vector3 SnapPivot;

			public Vector3 SnapDest;

			public float SnapDistance;
		}

		private static Config _defaultConfig;

		public static int MaxSourceObjects => 100;

		public static Config DefaultConfig => _defaultConfig;

		static Object2ObjectSnap()
		{
			_defaultConfig = default(Config);
			_defaultConfig.AreaMatchEps = 1E-05f;
			_defaultConfig.Prefs = Prefs.None;
		}

		public static SnapResult Snap(List<GameObject> roots, Config snapConfig)
		{
			float num = float.MaxValue;
			SnapResult result = new SnapResult(SnapFailReson.NoDestinationFound);
			foreach (GameObject root in roots)
			{
				SnapResult snapResult = CalculateSnapResult(root, snapConfig);
				if (snapResult.FailReason == SnapFailReson.MaxObjectsExceeded)
				{
					return snapResult;
				}
				if (snapResult.FailReason == SnapFailReson.None && snapResult.SnapDistance < num)
				{
					num = snapResult.SnapDistance;
					result = snapResult;
				}
			}
			if (result.Success)
			{
				ObjectSnap.Snap(roots, result.SnapPivot, result.SnapDestination);
			}
			return result;
		}

		public static SnapResult Snap(GameObject root, Config snapConfig)
		{
			SnapResult result = CalculateSnapResult(root, snapConfig);
			if (result.Success)
			{
				ObjectSnap.Snap(root, result.SnapPivot, result.SnapDestination);
			}
			return result;
		}

		public static SnapResult CalculateSnapResult(GameObject root, Config snapConfig)
		{
			if (snapConfig.IgnoreDestObjects == null)
			{
				snapConfig.IgnoreDestObjects = new List<GameObject>();
			}
			List<GameObject> allChildrenAndSelf = root.GetAllChildrenAndSelf();
			if (allChildrenAndSelf.Count > MaxSourceObjects)
			{
				return new SnapResult(SnapFailReson.MaxObjectsExceeded);
			}
			List<GameObject> meshObjectsInHierarchy = root.GetMeshObjectsInHierarchy();
			List<GameObject> spriteObjectsInHierarchy = root.GetSpriteObjectsInHierarchy();
			if (meshObjectsInHierarchy.Count == 0 && spriteObjectsInHierarchy.Count == 0)
			{
				return new SnapResult(SnapFailReson.InvalidSourceObjects);
			}
			ObjectBounds.QueryConfig queryConfig = new ObjectBounds.QueryConfig
			{
				ObjectTypes = (GameObjectType.Mesh | GameObjectType.Sprite)
			};
			Vector3 vector = Vector3.one * snapConfig.SnapRadius * 2f;
			List<BoxFace> allBoxFaces = BoxMath.AllBoxFaces;
			bool flag = (snapConfig.Prefs & Prefs.TryMatchArea) != 0;
			bool flag2 = false;
			List<SnapSortData> list = new List<SnapSortData>(10);
			SnapSortData item = default(SnapSortData);
			foreach (GameObject item2 in allChildrenAndSelf)
			{
				OBB obb = ObjectBounds.CalcWorldOBB(item2, queryConfig);
				obb.Size += vector;
				List<GameObject> list2 = MonoSingleton<RTScene>.Get.OverlapBox(obb);
				list2.RemoveAll((GameObject gameObject) => gameObject.transform.IsChildOf(root.transform) || snapConfig.IgnoreDestObjects.Contains(gameObject) || !LayerEx.IsLayerBitSet(snapConfig.DestinationLayers, gameObject.layer));
				if (list2.Count == 0)
				{
					continue;
				}
				Object2ObjectSnapData object2ObjectSnapData = Singleton<Object2ObjectSnapDataDb>.Get.GetObject2ObjectSnapData(item2);
				if (object2ObjectSnapData == null)
				{
					continue;
				}
				item.SrcObject = item2;
				foreach (BoxFace item3 in allBoxFaces)
				{
					BoxFaceAreaDesc worldSnapAreaDesc = object2ObjectSnapData.GetWorldSnapAreaDesc(item3);
					List<Vector3> centerAndCornerPoints = object2ObjectSnapData.GetWorldSnapAreaBounds(item3).GetCenterAndCornerPoints();
					item.SrcSnapFace = item3;
					foreach (GameObject item4 in list2)
					{
						Object2ObjectSnapData object2ObjectSnapData2 = Singleton<Object2ObjectSnapDataDb>.Get.GetObject2ObjectSnapData(item4);
						if (object2ObjectSnapData2 == null)
						{
							continue;
						}
						item.DestObject = item4;
						foreach (BoxFace item5 in allBoxFaces)
						{
							BoxFace boxFace = (item.DestSnapFace = item5);
							BoxFaceAreaDesc worldSnapAreaDesc2 = object2ObjectSnapData2.GetWorldSnapAreaDesc(boxFace);
							item.FaceAreasMatch = false;
							if (flag && worldSnapAreaDesc2.AreaType == worldSnapAreaDesc.AreaType)
							{
								item.FaceAreaDiff = Mathf.Abs(worldSnapAreaDesc2.Area - worldSnapAreaDesc.Area);
								if (item.FaceAreaDiff <= 1000f)
								{
									item.FaceAreasMatch = true;
								}
							}
							List<Vector3> centerAndCornerPoints2 = object2ObjectSnapData2.GetWorldSnapAreaBounds(boxFace).GetCenterAndCornerPoints();
							foreach (Vector3 item6 in centerAndCornerPoints)
							{
								Vector3 vector2 = (item.SnapPivot = item6);
								foreach (Vector3 item7 in centerAndCornerPoints2)
								{
									item.SnapDistance = (item7 - vector2).magnitude;
									if (item.SnapDistance < snapConfig.SnapRadius)
									{
										item.SnapDest = item7;
										list.Add(item);
										if (item.FaceAreasMatch)
										{
											flag2 = true;
										}
									}
								}
							}
						}
					}
				}
			}
			if (list.Count != 0)
			{
				if (!flag || !flag2)
				{
					list.Sort((SnapSortData s0, SnapSortData s1) => s0.SnapDistance.CompareTo(s1.SnapDistance));
				}
				else
				{
					while (!list[0].FaceAreasMatch)
					{
						list.RemoveAt(0);
					}
					list.Sort((SnapSortData s0, SnapSortData s1) => s0.FaceAreaDiff.CompareTo(s1.FaceAreaDiff));
				}
				return new SnapResult(list[0].SnapPivot, list[0].SnapDest, list[0].SnapDistance);
			}
			return new SnapResult(SnapFailReson.NoDestinationFound);
		}
	}
}
