using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.VFX;

public class EME_ShowstopperVfx : PoolableMonoBehaviour
{
	private Transform _transform;

	private MeshRenderer _Model1;

	private static readonly int _ScrollSpeedX;

	private static readonly int _ScrollSpeedY;

	private static readonly int _AlphaMul;

	private void Awake()
	{
		Material material = ((Renderer)_Model1).GetMaterial();
		material.SetFloatImpl(_AlphaMul, 0f);
		Camera main = Camera.main;
		Transform parent = main.transform;
		Transform transform = base.transform;
		transform.SetParent(parent, worldPositionStays: true);
	}

	public void Reset()
	{
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = base.transform;
		bool flag2 = (object)transform2 == null;
		bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
		Transform transform3 = _transform;
		bool flag4 = (object)_transform == null;
		bool flag5 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
		bool flag6 = (object)_Model1 == null;
		Material material = ((Renderer)_Model1).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, 0.9f, _AlphaMul, 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag7 = tweenerCore == null;
		bool flag8 = (object)GM.Core == null;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		bool flag9 = ArcadePhysics.s_scene == null;
		PhaserScene.Renderer renderer = s_scene._renderer;
		bool flag10 = s_scene._renderer == null;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleX(endValue: renderer.width + renderer.width, target: _transform, duration: 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag11 = tweenerCore2 == null;
		bool flag12 = (object)GM.Core == null;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		bool flag13 = ArcadePhysics.s_scene == null;
		PhaserScene.Renderer renderer2 = s_scene2._renderer;
		bool flag14 = s_scene2._renderer == null;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScaleZ(endValue: renderer2.height + renderer2.height, target: _transform, duration: 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag15 = tweenerCore3 == null;
	}

	public void FadeOut()
	{
		Material material = ((Renderer)_Model1).GetMaterial();
		TweenerCore<float, float, FloatOptions> tweenerCore = ShortcutExtensions.DOFloat(material, 0f, _AlphaMul, 0.2f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback = delegate
		{
			//IL_00a3->IL0029: Incompatible stack heights: 1 vs 0
			Transform transform = _transform;
			if ((object)_transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				GameObject obj = base.gameObject;
				if ((object)base._parentPool != null)
				{
					base._parentPool.Release(obj);
					return;
				}
			}
			throw new NullReferenceException();
		};
	}

	private void Cleanup()
	{
		GameObject obj = base.gameObject;
		if ((object)base._parentPool != null)
		{
			base._parentPool.Release(obj);
			return;
		}
		throw new NullReferenceException();
	}

	public EME_ShowstopperVfx()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static EME_ShowstopperVfx()
	{
		int scrollSpeedX = Shader.PropertyToID("_ScrollSpeedX");
		_ScrollSpeedX = scrollSpeedX;
		int scrollSpeedY = Shader.PropertyToID("_ScrollSpeedY");
		_ScrollSpeedY = scrollSpeedY;
		int alphaMul = Shader.PropertyToID("_AlphaMul");
		_AlphaMul = alphaMul;
	}

	private void _003CFadeOut_003Eb__7_0()
	{
		//IL_00a3->IL0029: Incompatible stack heights: 1 vs 0
		Transform transform = _transform;
		if ((object)_transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			GameObject obj = base.gameObject;
			if ((object)base._parentPool != null)
			{
				base._parentPool.Release(obj);
				return;
			}
		}
		throw new NullReferenceException();
	}
}
