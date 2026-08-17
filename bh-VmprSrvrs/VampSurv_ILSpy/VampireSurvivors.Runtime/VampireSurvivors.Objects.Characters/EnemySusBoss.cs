using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using Zenject;

namespace VampireSurvivors.Objects.Characters;

public class EnemySusBoss : EnemyController
{
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public EnemyController enemy;

		internal void _003COnMeatSpawned_003Eb__0()
		{
			//IL_00dd->IL0110: Incompatible stack heights: 1 vs 0
			Transform transform = (Transform)(object)enemy;
			if ((object)enemy != null && ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0)
			{
				Behaviour behaviour = enemy;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (UnityEngine.Behaviour)+28]");
				if ((nint)0 != 0)
				{
					behaviour.enabled = true;
					EnemyController enemyController = enemy;
					BaseBody body = enemyController.body;
					body._enable = true;
					Transform transform2 = enemy.transform;
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Quaternion value = default(Quaternion);
					Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					EnemyController enemyController2 = enemy;
					enemyController2._003CIsCullable_003Ek__BackingField = true;
				}
			}
		}
	}

	private EnemySusBossTentacle _leftTentacle;

	private EnemySusBossTentacle _leftTentacle2;

	private EnemySusBossTentacle _rightTentacle;

	private EnemySusBossTentacle _rightTentacle2;

	private List<EnemyController> _meattList;

	private PhaserSprite[] _miniTentacles;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_006f: Expected O, but got I
		//IL_0430: Expected I, but got O
		//IL_04a4: Expected I, but got O
		//IL_0518: Expected I, but got O
		//IL_058c: Expected I, but got O
		//IL_0600: Expected I, but got O
		//IL_0674: Expected I, but got O
		base.InitEnemy(enemyType, asRemote);
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v100 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v100 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v100 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				Action<EnemyController> b = OnRemoteEnemySpawned;
				Delegate obj2 = Delegate.Combine(EnemyInstantiator.OnRemoteEnemySpawned, b);
				if ((object)obj2 == null)
				{
					EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj2;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					Action<EnemyController> action = default(Action<EnemyController>);
					if (action == null)
					{
						throw new InvalidCastException();
					}
					EnemyInstantiator.OnRemoteEnemySpawned = action;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					if (obj3 == null)
					{
						throw new InvalidCastException();
					}
				}
			}
		}
		List<EnemyController> meattList = new List<EnemyController>();
		_meattList = meattList;
		base._003CIsCullable_003Ek__BackingField = false;
		base._003CIsTeleportOnCull_003Ek__BackingField = true;
		GameManager core = GM.Core;
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemySusBossTentacle leftTentacle = default(EnemySusBossTentacle);
		_leftTentacle = leftTentacle;
		GameObject owner = base.gameObject;
		_leftTentacle.SetOwner(owner);
		EnemySusBossTentacle leftTentacle2 = _leftTentacle;
		leftTentacle2._isLeft = true;
		((EnemyController)leftTentacle2)._003CIsCullable_003Ek__BackingField = false;
		((EnemyController)leftTentacle2)._003CIsTeleportOnCull_003Ek__BackingField = false;
		GameManager core2 = GM.Core;
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemySusBossTentacle leftTentacle3 = default(EnemySusBossTentacle);
		_leftTentacle2 = leftTentacle3;
		GameObject owner2 = base.gameObject;
		_leftTentacle2.SetOwner(owner2);
		EnemySusBossTentacle leftTentacle4 = _leftTentacle2;
		leftTentacle4._isLeft = true;
		((EnemyController)leftTentacle4)._003CIsCullable_003Ek__BackingField = false;
		((EnemyController)leftTentacle4)._003CIsTeleportOnCull_003Ek__BackingField = false;
		GameManager core3 = GM.Core;
		float2 float7 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemySusBossTentacle rightTentacle = default(EnemySusBossTentacle);
		_rightTentacle = rightTentacle;
		GameObject owner3 = base.gameObject;
		_rightTentacle.SetOwner(owner3);
		EnemySusBossTentacle rightTentacle2 = _rightTentacle;
		rightTentacle2._isLeft = false;
		((EnemyController)rightTentacle2)._003CIsCullable_003Ek__BackingField = false;
		((EnemyController)rightTentacle2)._003CIsTeleportOnCull_003Ek__BackingField = false;
		GameManager core4 = GM.Core;
		float2 float8 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemySusBossTentacle rightTentacle3 = default(EnemySusBossTentacle);
		_rightTentacle2 = rightTentacle3;
		EnemySusBossTentacle rightTentacle4 = _rightTentacle2;
		GameObject owner4 = base.gameObject;
		rightTentacle4.SetOwner(owner4);
		EnemySusBossTentacle rightTentacle5 = _rightTentacle2;
		rightTentacle5._isLeft = false;
		((EnemyController)rightTentacle5)._003CIsCullable_003Ek__BackingField = false;
		((EnemyController)rightTentacle5)._003CIsTeleportOnCull_003Ek__BackingField = false;
		if (_miniTentacles != null)
		{
			return;
		}
		PhaserSprite[] miniTentacles = new PhaserSprite[6];
		_miniTentacles = miniTentacles;
		PhaserSprite[] miniTentacles2 = _miniTentacles;
		PhaserSprite phaserSprite = CreateMiniTentacle("A");
		if ((object)phaserSprite != null)
		{
			nint num = (nint)miniTentacles2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		PhaserSprite[] miniTentacles3 = _miniTentacles;
		PhaserSprite phaserSprite2 = CreateMiniTentacle("A");
		if ((object)phaserSprite2 != null)
		{
			nint num2 = (nint)miniTentacles3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj5 = default(object);
			if (obj5 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		PhaserSprite[] miniTentacles4 = _miniTentacles;
		PhaserSprite phaserSprite3 = CreateMiniTentacle("B");
		if ((object)phaserSprite3 != null)
		{
			nint num3 = (nint)miniTentacles4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj6 = default(object);
			if (obj6 == null)
			{
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				throw ex3;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		PhaserSprite[] miniTentacles5 = _miniTentacles;
		PhaserSprite phaserSprite4 = CreateMiniTentacle("B");
		if ((object)phaserSprite4 != null)
		{
			nint num4 = (nint)miniTentacles5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj7 = default(object);
			if (obj7 == null)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				throw ex4;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		PhaserSprite[] miniTentacles6 = _miniTentacles;
		PhaserSprite phaserSprite5 = CreateMiniTentacle("C");
		if ((object)phaserSprite5 != null)
		{
			nint num5 = (nint)miniTentacles6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj8 = default(object);
			if (obj8 == null)
			{
				ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
				throw ex5;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		PhaserSprite[] miniTentacles7 = _miniTentacles;
		PhaserSprite phaserSprite6 = CreateMiniTentacle("C");
		if ((object)phaserSprite6 != null)
		{
			nint num6 = (nint)miniTentacles7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj9 = default(object);
			if (obj9 == null)
			{
				ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
				throw ex6;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	private void OnRemoteEnemySpawned(EnemyController enemy)
	{
		if (enemy._enemyType == EnemyType.CHAL_MEATT)
		{
			OnMeatSpawned(enemy);
		}
	}

	private PhaserSprite CreateMiniTentacle(string type)
	{
		float2 float5 = base.position;
		string spriteName = "susAnimeXL_mini" + type + "_i01";
		if ((object)this != null)
		{
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "chalcedonyEnemies", spriteName);
			string animName = "susAnimeXL_mini" + type + "_i";
			int num = default(int);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 5, "chalcedonyEnemies", num);
			if ((object)phaserSprite != null && (object)phaserSprite._spriteAnimation != null)
			{
				bool startRandomFrame = default(bool);
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				phaserSprite._spriteAnimation.AddAnimation("idle", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(phaserSprite._spriteRenderer, 1f);
				return phaserSprite;
			}
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	private unsafe void LateUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_1924: Expected O, but got Ref
		//IL_1997: Expected O, but got Ref
		//IL_1a06: Expected O, but got Ref
		//IL_1a46: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		//IL_00ab: Expected O, but got I
		//IL_00b9: Expected O, but got Ref
		//IL_00cc: Expected O, but got Ref
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0166: Expected O, but got Ref
		//IL_033b: Expected O, but got I
		//IL_0349: Expected O, but got Ref
		//IL_035c: Expected O, but got Ref
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_03f6: Expected O, but got Ref
		//IL_028d: Expected O, but got Ref
		//IL_02ad: Expected O, but got I4
		//IL_02b6: Expected O, but got I4
		//IL_05cb: Expected O, but got I
		//IL_05d9: Expected O, but got Ref
		//IL_05e7: Expected O, but got Ref
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_062b: Expected O, but got Unknown
		//IL_0686: Expected O, but got Ref
		//IL_051d: Expected O, but got Ref
		//IL_053d: Expected O, but got I4
		//IL_0546: Expected O, but got I4
		//IL_085b: Expected O, but got I
		//IL_0869: Expected O, but got Ref
		//IL_087c: Expected O, but got Ref
		//IL_08b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Expected O, but got Unknown
		//IL_0916: Expected O, but got Ref
		//IL_07ad: Expected O, but got Ref
		//IL_07cd: Expected O, but got I4
		//IL_07d6: Expected O, but got I4
		//IL_0a3d: Expected O, but got Ref
		//IL_0a5d: Expected O, but got I4
		//IL_0a66: Expected O, but got I4
		//IL_0f1a: Expected I4, but got O
		//IL_113b: Expected I4, but got O
		//IL_13de: Expected I4, but got O
		//IL_15ff: Expected I4, but got O
		//IL_18b1: Expected I4, but got O
		//IL_1895: Expected O, but got I4
		//IL_195a->IL18b6: Incompatible stack heights: 1 vs 0
		//IL_02bb->IL02bb: Incompatible stack heights: 13 vs 4
		//IL_054b->IL054b: Incompatible stack heights: 13 vs 4
		//IL_07db->IL07db: Incompatible stack heights: 13 vs 4
		//IL_0a6b->IL0a6b: Incompatible stack heights: 13 vs 4
		//IL_0c69->IL1ae4: Incompatible stack heights: 13 vs 12
		//IL_0f12->IL1b2b: Incompatible stack heights: 25 vs 24
		//IL_1133->IL1b72: Incompatible stack heights: 34 vs 33
		//IL_13d6->IL1bb9: Incompatible stack heights: 46 vs 45
		//IL_15f7->IL1c00: Incompatible stack heights: 55 vs 54
		//IL_189a->IL1c47: Incompatible stack heights: 67 vs 66
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ArcadeSprite arcadeSprite = setDepth(500);
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			_ = Quaternion.identityQuaternion;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj3);
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				_ = 0;
				_ = 0;
				bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out *(Vector3*)obj4);
				Transform cachedTransform2 = _cachedTransform;
				bool flag3 = (object)_cachedTransform == null;
				_ = 0;
				_ = 0;
				bool flag4 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Quaternion quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 73));
				Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Vector3*)quaternion2);
				Transform leftTentacle = (Transform)(object)_leftTentacle;
				bool flag5 = (object)_leftTentacle == null;
				object obj5 = 0;
				if (!flag5)
				{
					bool flag6 = ((UnityEngine.Object)leftTentacle).m_CachedPtr == (IntPtr)0;
					obj5 = 0;
					if (!flag6)
					{
						bool flag7 = (object)_cachedTransform == null;
						Quaternion localRotation = _cachedTransform.localRotation;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
						object obj6 = (nint)0 * (nint)0;
						Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Quaternion quaternion3 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						_ = localRotation.x;
						Vector3 vector2 = quaternion3 * vector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
						object obj7 = 0 + vector2.z;
						_ = vector2.x;
						bool flag8 = (object)_leftTentacle == null;
						Transform transform2 = _leftTentacle.transform;
						bool flag9 = (object)transform2 == null;
						Vector3 vector3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						transform2.position = vector3;
						bool flag10 = (object)_leftTentacle == null;
						ArcadeSprite arcadeSprite2 = _leftTentacle.setFlipX(flipX: false);
						bool flag11 = (object)_EnemyRenderer == null;
						int sortingOrder = _EnemyRenderer.sortingOrder;
						bool flag12 = (object)_leftTentacle == null;
						int num = sortingOrder - 1;
						ArcadeSprite arcadeSprite3 = _leftTentacle.setDepth(num);
						bool flag13 = (object)_leftTentacle == null;
						Transform transform3 = _leftTentacle.transform;
						bool flag14 = (object)_cachedTransform == null;
						Quaternion rotation = _cachedTransform.rotation;
						bool flag15 = (object)transform3 == null;
						quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						_ = rotation.x;
						transform3.rotation = quaternion2;
						object obj8 = 0;
						obj5 = 0;
					}
				}
				Transform leftTentacle2 = (Transform)(object)_leftTentacle2;
				if ((object)_leftTentacle2 != null && ((UnityEngine.Object)leftTentacle2).m_CachedPtr != (IntPtr)0)
				{
					bool flag16 = (object)_cachedTransform == null;
					Quaternion localRotation2 = _cachedTransform.localRotation;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
					object obj6 = (nint)0 * (nint)0;
					Vector3 vector4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Quaternion quaternion4 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					_ = localRotation2.x;
					Vector3 vector5 = quaternion4 * vector4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
					object obj9 = 0 + vector5.z;
					_ = vector5.x;
					bool flag17 = (object)_leftTentacle2 == null;
					Transform transform4 = _leftTentacle2.transform;
					bool flag18 = (object)transform4 == null;
					Vector3 vector6 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					transform4.position = vector6;
					bool flag19 = (object)_leftTentacle2 == null;
					ArcadeSprite arcadeSprite4 = _leftTentacle2.setFlipX(flipX: false);
					bool flag20 = (object)_EnemyRenderer == null;
					int sortingOrder2 = _EnemyRenderer.sortingOrder;
					bool flag21 = (object)_leftTentacle2 == null;
					int num2 = sortingOrder2 - 3;
					ArcadeSprite arcadeSprite5 = _leftTentacle2.setDepth(num2);
					bool flag22 = (object)_leftTentacle2 == null;
					Transform transform5 = _leftTentacle2.transform;
					bool flag23 = (object)_cachedTransform == null;
					Quaternion rotation2 = _cachedTransform.rotation;
					bool flag24 = (object)transform5 == null;
					quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					_ = rotation2.x;
					transform5.rotation = quaternion2;
					object obj8 = 0;
					obj5 = 0;
				}
				Transform rightTentacle = (Transform)(object)_rightTentacle;
				if ((object)_rightTentacle != null && ((UnityEngine.Object)rightTentacle).m_CachedPtr != (IntPtr)0)
				{
					bool flag25 = (object)_cachedTransform == null;
					Quaternion localRotation3 = _cachedTransform.localRotation;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
					object obj6 = (nint)0 * (nint)0;
					Vector3 vector7 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Quaternion quaternion5 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					_ = localRotation3.x;
					Vector3 vector8 = quaternion5 * vector7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
					object obj10 = 0 + vector8.z;
					_ = vector8.x;
					bool flag26 = (object)_rightTentacle == null;
					Transform transform6 = _rightTentacle.transform;
					bool flag27 = (object)transform6 == null;
					Vector3 vector9 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					transform6.position = vector9;
					bool flag28 = (object)_rightTentacle == null;
					ArcadeSprite arcadeSprite6 = _rightTentacle.setFlipX(flipX: true);
					bool flag29 = (object)_EnemyRenderer == null;
					int sortingOrder3 = _EnemyRenderer.sortingOrder;
					bool flag30 = (object)_rightTentacle == null;
					int num3 = sortingOrder3 - 1;
					ArcadeSprite arcadeSprite7 = _rightTentacle.setDepth(num3);
					bool flag31 = (object)_rightTentacle == null;
					Transform transform7 = _rightTentacle.transform;
					bool flag32 = (object)_cachedTransform == null;
					Quaternion rotation3 = _cachedTransform.rotation;
					bool flag33 = (object)transform7 == null;
					quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					_ = rotation3.x;
					transform7.rotation = quaternion2;
					object obj8 = 0;
					obj5 = 0;
				}
				Transform rightTentacle2 = (Transform)(object)_rightTentacle2;
				if ((object)_rightTentacle2 != null && ((UnityEngine.Object)rightTentacle2).m_CachedPtr != (IntPtr)0)
				{
					bool flag34 = (object)_cachedTransform == null;
					Quaternion localRotation4 = _cachedTransform.localRotation;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-41]");
					object obj6 = (nint)0 * (nint)0;
					Vector3 vector10 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					Quaternion quaternion6 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					_ = localRotation4.x;
					Vector3 vector11 = quaternion6 * vector10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-31]");
					object obj11 = 0 + vector11.z;
					_ = vector11.x;
					bool flag35 = (object)_rightTentacle2 == null;
					Transform transform8 = _rightTentacle2.transform;
					bool flag36 = (object)transform8 == null;
					Vector3 vector12 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					transform8.position = vector12;
					bool flag37 = (object)_rightTentacle2 == null;
					ArcadeSprite arcadeSprite8 = _rightTentacle2.setFlipX(flipX: true);
					bool flag38 = (object)_EnemyRenderer == null;
					int sortingOrder4 = _EnemyRenderer.sortingOrder;
					bool flag39 = (object)_rightTentacle2 == null;
					int num4 = sortingOrder4 - 3;
					ArcadeSprite arcadeSprite9 = _rightTentacle2.setDepth(num4);
					bool flag40 = (object)_rightTentacle2 == null;
					Transform transform9 = _rightTentacle2.transform;
					bool flag41 = (object)_cachedTransform == null;
					Quaternion rotation4 = _cachedTransform.rotation;
					bool flag42 = (object)transform9 == null;
					quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					_ = rotation4.x;
					transform9.rotation = quaternion2;
					object obj8 = 0;
					obj5 = 0;
				}
				PhaserSprite[] miniTentacles = _miniTentacles;
				bool flag43 = _miniTentacles == null;
				bool flag44 = miniTentacles.Length <= 0;
				float2 float5 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
				float num5 = 0f + 1.4f;
				bool flag45 = (object)miniTentacles[0] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite[] miniTentacles2 = _miniTentacles;
				bool flag46 = _miniTentacles == null;
				bool flag47 = miniTentacles2.Length <= 0;
				int num6 = base.depth;
				bool flag48 = (object)miniTentacles2[0] == null;
				int num7 = num6 - 4;
				PhaserSprite phaserSprite = miniTentacles2[0].setDepth(num7);
				PhaserSprite[] miniTentacles3 = _miniTentacles;
				bool flag49 = _miniTentacles == null;
				bool flag50 = miniTentacles3.Length <= 0;
				Transform leftTentacle3 = (Transform)(object)_leftTentacle;
				Transform transform10;
				bool visible;
				if ((object)_leftTentacle != null && ((UnityEngine.Object)leftTentacle3).m_CachedPtr != (IntPtr)0)
				{
					EnemySusBossTentacle leftTentacle4 = _leftTentacle;
					bool flag51 = (object)_leftTentacle == null;
					bool flag52 = !((EnemyController)leftTentacle4)._003CIsDead_003Ek__BackingField;
					transform10 = null;
					visible = flag52;
				}
				else
				{
					transform10 = null;
					visible = false;
				}
				bool flag53 = (object)miniTentacles3[0] == null;
				PhaserSprite phaserSprite2 = miniTentacles3[0].setVisible(visible);
				PhaserSprite[] miniTentacles4 = _miniTentacles;
				bool flag54 = _miniTentacles == null;
				bool flag55 = miniTentacles4.Length <= 1;
				float2 float6 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
				float num8 = 0f + 1.4f;
				bool flag56 = (object)miniTentacles4[1] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite[] miniTentacles5 = _miniTentacles;
				bool flag57 = _miniTentacles == null;
				bool flag58 = miniTentacles5.Length <= 1;
				bool flag59 = (object)miniTentacles5[1] == null;
				PhaserSprite phaserSprite3 = miniTentacles5[1].setFlipX(flipX: true);
				PhaserSprite[] miniTentacles6 = _miniTentacles;
				bool flag60 = _miniTentacles == null;
				bool flag61 = miniTentacles6.Length <= 1;
				int num9 = base.depth;
				bool flag62 = (object)miniTentacles6[1] == null;
				int num10 = num9 - 4;
				PhaserSprite phaserSprite4 = miniTentacles6[1].setDepth(num10);
				PhaserSprite[] miniTentacles7 = _miniTentacles;
				bool flag63 = _miniTentacles == null;
				bool flag64 = miniTentacles7.Length <= 1;
				EnemySusBossTentacle rightTentacle3 = _rightTentacle;
				bool visible2;
				if ((object)_rightTentacle != null && ((UnityEngine.Object)rightTentacle3).m_CachedPtr != (IntPtr)0)
				{
					EnemySusBossTentacle rightTentacle4 = _rightTentacle;
					bool flag65 = (object)_rightTentacle == null;
					bool flag66 = !((EnemyController)rightTentacle4)._003CIsDead_003Ek__BackingField;
					visible2 = flag66;
				}
				else
				{
					visible2 = (byte)(int)transform10 != 0;
				}
				bool flag67 = (object)miniTentacles7[1] == null;
				PhaserSprite phaserSprite5 = miniTentacles7[1].setVisible(visible2);
				PhaserSprite[] miniTentacles8 = _miniTentacles;
				bool flag68 = _miniTentacles == null;
				bool flag69 = miniTentacles8.Length <= 2;
				float2 float7 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
				float num11 = 0f + 1.4f;
				bool flag70 = (object)miniTentacles8[2] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite[] miniTentacles9 = _miniTentacles;
				bool flag71 = _miniTentacles == null;
				bool flag72 = miniTentacles9.Length <= 2;
				int num12 = base.depth;
				bool flag73 = (object)miniTentacles9[2] == null;
				int num13 = num12 - 5;
				PhaserSprite phaserSprite6 = miniTentacles9[2].setDepth(num13);
				PhaserSprite[] miniTentacles10 = _miniTentacles;
				bool flag74 = _miniTentacles == null;
				bool flag75 = miniTentacles10.Length <= 2;
				EnemySusBossTentacle leftTentacle5 = _leftTentacle2;
				bool visible3;
				if ((object)_leftTentacle2 != null && ((UnityEngine.Object)leftTentacle5).m_CachedPtr != (IntPtr)0)
				{
					EnemySusBossTentacle leftTentacle6 = _leftTentacle2;
					bool flag76 = (object)_leftTentacle2 == null;
					bool flag77 = !((EnemyController)leftTentacle6)._003CIsDead_003Ek__BackingField;
					visible3 = flag77;
				}
				else
				{
					visible3 = (byte)(int)transform10 != 0;
				}
				bool flag78 = (object)miniTentacles10[2] == null;
				PhaserSprite phaserSprite7 = miniTentacles10[2].setVisible(visible3);
				PhaserSprite[] miniTentacles11 = _miniTentacles;
				bool flag79 = _miniTentacles == null;
				bool flag80 = miniTentacles11.Length <= 3;
				float2 float8 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
				float num14 = 0f + 1.4f;
				bool flag81 = (object)miniTentacles11[3] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite[] miniTentacles12 = _miniTentacles;
				bool flag82 = _miniTentacles == null;
				bool flag83 = miniTentacles12.Length <= 3;
				bool flag84 = (object)miniTentacles12[3] == null;
				PhaserSprite phaserSprite8 = miniTentacles12[3].setFlipX(flipX: true);
				PhaserSprite[] miniTentacles13 = _miniTentacles;
				bool flag85 = _miniTentacles == null;
				bool flag86 = miniTentacles13.Length <= 3;
				int num15 = base.depth;
				bool flag87 = (object)miniTentacles13[3] == null;
				int num16 = num15 - 5;
				PhaserSprite phaserSprite9 = miniTentacles13[3].setDepth(num16);
				PhaserSprite[] miniTentacles14 = _miniTentacles;
				bool flag88 = _miniTentacles == null;
				bool flag89 = miniTentacles14.Length <= 3;
				EnemySusBossTentacle rightTentacle5 = _rightTentacle2;
				bool visible4;
				if ((object)_rightTentacle2 != null && ((UnityEngine.Object)rightTentacle5).m_CachedPtr != (IntPtr)0)
				{
					EnemySusBossTentacle rightTentacle6 = _rightTentacle2;
					bool flag90 = (object)_rightTentacle2 == null;
					bool flag91 = !((EnemyController)rightTentacle6)._003CIsDead_003Ek__BackingField;
					visible4 = flag91;
				}
				else
				{
					visible4 = (byte)(int)transform10 != 0;
				}
				bool flag92 = (object)miniTentacles14[3] == null;
				PhaserSprite phaserSprite10 = miniTentacles14[3].setVisible(visible4);
				PhaserSprite[] miniTentacles15 = _miniTentacles;
				bool flag93 = _miniTentacles == null;
				bool flag94 = miniTentacles15.Length <= 4;
				float2 float9 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
				float num17 = 0f + 0.4f;
				bool flag95 = (object)miniTentacles15[4] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite[] miniTentacles16 = _miniTentacles;
				bool flag96 = _miniTentacles == null;
				bool flag97 = miniTentacles16.Length <= 4;
				int num18 = base.depth;
				bool flag98 = (object)miniTentacles16[4] == null;
				int num19 = num18 - 2;
				PhaserSprite phaserSprite11 = miniTentacles16[4].setDepth(num19);
				PhaserSprite[] miniTentacles17 = _miniTentacles;
				bool flag99 = _miniTentacles == null;
				bool flag100 = miniTentacles17.Length <= 4;
				EnemySusBossTentacle leftTentacle7 = _leftTentacle;
				bool visible5;
				if ((object)_leftTentacle != null && ((UnityEngine.Object)leftTentacle7).m_CachedPtr != (IntPtr)0)
				{
					EnemySusBossTentacle leftTentacle8 = _leftTentacle;
					bool flag101 = (object)_leftTentacle == null;
					bool flag102 = !((EnemyController)leftTentacle8)._003CIsDead_003Ek__BackingField;
					visible5 = flag102;
				}
				else
				{
					visible5 = (byte)(int)transform10 != 0;
				}
				bool flag103 = (object)miniTentacles17[4] == null;
				PhaserSprite phaserSprite12 = miniTentacles17[4].setVisible(visible5);
				PhaserSprite[] miniTentacles18 = _miniTentacles;
				bool flag104 = _miniTentacles == null;
				bool flag105 = miniTentacles18.Length <= 5;
				float2 float10 = base.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+7B]");
				float num20 = 0f + 0.4f;
				bool flag106 = (object)miniTentacles18[5] == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				PhaserSprite[] miniTentacles19 = _miniTentacles;
				bool flag107 = _miniTentacles == null;
				bool flag108 = miniTentacles19.Length <= 5;
				bool flag109 = (object)miniTentacles19[5] == null;
				PhaserSprite phaserSprite13 = miniTentacles19[5].setFlipX(flipX: true);
				PhaserSprite[] miniTentacles20 = _miniTentacles;
				bool flag110 = _miniTentacles == null;
				bool flag111 = miniTentacles20.Length <= 5;
				int num21 = base.depth;
				bool flag112 = (object)miniTentacles20[5] == null;
				int num22 = num21 - 2;
				PhaserSprite phaserSprite14 = miniTentacles20[5].setDepth(num22);
				PhaserSprite[] miniTentacles21 = _miniTentacles;
				bool flag113 = _miniTentacles == null;
				bool flag114 = miniTentacles21.Length <= 5;
				EnemySusBossTentacle rightTentacle7 = _rightTentacle;
				if ((object)_rightTentacle != null && ((UnityEngine.Object)rightTentacle7).m_CachedPtr != (IntPtr)0)
				{
					EnemySusBossTentacle rightTentacle8 = _rightTentacle;
					bool flag115 = (object)_rightTentacle == null;
					bool flag116 = !((EnemyController)rightTentacle8)._003CIsDead_003Ek__BackingField;
					transform10 = (Transform)flag116;
				}
				bool flag117 = (object)miniTentacles21[5] == null;
				PhaserSprite phaserSprite15 = miniTentacles21[5].setVisible((byte)(int)transform10 != 0);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		//IL_0417: Expected O, but got I4
		//IL_0421: Expected O, but got I4
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0314->IL0497: Incompatible stack heights: 1 vs 0
		//IL_0240->IL0362: Incompatible stack heights: 1 vs 0
		//IL_0253->IL0476: Incompatible stack heights: 1 vs 0
		EnemySusBossTentacle leftTentacle = _leftTentacle;
		if ((object)_leftTentacle != null && ((UnityEngine.Object)leftTentacle).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_leftTentacle == null)
			{
				goto IL_0362;
			}
			_leftTentacle.Disappear();
		}
		EnemySusBossTentacle leftTentacle2 = _leftTentacle2;
		if ((object)_leftTentacle2 != null && ((UnityEngine.Object)leftTentacle2).m_CachedPtr != (IntPtr)0)
		{
			if ((object)_leftTentacle2 == null)
			{
				goto IL_0362;
			}
			_leftTentacle2.Disappear();
		}
		Delegate rightTentacle = (Delegate)(object)_rightTentacle;
		if ((object)_rightTentacle != null && rightTentacle.method_ptr != (IntPtr)0)
		{
			if ((object)_rightTentacle == null)
			{
				goto IL_0362;
			}
			_rightTentacle.Disappear();
		}
		Delegate rightTentacle2 = (Delegate)(object)_rightTentacle2;
		if ((object)_rightTentacle2 != null && rightTentacle2.method_ptr != (IntPtr)0)
		{
			if ((object)_rightTentacle2 == null)
			{
				goto IL_0362;
			}
			_rightTentacle2.Disappear();
		}
		PhaserSprite[] miniTentacles = _miniTentacles;
		bool flag = _miniTentacles == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			Action<EnemyController> action = default(Action<EnemyController>);
			object obj6 = default(object);
			while (true)
			{
				if ((nint)obj2 < miniTentacles.Length)
				{
					PhaserSprite[] miniTentacles2 = _miniTentacles;
					if (_miniTentacles == null)
					{
						break;
					}
					Delegate obj3 = (Delegate)(object)miniTentacles2[obj];
					if ((object)miniTentacles2[obj] == null)
					{
						break;
					}
					bool flag2 = obj3.method_ptr == (IntPtr)0;
					IntPtr gcHandlePtr = Component.get_gameObject_Injected(obj3.method_ptr);
					GameObject obj4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
					UnityEngine.Object.Destroy(obj4, 0f);
					miniTentacles = _miniTentacles;
					obj++;
					if (_miniTentacles == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				_miniTentacles = null;
				Action<EnemyController> value = OnRemoteEnemySpawned;
				Delegate obj5 = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value);
				if ((object)obj5 == null)
				{
					EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj5;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					if (action == null)
					{
						throw new InvalidCastException();
					}
					EnemyInstantiator.OnRemoteEnemySpawned = action;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag3 = obj6 == null;
				}
				base.Despawn();
				return;
			}
		}
		goto IL_0362;
		IL_0362:
		throw new NullReferenceException();
	}

	public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
	{
		//IL_015a: Expected O, but got I4
		List<EnemyController> meattList = _meattList;
		if (meattList._size >= 50)
		{
			int num = meattList._size - 1;
			HitVfxType hitVfxType = showHitVfx;
			object obj;
			do
			{
				List<EnemyController> meattList2 = _meattList;
				bool flag;
				if (num < meattList2._size)
				{
					EnemyController[] items = meattList2._items;
					EnemyController enemyController = items[num];
					if ((object)items[num] != null && ((UnityEngine.Object)enemyController).m_CachedPtr != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v80+260]");
						flag = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rax_v80+260]");
						if ((nint)0 == 0)
						{
							goto IL_0141;
						}
					}
					flag = (nint)_meattList < 0;
					_meattList.RemoveAt(num);
					hitVfxType = HitVfxType.None;
					goto IL_0141;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
				IL_0141:
				num--;
				obj = !flag;
			}
			while (obj != null);
			List<EnemyController> meattList3 = _meattList;
			if (meattList3._size >= 50)
			{
				return;
			}
		}
		GameManager core = GM.Core;
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
		EnemyController enemy = default(EnemyController);
		OnMeatSpawned(enemy);
		EnemySusBossTentacle leftTentacle = _leftTentacle;
		if ((object)_leftTentacle != null && ((UnityEngine.Object)leftTentacle).m_CachedPtr != (IntPtr)0)
		{
			EnemySusBossTentacle leftTentacle2 = _leftTentacle;
			if (!((EnemyController)leftTentacle2)._003CIsDead_003Ek__BackingField)
			{
				return;
			}
		}
		EnemySusBossTentacle leftTentacle3 = _leftTentacle2;
		if ((object)_leftTentacle2 != null && ((UnityEngine.Object)leftTentacle3).m_CachedPtr != (IntPtr)0)
		{
			EnemySusBossTentacle leftTentacle4 = _leftTentacle2;
			if (!((EnemyController)leftTentacle4)._003CIsDead_003Ek__BackingField)
			{
				return;
			}
		}
		EnemySusBossTentacle rightTentacle = _rightTentacle;
		if ((object)_rightTentacle != null && ((UnityEngine.Object)rightTentacle).m_CachedPtr != (IntPtr)0)
		{
			EnemySusBossTentacle rightTentacle2 = _rightTentacle;
			if (!((EnemyController)rightTentacle2)._003CIsDead_003Ek__BackingField)
			{
				return;
			}
		}
		EnemySusBossTentacle rightTentacle3 = _rightTentacle2;
		if ((object)_rightTentacle2 != null && ((UnityEngine.Object)rightTentacle3).m_CachedPtr != (IntPtr)0)
		{
			EnemySusBossTentacle rightTentacle4 = _rightTentacle2;
			if (!((EnemyController)rightTentacle4)._003CIsDead_003Ek__BackingField)
			{
				return;
			}
		}
		WeaponType damageType2 = default(WeaponType);
		bool hasKb2 = default(bool);
		base.GetDamaged(value, showHitVfx, damageKb, damageType2, hasKb2);
	}

	private unsafe void OnMeatSpawned(EnemyController enemy)
	{
		//IL_0012: Expected O, but got I8
		//IL_023c: Expected O, but got I
		//IL_08ce: Expected O, but got I4
		//IL_02a2: Expected O, but got I8
		//IL_07b4: Expected I, but got O
		//IL_0307: Expected O, but got I
		//IL_0364: Expected I, but got I8
		//IL_044f: Expected O, but got Ref
		//IL_05b6: Invalid comparison between F4 and O
		//IL_05d4: Invalid comparison between F4 and I4
		//IL_05fd: Expected O, but got I4
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Expected O, but got Unknown
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected O, but got Unknown
		//IL_08fc: Expected O, but got I4
		//IL_090c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Expected O, but got Unknown
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected I4, but got Unknown
		//IL_06ba: Expected O, but got Ref
		//IL_0369->IL07eb: Incompatible stack heights: 1 vs 0
		//IL_0887->IL0711: Incompatible stack heights: 1 vs 0
		//IL_0580->IL0711: Incompatible stack heights: 1 vs 0
		//IL_061a->IL0711: Incompatible stack heights: 1 vs 0
		//IL_064a->IL0711: Incompatible stack heights: 1 vs 0
		//IL_068c->IL0711: Incompatible stack heights: 1 vs 0
		//IL_06db->IL0710: Incompatible stack heights: 1 vs 0
		//IL_0700->IL0710: Incompatible stack heights: 1 vs 0
		//IL_0710->IL0710: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass12_0 CS_0024_003C_003E8__locals36 = new _003C_003Ec__DisplayClass12_0();
		float num6;
		Vector3 ret;
		Sequence sequence;
		TweenCallback signalBus;
		if (CS_0024_003C_003E8__locals36 != null)
		{
			object obj = 6603577472L;
			CS_0024_003C_003E8__locals36.enemy = enemy;
			EnemyController enemy2 = CS_0024_003C_003E8__locals36.enemy;
			if ((object)CS_0024_003C_003E8__locals36.enemy == null || ((UnityEngine.Object)enemy2).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			if ((object)CS_0024_003C_003E8__locals36.enemy != null)
			{
				CS_0024_003C_003E8__locals36.enemy.enabled = false;
				EnemyController enemy3 = CS_0024_003C_003E8__locals36.enemy;
				if ((object)CS_0024_003C_003E8__locals36.enemy != null)
				{
					BaseBody baseBody = enemy3.body;
					if (enemy3.body != null)
					{
						baseBody._enable = false;
						EnemyController enemy4 = CS_0024_003C_003E8__locals36.enemy;
						if ((object)CS_0024_003C_003E8__locals36.enemy != null)
						{
							((ArcadeSprite)CS_0024_003C_003E8__locals36.enemy).CheckRenderer();
							if ((object)((ArcadeSprite)enemy4)._spriteRenderer != null)
							{
								((ArcadeSprite)enemy4)._spriteRenderer.sortingOrder = 2000;
								EnemyController enemy5 = CS_0024_003C_003E8__locals36.enemy;
								if ((object)CS_0024_003C_003E8__locals36.enemy != null)
								{
									enemy5._003CIsCullable_003Ek__BackingField = false;
									EnemyController enemy6 = CS_0024_003C_003E8__locals36.enemy;
									if ((object)CS_0024_003C_003E8__locals36.enemy != null)
									{
										enemy6._003CIsTeleportOnCull_003Ek__BackingField = false;
										if (_meattList != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FE520");
											float2 float5 = base.position;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											object obj2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											bool flag = (nint)0 != 0;
											ArcadeSprite arcadeSprite = this;
											if (!flag)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												if (obj2 == null)
												{
													MissingMethodException ex = new MissingMethodException();
													throw ex;
												}
												arcadeSprite = (ArcadeSprite)6573110936L;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1031 @ rax_v36 (should have been resolved before IL gen)");
											object obj3 = UnityEngine.Random.RandomRangeInt(0, 2);
											float num = ((obj3 != null) ? (-1f) : 1f);
											if ((object)GM.Core != null)
											{
												nint num2 = (nint)typeof(ArcadePhysics);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1096 @ rax_v43 (Il2CppClass<ArcadePhysics>)+B8]");
												nint num3 = 0;
												PhaserScene s_scene = ArcadePhysics.s_scene;
												if (ArcadePhysics.s_scene != null)
												{
													PhaserScene.Renderer renderer = s_scene._renderer;
													if (s_scene._renderer != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
														object obj4 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
														if ((nint)0 == 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
															bool flag2 = obj4 == null;
															num3 = unchecked((nint)6573110936L);
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1108 @ rax_v47 (should have been resolved before IL gen)");
														if ((object)GM.Core != null)
														{
															PhaserScene s_scene2 = ArcadePhysics.s_scene;
															if (ArcadePhysics.s_scene != null && s_scene2._renderer != null)
															{
																float num4 = 0.2f * num;
																float num5 = num4 * renderer.width;
																num6 = (float)float5 + num5;
																if ((object)CS_0024_003C_003E8__locals36.enemy != null)
																{
																	Transform transform = CS_0024_003C_003E8__locals36.enemy.transform;
																	if ((object)transform != null)
																	{
																		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
																		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
																		if ((object)CS_0024_003C_003E8__locals36.enemy != null)
																		{
																			Transform target = CS_0024_003C_003E8__locals36.enemy.transform;
																			float duration = default(float);
																			bool snapping = default(bool);
																			sequence = ShortcutExtensions.DOJump(target, (Vector3)(&ret), 1f, 1, duration, snapping);
																			if (sequence != null && ((Tween)sequence)._003Cactive_003Ek__BackingField)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
																				bool flag4 = (nint)0 == 0;
																				sequence.stringId = "DefaultGameTweenId";
																				if (!flag4)
																				{
																					object obj5 = sequence + 56;
																					object obj6 = obj5 >> 12;
																					object obj7 = obj6 & 0x1FFFFF;
																					object obj8 = obj7 >> 6;
																					object obj9 = obj7 & 0x3F;
																					nint num8;
																					do
																					{
																						object obj10 = 1 << (int)obj9;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v7+462E0+v1241 @ rdx_v37*8]");
																						object obj11 = 0 | obj10;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v7+462E0+v1241 @ rdx_v37*8]");
																						nint num7 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v7+462E0+v1241 @ rdx_v37*8]");
																						if (num7 == 0)
																						{
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v7+462E0+v1241 @ rdx_v37*8]");
																						num8 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ r14_v7+462E0+v1241 @ rdx_v37*8]");
																					}
																					while (num8 != 0);
																					TweenCallback tweenCallback = delegate
																					{
																						//IL_00dd->IL0110: Incompatible stack heights: 1 vs 0
																						Transform enemy8 = (Transform)(object)CS_0024_003C_003E8__locals36.enemy;
																						if ((object)CS_0024_003C_003E8__locals36.enemy != null && ((UnityEngine.Object)enemy8).m_CachedPtr != (IntPtr)0)
																						{
																							Behaviour enemy9 = CS_0024_003C_003E8__locals36.enemy;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (UnityEngine.Behaviour)+28]");
																							if ((nint)0 != 0)
																							{
																								enemy9.enabled = true;
																								EnemyController enemy10 = CS_0024_003C_003E8__locals36.enemy;
																								BaseBody baseBody2 = enemy10.body;
																								baseBody2._enable = true;
																								Transform transform2 = CS_0024_003C_003E8__locals36.enemy.transform;
																								bool flag11 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																								Quaternion value = default(Quaternion);
																								Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
																								EnemyController enemy11 = CS_0024_003C_003E8__locals36.enemy;
																								enemy11._003CIsCullable_003Ek__BackingField = true;
																							}
																						}
																					};
																					signalBus = tweenCallback;
																					goto IL_0585;
																				}
																			}
																			TweenCallback tweenCallback2 = delegate
																			{
																				//IL_00dd->IL0110: Incompatible stack heights: 1 vs 0
																				Transform enemy8 = (Transform)(object)CS_0024_003C_003E8__locals36.enemy;
																				if ((object)CS_0024_003C_003E8__locals36.enemy != null && ((UnityEngine.Object)enemy8).m_CachedPtr != (IntPtr)0)
																				{
																					Behaviour enemy9 = CS_0024_003C_003E8__locals36.enemy;
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v8 (UnityEngine.Behaviour)+28]");
																					if ((nint)0 != 0)
																					{
																						enemy9.enabled = true;
																						EnemyController enemy10 = CS_0024_003C_003E8__locals36.enemy;
																						BaseBody baseBody2 = enemy10.body;
																						baseBody2._enable = true;
																						Transform transform2 = CS_0024_003C_003E8__locals36.enemy.transform;
																						bool flag11 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
																						Quaternion value = default(Quaternion);
																						Transform.set_rotation_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
																						EnemyController enemy11 = CS_0024_003C_003E8__locals36.enemy;
																						enemy11._003CIsCullable_003Ek__BackingField = true;
																					}
																				}
																			};
																			bool flag5 = sequence == null;
																			signalBus = tweenCallback2;
																			if (!flag5)
																			{
																				goto IL_0585;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0711;
		IL_0711:
		throw new NullReferenceException();
		IL_0585:
		((EnemyController)(object)sequence)._signalBus = (SignalBus)(object)signalBus;
		float2 float6 = base.position;
		EnemyController enemy7 = CS_0024_003C_003E8__locals36.enemy;
		bool flag6 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6) < System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6);
		float num9 = num6 - (float)float6;
		bool flag7 = num9 == 0f;
		bool flag8 = !flag6;
		bool flag9 = !flag7;
		object obj12 = flag9 & flag8;
		if ((object)CS_0024_003C_003E8__locals36.enemy != null)
		{
			((ArcadeSprite)CS_0024_003C_003E8__locals36.enemy).CheckRenderer();
			if ((object)((ArcadeSprite)enemy7)._spriteRenderer != null)
			{
				bool flag10 = (byte)(obj12 ^ 1) != 0;
				((ArcadeSprite)enemy7)._spriteRenderer.flipX = flag10;
				if ((object)CS_0024_003C_003E8__locals36.enemy != null)
				{
					Transform target2 = CS_0024_003C_003E8__locals36.enemy.transform;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target2, (Vector3)(&ret), 0.5f, RotateMode.LocalAxisAdd);
					if (tweenerCore != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ rax_v67 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					return;
				}
			}
		}
		goto IL_0711;
	}
}
