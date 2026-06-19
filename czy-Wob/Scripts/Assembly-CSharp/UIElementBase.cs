using UnityEngine;

public class UIElementBase
{
	private ElementStatus currentStatus = ElementStatus.UNLOADED;

	private UIElementContainer.LoadCallback loadedCallback;

	private UIElementContainer.LoadCallback unloadedCallback;

	private UIElementContainer parentContainer;

	private GraphicType elementType;

	private Vector2 size;

	private Vector3 pos;

	private Color color;

	private float additionalZOffset;

	private float scaleInTime;

	private float scaleOutTime;

	private GameObject graphic;

	public UIElementBase(UIElementContainer parentContainer, GraphicType elementType, Vector2 size, Vector2 pos, Color color, float additionalZOffset = 0f, float scaleInTime = -1f, float scaleOutTime = -1f)
	{
		this.parentContainer = parentContainer;
		this.elementType = elementType;
		this.size = size;
		this.pos = pos;
		this.color = color;
		this.additionalZOffset = additionalZOffset;
		this.scaleInTime = scaleInTime;
		this.scaleOutTime = scaleOutTime;
		this.parentContainer.AddElement(this);
	}

	public virtual void LoadElement(UIElementContainer.LoadCallback callback)
	{
		if (currentStatus != ElementStatus.UNLOADED)
		{
			Debug.LogError("Cannot load a UI element if it isn't yet unloaded.");
			return;
		}
		currentStatus = ElementStatus.LOADING;
		loadedCallback = callback;
		graphic = UIElementInfo.GetObjectForElementType(elementType);
		graphic.name = "UI Element";
		graphic.transform.localScale = parentContainer.GetElementSize(size);
		graphic.transform.position = parentContainer.GetElementPos(pos, size, additionalZOffset);
		Material material = graphic.GetComponent<MeshRenderer>().material;
		material.color = color;
		material.shader = Shader.Find("Unlit/Color");
		graphic.GetComponent<MeshRenderer>().material = material;
		ScaleIn();
	}

	public virtual void UnloadElement(UIElementContainer.LoadCallback callback)
	{
		if (currentStatus != ElementStatus.LOADED)
		{
			Debug.LogError("Cannot unload a UI element if it isn't yet loaded.");
			return;
		}
		currentStatus = ElementStatus.UNLOADING;
		unloadedCallback = callback;
		ScaleOut();
	}

	private void ScaleIn()
	{
		if (scaleInTime == -1f)
		{
			OnLoadedCallback();
			return;
		}
		Inchworm globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		Vector3 localScale = graphic.transform.localScale;
		graphic.transform.localScale = Vector3.zero;
		globalComponent.RequestEaseToScale(graphic, localScale, scaleInTime, Inchworm.EaseStyle.QuadraticOut, OnLoadedCallback);
	}

	private void ScaleOut()
	{
		if (scaleOutTime == -1f)
		{
			OnUnloadedCallback();
		}
		else
		{
			ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM).RequestEaseToScale(graphic, Vector3.zero, scaleOutTime, Inchworm.EaseStyle.QuadraticIn, OnUnloadedCallback);
		}
	}

	private void OnLoadedCallback()
	{
		currentStatus = ElementStatus.LOADED;
		loadedCallback();
		loadedCallback = null;
	}

	private void OnUnloadedCallback()
	{
		currentStatus = ElementStatus.UNLOADED;
		Object.Destroy(graphic);
		graphic = null;
		unloadedCallback();
		unloadedCallback = null;
	}
}
