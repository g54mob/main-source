using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects;

public class PetInstance
{
	public Equipment _baseEquipment;

	public Equipment _hiddenWeapon;

	public SpriteRenderer _petSprite;

	public VampireSurvivors.Objects.Characters.CharacterController Owner;

	public float _petOffset;

	private Vector2 _currentDirection;

	protected float _offsetY;

	protected float _runSpeed;

	private float GetOffsetX()
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected F4, but got Unknown
		VampireSurvivors.Objects.Characters.CharacterController owner = Owner;
		float num = _petOffset;
		if (!owner._isFlipped)
		{
			float num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			num = num2 ^ 0;
		}
		return num;
	}

	private float DistanceSquared(Vector2 vec1, Vector2 vec2)
	{
		object obj = vec1 - vec2;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		object obj5 = obj * obj;
		object obj6 = obj2 * obj2;
		return (float)obj5 + (float)obj6;
	}

	public unsafe void InternalPetUpdate()
	{
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0153: Expected O, but got F4
		//IL_01a6: Expected O, but got F4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected F4, but got Unknown
		//IL_01d3: Invalid comparison between I4 and F4
		//IL_01f2: Invalid comparison between F4 and I4
		//IL_028f: Expected F4, but got I4
		//IL_0435: Expected I, but got O
		//IL_0317->IL02c6: Incompatible stack heights: 1 vs 0
		//IL_00a4->IL02c6: Incompatible stack heights: 1 vs 0
		//IL_0370->IL02c6: Incompatible stack heights: 2 vs 0
		//IL_01c5->IL02c6: Incompatible stack heights: 2 vs 0
		//IL_0244->IL02c6: Incompatible stack heights: 2 vs 0
		//IL_0272->IL02c6: Incompatible stack heights: 2 vs 0
		Vector3 ret;
		if ((object)Owner != null)
		{
			Transform transform = Owner.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
				if ((object)_petSprite != null)
				{
					Transform transform2 = _petSprite.transform;
					if ((object)transform2 != null)
					{
						bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
						VampireSurvivors.Objects.Characters.CharacterController owner = Owner;
						if ((object)Owner != null)
						{
							float num = _petOffset;
							if (!owner._isFlipped)
							{
								float num2 = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
								num = num2 ^ 0;
							}
							float num3 = (float)ret + num;
							object obj2 = default(object);
							object obj3 = default(object);
							object obj = obj2 - obj3;
							float num4 = (float)ret2 - num3;
							float num5 = (float)obj * (float)obj;
							float num6 = num4 * num4;
							float num7 = num6 + num5;
							if (!(num7 > 0.5f))
							{
								goto IL_03ea;
							}
							float num8 = (float)obj3 - 0.24f;
							float num9 = (float)ret + num;
							Vector2 vector = (Vector2)(this + 52);
							float num10 = num8 - (float)obj2;
							float num11 = num9 - (float)ret2;
							_currentDirection = (Vector2)num11;
							float num12 = num10 + _offsetY;
							((Vector2*)vector)->Normalize();
							float num13 = (float)_currentDirection * 0.02f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.PetInstance)+38]");
							num5 = 0f * 0.02f;
							_currentDirection = (Vector2)num13;
							if ((object)_petSprite != null)
							{
								bool flag3 = 0f < num13;
								float num14 = 0f - num13;
								bool flag4 = num14 == 0f;
								bool flag5 = !flag3;
								bool flag6 = !flag4;
								bool flipX = flag6 & flag5;
								_petSprite.flipX = flipX;
								if ((object)Owner != null)
								{
									float num15 = Owner.PMoveSpeed();
									if ((object)Owner != null)
									{
										float num16 = Owner.PMoveSpeed();
										num3 = 0f;
										goto IL_03ea;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_03ea:
		bool flag7 = (object)_petSprite == null;
		Transform transform3 = _petSprite.transform;
		bool flag8 = (object)transform3 == null;
		bool flag9 = (object)((PetInstance)(object)transform3)._baseEquipment == null;
		Transform.set_position_Injected((IntPtr)((PetInstance)(object)transform3)._baseEquipment, ref ret);
	}

	public PetInstance()
	{
		//IL_003f: Expected I, but got O
		_petOffset = 0.24f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_currentDirection = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		float runSpeed = GameManager.PlayerPxSpeed / 1.1785715f;
		_runSpeed = runSpeed;
	}
}
