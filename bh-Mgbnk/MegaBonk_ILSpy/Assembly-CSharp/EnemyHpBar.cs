using Assets.Scripts.Actors.Enemies;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{
	public Transform hpBar;

	private Enemy enemy;

	public void Set(Enemy enemy)
	{
		this.enemy = enemy;
	}

	private unsafe void Update()
	{
		//IL_0070: Expected O, but got Ref
		//IL_008b: Expected O, but got Ref
		if (enemy != null && !enemy.IsDeadOrDyingNextFrame())
		{
			Transform transform = base.transform;
			Vector3 headPosition = enemy.GetHeadPosition();
			float num = default(float);
			transform.position = (Vector3)(&num);
			hpBar.localScale = (Vector3)(&num);
		}
		else
		{
			GameObject obj = base.gameObject;
			Object.Destroy(obj);
		}
	}
}
