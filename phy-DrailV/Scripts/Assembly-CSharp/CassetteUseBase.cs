using System.Collections;
using DV.CabControls;
using DV.Interaction;
using DV.Utils;
using UnityEngine;

public abstract class CassetteUseBase : MonoBehaviour, IItemUse
{
	protected Cassette cassette;

	protected ItemBase cassetteItem;

	protected bool initialized;

	private Coroutine initCoro;

	protected abstract void ModeSpecificInitialize();

	private void Awake()
	{
		cassette = GetComponent<Cassette>();
		initCoro = SingletonBehaviour<CoroutineManager>.Instance.Run(Initialize());
	}

	protected virtual void OnDestroy()
	{
		if (!UnloadWatcher.isUnloading && initCoro != null)
		{
			SingletonBehaviour<CoroutineManager>.Instance.Stop(initCoro);
		}
	}

	private IEnumerator Initialize()
	{
		yield return null;
		cassetteItem = GetComponent<ItemBase>();
		ModeSpecificInitialize();
		initialized = true;
		initCoro = null;
	}

	public bool HandleHover(ItemUseTarget target)
	{
		if (VRManager.IsVREnabled())
		{
			return false;
		}
		SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.InsertCassette);
		return true;
	}

	public abstract bool HandleUse(ItemUseTarget target);

	public bool IsHoverCompatible(ItemUseTarget target)
	{
		return IsUseCompatible(target);
	}

	public bool IsUseCompatible(ItemUseTarget target)
	{
		BoomboxInteractionController componentInParent = target.GetComponentInParent<BoomboxInteractionController>();
		if (componentInParent == null)
		{
			return false;
		}
		if (componentInParent.HasDoorOpen)
		{
			return !componentInParent.HasCassetteInserted;
		}
		return false;
	}
}
