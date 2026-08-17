using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

namespace VampireSurvivors;

public class ParticleSystemCircleCollision : GameMonoBehaviour
{
	[NonSerialized]
	public ParticleSystem _particleSystem;

	[NonSerialized]
	public float _radius;

	[NonSerialized]
	public float _bounce;

	private ParticleSystem.Particle[] _particles;

	protected unsafe override void OnUpdate()
	{
		//IL_007a: Expected I4, but got I8
		//IL_00a7: Expected O, but got I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_058d: Expected O, but got F4
		//IL_0670: Expected I, but got O
		//IL_01df: Expected F8, but got I4
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_0264: Expected O, but got Ref
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_05e3: Expected I, but got O
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_037f: Invalid comparison between I4 and F4
		//IL_03ca: Expected F4, but got I4
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Expected O, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_04c9->IL0433: Incompatible stack heights: 1 vs 0
		//IL_0540->IL0433: Incompatible stack heights: 2 vs 0
		//IL_0139->IL0433: Incompatible stack heights: 2 vs 0
		//IL_05d0->IL0675: Incompatible stack heights: 3 vs 0
		//IL_05d5->IL03f5: Incompatible stack heights: 3 vs 0
		//IL_0256->IL0433: Incompatible stack heights: 3 vs 0
		//IL_02a7->IL0433: Incompatible stack heights: 3 vs 0
		//IL_02d3->IL0433: Incompatible stack heights: 3 vs 0
		//IL_033a->IL0433: Incompatible stack heights: 3 vs 0
		//IL_0617->IL0433: Incompatible stack heights: 3 vs 0
		ParticleSystem particleSystem = _particleSystem;
		if ((object)_particleSystem == null || ((UnityEngine.Object)particleSystem).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		InitIfNeeded();
		int particles;
		if ((object)_particleSystem != null)
		{
			particles = _particleSystem.GetParticles(_particles, -1, 0);
			if (particles <= 0)
			{
				goto IL_03f5;
			}
			object obj = 0;
			object obj5 = default(object);
			object obj6 = default(object);
			object obj14 = default(object);
			object obj20 = default(object);
			while (true)
			{
				ParticleSystem.Particle[] particles2 = _particles;
				if (_particles == null)
				{
					break;
				}
				object particleSystem2 = _particleSystem;
				object obj2 = obj * 132;
				if ((object)_particleSystem == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rsi_v13 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rsi_v13 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
				Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				if ((object)transform == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rax_v37 (UnityEngine.Transform)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rax_v37 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out Vector3 ret);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rcx_v30+20+v522 @ rdx_v21 (Particle[])]");
				object obj3 = 0 - ret;
				object obj4 = obj5 - obj6;
				if (_particles == null)
				{
					break;
				}
				object particleSystem3 = _particleSystem;
				object obj7 = obj * 132;
				object obj8 = obj7 + (object)_particles;
				if ((object)_particleSystem == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rsi_v15 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				object obj9 = obj8 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v494 @ rsi_v15 (System.Object)+10]");
				object obj10 = ParticleSystem.GetParticleCurrentSize_Injected((IntPtr)0, ref *(ParticleSystem.Particle*)obj9);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rcx_v30+20+v522 @ rdx_v21 (Particle[])]");
				float num = 0f * 0.5f;
				nint num2 = (nint)typeof(Math);
				object obj11 = obj3 * obj3;
				object obj12 = obj4 * obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rcx_v30+28+v522 @ rdx_v21 (Particle[])]");
				float num3 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ rcx_v30+28+v522 @ rdx_v21 (Particle[])]");
				float num4 = num3 * 0f;
				object obj13 = obj11 + obj12;
				double d = (double)obj13 + (double)num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm3\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v555 @ rcx_v42 (Il2CppClass<System.Math>)+E4]");
				double num5;
				if ((nint)0 <= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm3\"");
					num5 = 0.0;
				}
				else
				{
					num5 = Math.Sqrt(d);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
				double num6 = num5 + (double)num;
				if (num6 > (double)_radius)
				{
					object particles3 = _particles;
					if (_particles == null)
					{
						break;
					}
					Vector3 vector = Vector3.Normalize((Vector3)(&obj14));
					float num7 = _radius - num;
					float num8 = vector.z * num7;
					if ((object)_particleSystem == null)
					{
						break;
					}
					Transform transform2 = _particleSystem.transform;
					if ((object)transform2 == null)
					{
						break;
					}
					float num9 = transform2.position.z + num8;
					object obj15 = obj * 132;
					object particles4 = _particles;
					if (_particles == null)
					{
						break;
					}
					nint num10 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rax_v56 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num11 = 0;
					ParticleSystem.Particle[] particles5 = _particles;
					if (_particles == null)
					{
						break;
					}
					object obj16 = obj * 132;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v866 @ rcx_v49+34+v530 @ rdx_v30 (Particle[])]");
					object obj17 = 0 ^ -0f;
					num4 = _bounce;
					if (!(0f > _bounce))
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ r8_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					object obj18 = obj17 - 0;
					float num12 = (float)obj18 * num4;
					float num13 = num12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ r8_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					float num14 = num13 + 0f;
					object obj19 = obj * 132;
					obj14 = obj20;
				}
				obj++;
				if ((nint)obj < particles)
				{
					continue;
				}
				goto IL_03f5;
			}
		}
		goto IL_0433;
		IL_0433:
		throw new NullReferenceException();
		IL_03f5:
		if ((object)_particleSystem != null)
		{
			_particleSystem.SetParticles(_particles, particles, 0);
			return;
		}
		goto IL_0433;
	}

	private void InitIfNeeded()
	{
		//IL_0103: Expected O, but got I
		//IL_00b7: Expected O, but got I
		if (_particles != null)
		{
			ParticleSystem.Particle[] particles = _particles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v266 @ rax_v35 (should have been resolved before IL gen)");
			object obj2 = default(object);
			if (particles.Length >= (nint)obj2)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9C0]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj3 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v330 @ rax_v15 (should have been resolved before IL gen)");
		object obj4 = default(object);
		ParticleSystem.Particle[] particles2 = new ParticleSystem.Particle[obj4];
		_particles = particles2;
	}

	public ParticleSystemCircleCollision()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
