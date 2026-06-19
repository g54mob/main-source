using System.Collections.Generic;
using DG.Tweening;
using FMODUnity;
using OUSystems.Basics.DataStructures;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireBuildingAnimator : MonoBehaviour
{
	[SerializeField]
	private Crafter _crafter;

	[SerializeField]
	private GameObject _craftingEffectsParent;

	[SerializeField]
	private List<ParticleSystem> _particles;

	[SerializeField]
	private Light2D _light;

	private float _lightIntensity;

	[SerializeField]
	private float _fadeDuration;

	private Tween _lightTween;

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

	public void OnUpdateIsCrafting(ValueUpdateData<bool> update)
	{
	}

	public void OnStartCrafting()
	{
	}

	public void OnStopCrafting()
	{
	}
}
