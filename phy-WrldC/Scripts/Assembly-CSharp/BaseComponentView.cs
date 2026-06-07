using System.Collections.Generic;
using UnityEngine;

public abstract class BaseComponentView : MonoBehaviour
{
	private bool isAlreadyInitialized;

	private bool isAlreadyGizmosInitialized;

	private bool isAlreadyModelInitialized;

	protected List<Rigidbody> allComponentRigidbodies;

	public BlockBodyView BlockBodyView { get; private set; }

	public ComponentModel ComponentModel { get; set; }

	protected GameObject GizmosFolder { get; private set; }

	public bool IsBodiesSplited { get; protected set; }

	public void Initialize(Properties properties)
	{
		if (!isAlreadyInitialized)
		{
			allComponentRigidbodies = new List<Rigidbody>();
			InternalInitialize(properties);
			isAlreadyInitialized = true;
		}
		IsBodiesSplited = false;
		SetInitializeConfiguration(properties);
	}

	protected virtual void InternalInitialize(Properties properties)
	{
		BlockBodyView = GetComponent<BlockBodyView>();
	}

	protected virtual void SetInitializeConfiguration(Properties properties)
	{
	}

	public virtual void SetUpToAction()
	{
		SetGizmosVisibility(isVisible: false);
		SetComponentActive(isActive: true);
	}

	public virtual void SetComponentActive(bool isActive)
	{
		base.enabled = isActive;
	}

	public virtual void SetBlockDestroyed()
	{
		base.enabled = false;
	}

	public void ResetComponent()
	{
		SetComponentActive(isActive: false);
		if (isAlreadyInitialized)
		{
			InternalResetComponent();
		}
		if (isAlreadyGizmosInitialized)
		{
			InternalResetGizmos();
		}
		if (isAlreadyModelInitialized)
		{
			InternalResetModel();
		}
	}

	protected virtual void InternalResetComponent()
	{
	}

	public void InitializeGizmos<T>(T componentModel) where T : ComponentModel
	{
		if (!isAlreadyGizmosInitialized)
		{
			InternalInitializeGizmos(componentModel);
			isAlreadyGizmosInitialized = true;
		}
		SetGizmosConfiguration(componentModel);
	}

	protected virtual void InternalInitializeGizmos<T>(T componentModel) where T : ComponentModel
	{
		GizmosFolder = new GameObject("GizmosFolder");
		GizmosFolder.transform.SetParent(base.transform, worldPositionStays: false);
		if (BlockBodyView == null)
		{
			BlockBodyView = GetComponent<BlockBodyView>();
		}
	}

	protected virtual void SetGizmosConfiguration<T>(T componentModel) where T : ComponentModel
	{
	}

	protected virtual void InternalResetGizmos()
	{
	}

	protected GameObject InstantiateGizmoObject(string gizmoPrefabName)
	{
		GameObject obj = Object.Instantiate(Resources.Load<GameObject>("Component Gizmos/" + gizmoPrefabName));
		obj.transform.SetParent(GizmosFolder.transform, worldPositionStays: false);
		return obj;
	}

	public void SetGizmosVisibility(bool isVisible)
	{
		if (GizmosFolder != null)
		{
			GizmosFolder.SetActive(isVisible);
		}
	}

	public void SetGizmosLayer(int layer)
	{
		if (GizmosFolder != null)
		{
			GizmosFolder.SetLayersRecursively(layer);
		}
	}

	public void InitializeModel()
	{
		if (!isAlreadyModelInitialized)
		{
			InternalInitializeModel();
			isAlreadyModelInitialized = true;
		}
		SetModelConfiguration();
	}

	protected virtual void InternalInitializeModel()
	{
		if (BlockBodyView == null)
		{
			BlockBodyView = GetComponent<BlockBodyView>();
		}
	}

	protected virtual void SetModelConfiguration()
	{
	}

	protected virtual void InternalResetModel()
	{
	}

	public abstract string GetComponentName();

	public virtual ComponentType GetComponentType()
	{
		return ComponentType.Other;
	}

	public ICollection<Rigidbody> GetAllComponentRigidbodies()
	{
		return allComponentRigidbodies;
	}
}
