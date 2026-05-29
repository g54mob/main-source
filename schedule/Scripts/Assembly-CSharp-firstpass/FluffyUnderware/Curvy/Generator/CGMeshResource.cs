using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[RequireComponent(typeof(MeshRenderer))]
	[HelpURL("https://curvyeditor.com/doclink/cgmeshresource")]
	public class CGMeshResource : DuplicateEditorMesh, IPoolable
	{
		public const MeshColliderCookingOptions EverMeshColliderCookingOptions = MeshColliderCookingOptions.CookForFasterSimulation | MeshColliderCookingOptions.EnableMeshCleaning | MeshColliderCookingOptions.WeldColocatedVertices | MeshColliderCookingOptions.UseFastMidphase;

		private MeshRenderer mRenderer;

		private Collider mCollider;

		private static readonly HashSet<Mesh> UsedMeshes;

		public MeshRenderer Renderer => null;

		public Collider Collider => null;

		[UsedImplicitly]
		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		public Mesh Prepare()
		{
			return null;
		}

		public bool ColliderMatches(CGColliderEnum type)
		{
			return false;
		}

		public void RemoveCollider()
		{
		}

		public bool UpdateCollider(CGColliderEnum mode, bool convex, bool isTrigger, PhysicMaterial material, MeshColliderCookingOptions meshCookingOptions = MeshColliderCookingOptions.CookForFasterSimulation | MeshColliderCookingOptions.EnableMeshCleaning | MeshColliderCookingOptions.WeldColocatedVertices | MeshColliderCookingOptions.UseFastMidphase)
		{
			return false;
		}

		public void OnBeforePush()
		{
		}

		public void OnAfterPop()
		{
		}

		private static Mesh GetNewMesh()
		{
			return null;
		}

		private static Mesh GetNewMesh([NotNull] Mesh oldMesh)
		{
			return null;
		}

		[UsedImplicitly]
		protected void Awake()
		{
		}

		[UsedImplicitly]
		public void OnDestroy()
		{
		}

		[Obsolete("Too slow, used only in sanity checks")]
		[UsedImplicitly]
		private static bool UsesSharedMesh(CGMeshResource meshResource)
		{
			return false;
		}
	}
}
