using System.Collections.Generic;
using UnityEngine;

public class UIElementContainer
{
	public delegate void LoadCallback();

	private LoadCallback loadedCallback;

	private LoadCallback unloadedCallback;

	private Vector2 size;

	private Vector2 pos;

	private float additionalZOffset;

	private Vector2 positionOffset;

	private float baseZSize = 0.25f;

	private float baseZPos = 5f;

	private ElementStatus currentStatus = ElementStatus.UNLOADED;

	private int loadedElements;

	private int loadedContainers;

	private UIElementContainer parentContainer;

	private List<UIElementBase> elements = new List<UIElementBase>();

	private List<UIElementContainer> containers = new List<UIElementContainer>();

	public UIElementContainer(Vector2 size, Vector2 pos, float additionalZOffset = 0f)
	{
		this.size = size;
		this.pos = pos;
		this.additionalZOffset = additionalZOffset;
	}

	public void Load(LoadCallback callback)
	{
		if (currentStatus != ElementStatus.UNLOADED)
		{
			Debug.LogError("Cannot load an element container if it isn't unloaded.");
			return;
		}
		currentStatus = ElementStatus.LOADING;
		loadedCallback = callback;
		LoadElements();
	}

	public void Unload(LoadCallback callback)
	{
		if (currentStatus != ElementStatus.LOADED)
		{
			Debug.LogError("Cannot unload an element container if it isn't loaded.");
			return;
		}
		currentStatus = ElementStatus.UNLOADING;
		unloadedCallback = callback;
		UnloadContainers();
	}

	public void AddElement(UIElementBase newElement)
	{
		if (currentStatus != ElementStatus.UNLOADED)
		{
			Debug.LogError("Attempting to add an element to an already active container. It won't load.");
		}
		elements.Add(newElement);
	}

	public void AddElementContainer(UIElementContainer newContainer)
	{
		if (currentStatus != ElementStatus.UNLOADED)
		{
			Debug.LogError("Attempting to add an element container to an already active container. It won't load.");
		}
		newContainer.SetParentContainer(this);
		containers.Add(newContainer);
	}

	public void SetParentContainer(UIElementContainer parent)
	{
		parentContainer = parent;
	}

	public Vector2 GetContainerSizePercentage()
	{
		Vector2 vector = Vector2.one;
		if (parentContainer != null)
		{
			vector = parentContainer.GetContainerSizePercentage();
		}
		return new Vector2(size.x * vector.x, size.y * vector.y);
	}

	public Vector3 GetElementSize(Vector2 elementSize)
	{
		Vector3 maxSize = GetMaxSize();
		return (Vector2)new Vector3(maxSize.x * elementSize.x, maxSize.y * elementSize.y, baseZSize);
	}

	public Vector3 GetMaxSize()
	{
		Vector2 aspectSize = GetAspectSize();
		Vector2 containerSizePercentage = GetContainerSizePercentage();
		return new Vector3(aspectSize.x * containerSizePercentage.x, aspectSize.y * containerSizePercentage.y, baseZSize);
	}

	public Vector2 GetAspectSize()
	{
		Camera globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Camera>(GlobalObject.UI_CAMERA);
		Vector2 absoluteScreenSize = GetAbsoluteScreenSize();
		float num = absoluteScreenSize.x / absoluteScreenSize.y;
		float num2 = globalComponent.orthographicSize * 2f;
		return new Vector2(num * num2, num2);
	}

	public Vector2 GetScaledAspectSize()
	{
		if (parentContainer == null)
		{
			return GetAspectSize();
		}
		Vector2 aspectSize = GetAspectSize();
		Vector2 containerSizePercentage = GetContainerSizePercentage();
		return new Vector2(aspectSize.x * containerSizePercentage.x, aspectSize.y * containerSizePercentage.y);
	}

	public Vector2 GetParentPosOffset()
	{
		if (parentContainer == null)
		{
			return Vector2.zero;
		}
		return parentContainer.GetPositionOffset();
	}

	public Vector3 GetElementPos(Vector2 elementPos, Vector2 elementSize, float childZOffset)
	{
		Vector3 position = ObjectRegistration.GetRegistrationScript().GetGlobalObject(GlobalObject.UI_CAMERA).transform.position;
		Vector3 vector = new Vector3(position.x, position.y, position.z + baseZPos + additionalZOffset + childZOffset);
		Vector3 vector2 = GetParentPosOffset();
		Vector2 aspectSize = GetAspectSize();
		Vector2 vector3 = GetElementSize(elementSize);
		Vector3 vector4 = new Vector3((aspectSize.x - vector3.x) / -2f, (aspectSize.y - vector3.y) / 2f, 0f);
		Vector2 vector5 = new Vector2((1f - size.x) * aspectSize.x, (1f - size.y) * aspectSize.y);
		Vector3 vector6 = new Vector3(vector5.x * pos.x, vector5.y * (0f - pos.y), 0f);
		positionOffset = vector6;
		Vector2 scaledAspectSize = GetScaledAspectSize();
		Vector2 vector7 = new Vector2((1f - elementSize.x) * scaledAspectSize.x, (1f - elementSize.y) * scaledAspectSize.y);
		Vector3 vector8 = new Vector3(vector7.x * elementPos.x, vector7.y * (0f - elementPos.y), 0f);
		return vector + vector2 + vector4 + vector6 + vector8;
	}

	public Vector2 GetPositionOffset()
	{
		return positionOffset;
	}

	private Vector2 GetAbsoluteScreenSize()
	{
		return new Vector2(Screen.width, Screen.height);
	}

	private void LoadElements()
	{
		loadedElements = 0;
		for (int i = 0; i < elements.Count; i++)
		{
			elements[i].LoadElement(ElementLoadedCallback);
		}
		if (elements.Count == 0)
		{
			ElementLoadedCallback();
		}
	}

	private void UnloadElements()
	{
		for (int i = 0; i < elements.Count; i++)
		{
			elements[i].UnloadElement(ElementUnloadedCallback);
		}
		if (elements.Count == 0)
		{
			ElementLoadedCallback();
		}
	}

	private void ElementLoadedCallback()
	{
		loadedElements++;
		if (loadedElements >= elements.Count)
		{
			AllElementsLoadedCallback();
		}
	}

	private void ElementUnloadedCallback()
	{
		loadedElements--;
		if (loadedElements <= 0)
		{
			AllElementsUnloadedCallback();
		}
	}

	private void AllElementsLoadedCallback()
	{
		LoadContainers();
	}

	private void LoadContainers()
	{
		loadedContainers = 0;
		for (int i = 0; i < containers.Count; i++)
		{
			containers[i].Load(ContainerLoadedCallback);
		}
		if (containers.Count == 0)
		{
			ContainerLoadedCallback();
		}
	}

	private void UnloadContainers()
	{
		for (int i = 0; i < containers.Count; i++)
		{
			containers[i].Unload(ContainerUnloadedCallback);
		}
		if (containers.Count == 0)
		{
			ContainerUnloadedCallback();
		}
	}

	private void ContainerLoadedCallback()
	{
		loadedContainers++;
		if (loadedContainers >= containers.Count)
		{
			AllContainersLoadedCallback();
		}
	}

	private void AllContainersLoadedCallback()
	{
		currentStatus = ElementStatus.LOADED;
		loadedCallback();
		loadedCallback = null;
	}

	private void AllElementsUnloadedCallback()
	{
		currentStatus = ElementStatus.UNLOADED;
		elements.Clear();
		unloadedCallback();
		unloadedCallback = null;
	}

	private void ContainerUnloadedCallback()
	{
		loadedContainers--;
		if (loadedContainers <= 0)
		{
			AllContainersUnloadedCallback();
		}
	}

	private void AllContainersUnloadedCallback()
	{
		containers.Clear();
		UnloadElements();
	}
}
