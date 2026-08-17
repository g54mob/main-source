using System;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;

public class PlayerFx : MonoBehaviour
{
	public GameObject jumpFx;

	public GameObject landFx;

	public PlayerMovement playerMovement;

	public ShakePreset landingShake;

	private void Awake()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<float> b = OnLanded;
		Delegate obj = Delegate.Combine(PlayerMovement.A_Landed, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerMovement.A_Landed = (Action<float>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action = default(Action<float>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<float>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			PlayerMovement.A_Landed = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<PlayerMovement> b2 = OnJumped;
		Delegate obj6 = Delegate.Combine(PlayerMovement.A_Jumped, b2);
		if ((object)obj6 == null)
		{
			PlayerMovement.A_Jumped = (Action<PlayerMovement>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerMovement> action2 = default(Action<PlayerMovement>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<PlayerMovement>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		PlayerMovement.A_Jumped = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<PlayerMovement>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	private void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<float> value = OnLanded;
		Delegate obj = Delegate.Remove(PlayerMovement.A_Landed, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			PlayerMovement.A_Landed = (Action<float>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action = default(Action<float>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<float>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			PlayerMovement.A_Landed = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0215;
			}
		}
		Action<PlayerMovement> value2 = OnJumped;
		Delegate obj6 = Delegate.Remove(PlayerMovement.A_Jumped, value2);
		if ((object)obj6 == null)
		{
			PlayerMovement.A_Jumped = (Action<PlayerMovement>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerMovement> action2 = default(Action<PlayerMovement>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<PlayerMovement>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		PlayerMovement.A_Jumped = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<PlayerMovement>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_0215:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0215;
	}

	private unsafe void OnJumped(PlayerMovement obj)
	{
		//IL_0052: Expected O, but got Ref
		//IL_0052: Expected O, but got Ref
		//IL_00cd: Expected O, but got Ref
		//IL_0122: Expected O, but got Ref
		PlayerMovement playerMovement = this.playerMovement;
		Vector3 position = playerMovement.feet.position;
		Transform transform = jumpFx.transform;
		Quaternion rotation = transform.rotation;
		float num = default(float);
		float num2 = default(float);
		GameObject gameObject = ParticleSpawner.SpawnParticles(jumpFx, (Vector3)(&num), (Quaternion)(&num2));
		ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
		PlayerMovement playerMovement2 = this.playerMovement;
		float num3 = playerMovement2.rb.velocity.x * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve = num3;
		ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = default(ParticleSystem.VelocityOverLifetimeModule);
		velocityOverLifetimeModule.x = (ParticleSystem.MinMaxCurve)(&num2);
		PlayerMovement playerMovement3 = this.playerMovement;
		float num4 = playerMovement3.rb.velocity.z * 0.5f;
		ParticleSystem.MinMaxCurve minMaxCurve2 = num4;
		ParticleSystemCurveMode particleSystemCurveMode = default(ParticleSystemCurveMode);
		velocityOverLifetimeModule.z = (ParticleSystem.MinMaxCurve)(&particleSystemCurveMode);
	}

	private unsafe void OnLanded(float fallSpeed)
	{
		//IL_014a: Expected O, but got Ref
		//IL_0162: Expected O, but got Ref
		//IL_0162: Expected O, but got Ref
		//IL_009e: Expected O, but got Ref
		//IL_00f3: Expected O, but got Ref
		//IL_011a: Expected O, but got I4
		if (!(8f > fallSpeed))
		{
			PlayerMovement playerMovement = this.playerMovement;
			Vector3 position = playerMovement.feet.position;
			float num = default(float);
			Quaternion quaternion = Quaternion.LookRotation((Vector3)(&num));
			float num2 = default(float);
			GameObject gameObject = ParticleSpawner.SpawnParticles(landFx, (Vector3)(&num), (Quaternion)(&num2));
			ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			PlayerMovement playerMovement2 = this.playerMovement;
			float num3 = playerMovement2.rb.velocity.x * 1.4f;
			ParticleSystem.MinMaxCurve minMaxCurve = num3;
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = default(ParticleSystem.VelocityOverLifetimeModule);
			velocityOverLifetimeModule.x = (ParticleSystem.MinMaxCurve)(&num2);
			PlayerMovement playerMovement3 = this.playerMovement;
			float num4 = playerMovement3.rb.velocity.z * 1.4f;
			ParticleSystem.MinMaxCurve minMaxCurve2 = num4;
			ParticleSystemCurveMode particleSystemCurveMode = default(ParticleSystemCurveMode);
			velocityOverLifetimeModule.z = (ParticleSystem.MinMaxCurve)(&particleSystemCurveMode);
			PlayerCamera instance = PlayerCamera.Instance;
			ShakeInstance shakeInstance = instance.shaker.Shake(landingShake, (int?)(object)0);
		}
	}
}
