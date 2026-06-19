using UnityEngine;

public class UICoreBase : MonoBehaviour
{
	private ScalableUIContainer.LoadCallback callback;

	protected ElementStatus currentStatus = ElementStatus.UNLOADED;

	protected Inchworm inchwormRef;

	private void Awake()
	{
		AwakeBehavior();
	}

	protected virtual void AwakeBehavior()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	public virtual void Load(ScalableUIContainer.LoadCallback loadCallback = null)
	{
		currentStatus = ElementStatus.LOADING;
		callback = loadCallback;
	}

	public virtual void Unload(ScalableUIContainer.LoadCallback unloadCallback)
	{
		currentStatus = ElementStatus.UNLOADING;
		callback = unloadCallback;
	}

	protected void AllElementsLoadedCallback()
	{
		currentStatus = ElementStatus.LOADED;
		if (callback != null)
		{
			callback();
			callback = null;
		}
	}

	protected void AllElementsUnloadedCallback()
	{
		currentStatus = ElementStatus.UNLOADED;
		if (callback != null)
		{
			callback();
			callback = null;
		}
	}
}
