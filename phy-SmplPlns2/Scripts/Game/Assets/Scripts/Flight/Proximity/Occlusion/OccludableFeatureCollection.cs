using System;
using System.Collections.Generic;
using Jundroo.Common.Math;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity.Occlusion
{
	public class OccludableFeatureCollection : OccludableFeatureBase
	{
		public class FeatureCollectionItem : IOccludableFeature
		{
			private GameObject _go;

			private float _inflationFactor = 1f;

			public string FeatureName => _go.name;

			public List<MeshRenderer> MeshRenderers { get; } = new List<MeshRenderer>();

			public float SizeScale => 1f;

			public OrientedBoundingBox WorldBounds
			{
				get
				{
					using (Profile.WorldBounds.Auto())
					{
						try
						{
							return OrientedBoundingBox.CalculateOBB(MeshRenderers, _inflationFactor);
						}
						catch (Exception ex)
						{
							Debug.LogError("Could not create OBB for game object " + _go.name + ". Error: " + ex.Message, _go);
							return new OrientedBoundingBox(_go.transform.position, Vector3.zero, Quaternion.identity);
						}
					}
				}
			}

			public FeatureCollectionItem(GameObject go, float inflationFactor)
			{
				_go = go;
				_inflationFactor = inflationFactor;
				MeshRenderer[] componentsInChildren = go.GetComponentsInChildren<MeshRenderer>(includeInactive: true);
				foreach (MeshRenderer meshRenderer in componentsInChildren)
				{
					if ((meshRenderer.gameObject.hideFlags & HideFlags.HideInHierarchy) == 0)
					{
						MeshRenderers.Add(meshRenderer);
					}
				}
			}

			public void SetVisible(bool visible)
			{
				using (Profile.SetVisible.Auto())
				{
					if (_go.activeSelf != visible)
					{
						_go.SetActive(visible);
					}
				}
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker GenerateOccludableFeatures = new ProfilerMarker("OccludableFeatureCollection.GenerateOccludableFeatures");

			public static readonly ProfilerMarker SetVisible = new ProfilerMarker("FeatureCollectionItem.SetVisible");

			public static readonly ProfilerMarker WorldBounds = new ProfilerMarker("FeatureCollectionItem.WorldBounds");
		}

		private Dictionary<Transform, OrientedBoundingBox> _gizmoBoundingBoxes;

		[Tooltip("Extra inflation factor for bounding box (e.g. 1.1 = 10% bigger) for all items in the collection.")]
		[SerializeField]
		private float _inflationFactor = 1f;

		private List<IOccludableFeature> _items;

		[SerializeField]
		private bool _showFeatureGizmos;

		public override IEnumerable<IOccludableFeature> GetOccludableFeaturesForBaking()
		{
			return GenerateOccludableFeatures();
		}

		protected void OnDrawGizmosSelected()
		{
			if (!_showFeatureGizmos)
			{
				return;
			}
			if (_gizmoBoundingBoxes == null)
			{
				_gizmoBoundingBoxes = new Dictionary<Transform, OrientedBoundingBox>();
			}
			foreach (Transform item in base.transform)
			{
				if (!_gizmoBoundingBoxes.TryGetValue(item, out var value))
				{
					FeatureCollectionItem featureCollectionItem = new FeatureCollectionItem(item.gameObject, _inflationFactor);
					if (featureCollectionItem.MeshRenderers.Count > 0)
					{
						value = featureCollectionItem.WorldBounds;
						_gizmoBoundingBoxes[item] = value;
					}
				}
				value?.Draw();
			}
		}

		protected override void Register(OcclusionManager manager)
		{
			_items = GenerateOccludableFeatures();
			foreach (IOccludableFeature item in _items)
			{
				try
				{
					manager.RegisterFeature(item);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		protected override void Unregister(OcclusionManager manager)
		{
			if (_items == null)
			{
				return;
			}
			foreach (IOccludableFeature item in _items)
			{
				manager.UnregisterFeature(item);
			}
			_items = null;
		}

		[ContextMenu("Append Child Index")]
		private void AppendChildIndex()
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				string text = child.name;
				int num = text.IndexOf('-');
				if (num >= 0)
				{
					text = text.Substring(0, num);
				}
				child.name = $"{text}-{i}";
			}
		}

		private List<IOccludableFeature> GenerateOccludableFeatures()
		{
			using (Profile.GenerateOccludableFeatures.Auto())
			{
				List<IOccludableFeature> list = new List<IOccludableFeature>();
				foreach (Transform item in base.transform)
				{
					FeatureCollectionItem featureCollectionItem = new FeatureCollectionItem(item.gameObject, _inflationFactor);
					if (featureCollectionItem.MeshRenderers.Count > 0)
					{
						list.Add(featureCollectionItem);
					}
				}
				return list;
			}
		}

		[ContextMenu("Refresh Gizmos")]
		private void RefreshGizmos()
		{
			_gizmoBoundingBoxes = null;
		}
	}
}
