using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

public class VelocityParticles : MonoBehaviour
{
	public ParticleSystem[] particleSystems;

	private ParticleSystem.VelocityOverLifetimeModule[] velocityModules;

	private Vector3 velocity;

	private Vector3 previousPos;

	private void Start()
	{
		//IL_002b: Expected O, but got F4
		//IL_006b: Expected O, but got I4
		//IL_0074: Expected O, but got I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		Transform transform = base.transform;
		Vector3 position = transform.position;
		ParticleSystem[] array = particleSystems;
		previousPos = (Vector3)position.x;
		_ = position.z;
		ParticleSystem.VelocityOverLifetimeModule[] array2 = new ParticleSystem.VelocityOverLifetimeModule[array.Length];
		velocityModules = array2;
		ParticleSystem[] array3 = particleSystems;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array3.Length)
		{
			ParticleSystem[] array4 = particleSystems;
			ParticleSystem.VelocityOverLifetimeModule[] array5 = velocityModules;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			array3 = particleSystems;
			obj++;
			obj2 = obj;
		}
	}

	private unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_007f: Invalid comparison between I4 and F4
		//IL_00ca: Expected F4, but got I4
		//IL_02b2: Expected O, but got I4
		//IL_02bb: Expected O, but got I4
		//IL_023e: Expected O, but got F4
		//IL_00de: Expected F4, but got O
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		//IL_011b: Expected O, but got Ref
		//IL_0135: Expected F4, but got I
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0172: Expected O, but got Ref
		//IL_0185: Expected O, but got Ref
		//IL_01a6: Expected F4, but got I
		//IL_01a1: Expected native int or pointer, but got O
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01e3: Expected O, but got Ref
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_0209: Expected O, but got I4
		//IL_0219: Expected O, but got I
		//IL_0222: Expected O, but got I4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		float num = position.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VelocityParticles)+44]");
		float num2 = num - 0f;
		float deltaTime = Time.deltaTime;
		float num3 = num2 / deltaTime;
		float deltaTime2 = Time.deltaTime;
		float num4 = deltaTime2 * 20f;
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		ParticleSystem.VelocityOverLifetimeModule[] array = velocityModules;
		float num5 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VelocityParticles)+38]");
		float num6 = num5 - 0f;
		float num7 = num6 * num4;
		float num8 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VelocityParticles)+38]");
		float num9 = num8 + 0f;
		Vector3 vector = default(Vector3);
		velocity = vector;
		object obj3 = 0;
		object obj4 = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = default(ParticleSystem.MinMaxCurve);
		while ((nint)obj4 < array.Length)
		{
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve((float)velocity);
			object obj5 = velocityModules + 32;
			object obj6 = obj3 * 8;
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule = (ParticleSystem.VelocityOverLifetimeModule)(obj5 + obj6);
			((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule)->x = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VelocityParticles)+34]");
			ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(0f);
			object obj7 = velocityModules + 32;
			object obj8 = obj3 * 8;
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule2 = (ParticleSystem.VelocityOverLifetimeModule)(obj7 + obj8);
			((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule2)->y = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VelocityParticles)+38]");
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f));
			object obj9 = obj3 + 4;
			object obj10 = obj9 * 8;
			ParticleSystem.VelocityOverLifetimeModule velocityOverLifetimeModule3 = (ParticleSystem.VelocityOverLifetimeModule)((object)velocityModules + obj10);
			((ParticleSystem.VelocityOverLifetimeModule*)velocityOverLifetimeModule3)->z = (ParticleSystem.MinMaxCurve)(&minMaxCurve2);
			array = velocityModules;
			obj3++;
			minMaxCurve3 = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-80]");
			minMaxCurve2 = (ParticleSystem.MinMaxCurve)0;
			minMaxCurve = (ParticleSystem.MinMaxCurve)0;
			obj4 = obj3;
		}
		previousPos = (Vector3)position.x;
		_ = position.y;
		_ = position.z;
	}
}
