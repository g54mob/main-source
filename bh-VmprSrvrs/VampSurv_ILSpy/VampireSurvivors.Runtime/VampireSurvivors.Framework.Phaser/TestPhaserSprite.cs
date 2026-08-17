using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Framework.Phaser;

public class TestPhaserSprite : GameMonoBehaviour
{
	private PhaserSprite _phaserSprite;

	private void TestAddSprite()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29F4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserWorld instance = PhaserWorld.Instance;
		Transform transform = base.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "sPFX_ring_64");
		_phaserSprite = phaserSprite;
	}

	private void TestSetOrigin(Vector2 origin)
	{
		//IL_00d3: Expected O, but got I4
		//IL_00d3: Expected F4, but got O
		//IL_018a->IL00d8: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL00a0: Incompatible stack heights: 1 vs 0
		Transform phaserSprite = (Transform)(object)_phaserSprite;
		if ((object)_phaserSprite != null && ((UnityEngine.Object)phaserSprite).m_CachedPtr != (IntPtr)0)
		{
			goto IL_00a0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29F4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserWorld instance = PhaserWorld.Instance;
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			if ((object)instance != null)
			{
				Vector2 pos = default(Vector2);
				PhaserSprite phaserSprite2 = instance.AddPhaserSprite(pos, "vfx", "sPFX_ring_64");
				_phaserSprite = phaserSprite2;
				goto IL_00a0;
			}
		}
		goto IL_00d8;
		IL_00a0:
		if ((object)_phaserSprite != null)
		{
			PhaserSprite phaserSprite3 = _phaserSprite.setOrigin((float)origin, (float?)(object)1);
			return;
		}
		goto IL_00d8;
		IL_00d8:
		throw new NullReferenceException();
	}

	public TestPhaserSprite()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
