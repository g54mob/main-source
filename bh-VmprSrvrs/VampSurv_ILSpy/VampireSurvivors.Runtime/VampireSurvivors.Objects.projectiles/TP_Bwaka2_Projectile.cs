using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Bwaka2_Projectile : TP_Bwaka1_Projectile
{
	private TrailRenderer _Trail;

	protected override string FrameName
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A41EA]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			return "TP_VFX_BwakaKnife";
		}
	}

	protected override bool InfiniteBounces => true;

	protected override float Radius => 16f;

	protected override float OrbitRadius => 20f;

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		base.InitProjectile(pool, weapon, index);
		TrailRenderer trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			SetupTrail();
		}
	}

	private void SetupTrail()
	{
		//IL_0354->IL02d0: Incompatible stack heights: 1 vs 0
		//IL_03a3->IL02d0: Incompatible stack heights: 1 vs 0
		//IL_01d5->IL02d0: Incompatible stack heights: 3 vs 0
		//IL_02a7->IL02d0: Incompatible stack heights: 7 vs 0
		float saturationMax = default(float);
		float valueMin = default(float);
		float valueMax = default(float);
		float alphaMin = default(float);
		Color color = UnityEngine.Random.ColorHSV(0.6f, 0.7f, 1f, saturationMax, valueMin, valueMax, alphaMin, 1f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		if ((object)_Trail != null)
		{
			_Trail.time = 0.5f;
			if ((object)_Trail != null)
			{
				_Trail.endWidth = 0.02f;
				_Trail.startWidth = 0.02f;
				Sprite sprite = default(Sprite);
				RenderingExtensions.SetMaterialToPackedSpriteInternal((Renderer)_Trail, sprite, true);
				if ((object)_Trail != null)
				{
					Material material = ((Renderer)_Trail).GetMaterial();
					RenderingExtensions.SetAlpha(material, 1f);
					TrailRenderer trail = _Trail;
					if ((object)_Trail != null)
					{
						bool flag = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
						TrailRenderer.Clear_Injected(((UnityEngine.Object)trail).m_CachedPtr);
						if ((object)_Trail != null)
						{
							_Trail.emitting = true;
							Gradient gradient = new Gradient();
							IntPtr ptr = Gradient.Init();
							gradient.m_Ptr = ptr;
							gradient.m_RequiresNativeCleanup = true;
							GradientColorKey[] array = new GradientColorKey[2];
							if (array != null)
							{
								bool flag2 = array.Length <= 0;
								_ = color.r;
								_ = 0;
								bool flag3 = array.Length <= 1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
								_ = 0;
								_ = 1f;
								GradientAlphaKey[] array2 = new GradientAlphaKey[4];
								if (array2 != null)
								{
									bool flag4 = array2.Length <= 0;
									_ = 1061997773;
									bool flag5 = array2.Length <= 1;
									_ = 1061997773;
									_ = 1056964608;
									bool flag6 = array2.Length <= 2;
									_ = 1056964608;
									_ = 1056964608;
									bool flag7 = array2.Length <= 3;
									_ = 1036831949;
									_ = 1065353216;
									gradient.SetKeys(array, array2);
									if ((object)_Trail != null)
									{
										_Trail.colorGradient = gradient;
										TrailRendererPauseController trailRendererPauseController = RenderingExtensions.AddPauseController(_Trail);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}
}
