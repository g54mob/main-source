using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;

public class UIImageUVRemap : BaseMeshEffect, IMaterialModifier
{
	private static readonly int UVRemapID;

	private static readonly int RainbowOffsetID;

	private float Seed;

	private Vector4 uvRemap;

	private int rotMode;

	private Image _img;

	protected override void Awake()
	{
		//IL_002c: Expected O, but got F4
		Image component = GetComponent<Image>();
		_img = component;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float seed = (float)obj2 * 100f;
		Seed = seed;
	}

	private void RegenerateSeed()
	{
		//IL_000e: Expected O, but got F4
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float seed = (float)obj2 * 100f;
		Seed = seed;
	}

	private void TryUpdate()
	{
		Sprite sprite;
		while (true)
		{
			Image img = _img;
			if ((object)_img == null || ((UnityEngine.Object)img).m_CachedPtr == (IntPtr)0)
			{
				Image component = GetComponent<Image>();
				_img = component;
			}
			Image img2 = _img;
			if ((object)_img != null && ((UnityEngine.Object)img2).m_CachedPtr != (IntPtr)0)
			{
				Image img3 = _img;
				sprite = img3.m_Sprite;
			}
			else
			{
				sprite = null;
			}
			if ((object)sprite != null && ((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
			{
				Texture2D texture = sprite.texture;
				if ((object)texture == null || ((UnityEngine.Object)texture).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				if (((UnityEngine.Object)sprite).m_CachedPtr != (IntPtr)0)
				{
					break;
				}
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(sprite);
				continue;
			}
			return;
		}
		Sprite.GetTextureRect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect _);
		Texture2D texture2 = sprite.texture;
		Vector2 texelSize = texture2.texelSize;
		Vector4 vector = default(Vector4);
		uvRemap = vector;
	}

	protected override void OnEnable()
	{
		//IL_00a4: Expected O, but got F4
		Graphic graphic = base.graphic;
		if ((object)graphic != null && ((UnityEngine.Object)graphic).m_CachedPtr != (IntPtr)0)
		{
			Graphic graphic2 = base.graphic;
			graphic2.SetVerticesDirty();
		}
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float seed = (float)obj2 * 100f;
		Seed = seed;
		TryUpdate();
		base.graphic?.SetMaterialDirty();
	}

	protected override void OnDisable()
	{
		Graphic graphic = base.graphic;
		if ((object)graphic != null && ((UnityEngine.Object)graphic).m_CachedPtr != (IntPtr)0)
		{
			Graphic graphic2 = base.graphic;
			graphic2.SetVerticesDirty();
		}
		base.graphic?.SetMaterialDirty();
	}

	public override void ModifyMesh(VertexHelper vh)
	{
	}

	public unsafe Material GetModifiedMaterial(Material baseMat)
	{
		//IL_00c2: Expected O, but got I4
		//IL_008b: Expected O, but got Ref
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj = Behaviour.get_isActiveAndEnabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj != null && (object)baseMat != null && ((UnityEngine.Object)baseMat).m_CachedPtr != (IntPtr)0)
		{
			TryUpdate();
			Material material = new Material(baseMat);
			object obj2 = default(object);
			material.SetVector(UVRemapID, (Vector4)(&obj2));
			material.SetFloatImpl(RainbowOffsetID, Seed);
			return material;
		}
		return baseMat;
	}

	public UIImageUVRemap()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	static UIImageUVRemap()
	{
		int uVRemapID = Shader.PropertyToID("_UVRemap");
		UVRemapID = uVRemapID;
		int rainbowOffsetID = Shader.PropertyToID("_RainbowOffset");
		RainbowOffsetID = rainbowOffsetID;
	}
}
