using System;
using System.Collections.Generic;
using Coffee.UIExtensions;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.Framework.Particles;

public class ParticleEmitterManager : GameMonoBehaviour
{
	public string _GlobalClockKey = "Game";

	private readonly List<ParticleSystem> _particleSystems;

	private List<GravityWell> _gravityWells;

	private float _defaultDepth;

	private unsafe bool UsePauseSystem
	{
		get
		{
			//IL_010f: Expected I4, but got O
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected Ref, but got Unknown
			//IL_00cb: Expected I8, but got I4
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2A01]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			string globalClockKey = _GlobalClockKey;
			if (_GlobalClockKey != null)
			{
				object obj = "Game";
				if ((object)_GlobalClockKey != "Game")
				{
					if ("Game" != null)
					{
						int stringLength = globalClockKey._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rdx_v1+10]");
						if ((nint)stringLength == 0)
						{
							ref byte second = ref *(byte*)("Game" + 20);
							ulong length = (ulong)(globalClockKey._stringLength + globalClockKey._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(_GlobalClockKey + 20), ref second, length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected void Start()
	{
		GameObject gameObject = base.gameObject;
		Transform transform = gameObject.transform;
		Transform parent = transform.parent;
		if (UsePauseSystem && !gameObject.TryGetComponent<ParticlePauseController>(out var _))
		{
			ParticlePauseController particlePauseController = gameObject.AddComponent<ParticlePauseController>();
		}
	}

	public ParticleSystem CreateEmitter(ParticleSystemConfig config, Transform parent = null, string psName = null)
	{
		Transform parent2;
		if ((object)parent != null)
		{
			bool flag = ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0;
			parent2 = parent;
			if (flag)
			{
				goto IL_0112;
			}
		}
		Transform transform = base.transform;
		parent2 = transform;
		goto IL_0112;
		IL_0112:
		bool usePauseSystem = UsePauseSystem;
		ParticleSystem particleSystem = ParticleSystemGenerator.GenerateParticleSystem(config, parent2, psName, usePauseSystem);
		RenderingExtensions.SetDepthMultiplied(particleSystem, _defaultDepth, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
		List<GravityWell> gravityWells = _gravityWells;
		List<GravityWell>.Enumerator enumerator = default(List<GravityWell>.Enumerator);
		if (gravityWells._size > 0 && enumerator.MoveNext())
		{
			GravityWell gravityWell = null;
			throw new NullReferenceException();
		}
		return particleSystem;
	}

	public unsafe ParticleSystem CreateUIEmitter(ParticleSystemConfig config, string layer, int order, Transform parent = null, string psName = null, bool isAdditive = true, bool requiresMasking = false)
	{
		//IL_0297: Expected F4, but got I4
		//IL_042c: Expected O, but got I4
		//IL_0308: Expected O, but got I4
		//IL_065d: Expected O, but got I
		//IL_0577: Expected O, but got I4
		//IL_0125->IL0625: Incompatible stack heights: 2 vs 0
		//IL_0349->IL0557: Incompatible stack heights: 4 vs 3
		_GlobalClockKey = "Root";
		Transform transform = default(Transform);
		Transform parent2;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr != (IntPtr)0;
			parent2 = transform;
			if (flag)
			{
				goto IL_0396;
			}
		}
		Transform transform2 = base.transform;
		parent2 = transform2;
		goto IL_0396;
		IL_0435:
		UIParticle uIParticle;
		ParticleSystem particleSystem;
		if ((object)uIParticle != null)
		{
			uIParticle.m_AbsoluteMode = true;
			if (!((MaskableGraphic)uIParticle).m_Maskable)
			{
				((MaskableGraphic)uIParticle).m_Maskable = true;
				((MaskableGraphic)uIParticle).m_ShouldRecalculateStencil = true;
				uIParticle.SetMaterialDirty();
			}
			List<GravityWell>.Enumerator scale3D = default(List<GravityWell>.Enumerator);
			uIParticle.m_Scale3D = (Vector3)scale3D;
			_ = 266f;
			if (_particleSystems != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96880");
				List<GravityWell> gravityWells = _gravityWells;
				if (_gravityWells != null)
				{
					bool flag2 = gravityWells._size <= 0;
					float defaultDepth = _defaultDepth;
					List<GravityWell> list = null;
					if (!flag2)
					{
						List<GravityWell>.Enumerator enumerator = default(List<GravityWell>.Enumerator);
						while (enumerator.MoveNext())
						{
							((GravityWell)null).AddParticleSystem(particleSystem);
						}
						defaultDepth = 0f;
						list = _gravityWells;
					}
					if ((object)particleSystem != null)
					{
						GameObject gameObject = particleSystem.gameObject;
						if ((object)gameObject != null)
						{
							ParticleSystemRenderer component = gameObject.GetComponent<ParticleSystemRenderer>();
							if ((object)component != null)
							{
								component.sortingLayerName = (string)requiresMasking;
								bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
								IntPtr intPtr = default(IntPtr);
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr, (int)(nint)intPtr);
								Transform transform3 = component.transform;
								bool flag4 = (object)transform3 == null;
								bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector3 value = default(Vector3);
								Transform.set_localPosition_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9A8]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999B9A8]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
									bool flag6 = obj == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1859 @ rax_v53 (should have been resolved before IL gen)");
								GameObject gameObject2 = particleSystem.gameObject;
								int value2 = LayerMask.NameToLayer((string)requiresMasking);
								bool flag7 = (object)gameObject2 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1865 @ rax_v55 (UnityEngine.GameObject)+10]");
								bool flag8 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1865 @ rax_v55 (UnityEngine.GameObject)+10]");
								GameObject.set_layer_Injected((IntPtr)0, value2);
								Transform transform4 = particleSystem.transform;
								bool flag9 = (object)transform4 == null;
								bool flag10 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
								List<GravityWell>.Enumerator value3 = default(List<GravityWell>.Enumerator);
								Transform.set_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref *(Vector3*)(&value3));
								return particleSystem;
							}
						}
					}
				}
			}
		}
		goto IL_035d;
		IL_035d:
		throw new NullReferenceException();
		IL_0396:
		object obj2 = default(object);
		bool flag11 = obj2 != null;
		uIParticle = null;
		if (!flag11)
		{
			GameObject gameObject3 = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject3, (string)null);
			if ((object)gameObject3 != null)
			{
				Transform transform5 = gameObject3.transform;
				if ((object)transform5 != null)
				{
					transform5.parent = parent2;
					Transform transform6 = gameObject3.transform;
					bool flag12 = (object)transform6 == null;
					bool flag13 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
					Vector3 value4 = default(Vector3);
					Transform.set_localPosition_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value4);
					UIParticle uIParticle2 = gameObject3.AddComponent<UIParticle>();
					Transform transform7 = gameObject3.transform;
					int layer2 = LayerMask.NameToLayer((string)requiresMasking);
					gameObject3.layer = layer2;
					uIParticle = uIParticle2;
					parent2 = transform7;
					goto IL_0625;
				}
			}
			goto IL_035d;
		}
		goto IL_0625;
		IL_0625:
		bool usePauseSystem = UsePauseSystem;
		string text = default(string);
		particleSystem = ParticleSystemGenerator.GenerateParticleSystem(config, parent2, text, usePauseSystem);
		RenderingExtensions.SetDepthMultiplied(particleSystem, _defaultDepth, 1f);
		if (obj2 != null)
		{
			if ((object)particleSystem != null)
			{
				GameObject gameObject4 = particleSystem.gameObject;
				if ((object)gameObject4 != null)
				{
					UIParticle uIParticle3 = gameObject4.AddComponent<UIParticle>();
					uIParticle = uIParticle3;
					goto IL_0435;
				}
			}
			goto IL_035d;
		}
		goto IL_0435;
	}

	public unsafe GravityWell CreateGravityWell(GravityWellConfig config, Transform parent = null, string gravityWellName = null)
	{
		//IL_00f0: Expected O, but got Ref
		//IL_010c: Expected O, but got I4
		Transform parent2;
		if ((object)parent != null)
		{
			bool flag = ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0;
			parent2 = parent;
			if (flag)
			{
				goto IL_0169;
			}
		}
		Transform transform = base.transform;
		parent2 = transform;
		goto IL_0169;
		IL_0169:
		bool usePauseSystem = UsePauseSystem;
		GravityWell result = ParticleSystemGenerator.GenerateGravityWell(config, parent2, gravityWellName, usePauseSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99550");
		if (_particleSystems != null)
		{
			List<ParticleSystem> particleSystems = _particleSystems;
			if (particleSystems._size > 0 && config.preCacheParticles)
			{
				List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
				List<GravityWell>.Enumerator enumerator3 = default(List<GravityWell>.Enumerator);
				while (enumerator.MoveNext())
				{
					bool flag2 = _gravityWells == null;
					List<ParticleSystem>.Enumerator enumerator2 = (List<ParticleSystem>.Enumerator)(&enumerator);
					if (flag2)
					{
						throw new NullReferenceException();
					}
					if (enumerator3.MoveNext())
					{
						enumerator2 = (List<ParticleSystem>.Enumerator)0;
						throw new NullReferenceException();
					}
				}
			}
		}
		return result;
	}

	public void AddGravityWellParticleSystems(GravityWell gravityWell)
	{
		if (_particleSystems == null)
		{
			return;
		}
		List<ParticleSystem> particleSystems = _particleSystems;
		if (particleSystems._size <= 0)
		{
			return;
		}
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)gravityWell == null)
				{
					break;
				}
				gravityWell.AddParticleSystem(null);
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public void RemoveGravityWell(GravityWell gc)
	{
		List<GravityWell> gravityWells = _gravityWells;
		if (gravityWells._size != 0)
		{
			int num = Array.IndexOf((object[])gravityWells._items, (object)gc, 0, gravityWells._size);
			if (num != -1)
			{
				bool flag = ((List<object>)(object)_gravityWells).Remove((object)gc);
			}
		}
	}

	public void UpdateGravityWellConfig(GravityWellConfig gc)
	{
		//IL_0013: Expected O, but got I4
		List<GravityWell>.Enumerator enumerator = default(List<GravityWell>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public float GetRemainingLifetime()
	{
		//IL_009b: Invalid comparison between I4 and F4
		//IL_0061: Expected F4, but got I4
		float num = -3.4028235E+38f;
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		while (enumerator.MoveNext())
		{
			float remainingLifetime = RenderingExtensions.GetRemainingLifetime(null);
			if (remainingLifetime > num)
			{
				num = remainingLifetime;
			}
		}
		if (0f > num)
		{
			num = 0f;
		}
		return num;
	}

	public ParticleEmitterManager SetDepth(int depth)
	{
		//IL_002d: Expected F4, but got I4
		_defaultDepth = depth;
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		while (enumerator.MoveNext())
		{
			RenderingExtensions.SetDepth((ParticleSystem)null, depth);
		}
		return this;
	}

	public void SetDepthMultiplied(float depth, float mul = 100f)
	{
		float defaultDepth = depth * mul;
		_defaultDepth = defaultDepth;
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		while (enumerator.MoveNext())
		{
			RenderingExtensions.SetDepthMultiplied((ParticleSystem)null, depth, mul);
		}
	}

	public void EmitParticleAt(Vector2 pos, int count = 1)
	{
		//IL_0078->IL0078: Incompatible stack heights: 1 vs 0
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rbx_v5 (System.Object)+10]");
			ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, count);
		}
	}

	public void EmitParticleTowards(Vector2 pos, Vector3 direction, int count = 1)
	{
		//IL_007d->IL007d: Incompatible stack heights: 1 vs 0
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		ParticleSystem.EmitParams emitParams = default(ParticleSystem.EmitParams);
		while (enumerator.MoveNext())
		{
			object obj = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v5 (System.Object)+10]");
			bool flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbx_v5 (System.Object)+10]");
			ParticleSystem.Emit_Injected((IntPtr)0, ref emitParams, count);
		}
	}

	public void RemoveEmitter(ParticleSystem sys)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004A40");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)_particleSystems).Remove((object)sys);
		}
		List<GravityWell> gravityWells = _gravityWells;
		List<GravityWell>.Enumerator enumerator = default(List<GravityWell>.Enumerator);
		if (gravityWells._size <= 0 || !enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public void StartAllEmitters()
	{
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		while (enumerator.MoveNext())
		{
			RenderingExtensions.Start(null);
		}
	}

	public void StopAllEmitters()
	{
		//IL_001d: Expected I, but got O
		List<ParticleSystem>.Enumerator enumerator = default(List<ParticleSystem>.Enumerator);
		if (enumerator.MoveNext())
		{
			nint num = (nint)typeof(RenderingExtensions);
			throw new NullReferenceException();
		}
	}

	public void DestroyAllOwnedSystems()
	{
		//IL_0018: Expected O, but got I4
		//IL_01f3: Expected O, but got I4
		//IL_0413: Expected I, but got O
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_0497: Expected I, but got O
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_0073->IL037c: Incompatible stack heights: 1 vs 0
		//IL_00aa->IL037c: Incompatible stack heights: 1 vs 0
		//IL_024c->IL037c: Incompatible stack heights: 1 vs 0
		//IL_0283->IL037c: Incompatible stack heights: 1 vs 0
		//IL_0101->IL0418: Incompatible stack heights: 2 vs 0
		//IL_0106->IL0106: Incompatible stack heights: 2 vs 0
		//IL_02d9->IL049c: Incompatible stack heights: 2 vs 0
		//IL_02de->IL02de: Incompatible stack heights: 2 vs 0
		List<ParticleSystem> particleSystems = _particleSystems;
		bool flag = (nint)_particleSystems < 0;
		if (_particleSystems != null)
		{
			object obj = particleSystems._size - 1;
			if (flag)
			{
				goto IL_0106;
			}
			while (true)
			{
				List<ParticleSystem> particleSystems2 = _particleSystems;
				if (_particleSystems == null)
				{
					break;
				}
				bool flag2 = (nint)obj >= particleSystems2._size;
				ParticleSystem[] items = particleSystems2._items;
				if (particleSystems2._items == null)
				{
					break;
				}
				object obj2 = items[obj];
				if ((object)items[obj] == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdi_v9 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdi_v9 (System.Object)+10]");
				IntPtr gcHandlePtr = Component.get_gameObject_Injected((IntPtr)0);
				GameObject obj3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr);
				nint num = (nint)typeof(UnityEngine.Object);
				UnityEngine.Object.Destroy(obj3, 0f);
				obj--;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v725 @ rcx_v24 (Il2CppClass<UnityEngine.Object>)+E4]");
				if ((nint)0 >= (nint)0)
				{
					continue;
				}
				goto IL_0106;
			}
		}
		goto IL_037c;
		IL_037c:
		throw new NullReferenceException();
		IL_0106:
		List<ParticleSystem> particleSystems3 = _particleSystems;
		if (_particleSystems != null)
		{
			int version = particleSystems3._version + 1;
			particleSystems3._version = version;
			particleSystems3._size = 0;
			if (particleSystems3._size > 0)
			{
				Array.Clear(particleSystems3._items, 0, particleSystems3._size);
			}
			List<GravityWell> gravityWells = _gravityWells;
			bool flag4 = (nint)_gravityWells < 0;
			if (_gravityWells != null)
			{
				object obj4 = gravityWells._size - 1;
				if (flag4)
				{
					goto IL_02de;
				}
				while (true)
				{
					List<GravityWell> gravityWells2 = _gravityWells;
					if (_gravityWells == null)
					{
						break;
					}
					bool flag5 = (nint)obj4 >= gravityWells2._size;
					GravityWell[] items2 = gravityWells2._items;
					if (gravityWells2._items == null)
					{
						break;
					}
					object obj5 = items2[obj4];
					if ((object)items2[obj4] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v13 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdi_v13 (System.Object)+10]");
					IntPtr gcHandlePtr2 = Component.get_gameObject_Injected((IntPtr)0);
					GameObject obj6 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<GameObject>(gcHandlePtr2);
					nint num2 = (nint)typeof(UnityEngine.Object);
					UnityEngine.Object.Destroy(obj6, 0f);
					obj4--;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ rcx_v41 (Il2CppClass<UnityEngine.Object>)+E4]");
					if ((nint)0 >= (nint)0)
					{
						continue;
					}
					goto IL_02de;
				}
			}
		}
		goto IL_037c;
		IL_02de:
		List<GravityWell> gravityWells3 = _gravityWells;
		if (_gravityWells != null)
		{
			int version2 = gravityWells3._version + 1;
			gravityWells3._version = version2;
			gravityWells3._size = 0;
			if (gravityWells3._size > 0)
			{
				Array.Clear(gravityWells3._items, 0, gravityWells3._size);
			}
			return;
		}
		goto IL_037c;
	}

	public ParticleEmitterManager()
	{
		List<ParticleSystem> particleSystems = new List<ParticleSystem>();
		_particleSystems = particleSystems;
		List<GravityWell> gravityWells = new List<GravityWell>();
		_gravityWells = gravityWells;
		base._onResumeSent = true;
	}
}
