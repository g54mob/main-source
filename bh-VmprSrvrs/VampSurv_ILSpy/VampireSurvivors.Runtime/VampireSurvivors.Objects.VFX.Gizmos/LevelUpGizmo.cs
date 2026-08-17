using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.VFX.Gizmos;

public class LevelUpGizmo : PoolableMonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public LevelUpGizmo _003C_003E4__this;

		public float offset;

		internal float _003CAnimateLevelUpText_003Eb__0()
		{
			LevelUpGizmo levelUpGizmo = _003C_003E4__this;
			return levelUpGizmo._YOffset;
		}

		internal void _003CAnimateLevelUpText_003Eb__1(float x)
		{
			LevelUpGizmo levelUpGizmo = _003C_003E4__this;
			levelUpGizmo._YOffset = x;
		}

		internal void _003CAnimateLevelUpText_003Eb__2()
		{
			//IL_018c->IL0112: Incompatible stack heights: 1 vs 0
			//IL_009c->IL0112: Incompatible stack heights: 1 vs 0
			LevelUpGizmo levelUpGizmo = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				levelUpGizmo._YOffset = 0f;
				LevelUpGizmo levelUpGizmo2 = _003C_003E4__this;
				if ((object)_003C_003E4__this != null)
				{
					LevelUpGizmo textParent = (LevelUpGizmo)(object)levelUpGizmo2._TextParent;
					if ((object)levelUpGizmo2._TextParent != null)
					{
						bool flag = ((UnityEngine.Object)textParent).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)textParent).m_CachedPtr, out Vector3 ret);
						if ((object)_003C_003E4__this != null)
						{
							Transform transform = _003C_003E4__this.transform;
							if ((object)transform != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v27 (UnityEngine.Transform)+10]");
								bool flag2 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v27 (UnityEngine.Transform)+10]");
								Transform.get_position_Injected((IntPtr)0, out ret);
								LevelUpGizmo levelUpGizmo3 = _003C_003E4__this;
								bool flag3 = (object)_003C_003E4__this == null;
								bool flag4 = (object)levelUpGizmo3._TextParent == null;
								Transform transform2 = levelUpGizmo3._TextParent.transform;
								bool flag5 = (object)transform2 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v33 (UnityEngine.Transform)+10]");
								bool flag6 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v33 (UnityEngine.Transform)+10]");
								Transform.set_position_Injected((IntPtr)0, ref ret);
								LevelUpGizmo levelUpGizmo4 = _003C_003E4__this;
								bool flag7 = (object)_003C_003E4__this == null;
								RenderingExtensions.Start(levelUpGizmo4._pfxEmitter);
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CAnimateLevelUpText_003Eb__3()
		{
			//IL_013f->IL00ee: Incompatible stack heights: 1 vs 0
			//IL_0089->IL00ee: Incompatible stack heights: 1 vs 0
			LevelUpGizmo levelUpGizmo = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				LevelUpGizmo textParent = (LevelUpGizmo)(object)levelUpGizmo._TextParent;
				if ((object)levelUpGizmo._TextParent != null)
				{
					bool flag = ((UnityEngine.Object)textParent).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)textParent).m_CachedPtr, out Vector3 ret);
					if ((object)_003C_003E4__this != null)
					{
						Transform transform = _003C_003E4__this.transform;
						if ((object)transform != null)
						{
							bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
							LevelUpGizmo levelUpGizmo2 = _003C_003E4__this;
							bool flag3 = (object)_003C_003E4__this == null;
							bool flag4 = (object)levelUpGizmo2._TextParent == null;
							Transform transform2 = levelUpGizmo2._TextParent.transform;
							bool flag5 = (object)transform2 == null;
							bool flag6 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CAnimateLevelUpText_003Eb__4()
		{
			LevelUpGizmo levelUpGizmo = _003C_003E4__this;
			if ((object)_003C_003E4__this != null)
			{
				LevelUpGizmo pfxEmitter = (LevelUpGizmo)(object)levelUpGizmo._pfxEmitter;
				if ((object)levelUpGizmo._pfxEmitter != null)
				{
					bool flag = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 55 ConditionalJump @-1, v73 @ ZF_v7 (System.Boolean) --- -1 Nop");
					/*Error: End of method reached without returning.*/;
				}
			}
			throw new NullReferenceException();
		}
	}

	private Transform _TextParent;

	private SpriteRenderer _Blur;

	public float _YOffset;

	private ParticleEmitterManager _particleEmitterManager;

	private ParticleSystem _pfxEmitter;

	private VampireSurvivors.Objects.Characters.CharacterController _activePlayer;

	private bool _hasSetupEmitter;

	private bool _defaultBlurPositionSet;

	private Vector3 _blurDefaultLocalPosition;

	private Vector2 PlayerPos
	{
		get
		{
			if ((object)_activePlayer != null)
			{
				Transform transform = _activePlayer.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Vector2 result = default(Vector2);
					return result;
				}
			}
			throw new NullReferenceException();
		}
	}

	private void Update()
	{
		//IL_0158->IL00d9: Incompatible stack heights: 3 vs 0
		Transform activePlayer = (Transform)(object)_activePlayer;
		if ((object)_activePlayer == null || ((UnityEngine.Object)activePlayer).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Transform transform = base.transform;
		if ((object)_activePlayer != null)
		{
			Transform transform2 = _activePlayer.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void Init(VampireSurvivors.Objects.Characters.CharacterController activePlayer)
	{
		//IL_00e4->IL0093: Incompatible stack heights: 1 vs 0
		_activePlayer = activePlayer;
		SetupEmitter();
		if (_defaultBlurPositionSet)
		{
			return;
		}
		if ((object)_Blur != null)
		{
			Transform transform = _Blur.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				_blurDefaultLocalPosition = ret;
				_ = 0;
				_defaultBlurPositionSet = true;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SetupEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_015a: Expected O, but got I4
		//IL_0181: Expected O, but got I4
		//IL_01a8: Expected O, but got I4
		//IL_01c1: Expected O, but got Ref
		//IL_01d0: Expected O, but got I4
		//IL_01de: Expected native int or pointer, but got O
		//IL_01f8: Expected O, but got I
		//IL_0210: Expected O, but got Ref
		//IL_022a: Expected native int or pointer, but got O
		//IL_0244: Expected O, but got I
		//IL_0264: Expected O, but got Ref
		//IL_028c: Expected native int or pointer, but got O
		//IL_0490: Expected O, but got I4
		//IL_02a4: Expected O, but got Ref
		//IL_02cb: Expected O, but got I
		//IL_02e5: Expected native int or pointer, but got O
		//IL_04ad: Expected O, but got I4
		//IL_0317: Expected O, but got Ref
		//IL_0331: Expected native int or pointer, but got O
		//IL_04e7: Expected O, but got I
		//IL_0369: Expected O, but got Ref
		//IL_0383: Expected native int or pointer, but got O
		//IL_0521: Expected O, but got I
		//IL_054e: Expected O, but got I4
		//IL_0408: Expected O, but got I
		//IL_0429: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (!_hasSetupEmitter)
		{
			_hasSetupEmitter = true;
			Line line = null;
			line._x1 = -0.16f;
			line._y1 = 0f;
			line._x2 = 0.16f;
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager particleEmitterManager = gameObject.AddComponent<ParticleEmitterManager>();
			_particleEmitterManager = particleEmitterManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"PfxLine2");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(0.32f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(250f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			_ = 0;
			obj = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-10]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 48));
			particleSystemConfig._angleSteps = 16;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(60f, 90f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
			_ = 0;
			_ = 10;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(0.5f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+60]");
			_ = 0;
			particleSystemConfig._scaleX = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 112));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(4f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
			particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 144));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0.35f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-38]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			_ = 0;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Edge;
			emitZone._source = line;
			emitZone._overrideRotation = (Vector3?)(object)1;
			particleSystemConfig._emitZone = emitZone;
			_ = 0;
			_ = 1065353216;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			particleSystemConfig._blendMode = (BlendMode?)(object)0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _particleEmitterManager.CreateEmitter(particleSystemConfig);
			_pfxEmitter = pfxEmitter;
		}
	}

	public void Play()
	{
		//IL_0060: Expected O, but got I
		//IL_0093: Expected O, but got I
		//IL_00ca: Expected O, but got I
		//IL_00fd: Expected O, but got I
		Transform transform = base.transform;
		if ((object)_activePlayer != null)
		{
			Transform transform2 = _activePlayer.transform;
			if ((object)transform2 != null)
			{
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				AnimateLevelUpText();
				MultiTargetTween multiTargetTween = AnimateBlur();
				bool flag4 = multiTargetTween == null;
				IntPtr cachedPtr = ((UnityEngine.Object)(object)multiTargetTween).m_CachedPtr;
				bool flag5 = ((UnityEngine.Object)(object)multiTargetTween).m_CachedPtr == (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v27 (System.IntPtr)+18]");
				object obj = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v27 (System.IntPtr)+18]");
				bool flag6 = (nint)obj >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v27 (System.IntPtr)+10]");
				Transform transform3 = (Transform)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v27 (System.IntPtr)+10]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rcx_v27 (System.IntPtr)+18]");
				object obj2 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rbx_v12 (UnityEngine.Transform)+18]");
				bool flag8 = (nint)obj2 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rbx_v12 (UnityEngine.Transform)+20+v478 @ rax_v36*8]");
				object obj3 = 0;
				TweenCallback tweenCallback = delegate
				{
					float remainingLifetime = RenderingExtensions.GetRemainingLifetime(_pfxEmitter);
					TweenCallback callback = Despawn;
					Tween tween = DOVirtual.DelayedCall(remainingLifetime, callback, ignoreTimeScale: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					tween.stringId = "DefaultGameTweenId";
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ rbx_v12 (UnityEngine.Transform)+20+v478 @ rax_v36*8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rbx_v13+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void AnimateLevelUpText()
	{
		//IL_0440: Expected O, but got I4
		//IL_004f: Expected O, but got I4
		//IL_04ec: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_01c6: Expected O, but got I
		//IL_02ef: Expected O, but got I
		//IL_0572->IL03e8: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass15_0();
		if (CS_0024_003C_003E8__locals21 != null)
		{
			CS_0024_003C_003E8__locals21._003C_003E4__this = this;
			VampireSurvivors.Objects.Characters.CharacterController activePlayer = _activePlayer;
			bool flag = (object)_activePlayer == null;
			object obj = 0;
			if (!flag)
			{
				bool flag2 = ((UnityEngine.Object)activePlayer).m_CachedPtr == (IntPtr)0;
				obj = 0;
				if (!flag2)
				{
					ArcadeSprite activePlayer2 = _activePlayer;
					if ((object)_activePlayer == null)
					{
						goto IL_041a;
					}
					bool flag3 = activePlayer2.body == null;
					obj = 0;
					if (!flag3)
					{
						float2 displaySize = _activePlayer.displaySize;
						object obj2 = default(object);
						obj = obj2;
					}
				}
			}
			float offset = (float)obj + 0.16f;
			CS_0024_003C_003E8__locals21.offset = offset;
			object textParent = _TextParent;
			_YOffset = 0f;
			if ((object)_TextParent != null)
			{
				Vector3 zeroVector = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdi_v5 (System.Object)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdi_v5 (System.Object)+10]");
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected((IntPtr)0, ref value);
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_TextParent, 1f, 0.5f);
				bool flag5 = tweenerCore == null;
				object obj3 = 0;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					bool flag6 = (nint)0 == 0;
					obj3 = 0;
					if (!flag6)
					{
						_ = 4;
						_ = 0;
						obj3 = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 2;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v633 @ rax_v26 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
								zeroVector = (Vector3)(num + 0);
							}
						}
					}
				}
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				((_003C_003Ec__DisplayClass15_0)(object)dOSetter)._003CAnimateLevelUpText_003Eb__1(1f);
				TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, 64f, 0.5f);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 2;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+A0]");
								object obj4 = num2 + 0;
							}
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore2 != null)
				{
					TweenCallback tweenCallback = delegate
					{
						//IL_018c->IL0112: Incompatible stack heights: 1 vs 0
						//IL_009c->IL0112: Incompatible stack heights: 1 vs 0
						LevelUpGizmo levelUpGizmo = CS_0024_003C_003E8__locals21._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals21._003C_003E4__this != null)
						{
							levelUpGizmo._YOffset = 0f;
							LevelUpGizmo levelUpGizmo2 = CS_0024_003C_003E8__locals21._003C_003E4__this;
							if ((object)CS_0024_003C_003E8__locals21._003C_003E4__this != null)
							{
								LevelUpGizmo textParent2 = (LevelUpGizmo)(object)levelUpGizmo2._TextParent;
								if ((object)levelUpGizmo2._TextParent != null)
								{
									bool flag7 = ((UnityEngine.Object)textParent2).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)textParent2).m_CachedPtr, out Vector3 ret);
									if ((object)CS_0024_003C_003E8__locals21._003C_003E4__this != null)
									{
										Transform transform = CS_0024_003C_003E8__locals21._003C_003E4__this.transform;
										if ((object)transform != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v27 (UnityEngine.Transform)+10]");
											bool flag8 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v27 (UnityEngine.Transform)+10]");
											Transform.get_position_Injected((IntPtr)0, out ret);
											LevelUpGizmo levelUpGizmo3 = CS_0024_003C_003E8__locals21._003C_003E4__this;
											bool flag9 = (object)CS_0024_003C_003E8__locals21._003C_003E4__this == null;
											bool flag10 = (object)levelUpGizmo3._TextParent == null;
											Transform transform2 = levelUpGizmo3._TextParent.transform;
											bool flag11 = (object)transform2 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v33 (UnityEngine.Transform)+10]");
											bool flag12 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v33 (UnityEngine.Transform)+10]");
											Transform.set_position_Injected((IntPtr)0, ref ret);
											LevelUpGizmo levelUpGizmo4 = CS_0024_003C_003E8__locals21._003C_003E4__this;
											bool flag13 = (object)CS_0024_003C_003E8__locals21._003C_003E4__this == null;
											RenderingExtensions.Start(levelUpGizmo4._pfxEmitter);
											return;
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
					}
					TweenCallback tweenCallback2 = delegate
					{
						//IL_013f->IL00ee: Incompatible stack heights: 1 vs 0
						//IL_0089->IL00ee: Incompatible stack heights: 1 vs 0
						LevelUpGizmo levelUpGizmo = CS_0024_003C_003E8__locals21._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals21._003C_003E4__this != null)
						{
							LevelUpGizmo textParent2 = (LevelUpGizmo)(object)levelUpGizmo._TextParent;
							if ((object)levelUpGizmo._TextParent != null)
							{
								bool flag7 = ((UnityEngine.Object)textParent2).m_CachedPtr == (IntPtr)0;
								Transform.get_position_Injected(((UnityEngine.Object)textParent2).m_CachedPtr, out Vector3 ret);
								if ((object)CS_0024_003C_003E8__locals21._003C_003E4__this != null)
								{
									Transform transform = CS_0024_003C_003E8__locals21._003C_003E4__this.transform;
									if ((object)transform != null)
									{
										bool flag8 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
										Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
										LevelUpGizmo levelUpGizmo2 = CS_0024_003C_003E8__locals21._003C_003E4__this;
										bool flag9 = (object)CS_0024_003C_003E8__locals21._003C_003E4__this == null;
										bool flag10 = (object)levelUpGizmo2._TextParent == null;
										Transform transform2 = levelUpGizmo2._TextParent.transform;
										bool flag11 = (object)transform2 == null;
										bool flag12 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
										Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref ret);
										return;
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
					}
					TweenCallback tweenCallback3 = delegate
					{
						LevelUpGizmo levelUpGizmo = CS_0024_003C_003E8__locals21._003C_003E4__this;
						if ((object)CS_0024_003C_003E8__locals21._003C_003E4__this != null)
						{
							LevelUpGizmo pfxEmitter = (LevelUpGizmo)(object)levelUpGizmo._pfxEmitter;
							if ((object)levelUpGizmo._pfxEmitter != null)
							{
								bool flag7 = ((UnityEngine.Object)pfxEmitter).m_CachedPtr == (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
								Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 55 ConditionalJump @-1, v73 @ ZF_v7 (System.Boolean) --- -1 Nop");
								/*Error: End of method reached without returning.*/;
							}
						}
						throw new NullReferenceException();
					};
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v807 @ rax_v33 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
					return;
				}
			}
			throw new NullReferenceException();
		}
		goto IL_041a;
		IL_041a:
		throw new NullReferenceException();
	}

	private MultiTargetTween AnimateBlur()
	{
		//IL_00c4: Expected I, but got O
		//IL_008f: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_0063->IL01d2: Incompatible stack heights: 1 vs 0
		//IL_00b2->IL00b2: Incompatible stack heights: 2 vs 1
		//IL_010e->IL01d2: Incompatible stack heights: 2 vs 0
		if ((object)_Blur != null)
		{
			Transform transform = _Blur.transform;
			object obj = default(object);
			float num = (float)obj + 0.24f;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				TweenConfig tweenConfig = new TweenConfig();
				object[] array = new object[2];
				if (array != null)
				{
					if ((object)_Blur != null)
					{
						nint num2 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj2 = default(object);
						bool flag2 = obj2 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					nint num3 = (nint)array;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					object obj3 = default(object);
					bool flag3 = obj3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					if (tweenConfig != null)
					{
						tweenConfig.targets = array;
						tweenConfig.duration = 500f;
						tweenConfig.alpha = (float?)(object)1;
						tweenConfig.yoyo = true;
						tweenConfig.repeat = 2;
						tweenConfig.scale = (float?)(object)1;
						TweenCallback onStart = delegate
						{
							SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_Blur, 0f);
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_Blur, 0f);
						};
						tweenConfig.onStart = onStart;
						TweenCallback onComplete = delegate
						{
							TweenCallback callback = delegate
							{
								GameObject obj4 = _Blur.gameObject;
								UnityEngine.Object.Destroy(obj4, 0f);
							};
							Tween tween = DOVirtual.DelayedCall(0.1f, callback, ignoreTimeScale: false);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							tween.stringId = "DefaultGameTweenId";
						};
						tweenConfig.onComplete = onComplete;
						return Tweens.Add(tweenConfig);
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Despawn()
	{
		GameObject obj = base.gameObject;
		if ((object)base._parentPool != null)
		{
			base._parentPool.Release(obj);
			return;
		}
		throw new NullReferenceException();
	}

	public LevelUpGizmo()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CPlay_003Eb__14_0()
	{
		float remainingLifetime = RenderingExtensions.GetRemainingLifetime(_pfxEmitter);
		TweenCallback callback = Despawn;
		Tween tween = DOVirtual.DelayedCall(remainingLifetime, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween.stringId = "DefaultGameTweenId";
	}

	private void _003CAnimateBlur_003Eb__16_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_Blur, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_Blur, 0f);
	}

	private void _003CAnimateBlur_003Eb__16_1()
	{
		TweenCallback callback = delegate
		{
			GameObject obj = _Blur.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
		};
		Tween tween = DOVirtual.DelayedCall(0.1f, callback, ignoreTimeScale: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		tween.stringId = "DefaultGameTweenId";
	}

	private void _003CAnimateBlur_003Eb__16_2()
	{
		GameObject obj = _Blur.gameObject;
		UnityEngine.Object.Destroy(obj, 0f);
	}
}
