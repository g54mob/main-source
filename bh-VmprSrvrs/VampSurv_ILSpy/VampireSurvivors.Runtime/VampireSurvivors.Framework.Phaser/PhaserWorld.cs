using System;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;

namespace VampireSurvivors.Framework.Phaser;

public class PhaserWorld : GameMonoBehaviour
{
	private bool _EnableHideFlags;

	private Transform _phaserSpritesParent;

	private static PhaserWorld _instance;

	public static PhaserWorld Instance
	{
		get
		{
			PhaserWorld instance = _instance;
			if ((object)_instance == null || ((UnityEngine.Object)instance).m_CachedPtr == (IntPtr)0)
			{
				PhaserWorld instance2 = UnityEngine.Object.FindObjectOfType<PhaserWorld>(includeInactive: true);
				_instance = instance2;
				if ((object)_instance == null)
				{
					return (PhaserWorld)(object)new NullReferenceException();
				}
				_instance.GenerateParents();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
		GenerateParents();
	}

	public T AddPhaserSpriteOfType<T>(float2 pos, string texture = null, string spriteName = null) where T : PhaserSprite
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ stack_28+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ stack_28+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		if ((object)_phaserSpritesParent != null)
		{
			GameObject gameObject = _phaserSpritesParent.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183115F90");
			T result = default(T);
			return result;
		}
		return (T)(object)new NullReferenceException();
	}

	public PhaserSprite AddPhaserSprite(Vector2 pos, SpriteTextureData sprite)
	{
		return AddPhaserSprite(pos, sprite.Texture, sprite.Sprite);
	}

	public PhaserSprite AddPhaserSprite(Vector2 pos, string texture = null, string spriteName = null)
	{
		if ((object)_phaserSpritesParent != null)
		{
			GameObject gameObject = _phaserSpritesParent.gameObject;
			return RenderingExtensions.AddPhaserSprite(gameObject, pos, texture, spriteName);
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	public PhaserSprite AddRectangle(Vector2 pos, float width, float height, uint fillColor)
	{
		//IL_0063: Expected O, but got I4
		if ((object)_phaserSpritesParent != null)
		{
			GameObject gameObject = _phaserSpritesParent.gameObject;
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "WhiteDot");
			if ((object)phaserSprite != null)
			{
				PhaserSprite phaserSprite2 = phaserSprite.setScale(width, (float?)(object)1);
				uint tint = default(uint);
				PhaserSprite phaserSprite3 = phaserSprite.setTint(tint);
				return phaserSprite;
			}
		}
		return (PhaserSprite)(object)new NullReferenceException();
	}

	private void GenerateParents()
	{
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, "PhaserSprites");
		Transform phaserSpritesParent = gameObject.transform;
		_phaserSpritesParent = phaserSpritesParent;
		Transform parent = base.transform;
		_phaserSpritesParent.SetParent(parent, worldPositionStays: true);
		GameObject gameObject2 = _phaserSpritesParent.gameObject;
		bool flag = !_EnableHideFlags;
		bool flag2 = !flag;
		gameObject2.hideFlags = (flag2 ? HideFlags.HideInHierarchy : HideFlags.None);
	}

	private void ToggleHideFlags()
	{
		GameObject gameObject = _phaserSpritesParent.gameObject;
		GameObject gameObject2 = _phaserSpritesParent.gameObject;
		HideFlags hideFlags = gameObject2.hideFlags;
		bool flag = hideFlags == HideFlags.None;
		gameObject.hideFlags = (flag ? HideFlags.HideInHierarchy : HideFlags.None);
	}

	public PhaserWorld()
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
