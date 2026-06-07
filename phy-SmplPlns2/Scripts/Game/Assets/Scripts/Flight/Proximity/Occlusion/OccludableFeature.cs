using System;
using System.Collections.Generic;
using Jundroo.Common.Math;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	public class OccludableFeature : OccludableFeatureBase, IOccludableFeature
	{
		private static class Profile
		{
			public static readonly ProfilerMarker GetInflatedBounds = new ProfilerMarker("OccludableFeature.GetInflatedBounds");

			public static readonly ProfilerMarker SetVisible = new ProfilerMarker("OccludableFeature.SetVisible");
		}

		private OrientedBoundingBox _gizmosObb;

		[Tooltip("Extra inflation factor for bounding box (e.g. 1.1 = 10% bigger).")]
		[SerializeField]
		private float _inflationFactor = 1f;

		[SerializeField]
		private float _sizeScale = 1f;

		[SerializeField]
		private string _uniqueFeatureName;

		public string FeatureName => _uniqueFeatureName;

		public float SizeScale => _sizeScale;

		public OrientedBoundingBox WorldBounds => GetInflatedBounds();

		public override IEnumerable<IOccludableFeature> GetOccludableFeaturesForBaking()
		{
			return new List<IOccludableFeature> { this };
		}

		public void SetVisible(bool visible)
		{
			using (Profile.SetVisible.Auto())
			{
				if (base.gameObject.activeSelf != visible)
				{
					base.gameObject.SetActive(visible);
				}
			}
		}

		protected void OnDrawGizmosSelected()
		{
			if (base.enabled)
			{
				if (_gizmosObb == null)
				{
					_gizmosObb = GetInflatedBounds();
				}
				_gizmosObb.Draw();
			}
		}

		protected override void Register(OcclusionManager manager)
		{
			manager.RegisterFeature(this);
		}

		protected void Reset()
		{
			if (string.IsNullOrEmpty(_uniqueFeatureName))
			{
				_uniqueFeatureName = base.gameObject.name;
			}
		}

		protected override void Unregister(OcclusionManager manager)
		{
			manager.UnregisterFeature(this);
		}

		private OrientedBoundingBox GetInflatedBounds()
		{
			using (Profile.GetInflatedBounds.Auto())
			{
				try
				{
					MeshRenderer[] componentsInChildren = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
					List<MeshRenderer> list = new List<MeshRenderer>();
					MeshRenderer[] array = componentsInChildren;
					foreach (MeshRenderer meshRenderer in array)
					{
						if ((meshRenderer.gameObject.hideFlags & HideFlags.HideInHierarchy) == 0)
						{
							list.Add(meshRenderer);
						}
					}
					return OrientedBoundingBox.CalculateOBB(list, _inflationFactor);
				}
				catch (Exception ex)
				{
					Debug.LogError("Could not create OBB for game object " + base.gameObject.name + ". Error: " + ex.Message, base.gameObject);
					return new OrientedBoundingBox(base.transform.position, Vector3.zero, Quaternion.identity);
				}
			}
		}

		[ContextMenu("Refresh Gizmos")]
		private void RefreshGizmos()
		{
			_gizmosObb = null;
		}
	}
}
