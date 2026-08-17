using System;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive.Implementations;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs.ConfigSettingsTypes;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
	public GameObject mirrorFx;

	public GameObject flexFx;

	public PlayerRenderer playerRenderer;

	public ParticleSystem dashPs;

	public ParticleSystem dashCloudPs;

	private ParticleSystem.EmissionModule dashEmission;

	private float dangerValue;

	private float dangerTarget;

	private float lastHp = -1f;

	private float timeLowHp;

	private const float dangerIncreaseSpeed = 4f;

	private const float dangerDecaySpeed = 0.02f;

	private const float sustainedLowThreshold = 15f;

	private const float lerpSpeed = 1.5f;

	private void Awake()
	{
		//IL_009e: Expected O, but got I4
		//IL_00a7: Expected O, but got I4
		//IL_00b5: Expected I, but got O
		//IL_00f6: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_010d: Expected I, but got O
		//IL_0181: Expected O, but got I4
		//IL_018a: Expected O, but got I4
		//IL_0198: Expected I, but got O
		//IL_0152: Expected I, but got O
		//IL_01d6: Expected I, but got O
		//IL_01e7: Expected O, but got I4
		//IL_01f0: Expected O, but got I4
		//IL_01fe: Expected I, but got O
		//IL_0238: Expected O, but got I4
		//IL_0241: Expected O, but got I4
		//IL_02df: Expected O, but got I4
		//IL_02e8: Expected O, but got I4
		//IL_02f6: Expected I, but got O
		//IL_0343: Expected O, but got I4
		//IL_034c: Expected O, but got I4
		//IL_035a: Expected I, but got O
		nint num3;
		nint num;
		if ((object)dashPs != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
			dashEmission = emissionModule;
			Action<bool> b = OnMirrorReady;
			Delegate obj = Delegate.Combine(ItemMirror.A_MirrorReady, b);
			Delegate obj2;
			object obj3;
			object obj4;
			if ((object)obj == null)
			{
				ItemMirror.A_MirrorReady = (Action<bool>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<bool> action = default(Action<bool>);
				bool flag = action == null;
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				num = (nint)typeof(Action<bool>);
				if (flag)
				{
					goto IL_0394;
				}
				ItemMirror.A_MirrorReady = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				num = (nint)typeof(Action<bool>);
				if (flag2)
				{
					goto IL_039f;
				}
			}
			Action<bool> b2 = OnFlexReady;
			Delegate obj6 = Delegate.Combine(PassiveAbilityFlex.A_FlexReady, b2);
			nint num2;
			if ((object)obj6 == null)
			{
				PassiveAbilityFlex.A_FlexReady = (Action<bool>)obj6;
				num2 = (nint)PassiveAbilityFlex.A_FlexReady;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<bool> action2 = default(Action<bool>);
				bool flag3 = action2 == null;
				obj2 = obj6;
				obj3 = 0;
				obj4 = 0;
				num3 = (nint)typeof(Action<bool>);
				if (flag3)
				{
					goto IL_03d7;
				}
				PassiveAbilityFlex.A_FlexReady = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj7 = default(object);
				bool flag4 = obj7 == null;
				num2 = (nint)typeof(Action<bool>);
				obj2 = obj6;
				obj3 = 0;
				obj4 = 0;
				num3 = (nint)typeof(Action<bool>);
				if (flag4)
				{
					goto IL_03ef;
				}
			}
			PlayerRenderer playerRenderer = this.playerRenderer;
			bool flag5 = (object)this.playerRenderer == null;
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			num3 = num2;
			if (!flag5)
			{
				Action<CharacterData> b3 = OnCharacterSet;
				Delegate obj8 = Delegate.Combine(playerRenderer.A_CharacterSet, b3);
				if ((object)obj8 == null)
				{
					playerRenderer.A_CharacterSet = (Action<CharacterData>)obj8;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<CharacterData> action3 = default(Action<CharacterData>);
				bool flag6 = action3 == null;
				obj2 = obj8;
				obj3 = 0;
				obj4 = 0;
				num3 = (nint)typeof(Action<CharacterData>);
				Delegate obj9 = obj8;
				if (!flag6)
				{
					playerRenderer.A_CharacterSet = action3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj10 = default(object);
					bool flag7 = obj10 == null;
					obj2 = obj8;
					obj3 = 0;
					obj4 = 0;
					num3 = (nint)typeof(Action<CharacterData>);
					if (!flag7)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
					obj9 = obj2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				goto IL_03ef;
			}
		}
		throw new NullReferenceException();
		IL_0394:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_039f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0394;
		IL_03ef:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03d7;
		IL_03d7:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num3;
		goto IL_039f;
	}

	private void OnDestroy()
	{
		//IL_0311: Expected I, but got O
		//IL_0322: Expected O, but got I4
		//IL_032b: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0115: Expected I, but got O
		//IL_0126: Expected O, but got I4
		//IL_012f: Expected O, but got I4
		//IL_00e9: Expected I, but got O
		//IL_016d: Expected I, but got O
		//IL_017b: Expected I, but got O
		//IL_018c: Expected O, but got I4
		//IL_0195: Expected O, but got I4
		//IL_01cf: Expected O, but got I4
		//IL_01d8: Expected O, but got I4
		//IL_026b: Expected I, but got O
		//IL_027c: Expected O, but got I4
		//IL_0285: Expected O, but got I4
		//IL_02cf: Expected I, but got O
		//IL_02e0: Expected O, but got I4
		//IL_02e9: Expected O, but got I4
		Action<bool> value = OnMirrorReady;
		Delegate obj = Delegate.Remove(ItemMirror.A_MirrorReady, value);
		nint num2;
		Delegate obj2;
		nint num;
		object obj3;
		object obj4;
		if ((object)obj == null)
		{
			ItemMirror.A_MirrorReady = (Action<bool>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_03cf;
			}
			ItemMirror.A_MirrorReady = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0358;
			}
		}
		Action<bool> value2 = OnFlexReady;
		Delegate obj6 = Delegate.Remove(PassiveAbilityFlex.A_FlexReady, value2);
		if ((object)obj6 == null)
		{
			PassiveAbilityFlex.A_FlexReady = (Action<bool>)obj6;
			num = (nint)PassiveAbilityFlex.A_FlexReady;
			goto IL_01a3;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<bool> action2 = default(Action<bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag2)
		{
			PassiveAbilityFlex.A_FlexReady = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<bool>);
			num2 = (nint)typeof(Action<bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (!flag3)
			{
				goto IL_01a3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0358;
		IL_03bf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03ab;
		IL_0358:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_03cf:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		Delegate obj8 = obj2;
		goto IL_03bf;
		IL_03ab:
		throw new NullReferenceException();
		IL_01a3:
		PlayerRenderer playerRenderer = this.playerRenderer;
		bool flag4 = (object)this.playerRenderer == null;
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_03ab;
		}
		Action<CharacterData> value3 = OnCharacterSet;
		Delegate obj9 = Delegate.Remove(playerRenderer.A_CharacterSet, value3);
		if ((object)obj9 == null)
		{
			playerRenderer.A_CharacterSet = (Action<CharacterData>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<CharacterData> action3 = default(Action<CharacterData>);
		bool flag5 = action3 == null;
		num = (nint)typeof(Action<CharacterData>);
		obj2 = obj9;
		obj3 = 0;
		obj4 = 0;
		obj8 = obj9;
		if (flag5)
		{
			goto IL_03bf;
		}
		playerRenderer.A_CharacterSet = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj10 = default(object);
		bool flag6 = obj10 == null;
		num = (nint)typeof(Action<CharacterData>);
		obj2 = obj9;
		obj3 = 0;
		obj4 = 0;
		if (!flag6)
		{
			return;
		}
		goto IL_03cf;
	}

	private unsafe void OnCharacterSet(CharacterData characterData)
	{
		//IL_006e: Expected O, but got Ref
		//IL_00e0: Expected O, but got Ref
		Transform transform = flexFx.transform;
		Vector3 position = transform.position;
		Transform transform2 = playerRenderer.transform;
		Vector3 position2 = transform2.position;
		Transform transform3 = flexFx.transform;
		float num = default(float);
		transform3.position = (Vector3)(&num);
		Transform transform4 = mirrorFx.transform;
		Vector3 position3 = transform4.position;
		Transform transform5 = playerRenderer.transform;
		Vector3 position4 = transform5.position;
		Transform transform6 = mirrorFx.transform;
		transform6.position = (Vector3)(&num);
	}

	private void Update()
	{
		//IL_0510: Invalid comparison between I4 and F4
		//IL_03d4: Expected F4, but got I4
		//IL_0267: Invalid comparison between I4 and F4
		//IL_034c: Expected O, but got I4
		//IL_05f0: Expected F4, but got I4
		//IL_04af: Expected F4, but got I4
		//IL_0433: Invalid comparison between F4 and I4
		//IL_05d3: Invalid comparison between O and F4
		//IL_0388: Expected F4, but got I4
		//IL_059d: Invalid comparison between I4 and F4
		//IL_05ac: Expected O, but got I4
		//IL_029d: Invalid comparison between F4 and I4
		//IL_0313: Expected O, but got I4
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected I4, but got Unknown
		//IL_032a: Expected O, but got I4
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance == null)
		{
			return;
		}
		PlayerInventory inventory = instance.inventory;
		if (instance.inventory == null || inventory.playerHealth == null)
		{
			return;
		}
		if (!dashPs.isPlaying)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerMovement playerMovement = instance2.playerMovement;
			if (playerMovement.isDashing)
			{
				dashCloudPs.Play();
				dashPs.Play();
				goto IL_015d;
			}
		}
		if (dashPs.isPlaying)
		{
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerMovement playerMovement2 = instance3.playerMovement;
			if (!playerMovement2.isDashing)
			{
				dashPs.Stop();
			}
		}
		goto IL_015d;
		IL_015d:
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFVisualsSettings cfVisualsSettings = config.cfVisualsSettings;
		int combinedHp;
		object obj;
		float num13;
		if (cfVisualsSettings.low_hp_effects != 0)
		{
			MyPlayer instance4 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance4.inventory;
			if (inventory2.playerHealth.IsDead())
			{
				dangerTarget = 0f;
				float num = MyTime.deltaTime * 1.5f;
				if (!(0f > num))
				{
					if (num > 1f)
					{
						num = 1f;
					}
				}
				else
				{
					num = 0f;
				}
				float num2 = 0f - dangerValue;
				float num3 = num2 * num;
				float num4 = num3 + dangerValue;
				dangerValue = num4;
				return;
			}
			MyPlayer instance5 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance5.inventory;
			combinedHp = inventory3.playerHealth.GetCombinedHp();
			MyPlayer instance6 = MyPlayer.Instance;
			PlayerInventory inventory4 = instance6.inventory;
			int combinedMaxHp = inventory4.playerHealth.GetCombinedMaxHp();
			int num5 = combinedHp / combinedMaxHp;
			if (!((float)num5 < 0.25f))
			{
				timeLowHp = 0f;
				obj = 0;
			}
			else
			{
				float num6 = (timeLowHp += MyTime.deltaTime);
				if (lastHp > 0f)
				{
					float num7 = lastHp - (float)combinedHp;
					if (num7 > 0f)
					{
						int num8 = (int)(num7 / combinedMaxHp);
						float num9 = (float)num8 * 4f;
						float num10 = num9 + dangerTarget;
						dangerTarget = num10;
					}
				}
				if (num6 > 15f)
				{
					float num11 = MyTime.deltaTime * 0.02f;
					float num12 = dangerTarget - num11;
					dangerTarget = num12;
				}
				num13 = dangerTarget;
				bool flag = 0f > dangerTarget;
				obj = 0;
				if (!flag)
				{
					bool flag2 = !(dangerTarget > 1f);
					obj = 0;
					if (!flag2)
					{
						obj = 0;
						num13 = 1f;
					}
					goto IL_049b;
				}
			}
			num13 = 0f;
			goto IL_049b;
		}
		dangerValue = 0f;
		return;
		IL_049b:
		dangerTarget = num13;
		lastHp = combinedHp;
		float num14 = MyTime.deltaTime * 1.5f;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num14))
		{
			if (num14 > 1f)
			{
				num14 = 1f;
			}
		}
		else
		{
			num14 = 0f;
		}
		float num15 = dangerTarget - dangerValue;
		float num16 = num15 * num14;
		float num17 = num16 + dangerValue;
		dangerValue = num17;
	}

	private void DashFx()
	{
		if (!dashPs.isPlaying)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerMovement playerMovement = instance.playerMovement;
			if (playerMovement.isDashing)
			{
				dashCloudPs.Play();
				dashPs.Play();
				return;
			}
		}
		if (dashPs.isPlaying)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerMovement playerMovement2 = instance2.playerMovement;
			if (!playerMovement2.isDashing)
			{
				dashPs.Stop();
			}
		}
	}

	private float RemapHpRatio(float hpRatio, float min, float max)
	{
		//IL_0092: Expected F4, but got I4
		float result;
		if (hpRatio < max)
		{
			bool flag = !(min < hpRatio);
			result = 1f;
			if (!flag)
			{
				float num = hpRatio - min;
				float num2 = max - min;
				float num3 = num / num2;
				return 1f - num3;
			}
		}
		else
		{
			result = 0f;
		}
		return result;
	}

	public float GetDangerRatio()
	{
		return dangerValue;
	}

	public float GetDangerRatioMusic()
	{
		//IL_002b: Invalid comparison between I4 and F4
		//IL_006e: Expected F4, but got I4
		float num = dangerValue - 0.6f;
		float num2 = num / 0.39999998f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				return 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		return num2;
	}

	private void OnMirrorReady(bool isReady)
	{
		mirrorFx.SetActive(isReady);
	}

	private void OnFlexReady(bool isReady)
	{
		flexFx.SetActive(isReady);
	}
}
