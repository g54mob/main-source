using System;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class Enemy_TP_DeathScythe : EnemyController
{
	private float2 _targetScreenPoint;

	public Vector2 BodyVelocity
	{
		get
		{
			Vector2 result = default(Vector2);
			if (body != null)
			{
				return result;
			}
			return result;
		}
		set
		{
			if (body != null)
			{
				BaseBody baseBody = body;
				baseBody._velocity = value;
			}
		}
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_00ad: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		_isImmuneToModification = true;
		base.InitEnemy(enemyType, asRemote);
		ArcadeSprite arcadeSprite = setScale(2f, (float?)(object)0);
		BaseBody baseBody = body;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = false;
		baseBody._immovable = true;
		BaseBody baseBody2 = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite2 = setFrame(sprite);
		BaseBody baseBody3 = body;
		float2 float5 = default(float2);
		baseBody3._transform.setOrigin(float5);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 186 Invalid \"Jump target not found in method: 0x1876C30D0\"");
		throw new NullReferenceException();
	}

	private void PickRandomScreenPoint()
	{
		//IL_00e6: Expected O, but got F4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		float minInclusive = renderer.width * -0.5f;
		float maxInclusive = renderer2.width * 0.5f;
		float num = UnityEngine.Random.Range(minInclusive, maxInclusive);
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer3 = s_scene3._renderer;
		PhaserScene s_scene4 = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer4 = s_scene4._renderer;
		float minInclusive2 = renderer3.height * -0.5f;
		float maxInclusive2 = renderer4.height * 0.5f;
		float num2 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
		_targetScreenPoint = (float2)num;
	}

	protected override void Die()
	{
		base.Die();
	}

	public override void Disappear()
	{
		base.Disappear();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_009c: Invalid comparison between F4 and I4
		Enemy_TP_Death component = _owner.GetComponent<Enemy_TP_Death>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && (component._003CHasRemovedWeapons_003Ek__BackingField || component._hasSpawnedAllies) && _hp > 0f)
		{
			_hp = 0f;
		}
		bool hasKb2 = default(bool);
		base.GetDamaged(value, showHitVfx, damageKb, damageType, hasKb2);
	}

	protected override void OnUpdate()
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_011d: Expected O, but got I
		//IL_0198: Expected O, but got I
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_01cb: Expected I, but got O
		//IL_01fe: Expected F4, but got O
		//IL_020e: Expected F4, but got I
		//IL_0233: Invalid comparison between F4 and O
		//IL_0340: Expected O, but got F4
		BaseBody baseBody = body.setCircle(10f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
		Transform cachedTrans = ((ArcadeSprite)this).CachedTrans;
		Vector3 localEulerAngles = cachedTrans.localEulerAngles;
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 720f;
		float num2 = num + localEulerAngles.z;
		base.angle = num2;
		ArcadeSprite arcadeSprite2 = setDepth(3000);
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v31 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v31 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v31 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				return;
			}
		}
		float num3 = base._003CSpeed_003Ek__BackingField * 0.01f;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj2 = renderer.screenCenter + _targetScreenPoint;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v16 (PhaserScene+Renderer)+38]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Characters.Enemies.Enemy_TP_DeathScythe)+274]");
		object obj3 = num4 + 0;
		float2 float5 = base.position;
		object obj4 = obj2 - (object)float5;
		object obj5 = obj3 - 1056964608;
		nint num5 = (nint)typeof(float2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v20 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
		nint num6 = 0;
		object obj6 = obj4 * obj4;
		object obj7 = obj5 * obj5;
		float num7 = (float)float2.zero;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rcx_v18 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
		float num8 = 0f;
		object obj8 = obj6 + obj7;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.01f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
		{
			object obj9 = obj4 / obj8;
			object obj10 = obj5 / obj8;
			num7 = (float)obj9 * num3;
			num8 = (float)obj10 * num3;
		}
		else
		{
			PickRandomScreenPoint();
		}
		Enemy_TP_Death component = _owner.GetComponent<Enemy_TP_Death>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0 && component.body != null)
		{
			BaseBody baseBody2 = component.body;
			num7 += (float)baseBody2._velocity;
			float num9 = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v31 (BaseBody)+74]");
			num8 = num9 + 0f;
		}
		BaseBody baseBody3 = body;
		baseBody3._velocity = (float2)num7;
	}
}
