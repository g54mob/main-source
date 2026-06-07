using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyHitVFX : MonoBehaviour
{
	[SerializeField]
	private List<Renderer> enemyRenderers;

	[SerializeField]
	private Transform punchTransform;

	private CombatComponent combatComponent;

	private Tween punchTween;

	private void AutoSetRenderers()
	{
		enemyRenderers = new List<Renderer>();
		enemyRenderers.AddRange(GetComponentsInChildren<SkinnedMeshRenderer>());
		enemyRenderers.AddRange(GetComponentsInChildren<MeshRenderer>());
	}

	private void Awake()
	{
		combatComponent = GetComponent<CombatComponent>();
	}

	private void Start()
	{
		combatComponent.onDamageTaken += OnDamageTaken;
		combatComponent.onDie += OnDie;
	}

	private void OnDie(CombatComponent combatComponent)
	{
		if (punchTween != null && punchTween.IsActive())
		{
			punchTween.Kill();
		}
	}

	private void OnDamageTaken(GameObject cuaser, float damageTaken)
	{
		if (damageTaken > 1f)
		{
			PlayHitVFX();
		}
	}

	private void PlayHitVFX()
	{
		for (int i = 0; i < enemyRenderers.Count; i++)
		{
			enemyRenderers[i].material.SetFloat("_HitStartTime", Time.time);
		}
		if ((bool)punchTransform)
		{
			if (punchTween != null)
			{
				punchTween.Complete();
			}
			punchTween = punchTransform.DOPunchScale(-Vector3.one * 0.1f, 0.5f, 8, 0.5f);
		}
	}
}
