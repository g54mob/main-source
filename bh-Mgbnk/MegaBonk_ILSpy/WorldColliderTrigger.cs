using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;

public class WorldColliderTrigger : MonoBehaviour
{
	private float maxSlopeAngle = 45f;

	private unsafe void OnCollisionStay(Collision collision)
	{
		//IL_014b: Expected O, but got I4
		//IL_0154: Expected O, but got I4
		//IL_015d: Expected O, but got I4
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01cf: Invalid comparison between F4 and O
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected O, but got Unknown
		//IL_0201: Expected O, but got I
		//IL_0319: Expected O, but got Ref
		//IL_032b: Expected I, but got O
		//IL_0407: Expected O, but got Ref
		ContactPoint[] contacts = collision.contacts;
		if (contacts.Length == 0)
		{
			return;
		}
		GameObject gameObject = collision.gameObject;
		if (!(gameObject != null))
		{
			return;
		}
		GameObject gameObject2 = collision.gameObject;
		int layer = gameObject2.layer;
		int num = LayerMask.NameToLayer("Player");
		if (layer != num)
		{
			GameObject gameObject3 = collision.gameObject;
			int layer2 = gameObject3.layer;
			int num2 = LayerMask.NameToLayer("Enemy");
			if (layer2 != num2)
			{
				return;
			}
		}
		int contactCount = collision.contactCount;
		if (contactCount <= 0)
		{
			return;
		}
		ContactPoint[] contacts2 = collision.contacts;
		ContactPoint contactPoint = (ContactPoint)0;
		object obj = 0;
		object obj2 = 0;
		float num6 = default(float);
		int attempts = default(int);
		bool onlyGround = default(bool);
		float fromHeight = default(float);
		while (true)
		{
			if ((nint)obj2 >= contacts2.Length)
			{
				return;
			}
			object obj3 = obj * 2;
			object obj4 = obj + obj3;
			object obj5 = obj4 + obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v635 @ rax_v20+4]");
			float num3 = 0f - -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
			object obj6 = num3 & 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.075f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
			{
				obj++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v16 (UnityEngine.ContactPoint[])+20+v632 @ rcx_v17*8]");
				contactPoint = (ContactPoint)0;
				obj2 = obj;
				continue;
			}
			GameObject gameObject4 = collision.gameObject;
			int layer3 = gameObject4.layer;
			int num4 = LayerMask.NameToLayer("Player");
			if (layer3 != num4)
			{
				GameObject gameObject5 = collision.gameObject;
				int layer4 = gameObject5.layer;
				int num5 = LayerMask.NameToLayer("Enemy");
				if (layer4 == num5)
				{
					break;
				}
				return;
			}
			Vector3 enemySpawnPositionAroundPoint = SpawnPositions.GetEnemySpawnPositionAroundPoint((Vector3)(&num6), 0f, 20f, attempts, onlyGround, fromHeight);
			nint num7 = (nint)typeof(SpawnPositions);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ rax_v33 (Il2CppClass<Assets.Scripts.Game.Spawning.SpawnPositions>)+B8]");
			nint num8 = 0;
			float num9 = enemySpawnPositionAroundPoint.x - (float)SpawnPositions.INVALID_POS;
			float num10 = enemySpawnPositionAroundPoint.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rcx_v27 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+4]");
			float num11 = num10 - 0f;
			float num12 = enemySpawnPositionAroundPoint.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v422 @ rcx_v27 (Il2CppStaticFields<Assets.Scripts.Game.Spawning.SpawnPositions>)+8]");
			float num13 = num12 - 0f;
			float num14 = num11 * num11;
			float num15 = num13 * num13;
			float num16 = num9 * num9;
			float num17 = num14 + num16;
			float num18 = num17 + num15;
			if (!(9.9999994E-11f > num18))
			{
				MyPlayer instance = MyPlayer.Instance;
				instance.playerMovement.TeleportPlayerBackToBounds((Vector3)(&num6));
			}
			return;
		}
		Collider collider = collision.collider;
		if (EnemyManager.Instance.GetEnemy(collider, out var enemy))
		{
			enemy.TeleportToPlayer();
		}
	}

	private bool IsFloor(Vector3 v)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0038: Invalid comparison between F4 and O
		//IL_0057: Invalid comparison between F4 and I4
		float num = v.y - -1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
		object obj = num & 0;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.075f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num2 = 0.075f - (float)obj;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private bool IsCeiling(Vector3 v)
	{
		//IL_001a: Invalid comparison between F4 and O
		//IL_003b: Invalid comparison between F4 and I4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803312C0");
		float num = maxSlopeAngle;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref Vector3.upVector);
		float num2 = maxSlopeAngle - (float)Vector3.upVector;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}
}
