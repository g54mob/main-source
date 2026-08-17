using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class DamagePlayerTrigger : MonoBehaviour
{
	private Enemy enemy;

	public float activeTime = 0.4f;

	private float stopTime;

	private bool done;

	private void Awake()
	{
		float num = MyTime.time + activeTime;
		stopTime = num;
	}

	public void Set(Enemy enemy)
	{
		this.enemy = enemy;
	}

	private void OnTriggerEnter(Collider other)
	{
		//IL_0123: Expected I, but got O
		if (MyTime.time < stopTime)
		{
			if (!done)
			{
				GameObject gameObject = other.gameObject;
				int layer = gameObject.layer;
				int num = LayerMask.NameToLayer("Player");
				if (layer == num)
				{
					done = true;
					DamageContainer damageContainer = new DamageContainer(0f, "Unknown");
					Enemy enemy = this.enemy;
					float damage = enemy._003CenemyData_003Ek__BackingField.GetDamage();
					damageContainer.damage = damage;
					Transform transform = MyPlayer.Instance.transform;
					Vector3 position = transform.position;
					Transform transform2 = base.transform;
					Vector3 position2 = transform2.position;
					Enemy enemy2 = this.enemy;
					nint num2 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v26 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num3 = 0;
					float num4 = enemy2._003CmeshHeight_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rcx_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
					float num5 = num4 * 0f;
					float num6 = enemy2._003CmeshHeight_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rcx_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num7 = num6 * 0f;
					float num8 = num5 * 0.5f;
					float num9 = num7 * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
					object direction = default(object);
					damageContainer.direction = (Vector3)direction;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v511 @ rax_v30+8]");
					_ = 0;
					damageContainer.knockback = 35f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
					Debug.Break();
				}
			}
		}
		else
		{
			base.enabled = false;
			Object.Destroy(this);
		}
	}
}
