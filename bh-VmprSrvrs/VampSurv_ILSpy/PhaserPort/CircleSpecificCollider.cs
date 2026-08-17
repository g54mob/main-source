using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;

public class CircleSpecificCollider : Collider
{
	private PhysicsGroup group1;

	private PhysicsGroup group2;

	private static readonly ProfilerMarker s_circleColliderMarker;

	private static readonly ProfilerMarker s_circleOverlapMarker;

	private static readonly ProfilerMarker s_circleVelocityMarker;

	private static readonly ProfilerMarker s_circlePositionMarker;

	public CircleSpecificCollider(World world, bool overlapOnly, ArcadeColliderType object1, ArcadeColliderType object2, ArcadePhysicsCallback collideCallback = null, ArcadePhysicsCallback processCallback = null, CallbackContext callbackContext = null)
	{
		//IL_02b0: Expected I, but got O
		//IL_001e: Expected I, but got O
		//IL_002e: Expected O, but got I
		//IL_006a: Expected O, but got I
		//IL_02f1: Expected I, but got O
		//IL_00b1: Expected I, but got O
		//IL_00b9: Expected I, but got O
		//IL_00c9: Expected O, but got I
		//IL_0150: Expected I, but got O
		//IL_0160: Expected O, but got I
		//IL_0105: Expected O, but got I
		//IL_019c: Expected O, but got I
		//IL_01e3: Expected I, but got O
		//IL_01eb: Expected I, but got O
		//IL_01fb: Expected O, but got I
		//IL_0237: Expected O, but got I
		ArcadeColliderType object3 = default(ArcadeColliderType);
		ArcadePhysicsCallback collideCallback2 = default(ArcadePhysicsCallback);
		ArcadePhysicsCallback processCallback2 = default(ArcadePhysicsCallback);
		CallbackContext callbackContext2 = default(CallbackContext);
		base._002Ector(world, overlapOnly, object1, object3, collideCallback2, processCallback2, callbackContext2);
		ArcadeColliderType object4 = _object1;
		nint num = (nint)typeof(PhysicsGroup);
		if (_object1 == null)
		{
			group1 = (PhysicsGroup)_object1;
			goto IL_02d9;
		}
		nint num2 = (nint)object4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v2 (Il2CppClass<PhysicsGroup>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r9_v9 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v2 (Il2CppClass<PhysicsGroup>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ r9_v9 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v36+FFFFFFF8+v73 @ rax_v33*8]");
			if (0 == (nint)typeof(PhysicsGroup))
			{
				group1 = (PhysicsGroup)_object1;
				nint num4 = (nint)typeof(PhysicsGroup);
				nint num5 = (nint)object4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v14 (Il2CppClass<PhysicsGroup>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r9_v10 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdx_v14 (Il2CppClass<PhysicsGroup>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ r9_v10 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rax_v38+FFFFFFF8+v208 @ rax_v37*8]");
					if (0 == (nint)typeof(PhysicsGroup))
					{
						goto IL_02d9;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
		IL_02d9:
		ArcadeColliderType object5 = _object2;
		nint num7 = (nint)typeof(PhysicsGroup);
		if (_object2 == null)
		{
			group2 = (PhysicsGroup)_object2;
			return;
		}
		nint num8 = (nint)object5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdx_v8 (Il2CppClass<PhysicsGroup>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r10_v5 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rdx_v8 (Il2CppClass<PhysicsGroup>)+130]");
		if (num9 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r10_v5 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rax_v24+FFFFFFF8+v241 @ rax_v23*8]");
			if (0 == (nint)typeof(PhysicsGroup))
			{
				group2 = (PhysicsGroup)_object2;
				nint num10 = (nint)typeof(PhysicsGroup);
				nint num11 = (nint)object5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdx_v12 (Il2CppClass<PhysicsGroup>)+130]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r10_v6 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ rdx_v12 (Il2CppClass<PhysicsGroup>)+130]");
				if (num12 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r10_v6 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v303 @ rax_v26+FFFFFFF8+v302 @ rax_v25*8]");
					if (0 == (nint)typeof(PhysicsGroup))
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}
		throw new InvalidCastException();
	}

	public unsafe override void update()
	{
		//IL_0051: Expected O, but got I4
		//IL_0059: Expected O, but got Ref
		PhysicsGroup physicsGroup = group1;
		World world = _world;
		RBush rBush = world._groupRTrees.get_Item((Group)group2);
		RBush rBush2 = rBush;
		HashSet<object>.Enumerator enumerator = default(HashSet<object>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			HashSet<object>.Enumerator enumerator2 = (HashSet<object>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	private static void ComputeSeparations(BaseBody body1, BaseBody body2)
	{
		//IL_0039: Expected O, but got I
		//IL_00b8: Invalid comparison between F4 and I4
		//IL_032b: Invalid comparison between F4 and I4
		//IL_00e7: Invalid comparison between F4 and I4
		//IL_092f: Invalid comparison between F4 and I4
		//IL_0eb7: Invalid comparison between O and F4
		//IL_08a9: Invalid comparison between F4 and I4
		//IL_0189: Invalid comparison between F4 and I4
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_03b0: Expected O, but got I4
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_06fc: Invalid comparison between F4 and I4
		//IL_04b8: Invalid comparison between F4 and I4
		//IL_08db: Invalid comparison between F4 and I4
		//IL_0a3f: Invalid comparison between F4 and I4
		//IL_0e12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e17: Expected O, but got Unknown
		//IL_0e53: Invalid comparison between O and F4
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03de: Expected O, but got Unknown
		//IL_0416: Expected O, but got I4
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Expected O, but got Unknown
		//IL_0f72: Expected O, but got I
		//IL_0f92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f97: Expected O, but got Unknown
		//IL_0f9f: Invalid comparison between O and F4
		//IL_0980: Expected I, but got O
		//IL_09b8: Expected O, but got I
		//IL_0a9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9f: Expected O, but got Unknown
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Expected O, but got Unknown
		//IL_0b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b71: Expected O, but got Unknown
		//IL_0b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		//IL_0bb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bba: Expected O, but got Unknown
		//IL_0bee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf3: Expected O, but got Unknown
		//IL_0c19: Expected O, but got F4
		//IL_0c47: Expected F4, but got O
		//IL_0c5c: Expected F4, but got I
		//IL_0cef: Expected O, but got I
		//IL_0d15: Expected O, but got F4
		//IL_0d43: Expected F4, but got O
		//IL_0d58: Expected F4, but got I
		//IL_0deb: Expected O, but got I
		//IL_055a: Invalid comparison between F4 and I4
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_0220: Expected O, but got I4
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_0749: Expected O, but got Unknown
		//IL_0781: Expected O, but got I4
		//IL_0789: Unknown result type (might be due to invalid IL or missing references)
		//IL_078e: Expected O, but got Unknown
		//IL_09eb: Invalid comparison between F4 and I4
		//IL_0eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef0: Expected O, but got Unknown
		//IL_0f00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f05: Expected O, but got Unknown
		//IL_0f25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2a: Expected O, but got Unknown
		//IL_0f32: Invalid comparison between O and F4
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_0286: Expected O, but got I4
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0464: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Expected O, but got Unknown
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Expected O, but got Unknown
		//IL_07e7: Expected O, but got I4
		//IL_07ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Expected O, but got Unknown
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_05b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Expected O, but got Unknown
		//IL_05f1: Expected O, but got I4
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		//IL_061a: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Expected O, but got Unknown
		//IL_0657: Expected O, but got I4
		//IL_065f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0664: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_0835: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_085f: Expected O, but got Unknown
		//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Expected O, but got Unknown
		//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Expected O, but got Unknown
		BaseBody baseBody = default(BaseBody);
		object obj = body2._center - baseBody._center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+6C]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+6C]");
		object obj2 = num - 0;
		object obj3 = baseBody._halfSize + body2._halfSize;
		object obj4 = obj * obj;
		object obj5 = obj2 * obj2;
		object obj6 = obj4 + obj5;
		object obj7 = obj3 * obj3;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185000031h\"");
		if (baseBody._dx == 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185000031h\"");
			if (body2._dx == 0f)
			{
				baseBody._embedded = true;
				body2._embedded = true;
				goto IL_0891;
			}
		}
		float dx = baseBody._dx;
		if (!(baseBody._dx > body2._dx))
		{
			if (body2._dx > baseBody._dx)
			{
				bool flag = baseBody._dx > 0f;
				float num2 = baseBody._dx;
				if (!flag)
				{
					num2 = baseBody._dx ^ -0f;
				}
				float num3 = body2._dx;
				if (!(body2._dx > 0f))
				{
					num3 ^= -0f;
				}
				float num4 = num3 + num2;
				object obj8 = baseBody._position ^ -0f;
				object obj9 = obj8 - (object)body2._size;
				dx = num4 + 0.04f;
				object obj10 = obj9 - (object)body2._position;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)dx))
				{
					object obj11 = baseBody._checkCollision & 4;
					bool flag2 = obj11 == null;
					bool flag3 = (nint)obj11 < 0;
					bool flag4 = !flag3;
					object obj12 = !flag4;
					object obj13 = obj12 | flag2;
					if (obj13 == null)
					{
						object obj14 = body2._checkCollision & 8;
						bool flag5 = obj14 == null;
						bool flag6 = (nint)obj14 < 0;
						bool flag7 = !flag6;
						object obj15 = !flag7;
						object obj16 = obj15 | flag5;
						if (obj16 == null)
						{
							if (body2._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked = (ArcadeBodyCollision)(baseBody._blocked | 4);
								baseBody._blocked = blocked;
							}
							if (baseBody._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked2 = (ArcadeBodyCollision)(body2._blocked | 8);
								body2._blocked = blocked2;
							}
						}
					}
				}
			}
		}
		else
		{
			float num2 = baseBody._dx;
			if (!(baseBody._dx > 0f))
			{
				num2 ^= -0f;
			}
			float num5 = body2._dx;
			if (!(body2._dx > 0f))
			{
				num5 ^= -0f;
			}
			float num6 = num5 + num2;
			object obj17 = baseBody._size + baseBody._position;
			dx = num6 + 0.04f;
			object obj18 = obj17 - (object)body2._position;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)dx))
			{
				object obj19 = baseBody._checkCollision & 8;
				bool flag8 = obj19 == null;
				bool flag9 = (nint)obj19 < 0;
				bool flag10 = !flag9;
				object obj20 = !flag10;
				object obj21 = obj20 | flag8;
				if (obj21 == null)
				{
					object obj22 = body2._checkCollision & 4;
					bool flag11 = obj22 == null;
					bool flag12 = (nint)obj22 < 0;
					bool flag13 = !flag12;
					object obj23 = !flag13;
					object obj24 = obj23 | flag11;
					if (obj24 == null)
					{
						if (body2._physicsType == PhysicsType.STATIC_BODY)
						{
							ArcadeBodyCollision blocked3 = (ArcadeBodyCollision)(baseBody._blocked | 8);
							baseBody._blocked = blocked3;
						}
						if (baseBody._physicsType == PhysicsType.STATIC_BODY)
						{
							ArcadeBodyCollision blocked4 = (ArcadeBodyCollision)(body2._blocked | 4);
							body2._blocked = blocked4;
						}
					}
				}
			}
		}
		goto IL_0891;
		IL_0891:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500017Ch\"");
		if (baseBody._dy == 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500017Ch\"");
			if (body2._dy == 0f)
			{
				baseBody._embedded = true;
				body2._embedded = true;
				goto IL_0968;
			}
		}
		dx = baseBody._dy;
		if (!(baseBody._dy > body2._dy))
		{
			if (body2._dy > baseBody._dy)
			{
				bool flag14 = baseBody._dy > 0f;
				float num2 = baseBody._dy;
				if (!flag14)
				{
					num2 = baseBody._dy ^ -0f;
				}
				float num7 = body2._dy;
				if (!(body2._dy > 0f))
				{
					num7 ^= -0f;
				}
				float num8 = num7 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+54]");
				object obj25 = 0 ^ -0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+54]");
				object obj26 = obj25 - 0;
				dx = num8 + 0.04f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+5C]");
				object obj27 = obj26 + 0;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj27) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)dx))
				{
					object obj28 = baseBody._checkCollision & 1;
					bool flag15 = obj28 == null;
					bool flag16 = (nint)obj28 < 0;
					bool flag17 = !flag16;
					object obj29 = !flag17;
					object obj30 = obj29 | flag15;
					if (obj30 == null)
					{
						object obj31 = body2._checkCollision & 2;
						bool flag18 = obj31 == null;
						bool flag19 = (nint)obj31 < 0;
						bool flag20 = !flag19;
						object obj32 = !flag20;
						object obj33 = obj32 | flag18;
						if (obj33 == null)
						{
							if (body2._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked5 = (ArcadeBodyCollision)(baseBody._blocked | 1);
								baseBody._blocked = blocked5;
							}
							if (baseBody._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked6 = (ArcadeBodyCollision)(body2._blocked | 2);
								body2._blocked = blocked6;
							}
						}
					}
				}
			}
		}
		else
		{
			float num2 = baseBody._dy;
			if (!(baseBody._dy > 0f))
			{
				num2 ^= -0f;
			}
			float num9 = body2._dy;
			if (!(body2._dy > 0f))
			{
				num9 ^= -0f;
			}
			float num10 = num9 + num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+5C]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+54]");
			object obj34 = num11 + 0;
			dx = num10 + 0.04f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+54]");
			object obj35 = obj34 - 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj35) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)dx))
			{
				object obj36 = baseBody._checkCollision & 2;
				bool flag21 = obj36 == null;
				bool flag22 = (nint)obj36 < 0;
				bool flag23 = !flag22;
				object obj37 = !flag23;
				object obj38 = obj37 | flag21;
				if (obj38 == null)
				{
					object obj39 = body2._checkCollision & 1;
					bool flag24 = obj39 == null;
					bool flag25 = (nint)obj39 < 0;
					bool flag26 = !flag25;
					object obj40 = !flag26;
					object obj41 = obj40 | flag24;
					if (obj41 == null)
					{
						if (body2._physicsType == PhysicsType.STATIC_BODY)
						{
							ArcadeBodyCollision blocked7 = (ArcadeBodyCollision)(baseBody._blocked | 2);
							baseBody._blocked = blocked7;
						}
						if (baseBody._physicsType == PhysicsType.STATIC_BODY)
						{
							ArcadeBodyCollision blocked8 = (ArcadeBodyCollision)(body2._blocked | 1);
							body2._blocked = blocked8;
						}
					}
				}
			}
		}
		goto IL_0968;
		IL_0968:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		nint num12 = (nint)typeof(float2);
		bool flag27 = obj6 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v5 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num13 = 0;
		float2 float5 = float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rcx_v3 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		object obj42 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001850002C2h\"");
		if (!flag27)
		{
			float5 = obj / obj6;
			obj42 = obj2 / obj6;
		}
		object obj43 = obj3 - obj6;
		float2 velocity = baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+74]");
		object obj44 = velocity + 0;
		float num14 = (float)obj43 * 0.5f;
		float num15 = num14 + 1E-06f;
		object obj45 = obj44 - (object)body2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+74]");
		object obj46 = obj45 - 0;
		object obj47 = (object)float5 * obj46;
		object obj48 = obj42 * obj46;
		object obj49 = obj47 * (object)float5;
		object obj50 = obj48 * obj42;
		object obj51 = (object)baseBody._velocity - obj49;
		float num16 = (float)float5 * num15;
		object obj52 = obj49 + (object)body2._velocity;
		float num17 = (float)obj42 * num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+74]");
		object obj53 = 0 - obj50;
		float2 velocity2 = obj51 * (object)baseBody._bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+74]");
		object obj54 = obj50 + 0;
		baseBody._velocity = velocity2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+88]");
		object obj55 = obj53 * 0;
		float2 velocity3 = obj52 * (object)body2._bounce;
		body2._velocity = velocity3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+88]");
		object obj56 = obj54 * 0;
		float num18 = (float)baseBody._position - num16;
		baseBody._position = (float2)num18;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+54]");
		float num19 = 0f - num17;
		baseBody.MinX = (float)baseBody._position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+54]");
		baseBody.MinY = 0f;
		float maxX = (float)baseBody._size + (float)baseBody._position;
		baseBody.MaxX = maxX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+5C]");
		float num20 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+54]");
		float maxY = num20 + 0f;
		baseBody.MaxY = maxY;
		float2 center = baseBody._halfSize + baseBody._position;
		baseBody._center = center;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+64]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rcx_v1 (BaseBody)+54]");
		object obj57 = num21 + 0;
		float num22 = num16 + (float)body2._position;
		body2._position = (float2)num22;
		float num23 = num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+54]");
		float num24 = num23 + 0f;
		body2.MinX = (float)body2._position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+54]");
		body2.MinY = 0f;
		float maxX2 = (float)body2._size + (float)body2._position;
		body2.MaxX = maxX2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+5C]");
		float num25 = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+54]");
		float maxY2 = num25 + 0f;
		body2.MaxY = maxY2;
		float2 center2 = body2._halfSize + body2._position;
		body2._center = center2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+64]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+54]");
		object obj58 = num26 + 0;
	}

	static CircleSpecificCollider()
	{
		//IL_005b: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_000e: Expected O, but got I
		//IL_0034: Expected O, but got I
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("CircleSpecificCollider.update", 5, MarkerFlags.Default, 0);
		s_circleColliderMarker = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("CircleSpecificCollider.update.overlap", 5, MarkerFlags.Default, 0);
		s_circleOverlapMarker = (ProfilerMarker)(nint)intPtr2;
		IntPtr intPtr3 = ProfilerUnsafeUtility.CreateMarker("CircleSpecificCollider.update.velocity", 5, MarkerFlags.Default, 0);
		s_circleVelocityMarker = (ProfilerMarker)(nint)intPtr3;
		IntPtr intPtr4 = ProfilerUnsafeUtility.CreateMarker("CircleSpecificCollider.update.position", 5, MarkerFlags.Default, 0);
		s_circlePositionMarker = (ProfilerMarker)(nint)intPtr4;
	}
}
