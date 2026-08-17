using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class LEM_Planets2_Weapon : LEM_Planets1_Weapon
{
	protected override bool ShowBasePlanetCards => false;

	public override float PAmount()
	{
		//IL_0012: Expected F4, but got I
		List<PlanetData> list = base._003CPlanetList_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
		return 0f;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		AddSecretPlanets();
		StartNegativeTimer();
		AddInnerSaboteur();
	}

	private unsafe void AddSecretPlanets()
	{
		//IL_0008: Expected O, but got Ref
		//IL_066f: Expected O, but got I4
		//IL_04a2: Expected O, but got Ref
		//IL_04d4: Expected O, but got I
		//IL_0547: Expected O, but got I
		//IL_052c: Expected O, but got Ref
		//IL_058d: Expected O, but got I
		//IL_0600: Expected O, but got I
		//IL_05e5: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		obj = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		SpriteTextures.SpriteTexturesLemon lemon = SpriteTextures.Lemon;
		if (lemon.LEM_Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E5A]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			SpriteTextures.SpriteTexturesLemon lemon2 = SpriteTextures.Lemon;
			if (lemon2.LEM_Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E5B]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextures.SpriteTexturesLemon lemon3 = SpriteTextures.Lemon;
				if (lemon3.LEM_Vfx != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E43]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					_ = 1058642330;
					_ = 1092616192;
					_ = 0;
					SpriteTextures.SpriteTexturesLemon lemon4 = SpriteTextures.Lemon;
					if (lemon4.LEM_Vfx != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E70]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						SpriteTextures.SpriteTexturesLemon lemon5 = SpriteTextures.Lemon;
						if (lemon5.LEM_Vfx != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E71]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							SpriteTextures.SpriteTexturesLemon lemon6 = SpriteTextures.Lemon;
							if (lemon6.LEM_Vfx != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E4A]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								_ = 1060320051;
								_ = 1098907648;
								_ = 0;
								SpriteTextures.SpriteTexturesLemon lemon7 = SpriteTextures.Lemon;
								if (lemon7.LEM_Vfx != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E5E]");
									if ((nint)0 == 0)
									{
										_ = 1;
									}
									SpriteTextures.SpriteTexturesLemon lemon8 = SpriteTextures.Lemon;
									if (lemon8.LEM_Vfx != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E5F]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										SpriteTextures.SpriteTexturesLemon lemon9 = SpriteTextures.Lemon;
										if (lemon9.LEM_Vfx != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E45]");
											if ((nint)0 == 0)
											{
												_ = 1;
											}
											_ = 1056964608;
											_ = 1090519040;
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
											_ = 0;
											object obj3 = default(object);
											base._003CPlanetList_003Ek__BackingField.Insert(5, (PlanetData)(&obj3));
											List<PlanetData> list = base._003CPlanetList_003Ek__BackingField;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v52 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v52 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v52 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
											nint num = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ r9_v12+18]");
											if (num >= 0)
											{
												list.AddWithResize((PlanetData)(&obj3));
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v52 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
												object obj5 = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805FAB00");
											}
											List<PlanetData> list2 = base._003CPlanetList_003Ek__BackingField;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+1C]");
											_ = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+10]");
											object obj6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
											nint num2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r9_v13+18]");
											if (num2 >= 0)
											{
												list2.AddWithResize((PlanetData)(&obj3));
											}
											else
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Weapons.LEM_Planets1_Weapon+PlanetData>)+18]");
												object obj7 = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805FAB00");
											}
											ShowPlanetCard(5);
											ShowPlanetCard(11);
											ShowPlanetCard(12);
											return;
										}
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

	public unsafe override void SetVisible(bool visible)
	{
		//IL_00b1: Expected O, but got Ref
		base.SetVisible(visible);
		if (!visible)
		{
			base._003CIsNegative_003Ek__BackingField = visible;
			base._003CTiltAngle_003Ek__BackingField = 0f;
			if (_negativeTimer != null)
			{
				_negativeTimer.Cancel();
			}
			if (_tiltTween != null)
			{
				TweenExtensions.Kill(_tiltTween);
			}
			Transform transform = base._PlanetContainer.transform;
			object obj = default(object);
			transform.localEulerAngles = (Vector3)(&obj);
		}
		else
		{
			StartNegativeTimer();
		}
	}
}
