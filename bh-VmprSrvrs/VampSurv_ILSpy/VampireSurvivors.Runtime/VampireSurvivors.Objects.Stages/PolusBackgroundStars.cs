using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;

namespace VampireSurvivors.Objects.Stages;

public class PolusBackgroundStars : GameMonoBehaviour
{
	private Vector2 _DefaultPosition;

	private Vector2 _InversePosition;

	private Material _DefaultStarsMaterial;

	private Material _InvertedStarsMaterial;

	private SpriteRenderer _starsRenderer;

	private SpriteRenderer StarsRenderer
	{
		get
		{
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_015b: Expected O, but got I4
			SpriteRenderer starsRenderer = _starsRenderer;
			SpriteRenderer spriteRenderer;
			if ((object)_starsRenderer == null || ((UnityEngine.Object)starsRenderer).m_CachedPtr == (IntPtr)0)
			{
				spriteRenderer = GetComponent<SpriteRenderer>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_starsRenderer = spriteRenderer;
				if (flag)
				{
					goto IL_0129;
				}
				object obj = this + 72;
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj3 & 0x3F;
				object obj6 = obj4 * 8;
				object obj7 = 6603864928L + obj6;
				do
				{
					object obj8 = 1 << (int)obj5;
					object obj9 = obj7 | obj8;
					if (obj7 == obj7)
					{
						obj7 = obj9;
					}
				}
				while (obj7 != obj7);
			}
			spriteRenderer = _starsRenderer;
			goto IL_0129;
			IL_0129:
			return spriteRenderer;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		GameManager core = GM.Core;
		Action action = OnGameInitialized;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2530");
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		GameManager core = GM.Core;
		Action action = OnGameInitialized;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA64D0");
	}

	private unsafe void OnGameInitialized()
	{
		//IL_0247: Expected O, but got Ref
		//IL_0299: Expected O, but got Ref
		//IL_0205->IL0106: Incompatible stack heights: 2 vs 1
		//IL_0164->IL0179: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL0106: Incompatible stack heights: 2 vs 1
		//IL_00f1->IL0179: Incompatible stack heights: 2 vs 0
		//IL_0106->IL027a: Incompatible stack heights: 2 vs 1
		Transform transform = base.transform;
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				Vector3 value = default(Vector3);
				SpriteRenderer starsRenderer;
				Material material;
				if (!config._003CSelectedInverse_003Ek__BackingField)
				{
					bool flag = (object)transform == null;
					bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					transform.localEulerAngles = (Vector3)(&value);
					Transform defaultStarsMaterial = (Transform)(object)_DefaultStarsMaterial;
					if ((object)_DefaultStarsMaterial == null || ((UnityEngine.Object)defaultStarsMaterial).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					starsRenderer = StarsRenderer;
					if ((object)starsRenderer == null)
					{
						goto IL_0179;
					}
					material = _DefaultStarsMaterial;
				}
				else
				{
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					object obj = default(object);
					transform.localEulerAngles = (Vector3)(&obj);
					Transform invertedStarsMaterial = (Transform)(object)_InvertedStarsMaterial;
					if ((object)_InvertedStarsMaterial == null || ((UnityEngine.Object)invertedStarsMaterial).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					starsRenderer = StarsRenderer;
					if ((object)starsRenderer == null)
					{
						goto IL_0179;
					}
					material = _InvertedStarsMaterial;
				}
				((Renderer)starsRenderer).SetMaterial(material);
				return;
			}
		}
		goto IL_0179;
		IL_0179:
		throw new NullReferenceException();
	}

	public PolusBackgroundStars()
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
