using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects;

public class MagnetZone : ArcadeSprite
{
	private SpriteRenderer _renderer;

	private Transform _cachedTransform;

	private VampireSurvivors.Objects.Characters.CharacterController _targetCharacter;

	public EggFloat Radius;

	public VampireSurvivors.Objects.Characters.CharacterController TargetCharacter => _targetCharacter;

	private void Awake()
	{
		Transform cachedTransform = base.transform;
		_cachedTransform = cachedTransform;
		object cachedTransform2 = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rdi_v1 (System.Object)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		GameObject gameObject = base.gameObject;
		Vector2 pos = default(Vector2);
		SpriteRenderer renderer = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "WhiteDot");
		_renderer = renderer;
	}

	public void Init(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		_targetCharacter = character;
		Transform cachedTransform = _cachedTransform;
		if ((object)character != null)
		{
			Transform transform = character.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				bool flag2 = (object)_cachedTransform == null;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
				PhaserScene s_scene = ArcadePhysics.s_scene;
				bool flag4 = ArcadePhysics.s_scene == null;
				Factory add = s_scene.add;
				bool flag5 = s_scene.add == null;
				bool flag6 = add._world == null;
				PhaserGameObject phaserGameObject = add._world.enableBody(this);
				bool flag7 = (object)_renderer == null;
				_renderer.enabled = false;
				RefreshSize();
				object cachedTransform2 = _cachedTransform;
				bool flag8 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rdi_v10 (System.Object)+10]");
				bool flag9 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ rdi_v10 (System.Object)+10]");
				Transform.get_localPosition_Injected((IntPtr)0, out ret);
				object cachedTransform3 = _cachedTransform;
				bool flag10 = (object)_cachedTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rdi_v11 (System.Object)+10]");
				bool flag11 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ rdi_v11 (System.Object)+10]");
				Transform.set_localPosition_Injected((IntPtr)0, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void RefreshSize()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0225: Expected O, but got I4
		//IL_0225: Expected O, but got I4
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		EggFloat radius = Radius;
		float num = radius._eggVal + radius._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E2FD1Ah\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_0239;
			}
		}
		num = 3.4028235E+38f;
		goto IL_0239;
		IL_0239:
		EggFloat radius2 = Radius;
		float num2 = radius2._eggVal + radius2._val;
		object obj3 = num2 & -2147483649L;
		if ((nint)obj3 != 2139095040)
		{
			object obj4 = num2 & -2147483649L;
			if ((nint)obj4 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E2FD5Eh\"");
				if (num2 != -1f / 0f)
				{
				}
			}
		}
		EggFloat radius3 = Radius;
		float num3 = radius3._eggVal + radius3._val;
		object obj5 = num3 & -2147483649L;
		if ((nint)obj5 != 2139095040)
		{
			object obj6 = num3 & -2147483649L;
			if ((nint)obj6 <= 2139095040)
			{
				bool flag = num3 == -1f / 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186E2FDB3h\"");
				if (flag)
				{
				}
			}
		}
		BaseBody baseBody = body.setCircle(num, (float?)(object)1, (float?)(object)1);
	}

	public MagnetZone()
	{
		EggFloat radius = new EggFloat(30f);
		Radius = radius;
		((GameMonoBehaviour)this)._onResumeSent = true;
	}
}
