using System;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Decals
{
	public class PartMeshDecalObject : MonoBehaviour
	{
		private static class Profile
		{
			public const string Prefix = "PartMeshDecalObject";

			public static readonly ProfilerMarker Create = new ProfilerMarker("PartMeshDecalObject.Create");

			public static readonly ProfilerMarker InitializePooledObject = new ProfilerMarker("PartMeshDecalObject.InitializePooledObject");

			public static readonly ProfilerMarker RefreshRenderer = new ProfilerMarker("PartMeshDecalObject.RefreshRenderer");

			public static readonly ProfilerMarker ResetPooledObject = new ProfilerMarker("PartMeshDecalObject.ResetPooledObject");
		}

		public ICraftDecal Decal { get; private set; }

		public DecalTargetScript DecalTarget { get; private set; }

		public GameObject GameObject { get; private set; }

		public Transform Transform { get; protected set; }

		public void InitializePooledObject(ICraftDecal decal, DecalTargetScript target)
		{
			using (Profile.InitializePooledObject.Auto())
			{
				Decal = decal;
				DecalTarget = target;
				Decal.DecalPropertiesChanged += OnDecalPropertiesChanged;
				OnInitializePooledObject(decal, target);
				GameObject.SetActive(value: true);
			}
		}

		public void RefreshRenderer()
		{
			using (Profile.RefreshRenderer.Auto())
			{
				OnRefreshRenderer();
			}
		}

		public void ResetPooledObject()
		{
			using (Profile.ResetPooledObject.Auto())
			{
				GameObject.SetActive(value: false);
				OnResetPooledObject();
				if (Decal != null)
				{
					Decal.DecalPropertiesChanged -= OnDecalPropertiesChanged;
				}
				Decal = null;
				DecalTarget = null;
			}
		}

		protected static T Create<T>() where T : PartMeshDecalObject
		{
			using (Profile.Create.Auto())
			{
				GameObject gameObject = new GameObject("T");
				T val = gameObject.AddComponent<T>();
				val.Transform = gameObject.GetComponent<Transform>();
				val.GameObject = gameObject;
				val.OnCreated();
				return val;
			}
		}

		protected virtual void OnCreated()
		{
		}

		protected virtual void OnDestroy()
		{
			ResetPooledObject();
		}

		protected virtual void OnInitializePooledObject(ICraftDecal decal, DecalTargetScript target)
		{
		}

		protected virtual void OnRefreshRenderer()
		{
		}

		protected virtual void OnResetPooledObject()
		{
		}

		private void OnDecalPropertiesChanged(object sender, EventArgs e)
		{
			RefreshRenderer();
		}
	}
}
