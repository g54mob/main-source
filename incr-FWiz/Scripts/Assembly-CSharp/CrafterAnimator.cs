using System.Collections.Generic;
using DG.Tweening;
using FMODUnity;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public class CrafterAnimator : MonoBehaviour
{
	[SerializeField]
	private Crafter _crafter;

	[SerializeField]
	private List<GameObject> _activateWhileCrafting;

	[SerializeField]
	private List<GameObject> _deactivateWhileCrafting;

	[SerializeField]
	private List<ParticleSystem> _particles;

	[SerializeField]
	private EventReference _onStartCraftingSound;

	[SerializeField]
	private CustomEventEmitter _craftingSoundLoopEmitter;

	[SerializeField]
	private float _craftingSoundLoopFadeDuration;

	private Tween _craftingLoopSoundTween;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public virtual void OnUpdateIsCrafting(ValueUpdateData<bool> update)
	{
	}

	public virtual void OnStartCrafting()
	{
	}

	public void OnStopCrafting()
	{
	}
}
