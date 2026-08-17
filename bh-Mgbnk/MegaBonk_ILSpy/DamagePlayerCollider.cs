using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class DamagePlayerCollider : MonoBehaviour
{
	public float knockbackForce = 10f;

	public float damage = 2f;

	public float refreshTime = 0.5f;

	private float readyAtTime;

	private unsafe void OnCollisionEnter(Collision collision)
	{
		//IL_0142: Expected I, but got O
		//IL_010f: Expected O, but got Ref
		GameObject gameObject = collision.gameObject;
		int layer = gameObject.layer;
		int num = LayerMask.NameToLayer("Player");
		if (layer == num && !(readyAtTime > MyTime.time))
		{
			Transform transform = collision.transform;
			Vector3 position = transform.position;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float num2 = position.y - position2.y;
			float num3 = position.z - position2.z;
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v16 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			float num6 = 0f * 0.25f;
			float num7 = num6 + num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ rcx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			float num8 = 0f * 0.25f;
			float num9 = num8 + num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			float num10 = default(float);
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory.playerHealth.DamagePlayerExternal(damage, knockbackForce, (Vector3)(&num10), ignoreShield, damageSource, flags, damageEffect);
			float num11 = MyTime.time + refreshTime;
			readyAtTime = num11;
		}
	}
}
