using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives.ImplementationsFuckYou;

public class AbilityDash : ActiveAbility
{
	private float dashDuration = 0.2f;

	private float dashOverAtTime;

	private bool isDashing;

	private Vector3 dashDir;

	private Vector3 preDashVel;

	private float dashSpeed = 40f;

	private float dashSpeedToUse;

	public override void Init()
	{
	}

	public override void Cleanup()
	{
	}

	public override void UseImplementation()
	{
		//IL_0087: Expected O, but got F4
		//IL_01db: Expected O, but got F4
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_02f9: Expected O, but got I
		//IL_0316: Expected O, but got I
		//IL_0342: Invalid comparison between F4 and O
		//IL_0104: Expected O, but got I
		//IL_0135: Expected O, but got I
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		isDashing = true;
		float num = MyTime.time + dashDuration;
		dashOverAtTime = num;
		MyPlayer instance = MyPlayer.Instance;
		PlayerMovement playerMovement = instance.playerMovement;
		playerMovement.isDashing = true;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerMovement playerMovement2 = instance2.playerMovement;
		playerMovement2.rb.useGravity = false;
		MyPlayer instance3 = MyPlayer.Instance;
		Vector3 wishDir = instance3.playerMovement.GetWishDir();
		dashDir = (Vector3)wishDir.x;
		_ = wishDir.z;
		MyPlayer instance4 = MyPlayer.Instance;
		if (instance4.playerMovement.IsTouchingGround())
		{
			MyPlayer instance5 = MyPlayer.Instance;
			PlayerMovement playerMovement3 = instance5.playerMovement;
			object obj = (object)playerMovement3.normalVector * (object)playerMovement3.normalVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v40 (PlayerMovement)+134]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v40 (PlayerMovement)+134]");
			object obj2 = num2 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v40 (PlayerMovement)+138]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v40 (PlayerMovement)+138]");
			object obj3 = num3 * 0;
			object obj4 = obj2 + obj;
			float epsilon = Mathf.Epsilon;
			object obj5 = obj4 + obj3;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives.ImplementationsFuckYou.AbilityDash)+28]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v40 (PlayerMovement)+134]");
				object obj6 = num4 * 0;
				object obj7 = (object)dashDir * (object)playerMovement3.normalVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives.ImplementationsFuckYou.AbilityDash)+2C]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v40 (PlayerMovement)+138]");
				object obj8 = num5 * 0;
				object obj9 = obj6 + obj7;
				object obj10 = obj9 + obj8;
				object obj11 = obj10 * (object)playerMovement3.normalVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v40 (PlayerMovement)+134]");
				object obj12 = obj10 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v40 (PlayerMovement)+138]");
				object obj13 = obj10 * 0;
				epsilon = (float)obj11 / (float)obj5;
				obj3 = obj12 / obj5;
				object obj14 = obj13 / obj5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj15 = default(object);
			dashDir = (Vector3)obj15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ rax_v43+8]");
			_ = 0;
		}
		MyPlayer instance6 = MyPlayer.Instance;
		Vector3 velocity = instance6.playerMovement.GetVelocity();
		preDashVel = (Vector3)velocity.x;
		_ = velocity.z;
		object obj16 = this + 48;
		_ = 0;
		dashSpeedToUse = dashSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		if (velocity.x > dashSpeed)
		{
			object obj17 = this + 48;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			float num6 = dashSpeed * 0.5f;
			float num7 = num6 + velocity.x;
			dashSpeedToUse = num7;
		}
		int layer = LayerMask.NameToLayer("Player");
		int layer2 = LayerMask.NameToLayer("Enemy");
		Physics.IgnoreLayerCollision(layer, layer2, ignore: true);
	}

	private unsafe void DashFinished()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00aa: Expected O, but got Ref
		isDashing = false;
		MyPlayer instance = MyPlayer.Instance;
		PlayerMovement playerMovement = instance.playerMovement;
		playerMovement.isDashing = false;
		MyPlayer instance2 = MyPlayer.Instance;
		PlayerMovement playerMovement2 = instance2.playerMovement;
		playerMovement2.rb.useGravity = false;
		object obj = this + 48;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerMovement playerMovement3 = instance3.playerMovement;
		object obj2 = default(object);
		playerMovement3.rb.velocity = (Vector3)(&obj2);
		int layer = LayerMask.NameToLayer("Player");
		int layer2 = LayerMask.NameToLayer("Enemy");
		Physics.IgnoreLayerCollision(layer, layer2, ignore: false);
	}

	public unsafe override void Tick()
	{
		//IL_005f: Expected O, but got Ref
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_012d: Expected O, but got Ref
		if (isDashing)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerMovement playerMovement = instance.playerMovement;
			float num = dashSpeedToUse * (float)dashDir;
			float num2 = dashSpeedToUse;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Inventory__Items__Pickups.AbilitiesActives.ImplementationsFuckYou.AbilityDash)+28]");
			float num3 = num2 * 0f;
			float num4 = default(float);
			playerMovement.rb.velocity = (Vector3)(&num4);
			if (isDashing && !(MyTime.time < dashOverAtTime))
			{
				isDashing = false;
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerMovement playerMovement2 = instance2.playerMovement;
				playerMovement2.isDashing = false;
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerMovement playerMovement3 = instance3.playerMovement;
				playerMovement3.rb.useGravity = false;
				object obj = this + 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
				MyPlayer instance4 = MyPlayer.Instance;
				PlayerMovement playerMovement4 = instance4.playerMovement;
				playerMovement4.rb.velocity = (Vector3)(&num4);
				int layer = LayerMask.NameToLayer("Player");
				int layer2 = LayerMask.NameToLayer("Enemy");
				Physics.IgnoreLayerCollision(layer, layer2, ignore: false);
			}
		}
	}

	public override float GetCooldown()
	{
		return 1.5f;
	}
}
