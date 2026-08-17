using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class Unused_TP_AlchemyWhipTween_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int localIndex;

		public Unused_TP_AlchemyWhipTween_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_00c2: Expected O, but got I4
			//IL_006f->IL008b: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					if ((object)_003C_003E4__this != null)
					{
						_003C_003E4__this.ShiftWhipForce(localIndex);
						return;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private int _iterations;

	private int _totalNodes;

	private VerletTweenNode[] _nodes;

	private Projectile[] _whipProjectiles;

	private List<List<Vector2>> _splineList;

	private float _flipNum;

	private float _tempArea;

	private bool _applyTipControl;

	private float2 _gravity;

	private float _nodeDistance;

	private int _splineIndex;

	private MultiTargetTween _lerpTween;

	private float _waypointTotalDist;

	private float2 _characterOffset;

	private Timer _resetTimer;

	public unsafe override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_0077: Expected I, but got O
		//IL_0214: Expected O, but got I
		//IL_03b3: Expected O, but got F4
		//IL_00f2: Expected I, but got O
		//IL_025e: Expected O, but got I
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected O, but got Unknown
		//IL_04da: Expected O, but got F4
		//IL_029d: Expected O, but got I4
		//IL_0166->IL0300: Incompatible stack heights: 1 vs 0
		//IL_0576->IL0300: Incompatible stack heights: 1 vs 0
		//IL_01bd->IL0300: Incompatible stack heights: 2 vs 0
		//IL_01f4->IL0300: Incompatible stack heights: 2 vs 0
		//IL_0234->IL0300: Incompatible stack heights: 2 vs 0
		//IL_03d1->IL0300: Incompatible stack heights: 3 vs 0
		//IL_0115->IL0115: Incompatible stack heights: 4 vs 3
		//IL_0466->IL0300: Incompatible stack heights: 3 vs 0
		//IL_040d->IL0519: Incompatible stack heights: 4 vs 1
		//IL_0412->IL0142: Incompatible stack heights: 4 vs 1
		//IL_027e->IL0300: Incompatible stack heights: 3 vs 0
		//IL_0514->IL0300: Incompatible stack heights: 4 vs 0
		//IL_02ec->IL0300: Incompatible stack heights: 5 vs 0
		WeaponType weaponType2 = default(WeaponType);
		base.InitWeapon(characterController, weaponType2);
		VerletTweenNode[] nodes = new VerletTweenNode[_totalNodes];
		_nodes = nodes;
		Projectile[] whipProjectiles = new Projectile[_totalNodes];
		_whipProjectiles = whipProjectiles;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			bool flag2 = _totalNodes <= 0;
			Transform transform2 = null;
			if (flag2)
			{
				goto IL_0142;
			}
			Transform transform3 = null;
			WeaponType weaponType3 = WeaponType.VOID;
			WeaponType weaponType4 = weaponType2;
			float num = default(float);
			object obj = default(object);
			object obj2 = default(object);
			while (true)
			{
				VerletTweenNode[] nodes2 = _nodes;
				VerletTweenNode verletTweenNode = null;
				verletTweenNode.posX = ret;
				verletTweenNode.posY = num;
				verletTweenNode.oldX = ret;
				verletTweenNode.oldY = num;
				if (_nodes == null)
				{
					break;
				}
				nint num2 = (nint)nodes2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag3 = obj == null;
				bool flag4 = (int)weaponType3 >= nodes2.Length;
				nodes2[(int)weaponType3] = verletTweenNode;
				transform2 = _targetTransform;
				Transform whipProjectiles2 = (Transform)(object)_whipProjectiles;
				Projectile projectile = base.FireOneProjectile((Vector2)ret, (int)weaponType3, _targetTransform);
				if (_whipProjectiles == null)
				{
					break;
				}
				if ((object)projectile != null)
				{
					nint num3 = (nint)whipProjectiles2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag5 = obj2 == null;
				}
				WeaponType num4 = weaponType3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rbx_v21 (UnityEngine.Transform)+18]");
				bool flag6 = (nint)num4 >= (nint)0;
				weaponType3++;
				bool flag7 = (int)weaponType3 < _totalNodes;
				transform3 = transform2;
				weaponType4 = weaponType3;
				if (flag7)
				{
					continue;
				}
				goto IL_0142;
			}
		}
		goto IL_0300;
		IL_0300:
		throw new NullReferenceException();
		IL_0142:
		VerletTweenNode[] nodes3 = _nodes;
		if (_nodes != null)
		{
			bool flag8 = nodes3.Length <= 0;
			VerletTweenNode verletTweenNode2 = nodes3[0];
			if (nodes3[0] != null)
			{
				verletTweenNode2.isStatic = true;
				Transform transform4 = (Transform)(object)((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rbx_v14 (UnityEngine.Transform)+48]");
					Transform transform5 = (Transform)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rbx_v14 (UnityEngine.Transform)+48]");
					if ((nint)0 != 0)
					{
						bool flag9 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
						SpriteRenderer.get_size_Injected(((UnityEngine.Object)transform5).m_CachedPtr, out Vector2 ret2);
						Transform transform6 = (Transform)(object)((Equipment)this)._003COwner_003Ek__BackingField;
						if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
						{
							((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CheckRenderer();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rbx_v16 (UnityEngine.Transform)+48]");
							Transform transform7 = (Transform)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rbx_v16 (UnityEngine.Transform)+48]");
							if ((nint)0 != 0)
							{
								bool flag10 = ((UnityEngine.Object)transform7).m_CachedPtr == (IntPtr)0;
								SpriteRenderer.get_size_Injected(((UnityEngine.Object)transform7).m_CachedPtr, out Vector2 _);
								Vector2 vector = ret2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
								object obj3 = vector ^ 0;
								float num5 = (float)obj3 * 0.1f;
								object obj4 = default(object);
								float num6 = (float)obj4 * 0.5f;
								_characterOffset = (float2)num5;
								updateScale();
								VerletTweenNode[] nodes4 = _nodes;
								_applyTipControl = false;
								if (_nodes != null)
								{
									object obj5 = nodes4.Length - 1;
									bool flag11 = (nint)obj5 >= nodes4.Length;
									VerletTweenNode verletTweenNode3 = nodes4[obj5];
									if (nodes4[obj5] != null)
									{
										verletTweenNode3.isStatic = false;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0300;
	}

	private void updateScale()
	{
		//IL_0060: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_00b7: Expected O, but got I4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		float num = base.PArea();
		float num2 = default(float);
		_tempArea = num2;
		float num3 = base.PArea();
		float num4 = num2 * 0.04f;
		Projectile[] whipProjectiles = _whipProjectiles;
		float num5 = (_nodeDistance = num4 + 0.04f);
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < whipProjectiles.Length)
		{
			Projectile[] whipProjectiles2 = _whipProjectiles;
			float num6 = base.PArea();
			num5 += 4f;
			ArcadeSprite arcadeSprite = whipProjectiles2[obj].setScale(num5, (float?)(object)0);
			whipProjectiles = _whipProjectiles;
			obj++;
			obj2 = obj;
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01e3: Invalid comparison between O and F4
		//IL_009a: Invalid comparison between F4 and I4
		//IL_0196: Invalid comparison between F4 and I4
		float num = base.PArea();
		float num2 = default(float);
		bool flag = _tempArea == num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187483B43h\"");
		if (!flag)
		{
			updateScale();
		}
		ShiftWhipForce(0);
		float num3 = base.PAmount();
		if (num2 > 1f)
		{
			float num4 = base.PAmount();
			if (num2 > 1f)
			{
				int num5 = 1;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				do
				{
					WeaponData currentWeaponData = _currentWeaponData;
					num2 = (float)num5 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					if (!(num2 > 0f))
					{
						ShiftWhipForce(num5);
					}
					else
					{
						_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass17_0();
						CS_0024_003C_003E8__locals7._003C_003E4__this = this;
						CS_0024_003C_003E8__locals7.localIndex = num5;
						WeaponData currentWeaponData2 = _currentWeaponData;
						Action onComplete = delegate
						{
							//IL_00c2: Expected O, but got I4
							//IL_006f->IL008b: Incompatible stack heights: 1 vs 0
							if ((object)CS_0024_003C_003E8__locals7._003C_003E4__this != null)
							{
								GameObject gameObject = CS_0024_003C_003E8__locals7._003C_003E4__this.gameObject;
								if ((object)gameObject != null)
								{
									bool flag2 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									object obj2 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
									if (obj2 == null)
									{
										return;
									}
									if ((object)CS_0024_003C_003E8__locals7._003C_003E4__this != null)
									{
										CS_0024_003C_003E8__locals7._003C_003E4__this.ShiftWhipForce(CS_0024_003C_003E8__locals7.localIndex);
										return;
									}
								}
							}
							throw new NullReferenceException();
						};
						float num6 = (float)num5 * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
						num2 = num6 * 0.001f;
						Timer lastShotTimer = Timers.Register(num2, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
						_lastShotTimer = lastShotTimer;
					}
					num5++;
					float num7 = base.PAmount();
				}
				while (num2 > (float)num5);
			}
		}
		float num8 = base.PInterval();
		float num9 = _lastFiringInterval - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num9 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num10 = base.PInterval();
			_lastFiringInterval = num2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	private unsafe void ShiftWhipForce(int index)
	{
		//IL_0105: Expected O, but got I4
		//IL_054f: Expected I, but got O
		//IL_0565: Expected O, but got I
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		//IL_05e9: Expected I, but got O
		//IL_04e7: Expected O, but got I4
		//IL_04f5: Expected O, but got I4
		//IL_082c: Expected O, but got I4
		//IL_0867: Expected I, but got I8
		//IL_05c5: Expected I, but got I8
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Expected O, but got Unknown
		//IL_0338: Expected I, but got O
		//IL_008a->IL073a: Incompatible stack heights: 1 vs 0
		//IL_00d4->IL073a: Incompatible stack heights: 1 vs 0
		//IL_0801->IL073a: Incompatible stack heights: 1 vs 0
		//IL_0137->IL073a: Incompatible stack heights: 1 vs 0
		//IL_0171->IL073a: Incompatible stack heights: 1 vs 0
		//IL_019d->IL073a: Incompatible stack heights: 1 vs 0
		//IL_062f->IL073a: Incompatible stack heights: 1 vs 0
		//IL_0679->IL073a: Incompatible stack heights: 1 vs 0
		//IL_08ea->IL073a: Incompatible stack heights: 2 vs 0
		//IL_01e3->IL073a: Incompatible stack heights: 2 vs 0
		//IL_06b0->IL073a: Incompatible stack heights: 1 vs 0
		//IL_024b->IL073a: Incompatible stack heights: 3 vs 0
		//IL_06df->IL073a: Incompatible stack heights: 1 vs 0
		//IL_02bc->IL073a: Incompatible stack heights: 3 vs 0
		//IL_0739->IL073a: Incompatible stack heights: 1 vs 0
		//IL_032b->IL073a: Incompatible stack heights: 3 vs 0
		//IL_037d->IL073a: Incompatible stack heights: 4 vs 0
		//IL_03c5->IL073a: Incompatible stack heights: 4 vs 0
		//IL_0472->IL073a: Incompatible stack heights: 4 vs 0
		//IL_049c->IL07bc: Incompatible stack heights: 4 vs 1
		List<List<Vector2>> splineList = _splineList;
		if (_splineList != null)
		{
			int num = (_splineIndex = index % splineList._size);
			if (_splineList != null)
			{
				bool flag = num >= splineList._size;
				List<Vector2>[] items = splineList._items;
				if (splineList._items != null)
				{
					float num2 = MultiDistance(items[num]);
					VerletTweenNode[] nodes = _nodes;
					_waypointTotalDist = num2;
					if (_nodes != null)
					{
						float num3 = 1f / (float)nodes.Length;
						bool flag2 = false;
						float num4 = num3;
						object obj = 0;
						bool flag3 = false;
						object obj3 = default(object);
						object obj4 = default(object);
						object obj5 = default(object);
						object obj6 = default(object);
						bool useRealTime = default(bool);
						MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
						int repeat = default(int);
						TimerType type = default(TimerType);
						while (true)
						{
							if ((flag3 ? 1 : 0) < nodes.Length)
							{
								VerletTweenNode[] nodes2 = _nodes;
								if (_nodes == null)
								{
									break;
								}
								ArcadeSprite arcadeSprite = ((Equipment)this)._003COwner_003Ek__BackingField;
								VerletTweenNode verletTweenNode = nodes2[flag2 ? 1u : 0u];
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
								{
									break;
								}
								Transform cachedTrans = ((ArcadeSprite)((Equipment)this)._003COwner_003Ek__BackingField).CachedTrans;
								if ((object)cachedTrans == null)
								{
									break;
								}
								bool flag4 = ((UnityEngine.Object)cachedTrans).m_CachedPtr == (IntPtr)0;
								float2 ret;
								Transform.get_position_Injected(((UnityEngine.Object)cachedTrans).m_CachedPtr, out *(Vector3*)(&ret));
								if (arcadeSprite.body != null)
								{
									BaseBody body = arcadeSprite.body;
									ArcadeTransform arcadeTransform = body._transform;
									if (body._transform == null)
									{
										break;
									}
									arcadeTransform.position = ret;
								}
								List<List<Vector2>> splineList2 = _splineList;
								int splineIndex = _splineIndex;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.Unused_TP_AlchemyWhipTween_Weapon)+1A8]");
								object obj2 = obj3 + 0;
								if (_splineList == null)
								{
									break;
								}
								bool flag5 = _splineIndex >= splineList2._size;
								List<Vector2>[] items2 = splineList2._items;
								if (splineList2._items == null)
								{
									break;
								}
								float2 float5 = MultiLerp(items2[splineIndex], num4);
								num2 = (float)float5 * _flipNum;
								float num5 = (float)obj4 * -1f;
								float num6 = (float)obj2 + num5;
								if (nodes2[flag2 ? 1u : 0u] == null)
								{
									break;
								}
								if (verletTweenNode.tween != null)
								{
									verletTweenNode.tween.Kill();
								}
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								if (array == null)
								{
									break;
								}
								nint num7 = (nint)array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								bool flag6 = obj5 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								if (tweenConfig == null)
								{
									break;
								}
								tweenConfig.targets = array;
								Dictionary<string, object> dictionary = new Dictionary<string, object>();
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								if (dictionary == null)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804789A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804789A0");
								tweenConfig.custom = dictionary;
								tweenConfig.duration = 500f;
								MultiTargetTween tween = Tweens.Add(tweenConfig);
								verletTweenNode.tween = tween;
								nodes = _nodes;
								flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
								float num8 = num4 + num3;
								if (_nodes == null)
								{
									break;
								}
								float num9 = num6;
								num4 = num8;
								obj = obj6;
								flag3 = flag2;
								continue;
							}
							if (_resetTimer != null)
							{
								Timer resetTimer = _resetTimer;
								if (!_resetTimer.IsDone)
								{
									num2 = _resetTimer.GetTimeElapsed();
									resetTimer._timeElapsedBeforeCancel = (float?)(object)1;
									resetTimer._timeElapsedBeforePause = (float?)(object)0;
								}
							}
							WeaponData currentWeaponData = _currentWeaponData;
							if (_currentWeaponData == null)
							{
								break;
							}
							float num10 = base.PAmount();
							Action action = null;
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ r10_v7 (Il2CppMethodInfo)+8]");
							((Delegate)action).method_ptr = (IntPtr)0;
							((Delegate)action).method = (nint)__ldftn(Unused_TP_AlchemyWhipTween_Weapon._003CShiftWhipForce_003Eb__18_0);
							((Delegate)action).m_target = this;
							((Delegate)action).method_code = (IntPtr)action;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ r10_v7 (Il2CppMethodInfo)+4C]");
							object obj7 = (nint)0 >> 4;
							object obj8 = obj7 & 1;
							nint num12;
							if (obj8 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ r10_v7 (Il2CppMethodInfo)+52]");
								if ((nint)0 == 0)
								{
									num12 = unchecked((nint)6447293664L);
									goto IL_0823;
								}
							}
							num12 = ((Delegate)action).method_ptr;
							((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
							goto IL_0823;
							IL_0823:
							object obj9 = 24;
							float num13 = num2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
							float duration = num13 * 0.001f;
							((Delegate)action).extra_arg = unchecked((nint)6447293568L);
							Timer resetTimer2 = Timers.Register(duration, action, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							_resetTimer = resetTimer2;
							Projectile[] whipProjectiles = _whipProjectiles;
							_applyTipControl = true;
							bool flag7 = _whipProjectiles == null;
							bool flag8 = false;
							bool flag9 = false;
							if (flag7)
							{
								break;
							}
							bool flag10;
							do
							{
								if ((flag8 ? 1 : 0) < whipProjectiles.Length)
								{
									Projectile[] whipProjectiles2 = _whipProjectiles;
									if (_whipProjectiles == null)
									{
										break;
									}
									Projectile projectile = whipProjectiles2[flag9 ? 1u : 0u];
									if ((object)whipProjectiles2[flag9 ? 1u : 0u] == null)
									{
										break;
									}
									BaseBody body2 = projectile.body;
									if (projectile.body == null)
									{
										break;
									}
									flag9 = (byte)((flag9 ? 1u : 0u) + 1u) != 0;
									body2._enable = true;
									whipProjectiles = _whipProjectiles;
									flag10 = _whipProjectiles != null;
									flag8 = flag9;
									continue;
								}
								return;
							}
							while (flag10);
							break;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void bodyEnabled(bool enable)
	{
		//IL_0022: Expected O, but got I4
		//IL_002b: Expected O, but got I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		Projectile[] whipProjectiles = _whipProjectiles;
		Projectile[] whipProjectiles2 = _whipProjectiles;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj < whipProjectiles.Length)
		{
			Projectile projectile = whipProjectiles2[obj2];
			BaseBody body = projectile.body;
			obj2++;
			body._enable = enable;
			whipProjectiles2 = _whipProjectiles;
			obj = obj2;
			whipProjectiles = _whipProjectiles;
		}
	}

	public override void InternalUpdate()
	{
		//IL_0028: Expected O, but got I4
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_00c8: Expected O, but got I4
		//IL_00d1: Expected O, but got I4
		//IL_0094: Expected O, but got F4
		//IL_00b1: Expected O, but got I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		base.InternalUpdate();
		bool flipX = ((Equipment)this)._003COwner_003Ek__BackingField.flipX;
		object obj = (flipX ? 1 : 0) ^ 1;
		object obj2 = obj * 2;
		float flipNum = (float)obj2 - 1f;
		_flipNum = flipNum;
		if (!_applyTipControl)
		{
			Simulate();
			float num = _flipNum * -5f;
			_gravity = (float2)num;
			bool flag = _iterations <= 0;
			object obj3 = 0;
			if (!flag)
			{
				do
				{
					ApplyConstraints();
					obj3++;
				}
				while ((nint)obj3 < _iterations);
			}
		}
		VerletTweenNode[] nodes = _nodes;
		object obj4 = 0;
		object obj5 = 0;
		float2 position = default(float2);
		while ((nint)obj5 < nodes.Length)
		{
			Projectile[] whipProjectiles = _whipProjectiles;
			whipProjectiles[obj4].position = position;
			obj4++;
			obj5 = obj4;
			nodes = _nodes;
		}
	}

	private void Simulate()
	{
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		//IL_00ff: Expected I, but got O
		VerletTweenNode[] nodes = _nodes;
		object obj = 0;
		object obj2 = 0;
		object obj3 = default(object);
		object obj4 = default(object);
		float num11 = default(float);
		while ((nint)obj < nodes.Length)
		{
			VerletTweenNode[] nodes2 = _nodes;
			VerletTweenNode verletTweenNode = nodes2[obj2];
			if (!verletTweenNode.isStatic)
			{
				VerletTweenNode[] nodes3 = _nodes;
				VerletTweenNode verletTweenNode2 = nodes3[obj2];
				VerletTweenNode verletTweenNode3 = nodes3[obj2];
				VerletTweenNode verletTweenNode4 = nodes3[obj2];
				float num = verletTweenNode2.posX - verletTweenNode4.oldX;
				nint num2 = (nint)nodes3[obj2];
				float num3 = verletTweenNode3.posY;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v2 (Il2CppMethodInfo)+1C]");
				float num4 = num3 - 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45AC0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184B45AC0");
				float num5 = (float)obj3 * (float)obj4;
				float num6 = (float)_gravity * num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Weapons.Unused_TP_AlchemyWhipTween_Weapon)+188]");
				float num7 = 0f * num5;
				float num8 = num6 + num;
				float num9 = num7 + num4;
				float posX = num8 + verletTweenNode.posX;
				verletTweenNode.posX = posX;
				float num10 = (verletTweenNode.posY = num9 + verletTweenNode.posY);
				if (!_applyTipControl)
				{
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					bool flag = !(num11 > num10);
					num5 = num11;
					if (!flag)
					{
						float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						verletTweenNode.posY = num11;
						num5 = num11;
					}
				}
				verletTweenNode.oldX = verletTweenNode2.posX;
				verletTweenNode.oldY = verletTweenNode3.posY;
			}
			nodes = _nodes;
			obj2++;
			obj = obj2;
		}
	}

	private void ApplyConstraints()
	{
		//IL_004a: Expected O, but got I4
		//IL_0053: Expected O, but got I4
		//IL_0345: Expected O, but got I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0275: Expected I, but got O
		//IL_0167: Expected F4, but got I4
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		VerletTweenNode[] nodes = _nodes;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			object obj3 = nodes.Length - 1;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
			{
				VerletTweenNode[] nodes2 = _nodes;
				object obj4 = obj2 + 1;
				VerletTweenNode verletTweenNode = nodes2[obj2];
				VerletTweenNode verletTweenNode2 = nodes2[obj4];
				float num = verletTweenNode.posY - verletTweenNode2.posY;
				nint num2 = (nint)typeof(Math);
				float num3 = verletTweenNode.posX - verletTweenNode2.posX;
				float num4 = verletTweenNode.posY - verletTweenNode2.posY;
				float num5 = num4 * num4;
				float num6 = num3 * num3;
				double d = (double)num5 + (double)num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v7 (Il2CppClass<System.Math>)+E4]");
				if ((nint)0 <= (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
				}
				else
				{
					double num7 = Math.Sqrt(d);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm3,xmm0\"");
				bool flag = 0 <= 0;
				float num8 = 0f;
				if (!flag)
				{
					VerletTweenNode[] nodes3 = _nodes;
					float num9 = _nodeDistance / (float)nodes3.Length;
					float num10 = num9 * (float)obj2;
					float num11 = num10 + 0.02f;
					num8 = num11 / 0f;
				}
				float num12 = verletTweenNode.posX - verletTweenNode2.posX;
				float num13 = num8 * 0.5f;
				float num14 = num13 * num;
				float num15 = num13 * num12;
				if (!verletTweenNode.isStatic)
				{
					float posX = num15 + verletTweenNode.posX;
					verletTweenNode.posX = posX;
					float posY = num14 + verletTweenNode.posY;
					verletTweenNode.posY = posY;
				}
				if (!verletTweenNode2.isStatic)
				{
					float posX2 = verletTweenNode2.posX - num15;
					verletTweenNode2.posX = posX2;
					float posY2 = verletTweenNode2.posY - num14;
					verletTweenNode2.posY = posY2;
				}
				nodes = _nodes;
				obj2++;
				obj = obj2;
				continue;
			}
			break;
		}
	}

	public float2 MultiLerp(List<Vector2> waypoints, float ratio)
	{
		//IL_0303: Expected O, but got I4
		//IL_030c: Expected O, but got I4
		//IL_031d: Expected O, but got I4
		//IL_0114: Expected O, but got I
		//IL_011c: Expected I4, but got O
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0050: Expected O, but got I
		//IL_026c: Expected O, but got I
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected I4, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_029b: Expected O, but got I4
		//IL_00b2: Invalid comparison between O and F4
		//IL_00c0: Expected I4, but got O
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_01cc: Expected O, but got I4
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0245: Expected O, but got I4
		//IL_0251: Expected O, but got I4
		float num = ratio * _waypointTotalDist;
		object obj = 0;
		object obj2 = 0;
		List<Vector2> list = waypoints;
		object obj3 = 0;
		object obj9 = default(object);
		int index;
		List<Vector2> list2 = default(List<Vector2>);
		while (true)
		{
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj4 < 0)
			{
				object obj5 = obj2 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj6 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					object obj7 = obj2 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
					object obj8 = obj9 + obj;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num);
					index = (int)list2;
					if (flag)
					{
						break;
					}
					obj2++;
					obj += obj9;
					list = list2;
					obj3 = obj2;
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			obj2 = -1;
			index = (int)list;
			break;
		}
		object obj10 = obj2 + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		int num3 = default(int);
		if ((nint)obj10 < 0)
		{
			int count = obj2 + 1;
			List<Vector2> range = waypoints.GetRange(index, count);
			float num2 = MultiDistance(range);
			object obj11 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj11 < 0)
			{
				object obj12 = obj2 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)obj12 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
					List<Vector2> range2 = ((List<Vector2>)num3).GetRange(num3, 0);
					object obj13 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					if ((nint)obj13 < 0)
					{
						object obj14 = obj2 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						if ((nint)obj14 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
							List<Vector2> range3 = ((List<Vector2>)num3).GetRange(num3, 0);
							return (float2)num3;
						}
					}
				}
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj15 = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			if ((nint)obj15 < 0)
			{
				return (float2)num3;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float2 result = default(float2);
		return result;
	}

	public static int GetVectorIndexFromDistanceTravelled(List<Vector2> waypoints, float distanceTravelled)
	{
		//IL_0127: Expected I4, but got O
		//IL_000e: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		//IL_0051: Expected O, but got I
		//IL_0085: Expected O, but got I4
		if (waypoints != null)
		{
			object obj = 0;
			int num = 0;
			float num2 = distanceTravelled;
			int num3 = 0;
			object obj5 = default(object);
			while (true)
			{
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				object obj2 = num + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = -1;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				object obj4 = num + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D650");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C24430");
				num2 = (float)obj5 + (float)obj;
				if (!(num2 > distanceTravelled))
				{
					num++;
					obj += obj5;
					num3 = num;
					continue;
				}
				return num;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rcx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			return (int)(-1);
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public float MultiDistance(List<Vector2> waypoints)
	{
		//IL_0219: Expected F4, but got I4
		//IL_0222: Expected O, but got I4
		//IL_0233: Expected O, but got I4
		//IL_02c2: Expected O, but got I
		//IL_0044: Expected O, but got I
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_026d: Expected I, but got O
		//IL_028a: Expected O, but got I
		//IL_02a7: Expected O, but got I
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_01a2: Expected F8, but got I4
		bool flag = waypoints == null;
		float num = 0f;
		object obj = 0;
		double num3 = default(double);
		double num2 = num3;
		object obj2 = 0;
		if (!flag)
		{
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj3 = -1;
				float result;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
				{
					object obj4 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					bool flag2 = (nint)obj4 >= 0;
					result = (float)num2;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						object obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
						bool flag3 = (nint)0 == 0;
						num3 = num2;
						if (flag3)
						{
							break;
						}
						object obj6 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+18]");
						bool flag4 = (nint)obj6 >= 0;
						num3 = num2;
						if (!flag4)
						{
							object obj7 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [waypoints @ rdx (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
							bool flag5 = (nint)obj7 >= 0;
							result = (float)num2;
							if (flag5)
							{
								goto IL_0241;
							}
							object obj8 = obj + 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+18]");
							bool flag6 = (nint)obj8 >= 0;
							num3 = num2;
							if (!flag6)
							{
								nint num4 = (nint)typeof(Math);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+20+v61 @ rbx_v2*8]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+28+v61 @ rbx_v2*8]");
								object obj9 = num5 - 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+24+v61 @ rbx_v2*8]");
								nint num6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v4+2C+v61 @ rbx_v2*8]");
								object obj10 = num6 - 0;
								object obj11 = obj10 * obj10;
								object obj12 = obj9 * obj9;
								double d = (double)obj11 + (double)obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v6 (Il2CppClass<System.Math>)+E4]");
								if ((nint)0 <= (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
									obj++;
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
									num2 = 0.0;
									obj2 = obj;
								}
								else
								{
									num2 = Math.Sqrt(d);
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
									obj++;
									num += (float)num2;
									obj2 = obj;
								}
								continue;
							}
						}
						throw new IndexOutOfRangeException();
					}
					goto IL_0241;
				}
				return num;
				IL_0241:
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return result;
			}
		}
		throw new NullReferenceException();
	}

	public Unused_TP_AlchemyWhipTween_Weapon()
	{
		//IL_0095: Expected O, but got I4
		_iterations = 80;
		_totalNodes = 20;
		List<List<Vector2>> list = new List<List<Vector2>>();
		List<Vector2> list2 = new List<Vector2>();
		list2._002Ector();
		Vector2 item = default(Vector2);
		list2.Add(item);
		list2.Add(item);
		list2.Add(item);
		list2.Add(item);
		list2.Add(item);
		((List<Vector2>)(object)list).Add((Vector2)list2);
		_splineList = list;
		_flipNum = 1f;
		_gravity = (float2)0;
		_ = 3248488448L;
		base._002Ector();
	}

	private void _003CShiftWhipForce_003Eb__18_0()
	{
		_applyTipControl = false;
		bodyEnabled(enable: false);
	}
}
