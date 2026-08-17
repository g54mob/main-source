using System;
using System.Reflection;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors;

public class EnemyInstantiator : INetworkObjectInstantiator
{
	public static Action<EnemyController> OnRemoteEnemySpawned;

	public unsafe ICoherenceSync Instantiate(SpawnInfo spawnInfo)
	{
		int bindingValue = ((SpawnInfo*)spawnInfo)->GetBindingValue<int>("SyncedEnemyType");
		GameManager core = GM.Core;
		if ((object)GM.Core != null && (object)core._stage != null)
		{
			Vector2 spawnPos = default(Vector2);
			bool forceSpawn = default(bool);
			GameObject gameObject = core._stage.SpawnEnemy((EnemyType)bindingValue, spawnPos, asRemote: true, forceSpawn);
			Action<EnemyController> onRemoteEnemySpawned = OnRemoteEnemySpawned;
			bool flag = (object)gameObject == null;
			Stage typeFromHandle = (Stage)(object)typeof(EnemyInstantiator);
			if (!flag)
			{
				if (OnRemoteEnemySpawned != null)
				{
					EnemyController component = gameObject.GetComponent<EnemyController>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v98 @ rbx_v2 (System.Action`1<VampireSurvivors.Objects.Characters.EnemyController>)+18] (should have been resolved before IL gen)");
				}
				return gameObject.GetComponent<CoherenceSync>();
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void Destroy(ICoherenceSync obj)
	{
		//IL_027b: Invalid comparison between I4 and F4
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Ref, but got Unknown
		//IL_0175: Expected I8, but got O
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected Ref, but got Unknown
		//IL_0345: Invalid comparison between I4 and F4
		if ((object)obj.GetType() == typeof(CoherenceSync))
		{
		}
		bool flag = (object)obj.GetType() != typeof(CoherenceSync);
		Component component = null;
		if (!flag)
		{
			component = (Component)obj;
		}
		EnemyController component2 = component.GetComponent<EnemyController>();
		component2._003CKilledByAuthority_003Ek__BackingField = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5F17]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		SpriteAnimation spriteAnimation = component2._SpriteAnimation;
		FrameAnimationData frameAnimationData = ((BaseSpriteAnimation)spriteAnimation)._currentAnimation;
		if (((BaseSpriteAnimation)spriteAnimation)._currentAnimation != null)
		{
			frameAnimationData = (FrameAnimationData)(object)frameAnimationData._name;
		}
		object obj2 = "die";
		if ((object)frameAnimationData == "die")
		{
			goto IL_01b1;
		}
		if (frameAnimationData != null && "die" != null)
		{
			string name = frameAnimationData._name;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdx_v4+10]");
			if (name == null)
			{
				ref byte second = ref *(byte*)("die" + 20);
				ulong length = (ulong)(long)(frameAnimationData._name + frameAnimationData._name);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(frameAnimationData + 20), ref second, length))
				{
					goto IL_01b1;
				}
			}
		}
		goto IL_01f3;
		IL_01b1:
		if (component2.body == null || !component2._EnemyRenderer.enabled)
		{
			goto IL_01f3;
		}
		return;
		IL_01f3:
		if (!component2._003CIsDead_003Ek__BackingField && component2._deathStyle != EnemyDeathStyle.Despawn)
		{
			if (component2._deathStyle == EnemyDeathStyle.Die)
			{
				component2._hp = 0f;
				if (0f > component2._maxHp)
				{
					component2._hp = component2._maxHp;
				}
				if (!(0f < component2._hp))
				{
					component2.Die();
				}
			}
			else if (component2._deathStyle == EnemyDeathStyle.Disappear)
			{
				component2.Disappear();
			}
		}
		else
		{
			component2.Despawn();
		}
	}

	public void OnApplicationQuit()
	{
	}

	public void WarmUpInstantiator(CoherenceBridge bridge, CoherenceSyncConfig config, INetworkObjectProvider assetLoader)
	{
	}

	public void OnUniqueObjectReplaced(ICoherenceSync instance)
	{
	}

	private static object GetFieldValue(object obj, string fieldName)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0084: Expected O, but got I
		if (obj != null)
		{
			object obj2 = obj + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj3 = default(object);
			bool flag = obj3 == null;
			object obj4 = obj3;
			if (flag)
			{
				return new NullReferenceException();
			}
			object obj8 = default(object);
			object obj9 = default(object);
			while (true)
			{
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v89 @ r9_v6+6B8] (should have been resolved before IL gen)");
				object obj6 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rdx_v11+888]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v94 @ rdx_v11+888] (should have been resolved before IL gen)");
				if (obj8 != null)
				{
					break;
				}
				bool flag2 = obj9 != null;
				obj4 = obj9;
				if (!flag2)
				{
					if (obj8 != null)
					{
						break;
					}
					throw new NullReferenceException();
				}
			}
			object obj10 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v190 @ r8_v9+2C8] (should have been resolved before IL gen)");
		}
		ArgumentNullException ex = new ArgumentNullException("obj");
		throw ex;
	}

	private static FieldInfo GetFieldInfo(Type type, string fieldName)
	{
		bool flag = (object)type == null;
		Type type2 = type;
		if (!flag)
		{
			FieldInfo field;
			bool flag2;
			do
			{
				field = type2.GetField(fieldName, (BindingFlags)52);
				Type baseType = type2.BaseType;
				if ((object)field != null)
				{
					break;
				}
				flag2 = (object)baseType != null;
				type2 = baseType;
			}
			while (flag2);
			return field;
		}
		return (FieldInfo)(object)new NullReferenceException();
	}
}
