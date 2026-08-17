using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Interactables;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UIElements.Experimental;

public class InteractableCoffin : BaseInteractable
{
	public const int numCoffins = 4;

	public GameObject rayFx;

	public Animator coffinAnimator;

	public LocalizedString interactString;

	public Transform bossSpawnPos;

	public GameObject zone;

	public GameObject minimapIcon;

	public GameObject keyPickup;

	public AudioSource ambience;

	private static int currentGhostIndex;

	private HashSet<Enemy> minibossEnemies;

	private static bool hasActiveFight;

	private bool interacted;

	public AudioSource audio;

	public ParticleSystem[] stormParticles;

	public MeshRenderer fogOfWarRenderer;

	public GameObject zoneCollider;

	public GameObject zoneRenderer;

	private Material fogOfWarMaterial;

	private float fogIntensityDefault;

	private float fogIntensityNew;

	private Color fogColorDefault;

	private Color fogColorNew;

	private float audioVolume;

	private float fadeOverTime;

	private float fadeZoneTime;

	private float fadeTime;

	private bool isActive;

	private bool startedAnimating;

	private void Awake()
	{
		//IL_00b5: Expected I, but got O
		//IL_00c6: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_010d: Expected I, but got O
		//IL_011e: Expected O, but got I4
		//IL_0127: Expected O, but got I4
		//IL_01b7: Expected I, but got O
		//IL_01c8: Expected O, but got I4
		//IL_01d1: Expected O, but got I4
		//IL_020f: Expected I, but got O
		//IL_0220: Expected O, but got I4
		//IL_0229: Expected O, but got I4
		hasActiveFight = false;
		currentGhostIndex = 0;
		if ((object)audio != null)
		{
			float volume = audio.volume;
			audioVolume = volume;
			if ((object)fogOfWarRenderer != null)
			{
				Material material = ((Renderer)fogOfWarRenderer).GetMaterial();
				fogOfWarMaterial = material;
				Action<Enemy> b = OnEnemyDied;
				Delegate obj = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b);
				nint num;
				Delegate obj2;
				object obj3;
				object obj4;
				if ((object)obj == null)
				{
					Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					Action<Enemy> action = default(Action<Enemy>);
					bool flag = action == null;
					num = (nint)typeof(Action<Enemy>);
					obj2 = obj;
					obj3 = 0;
					obj4 = 0;
					if (flag)
					{
						goto IL_029f;
					}
					Enemy.A_EnemyReleasedFromPool = action;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj5 = default(object);
					bool flag2 = obj5 == null;
					num = (nint)typeof(Action<Enemy>);
					obj2 = obj;
					obj3 = 0;
					obj4 = 0;
					if (flag2)
					{
						goto IL_02aa;
					}
				}
				Action<BaseInteractable, bool> b2 = OnInteracted;
				Delegate obj6 = Delegate.Combine(DetectInteractables.A_Interacted, b2);
				if ((object)obj6 == null)
				{
					DetectInteractables.A_Interacted = (Action<BaseInteractable, bool>)obj6;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<BaseInteractable, bool> action2 = default(Action<BaseInteractable, bool>);
				bool flag3 = action2 == null;
				num = (nint)typeof(Action<BaseInteractable, bool>);
				obj2 = obj6;
				obj3 = 0;
				obj4 = 0;
				if (!flag3)
				{
					DetectInteractables.A_Interacted = action2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj7 = default(object);
					bool flag4 = obj7 == null;
					num = (nint)typeof(Action<BaseInteractable, bool>);
					obj2 = obj6;
					obj3 = 0;
					obj4 = 0;
					if (!flag4)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				goto IL_02aa;
			}
		}
		throw new NullReferenceException();
		IL_02aa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_029f;
		IL_029f:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void Start()
	{
		base.Start();
		StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
		fogColorDefault = stageData.fogColor;
		StageData stageData2 = MapController._003CcurrentStage_003Ek__BackingField;
		fogIntensityDefault = stageData2.fogIntensity;
	}

	private new void OnDestroy()
	{
		//IL_01ce: Expected I, but got O
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		Action<Enemy> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action = default(Action<Enemy>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<Enemy>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_020d;
			}
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01f2;
			}
		}
		Action<BaseInteractable, bool> value2 = OnInteracted;
		Delegate obj6 = Delegate.Remove(DetectInteractables.A_Interacted, value2);
		if ((object)obj6 == null)
		{
			DetectInteractables.A_Interacted = (Action<BaseInteractable, bool>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<BaseInteractable, bool> action2 = default(Action<BaseInteractable, bool>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<BaseInteractable, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_01fd;
		}
		DetectInteractables.A_Interacted = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<BaseInteractable, bool>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_020d;
		IL_01f2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_020d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_01fd;
		IL_01fd:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01f2;
	}

	public override bool Interact()
	{
		//IL_0399: Expected I4, but got O
		//IL_0125: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_0162: Expected O, but got I4
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		if (!interacted)
		{
			interacted = true;
			hasActiveFight = true;
			if ((object)coffinAnimator != null)
			{
				coffinAnimator.Play("CoffinOpen");
				if ((object)zoneCollider != null)
				{
					zoneCollider.SetActive(value: true);
					if ((object)rayFx != null)
					{
						rayFx.SetActive(value: false);
						Invoke("FadeIn", 0.3f);
						if ((object)minimapIcon != null)
						{
							minimapIcon.SetActive(value: false);
							GameManager instance = GameManager.Instance;
							if ((object)GameManager.Instance != null)
							{
								object obj = instance.bossCurses + 1;
								if ((nint)obj <= 0)
								{
									goto IL_0367;
								}
								object obj2 = 0;
								Vector3 pos = default(Vector3);
								float extraSizeMultiplier = default(float);
								while (true)
								{
									bool flag = currentGhostIndex == 0;
									if (flag)
									{
										goto IL_0230;
									}
									object obj3 = currentGhostIndex - 1;
									EEnemy eEnemy;
									if (!flag)
									{
										object obj4 = obj3 - 1;
										if (!flag)
										{
											if ((nint)obj4 != 1)
											{
												goto IL_0230;
											}
											if ((object)DataManager.Instance == null)
											{
												break;
											}
											eEnemy = EEnemy.GhostGrave4;
										}
										else
										{
											if ((object)DataManager.Instance == null)
											{
												break;
											}
											eEnemy = EEnemy.GhostGrave3;
										}
									}
									else
									{
										if ((object)DataManager.Instance == null)
										{
											break;
										}
										eEnemy = EEnemy.GhostGrave2;
									}
									goto IL_03c0;
									IL_0230:
									if ((object)DataManager.Instance == null)
									{
										break;
									}
									eEnemy = EEnemy.GhostGrave1;
									goto IL_03c0;
									IL_03c0:
									EnemyData enemyData = DataManager.Instance.GetEnemyData(eEnemy);
									if ((object)enemyData == null || (object)bossSpawnPos == null)
									{
										break;
									}
									Vector3 position = bossSpawnPos.position;
									if ((object)EnemyManager.Instance == null)
									{
										break;
									}
									Enemy enemy = EnemyManager.Instance.SpawnBoss(enemyData.enemyName, 0, EEnemyFlag.Boss, pos, extraSizeMultiplier);
									if (enemy != null)
									{
										if (minibossEnemies == null)
										{
											break;
										}
										bool flag2 = minibossEnemies.Add(enemy);
									}
									else
									{
										Debug.LogError("Failed to spawn miniboss from coffin");
									}
									obj2++;
									if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
									{
										goto IL_0367;
									}
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
		IL_0367:
		int num = currentGhostIndex + 1;
		currentGhostIndex = num;
		return true;
	}

	private unsafe void OnEnemyDied(Enemy enemy)
	{
		//IL_00ca: Expected O, but got Ref
		if (((HashSet<object>)(object)minibossEnemies).Contains((object)enemy))
		{
			bool flag = ((HashSet<object>)(object)minibossEnemies).Remove((object)enemy);
			HashSet<Enemy> hashSet = minibossEnemies;
			if (hashSet._count <= 0)
			{
				keyPickup.SetActive(value: true);
				UiManager instance = UiManager.Instance;
				Transform t = keyPickup.transform;
				object obj = default(object);
				float timeout = default(float);
				float scaleMultiplier = default(float);
				instance.objectiveArrow.SetTarget(t, (Vector3)(&obj), 0f, timeout, scaleMultiplier);
			}
		}
	}

	private void OnKeyPickedUp()
	{
	}

	private void OnZoneCharged()
	{
	}

	private void OnInteracted(BaseInteractable interactable, bool succeess)
	{
		//IL_00c0: Expected F4, but got I4
		//IL_00c9: Expected F4, but got I4
		//IL_0134: Invalid comparison between F4 and I4
		GameObject gameObject = interactable.gameObject;
		if (gameObject == keyPickup && succeess)
		{
			zone.SetActive(value: false);
			GameObject gameObject2 = fogOfWarRenderer.gameObject;
			gameObject2.SetActive(value: false);
			hasActiveFight = false;
			fadeTime = 0f;
			isActive = false;
			ParticleSystem[] array = stormParticles;
			float num = 0f;
			float num2 = 0f;
			ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
			while (num < (float)array.Length)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
				emissionModule.enabled = false;
				num2++;
				num = num2;
			}
			UiManager instance = UiManager.Instance;
			instance.objectiveArrow.ClearTarget();
		}
	}

	public override string GetInteractString()
	{
		if (interactString != null)
		{
			return interactString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public override bool CanInteract()
	{
		if (interacted)
		{
			return false;
		}
		return !hasActiveFight;
	}

	public EnemyData GetEnemyData()
	{
		//IL_0014: Expected O, but got I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		bool flag = currentGhostIndex == 0;
		if (flag)
		{
			goto IL_0100;
		}
		object obj = currentGhostIndex - 1;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				if ((nint)obj2 != 1)
				{
					goto IL_0100;
				}
				if ((object)DataManager.Instance != null)
				{
					return DataManager.Instance.GetEnemyData(EEnemy.GhostGrave4);
				}
			}
			else if ((object)DataManager.Instance != null)
			{
				return DataManager.Instance.GetEnemyData(EEnemy.GhostGrave3);
			}
		}
		else if ((object)DataManager.Instance != null)
		{
			return DataManager.Instance.GetEnemyData(EEnemy.GhostGrave2);
		}
		goto IL_0136;
		IL_0136:
		return (EnemyData)(object)new NullReferenceException();
		IL_0100:
		if ((object)DataManager.Instance != null)
		{
			return DataManager.Instance.GetEnemyData(EEnemy.GhostGrave1);
		}
		goto IL_0136;
	}

	public unsafe void FadeIn()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_009f: Expected O, but got F4
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		//IL_024e: Expected I, but got O
		//IL_0197: Expected O, but got Ref
		//IL_01df: Expected O, but got I4
		//IL_01e8: Expected O, but got I4
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		isActive = true;
		fogOfWarRenderer.enabled = true;
		StageData stageData = MapController._003CcurrentStage_003Ek__BackingField;
		fogIntensityDefault = stageData.fogIntensity;
		StageData stageData2 = MapController._003CcurrentStage_003Ek__BackingField;
		fogColorDefault = stageData2.fogColor;
		object obj = 0 - stageData2.fogColor;
		float num = (float)obj * 0.65f;
		float num2 = num + (float)stageData2.fogColor;
		object obj3 = default(object);
		object obj2 = 0 - obj3;
		fogColorNew = (Color)num2;
		object obj4 = 0 - obj3;
		float num3 = (float)obj2 * 0.65f;
		float num4 = num3 + (float)obj3;
		float num5 = (float)obj4 * 0.65f;
		float num6 = num5 + (float)obj3;
		float num7 = 1f - (float)obj3;
		float num8 = num7 * 0.65f;
		float num9 = num8 + (float)obj3;
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		Transform transform2 = base.transform;
		Vector3 position2 = transform2.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		nint num10 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v490 @ rax_v24 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rcx_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		float num12 = 0f * 0.5f;
		float num13 = num12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rax_v22+8]");
		float num14 = num13 + 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ rcx_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
		float num15 = 0f * 0.5f;
		float num16 = num15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v475 @ rax_v22+4]");
		float num17 = num16 + 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		MyPlayer instance = MyPlayer.Instance;
		float num18 = default(float);
		instance.playerMovement.RocketJump((Vector3)(&num18));
		fadeTime = 0f;
		audio.volume = 0f;
		audio.Play();
		ParticleSystem[] array = stormParticles;
		object obj5 = 0;
		object obj6 = 0;
		ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
		while ((nint)obj6 < array.Length)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			emissionModule.enabled = true;
			obj5++;
			obj6 = obj5;
		}
	}

	public void FadeOut()
	{
		//IL_002e: Expected F4, but got I4
		//IL_0037: Expected F4, but got I4
		//IL_0081: Invalid comparison between F4 and I4
		ParticleSystem[] array = stormParticles;
		fadeTime = 0f;
		isActive = false;
		float num = 0f;
		ParticleSystem.EmissionModule emissionModule = default(ParticleSystem.EmissionModule);
		for (float num2 = 0f; num2 < (float)array.Length; num2 = num)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181565C70");
			emissionModule.enabled = false;
			num++;
		}
	}

	private unsafe void Update()
	{
		//IL_034c: Invalid comparison between I4 and F4
		//IL_0066: Expected F4, but got I4
		//IL_0084: Expected O, but got Ref
		//IL_015e: Invalid comparison between I4 and F4
		//IL_01b3: Expected F4, but got I4
		//IL_00d6: Invalid comparison between I4 and F4
		//IL_0482: Invalid comparison between I4 and F4
		//IL_012b: Expected F4, but got I4
		//IL_04b3: Expected O, but got Ref
		//IL_0424: Invalid comparison between I4 and F4
		//IL_022b: Invalid comparison between I4 and F4
		//IL_0276: Expected F4, but got I4
		//IL_029c: Expected O, but got Ref
		if (!startedAnimating)
		{
			return;
		}
		if (fadeOverTime > fadeTime)
		{
			float num = fadeTime + MyTime.deltaTime;
			if (!(0f > num))
			{
				if (num > fadeOverTime)
				{
					num = fadeOverTime;
				}
			}
			else
			{
				num = 0f;
			}
			fadeTime = num;
			float num2 = num / fadeOverTime;
			if (!isActive)
			{
			}
			float num3 = default(float);
			fogOfWarMaterial.SetColor("_Color", (Color)(&num3));
			float num4 = (isActive ? num2 : (1f - num2));
			float volume = num4 * audioVolume;
			audio.volume = volume;
			if (!isActive)
			{
				float num5 = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
				float num6 = fogIntensityDefault - fogIntensityNew;
				float num7 = num6 * num5;
				float fogDensity = num7 + fogIntensityNew;
				RenderSettings.fogDensity = fogDensity;
				if (!(0f > num2) && !(num2 > 1f))
				{
				}
			}
			else
			{
				float num8 = ((0f > num2) ? 0f : ((num2 > 1f) ? 1f : num2));
				float num9 = fogIntensityNew - fogIntensityDefault;
				float num10 = num9 * num8;
				float fogDensity2 = num10 + fogIntensityDefault;
				RenderSettings.fogDensity = fogDensity2;
				if (!(0f > num2) && !(num2 > 1f))
				{
				}
			}
			RenderSettings.fogColor = (Color)(&num3);
			if (!(fadeTime < fadeOverTime) && !isActive)
			{
				audio.Stop();
			}
			float num11 = fadeTime / fadeZoneTime;
			if (!(0f > num11))
			{
				if (num11 > 1f)
				{
					num11 = 1f;
				}
			}
			else
			{
				num11 = 0f;
			}
			Transform transform = zoneRenderer.transform;
			float num12 = Easing.OutCirc(num11);
			transform.localScale = (Vector3)(&num3);
		}
		if (!(fadeTime < fadeOverTime) && !isActive && interacted)
		{
			base.enabled = false;
		}
	}

	public InteractableCoffin()
	{
		HashSet<Enemy> hashSet = (HashSet<Enemy>)(object)new HashSet<object>();
		minibossEnemies = hashSet;
		fogIntensityNew = 0.015f;
		fadeOverTime = 3f;
		fadeZoneTime = 3f;
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
