using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundFoscari_Plain : BackgroundManager
{
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public PizzaCircle triggered;

		public Action _003C_003E9__0;

		internal void _003CCheckBossPizzas_003Eb__0()
		{
			PizzaCircle pizzaCircle = triggered;
			if ((object)triggered == null || ((UnityEngine.Object)pizzaCircle).m_CachedPtr == (IntPtr)0)
			{
				return;
			}
			GameObject gameObject = triggered.gameObject;
			if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
			{
				GameObject obj;
				if ((object)triggered != null)
				{
					GameObject gameObject2 = triggered.gameObject;
					obj = gameObject2;
				}
				else
				{
					obj = null;
				}
				ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
				pool.Release(obj);
			}
		}
	}

	private List<PizzaCircle> _bossPizzas;

	private Timer _checkBossPizzasTimer;

	protected void InitMagicWater()
	{
		InitVFX();
	}

	public override void Create()
	{
		base.Create();
		InitVFX();
		CreateBossPizzas();
		if (_checkBossPizzasTimer != null)
		{
			_checkBossPizzasTimer.Cancel();
		}
		Action onComplete = CheckBossPizzas;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer checkBossPizzasTimer = Timers.Register(0.3f, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_checkBossPizzasTimer = checkBossPizzasTimer;
	}

	public override void Cleanup()
	{
		//IL_0013: Expected O, but got I4
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		GameManager core = GM.Core;
		core._003CHardBounds_003Ek__BackingField = (Rect?)(object)0;
		_ = 0;
	}

	private void InitVFX()
	{
		//IL_0222: Expected I4, but got I8
		GameObject original = Resources.Load<GameObject>("MagicWater");
		Camera main = Camera.main;
		Transform parent = main.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(original, parent, worldPositionStays: false);
		int2 renderTextureSize = CameraExtensions.GetRenderTextureSize(_mainCamera);
		Transform transform = gameObject.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		Transform transform2 = gameObject.transform;
		Transform child = transform2.GetChild(0);
		GameObject gameObject2 = child.gameObject;
		int layer = (gameObject2.layer = LayerMask.NameToLayer("Default"));
		gameObject.layer = layer;
		Transform transform3 = gameObject.transform;
		Transform child2 = transform3.GetChild(0);
		bool flag2 = ((UnityEngine.Object)child2).m_CachedPtr == (IntPtr)0;
		Vector3 value2 = default(Vector3);
		Transform.set_localPosition_Injected(((UnityEngine.Object)child2).m_CachedPtr, ref value2);
		Transform transform4 = gameObject.transform;
		Transform child3 = transform4.GetChild(0);
		MeshRenderer component = child3.GetComponent<MeshRenderer>();
		bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Renderer.set_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr, -9000);
		Transform transform5 = gameObject.transform;
		Transform child4 = transform5.GetChild(0);
		MeshRenderer component2 = child4.GetComponent<MeshRenderer>();
	}

	private unsafe void CreateBossPizzas()
	{
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Expected O, but got Unknown
		//IL_03e6: Expected O, but got I4
		//IL_041d: Expected O, but got Ref
		//IL_041d: Expected O, but got Ref
		//IL_018d->IL0515: Incompatible stack heights: 1 vs 0
		//IL_01c4->IL0515: Incompatible stack heights: 1 vs 0
		//IL_0598->IL0515: Incompatible stack heights: 2 vs 0
		//IL_0207->IL0515: Incompatible stack heights: 4 vs 0
		//IL_022d->IL0515: Incompatible stack heights: 4 vs 0
		//IL_0260->IL0515: Incompatible stack heights: 4 vs 0
		//IL_050f->IL060a: Incompatible stack heights: 4 vs 0
		//IL_02b1->IL0515: Incompatible stack heights: 4 vs 0
		//IL_0514->IL0514: Incompatible stack heights: 4 vs 0
		//IL_0385->IL0515: Incompatible stack heights: 4 vs 0
		//IL_0307->IL0515: Incompatible stack heights: 4 vs 0
		//IL_0605->IL0515: Incompatible stack heights: 4 vs 0
		//IL_0402->IL0515: Incompatible stack heights: 4 vs 0
		//IL_0439->IL0515: Incompatible stack heights: 4 vs 0
		//IL_0463->IL0515: Incompatible stack heights: 4 vs 0
		//IL_04bb->IL0515: Incompatible stack heights: 4 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null && (object)stage._tilingTileset != null)
			{
				List<SuperObject> scriptsFromName = stage._tilingTileset.GetScriptsFromName("BossSpawn");
				if (scriptsFromName == null || scriptsFromName._size <= 0)
				{
					return;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._playerOptions != null)
				{
					PlayerOptionsData config = core2._playerOptions.Config;
					if (config != null)
					{
						if (scriptsFromName._size <= 0)
						{
							return;
						}
						CustomProperty property = null;
						CustomProperty customProperty = null;
						object obj = default(object);
						object obj2 = default(object);
						Quaternion identityQuaternion = default(Quaternion);
						while (true)
						{
							bool flag = (nint)customProperty >= scriptsFromName._size;
							SuperObject[] items = scriptsFromName._items;
							if (scriptsFromName._items == null)
							{
								break;
							}
							SuperCustomProperties superCustomProperties = (SuperCustomProperties)(object)items[(object)customProperty];
							if ((object)items[(object)customProperty] == null)
							{
								break;
							}
							bool flag2 = ((UnityEngine.Object)superCustomProperties).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)superCustomProperties).m_CachedPtr);
							Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							if ((object)transform == null)
							{
								break;
							}
							bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
							bool flag4 = (nint)customProperty >= scriptsFromName._size;
							SuperObject[] items2 = scriptsFromName._items;
							if (scriptsFromName._items == null || (object)items2[(object)customProperty] == null)
							{
								break;
							}
							SuperCustomProperties component = items2[(object)customProperty].GetComponent<SuperCustomProperties>();
							if ((object)component == null)
							{
								break;
							}
							if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "requiresItem", out var property2))
							{
								if (property2 == null)
								{
									break;
								}
								if (Enum.Parse<ItemType>(property2.m_Value) != ItemType.VOID)
								{
									if (config._003CCollectedItems_003Ek__BackingField == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
									if (obj == null)
									{
										goto IL_04e5;
									}
								}
							}
							if (CustomPropertyListExtensions.TryGetProperty(component.m_Properties, "enemyType", out property))
							{
								if (property == null)
								{
									break;
								}
								if (Enum.Parse<EnemyType>(property.m_Value) != EnemyType.BAT1)
								{
									EnemyType enemyType = Enum.Parse<EnemyType>(property.m_Value);
									if (enemyType == EnemyType.BAT1)
									{
										break;
									}
									ObjectPool pool = ((MasterObjectPooler)enemyType).GetPool("PizzaCircles");
									if ((object)pool == null)
									{
										break;
									}
									GameObject gameObject = pool.GetObject((Vector3)(&obj2), (Quaternion)(&identityQuaternion));
									if ((object)gameObject == null)
									{
										break;
									}
									PizzaCircle component2 = gameObject.GetComponent<PizzaCircle>();
									if ((object)component2 == null)
									{
										break;
									}
									component2.Init(24f);
									component2.SetAlpha(1f);
									component2.SetSprite("items", "PizzaBossFoscari");
									if (_bossPizzas == null)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4300");
									obj2 = ret;
									identityQuaternion = Quaternion.identityQuaternion;
								}
							}
							goto IL_04e5;
							IL_04e5:
							customProperty = (CustomProperty)(customProperty + 1);
							if ((nint)customProperty >= scriptsFromName._size)
							{
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CheckBossPizzas()
	{
		//IL_0093: Expected I, but got O
		//IL_00c0: Expected I4, but got O
		//IL_00e6: Expected O, but got I4
		//IL_0689: Expected O, but got I4
		//IL_028c: Expected O, but got I4
		//IL_01a6: Expected O, but got I
		//IL_022e: Expected I, but got O
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01f1: Expected I, but got O
		//IL_01fa: Expected O, but got I4
		//IL_06eb: Expected I, but got O
		//IL_025b: Expected I, but got O
		//IL_0210: Expected I, but got O
		//IL_03c6: Expected I, but got O
		//IL_071a: Expected I, but got O
		//IL_0425: Expected I, but got O
		//IL_046e: Expected O, but got I4
		//IL_04f9: Expected I, but got O
		//IL_0533: Expected I, but got O
		//IL_05ec: Expected I4, but got F4
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass7_0();
		if (CS_0024_003C_003E8__locals23 != null)
		{
			CS_0024_003C_003E8__locals23.triggered = null;
			GameManager gameManager = GM.Core;
			if ((object)GM.Core != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = gameManager._mainCharacters;
				if (gameManager._mainCharacters != null)
				{
					bool flag = mainCharacters._size <= 0;
					int size = mainCharacters._size;
					nint num = unchecked((nint)null);
					if (flag)
					{
						return;
					}
					Vector2 vector2 = default(Vector2);
					object obj3 = default(object);
					ArcadeSprite arcadeSprite = default(ArcadeSprite);
					object obj5 = default(object);
					PizzaCircle triggered = default(PizzaCircle);
					bool flag11 = default(bool);
					UnityEngine.Object obj6 = default(UnityEngine.Object);
					float num4 = default(float);
					nint num3 = default(nint);
					MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
					int repeat = default(int);
					TimerType type = default(TimerType);
					while (true)
					{
						List<PizzaCircle> bossPizzas = _bossPizzas;
						bool flag2 = _bossPizzas == null;
						UnityEngine.Object obj = null;
						if (flag2)
						{
							break;
						}
						bool flag3 = bossPizzas._size <= 0;
						bool flag4 = (byte)(int)gameManager != 0;
						obj = null;
						Vector2 vector = vector2;
						object obj2 = obj3;
						nint num2 = num3;
						object obj4 = 0;
						if (!flag3)
						{
							while (true)
							{
								bool flag5 = _bossPizzas == null;
								num3 = num2;
								if (flag5)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								bool flag6 = (object)arcadeSprite == null;
								num3 = num;
								if (flag6)
								{
									break;
								}
								float2 position = arcadeSprite.position;
								bool flag7 = obj5 == null;
								num3 = num;
								if (flag7)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ rax_v12+40]");
								bool flag8 = (nint)0 == 0;
								num3 = num;
								if (flag8)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ rax_v12+40]");
								flag4 = ((Circle)0).Contains(vector2);
								if (!flag4)
								{
									obj = (UnityEngine.Object)(obj + 1);
									bool flag9 = (nint)obj < bossPizzas._size;
									vector = vector2;
									obj2 = obj3;
									num2 = (nint)vector2;
									obj4 = 0;
									if (flag9)
									{
										continue;
									}
									num3 = (nint)vector2;
								}
								else
								{
									bool flag10 = _bossPizzas == null;
									num3 = (nint)vector2;
									if (flag10)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									CS_0024_003C_003E8__locals23.triggered = triggered;
									num3 = (nint)obj;
									flag4 = flag11;
								}
								size = mainCharacters._size;
								goto IL_062f;
							}
							break;
						}
						goto IL_062f;
						IL_062f:
						obj = CS_0024_003C_003E8__locals23.triggered;
						bool flag12 = (object)CS_0024_003C_003E8__locals23.triggered == null;
						gameManager = (GameManager)flag4;
						if (!flag12)
						{
							gameManager = (GameManager)flag4;
							if (obj.m_CachedPtr != (IntPtr)0)
							{
								GameManager core = GM.Core;
								if ((object)GM.Core == null)
								{
									break;
								}
								PizzaCircle triggered2 = CS_0024_003C_003E8__locals23.triggered;
								if ((object)CS_0024_003C_003E8__locals23.triggered == null)
								{
									break;
								}
								bool flag13 = ((UnityEngine.Object)triggered2).m_CachedPtr == (IntPtr)0;
								object triggered3 = CS_0024_003C_003E8__locals23.triggered;
								num3 = unchecked((nint)null);
								if (!flag13)
								{
									IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)triggered2).m_CachedPtr);
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									bool flag14 = (object)transform == null;
									obj = CS_0024_003C_003E8__locals23.triggered;
									num3 = 0;
									if (flag14)
									{
										break;
									}
									Vector3 position2 = transform.position;
									bool flag15 = (object)core._stage == null;
									obj = CS_0024_003C_003E8__locals23.triggered;
									num3 = (nint)transform;
									if (flag15)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183146960");
									if ((bool)obj6)
									{
										bool flag16 = (object)obj6 == null;
										obj = obj6;
										num3 = unchecked((nint)null);
										if (flag16)
										{
											break;
										}
										_ = 257;
										_ = 1;
									}
									bool flag17 = (object)CS_0024_003C_003E8__locals23.triggered == null;
									obj = obj6;
									num3 = unchecked((nint)null);
									if (flag17)
									{
										break;
									}
									CS_0024_003C_003E8__locals23.triggered.ShowFinalWarning();
									SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
									soundConfig.Volume = (float?)(object)1;
									soundConfig.Rate = 1f;
									float value = UnityEngine.Random.value;
									float detune = value * 500f;
									soundConfig.Rate = 1f;
									soundConfig.Detune = detune;
									PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Pizza, soundConfig, 150f, 2, num4);
									bool flag18 = (object)CS_0024_003C_003E8__locals23.triggered == null;
									obj = (UnityEngine.Object)(object)soundConfig;
									num3 = (nint)soundConfig;
									if (flag18)
									{
										break;
									}
									CS_0024_003C_003E8__locals23.triggered.CleanUp();
									bool flag19 = _bossPizzas == null;
									obj = (UnityEngine.Object)(object)soundConfig;
									num3 = unchecked((nint)null);
									if (flag19)
									{
										break;
									}
									bool flag20 = ((List<object>)(object)_bossPizzas).Remove((object)CS_0024_003C_003E8__locals23.triggered);
									Action onComplete = CS_0024_003C_003E8__locals23._003C_003E9__0;
									if (CS_0024_003C_003E8__locals23._003C_003E9__0 == null)
									{
										onComplete = (CS_0024_003C_003E8__locals23._003C_003E9__0 = delegate
										{
											PizzaCircle triggered4 = CS_0024_003C_003E8__locals23.triggered;
											if ((object)CS_0024_003C_003E8__locals23.triggered != null && ((UnityEngine.Object)triggered4).m_CachedPtr != (IntPtr)0)
											{
												GameObject gameObject = CS_0024_003C_003E8__locals23.triggered.gameObject;
												if ((object)gameObject != null && ((UnityEngine.Object)gameObject).m_CachedPtr != (IntPtr)0)
												{
													GameObject obj7;
													if ((object)CS_0024_003C_003E8__locals23.triggered != null)
													{
														GameObject gameObject2 = CS_0024_003C_003E8__locals23.triggered.gameObject;
														obj7 = gameObject2;
													}
													else
													{
														obj7 = null;
													}
													ObjectPool pool = MasterObjectPooler._003CInstance_003Ek__BackingField.GetPool("PizzaCircles");
													pool.Release(obj7);
												}
											}
										});
									}
									Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, (byte)(int)num4 != 0, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
								}
								else
								{
									UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(triggered3);
								}
								return;
							}
						}
						num++;
						if (num >= size)
						{
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public BackgroundFoscari_Plain()
	{
		List<PizzaCircle> bossPizzas = new List<PizzaCircle>();
		_bossPizzas = bossPizzas;
		base._002Ector();
	}
}
