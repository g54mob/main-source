using System;
using Cpp2ILInjected;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Graphics;

public class VFXManager : IInitializable
{
	private SignalBus _signalBus;

	private static HitVFXData[] Config;

	private static Material[] VfxTypeMaterialsCache;

	public void Initialize()
	{
		//IL_02d3: Expected O, but got I4
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		object obj = 0;
		while (true)
		{
			HitVFXData[] config = Config;
			if ((nint)obj >= config.Length)
			{
				break;
			}
			HitVFXData[] config2 = Config;
			config2[obj] = null;
			obj++;
		}
		ResourcesAPI activeAPI = ResourcesAPI.ActiveAPI;
		Shader shader = activeAPI.FindShaderByName("Shader Graphs/BaseSpriteShader");
		string impactFrameName = default(string);
		float duration = default(float);
		Shader baseSpriteShader = default(Shader);
		AddData(HitVfxType.None, hasTintFill: false, "#ffffff", "", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Push, hasTintFill: true, "#ddffdd", "NoDraw", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Default, hasTintFill: true, "#ffffff", "HitStar2", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.TimeFreeze, hasTintFill: true, "#0000ff", "feedback-4", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Fire, hasTintFill: true, "#ff0000", "Hit1", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Dark, hasTintFill: true, "#220044", "HitMoon2", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Light, hasTintFill: true, "#44ffff", "HitStar2", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Prism, hasTintFill: true, "#ffffff", "s_pfx_rainbow_32", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Red, hasTintFill: true, "#ffeeee", "HitCross1", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Blue, hasTintFill: true, "#eeeeff", "HitCross2", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Beam, hasTintFill: true, "#ffffff", "HitStarWhite2", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Evil, hasTintFill: true, "#110022", "HitMoon2", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Wind, hasTintFill: true, "#00ff00", "HitStarWhite2", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Yellow, hasTintFill: true, "#fffc99", "HitStar2", impactFrameName, duration, baseSpriteShader);
		AddData(HitVfxType.Water, hasTintFill: true, "#ddddff", "HitCloud1", impactFrameName, duration, baseSpriteShader);
	}

	private static Sprite GetVfxSprite(string frameName)
	{
		if (frameName != null && frameName._stringLength > 0)
		{
			return SpriteManager.GetSprite(frameName, "vfx");
		}
		return null;
	}

	public static HitVFXData GetData(HitVfxType vfxType)
	{
		HitVFXData[] config = Config;
		if ((int)vfxType < config.Length)
		{
			return config[(int)vfxType];
		}
		return (HitVFXData)(object)new IndexOutOfRangeException();
	}

	public static Material GetMaterial(HitVfxType type)
	{
		Material[] vfxTypeMaterialsCache = VfxTypeMaterialsCache;
		if ((int)type < vfxTypeMaterialsCache.Length)
		{
			return vfxTypeMaterialsCache[(int)type];
		}
		return (Material)(object)new IndexOutOfRangeException();
	}

	private static void AddData(HitVfxType t, bool hasTintFill, string color, string hitFrameName, string impactFrameName, float duration, Shader baseSpriteShader)
	{
		//IL_00cd: Expected I, but got O
		Sprite hitSprite;
		if (hitFrameName != null && hitFrameName._stringLength > 0)
		{
			Sprite sprite = SpriteManager.GetSprite(hitFrameName, "vfx");
			hitSprite = sprite;
		}
		else
		{
			hitSprite = null;
		}
		string text = default(string);
		if (text != null && text._stringLength > 0)
		{
			Sprite sprite2 = SpriteManager.GetSprite(text, "vfx");
		}
		Sprite impactSprite = default(Sprite);
		float duration2 = default(float);
		HitVFXData hitVFXData = new HitVFXData(hasTintFill, color, hitSprite, impactSprite, duration2);
		HitVFXData[] config = Config;
		if (hitVFXData != null)
		{
			nint num = (nint)config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Shader baseSpriteShader2 = default(Shader);
		TryCacheVfxHitMaterial(t, hasTintFill, hitVFXData, baseSpriteShader2);
	}

	public static void SpawnImpactVFX(HitVfxType type, Vector2 worldPos)
	{
		ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("ImpactVfx");
		GameObject gameObject = pool.GetObject();
		HitVfx component = gameObject.GetComponent<HitVfx>();
		HitVFXData[] config = Config;
		Transform transform = component.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		component._data = config[(int)type];
		HitVFXData data = component._data;
		component._Hit.sprite = data.HitSprite;
		HitVFXData data2 = component._data;
		component._Impact.sprite = data2.ImpactSprite;
		component.PlayAnim();
		gameObject.SetActive(value: true);
	}

	private unsafe static void TryCacheVfxHitMaterial(HitVfxType t, bool hasTintFill, HitVFXData dat, Shader baseSpriteShader)
	{
		//IL_008c: Expected I4, but got O
		//IL_00b1: Expected O, but got Ref
		//IL_00fb: Expected F4, but got I4
		//IL_0302: Expected O, but got I
		//IL_02bd: Expected O, but got I
		//IL_01e5: Expected O, but got I
		//IL_0205: Expected O, but got I
		//IL_0172: Expected O, but got I
		//IL_0182: Expected O, but got I
		//IL_022d: Expected I, but got O
		//IL_036c->IL0260: Incompatible stack heights: 2 vs 0
		//IL_0371->IL0225: Incompatible stack heights: 2 vs 3
		//IL_025f->IL025f: Incompatible stack heights: 4 vs 0
		Material[] vfxTypeMaterialsCache = VfxTypeMaterialsCache;
		Material[] vfxTypeMaterialsCache2 = default(Material[]);
		if (VfxTypeMaterialsCache != null)
		{
			if ((int)t >= vfxTypeMaterialsCache.Length)
			{
				throw new IndexOutOfRangeException();
			}
			Material material = vfxTypeMaterialsCache[(int)t];
			if ((object)vfxTypeMaterialsCache[(int)t] != null && ((UnityEngine.Object)material).m_CachedPtr != (IntPtr)0)
			{
				return;
			}
			Material material2 = new Material(baseSpriteShader);
			object obj = default(object);
			object arg = (HitVfxType)obj;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj2 = default(object);
			string name = string.FormatHelper((IFormatProvider)null, "BaseSpriteShader-{0}", (System.ParamsArray)(&obj2));
			if ((object)material2 != null)
			{
				((UnityEngine.Object)material2).SetName(name);
				material2.SetFloatImpl(RenderingExtensions.ApplyTintFill, (float)(hasTintFill ? 1 : 0));
				bool num;
				bool num2;
				if (hasTintFill)
				{
					if (dat == null)
					{
						goto IL_0260;
					}
					bool flag = (object)dat.CachedTintColor == null;
					num = flag;
					int tintFillColor = RenderingExtensions.TintFillColor;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v30 (UnityEngine.Material)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v30 (UnityEngine.Material)+10]");
					bool flag2 = (nint)0 == 0;
					num2 = flag2;
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [dat @ r8 (VampireSurvivors.Graphics.HitVFXData)+38]");
					paramsArray = (System.ParamsArray)0;
				}
				else
				{
					if (dat == null)
					{
						goto IL_0260;
					}
					bool flag3 = (object)dat.CachedTintColor == null;
					num = flag3;
					int tintFillColor = RenderingExtensions.TintColor;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v30 (UnityEngine.Material)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v403 @ rax_v30 (UnityEngine.Material)+10]");
					bool flag4 = (nint)0 == 0;
					num2 = flag4;
					object obj4 = 0;
					bool flag5 = (nint)0 != 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [dat @ r8 (VampireSurvivors.Graphics.HitVFXData)+38]");
					paramsArray = (System.ParamsArray)0;
					if (!flag5)
					{
						bool flag6 = (nint)0 == 0;
						goto IL_0225;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v967 @ rax_v41 (should have been resolved before IL gen)");
				vfxTypeMaterialsCache2 = VfxTypeMaterialsCache;
				if (VfxTypeMaterialsCache != null)
				{
					goto IL_0225;
				}
			}
		}
		goto IL_0260;
		IL_0225:
		nint num3 = (nint)vfxTypeMaterialsCache2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		bool flag7 = obj5 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		return;
		IL_0260:
		throw new NullReferenceException();
	}

	static VFXManager()
	{
		HitVFXData[] config = new HitVFXData[16];
		Config = config;
		Material[] vfxTypeMaterialsCache = new Material[16];
		VfxTypeMaterialsCache = vfxTypeMaterialsCache;
	}
}
