using System;
using System.Collections.Generic;
using Pathfinding.Graphs.Navmesh;
using Pathfinding.Serialization;
using Pathfinding.Util;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Navmesh/RecastMeshObj")]
	[DisallowMultipleComponent]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/recastmeshobj.html")]
	public class RecastMeshObj : VersionedMonoBehaviour
	{
		public enum ScanInclusion
		{
			Auto = 0,
			AlwaysExclude = 1,
			AlwaysInclude = 2
		}

		public enum GeometrySource
		{
			Auto = 0,
			MeshFilter = 1,
			Collider = 2
		}

		public enum Mode
		{
			UnwalkableSurface = 1,
			WalkableSurface = 2,
			WalkableSurfaceWithSeam = 3,
			WalkableSurfaceWithTag = 4
		}

		protected static AABBTree<RecastMeshObj> tree = new AABBTree<RecastMeshObj>();

		public bool dynamic = true;

		public bool solid;

		public GeometrySource geometrySource;

		public ScanInclusion includeInScan;

		[FormerlySerializedAs("area")]
		public int surfaceID = 1;

		public Mode mode = Mode.WalkableSurface;

		private AABBTree<RecastMeshObj>.Key treeKey;

		[Obsolete("Use mode and surfaceID instead")]
		public int area
		{
			get
			{
				return mode switch
				{
					Mode.UnwalkableSurface => -1, 
					Mode.WalkableSurfaceWithSeam => surfaceID, 
					Mode.WalkableSurfaceWithTag => surfaceID, 
					_ => 0, 
				};
			}
			set
			{
				if (value <= -1)
				{
					mode = Mode.UnwalkableSurface;
				}
				if (value == 0)
				{
					mode = Mode.WalkableSurface;
				}
				if (value > 0)
				{
					mode = Mode.WalkableSurfaceWithSeam;
					surfaceID = value;
				}
			}
		}

		private void OnEnable()
		{
			surfaceID = Mathf.Clamp(surfaceID, 0, 33554432);
			if (!treeKey.isValid)
			{
				treeKey = tree.Add(CalculateBounds(), this);
				if (dynamic)
				{
					BatchedEvents.Add(this, BatchedEvents.Event.Custom, OnUpdate);
				}
			}
		}

		private void OnDisable()
		{
			BatchedEvents.Remove(this);
			Bounds bounds = tree.Remove(treeKey);
			treeKey = default(AABBTree<RecastMeshObj>.Key);
			if (!dynamic)
			{
				Bounds bounds2 = CalculateBounds();
				bounds.Expand(0.001f);
				bounds2.Encapsulate(bounds);
				if ((bounds2.center - bounds.center).sqrMagnitude > 0.0001f || (bounds2.extents - bounds.extents).sqrMagnitude > 0.0001f)
				{
					Bounds bounds3 = bounds;
					string text = bounds3.ToString();
					bounds3 = bounds2;
					Debug.LogError("The RecastMeshObj has been moved or resized since it was enabled. You should set dynamic to true for moving objects, or disable the component while moving it. The bounds changed from " + text + " to " + bounds3.ToString(), this);
				}
			}
		}

		private static void OnUpdate(RecastMeshObj[] components, int _)
		{
			foreach (RecastMeshObj recastMeshObj in components)
			{
				if (recastMeshObj != null && recastMeshObj.transform.hasChanged)
				{
					Bounds bounds = recastMeshObj.CalculateBounds();
					if (tree.GetBounds(recastMeshObj.treeKey) != bounds)
					{
						tree.Move(recastMeshObj.treeKey, bounds);
					}
					recastMeshObj.transform.hasChanged = false;
				}
			}
		}

		public static void GetAllInBounds(List<RecastMeshObj> buffer, Bounds bounds)
		{
			BatchedEvents.ProcessEvent<RecastMeshObj>(BatchedEvents.Event.Custom);
			if (!Application.isPlaying)
			{
				RecastMeshObj[] array = UnityCompatibility.FindObjectsByTypeSorted<RecastMeshObj>();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].enabled && bounds.Intersects(array[i].CalculateBounds()))
					{
						buffer.Add(array[i]);
					}
				}
				return;
			}
			if (Time.timeSinceLevelLoad == 0f)
			{
				RecastMeshObj[] array2 = UnityCompatibility.FindObjectsByTypeUnsorted<RecastMeshObj>();
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j].OnEnable();
				}
			}
			tree.Query(bounds, buffer);
		}

		public void ResolveMeshSource(out MeshFilter meshFilter, out Collider collider, out Collider2D collider2D)
		{
			meshFilter = null;
			collider = null;
			collider2D = null;
			switch (geometrySource)
			{
			case GeometrySource.Auto:
			{
				if ((!TryGetComponent<MeshRenderer>(out var _) || !TryGetComponent<MeshFilter>(out meshFilter) || !(meshFilter.sharedMesh != null)) && !TryGetComponent<Collider>(out collider))
				{
					TryGetComponent<Collider2D>(out collider2D);
				}
				break;
			}
			case GeometrySource.MeshFilter:
				TryGetComponent<MeshFilter>(out meshFilter);
				break;
			case GeometrySource.Collider:
				if (!TryGetComponent<Collider>(out collider))
				{
					TryGetComponent<Collider2D>(out collider2D);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private Bounds CalculateBounds()
		{
			ResolveMeshSource(out var meshFilter, out var collider, out var collider2D);
			if (collider != null)
			{
				return collider.bounds;
			}
			if (collider2D != null)
			{
				return collider2D.bounds;
			}
			if (meshFilter != null)
			{
				if (TryGetComponent<MeshRenderer>(out var component))
				{
					return component.bounds;
				}
				Debug.LogError("Cannot use a MeshFilter as a geomtry source without a MeshRenderer attached to the same GameObject.", this);
				return new Bounds(Vector3.zero, Vector3.one);
			}
			Debug.LogError("Could not find an attached mesh source", this);
			return new Bounds(Vector3.zero, Vector3.one);
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
			if (migrations.TryMigrateFromLegacyFormat(out var legacyVersion))
			{
				if (legacyVersion == 1)
				{
					area = surfaceID;
				}
				if (legacyVersion <= 2)
				{
					includeInScan = ScanInclusion.AlwaysInclude;
				}
				if (mode == (Mode)0)
				{
					includeInScan = ScanInclusion.AlwaysExclude;
				}
			}
		}
	}
}
