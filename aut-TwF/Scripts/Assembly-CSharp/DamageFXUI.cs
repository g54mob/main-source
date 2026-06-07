using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DamageFXUI : MonoBehaviour
{
	private Image damageFXOverlay;

	private void Awake()
	{
		damageFXOverlay = GetComponent<Image>();
		damageFXOverlay.enabled = false;
		damageFXOverlay.raycastTarget = false;
	}

	private void Start()
	{
		LTFunctionLibrary.GetLTGameManager().PlayerTower.CombatComponent.onDamageTaken += OnPlayerTakesDamage;
	}

	private void OnPlayerTakesDamage(GameObject cuaser, float damageTaken)
	{
		damageFXOverlay.enabled = true;
		damageFXOverlay.DOKill();
		damageFXOverlay.DOFade(1f, 0f);
		TweenerCore<Color, Color, ColorOptions> tweenerCore = damageFXOverlay.DOFade(0f, 0.3f);
		tweenerCore.onComplete = (TweenCallback)Delegate.Combine(tweenerCore.onComplete, (TweenCallback)delegate
		{
			damageFXOverlay.enabled = false;
		});
	}
}
