using UnityEngine;

public abstract class VisualEffectBase : MonoBehaviour
{
	private bool isAlreadyInitialized;

	private void Awake()
	{
		if (!isAlreadyInitialized)
		{
			Initialize();
			isAlreadyInitialized = true;
		}
	}

	protected virtual void Update()
	{
	}

	protected abstract void Initialize();

	public virtual void SetVisualEffectsByGameStyleData(GameStylesData gameStylesData)
	{
		if (!isAlreadyInitialized)
		{
			Initialize();
			isAlreadyInitialized = true;
		}
	}
}
