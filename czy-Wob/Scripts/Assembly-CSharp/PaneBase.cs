using UnityEngine;

public class PaneBase : MonoBehaviour
{
	public enum PaneState
	{
		LOADING = 0,
		UNLOADING = 1,
		LOADED = 2,
		UNLOADED = 3
	}

	public delegate void PaneCallback();

	public PaneState currentState = PaneState.UNLOADED;

	public PaneCallback currentCallback;

	protected Vector3 originalPosition;

	protected Segment currentEase;

	protected Inchworm inchwormRef;

	private void Awake()
	{
		AwakeBehavior();
		originalPosition = base.transform.localPosition;
	}

	protected virtual void AwakeBehavior()
	{
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	public virtual void ForceImmediateUnload()
	{
		CancelCurrentEase();
		currentState = PaneState.UNLOADED;
		currentCallback = null;
	}

	public virtual void RequestLoad(PaneCallback loadCallback)
	{
		if (currentState != PaneState.UNLOADED)
		{
			Debug.LogError("Cannot load a pane that is not unloaded.");
			return;
		}
		currentCallback = loadCallback;
		currentState = PaneState.LOADING;
		LoadBehavior();
	}

	public virtual void RequestUnload(PaneCallback unloadCallback)
	{
		if (currentState != PaneState.LOADED)
		{
			Debug.LogError("Cannot unload a pane that is not loaded.");
			return;
		}
		currentCallback = unloadCallback;
		currentState = PaneState.UNLOADING;
		UnloadBehavior();
	}

	protected virtual void LoadBehavior()
	{
		OnLoadComplete();
	}

	protected virtual void UnloadBehavior()
	{
		OnUnloadComplete();
	}

	protected virtual void OnLoadComplete()
	{
		currentState = PaneState.LOADED;
		CallCallback();
	}

	protected virtual void OnUnloadComplete()
	{
		currentState = PaneState.UNLOADED;
		CallCallback();
		base.transform.localPosition = originalPosition;
		base.gameObject.SetActive(value: false);
	}

	protected void CancelCurrentEase()
	{
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase, callCallback: true);
		}
	}

	private void CallCallback()
	{
		PaneCallback paneCallback = currentCallback;
		if (paneCallback != null)
		{
			currentCallback = null;
			paneCallback();
		}
	}
}
