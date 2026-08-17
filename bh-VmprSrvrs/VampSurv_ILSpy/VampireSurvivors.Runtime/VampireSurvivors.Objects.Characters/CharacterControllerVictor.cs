using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerVictor : CharacterController
{
	private float _armorBonus;

	private float _armorDelay = 10000f;

	private float _armorTime;

	public override float PArmor()
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
		float value = default(float);
		EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
		value = eggFloat._val + _armorBonus;
		float num = eggFloat2._eggVal + eggFloat2._val;
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875C4F67h\"");
				if (num == -1f / 0f)
				{
					num = -3.4028235E+38f;
				}
				goto IL_011d;
			}
		}
		num = 3.4028235E+38f;
		goto IL_011d;
		IL_011d:
		bool flag = !(50f > num);
		float num2 = 50f;
		if (!flag)
		{
			num2 = num;
		}
		return num2 + ArmorManualIncrease;
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		_armorBonus = 0f;
		_armorTime = 0f;
	}

	public override void OnGetDamaged(string hexColor = "#ff0000", float vulnerabilityDelay = 120f, bool playDamageFx = true, bool playWeaponDamageFx = false)
	{
		//IL_0073: Invalid comparison between I4 and F4
		//IL_0085: Expected F4, but got I4
		if (!_receivingDamage)
		{
			bool playWeaponDamageFx2 = default(bool);
			bool ignoreInvulnerabilityForRestoringTint = default(bool);
			OnGetDamaged(hexColor, vulnerabilityDelay, playDamageFx, playWeaponDamageFx2, ignoreInvulnerabilityForRestoringTint);
			float armorBonus = _armorBonus + 1f;
			_armorBonus = armorBonus;
			float num = _armorTime - 1000f;
			bool flag = !(0f < num);
			float armorTime = 0f;
			if (!flag)
			{
				armorTime = num;
			}
			_armorTime = armorTime;
		}
	}

	private void AddArmor()
	{
		//IL_0037: Invalid comparison between I4 and F4
		//IL_0049: Expected F4, but got I4
		float armorBonus = _armorBonus + 1f;
		_armorBonus = armorBonus;
		float num = _armorTime - 1000f;
		bool flag = !(0f < num);
		float armorTime = 0f;
		if (!flag)
		{
			armorTime = num;
		}
		_armorTime = armorTime;
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		if (!((_armorTime = num + _armorTime) < _armorDelay))
		{
			_armorBonus = 0f;
			_armorTime = 0f;
		}
	}

	public override void LevelUp()
	{
		//IL_00aa: Expected F4, but got O
		base.LevelUp();
		if (base._level == 30)
		{
			float2 float5 = base.position;
			float2 float6 = base.position;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			float num = renderer.height * 0.45f;
			object obj = default(object);
			float y = (float)obj - num;
			Vector2 pos = default(Vector2);
			float value = default(float);
			ItemType relicType = default(ItemType);
			bool validatePickups = default(bool);
			Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, WeaponType.ACADEMYBADGE, value, relicType, validatePickups);
			GameManager core = GM.Core;
			core._gizmoManager.ShowHighlightAt((float)float5, y);
		}
	}
}
