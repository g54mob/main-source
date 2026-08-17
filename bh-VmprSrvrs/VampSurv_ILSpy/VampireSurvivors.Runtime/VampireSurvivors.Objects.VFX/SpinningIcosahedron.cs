using System;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using QFSW.MOP2;
using UnityEngine;

namespace VampireSurvivors.Objects.VFX;

public class SpinningIcosahedron : PoolableMonoBehaviour
{
	private Transform _icosahedronTransform;

	private Transform _trailRendererTransform;

	private Tween rotationTween;

	private unsafe void Awake()
	{
		//IL_001e: Expected O, but got Ref
		if (rotationTween != null)
		{
			return;
		}
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_icosahedronTransform, (Vector3)(&obj), 1f, RotateMode.LocalAxisAdd);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		rotationTween = tweenerCore;
	}

	public void Reset()
	{
		//IL_0083: Expected I, but got O
		//IL_009d->IL0023: Incompatible stack heights: 1 vs 0
		Transform trailRendererTransform = _trailRendererTransform;
		if ((object)_trailRendererTransform != null)
		{
			bool flag = ((UnityEngine.Object)trailRendererTransform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)trailRendererTransform).m_CachedPtr, ref value);
			nint num = (nint)_icosahedronTransform;
			if ((object)_icosahedronTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdi_v7 (System.IntPtr)+10]");
				bool flag2 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdi_v7 (System.IntPtr)+10]");
				Vector3 value2 = default(Vector3);
				Transform.set_localScale_Injected((IntPtr)0, ref value2);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void ShrinkAndRecycle(float durationInSeconds = 0.25f)
	{
		//IL_00af: Expected O, but got Ref
		//IL_006f: Expected O, but got Ref
		Vector3 vector = default(Vector3);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_icosahedronTransform, (Vector3)(&vector), durationInSeconds);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback = Cleanup;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(_trailRendererTransform, (Vector3)(&vector), durationInSeconds);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
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

	public SpinningIcosahedron()
	{
		//IL_0020: Expected I, but got O
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
