using System.Collections.Generic;
using UnityEngine;

public abstract class AreaEffectModule : MonoBehaviour
{
	protected AreaEffect areaEffect;

	public abstract string DisplayName { get; }

	public abstract string Description { get; }

	public abstract void DoModuleEffect(IEnumerable<Enemy> enemies);

	protected virtual void Awake()
	{
		areaEffect = GetComponent<AreaEffect>();
	}
}
