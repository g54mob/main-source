using System;
using System.Collections.Generic;
using Pathfinding.Collections;
using Pathfinding.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Pathfinding
{
	[AddComponentMenu("Pathfinding/Navmesh/RecastNavmeshModifier")]
	[DisallowMultipleComponent]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/recastnavmeshmodifier.html")]
	public class RecastNavmeshModifier : VersionedMonoBehaviour, RecastMeshObj
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

		protected static AABBTree<RecastNavmeshModifier> tree;

		public bool dynamic;

		public bool solid;

		public GeometrySource geometrySource;

		public ScanInclusion includeInScan;

		[FormerlySerializedAs("area")]
		public int surfaceID;

		public Mode mode;

		private AABBTree<RecastNavmeshModifier>.Key treeKey;

		[Obsolete("Use mode and surfaceID instead")]
		public int area
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		bool RecastMeshObj.dynamic
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool RecastMeshObj.solid
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		GeometrySource RecastMeshObj.geometrySource
		{
			get
			{
				return default(GeometrySource);
			}
			set
			{
			}
		}

		ScanInclusion RecastMeshObj.includeInScan
		{
			get
			{
				return default(ScanInclusion);
			}
			set
			{
			}
		}

		int RecastMeshObj.surfaceID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		Mode RecastMeshObj.mode
		{
			get
			{
				return default(Mode);
			}
			set
			{
			}
		}

		bool RecastMeshObj.enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private static void OnUpdate(RecastNavmeshModifier[] components, int _)
		{
		}

		public static void GetAllInBounds(List<RecastNavmeshModifier> buffer, Bounds bounds)
		{
		}

		public void ResolveMeshSource(out MeshFilter meshFilter, out Collider collider, out Collider2D collider2D)
		{
			meshFilter = null;
			collider = null;
			collider2D = null;
		}

		private Bounds CalculateBounds()
		{
			return default(Bounds);
		}

		protected override void OnUpgradeSerializedData(ref Migrations migrations, bool unityThread)
		{
		}
	}
}
