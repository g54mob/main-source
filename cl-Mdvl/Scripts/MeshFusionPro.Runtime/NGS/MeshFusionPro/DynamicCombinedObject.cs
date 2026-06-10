using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public class DynamicCombinedObject : BaseCombinedObject, ICombinedObject<DynamicCombinedObjectPart, DynamicCombineSource>, ICombinedObject
	{
		public static readonly List<DynamicFusedObjectDrawData> ObjectsDrawData = new List<DynamicFusedObjectDrawData>();

		private CombinedObject _baseObject;

		private List<DynamicCombinedObjectPart> _parts;

		private ICombinedMeshMover _meshMover;

		private List<DynamicCombinedObjectPartInternal> _movedParts;

		private List<PartMoveInfo> _movedPartsData;

		private bool _partsMoved;

		IReadOnlyList<ICombinedObjectPart> ICombinedObject.Parts => _parts;

		public IReadOnlyList<DynamicCombinedObjectPart> Parts => _parts;

		public RendererSettings RendererSettings => _baseObject.RendererSettings;

		public override Bounds Bounds => _baseObject.Bounds;

		public Bounds LocalBounds => _baseObject.LocalBounds;

		public int VertexCount => _baseObject.VertexCount;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void DomainReload()
		{
			ObjectsDrawData.Clear();
		}

		private void Update()
		{
			if (_movedParts.Count > 0)
			{
				if (_meshMover is IAsyncCombinedMeshMover asyncCombinedMeshMover)
				{
					asyncCombinedMeshMover.MovePartsAsync(_movedPartsData);
				}
				else
				{
					_meshMover.MoveParts(_movedPartsData);
				}
				for (int i = 0; i < _movedParts.Count; i++)
				{
					_movedParts[i].PositionUpdated();
				}
				_movedParts.Clear();
				_movedPartsData.Clear();
				_partsMoved = true;
			}
		}

		private void LateUpdate()
		{
			if (_partsMoved)
			{
				if (_meshMover is IAsyncCombinedMeshMover asyncCombinedMeshMover)
				{
					asyncCombinedMeshMover.FinishAsyncMoving();
				}
				_meshMover.ApplyData();
				_partsMoved = false;
			}
			_baseObject.ForceUpdate();
			if (_movedParts.Count == 0)
			{
				base.enabled = false;
			}
		}

		private void UnregisterDrawObject()
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\MeshFusionPro\\Core\\Runtime\\6.CombinedObject\\Logic\\Dynamic\\DynamicCombinedObject.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Unregister combined mesh at ");
				messageBuilder.AppendFormatted(base.transform.position);
			}
			Log.Trace(messageBuilder);
			for (int i = 0; i < ObjectsDrawData.Count; i++)
			{
				if (ObjectsDrawData[i].Mesh == _baseObject.CombinedMesh.Mesh)
				{
					ObjectsDrawData.RemoveAt(i);
					break;
				}
			}
		}

		private void OnDestroy()
		{
			UnregisterDrawObject();
			if (_meshMover is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}

		public static DynamicCombinedObject Create(MeshType meshType, CombineMethod combineMethod, MoveMethod moveMethod, RendererSettings settings)
		{
			return Create(new CombinedMeshFactory(meshType, combineMethod, moveMethod), settings);
		}

		public static DynamicCombinedObject Create(ICombinedMeshFactory factory, RendererSettings settings)
		{
			ICombinedMeshMover mover;
			CombinedObject combinedObject = CombinedObject.Create(factory.CreateMovableCombinedMesh(out mover), settings);
			DynamicCombinedObject dynamicCombinedObject = combinedObject.gameObject.AddComponent<DynamicCombinedObject>();
			dynamicCombinedObject.Construct(combinedObject, mover);
			return dynamicCombinedObject;
		}

		private void Construct(CombinedObject baseObject, ICombinedMeshMover mover)
		{
			base.gameObject.name = "Dynamic Combined Object";
			_baseObject = baseObject;
			_meshMover = mover;
			_parts = new List<DynamicCombinedObjectPart>();
			_movedParts = new List<DynamicCombinedObjectPartInternal>();
			_movedPartsData = new List<PartMoveInfo>();
			_baseObject.Updating = false;
		}

		public void Combine(IEnumerable<ICombineSource> sources)
		{
			Combine(sources.Select((ICombineSource s) => (DynamicCombineSource)s));
		}

		public void Combine(IEnumerable<DynamicCombineSource> sources)
		{
			int num = sources.Count();
			CombineSource[] array = new CombineSource[num];
			_ = new DynamicCombinedObjectPart[num];
			int num2 = 0;
			foreach (DynamicCombineSource source in sources)
			{
				CombineSource baseSource = source.Base;
				array[num2++] = baseSource;
				baseSource.onCombinedTyped += delegate(CombinedObject root, CombinedObjectPart part)
				{
					DynamicCombinedObjectPart dynamicCombinedObjectPart = new DynamicCombinedObjectPartInternal(this, part, baseSource.CombineInfo.transformMatrix);
					_parts.Add(dynamicCombinedObjectPart);
					if (_parts.Count == 1)
					{
						bool isEnabled;
						FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(26, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Externals\\MeshFusionPro\\Core\\Runtime\\6.CombinedObject\\Logic\\Dynamic\\DynamicCombinedObject.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Register combined mesh at ");
							messageBuilder.AppendFormatted(base.transform.position);
						}
						Log.Trace(messageBuilder);
						ObjectsDrawData.Add(new DynamicFusedObjectDrawData
						{
							Mesh = _baseObject.CombinedMesh.Mesh,
							TransformMatrix = Matrix4x4.Translate(_baseObject.transform.position)
						});
					}
					source.Combined(this, dynamicCombinedObjectPart);
				};
				baseSource.onCombineErrorTyped += delegate(CombinedObject root, string message)
				{
					source.CombineError(this, message);
				};
				baseSource.onCombineFailedTyped += delegate
				{
					source.CombineFailed(this);
				};
			}
			_baseObject.Combine(array);
		}

		public void UpdatePart(DynamicCombinedObjectPartInternal part)
		{
			_movedParts.Add(part);
			_movedPartsData.Add(part.CreateMoveInfo());
			base.enabled = true;
		}

		public void Destroy(DynamicCombinedObjectPart dynamicPart, CombinedObjectPart basePart)
		{
			if (_parts.Remove(dynamicPart))
			{
				basePart.Destroy();
				base.enabled = true;
			}
			if (_parts.Count == 0)
			{
				UnregisterDrawObject();
			}
		}
	}
}
