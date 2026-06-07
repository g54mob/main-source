using System;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

namespace Deform
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[HelpURL("https://github.com/keenanwoodall/Deform/wiki/Deformable")]
	public class Deformable : MonoBehaviour, IDeformable
	{
		public bool assignOriginalMeshOnDisable = true;

		public Action<MeshData> DynamicMeshUpdated;

		[SerializeField]
		[HideInInspector]
		protected UpdateMode updateMode;

		[SerializeField]
		[HideInInspector]
		protected CullingMode cullingMode = CullingMode.DontUpdate;

		[SerializeField]
		[HideInInspector]
		protected StripMode stripMode = StripMode.DontStrip;

		[SerializeField]
		[HideInInspector]
		protected NormalsRecalculation normalsRecalculation;

		[SerializeField]
		[HideInInspector]
		protected BoundsRecalculation boundsRecalculation;

		[SerializeField]
		[HideInInspector]
		protected ColliderRecalculation colliderRecalculation;

		[SerializeField]
		[HideInInspector]
		protected MeshCollider meshCollider;

		[SerializeField]
		[HideInInspector]
		protected MeshData data;

		[SerializeField]
		[HideInInspector]
		protected List<DeformerElement> deformerElements = new List<DeformerElement>();

		[SerializeField]
		[HideInInspector]
		protected Bounds customBounds = new Bounds(Vector3.zero, Vector3.one * 0.5f);

		protected DeformableManager manager;

		protected JobHandle handle;

		protected DataFlags currentModifiedDataFlags;

		protected DataFlags lastModifiedDataFlags;

		public UpdateMode UpdateMode
		{
			get
			{
				return updateMode;
			}
			set
			{
				switch (value)
				{
				case UpdateMode.Auto:
					if (Application.isPlaying)
					{
						Manager = DeformableManager.GetDefaultManager(createIfMissing: true);
					}
					break;
				case UpdateMode.Stop:
					Complete();
					data.ResetData(DataFlags.All);
					ResetMesh();
					break;
				case UpdateMode.Custom:
					Manager = null;
					Complete();
					break;
				}
				updateMode = value;
			}
		}

		public CullingMode CullingMode
		{
			get
			{
				return cullingMode;
			}
			set
			{
				cullingMode = value;
			}
		}

		public NormalsRecalculation NormalsRecalculation
		{
			get
			{
				return normalsRecalculation;
			}
			set
			{
				normalsRecalculation = value;
			}
		}

		public BoundsRecalculation BoundsRecalculation
		{
			get
			{
				return boundsRecalculation;
			}
			set
			{
				boundsRecalculation = value;
			}
		}

		public ColliderRecalculation ColliderRecalculation
		{
			get
			{
				return colliderRecalculation;
			}
			set
			{
				colliderRecalculation = value;
			}
		}

		public MeshCollider MeshCollider
		{
			get
			{
				return meshCollider;
			}
			set
			{
				meshCollider = value;
			}
		}

		public virtual StripMode StripMode
		{
			get
			{
				return stripMode;
			}
			set
			{
				stripMode = value;
			}
		}

		public List<DeformerElement> DeformerElements
		{
			get
			{
				return deformerElements;
			}
			set
			{
				deformerElements = value;
			}
		}

		public Bounds CustomBounds
		{
			get
			{
				return customBounds;
			}
			set
			{
				customBounds = value;
			}
		}

		public DeformableManager Manager
		{
			get
			{
				return manager;
			}
			set
			{
				if (manager != null)
				{
					manager.RemoveDeformable(this);
				}
				manager = value;
				if (manager != null)
				{
					manager.AddDeformable(this);
				}
			}
		}

		public DataFlags ModifiedDataFlags => lastModifiedDataFlags;

		public virtual UpdateFrequency UpdateFrequency => UpdateFrequency.Default;

		protected virtual void OnEnable()
		{
			AllocateData();
			if (Application.isPlaying && UpdateMode == UpdateMode.Auto)
			{
				Manager = DeformableManager.GetDefaultManager(createIfMissing: true);
			}
			InitializeData();
		}

		protected virtual void OnDisable()
		{
			Complete();
			DisposeData();
			if (Manager != null)
			{
				Manager.RemoveDeformable(this);
			}
		}

		private void OnBecameVisible()
		{
			if (UpdateMode == UpdateMode.Auto && UpdateFrequency != UpdateFrequency.Immediate)
			{
				DeformableManager deformableManager = manager;
				if ((bool)deformableManager)
				{
					Manager = null;
					Manager = deformableManager;
				}
				else
				{
					Manager = DeformableManager.GetDefaultManager(createIfMissing: true);
				}
			}
		}

		public virtual void AllocateData()
		{
			if (data == null)
			{
				data = new MeshData();
			}
			data.Initialize(base.gameObject);
		}

		public virtual void InitializeData()
		{
		}

		public virtual void DisposeData()
		{
			data.Dispose(assignOriginalMeshOnDisable);
		}

		protected bool IsVisible()
		{
			return data.Target.GetRenderer().isVisible;
		}

		protected bool ShouldCull(bool ignoreCullingMode)
		{
			if (!IsVisible() && !ignoreCullingMode)
			{
				return cullingMode == CullingMode.DontUpdate;
			}
			return false;
		}

		public virtual void PreSchedule(bool ignoreCullingMode)
		{
			if (!CanUpdate() || ShouldCull(ignoreCullingMode))
			{
				return;
			}
			foreach (DeformerElement deformerElement in DeformerElements)
			{
				Deformer component = deformerElement.Component;
				if (component != null && component.CanProcess())
				{
					component.PreProcess();
				}
			}
		}

		public void PreSchedule()
		{
			PreSchedule(ignoreCullingMode: false);
		}

		public virtual JobHandle Schedule(bool ignoreCullingMode, JobHandle dependency = default(JobHandle))
		{
			if (ShouldCull(ignoreCullingMode))
			{
				return dependency;
			}
			if (data.Target.GetGameObject() == null && !data.Initialize(base.gameObject))
			{
				return dependency;
			}
			if (!CanUpdate())
			{
				return dependency;
			}
			handle = dependency;
			if (currentModifiedDataFlags != DataFlags.None)
			{
				ResetDynamicData();
			}
			for (int i = 0; i < deformerElements.Count; i++)
			{
				DeformerElement deformerElement = deformerElements[i];
				Deformer component = deformerElement.Component;
				if (deformerElement.CanProcess())
				{
					if (component.RequiresUpdatedBounds && BoundsRecalculation == BoundsRecalculation.Auto)
					{
						handle = MeshUtils.RecalculateBounds(data.DynamicNative, handle);
						currentModifiedDataFlags |= DataFlags.Bounds;
					}
					handle = component.Process(data, handle);
					currentModifiedDataFlags |= component.DataFlags;
				}
			}
			bool num = (currentModifiedDataFlags | DataFlags.Vertices) > DataFlags.None;
			if (num && NormalsRecalculation == NormalsRecalculation.Auto)
			{
				handle = MeshUtils.RecalculateNormals(data.DynamicNative, handle);
				currentModifiedDataFlags |= DataFlags.Normals;
			}
			if ((num && BoundsRecalculation == BoundsRecalculation.Auto) || BoundsRecalculation == BoundsRecalculation.OnceAtTheEnd)
			{
				handle = MeshUtils.RecalculateBounds(data.DynamicNative, handle);
				currentModifiedDataFlags |= DataFlags.Bounds;
			}
			return handle;
		}

		public JobHandle Schedule(JobHandle dependency = default(JobHandle))
		{
			return Schedule(ignoreCullingMode: false, dependency);
		}

		public virtual void ApplyData(bool ignoreCullingMode)
		{
			if (!ShouldCull(ignoreCullingMode) && CanUpdate())
			{
				data.ApplyData(currentModifiedDataFlags | lastModifiedDataFlags);
				if (BoundsRecalculation == BoundsRecalculation.Custom)
				{
					data.DynamicMesh.bounds = CustomBounds;
				}
				if (ColliderRecalculation == ColliderRecalculation.Auto)
				{
					RecalculateMeshCollider();
				}
				DynamicMeshUpdated?.Invoke(data);
				ResetDynamicData();
			}
		}

		public void ApplyData()
		{
			ApplyData(ignoreCullingMode: false);
		}

		public void ResetMesh()
		{
			data.ApplyOriginalData();
		}

		public void Complete()
		{
			handle.Complete();
		}

		public void ForceImmediateUpdate()
		{
			Complete();
			PreSchedule(ignoreCullingMode: true);
			Schedule(ignoreCullingMode: true).Complete();
			ApplyData(ignoreCullingMode: true);
		}

		protected void ResetDynamicData()
		{
			data.ResetData(currentModifiedDataFlags);
			lastModifiedDataFlags = currentModifiedDataFlags;
			currentModifiedDataFlags = DataFlags.None;
		}

		public void RecalculateMeshCollider()
		{
			if (MeshCollider != null)
			{
				MeshCollider.sharedMesh = null;
				MeshCollider.sharedMesh = GetMesh();
			}
		}

		public bool CanUpdate()
		{
			if (handle.IsCompleted && (UpdateMode == UpdateMode.Auto || UpdateMode == UpdateMode.Custom) && base.isActiveAndEnabled)
			{
				return data.EnsureData();
			}
			return false;
		}

		public void AddDeformer(Deformer deformer, bool active = true)
		{
			DeformerElements.Add(new DeformerElement(deformer, active));
		}

		public void RemoveDeformer(Deformer deformer)
		{
			for (int i = 0; i < DeformerElements.Count; i++)
			{
				if (DeformerElements[i].Component == deformer)
				{
					DeformerElements.RemoveAt(i);
					i--;
				}
			}
		}

		public void ChangeMesh(Mesh mesh)
		{
			Complete();
			data.ChangeMesh(mesh);
		}

		public Mesh GetMesh()
		{
			return data.DynamicMesh;
		}

		public Mesh GetOriginalMesh()
		{
			return data.OriginalMesh;
		}

		public Mesh GetCurrentMesh()
		{
			return data.Target.GetMesh();
		}

		public Renderer GetRenderer()
		{
			return data.Target.GetRenderer();
		}

		public bool HasTarget()
		{
			return data.Target.Exists();
		}
	}
}
