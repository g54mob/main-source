using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

public class ExplodeEnemyTrigger : MonoBehaviour
{
	public float radius;

	private unsafe void Start()
	{
		//IL_0050: Expected O, but got Ref
		//IL_0067: Expected O, but got I4
		//IL_0088: Expected O, but got I4
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_0343: Expected I, but got O
		//IL_0293: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 position = transform.position;
		GameManager instance = GameManager.Instance;
		float x = position.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
		float num = default(float);
		int layerMask = default(int);
		Collider[] array = Physics.OverlapSphere((Vector3)(&num), radius, layerMask);
		Enemy enemy = null;
		object obj = 0;
		float num2 = radius;
		num = position.x;
		object obj2 = 0;
		object obj3 = default(object);
		while ((nint)obj2 < array.Length)
		{
			GameObject gameObject = array[obj].gameObject;
			int layer = gameObject.layer;
			int num3 = LayerMask.NameToLayer("Enemy");
			if (layer == num3 && EnemyManager.Instance.GetEnemy(array[obj], out enemy))
			{
				Transform transform2 = array[obj].transform;
				Vector3 position2 = transform2.position;
				Transform transform3 = base.transform;
				Vector3 position3 = transform3.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331420");
				float num4 = position3.x - 1f;
				x = num4 / radius;
				if (!(0.3f > x))
				{
					if (x > 1f)
					{
						x = 1f;
					}
				}
				else
				{
					x = 0.3f;
				}
				DamageContainer damageContainer = new DamageContainer(0f, "ExplodeEnemyTrigger (Bug probably)");
				Transform transform4 = array[obj].transform;
				Vector3 position4 = transform4.position;
				Transform transform5 = base.transform;
				Vector3 position5 = transform5.position;
				float num5 = position4.x - position5.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				nint num6 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v35 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num7 = 0;
				float num8 = (float)Vector3.upVector * 0.4f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
				float num9 = 0f * 0.4f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rcx_v32 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				float num10 = 0f * 0.4f;
				float num11 = num8 + (float)obj3;
				float num12 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ rax_v33+4]");
				num2 = num12 + 0f;
				float num13 = num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ rax_v33+8]");
				float num14 = num13 + 0f;
				damageContainer.direction = (Vector3)num11;
				float num15 = 1f - x;
				float knockback = num15 * 60f;
				damageContainer.knockback = knockback;
				enemy.enemyMovement.Knockback(damageContainer);
				float x2 = position3.x;
				float x3 = position2.x;
				num = num5;
			}
			obj++;
			obj2 = obj;
		}
	}
}
