using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSMedieval.OcclusionCulling;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class CombinedLODGroup : BaseCombinedObject, ICombinedObject<CombinedLODGroupPart, LODGroupCombineSource>, ICombinedObject, IOcclusionObject
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

			public override string ToString()
			{
				return $"CombinedLODGroup {_transform.position}";
			}
		}

		public static readonly List<CombinedLODGroup> ActiveObjects = new List<CombinedLODGroup>();

		private LODGroup _group;

		private List<CombinedLODGroupPart> _parts;

		private LevelOfDetailCombiner[] _levelCombiners;

		private LOD[] _lods;

		private Bounds _localBounds;

		private int _lodCount;

		private LODGroupSettings _settings;

		private bool _updateLODs;

		private bool isOcclusionCulled;

		IReadOnlyList<ICombinedObjectPart> ICombinedObject.Parts => _parts;

		public IReadOnlyList<CombinedLODGroupPart> Parts => _parts;

		public LODGroupSettings Settings => _settings;

		public override Bounds Bounds
		{
			get
			{
				Bounds localBounds = _localBounds;
				localBounds.center += base.transform.position;
				return localBounds;
			}
		}

		public bool IsOcclusionCulled
		{
			get
			{
				return isOcclusionCulled;
			}
			set
			{
				if (isOcclusionCulled != value)
				{
					isOcclusionCulled = value;
					if (isOcclusionCulled)
					{
						_group.ForceLOD(int.MaxValue);
					}
					else
					{
						_group.ForceLOD(-1);
					}
				}
			}
		}

		public OcclusionCullingMode OcclusionCullingMode => OcclusionCullingMode.CanBeOccludedOnly;

		public Bounds OcclusionLocalSpaceBoundingBox => _localBounds;

		public Vector3 WorldPosition => base.transform.position;

		public static event Action<CombinedLODGroup> ObjectActivated;

		public static event Action<CombinedLODGroup> ObjectDeactivated;

		public static event Action<CombinedLODGroup> BoundsChanged;

		public event Action<CombinedObject> onStaticCombinedObjectCreated
		{
			add
			{
				for (int i = 0; i < _levelCombiners.Length; i++)
				{
					_levelCombiners[i].onCombinedObjectCreated += value;
				}
			}
			remove
			{
				for (int i = 0; i < _levelCombiners.Length; i++)
				{
					_levelCombiners[i].onCombinedObjectCreated -= value;
				}
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void DomainReload()
		{
			ActiveObjects.Clear();
		}

		private void LateUpdate()
		{
			RecalculateBounds();
			_group.RecalculateBounds();
			base.enabled = false;
		}

		public static CombinedLODGroup Create(MeshType meshType, CombineMethod combineMethod, LODGroupCombineSource source, int vertexLimit = 45000)
		{
			return Create(new CombinedMeshFactory(meshType, combineMethod), source, vertexLimit);
		}

		public static CombinedLODGroup Create(ICombinedMeshFactory factory, LODGroupCombineSource source, int vertexLimit = 45000)
		{
			CombinedLODGroup combinedLODGroup = new GameObject("CombinedLODGroup").AddComponent<CombinedLODGroup>();
			combinedLODGroup.Construct(source, factory, vertexLimit);
			return combinedLODGroup;
		}

		private void Construct(LODGroupCombineSource source, ICombinedMeshFactory factory, int vertexLimit)
		{
			if (factory == null)
			{
				throw new ArgumentException("CombinedLODGroup::factory is null");
			}
			_group = base.gameObject.AddComponent<LODGroup>();
			_parts = new List<CombinedLODGroupPart>();
			LODGroupSettings settings = source.Settings;
			_group.size = source.LODGroup.size;
			_group.fadeMode = settings.fadeMode;
			_group.animateCrossFading = settings.animateCrossFading;
			_settings = settings;
			_lodCount = _settings.lodCount;
			_levelCombiners = new LevelOfDetailCombiner[_lodCount];
			_lods = new LOD[_lodCount];
			LOD[] lODs = source.LODGroup.GetLODs();
			for (int i = 0; i < _settings.lodCount; i++)
			{
				_levelCombiners[i] = new LevelOfDetailCombiner(i, this, factory, vertexLimit);
				_lods[i] = new LOD
				{
					fadeTransitionWidth = lODs[i].fadeTransitionWidth,
					screenRelativeTransitionHeight = lODs[i].screenRelativeTransitionHeight,
					renderers = null
				};
			}
			base.enabled = false;
		}

		private void OnDestroy()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\MeshFusionPro\\Core\\Runtime\\8.CombinedLODGroup\\CombinedLODGroup.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Unregister combined mesh at ");
				messageBuilder.AppendFormatted(base.transform.position);
			}
			Log.Trace(messageBuilder);
			ActiveObjects.Remove(this);
			CombinedLODGroup.ObjectDeactivated?.Invoke(this);
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
				CentralizePosition(array);
			}
			List<CombinedObjectPart>[] combinedParts = FillCombinersAndCreateBaseParts(array);
			for (int i = 0; i < _lodCount; i++)
			{
				_levelCombiners[i].Combine();
			}
			if (_updateLODs)
			{
				UpdateLODs();
				_updateLODs = false;
			}
			CreatePartsAndNotifySources(array, combinedParts);
			base.enabled = true;
		}

		public void Destroy(CombinedLODGroupPart part, IList<CombinedObjectPart> baseParts)
		{
			if (_parts.Remove(part))
			{
				for (int i = 0; i < baseParts.Count; i++)
				{
					baseParts[i].Destroy();
				}
				base.enabled = true;
			}
			if (_parts.Count == 0)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\MeshFusionPro\\Core\\Runtime\\8.CombinedLODGroup\\CombinedLODGroup.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Unregister combined mesh at ");
					messageBuilder.AppendFormatted(base.transform.position);
				}
				Log.Trace(messageBuilder);
				ActiveObjects.Remove(this);
				CombinedLODGroup.ObjectDeactivated?.Invoke(this);
			}
		}

		private void CentralizePosition(LODGroupCombineSource[] sources)
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < sources.Length; i++)
			{
				zero += sources[i].Position;
			}
			base.transform.position = zero / sources.Length;
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
			Bounds localBounds = _localBounds;
			_localBounds = new Bounds(base.transform.position, Vector3.zero);
			for (int i = 0; i < _levelCombiners.Length; i++)
			{
				_localBounds.Encapsulate(_levelCombiners[i].CalculateBounds());
			}
			_localBounds.center -= base.transform.position;
			if (_localBounds != localBounds)
			{
				CombinedLODGroup.BoundsChanged?.Invoke(this);
			}
		}

		private void UpdateLODs()
		{
			for (int i = 0; i < _lodCount; i++)
			{
				LOD lOD = _lods[i];
				lOD.renderers = _levelCombiners[i].GetRenderers();
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
				if (_parts.Count == 1)
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\MeshFusionPro\\Core\\Runtime\\8.CombinedLODGroup\\CombinedLODGroup.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Register combined mesh at ");
						messageBuilder.AppendFormatted(base.transform.position);
					}
					Log.Trace(messageBuilder);
					ActiveObjects.Add(this);
					CombinedLODGroup.ObjectActivated?.Invoke(this);
				}
				lODGroupCombineSource.Combined(this, combinedLODGroupPart);
			}
		}
	}
}
