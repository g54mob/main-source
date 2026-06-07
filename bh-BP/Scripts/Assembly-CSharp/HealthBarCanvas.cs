using UnityEngine;

public class HealthBarCanvas : MonoBehaviour
{
	public static HealthBarCanvas I;

	public Canvas Cvs;

	public SerializedObjectPool<EnemyHealthBar> HealthBarPool;

	private void Awake()
	{
	}

	public EnemyHealthBar CreateHealthBar()
	{
		return null;
	}

	public void RemoveHealthBar(EnemyHealthBar hb)
	{
	}
}
