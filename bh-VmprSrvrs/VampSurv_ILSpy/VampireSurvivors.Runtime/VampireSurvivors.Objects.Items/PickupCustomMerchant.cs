using System;
using System.Collections.Generic;
using Coherence;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Cursors;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Items;

public class PickupCustomMerchant : NetworkPickup
{
	private ParticleEmitterManager _particleEmitterManager;

	private ParticleSystem _pfxEmitter;

	protected CustomMerchantData _customMerchantData;

	private float _shopCooldownTimer;

	private bool _facePlayer = true;

	private float _shopCooldown = 3000f;

	private bool _003CSkipValidWeaponCheck_003Ek__BackingField;

	public readonly List<CustomActionInventoryItem> CustomActionInventoryItems;

	public CustomMerchantData CustomMerchantData => _customMerchantData;

	public bool SkipValidWeaponCheck
	{
		get
		{
			return _003CSkipValidWeaponCheck_003Ek__BackingField;
		}
		private set
		{
			_003CSkipValidWeaponCheck_003Ek__BackingField = value;
		}
	}

	protected override bool UsesOrderedCommand => true;

	protected override void Awake()
	{
		//IL_0016: Expected O, but got I4
		base.Awake();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		_ShowAboveAll = true;
	}

	private void Update()
	{
		//IL_000b: Invalid comparison between F4 and I4
		if (_shopCooldownTimer > 0f)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			float shopCooldownTimer = _shopCooldownTimer - num;
			_shopCooldownTimer = shopCooldownTimer;
		}
	}

	public override void SetData(ItemType itemType)
	{
		//IL_003a: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		base.SetData(itemType);
		base.GoToPlayer = true;
		((Pickup)this)._003CIsStationary_003Ek__BackingField = true;
		Debug.Log("Setting Data Of Custom Merchant");
		SetFrame("Pantalone");
		BaseBody baseBody = body.setCircle(16f, (float?)(object)0, (float?)(object)0);
		((Pickup)this)._003CResRosary_003Ek__BackingField = 1f;
		_ShowAboveAll = true;
	}

	public void SetInventoryData(CustomMerchantData customMerchantData)
	{
		//IL_00a1: Expected O, but got I
		//IL_01a0: Expected O, but got I4
		//IL_00d5: Expected O, but got I4
		//IL_0203: Expected F4, but got O
		//IL_00bb->IL0302: Incompatible stack heights: 1 vs 0
		//IL_00de->IL0337: Incompatible stack heights: 1 vs 0
		//IL_0208->IL0417: Incompatible stack heights: 1 vs 0
		//IL_0417->IL0370: Incompatible stack heights: 3 vs 0
		_customMerchantData = customMerchantData;
		SetCharacterFrame();
		Vector2? vector = default(Vector2?);
		if (_customMerchantData != null)
		{
			CustomMerchantData customMerchantData2 = _customMerchantData;
			vector = customMerchantData2._003CBodyOffset_003Ek__BackingField;
			if ((object)customMerchantData2._003CBodyOffset_003Ek__BackingField != null)
			{
				CustomMerchantData customMerchantData3 = _customMerchantData;
				if (_customMerchantData != null)
				{
					bool flag = (object)customMerchantData3._003CBodyOffset_003Ek__BackingField == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v69 (VampireSurvivors.App.Data.CustomMerchantData)+70]");
					vector = (Vector2?)(object)0;
					if (body != null)
					{
						float x = default(float);
						BaseBody baseBody = body.setOffset(x, (float?)(object)1);
						goto IL_0337;
					}
				}
				goto IL_0302;
			}
		}
		goto IL_0337;
		IL_0302:
		throw new NullReferenceException();
		IL_0337:
		GenerateParticleSystem();
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null && ((UnityEngine.Object)pfxEmitter).m_CachedPtr != (IntPtr)0)
		{
			RenderingExtensions.Start(_pfxEmitter);
			if ((object)_pfxEmitter != null)
			{
				Transform transform = _pfxEmitter.transform;
				Transform transform2 = base.transform;
				if ((object)transform2 != null)
				{
					bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
					bool flag3 = (object)transform == null;
					bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					goto IL_0370;
				}
			}
			goto IL_0302;
		}
		goto IL_0370;
		IL_0370:
		SpawnCursor();
		AddEffects();
		if (customMerchantData != null)
		{
			object obj = customMerchantData._003CMerchantCharacter_003Ek__BackingField - 256;
			bool flag5 = obj == null;
			_003CSkipValidWeaponCheck_003Ek__BackingField = flag5;
			if ((object)customMerchantData._003CCustomCooldown_003Ek__BackingField != null)
			{
				bool flag6 = (object)customMerchantData._003CCustomCooldown_003Ek__BackingField == null;
				_shopCooldown = (float)vector;
			}
			GameManager core = GM.Core;
			if ((object)GM.Core != null && core._multiplayer != null)
			{
				if (!core._multiplayer.IsOnlineMultiplayer)
				{
					return;
				}
				if ((object)_coherenceSync != null)
				{
					if (!_coherenceSync.HasStateAuthority)
					{
						return;
					}
					byte[] param = SerializationUtils.SerializeCustomMerchantData(_customMerchantData);
					Action<byte[]> action = SendMerchantData;
					if ((object)_coherenceSync != null)
					{
						bool flag7 = _coherenceSync.SendCommand((Action<object>)action, MessageTarget.Other, param);
						return;
					}
				}
			}
		}
		goto IL_0302;
	}

	public void SendMerchantData(byte[] serializedMerchantData)
	{
		CustomMerchantData inventoryData = SerializationUtils.DeserializeCustomMerchantData(serializedMerchantData);
		SetInventoryData(inventoryData);
	}

	public void SetFacePlayerEnabled(bool isEnabled)
	{
		_facePlayer = isEnabled;
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float2 float5 = SafeXY();
		base.position = float5;
		if (_facePlayer)
		{
			float2 float6 = base.position;
			GameManager core = GM.Core;
			GameSessionData gameSessionData = core._gameSessionData;
			float2 float7 = gameSessionData._activeCharacter.position;
			bool flag = (byte)(float6 < float7) != 0;
			object obj = float6 - float7;
			bool flag2 = obj == null;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			ArcadeSprite arcadeSprite = setFlipX(flag5);
		}
	}

	public override void UpdateDepth()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int num = default(int);
		if (_ShowAboveAll)
		{
			num = 1990;
		}
		ArcadeSprite arcadeSprite = setDepth(num);
		ParticleEmitterManager particleEmitterManager = _particleEmitterManager;
		if ((object)_particleEmitterManager != null && ((UnityEngine.Object)particleEmitterManager).m_CachedPtr != (IntPtr)0)
		{
			int num2 = base.Depth;
			int num3 = num2 - 1;
			ParticleEmitterManager particleEmitterManager2 = _particleEmitterManager.SetDepth(num3);
		}
	}

	public void UpdateShopCooldown(float newCooldown)
	{
		_shopCooldown = newCooldown;
		_shopCooldownTimer = newCooldown;
	}

	public override void GetTaken()
	{
		//IL_0010: Invalid comparison between F4 and I4
		if (((Pickup)this)._003CDisableGet_003Ek__BackingField)
		{
			return;
		}
		if (_shopCooldownTimer > 0f)
		{
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				return;
			}
		}
		ParticleSystem pfxEmitter = _pfxEmitter;
		if ((object)_pfxEmitter != null && ((UnityEngine.Object)pfxEmitter).m_CachedPtr != (IntPtr)0)
		{
			RenderingExtensions.StopEmitting(_pfxEmitter);
		}
		CustomMerchantData customMerchantData = _customMerchantData;
		if ((object)customMerchantData._003CCustomCooldown_003Ek__BackingField != null)
		{
			if ((object)customMerchantData._003CCustomCooldown_003Ek__BackingField == null)
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				return;
			}
			float num = default(float);
			_shopCooldown = num;
			_shopCooldownTimer = num;
		}
		MerchantInventoryType inventoryType = GetInventoryType();
		_gameManager.QueueEnterShop(_targetPlayer, inventoryType, this);
		_shopCooldownTimer = _shopCooldown;
		Reset();
	}

	public override void GetOnlineTaken()
	{
		//IL_000b: Invalid comparison between F4 and I4
		if (!(_shopCooldownTimer > 0f))
		{
			base.GetOnlineTaken();
		}
	}

	public virtual bool IsMerchantSoldOut()
	{
		//IL_016f: Expected I4, but got O
		//IL_00ec: Expected O, but got I
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		CustomMerchantData customMerchantData = _customMerchantData;
		if (_customMerchantData != null)
		{
			List<WeaponType> validCustomMerchantWeapons = ShopFactory.GetValidCustomMerchantWeapons(customMerchantData._003CMerchantInventory_003Ek__BackingField, _playerOptions);
			CustomMerchantData customMerchantData2 = _customMerchantData;
			if (_customMerchantData != null)
			{
				List<ItemType> validCustomMerchantItems = ShopFactory.GetValidCustomMerchantItems(customMerchantData2._003CMerchantInventoryItems_003Ek__BackingField, _playerOptions);
				if (validCustomMerchantWeapons != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
					if ((nint)0 > (nint)0)
					{
						return false;
					}
				}
				if (validCustomMerchantItems == null)
				{
					return true;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj = num ^ 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				object obj2 = 0 & obj;
				bool flag = (nint)obj2 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				bool flag2 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
				bool flag3 = (nint)0 == 0;
				bool flag4 = flag2 != flag;
				return flag4 | flag3;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void ForceGetTaken()
	{
		if (!_taken)
		{
			((Pickup)this).GetTaken();
			_taken = true;
		}
	}

	protected virtual MerchantInventoryType GetInventoryType()
	{
		return MerchantInventoryType.CUSTOM;
	}

	private unsafe void SetCharacterFrame()
	{
		//IL_00fb: Expected I4, but got O
		if (_customMerchantData == null)
		{
			return;
		}
		CustomMerchantData customMerchantData = _customMerchantData;
		string message = "Setting Character Frame: " + customMerchantData._003CStaticSprite_003Ek__BackingField;
		Debug.Log(message);
		CustomMerchantData customMerchantData2 = _customMerchantData;
		string text = customMerchantData2._003CStaticSprite_003Ek__BackingField;
		if (customMerchantData2._003CStaticSprite_003Ek__BackingField != null && text._stringLength > 0)
		{
			CustomMerchantData customMerchantData3 = _customMerchantData;
			if (SpriteManager.TextureExists(customMerchantData3._003CStaticSpriteTexture_003Ek__BackingField))
			{
				_003CSetCharacterFrame_003Eg__SetSprite_007C29_1();
				return;
			}
			CustomMerchantData customMerchantData4 = _customMerchantData;
			Action<bool> action = null;
			((PickupCustomMerchant)(object)action)._003CSetCharacterFrame_003Eb__29_0((byte)(int)this != 0);
			CustomMerchantData customMerchantData5 = _customMerchantData;
			GameManager core = GM.Core;
			string customCacheGroup = default(string);
			CharacterLoader.LoadCharacterTextureAsync(customMerchantData4._003CStaticSpriteTexture_003Ek__BackingField, customMerchantData5._003CMerchantCharacter_003Ek__BackingField, action, core._dataManager, customCacheGroup);
			return;
		}
		CustomMerchantData customMerchantData6 = _customMerchantData;
		if (customMerchantData6._003CMerchantCharacter_003Ek__BackingField != CharacterType.VOID)
		{
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
			if (((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).TryGetValue((System.Int32Enum)customMerchantData6._003CMerchantCharacter_003Ek__BackingField, out object value) && ((Dictionary<CharacterType, List<CharacterData>>)value).TryGetValue(customMerchantData6._003CMerchantCharacter_003Ek__BackingField, out *(List<CharacterData>*)(&value)))
			{
				SkinType skinTypeForCharacter = _playerOptions.GetSkinTypeForCharacter(customMerchantData6._003CMerchantCharacter_003Ek__BackingField);
				Skin skinForCharacter = _playerOptions.GetSkinForCharacter(customMerchantData6._003CMerchantCharacter_003Ek__BackingField, skinTypeForCharacter);
				Sprite sprite = SpriteManager.GetSprite(skinForCharacter._003CspriteName_003Ek__BackingField, skinForCharacter._003CtextureName_003Ek__BackingField);
				ArcadeSprite arcadeSprite = setFrame(sprite);
				base.SpriteName = skinForCharacter._003CspriteName_003Ek__BackingField;
			}
		}
	}

	private void SetBodyOffset()
	{
		//IL_0067: Expected O, but got I4
		if (_customMerchantData == null)
		{
			return;
		}
		CustomMerchantData customMerchantData = _customMerchantData;
		if ((object)customMerchantData._003CBodyOffset_003Ek__BackingField != null)
		{
			if ((object)customMerchantData._003CBodyOffset_003Ek__BackingField != null)
			{
				float x = default(float);
				BaseBody baseBody = body.setOffset(x, (float?)(object)1);
			}
			else
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0a63: Expected O, but got I
		//IL_04d5: Expected O, but got I
		//IL_0b04: Expected O, but got I4
		//IL_08e2: Expected O, but got I4
		//IL_0b21: Expected O, but got I4
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected O, but got Unknown
		//IL_0b3e: Expected O, but got I4
		//IL_0920: Expected O, but got I4
		//IL_092e: Expected O, but got I4
		//IL_063f: Expected O, but got I
		//IL_0707: Expected O, but got I
		//IL_0965->IL0965: Incompatible stack heights: 1 vs 0
		List<string> list = new List<string>();
		string texture;
		List<string> list5;
		if (list != null)
		{
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._items != null)
			{
				if (list._size >= items.Length)
				{
					((List<object>)(object)list).AddWithResize((object)"mask1");
				}
				else
				{
					int num = list._size + 1;
					list._size = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				int version2 = list._version + 1;
				list._version = version2;
				string[] items2 = list._items;
				if (list._items != null)
				{
					if (list._size >= items2.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"mask2");
					}
					else
					{
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					int version3 = list._version + 1;
					list._version = version3;
					string[] items3 = list._items;
					if (list._items != null)
					{
						if (list._size >= items3.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"mask3");
						}
						else
						{
							int num3 = list._size + 1;
							list._size = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						int version4 = list._version + 1;
						list._version = version4;
						string[] items4 = list._items;
						if (list._items != null)
						{
							if (list._size >= items4.Length)
							{
								((List<object>)(object)list).AddWithResize((object)"mask4");
							}
							else
							{
								int num4 = list._size + 1;
								list._size = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							int version5 = list._version + 1;
							list._version = version5;
							string[] items5 = list._items;
							if (list._items != null)
							{
								if (list._size >= items5.Length)
								{
									((List<object>)(object)list).AddWithResize((object)"mask5");
								}
								else
								{
									int num5 = list._size + 1;
									list._size = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (_customMerchantData != null)
								{
									CustomMerchantData customMerchantData = _customMerchantData;
									if (customMerchantData._003CMerchantInventory_003Ek__BackingField != null)
									{
										List<WeaponType> list2 = customMerchantData._003CMerchantInventory_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v900 @ rcx_v118 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
										if ((nint)0 > (nint)0)
										{
											List<string> list3 = new List<string>();
											CustomMerchantData customMerchantData2 = _customMerchantData;
											if (_customMerchantData != null && customMerchantData2._003CMerchantInventory_003Ek__BackingField != null)
											{
												texture = "items";
												object obj = default(object);
												object obj2 = default(object);
												object obj4 = default(object);
												while (true)
												{
													if (obj != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-178_v21+1C]");
														if (obj2 != null)
														{
															break;
														}
														object obj3 = obj4;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-178_v21+18]");
														if ((nint)obj3 >= 0)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-178_v21+10]");
														object obj5 = 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-178_v21+10]");
														if ((nint)0 != 0)
														{
															object obj6 = obj4;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1084 @ rdx_v87+18]");
															if ((nint)obj6 < 0)
															{
																object obj7 = obj4 + 1;
																if (_dataManager != null)
																{
																	Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
																	if (convertedWeapons != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1084 @ rdx_v87+20+v1064 @ stack_-170_v19*4]");
																		bool flag = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).TryGetValue((System.Int32Enum)0, out object value);
																		bool flag2 = !flag;
																		obj4 = obj7;
																		if (flag2)
																		{
																			continue;
																		}
																		if (value != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ stack_20_v21 (System.Object)+18]");
																			bool flag3 = (nint)0 <= (nint)0;
																			obj4 = obj7;
																			if (flag3)
																			{
																				continue;
																			}
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ stack_20_v21 (System.Object)+18]");
																			if ((nint)0 > (nint)0)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ stack_20_v21 (System.Object)+10]");
																				object obj8 = 0;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1160 @ stack_20_v21 (System.Object)+10]");
																				if ((nint)0 != 0)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1190 @ rcx_v129+18]");
																					if ((nint)0 > (nint)0)
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1190 @ rcx_v129+20]");
																						nint num6 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1190 @ rcx_v129+20]");
																						if ((nint)0 != 0)
																						{
																							if (list3 != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1233 @ rsi_v26 (Il2CppMethodInfo)+40]");
																								bool flag4 = ((Dictionary<WeaponType, List<WeaponData>>)(object)list3).TryGetValue(WeaponType.VOID, out *(List<WeaponData>*)null);
																								obj4 = obj7;
																								texture = (string)0;
																								continue;
																							}
																							throw new NullReferenceException();
																						}
																						throw new NullReferenceException();
																					}
																					throw new IndexOutOfRangeException();
																				}
																				throw new NullReferenceException();
																			}
																			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
																		}
																	}
																	throw new NullReferenceException();
																}
																throw new NullReferenceException();
															}
															throw new IndexOutOfRangeException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												bool flag5 = obj == null;
												List<string> list4 = (List<string>)0;
												if (!flag5)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-178_v21+1C]");
													if (obj2 == null)
													{
														if (list3 == null)
														{
															goto IL_0a14;
														}
														list5 = list3;
														goto IL_0a8e;
													}
													System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
													list4 = null;
												}
												throw new NullReferenceException();
											}
											goto IL_0a14;
										}
									}
								}
								texture = "vfx";
								list5 = list;
								goto IL_0a8e;
							}
						}
					}
				}
			}
		}
		goto IL_0a14;
		IL_0a8e:
		if (list5._size > 0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager particleEmitterManager = ((!gameObject.TryGetComponent<ParticleEmitterManager>(out var component)) ? gameObject.AddComponent<ParticleEmitterManager>() : component);
			_particleEmitterManager = particleEmitterManager;
			Transform transform = base.transform;
			bool flag6 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			float ret;
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig(texture)
			{
				_frame = list5
			};
			ParticleSystem.MinMaxCurve x = new ParticleSystem.MinMaxCurve(ret);
			particleSystemConfig._x = x;
			_ = 0;
			float constant = default(float);
			ParticleSystem.MinMaxCurve y = new ParticleSystem.MinMaxCurve(constant);
			particleSystemConfig._y = y;
			_ = 0;
			ParticleSystem.MinMaxCurve lifespan = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig._lifespan = lifespan;
			_ = 0;
			ParticleSystem.MinMaxCurve rotate = new ParticleSystem.MinMaxCurve(-20f, 20f);
			particleSystemConfig._rotate = rotate;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(260f, 280f);
			particleSystemConfig._angle = minMaxCurve;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = new ParticleSystem.MinMaxCurve(20f, 50f);
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			particleSystemConfig._quantity = (int?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(1f, 0.75f);
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = new ParticleSystem.MinMaxCurve(1f, 0f);
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			particleSystemConfig._frequency = (float?)(object)1;
			particleSystemConfig._tint = (uint?)(object)1;
			particleSystemConfig._on = true;
			ParticleSystem pfxEmitter = _particleEmitterManager.CreateEmitter(particleSystemConfig);
			_pfxEmitter = pfxEmitter;
		}
		return;
		IL_0a14:
		throw new NullReferenceException();
	}

	private unsafe void AddEffects()
	{
		//IL_0522: Expected I, but got O
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Expected O, but got Unknown
		//IL_0595: Expected I, but got O
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Expected O, but got Unknown
		//IL_0666: Expected O, but got I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected I4, but got Unknown
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Expected O, but got Unknown
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Expected O, but got Unknown
		//IL_06f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f5: Expected O, but got Unknown
		//IL_0715: Unknown result type (might be due to invalid IL or missing references)
		//IL_071a: Expected O, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Expected O, but got Unknown
		//IL_07cf: Expected I, but got O
		//IL_081f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0824: Expected O, but got Unknown
		//IL_0856: Expected I, but got O
		//IL_08c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ca: Expected O, but got Unknown
		//IL_08f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f7: Expected O, but got Unknown
		//IL_0985: Expected O, but got I4
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected I4, but got Unknown
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cd: Expected O, but got Unknown
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		if ((object)gameObject != null)
		{
			SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
			Transform transform = gameObject.transform;
			Transform parent = base.transform;
			if ((object)transform != null)
			{
				transform.SetParent(parent, worldPositionStays: true);
				Transform transform2 = gameObject.transform;
				nint num = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v77 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num2 = 0;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ rax_v82 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				object obj2 = default(object);
				object obj = obj2 - 64;
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref *(Vector3*)obj);
				Transform transform3 = gameObject.transform;
				nint num3 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ rcx_v83 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num4 = 0;
				_ = Vector3.oneVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rdx_v62 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
				float num5 = 0f * 0.2f;
				bool flag2 = (object)transform3 == null;
				bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				object obj3 = obj2 - 48;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj3);
				bool flag4 = (object)_spriteAnimation == null;
				SpriteRenderer component = _spriteAnimation.GetComponent<SpriteRenderer>();
				bool flag5 = (object)component == null;
				bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
				object obj4 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr);
				bool flag7 = (object)spriteRenderer == null;
				int sortingOrder = obj4 - 2;
				spriteRenderer.sortingOrder = sortingOrder;
				Sprite sprite = SpriteManager.GetSprite("circle", "vfx");
				spriteRenderer.sprite = sprite;
				_ = ColourHelper.HexToColor("8EEFF1").r;
				bool flag8 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				object obj5 = obj2 - 48;
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref *(Color*)obj5);
				_ = 0;
				bool flag9 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				object obj6 = obj2 - 32;
				SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)obj6);
				_ = 0;
				bool flag10 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				object obj7 = obj2 - 48;
				SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)obj7);
				_ = 0;
				bool flag11 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				object obj8 = obj2 - 64;
				SpriteRenderer.get_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, out *(Color*)obj8);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-2C]");
				_ = 0;
				_ = 1053609165;
				bool flag12 = ((UnityEngine.Object)spriteRenderer).m_CachedPtr == (IntPtr)0;
				object obj9 = obj2 - 32;
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer).m_CachedPtr, ref *(Color*)obj9);
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(spriteRenderer, 0.2f, 1.3f);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1984 @ rax_v125 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
					}
				}
				Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
				((Renderer)spriteRenderer).SetMaterial(material);
				((UnityEngine.Object)gameObject).SetName("GlowEffect");
				GameObject gameObject2 = new GameObject();
				GameObject.Internal_CreateGameObject(gameObject2, (string)null);
				bool flag13 = (object)gameObject2 == null;
				SpriteRenderer spriteRenderer2 = gameObject2.AddComponent<SpriteRenderer>();
				Transform transform4 = gameObject2.transform;
				Transform parent2 = base.transform;
				bool flag14 = (object)transform4 == null;
				transform4.SetParent(parent2, worldPositionStays: true);
				Transform transform5 = gameObject2.transform;
				nint num6 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2248 @ rcx_v128 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num7 = 0;
				bool flag15 = (object)transform5 == null;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2246 @ rax_v142 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				bool flag16 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
				object obj10 = obj2 - 48;
				Transform.set_localPosition_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)obj10);
				Transform transform6 = gameObject2.transform;
				nint num8 = (nint)typeof(Vector3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2021 @ rcx_v134 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num9 = 0;
				_ = Vector3.oneVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1248 @ rdx_v85 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
				float num10 = 0f * 0.9f;
				bool flag17 = (object)transform6 == null;
				bool flag18 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
				object obj11 = obj2 - 64;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj11);
				Transform target = gameObject2.transform;
				Vector3 endValue = (Vector3)(obj2 - 48);
				_ = 360f;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DORotate(target, endValue, 0.8f, RotateMode.LocalAxisAdd);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2017 @ rax_v155 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2017 @ rax_v155 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2017 @ rax_v155 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
					}
				}
				bool flag19 = (object)_spriteAnimation == null;
				SpriteRenderer component2 = _spriteAnimation.GetComponent<SpriteRenderer>();
				bool flag20 = (object)component2 == null;
				bool flag21 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				object obj12 = Renderer.get_sortingOrder_Injected(((UnityEngine.Object)component2).m_CachedPtr);
				bool flag22 = (object)spriteRenderer2 == null;
				int sortingOrder2 = obj12 - 1;
				spriteRenderer2.sortingOrder = sortingOrder2;
				Sprite sprite2 = SpriteManager.GetSprite("FlareCircle3", "vfx");
				spriteRenderer2.sprite = sprite2;
				_ = ColourHelper.HexToColor("8EEFF1").r;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2347 @ rax_v136 (UnityEngine.SpriteRenderer)+10]");
				bool flag23 = (nint)0 == 0;
				object obj13 = obj2 - 48;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2347 @ rax_v136 (UnityEngine.SpriteRenderer)+10]");
				SpriteRenderer.set_color_Injected((IntPtr)0, ref *(Color*)obj13);
				TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(spriteRenderer2, 0.2f, 1.3f);
				if (tweenerCore3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2620 @ rax_v169 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2620 @ rax_v169 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 4294967295L;
							_ = 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2620 @ rax_v169 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
							if ((nint)0 == 0)
							{
								_ = 2139095040;
							}
						}
					}
				}
				Material material2 = MaterialManager.GetMaterial(MaterialType.Vfx);
				((Renderer)spriteRenderer2).SetMaterial(material2);
				((UnityEngine.Object)gameObject2).SetName("SpinEffect");
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void SpawnCursor()
	{
		//IL_02cc: Expected O, but got I4
		//IL_0175: Expected O, but got I
		//IL_0185: Expected O, but got I
		//IL_0029->IL026e: Incompatible stack heights: 1 vs 0
		//IL_0055->IL026e: Incompatible stack heights: 1 vs 0
		//IL_030d->IL026e: Incompatible stack heights: 1 vs 0
		//IL_011b->IL026e: Incompatible stack heights: 1 vs 0
		//IL_014f->IL026e: Incompatible stack heights: 1 vs 0
		//IL_0259->IL026e: Incompatible stack heights: 1 vs 0
		GameObject gameObject = base.gameObject;
		if ((object)gameObject != null)
		{
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			object obj = GameObject.get_activeInHierarchy_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			if (obj == null)
			{
				return;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					if (!config._003CShowPickups_003Ek__BackingField)
					{
						return;
					}
					CursorData cursorData = new CursorData
					{
						IconAlpha = 1f,
						_cursorProportionOfScreenFromCenter = 0.45f,
						AnimationName = "arrow_0"
					};
					_ = 1;
					_ = 8;
					_ = 16;
					Sprite sprite = SpriteManager.GetSprite("arrow_01", "UI");
					_ = 1073741824;
					_ = 1065353216;
					DataManager dataManager = _dataManager;
					if (_dataManager != null && dataManager._003CAllItems_003Ek__BackingField != null)
					{
						object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)29);
						if (obj2 != null)
						{
							bool flag2 = _customMerchantData == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v23 (System.Object)+38]");
							string spriteName = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v23 (System.Object)+30]");
							string textureName = (string)0;
							if (!flag2)
							{
								CustomMerchantData customMerchantData = _customMerchantData;
								string text = customMerchantData._003CPortraitSprite_003Ek__BackingField;
								if (customMerchantData._003CPortraitSprite_003Ek__BackingField != null && text._stringLength > 0)
								{
									textureName = customMerchantData._003CPortraitSpriteTexture_003Ek__BackingField;
									spriteName = customMerchantData._003CPortraitSprite_003Ek__BackingField;
								}
							}
							Sprite sprite2 = SpriteManager.GetSprite(spriteName, textureName);
							GameObject gameObject2 = base.gameObject;
							if (_signalBus != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4920");
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void RemoveCursor()
	{
		Transform transform = base.transform;
		GameObject gameObject = transform.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
	}

	protected override void ToggleCursors(UISignals.ToggleGuidesSignal sig)
	{
		if ((object)sig == null)
		{
			Transform transform = base.transform;
			GameObject gameObject = transform.gameObject;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA4A10");
		}
		else
		{
			SpawnCursor();
		}
	}

	private Sprite GetCustomMerchantCursorSprite()
	{
		//IL_007c: Expected O, but got I
		//IL_008c: Expected O, but got I
		DataManager dataManager = _dataManager;
		if (_dataManager != null && dataManager._003CAllItems_003Ek__BackingField != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)29);
			if (obj != null)
			{
				bool flag = _customMerchantData == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v5 (System.Object)+30]");
				string textureName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v5 (System.Object)+38]");
				string spriteName = (string)0;
				if (!flag)
				{
					CustomMerchantData customMerchantData = _customMerchantData;
					string text = customMerchantData._003CPortraitSprite_003Ek__BackingField;
					if (customMerchantData._003CPortraitSprite_003Ek__BackingField != null && text._stringLength > 0)
					{
						textureName = customMerchantData._003CPortraitSpriteTexture_003Ek__BackingField;
						spriteName = customMerchantData._003CPortraitSprite_003Ek__BackingField;
					}
				}
				return SpriteManager.GetSprite(spriteName, textureName);
			}
		}
		return (Sprite)(object)new NullReferenceException();
	}

	private void LoadCharacterTextureAsync(string textureName, Action<bool> onTextureLoaded)
	{
		CustomMerchantData customMerchantData = _customMerchantData;
		GameManager core = GM.Core;
		string customCacheGroup = default(string);
		CharacterLoader.LoadCharacterTextureAsync(textureName, customMerchantData._003CMerchantCharacter_003Ek__BackingField, onTextureLoaded, core._dataManager, customCacheGroup);
	}

	public PickupCustomMerchant()
	{
		List<CustomActionInventoryItem> customActionInventoryItems = new List<CustomActionInventoryItem>();
		CustomActionInventoryItems = customActionInventoryItems;
		base._002Ector();
	}

	private void _003CSetCharacterFrame_003Eb__29_0(bool _)
	{
		_003CSetCharacterFrame_003Eg__SetSprite_007C29_1();
	}

	private void _003CSetCharacterFrame_003Eg__SetSprite_007C29_1()
	{
		//IL_0103: Expected O, but got I4
		//IL_0103: Expected I4, but got O
		CustomMerchantData customMerchantData = _customMerchantData;
		Sprite sprite = SpriteManager.GetSprite(customMerchantData._003CStaticSprite_003Ek__BackingField, customMerchantData._003CStaticSpriteTexture_003Ek__BackingField);
		ArcadeSprite arcadeSprite = setFrame(sprite);
		CustomMerchantData customMerchantData2 = _customMerchantData;
		if (customMerchantData2._003CIsAnimated_003Ek__BackingField)
		{
			_spriteAnimation.CleanAnimations();
			CustomMerchantData customMerchantData3 = _customMerchantData;
			string animName = customMerchantData3._003CStaticSprite_003Ek__BackingField.Replace("01", "");
			Vector2 pivot = default(Vector2);
			string text = default(string);
			int num = default(int);
			bool flag = default(bool);
			List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 5, pivot, text, num, flag);
			bool autoSetAnimation = default(bool);
			_spriteAnimation.AddAnimation("walk", animationFrames, 8, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
			_spriteAnimation.SetAnimation("walk");
		}
	}
}
