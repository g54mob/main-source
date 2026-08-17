using System;
using System.Collections;
using System.Collections.Generic;
using Coherence.Toolkit;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.Objects.Characters;

public class FollowerEnemy_CharacterController : CharacterController
{
	private sealed class _003CWaitForEnemyDataForAddAttackAnimations_003Ed__15(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public FollowerEnemy_CharacterController _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0069: Expected I4, but got I8
			//IL_0126: Expected I4, but got O
			FollowerEnemy_CharacterController followerEnemy_CharacterController = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_00c6;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0152;
				}
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)_003C_003E4__this != null)
				{
					followerEnemy_CharacterController._enemyData = core._latestKilledEnemyThatCanBeFollowerData;
					goto IL_00c6;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0152:
			return false;
			IL_00c6:
			if (followerEnemy_CharacterController._enemyData == null)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.AddAttackAnimations();
			goto IL_0152;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitForEnemyDataForMakeLevelOne_003Ed__9(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public FollowerEnemy_CharacterController _003C_003E4__this;

		public bool dontGetCharacterDataForCurrentLevel;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00a2: Expected I4, but got I8
			//IL_0165: Expected I4, but got O
			FollowerEnemy_CharacterController followerEnemy_CharacterController = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)_003C_003E4__this != null)
				{
					followerEnemy_CharacterController._enemyData = core._latestKilledEnemyThatCanBeFollowerData;
					goto IL_00ff;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0191;
				}
				_003C_003E1__state = -1;
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && (object)_003C_003E4__this != null)
				{
					followerEnemy_CharacterController._enemyData = core2._latestKilledEnemyThatCanBeFollowerData;
					goto IL_00ff;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0191:
			return false;
			IL_00ff:
			if (followerEnemy_CharacterController._enemyData == null)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.MakeLevelOne(dontGetCharacterDataForCurrentLevel);
			goto IL_0191;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitForEnemyDataForSetCharacterSprite_003Ed__11(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public FollowerEnemy_CharacterController _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0069: Expected I4, but got I8
			//IL_0126: Expected I4, but got O
			FollowerEnemy_CharacterController followerEnemy_CharacterController = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_00c6;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0152;
				}
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)_003C_003E4__this != null)
				{
					followerEnemy_CharacterController._enemyData = core._latestKilledEnemyThatCanBeFollowerData;
					goto IL_00c6;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0152:
			return false;
			IL_00c6:
			if (followerEnemy_CharacterController._enemyData == null)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.SetCharacterSprite();
			goto IL_0152;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CWaitForEnemyDataForSetupAnimation_003Ed__13(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public FollowerEnemy_CharacterController _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0069: Expected I4, but got I8
			//IL_0126: Expected I4, but got O
			FollowerEnemy_CharacterController followerEnemy_CharacterController = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					goto IL_00c6;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0152;
				}
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				if ((object)GM.Core != null && (object)_003C_003E4__this != null)
				{
					followerEnemy_CharacterController._enemyData = core._latestKilledEnemyThatCanBeFollowerData;
					goto IL_00c6;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0152:
			return false;
			IL_00c6:
			if (followerEnemy_CharacterController._enemyData == null)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			_003C_003E4__this.SetupAnimation();
			goto IL_0152;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private EnemyData _enemyData;

	private Vector3 _OriginalScale;

	public bool HasSetName;

	private bool _needsCart;

	private float _PowerMultiplier = 1f;

	private float _HpMultiplier = 1f;

	public override bool NeedsCart => _needsCart;

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		//IL_00ec: Expected O, but got I4
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_048e: Expected I4, but got O
		//IL_075c: Expected I4, but got O
		//IL_06c6: Expected I4, but got O
		//IL_06d1: Expected I4, but got O
		//IL_0784->IL0727: Incompatible stack heights: 1 vs 0
		GameManager core = GM.Core;
		EggFloat eggFloat;
		float num;
		if ((object)GM.Core != null)
		{
			_enemyData = core._latestKilledEnemyThatCanBeFollowerData;
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				bool flag = _enemyData == null;
				_needsCart = core2._latestKilledEnemyWasCartRider;
				_playDamageSFX = false;
				if (!flag)
				{
					EnemyData enemyData = _enemyData;
					if (enemyData._003CcolliderOverride_003Ek__BackingField != null)
					{
						ColliderOverride colliderOverride = enemyData._003CcolliderOverride_003Ek__BackingField;
						if (body == null)
						{
							goto IL_05b3;
						}
						BaseBody baseBody = body.setOffset(colliderOverride._003CoffsetX_003Ek__BackingField, (float?)(object)1);
					}
					base._canFlip = false;
					base.MakeLevelOne(dontGetCharacterDataForCurrentLevel);
					PlayerModifierStats playerStats = _playerStats;
					if (_playerStats != null)
					{
						EnemyData enemyData2 = _enemyData;
						if (_enemyData != null)
						{
							eggFloat = playerStats._003CMaxHp_003Ek__BackingField;
							if (playerStats._003CMaxHp_003Ek__BackingField != null)
							{
								num = _HpMultiplier * enemyData2._003CmaxHp_003Ek__BackingField;
								object obj = num & -2147483649L;
								if ((nint)obj != 2139095040)
								{
									object obj2 = num & -2147483649L;
									if ((nint)obj2 <= 2139095040)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018766C190h\"");
										if (num == -1f / 0f)
										{
											num = -3.4028235E+38f;
										}
										goto IL_05f8;
									}
								}
								num = 3.4028235E+38f;
								goto IL_05f8;
							}
						}
					}
				}
				else if ((object)_coherenceSync != null)
				{
					if (!_coherenceSync.HasStateAuthority)
					{
						_003CWaitForEnemyDataForMakeLevelOne_003Ed__9 obj3 = null;
						obj3._003C_003E1__state = 0;
						obj3._003C_003E4__this = this;
						obj3.dontGetCharacterDataForCurrentLevel = dontGetCharacterDataForCurrentLevel;
						Coroutine coroutine = StartCoroutine(obj3);
					}
					else
					{
						Debug.LogError("<FollowerEnemy_CharacterController.MakeLevelOne> Uh oh, _enemyData is null");
					}
					return;
				}
			}
		}
		goto IL_05b3;
		IL_0661:
		EggFloat eggFloat2;
		float val;
		eggFloat2._val = val;
		if (_wiggleTween != null)
		{
			_wiggleTween.Kill();
		}
		_wiggleTween = null;
		if ((object)_CharacterRenderer != null)
		{
			((Renderer)_CharacterRenderer).Internal_GetPropertyBlock(_propBlock);
			RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: false);
			bool flag2 = (byte)(int)_propBlock != 0;
			if ((int)(~_propBlock) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v9 (System.Boolean)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_propBlock);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdi_v9 (System.Boolean)+10]");
					Color value = default(Color);
					MaterialPropertyBlock.SetColorImpl_Injected((IntPtr)0, RenderingExtensions.TintColor, ref value);
					RenderingExtensions.SetTintEnabled(_propBlock, isEnabled: true);
					bool flag3 = (byte)(int)_CharacterRenderer != 0;
					if ((int)(~_CharacterRenderer) == 0)
					{
						MaterialPropertyBlock propBlock = _propBlock;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdi_v11 (System.Boolean)+10]");
						bool flag4 = (nint)0 == 0;
						bool flag5 = _propBlock == null;
						bool flag6 = false;
						if (!flag5)
						{
							flag6 = (byte)(nint)propBlock.m_Ptr != 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdi_v11 (System.Boolean)+10]");
						Renderer.Internal_SetPropertyBlock_Injected((IntPtr)0, (IntPtr)(flag6 ? 1 : 0));
						return;
					}
				}
			}
		}
		goto IL_05b3;
		IL_05b3:
		throw new NullReferenceException();
		IL_05f8:
		eggFloat._val = num;
		PlayerModifierStats playerStats2 = _playerStats;
		float num2;
		if (_playerStats != null)
		{
			EggFloat eggFloat3 = playerStats2._003CMaxHp_003Ek__BackingField;
			if (playerStats2._003CMaxHp_003Ek__BackingField != null)
			{
				num2 = eggFloat3._eggVal + eggFloat3._val;
				object obj4 = num2 & -2147483649L;
				if ((nint)obj4 != 2139095040)
				{
					object obj5 = num2 & -2147483649L;
					if ((nint)obj5 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018766C1FAh\"");
						if (num2 == -1f / 0f)
						{
							num2 = -3.4028235E+38f;
						}
						goto IL_062e;
					}
				}
				num2 = 3.4028235E+38f;
				goto IL_062e;
			}
		}
		goto IL_05b3;
		IL_062e:
		base._currentHp = num2;
		float num3 = base.MaxHp();
		if (num2 > num)
		{
			float num4 = base.MaxHp();
			base._currentHp = num;
		}
		PlayerModifierStats playerStats3 = _playerStats;
		if (_playerStats != null)
		{
			EnemyData enemyData3 = _enemyData;
			if (_enemyData != null)
			{
				eggFloat2 = playerStats3._003CPower_003Ek__BackingField;
				if (playerStats3._003CPower_003Ek__BackingField != null)
				{
					float num5 = enemyData3._003Cpower_003Ek__BackingField * _PowerMultiplier;
					object obj6 = num5 & -2147483649L;
					if ((nint)obj6 != 2139095040)
					{
						object obj7 = num5 & -2147483649L;
						if ((nint)obj7 <= 2139095040)
						{
							bool flag7 = num5 == -1f / 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018766C2A3h\"");
							val = -3.4028235E+38f;
							if (!flag7)
							{
								val = num5;
							}
							goto IL_0661;
						}
					}
					val = 3.4028235E+38f;
					goto IL_0661;
				}
			}
		}
		goto IL_05b3;
	}

	private IEnumerator WaitForEnemyDataForMakeLevelOne(bool dontGetCharacterDataForCurrentLevel)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_0110: Expected O, but got I4
		_003CWaitForEnemyDataForMakeLevelOne_003Ed__9 obj = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
		bool flag = (nint)0 == 0;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		if (!flag)
		{
			object obj2 = obj + 32;
			object obj3 = obj2 >> 12;
			object obj4 = obj3 & 0x1FFFFF;
			object obj5 = obj4 >> 6;
			object obj6 = obj4 & 0x3F;
			object obj7 = obj5 * 8;
			object obj8 = 6603864928L + obj7;
			do
			{
				object obj9 = 1 << (int)obj6;
				object obj10 = obj8 | obj9;
				if (obj8 == obj8)
				{
					obj8 = obj10;
				}
			}
			while (obj8 != obj8);
			obj.dontGetCharacterDataForCurrentLevel = dontGetCharacterDataForCurrentLevel;
			return obj;
		}
		obj.dontGetCharacterDataForCurrentLevel = dontGetCharacterDataForCurrentLevel;
		return obj;
	}

	protected unsafe override void SetCharacterSprite()
	{
		//IL_008c: Expected O, but got I
		//IL_02c2: Expected O, but got I4
		//IL_02c2: Expected O, but got I4
		//IL_05ab: Expected O, but got I4
		//IL_037b: Expected O, but got I4
		//IL_037b: Expected O, but got I4
		//IL_041e: Expected O, but got I4
		//IL_01ab->IL048b: Incompatible stack heights: 1 vs 0
		//IL_01f6->IL048b: Incompatible stack heights: 1 vs 0
		//IL_023f->IL048b: Incompatible stack heights: 1 vs 0
		//IL_026d->IL048b: Incompatible stack heights: 1 vs 0
		//IL_0299->IL048b: Incompatible stack heights: 1 vs 0
		//IL_0596->IL048b: Incompatible stack heights: 2 vs 0
		//IL_02ea->IL048b: Incompatible stack heights: 2 vs 0
		//IL_05c9->IL048b: Incompatible stack heights: 2 vs 0
		//IL_035c->IL048b: Incompatible stack heights: 2 vs 0
		//IL_03a3->IL048b: Incompatible stack heights: 2 vs 0
		//IL_03d2->IL048b: Incompatible stack heights: 2 vs 0
		//IL_03f1->IL048b: Incompatible stack heights: 2 vs 0
		//IL_068c->IL00e2: Incompatible stack heights: 7 vs 0
		CoherenceSync coherenceSync = _coherenceSync;
		if ((object)_coherenceSync != null)
		{
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
				{
					goto IL_048b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v61 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				bool flag = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v61 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v61 (Coherence.Toolkit.ObservableAuthorityType)+10]");
					object obj = -3;
					bool flag2 = obj == null;
					flag = flag2;
				}
				if (!flag)
				{
					if (_enemyData == null)
					{
						_003CWaitForEnemyDataForSetCharacterSprite_003Ed__11 obj2 = null;
						obj2._003C_003E1__state = 0;
						obj2._003C_003E4__this = this;
						Coroutine coroutine = StartCoroutine(obj2);
						return;
					}
					goto IL_0102;
				}
			}
			if (_enemyData != null)
			{
				goto IL_0102;
			}
			goto IL_047c;
		}
		goto IL_048b;
		IL_059b:
		ArcadeSprite arcadeSprite = setOrigin(0.5f, (float?)(object)1);
		Rect ret;
		if ((object)base._healthBar != null)
		{
			Transform transform = base._healthBar.transform;
			bool flag3 = (object)transform == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rax_v48 (UnityEngine.Transform)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1334 @ rax_v48 (UnityEngine.Transform)+10]");
			Transform.set_localPosition_Injected((IntPtr)0, ref *(Vector3*)(&ret));
			bool flag5 = (object)_CharacterRenderer == null;
			Transform transform2 = _CharacterRenderer.transform;
			bool flag6 = (object)transform2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1206 @ rax_v54 (UnityEngine.Transform)+10]");
			bool flag7 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1206 @ rax_v54 (UnityEngine.Transform)+10]");
			Transform.get_localScale_Injected((IntPtr)0, out Vector3 ret2);
			_OriginalScale = ret2;
			_ = 0;
			return;
		}
		goto IL_048b;
		IL_048b:
		throw new NullReferenceException();
		IL_0102:
		EnemyData enemyData = _enemyData;
		List<string> list = enemyData._003CframeNames_003Ek__BackingField;
		if (enemyData._003CframeNames_003Ek__BackingField != null)
		{
			if (list._size <= 0)
			{
				goto IL_047c;
			}
			bool flag8 = list._size <= 0;
			string[] items = list._items;
			if (list._items != null)
			{
				if (items.Length <= 0)
				{
					throw new IndexOutOfRangeException();
				}
				EnemyData enemyData2 = _enemyData;
				if (_enemyData != null)
				{
					Sprite sprite = SpriteManager.GetSprite(items[0], enemyData2._003CtextureName_003Ek__BackingField);
					if ((object)_CharacterRenderer != null)
					{
						_CharacterRenderer.sprite = sprite;
						if ((object)_CharacterRenderer != null)
						{
							Sprite sprite2 = _CharacterRenderer.sprite;
							if ((object)sprite2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v38 (UnityEngine.Sprite)+10]");
								bool flag9 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v38 (UnityEngine.Sprite)+10]");
								Sprite.get_rect_Injected((IntPtr)0, out ret);
								object obj3 = default(object);
								float num = (float)obj3 * 0.4f;
								float num2 = num * 0.5f;
								if (body != null)
								{
									BaseBody baseBody = body.setCircle(num, (float?)(object)1, (float?)(object)1);
									EnemyData enemyData3 = _enemyData;
									if (_enemyData != null)
									{
										if (enemyData3._003CcolliderOverride_003Ek__BackingField == null)
										{
											goto IL_059b;
										}
										ColliderOverride colliderOverride = enemyData3._003CcolliderOverride_003Ek__BackingField;
										float num3 = (float)obj3 * colliderOverride._003Cradius_003Ek__BackingField;
										num2 = num3 * 0.5f;
										if (body != null)
										{
											BaseBody baseBody2 = body.setCircle(num3, (float?)(object)1, (float?)(object)1);
											EnemyData enemyData4 = _enemyData;
											if (_enemyData != null)
											{
												ColliderOverride colliderOverride2 = enemyData4._003CcolliderOverride_003Ek__BackingField;
												if (enemyData4._003CcolliderOverride_003Ek__BackingField != null && body != null)
												{
													float x = num2 + colliderOverride2._003CoffsetX_003Ek__BackingField;
													BaseBody baseBody3 = body.setOffset(x, (float?)(object)1);
													goto IL_059b;
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
		goto IL_048b;
		IL_047c:
		Debug.LogError("Uh oh, skin data is invalid");
	}

	private IEnumerator WaitForEnemyDataForSetCharacterSprite()
	{
		_003CWaitForEnemyDataForSetCharacterSprite_003Ed__11 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void SetupAnimation()
	{
		//IL_006f: Expected O, but got I
		//IL_0183: Expected O, but got I4
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		CoherenceSync coherenceSync = _coherenceSync;
		NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
		if (coherenceSync._003CEntityState_003Ek__BackingField != null)
		{
			ObservableAuthorityType observableAuthorityType = networkEntityState._003CAuthorityType_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v22 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			bool flag = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v22 (Coherence.Toolkit.ObservableAuthorityType)+10]");
			if ((nint)0 != 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ rcx_v22 (Coherence.Toolkit.ObservableAuthorityType)+10]");
				object obj = -3;
				bool flag2 = obj == null;
				flag = flag2;
			}
			if (!flag)
			{
				if (_enemyData == null)
				{
					_003CWaitForEnemyDataForSetupAnimation_003Ed__13 obj2 = null;
					obj2._003C_003E1__state = 0;
					obj2._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj2);
					return;
				}
				goto IL_00e0;
			}
		}
		if (_enemyData != null)
		{
			goto IL_00e0;
		}
		Debug.LogError("Uh oh, skin data is invalid");
		return;
		IL_00e0:
		EnemyData enemyData = _enemyData;
		List<string> list = enemyData._003CframeNames_003Ek__BackingField;
		int num = list._size ^ list._size;
		int num2 = list._size & num;
		bool flag3 = num2 < 0;
		bool flag4 = list._size < 0;
		bool flag5 = list._size == 0;
		if (!flag5)
		{
			bool flag6 = flag4 == flag3;
			object obj3 = !flag6;
			object obj4 = obj3 | flag5;
			if (obj4 == null)
			{
				List<List<string>> internal_IdleAnimFrameNames = enemyData.Internal_IdleAnimFrameNames;
				if (internal_IdleAnimFrameNames._size > 0)
				{
					List<string>[] items = internal_IdleAnimFrameNames._items;
					EnemyData enemyData2 = _enemyData;
					List<Sprite> animationFramesFast = SpriteManager.GetAnimationFramesFast(items[0], enemyData2._003CtextureName_003Ek__BackingField);
					bool shouldLoop = default(bool);
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					_spriteAnimation.AddAnimation("walk", animationFramesFast, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
					_spriteAnimation.SetAnimation("walk");
					_currentAnimation = CharAnimationType.walk;
					base.CurrentWalkAnimName = "walk";
					base.OnStop();
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
		}
		else
		{
			Debug.LogError("<FollowerEnemy_CharacterController.SetupAnimation> No frames in the animation found in Enemy Data");
		}
	}

	private IEnumerator WaitForEnemyDataForSetupAnimation()
	{
		_003CWaitForEnemyDataForSetupAnimation_003Ed__13 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void AddAttackAnimations()
	{
		//IL_042b: Expected I, but got O
		//IL_0017: Expected I, but got O
		//IL_0111: Expected I, but got O
		//IL_0084: Expected O, but got I
		//IL_01c4: Expected I, but got O
		//IL_0201: Expected I, but got O
		//IL_0230: Expected I, but got O
		//IL_0298: Expected I, but got O
		//IL_02d1: Expected O, but got I
		//IL_0300: Expected O, but got I4
		CoherenceSync coherenceSync = _coherenceSync;
		bool flag = (object)_coherenceSync == null;
		nint num = (nint)this;
		if (!flag)
		{
			NetworkEntityState networkEntityState = coherenceSync._003CEntityState_003Ek__BackingField;
			if (coherenceSync._003CEntityState_003Ek__BackingField != null)
			{
				num = (nint)networkEntityState._003CAuthorityType_003Ek__BackingField;
				if (networkEntityState._003CAuthorityType_003Ek__BackingField == null)
				{
					goto IL_03ff;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+10]");
				bool flag2 = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+10]");
				if ((nint)0 != 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+10]");
					object obj = -3;
					bool flag3 = obj == null;
					flag2 = flag3;
				}
				if (!flag2)
				{
					if (_enemyData == null)
					{
						_003CWaitForEnemyDataForAddAttackAnimations_003Ed__15 obj2 = null;
						obj2._003C_003E1__state = 0;
						obj2._003C_003E4__this = this;
						Coroutine coroutine = StartCoroutine(obj2);
						return;
					}
					goto IL_00fa;
				}
			}
			if (_enemyData != null)
			{
				goto IL_00fa;
			}
			Debug.LogError("Uh oh, skin data is invalid");
			return;
		}
		goto IL_03ff;
		IL_00fa:
		EnemyData enemyData = _enemyData;
		num = (nint)enemyData._003CframeNames_003Ek__BackingField;
		if (enemyData._003CframeNames_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+18]");
			if ((nint)0 <= (nint)0)
			{
				return;
			}
			SpriteAnimation spriteAnimation = _spriteAnimation;
			if ((object)_spriteAnimation == null || ((UnityEngine.Object)spriteAnimation).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			EnemyData enemyData2 = _enemyData;
			bool flag4 = _enemyData == null;
			num = (nint)typeof(UnityEngine.Object);
			if (!flag4)
			{
				List<List<string>> internal_IdleAnimFrameNames = enemyData2.Internal_IdleAnimFrameNames;
				bool flag5 = enemyData2.Internal_IdleAnimFrameNames == null;
				num = (nint)typeof(UnityEngine.Object);
				if (!flag5)
				{
					int num2 = UnityEngine.Random.Range(0, internal_IdleAnimFrameNames._size);
					num = (nint)_enemyData;
					if (_enemyData != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+168]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+168]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							num = (nint)_enemyData;
							if (_enemyData != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v4 (Il2CppClass<UnityEngine.Object>)+C8]");
								List<string> frameNames = default(List<string>);
								List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(frameNames, (string)0);
								if (animationFrames != null)
								{
									List<Sprite>.Enumerator enumerator = default(List<Sprite>.Enumerator);
									List<Sprite> frames;
									if (enumerator.MoveNext())
									{
										object obj3 = 0;
										List<Sprite> list = new List<Sprite>();
										if ((object)_CharacterRenderer == null)
										{
											throw new NullReferenceException();
										}
										Sprite sprite = _CharacterRenderer.sprite;
										if (list == null)
										{
											throw new NullReferenceException();
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
										frames = list;
									}
									else
									{
										frames = animationFrames;
									}
									if ((object)_spriteAnimation != null)
									{
										bool shouldLoop = default(bool);
										bool startRandomFrame = default(bool);
										Action onComplete = default(Action);
										bool autoSetAnimation = default(bool);
										_spriteAnimation.AddAnimation("idle", frames, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
										_hasIdleAnimation = true;
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_03ff;
		IL_03ff:
		throw new NullReferenceException();
	}

	private IEnumerator WaitForEnemyDataForAddAttackAnimations()
	{
		_003CWaitForEnemyDataForAddAttackAnimations_003Ed__15 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void InternalUpdate()
	{
		if (!base._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			base.InternalUpdate();
			if (0 > (nint)_currentDirection)
			{
				base._isFlipped = false;
			}
			else if ((nint)_currentDirection > 0)
			{
				base._isFlipped = true;
			}
			_CharacterRenderer.flipX = base._isFlipped;
		}
	}

	protected override void ScheduleDeathConsequences()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		weaponsManager._maxActiveCount = 0;
		weaponsManager.SetMaxWeaponCount(0, 0);
		_enemyData = null;
		Action onComplete = delegate
		{
			base._isDead = true;
			_damageVfx.Stop();
			if (_deficiencyControl != null)
			{
				CharacterADControl deficiencyControl = _deficiencyControl;
				CharacterController followedCharacter = deficiencyControl._followedCharacter;
				if ((object)deficiencyControl._followedCharacter != null && ((UnityEngine.Object)followedCharacter).m_CachedPtr != (IntPtr)0)
				{
					CharacterADControl deficiencyControl2 = _deficiencyControl;
					GM.Core.RefreshEnemyFollowersList(deficiencyControl2._followedCharacter);
				}
			}
			_deficiencyControl = null;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void Deactivate()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		weaponsManager._maxActiveCount = 0;
		weaponsManager.SetMaxWeaponCount(0, 0);
		_enemyData = null;
		Action onComplete = delegate
		{
			base._isDead = true;
			_damageVfx.Stop();
			if (_deficiencyControl != null)
			{
				CharacterADControl deficiencyControl = _deficiencyControl;
				CharacterController followedCharacter = deficiencyControl._followedCharacter;
				if ((object)deficiencyControl._followedCharacter != null && ((UnityEngine.Object)followedCharacter).m_CachedPtr != (IntPtr)0)
				{
					CharacterADControl deficiencyControl2 = _deficiencyControl;
					GM.Core.RefreshEnemyFollowersList(deficiencyControl2._followedCharacter);
				}
			}
			_deficiencyControl = null;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1.25f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public unsafe void Activate()
	{
		//IL_00ce: Expected O, but got I
		//IL_023a: Expected I, but got O
		//IL_012d: Expected F4, but got I
		//IL_0185: Expected I4, but got I8
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		weaponsManager._maxActiveCount = -1;
		weaponsManager.SetMaxWeaponCount(weaponsManager._maxActiveCount, weaponsManager._maxHiddenCount);
		((Renderer)_CharacterRenderer).Internal_GetPropertyBlock(_propBlock);
		RenderingExtensions.SetTintFillEnabled(_propBlock, isEnabled: false);
		MaterialPropertyBlock propBlock = _propBlock;
		bool flag = propBlock.m_Ptr == (IntPtr)0;
		float value = default(float);
		MaterialPropertyBlock.SetColorImpl_Injected(propBlock.m_Ptr, RenderingExtensions.TintColor, ref *(Color*)(&value));
		RenderingExtensions.SetTintEnabled(_propBlock, isEnabled: true);
		SpriteRenderer characterRenderer = _CharacterRenderer;
		MaterialPropertyBlock materialPropertyBlock = _propBlock;
		bool flag2 = ((UnityEngine.Object)characterRenderer).m_CachedPtr == (IntPtr)0;
		if (_propBlock != null)
		{
			materialPropertyBlock = (MaterialPropertyBlock)(nint)materialPropertyBlock.m_Ptr;
		}
		Renderer.Internal_SetPropertyBlock_Injected(((UnityEngine.Object)characterRenderer).m_CachedPtr, (IntPtr)materialPropertyBlock);
		_spriteAnimation.CleanAnimations();
		BaseBody baseBody = body;
		_playDamageSFX = false;
		baseBody._enable = true;
		base._isDead = false;
		float num = base.MaxHp();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F50]");
		base._currentHp = 0f;
		Transform transform = _CharacterRenderer.transform;
		bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value2);
		_playerStats.ResetStats();
		_currentJsonData = null;
		bool dontGetCharacterDataForCurrentLevel = default(bool);
		InitCharacter(_characterType, -1, asRemote: true, dontGetCharacterDataForCurrentLevel);
	}

	private void _003CDeactivate_003Eb__18_0()
	{
		base._isDead = true;
		_damageVfx.Stop();
		if (_deficiencyControl != null)
		{
			CharacterADControl deficiencyControl = _deficiencyControl;
			CharacterController followedCharacter = deficiencyControl._followedCharacter;
			if ((object)deficiencyControl._followedCharacter != null && ((UnityEngine.Object)followedCharacter).m_CachedPtr != (IntPtr)0)
			{
				CharacterADControl deficiencyControl2 = _deficiencyControl;
				GM.Core.RefreshEnemyFollowersList(deficiencyControl2._followedCharacter);
			}
		}
		_deficiencyControl = null;
	}
}
