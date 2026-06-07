using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class AreaEffect : MonoBehaviour
{
	[SerializeField]
	private float startDelay;

	[SerializeField]
	private float duration = 1f;

	[SerializeField]
	private float tickTime = 1f;

	[SerializeField]
	private Enemy.EEnemyType validEnemyType;

	private Tower ownerTower;

	private AreaEffectModule[] areaEffectModules;

	private Coroutine doAreaEffectCoroutine;

	public float Radius
	{
		get
		{
			return base.transform.localScale.x * 0.5f;
		}
		set
		{
			base.transform.localScale = Vector3.one * value;
		}
	}

	public string DisplayName => GetComponentsInChildren<AreaEffectModule>()[0]?.DisplayName ?? "Name-not-found";

	public string Description => GetComponentsInChildren<AreaEffectModule>()[0]?.Description ?? "Description-not-found";

	public float Duration => duration;

	public float TickTime => tickTime;

	public Enemy.EEnemyType ValidEnemyType => validEnemyType;

	public Tower OwnerTower
	{
		get
		{
			return ownerTower;
		}
		set
		{
			ownerTower = value;
		}
	}

	public event Action onAreaEffectStarts;

	public event Action onAreaEffectEnds;

	private void Awake()
	{
		areaEffectModules = GetComponentsInChildren<AreaEffectModule>();
	}

	private void Start()
	{
		this.StartCoroutineCheckingVar(DoAreaEffectCoroutine(), ref doAreaEffectCoroutine);
	}

	private IEnumerator DoAreaEffectCoroutine()
	{
		tickTime = Mathf.Max(TickTime, 0.1f);
		WaitForSeconds tickWFS = new WaitForSeconds(TickTime);
		yield return new WaitForSeconds(startDelay);
		this.onAreaEffectStarts?.Invoke();
		for (int i = 0; i < (int)duration / (int)tickTime; i++)
		{
			List<Enemy> affectedEnemies = GetAffectedEnemies();
			for (int j = 0; j < areaEffectModules.Length; j++)
			{
				areaEffectModules[j].DoModuleEffect(affectedEnemies);
			}
			yield return tickWFS;
		}
		this.onAreaEffectEnds?.Invoke();
		doAreaEffectCoroutine = null;
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public string GetAffectedEnemyTypesString()
	{
		string text = "";
		if ((validEnemyType & Enemy.EEnemyType.Ground) > (Enemy.EEnemyType)0)
		{
			text += LocalizationSettings.StringDatabase.GetLocalizedString("Enemies", "Enemies_enemyType_ground", null, FallbackBehavior.UseProjectSettings).ToLower();
		}
		if ((validEnemyType & Enemy.EEnemyType.Flying) > (Enemy.EEnemyType)0)
		{
			if (text.Length > 0)
			{
				text += ", ";
			}
			text += LocalizationSettings.StringDatabase.GetLocalizedString("Enemies", "Enemies_enemyType_flying", null, FallbackBehavior.UseProjectSettings).ToLower();
		}
		return text;
	}

	protected virtual List<Enemy> GetAffectedEnemies()
	{
		Collider[] array = Physics.OverlapCapsule(base.transform.position + Vector3.down * 3f, base.transform.position + Vector3.up * 3f, Radius, LayerMask.GetMask("Enemy"));
		List<Enemy> list = new List<Enemy>();
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].TryGetComponent<Enemy>(out var component) && (component.EnemyType & ValidEnemyType) > (Enemy.EEnemyType)0)
			{
				list.Add(component);
			}
		}
		return list;
	}
}
