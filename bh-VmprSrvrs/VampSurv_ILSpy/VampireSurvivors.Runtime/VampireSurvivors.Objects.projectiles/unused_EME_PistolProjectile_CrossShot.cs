using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class unused_EME_PistolProjectile_CrossShot : Projectile
{
	private sealed class _003CDespawnInAFrame_003Ed__10(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public unused_EME_PistolProjectile_CrossShot _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00bc: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.Despawn();
			}
			return false;
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

	private ParticleSystem crossshotVFX;

	private ParticleEventCall crossshotParticleEventCall;

	private float hitboxWidth = 25f;

	private float hitboxHeight = 50f;

	private float centralOffset = -1.25f;

	private EnemyController _targetEnemyController;

	private Timer _expireTimer;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		Transform targetTransform = _targetTransform;
		if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform).m_CachedPtr != (IntPtr)0)
		{
			SetupMechanics(index);
			if ((object)crossshotVFX != null)
			{
				crossshotVFX.Play(withChildren: true);
			}
		}
		else
		{
			_003CDespawnInAFrame_003Ed__10 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
		}
	}

	private unsafe void SetupMechanics(int index)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_05ca: Expected O, but got I
		//IL_05ca: Expected O, but got I
		//IL_05e6: Expected O, but got F4
		//IL_063e: Expected I, but got O
		//IL_066c: Expected O, but got I
		//IL_0687: Expected O, but got I
		//IL_0416: Expected O, but got I
		//IL_0416: Expected O, but got I
		//IL_0432: Expected O, but got F4
		//IL_046a: Expected I, but got O
		//IL_0488: Expected O, but got F4
		//IL_04a7: Expected O, but got I
		//IL_04d3: Expected O, but got I
		//IL_0262: Expected O, but got I
		//IL_0262: Expected O, but got I
		//IL_027e: Expected O, but got F4
		//IL_088d: Expected I4, but got O
		//IL_0bb9: Expected I, but got O
		//IL_0bd2: Expected F4, but got O
		//IL_02d6: Expected I, but got O
		//IL_0304: Expected O, but got I
		//IL_031f: Expected O, but got I
		//IL_0ad1: Expected I, but got O
		//IL_0aea: Expected F4, but got O
		//IL_00e0: Expected O, but got I
		//IL_00e0: Expected O, but got I
		//IL_00fc: Expected O, but got F4
		//IL_06d3: Expected O, but got I
		//IL_09ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b1: Expected I4, but got Unknown
		//IL_09ce: Expected I, but got O
		//IL_09dc: Expected O, but got F4
		//IL_09e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09eb: Expected O, but got Unknown
		//IL_0a04: Expected F4, but got O
		//IL_0a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a19: Expected O, but got Unknown
		//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca9: Expected O, but got Unknown
		//IL_0cc8: Expected I4, but got O
		//IL_0133: Expected I, but got O
		//IL_0151: Expected O, but got F4
		//IL_0170: Expected O, but got I
		//IL_019c: Expected O, but got I
		//IL_051f: Expected O, but got I
		//IL_036b: Expected O, but got I
		//IL_08c4: Expected I, but got O
		//IL_08d2: Expected O, but got F4
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Expected O, but got Unknown
		//IL_0924: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Expected O, but got Unknown
		//IL_0d1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d22: Expected O, but got Unknown
		//IL_0d41: Expected I4, but got O
		//IL_01e8: Expected O, but got I
		//IL_0d96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9b: Expected O, but got Unknown
		//IL_0df2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df7: Expected O, but got Unknown
		//IL_0763: Expected O, but got I4
		//IL_07b1: Expected I, but got O
		//IL_09c0->IL0883: Incompatible stack heights: 1 vs 0
		//IL_0ce2->IL0830: Incompatible stack heights: 1 vs 0
		//IL_070b->IL070b: Incompatible stack heights: 2 vs 0
		//IL_0540->IL09a3: Incompatible stack heights: 2 vs 1
		//IL_038c->IL09a3: Incompatible stack heights: 2 vs 1
		//IL_055d->IL055d: Incompatible stack heights: 3 vs 0
		//IL_0d5b->IL0830: Incompatible stack heights: 2 vs 0
		//IL_03a9->IL03a9: Incompatible stack heights: 3 vs 0
		//IL_01f5->IL09a3: Incompatible stack heights: 2 vs 1
		//IL_081c->IL0830: Incompatible stack heights: 6 vs 0
		object obj2 = default(object);
		object obj = obj2 - 95;
		float num = hitboxWidth * 0.5f;
		float num2 = hitboxHeight * 0.5f;
		_isCullable = false;
		bool flag = index == 0;
		if (flag)
		{
			goto IL_055d;
		}
		int num3 = index - 1;
		if (flag)
		{
			goto IL_03a9;
		}
		int num4 = num3 - 1;
		float num12 = default(float);
		if (!flag)
		{
			if (num4 != 1)
			{
				goto IL_0883;
			}
			_ = 0;
			_ = 0;
			_ = hitboxHeight;
			_ = hitboxWidth;
			if (body != null)
			{
				BaseBody baseBody = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+7F]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
				BaseBody baseBody2 = baseBody.setSize((float?)(object)num5, (float?)(object)0, center: false);
				BaseBody baseBody3 = body;
				object obj3 = num ^ -0f;
				_ = 0;
				if (body != null)
				{
					nint num6 = (nint)baseBody3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
					nint num7 = 0;
					object obj4 = num2 ^ -0f;
					float num8 = (float)obj4 - num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rax_v135 (Il2CppClass<BaseBody>)+230]");
					object obj5 = 0;
					float x = num8 + centralOffset;
					BaseBody baseBody4 = body;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
					BaseBody baseBody5 = baseBody4.setOffset(x, (float?)(object)0);
					if ((object)crossshotVFX != null)
					{
						Transform transform = crossshotVFX.transform;
						nint num9 = (nint)typeof(Vector3);
						object obj6 = num2 ^ -0f;
						object obj7 = obj6 + centralOffset;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1130 @ rcx_v112 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num10 = 0;
						float num11 = num12 * (float)obj7;
						object obj8 = (object)Vector3.rightVector * obj7;
						_ = Vector3.rightVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rdx_v67 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
						object obj9 = 0 * obj7;
						float num13 = (float)obj8 * 0.01f;
						float num14 = num11 * 0.01f;
						float num15 = (float)obj9 * 0.01f;
						bool flag2 = (object)transform == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v137 (UnityEngine.Transform)+10]");
						nint num16 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v137 (UnityEngine.Transform)+10]");
						bool flag3 = (nint)0 == 0;
						object obj10 = 0;
						float num17 = num12;
						goto IL_09a3;
					}
				}
			}
		}
		else
		{
			_ = 0;
			_ = 0;
			_ = hitboxWidth;
			_ = hitboxHeight;
			_ = 1;
			_ = 1;
			if (body != null)
			{
				BaseBody baseBody6 = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+7F]");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
				BaseBody baseBody7 = baseBody6.setSize((float?)(object)num18, (float?)(object)0, center: false);
				BaseBody baseBody8 = body;
				object obj11 = num2 ^ -0f;
				_ = 0;
				float num19 = (float)obj11 - num2;
				_ = 1;
				float num20 = num19 + centralOffset;
				if (body != null)
				{
					nint num21 = (nint)baseBody8;
					float x2 = num ^ -0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v558 @ rax_v124 (Il2CppClass<BaseBody>)+230]");
					object obj5 = 0;
					BaseBody baseBody9 = body;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
					BaseBody baseBody10 = baseBody9.setOffset(x2, (float?)(object)0);
					if ((object)crossshotVFX != null)
					{
						Transform transform2 = crossshotVFX.transform;
						nint num22 = (nint)typeof(Vector3);
						object obj12 = num2 ^ -0f;
						object obj13 = obj12 + centralOffset;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ rcx_v103 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num23 = 0;
						float num14 = (float)Vector3.upVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v984 @ rdx_v64 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						object obj14 = obj13 * 0;
						float num24 = (float)obj13 * num12;
						float num25 = (float)obj13 * (float)Vector3.upVector;
						_ = Vector3.upVector;
						float num13 = num25 * 0.01f;
						float num15 = num24 * 0.01f;
						float num26 = (float)obj14 * 0.01f;
						bool flag4 = (object)transform2 == null;
						nint num16 = ((UnityEngine.Object)transform2).m_CachedPtr;
						bool flag5 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						object obj10 = 0;
						bool flag6 = (nint)0 != 0;
						float num17 = num12;
						if (!flag6)
						{
							bool flag7 = (nint)0 == 0;
							goto IL_03a9;
						}
						goto IL_09a3;
					}
				}
			}
		}
		goto IL_0830;
		IL_055d:
		_ = 0;
		_ = 0;
		_ = hitboxWidth;
		_ = hitboxHeight;
		_ = 1;
		_ = 1;
		if (body != null)
		{
			BaseBody baseBody11 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+7F]");
			nint num27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
			BaseBody baseBody12 = baseBody11.setSize((float?)(object)num27, (float?)(object)0, center: false);
			BaseBody baseBody13 = body;
			object obj15 = num2 ^ -0f;
			_ = 0;
			float num28 = (float)obj15 + num2;
			_ = 1;
			float num29 = num28 - centralOffset;
			if (body != null)
			{
				nint num30 = (nint)baseBody13;
				float x3 = num ^ -0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ rax_v102 (Il2CppClass<BaseBody>)+230]");
				object obj5 = 0;
				BaseBody baseBody14 = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
				BaseBody baseBody15 = baseBody14.setOffset(x3, (float?)(object)0);
				if ((object)crossshotVFX != null)
				{
					Transform transform3 = crossshotVFX.transform;
					float num31 = num2 - centralOffset;
					nint num32 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ rcx_v85 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num33 = 0;
					float num14 = (float)Vector3.upVector;
					float num34 = num31;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rdx_v58 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					float num35 = num34 * 0f;
					float num36 = num31 * num12;
					float num37 = num31 * (float)Vector3.upVector;
					_ = Vector3.upVector;
					float num13 = num37 * 0.01f;
					float num15 = num36 * 0.01f;
					float num38 = num35 * 0.01f;
					nint num16 = ((UnityEngine.Object)transform3).m_CachedPtr;
					bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					object obj10 = 0;
					bool flag9 = (nint)0 != 0;
					float num17 = num12;
					if (flag9)
					{
						goto IL_09a3;
					}
					bool flag10 = (nint)0 == 0;
					goto IL_0c6e;
				}
			}
		}
		goto IL_0830;
		IL_03a9:
		_ = 0;
		_ = 0;
		_ = hitboxHeight;
		_ = hitboxWidth;
		_ = 1;
		_ = 1;
		if (body != null)
		{
			BaseBody baseBody16 = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+7F]");
			nint num39 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
			BaseBody baseBody17 = baseBody16.setSize((float?)(object)num39, (float?)(object)0, center: false);
			BaseBody baseBody18 = body;
			object obj16 = num ^ -0f;
			_ = 0;
			_ = 1;
			if (body != null)
			{
				nint num40 = (nint)baseBody18;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
				nint num7 = 0;
				object obj17 = num2 ^ -0f;
				float num41 = (float)obj17 + num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ rax_v113 (Il2CppClass<BaseBody>)+230]");
				object obj5 = 0;
				float x4 = num41 - centralOffset;
				BaseBody baseBody19 = body;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+67]");
				BaseBody baseBody20 = baseBody19.setOffset(x4, (float?)(object)0);
				if ((object)crossshotVFX != null)
				{
					Transform transform4 = crossshotVFX.transform;
					float num42 = num2 - centralOffset;
					nint num43 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v759 @ rcx_v94 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num44 = 0;
					float num14 = (float)Vector3.rightVector;
					float num45 = num42;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rdx_v61 (Il2CppStaticFields<UnityEngine.Vector3>)+44]");
					float num46 = num45 * 0f;
					float num47 = num42 * num12;
					float num48 = num42 * (float)Vector3.rightVector;
					_ = Vector3.rightVector;
					float num13 = num48 * 0.01f;
					float num15 = num47 * 0.01f;
					float num49 = num46 * 0.01f;
					bool flag11 = (object)transform4 == null;
					nint num16 = ((UnityEngine.Object)transform4).m_CachedPtr;
					bool flag12 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					object obj10 = 0;
					bool flag13 = (nint)0 != 0;
					float num17 = num12;
					if (!flag13)
					{
						bool flag14 = (nint)0 == 0;
						goto IL_055d;
					}
					goto IL_09a3;
				}
			}
		}
		goto IL_0830;
		IL_09a3:
		int num50 = obj - 25;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1638 @ rax_v53 (should have been resolved before IL gen)");
		goto IL_0883;
		IL_0883:
		int num51 = (int)_targetTransform;
		Transform cachedTransform = _cachedTransform;
		if ((object)_targetTransform == null)
		{
			goto IL_0830;
		}
		goto IL_0c6e;
		IL_0c6e:
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdi_v25 (System.Int32)+10]");
		bool flag15 = (nint)0 == 0;
		object obj18 = obj - 9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdi_v25 (System.Int32)+10]");
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj18);
		int num52 = (int)_targetTransform;
		if ((object)_targetTransform != null)
		{
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdi_v26 (System.Int32)+10]");
			bool flag16 = (nint)0 == 0;
			object obj19 = obj - 41;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rdi_v26 (System.Int32)+10]");
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj19);
			int num53 = (int)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rdi_v27 (System.Int32)+10]");
				bool flag17 = (nint)0 == 0;
				object obj20 = obj - 25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rdi_v27 (System.Int32)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)obj20);
				bool flag18 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-11]");
				_ = 0;
				bool flag19 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				object obj21 = obj - 9;
				Transform.set_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Vector3*)obj21);
				bool flag20 = (object)_weapon == null;
				float num54 = _weapon.PArea();
				ArcadeSprite arcadeSprite = setScale(num12, (float?)(object)0);
				if (_expireTimer != null)
				{
					_expireTimer.Cancel();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2200 @ r8_v25 (Il2CppClass<VampireSurvivors.Objects.Projectiles.unused_EME_PistolProjectile_CrossShot>)+370]");
				Action onComplete = new Action(this, (IntPtr)0);
				nint num55 = (nint)this;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				TimerType type = default(TimerType);
				Timer expireTimer = Timers.Register(1.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_expireTimer = expireTimer;
				BaseBody baseBody21 = body;
				if (body != null)
				{
					baseBody21._enable = true;
					return;
				}
			}
		}
		goto IL_0830;
		IL_0830:
		throw new NullReferenceException();
	}

	private void SetupVisuals()
	{
		if ((object)crossshotVFX != null)
		{
			crossshotVFX.Play(withChildren: true);
		}
	}

	private IEnumerator DespawnInAFrame()
	{
		_003CDespawnInAFrame_003Ed__10 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public override void Despawn()
	{
		BaseBody baseBody = body;
		baseBody._enable = false;
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if ((object)crossshotVFX != null)
		{
			crossshotVFX.Stop();
		}
		if ((object)crossshotVFX != null)
		{
			crossshotVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}

	private void DespawnAfterParticlesStopped()
	{
		if ((object)crossshotVFX != null)
		{
			crossshotVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}

	private void FinishDespawn()
	{
		if ((object)crossshotVFX != null)
		{
			crossshotVFX.Clear(withChildren: true);
		}
		_isCullable = true;
		base.Despawn();
	}
}
