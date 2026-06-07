using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	[DisallowMultipleComponent]
	public abstract class MeshFusionSource : MonoBehaviour
	{
		private RuntimeMeshFusion _controller;

		private int _combinedSourcesCount;

		private int _failedSourcesCount;

		private int _totalSourcesCount;

		[field: SerializeField]
		public SourceCombineStatus CombineStatus { get; private set; }

		[field: SerializeField]
		public int ControllerIndex { get; set; }

		[field: SerializeField]
		[field: HideInInspector]
		public bool CombineAtStart { get; set; } = true;

		[field: SerializeField]
		[field: HideInInspector]
		public CombineErrorStrategy CombineErrorStrategy { get; set; }

		[field: SerializeField]
		public AfterCombineAction AfterCombineAction { get; set; }

		[field: SerializeField]
		public bool IsIncompatible { get; private set; }

		[field: SerializeField]
		public string IncompatibilityReason { get; private set; }

		[field: SerializeField]
		public bool HasCombineErrors { get; private set; }

		[field: SerializeField]
		public string CombineErrors { get; private set; }

		public event Action<MeshFusionSource, IEnumerable<ICombinedObjectPart>> onCombineFinished;

		private void Reset()
		{
			CheckCompatibility();
		}

		private void Start()
		{
			if (CombineAtStart)
			{
				AssignToController();
			}
		}

		private void OnDestroy()
		{
			Unfreeze();
		}

		public void Unfreeze()
		{
			if (CombineStatus == SourceCombineStatus.AssignedToController)
			{
				UnassignFromController();
			}
			ClearSourcesAndUnsubscribe();
		}

		public abstract bool TryGetBounds(ref Bounds bounds);

		public bool CheckCompatibility()
		{
			try
			{
				string incompatibilityReason;
				bool flag = CheckCompatibilityAndGetComponents(out incompatibilityReason);
				IsIncompatible = !flag;
				IncompatibilityReason = incompatibilityReason;
				return flag;
			}
			catch (Exception ex)
			{
				IsIncompatible = true;
				IncompatibilityReason += $"\n{ex.Message}{ex.StackTrace}";
				return false;
			}
		}

		public bool AssignToController()
		{
			try
			{
				if (CombineStatus != SourceCombineStatus.NotCombined)
				{
					return false;
				}
				if (!CheckCompatibility())
				{
					return false;
				}
				_controller = RuntimeMeshFusion.FindByIndex(ControllerIndex);
				if (_controller == null)
				{
					throw new NullReferenceException("RuntimeMeshFusion with index " + ControllerIndex + " not found");
				}
				CreateSourcesAndSubscribe();
				HasCombineErrors = false;
				CombineErrors = "";
				_combinedSourcesCount = 0;
				_failedSourcesCount = 0;
				_totalSourcesCount = 0;
				foreach (ICombineSource combineSource in GetCombineSources())
				{
					_totalSourcesCount++;
					_controller.AddSource(combineSource);
				}
				CombineStatus = SourceCombineStatus.AssignedToController;
				return true;
			}
			catch (Exception ex)
			{
				HasCombineErrors = true;
				CombineErrors += $"\n{ex.Message}\n{ex.StackTrace}";
				UnassignFromController();
				CombineStatus = SourceCombineStatus.FailedToCombine;
				return false;
			}
		}

		public void UndoCombine()
		{
			try
			{
				foreach (ICombinedObjectPart combinedPart in GetCombinedParts())
				{
					combinedPart.Destroy();
				}
				foreach (ICombineSource combineSource in GetCombineSources())
				{
					combineSource.onCombined += delegate(ICombinedObject root, ICombinedObjectPart part)
					{
						part.Destroy();
					};
				}
				UnassignFromController();
				ClearSourcesAndUnsubscribe();
				ClearParts();
				_combinedSourcesCount = 0;
				_failedSourcesCount = 0;
				ToggleComponents(enabled: true);
				CombineStatus = SourceCombineStatus.NotCombined;
			}
			catch (Exception ex)
			{
				HasCombineErrors = true;
				CombineErrors += $"\n{ex.Message}\n{ex.StackTrace}";
				CombineStatus = SourceCombineStatus.FailedToCombine;
			}
		}

		private void CreateSourcesAndSubscribe()
		{
			CreateSources();
			foreach (ICombineSource combineSource in GetCombineSources())
			{
				combineSource.onCombined += OnSourceCombinedHandler;
				combineSource.onCombineError += OnCombineErrorHandler;
				combineSource.onCombineFailed += OnFailedCombineSourceHandler;
			}
		}

		private void ClearSourcesAndUnsubscribe()
		{
			foreach (ICombineSource combineSource in GetCombineSources())
			{
				combineSource.onCombined -= OnSourceCombinedHandler;
				combineSource.onCombineError -= OnCombineErrorHandler;
				combineSource.onCombineFailed -= OnFailedCombineSourceHandler;
			}
			ClearSources();
		}

		private void UnassignFromController()
		{
			if (_controller != null)
			{
				foreach (ICombineSource combineSource in GetCombineSources())
				{
					_controller.RemoveSource(combineSource);
				}
			}
			_controller = null;
		}

		private void OnSourceCombinedHandler(ICombinedObject root, ICombinedObjectPart part)
		{
			CombineStatus = SourceCombineStatus.CombinedPartially;
			_combinedSourcesCount++;
			OnSourceCombinedInternal(root, part);
			if (_combinedSourcesCount + _failedSourcesCount == _totalSourcesCount)
			{
				OnCombineFinishedHandler();
			}
		}

		private void OnCombineErrorHandler(ICombinedObject root, string errorMessage)
		{
			HasCombineErrors = true;
			CombineErrors = CombineErrors + errorMessage + "\n";
			OnCombineErrorInternal(root, errorMessage);
			if (CombineErrorStrategy == CombineErrorStrategy.UndoCombining)
			{
				UndoCombine();
			}
		}

		private void OnFailedCombineSourceHandler(ICombinedObject root)
		{
			_failedSourcesCount++;
			OnFailedCombineSourceInternal(root);
			if (_combinedSourcesCount + _failedSourcesCount == _totalSourcesCount)
			{
				OnCombineFinishedHandler();
			}
		}

		private void OnCombineFinishedHandler()
		{
			ClearSourcesAndUnsubscribe();
			if (_combinedSourcesCount == _totalSourcesCount)
			{
				CombineStatus = SourceCombineStatus.Combined;
			}
			else if (_failedSourcesCount == _totalSourcesCount)
			{
				CombineStatus = SourceCombineStatus.FailedToCombine;
				return;
			}
			OnCombineFinishedInternal();
			this.onCombineFinished?.Invoke(this, GetCombinedParts());
			if (AfterCombineAction == AfterCombineAction.DisableComponents)
			{
				ToggleComponents(enabled: false);
			}
			else if (AfterCombineAction == AfterCombineAction.DestroyGameObject)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		protected virtual void OnSourceCombinedInternal(ICombinedObject root, ICombinedObjectPart part)
		{
		}

		protected virtual void OnCombineErrorInternal(ICombinedObject root, string errorMessage)
		{
		}

		protected virtual void OnFailedCombineSourceInternal(ICombinedObject root)
		{
		}

		protected virtual void OnCombineFinishedInternal()
		{
		}

		protected bool CanCreateCombineSource(GameObject go, ref string incompatibilityReason, ref MeshRenderer renderer, ref MeshFilter filter, ref Mesh mesh)
		{
			if (renderer == null)
			{
				renderer = go.GetComponent<MeshRenderer>();
			}
			if (renderer == null)
			{
				incompatibilityReason = "MeshRenderer not found";
				return false;
			}
			if (renderer.isPartOfStaticBatch)
			{
				incompatibilityReason = "MeshRenderer is PartOfStaticBatching\nDisable Static Batching";
				return false;
			}
			if (filter == null)
			{
				filter = go.GetComponent<MeshFilter>();
			}
			if (filter == null)
			{
				incompatibilityReason = "MeshFilter not found";
				return false;
			}
			mesh = filter.sharedMesh;
			if (mesh == null)
			{
				incompatibilityReason = "Mesh not found";
				return false;
			}
			if (!mesh.isReadable)
			{
				incompatibilityReason = "Mesh is not readable. Enable Read/Write in import settings";
				return false;
			}
			if (mesh.subMeshCount != renderer.sharedMaterials.Length)
			{
				incompatibilityReason = "Submesh count and Materials count isn't equal";
				return false;
			}
			incompatibilityReason = "";
			return true;
		}

		protected abstract bool CheckCompatibilityAndGetComponents(out string incompatibilityReason);

		protected abstract void CreateSources();

		protected abstract void ClearSources();

		protected abstract void ClearParts();

		protected abstract IEnumerable<ICombineSource> GetCombineSources();

		protected abstract IEnumerable<ICombinedObjectPart> GetCombinedParts();

		protected abstract void ToggleComponents(bool enabled);
	}
}
