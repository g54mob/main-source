using UnityEngine;

public class ScalableUIContainerLoader : MonoBehaviour
{
	public ScalableUIContainer container;

	public bool customZPos;

	public float zPos;

	private ScalableUIContainer.LoadCallback callback;

	private ElementStatus currentStatus = ElementStatus.UNLOADED;

	private void Update()
	{
		if (currentStatus == ElementStatus.LOADED)
		{
			container.CheckResize();
		}
	}

	public GameObject GetMainUIObject()
	{
		return container.GetMainUIObject();
	}

	public void LoadContainer(ScalableUIContainer.LoadCallback loadCallback = null, ScalableUIContainer.LoadCallback mainUIObjectCreatedCallback = null)
	{
		if (currentStatus != ElementStatus.UNLOADED)
		{
			Debug.LogError("Cannot load a scalable UI Container before it's been unloaded.");
			return;
		}
		callback = loadCallback;
		currentStatus = ElementStatus.LOADING;
		if (customZPos)
		{
			container.SetBaseZPosOffset(zPos);
		}
		container.Load(ContainerLoadedCallback, mainUIObjectCreatedCallback);
	}

	public void UnloadContainer(ScalableUIContainer.LoadCallback unloadCallback = null)
	{
		if (currentStatus != ElementStatus.LOADED)
		{
			Debug.LogError("Cannot unload a scalable UI Container before it's been loaded.");
			return;
		}
		callback = unloadCallback;
		currentStatus = ElementStatus.UNLOADING;
		container.Unload(ContainerUnloadedCallback);
	}

	private void ContainerLoadedCallback()
	{
		currentStatus = ElementStatus.LOADED;
		CallCallback();
	}

	private void ContainerUnloadedCallback()
	{
		currentStatus = ElementStatus.UNLOADED;
		CallCallback();
	}

	private void CallCallback()
	{
		if (callback != null)
		{
			ScalableUIContainer.LoadCallback loadCallback = callback;
			callback = null;
			loadCallback();
		}
	}
}
