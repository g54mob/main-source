using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Framework;

public class ArcanaManager_VFX
{
	private GameObject _SapphireMistGO;

	private bool _SapphireMist_Ready;

	private ParticleEmitterManager _SapphireMist_PFXManager;

	private ParticleSystem _SapphireMist_pfxEmitter;

	private ParticleSystem _SapphireMist_pfxEmitter2;

	private GravityWell _SapphireMist_well;

	private VampireSurvivors.Objects.Characters.CharacterController _SapphireMist_LastUser;

	private Vector3 _SapphireMist_GravityWellOffset;

	private List<float> _sapphireMistDetunes;

	private int _sapphireMistDetunesIndex;

	public WorldEaterVFX WorldEaterVFX;

	public unsafe void Play_SapphireMist(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_0133: Expected O, but got I
		//IL_01b3: Expected F4, but got I
		//IL_01cf: Expected O, but got I4
		//IL_00e4->IL01f5: Incompatible stack heights: 1 vs 0
		//IL_0153->IL01f5: Incompatible stack heights: 2 vs 0
		if (!_SapphireMist_Ready)
		{
			Generate_SapphireMist();
		}
		_SapphireMist_LastUser = character;
		if ((object)_SapphireMist_well != null)
		{
			Transform transform = _SapphireMist_well.transform;
			if ((object)character != null)
			{
				float2 cachedPosition = character.cachedPosition;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 value = default(Vector2);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				float2 position = character.position;
				Vector2 pos = default(Vector2);
				RenderingExtensions.EmitParticleAt(_SapphireMist_pfxEmitter, pos, 20);
				float2 position2 = character.position;
				RenderingExtensions.EmitParticleAt(_SapphireMist_pfxEmitter2, pos, 40);
				List<float> sapphireMistDetunes = _sapphireMistDetunes;
				if (_sapphireMistDetunes != null)
				{
					int sapphireMistDetunesIndex = _sapphireMistDetunesIndex;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
					int num = (int)((nint)sapphireMistDetunesIndex % (nint)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v10 (System.Collections.Generic.List`1<System.Single>)+18]");
					bool flag2 = (nint)num >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v10 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ r8_v10 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rcx_v24+18]");
						bool flag3 = (nint)num >= (nint)0;
						int sapphireMistDetunesIndex2 = _sapphireMistDetunesIndex + 1;
						_sapphireMistDetunesIndex = sapphireMistDetunesIndex2;
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rcx_v24+20+v193 @ rdx_v16 (System.Int32)*4]");
						soundConfig.Detune = 0f;
						soundConfig.Rate = 1f;
						soundConfig.Volume = (float?)(object)1;
						float time = default(float);
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_paradoxMist, soundConfig, 0f, 10, time);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Play_WorldEater(VampireSurvivors.Objects.Characters.CharacterController character, bool isCursed = false)
	{
		if (WorldEaterVFX == null)
		{
			WorldEaterVFX worldEaterVFX = new WorldEaterVFX(character);
			WorldEaterVFX = worldEaterVFX;
		}
		WorldEaterVFX.CastSoulSteal(null, isCursed);
	}

	public void Update()
	{
		//IL_00c8->IL0092: Incompatible stack heights: 1 vs 0
		if (!_SapphireMist_Ready)
		{
			return;
		}
		if ((object)_SapphireMist_well != null)
		{
			Transform transform = _SapphireMist_well.transform;
			if ((object)_SapphireMist_LastUser != null)
			{
				float2 cachedPosition = _SapphireMist_LastUser.cachedPosition;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public static List<float> MakeDetunes(int amount = 100, int min = -1000, int max = 1000, bool shuffle = true)
	{
		//IL_0174: Expected I, but got O
		//IL_01fc: Expected O, but got I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected I4, but got Unknown
		//IL_0061: Expected O, but got I4
		//IL_0089: Expected O, but got I
		//IL_0099: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_00d7: Expected F4, but got I4
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		List<float> list = new List<float>();
		nint num = (nint)typeof(Math);
		int num2 = -min;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v4 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			num2 = min;
		}
		int num3 = -max;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rcx_v4 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			num3 = max;
		}
		object obj = num2 + num3;
		int num4 = obj / amount;
		if (amount > 0)
		{
			int num5 = min;
			object obj2 = 0;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v10+18]");
				if (num6 >= 0)
				{
					list.AddWithResize((float)num5);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
					object obj5 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v2 (System.Collections.Generic.List`1<System.Single>)+18]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v10+18]");
					if (num7 >= 0)
					{
						return (List<float>)(object)new IndexOutOfRangeException();
					}
				}
				obj2++;
				num5 += num4;
			}
			while ((nint)obj2 < amount);
		}
		if (shuffle)
		{
			VampireSurvivors.App.Tools.Extensions.Shuffle(list);
		}
		return list;
	}

	public unsafe void Generate_SapphireMist()
	{
		//IL_0008: Expected O, but got Ref
		//IL_002a: Expected I4, but got I8
		//IL_005a: Expected I4, but got I8
		//IL_00c0: Expected O, but got I
		//IL_01d8: Expected O, but got I
		//IL_01d8: Expected I4, but got O
		//IL_0127: Expected O, but got I
		//IL_013d: Expected O, but got I
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Expected O, but got Unknown
		//IL_0158: Expected I, but got O
		//IL_0dff: Expected O, but got I
		//IL_0e08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0d: Expected O, but got Unknown
		//IL_0e15: Expected I, but got O
		//IL_0340: Expected I4, but got O
		//IL_0340: Expected O, but got I
		//IL_039a: Expected O, but got I
		//IL_05a2: Expected O, but got Ref
		//IL_05bc: Expected native int or pointer, but got O
		//IL_0e77: Expected O, but got I4
		//IL_05ef: Expected O, but got I4
		//IL_0608: Expected O, but got Ref
		//IL_0622: Expected native int or pointer, but got O
		//IL_063c: Expected O, but got I
		//IL_065c: Expected O, but got Ref
		//IL_0676: Expected native int or pointer, but got O
		//IL_0690: Expected O, but got I
		//IL_06b0: Expected O, but got Ref
		//IL_06ca: Expected native int or pointer, but got O
		//IL_0eb1: Expected O, but got I
		//IL_0702: Expected O, but got Ref
		//IL_0729: Expected O, but got I
		//IL_0750: Expected O, but got I
		//IL_0777: Expected O, but got I
		//IL_0791: Expected native int or pointer, but got O
		//IL_0eeb: Expected O, but got I
		//IL_0f3a: Expected I, but got O
		//IL_0970: Expected O, but got Ref
		//IL_098a: Expected native int or pointer, but got O
		//IL_09b2: Expected O, but got I
		//IL_0f72: Expected O, but got I
		//IL_09d3: Expected O, but got I4
		//IL_09ec: Expected O, but got Ref
		//IL_0a06: Expected native int or pointer, but got O
		//IL_0a20: Expected O, but got I
		//IL_0a40: Expected O, but got Ref
		//IL_0a5a: Expected native int or pointer, but got O
		//IL_0a74: Expected O, but got I
		//IL_0a94: Expected O, but got Ref
		//IL_0aae: Expected native int or pointer, but got O
		//IL_0af3: Expected O, but got I
		//IL_0b1b: Expected O, but got Ref
		//IL_0b35: Expected native int or pointer, but got O
		//IL_0b7a: Expected O, but got I
		//IL_0bc0: Expected O, but got I
		//IL_0bed: Expected O, but got I
		//IL_0c0e: Expected O, but got I
		//IL_0c77: Expected O, but got Ref
		//IL_0cad: Expected O, but got I4
		//IL_0cc1: Expected O, but got I4
		//IL_0d50: Expected O, but got Ref
		//IL_0d60->IL0faa: Incompatible stack heights: 6 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if (_SapphireMist_Ready)
		{
			return;
		}
		List<float> sapphireMistDetunes = MakeDetunes(50, -600, 600, shuffle: false);
		_sapphireMistDetunes = sapphireMistDetunes;
		List<float> collection = MakeDetunes(50, -600, 600, shuffle: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)0 >= (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)0 > (nint)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 == 0)
				{
					ArgumentNullException ex = new ArgumentNullException("array");
					ex._002Ector("array");
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v616 @ r9_v33+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
				if (num < 0)
				{
					object obj4 = new ArgumentException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
					throw obj4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj5 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
				ArcanaManager_VFX arcanaManager_VFX = (ArcanaManager_VFX)((nint)0 + (nint)32);
				object obj6 = obj5 * 4;
				nint num2 = (nint)((object)arcanaManager_VFX + obj6);
				IntPtr intPtr = default(IntPtr);
				num2 = intPtr;
				arcanaManager_VFX = this;
				do
				{
					arcanaManager_VFX = (ArcanaManager_VFX)num2;
					arcanaManager_VFX = (ArcanaManager_VFX)(arcanaManager_VFX + 4);
					num2 = (nint)arcanaManager_VFX;
					num2 -= 4;
				}
				while ((nint)arcanaManager_VFX < num2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			List<float> sapphireMistDetunes2 = _sapphireMistDetunes;
			List<float> sapphireMistDetunes3 = _sapphireMistDetunes;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
			sapphireMistDetunes3.InsertRange(0, collection);
			Vector3 sapphireMist_GravityWellOffset = default(Vector3);
			_SapphireMist_GravityWellOffset = sapphireMist_GravityWellOffset;
			_ = 0;
			_sapphireMistDetunesIndex = 0;
			DOGetter<float> dOGetter = null;
			((List<float>)(object)dOGetter).InsertRange((int)this, (IEnumerable<float>)0);
			DOSetter<float> dOSetter = null;
			((ArcanaManager_VFX)(object)dOSetter)._003CGenerate_SapphireMist_003Eb__15_1(0.2f);
			TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(dOGetter, dOSetter, 0.35f, 1f);
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+100]");
					if ((nint)0 == 0)
					{
						_ = 4294967295L;
						_ = 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						if ((nint)0 == 0)
						{
							_ = 2139095040;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v916 @ rax_v40 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 4;
						_ = 0;
					}
				}
			}
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, (string)null);
			_SapphireMistGO = gameObject;
			((UnityEngine.Object)_SapphireMistGO).SetName("SapphireMist_VFXManager");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1426 @ rbx_v14 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				((List<float>)0).InsertRange((int)"SapphireMist_VFXManager", null);
			}
			_ = 0;
			ParticleEmitterManager sapphireMist_PFXManager;
			if (_SapphireMistGO.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 480))))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
				sapphireMist_PFXManager = (ParticleEmitterManager)0;
			}
			else
			{
				sapphireMist_PFXManager = _SapphireMistGO.AddComponent<ParticleEmitterManager>();
			}
			_SapphireMist_PFXManager = sapphireMist_PFXManager;
			EmitZone emitZone = new EmitZone();
			emitZone._type = EmitZoneType.Random;
			Circle circle = new Circle();
			circle._x = 0f;
			circle._radius = 16f;
			emitZone._source = circle;
			emitZone._type = EmitZoneType.Random;
			emitZone._yoyo = false;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"WhiteDot");
			}
			else
			{
				int size2 = list._size + 1;
				list._size = size2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(3f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+70]");
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(2000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+80]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+90]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0f, 180f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+A0]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+B0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(100f, 200f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+C0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+D0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-68]");
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-48]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			_ = 0;
			_ = 10;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 1065353216;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 0;
			_ = 42495;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
			particleSystemConfig._tint = (uint?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.65f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+E0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+F0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-20]");
			_ = 0;
			particleSystemConfig._emitZone = emitZone;
			particleSystemConfig._on = false;
			ParticleSystem sapphireMist_pfxEmitter = _SapphireMist_PFXManager.CreateEmitter(particleSystemConfig, null, "SapphireMist_Emitter2");
			_SapphireMist_pfxEmitter2 = sapphireMist_pfxEmitter;
			Transform transform = _SapphireMist_pfxEmitter2.transform;
			bool flag = ((Exception)(object)transform)._className == null;
			Vector3 value = default(Vector3);
			Transform.set_localPosition_Injected((IntPtr)((Exception)(object)transform)._className, ref value);
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			List<string> list2 = new List<string>();
			list2._002Ector();
			int version3 = list2._version + 1;
			list2._version = version3;
			string[] items3 = list2._items;
			if (list2._size >= items3.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"_blur3");
			}
			else
			{
				int size3 = list2._size + 1;
				list2._size = size3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version4 = list2._version + 1;
			list2._version = version4;
			string[] items4 = list2._items;
			if (list2._size >= items4.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"2Spell4Blue");
			}
			else
			{
				int size4 = list2._size + 1;
				list2._size = size4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig2._frame = list2;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(1f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+100]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+110]");
			obj = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-18]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+8]");
			_ = 0;
			minMaxCurve2 = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+120]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+130]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+140]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+150]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(100f, 200f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+160]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+170]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+10]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+30]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 384));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(0.75f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+180]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+190]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+38]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+58]");
			_ = 0;
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 0;
			_ = 1065353216;
			_ = 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
			particleSystemConfig2._frequency = (float?)(object)0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+1E0]");
			particleSystemConfig2._blendMode = (BlendMode?)(object)0;
			particleSystemConfig2._emitZone = emitZone;
			particleSystemConfig2._on = false;
			ParticleSystem sapphireMist_pfxEmitter2 = _SapphireMist_PFXManager.CreateEmitter(particleSystemConfig2, null, "SapphireMist_Emitter");
			_SapphireMist_pfxEmitter = sapphireMist_pfxEmitter2;
			Transform transform2 = _SapphireMist_pfxEmitter.transform;
			bool flag2 = (object)transform2 == null;
			transform2.localPosition = (Vector3)(&value);
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			bool flag3 = gravityWellConfig == null;
			((Exception)(object)gravityWellConfig)._data = (IDictionary)1065353216;
			_ = 1112014848;
			((Exception)(object)gravityWellConfig)._innerException = (Exception)1112014848;
			bool flag4 = (object)_SapphireMist_PFXManager == null;
			GravityWell sapphireMist_well = _SapphireMist_PFXManager.CreateGravityWell(gravityWellConfig);
			_SapphireMist_well = sapphireMist_well;
			bool flag5 = (object)_SapphireMist_well == null;
			Transform transform3 = _SapphireMist_well.transform;
			bool flag6 = (object)transform3 == null;
			object obj7 = default(object);
			transform3.localPosition = (Vector3)(&obj7);
			_SapphireMist_Ready = true;
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.count, System.ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
		throw new NullReferenceException();
	}

	private float _003CGenerate_SapphireMist_003Eb__15_0()
	{
		//IL_0007: Expected F4, but got O
		return (float)_SapphireMist_GravityWellOffset;
	}

	private void _003CGenerate_SapphireMist_003Eb__15_1(float x)
	{
		//IL_000a: Expected O, but got F4
		_SapphireMist_GravityWellOffset = (Vector3)x;
	}
}
