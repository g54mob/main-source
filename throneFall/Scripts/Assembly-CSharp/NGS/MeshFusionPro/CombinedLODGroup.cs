using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombinedLODGroup : MonoBehaviour, ICombinedObject<CombinedLODGroupPart, LODGroupCombineSource>, ICombinedObject
	{
		private class LevelOfDetailCombiner : StaticObjectsCombiner
		{
			private Transform _transform;

			private CombinedLODGroup _group;

			private Renderer[] _renderers;

			private int _level;

			public LevelOfDetailCombiner(int level, CombinedLODGroup group, ICombinedMeshFactory factory, int vertexLimit)
				: base(factory, vertexLimit)
			{
				_level = level;
				_group = group;
				_transform = new GameObject("LOD" + _level).transform;
				_transform.parent = group.transform;
				_transform.localPosition = Vector3.zero;
			}

			public Renderer[] GetRenderers()
			{
				if (_renderers == null || _renderers.Length != base.CombinedObjects.Count)
				{
					UpdateRenderersList();
				}
				return _renderers;
			}

			public Bounds CalculateBounds()
			{
				Bounds result = new Bounds(_group.transform.position, Vector3.zero);
				GetRenderers();
				for (int i = 0; i < _renderers.Length; i++)
				{
					if (base.CombinedObjects[i].Parts.Count > 0)
					{
						result.Encapsulate(_renderers[i].bounds);
					}
				}
				return result;
			}

			protected override CombinedObject CreateCombinedObject(CombineSource source)
			{
				CombinedObject combinedObject = base.CreateCombinedObject(source);
				combinedObject.transform.parent = _transform;
				_group._updateLODs = true;
				return combinedObject;
			}

			private void UpdateRenderersList()
			{
				_renderers = base.CombinedObjects.Select((CombinedObject r) => r.GetComponent<Renderer>()).ToArray();
			}
		}

		private LODGroup _group;

		private List<CombinedLODGroupPart> _parts;

		private LevelOfDetailCombiner[] _levelCombiners;

		private LOD[] _lods;

		private Bounds _localBounds;

		private int _lodCount;

		private LODGroupSettings _originalSettings;

		private float _originalBoundsSize;

		private bool _updateLODs;

		IReadOnlyList<ICombinedObjectPart> ICombinedObject.Parts => _parts;

		public IReadOnlyList<CombinedLODGroupPart> Parts => _parts;

		public LODGroupSettings Settings => _originalSettings;

		public Bounds Bounds
		{
			get
			{
				Bounds localBounds = _localBounds;
				localBounds.center += base.transform.position;
				return localBounds;
			}
		}

		public static CombinedLODGroup Create(MeshType meshType, CombineMethod combineMethod, LODGroupSettings settings, int vertexLimit = 45000)
		{
			return Create(new CombinedMeshFactory(meshType, combineMethod), settings, vertexLimit);
		}

		public static CombinedLODGroup Create(ICombinedMeshFactory factory, LODGroupSettings settings, int vertexLimit = 45000)
		{
			CombinedLODGroup combinedLODGroup = new GameObject("CombinedLODGroup").AddComponent<CombinedLODGroup>();
			combinedLODGroup.Construct(settings, factory, vertexLimit);
			return combinedLODGroup;
		}

		private void Construct(LODGroupSettings settings, ICombinedMeshFactory factory, int vertexLimit)
		{
			if (factory == null)
			{
				throw new ArgumentException("CombinedLODGroup::factory is null");
			}
			_group = base.gameObject.AddComponent<LODGroup>();
			_parts = new List<CombinedLODGroupPart>();
			_group.fadeMode = settings.fadeMode;
			_group.animateCrossFading = settings.animateCrossFading;
			_originalSettings = settings;
			_lodCount = _originalSettings.lodCount;
			_levelCombiners = new LevelOfDetailCombiner[_lodCount];
			_lods = new LOD[_originalSettings.lodCount];
			for (int i = 0; i < _originalSettings.lodCount; i++)
			{
				_levelCombiners[i] = new LevelOfDetailCombiner(i, this, factory, vertexLimit);
				_lods[i] = new LOD
				{
					fadeTransitionWidth = _originalSettings.fadeTransitionsWidth[i],
					screenRelativeTransitionHeight = _originalSettings.screenTransitionsHeight[i],
					renderers = null
				};
			}
		}

		public void Combine(IEnumerable<ICombineSource> sources)
		{
			Combine(sources.Select((ICombineSource s) => (LODGroupCombineSource)s));
		}

		public void Combine(IEnumerable<LODGroupCombineSource> sourceGroups)
		{
			if (sourceGroups == null || sourceGroups.Count() == 0)
			{
				throw new ArgumentException("CombinedLODGroup::sources is null");
			}
			LODGroupCombineSource[] array = sourceGroups.ToArray();
			if (_parts.Count == 0)
			{
				InitBeforeFirstCombine(array);
			}
			List<CombinedObjectPart>[] combinedParts = FillCombinersAndCreateBaseParts(array);
			for (int i = 0; i < _lodCount; i++)
			{
				_levelCombiners[i].Combine();
			}
			RecalculateBounds();
			if (_updateLODs)
			{
				UpdateLODs();
				_updateLODs = false;
			}
			CreatePartsAndNotifySources(array, combinedParts);
		}

		public void Destroy(CombinedLODGroupPart part, IList<CombinedObjectPart> baseParts)
		{
			if (_parts.Remove(part))
			{
				for (int i = 0; i < baseParts.Count; i++)
				{
					baseParts[i].Destroy();
				}
				RecalculateBounds();
			}
		}

		private void InitBeforeFirstCombine(LODGroupCombineSource[] sources)
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < sources.Length; i++)
			{
				zero += sources[i].Position;
			}
			base.transform.position = zero / sources.Length;
			_originalBoundsSize = sources[0].Bounds.size.magnitude;
		}

		private List<CombinedObjectPart>[] FillCombinersAndCreateBaseParts(LODGroupCombineSource[] sourceGroups)
		{
			List<CombinedObjectPart>[] parts = new List<CombinedObjectPart>[sourceGroups.Length];
			for (int i = 0; i < sourceGroups.Length; i++)
			{
				LODGroupCombineSource sourceGroup = sourceGroups[i];
				parts[i] = new List<CombinedObjectPart>();
				for (int j = 0; j < _lodCount; j++)
				{
					CombineSource[] array = sourceGroup.BaseSources[j];
					foreach (CombineSource obj in array)
					{
						int g = i;
						obj.onCombinedTyped += delegate(CombinedObject o, CombinedObjectPart p)
						{
							parts[g].Add(p);
						};
						obj.onCombineErrorTyped += delegate(CombinedObject root, string msg)
						{
							sourceGroup.CombineError(this, msg);
						};
					}
					_levelCombiners[j].AddSources(array);
				}
			}
			return parts;
		}

		private void RecalculateBounds()
		{
			_localBounds = new Bounds(base.transform.position, Vector3.zero);
			for (int i = 0; i < _levelCombiners.Length; i++)
			{
				_localBounds.Encapsulate(_levelCombiners[i].CalculateBounds());
			}
			_localBounds.center -= base.transform.position;
		}

		private void UpdateLODs()
		{
			float value = _localBounds.size.magnitude / _originalBoundsSize;
			float num = 1f;
			value = Mathf.Clamp(value, 1f, 100f);
			for (int i = 0; i < _lodCount; i++)
			{
				LOD lOD = _lods[i];
				lOD.renderers = _levelCombiners[i].GetRenderers();
				lOD.screenRelativeTransitionHeight = _originalSettings.screenTransitionsHeight[i] * value;
				if (lOD.screenRelativeTransitionHeight >= num)
				{
					num = (lOD.screenRelativeTransitionHeight = num - 0.03f);
				}
				_lods[i] = lOD;
			}
			_group.SetLODs(_lods);
		}

		private void CreatePartsAndNotifySources(LODGroupCombineSource[] sourceGroups, List<CombinedObjectPart>[] combinedParts)
		{
			for (int i = 0; i < sourceGroups.Length; i++)
			{
				LODGroupCombineSource lODGroupCombineSource = sourceGroups[i];
				List<CombinedObjectPart> list = combinedParts[i];
				if (list.Count == 0)
				{
					lODGroupCombineSource.CombineFailed(this);
					continue;
				}
				CombinedLODGroupPart combinedLODGroupPart = new CombinedLODGroupPart(this, list);
				_parts.Add(combinedLODGroupPart);
				lODGroupCombineSource.Combined(this, combinedLODGroupPart);
			}
		}
	}
}
