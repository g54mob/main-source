using System;
using UnityEngine;

public class EnemySpawnVFX : MonoBehaviour
{
	public event Action onSpawnEnded;

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	protected void CallOnSpawnEnded()
	{
		this.onSpawnEnded?.Invoke();
	}
}
