using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Game.Combat.EnemySpecialAttacks;

public class EnemyAttackPrefabAnimation : MonoBehaviour
{
	public AnimationCurve animationCurveScale;

	public float animationDuration = 1f;

	private Vector3 defaultSize;

	private float animationTime;

	private void Awake()
	{
		//IL_002b: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 localScale = transform.localScale;
		defaultSize = (Vector3)localScale.x;
		_ = localScale.z;
	}

	private unsafe void Update()
	{
		//IL_00b2: Invalid comparison between I4 and F4
		//IL_003c: Expected F4, but got I4
		//IL_0076: Expected O, but got Ref
		float num = MyTime.deltaTime / animationDuration;
		float num2 = (animationTime = num + animationTime);
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = animationCurveScale.Evaluate(num2);
		Transform transform = base.transform;
		float num4 = default(float);
		transform.localScale = (Vector3)(&num4);
	}
}
