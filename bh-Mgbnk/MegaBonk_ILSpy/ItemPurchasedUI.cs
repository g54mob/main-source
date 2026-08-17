using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class ItemPurchasedUI : MonoBehaviour
{
	private sealed class _003CShowNewItem_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ItemPurchasedUI _003C_003E4__this;

		public UnlockableBase unlockable;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShowNewItem_003Ed__24(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_007e: Expected I4, but got I8
			//IL_0496: Expected I4, but got O
			//IL_02c3: Expected O, but got Ref
			//IL_037a: Expected I, but got O
			//IL_0390: Expected O, but got I
			//IL_0468: Expected O, but got I
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				ItemPurchasedUI itemPurchasedUI = _003C_003E4__this;
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)itemPurchasedUI.content != null)
				{
					itemPurchasedUI.content.SetActive((byte)_003C_003E1__state != 0);
					if ((object)itemPurchasedUI.sfx != null)
					{
						itemPurchasedUI.sfx.Play();
						if ((object)itemPurchasedUI.ps != null)
						{
							itemPurchasedUI.ps.Play();
							if ((object)itemPurchasedUI.background != null)
							{
								itemPurchasedUI.background.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
								if ((object)itemPurchasedUI.background != null)
								{
									itemPurchasedUI.background.CrossFadeAlpha(itemPurchasedUI.desiredAlpha, itemPurchasedUI.fadeInTime, ignoreTimeScale: false);
									if ((object)unlockable != null)
									{
										Texture icon = unlockable.GetIcon();
										if ((object)itemPurchasedUI.itemDisplay != null)
										{
											itemPurchasedUI.itemDisplay.texture = icon;
											if ((object)unlockable != null)
											{
												string name = unlockable.GetName();
												if ((object)itemPurchasedUI.itemNameText != null)
												{
													itemPurchasedUI.itemNameText.text = name;
													if ((object)itemPurchasedUI.itemNameText != null)
													{
														Transform transform = itemPurchasedUI.itemNameText.transform;
														if ((object)transform != null)
														{
															object obj = default(object);
															transform.localScale = (Vector3)(&obj);
															Dictionary<string, string> dictionary = new Dictionary<string, string>();
															if ((object)unlockable != null)
															{
																object unlockableTypeDisplayString = unlockable.GetUnlockableTypeDisplayString();
																if (dictionary != null)
																{
																	((Dictionary<object, object>)(object)dictionary).Add((object)"item", unlockableTypeDisplayString);
																	LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("MainMenuOther", "ITEM_PURCHASED");
																	object[] array = new object[1];
																	if (array != null)
																	{
																		nint num = (nint)array;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rdx_v18 (Il2CppClass<System.Object[]>)+40]");
																		dictionary.Add((string)0, null);
																		object obj2 = default(object);
																		if (obj2 == null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rdx_v18 (Il2CppClass<System.Object[]>)+40]");
																			dictionary.Add((string)0, null);
																			object obj3 = default(object);
																			throw obj3;
																		}
																		array[0] = dictionary;
																		if (localizedStringReference != null)
																		{
																			string localizedString = localizedStringReference.GetLocalizedString(array);
																			string text = localizedString + " <size=130%><sprite name=\"Check\" color=#04ff00>";
																			if ((object)itemPurchasedUI.extraText != null)
																			{
																				itemPurchasedUI.extraText.text = text;
																				itemPurchasedUI.yRotation = 720f;
																				return false;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
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
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private sealed class _003CShowNewItem_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ItemPurchasedUI _003C_003E4__this;

		public MyAchievement achievement;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShowNewItem_003Ed__25(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_007e: Expected I4, but got I8
			//IL_0359: Expected I4, but got O
			//IL_02ab: Expected O, but got Ref
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				ItemPurchasedUI itemPurchasedUI = _003C_003E4__this;
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null && (object)itemPurchasedUI.content != null)
				{
					itemPurchasedUI.content.SetActive((byte)_003C_003E1__state != 0);
					if ((object)itemPurchasedUI.sfx != null)
					{
						itemPurchasedUI.sfx.Play();
						if ((object)itemPurchasedUI.ps != null)
						{
							itemPurchasedUI.ps.Play();
							if ((object)itemPurchasedUI.background != null)
							{
								itemPurchasedUI.background.CrossFadeAlpha(0f, 0f, ignoreTimeScale: true);
								if ((object)itemPurchasedUI.background != null)
								{
									itemPurchasedUI.background.CrossFadeAlpha(itemPurchasedUI.desiredAlpha, itemPurchasedUI.fadeInTime, ignoreTimeScale: false);
									if ((object)itemPurchasedUI.itemDisplay != null)
									{
										itemPurchasedUI.itemDisplay.texture = itemPurchasedUI.silverIcon;
										if ((object)achievement != null)
										{
											string rewardString = achievement.GetRewardString();
											bool flag = rewardString == null;
											string text = "";
											if (!flag)
											{
												text = rewardString;
											}
											if ((object)itemPurchasedUI.itemNameText != null)
											{
												itemPurchasedUI.itemNameText.text = text;
												if ((object)itemPurchasedUI.itemNameText != null)
												{
													Transform transform = itemPurchasedUI.itemNameText.transform;
													if ((object)transform != null)
													{
														object obj = default(object);
														transform.localScale = (Vector3)(&obj);
														LocalizedString localizedStringReference = LocalizationUtility.GetLocalizedStringReference("MainMenuOther", "JUICE");
														if (localizedStringReference != null)
														{
															string localizedString = localizedStringReference.GetLocalizedString();
															string text2 = localizedString + " <size=130%><sprite name=\"Check\" color=#04ff00>";
															if ((object)itemPurchasedUI.extraText != null)
															{
																itemPurchasedUI.extraText.text = text2;
																itemPurchasedUI.yRotation = 720f;
																goto IL_0369;
															}
														}
													}
												}
											}
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
			goto IL_0369;
			IL_0369:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public GameObject content;

	public RawImage background;

	public RawImage itemDisplay;

	public TextMeshProUGUI itemNameText;

	public TextMeshProUGUI extraText;

	public ParticleSystem ps;

	private bool hasClaimedAchievement;

	private float fadeInTime = 0.6f;

	private float fadeOutTime = 0.2f;

	private float cardDesiredScale;

	private float textDesiredScale;

	private float desiredAlpha = 0.99f;

	private float yRotation = 1000f;

	private float animatorTime;

	private float animatorSpeed = 0.8f;

	public AudioSource sfx;

	public Texture silverIcon;

	private void Awake()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		Action<UnlockableBase> b = OnItemPurchased;
		Delegate obj = Delegate.Combine(UnlocksFooter.A_Purchased, b);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			UnlocksFooter.A_Purchased = (Action<UnlockableBase>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<UnlockableBase> action = default(Action<UnlockableBase>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<UnlockableBase>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_035a;
			}
			UnlocksFooter.A_Purchased = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<UnlockableBase>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0317;
			}
		}
		Action<MyAchievement> b2 = OnAchievementClaimed;
		Delegate obj6 = Delegate.Combine(ProgressionSaveFile.A_AchievementClaimed, b2);
		if ((object)obj6 == null)
		{
			ProgressionSaveFile.A_AchievementClaimed = (Action<MyAchievement>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyAchievement> action2 = default(Action<MyAchievement>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_0322;
			}
			ProgressionSaveFile.A_AchievementClaimed = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<MyAchievement>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0332;
			}
		}
		Action<SkinData> b3 = OnSkinPurchased;
		Delegate obj8 = Delegate.Combine(SkinContainer.A_Purchased, b3);
		if ((object)obj8 == null)
		{
			SkinContainer.A_Purchased = (Action<SkinData>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SkinData> action3 = default(Action<SkinData>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<SkinData>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_034a;
		}
		SkinContainer.A_Purchased = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<SkinData>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_035a;
		IL_035a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_034a;
		IL_0317:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0322:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0317;
		IL_0332:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0322;
		IL_034a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0332;
	}

	private void OnDestroy()
	{
		//IL_02d0: Expected I, but got O
		//IL_02e1: Expected O, but got I4
		//IL_02ea: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_0134: Expected I, but got O
		//IL_0145: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_018c: Expected I, but got O
		//IL_019d: Expected O, but got I4
		//IL_01a6: Expected O, but got I4
		//IL_0236: Expected I, but got O
		//IL_0247: Expected O, but got I4
		//IL_0250: Expected O, but got I4
		//IL_028e: Expected I, but got O
		//IL_029f: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		Action<UnlockableBase> value = OnItemPurchased;
		Delegate obj = Delegate.Remove(UnlocksFooter.A_Purchased, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			UnlocksFooter.A_Purchased = (Action<UnlockableBase>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<UnlockableBase> action = default(Action<UnlockableBase>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<UnlockableBase>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_035a;
			}
			UnlocksFooter.A_Purchased = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<UnlockableBase>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_0317;
			}
		}
		Action<MyAchievement> value2 = OnAchievementClaimed;
		Delegate obj6 = Delegate.Remove(ProgressionSaveFile.A_AchievementClaimed, value2);
		if ((object)obj6 == null)
		{
			ProgressionSaveFile.A_AchievementClaimed = (Action<MyAchievement>)obj6;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyAchievement> action2 = default(Action<MyAchievement>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<MyAchievement>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag2)
			{
				goto IL_0322;
			}
			ProgressionSaveFile.A_AchievementClaimed = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num = (nint)typeof(Action<MyAchievement>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = 0;
			if (flag3)
			{
				goto IL_0332;
			}
		}
		Action<SkinData> value3 = OnSkinPurchased;
		Delegate obj8 = Delegate.Remove(SkinContainer.A_Purchased, value3);
		if ((object)obj8 == null)
		{
			SkinContainer.A_Purchased = (Action<SkinData>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SkinData> action3 = default(Action<SkinData>);
		bool flag4 = action3 == null;
		num = (nint)typeof(Action<SkinData>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (flag4)
		{
			goto IL_034a;
		}
		SkinContainer.A_Purchased = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj9 = default(object);
		bool flag5 = obj9 == null;
		num = (nint)typeof(Action<SkinData>);
		obj2 = obj8;
		obj3 = 0;
		obj4 = 0;
		if (!flag5)
		{
			return;
		}
		goto IL_035a;
		IL_035a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_034a;
		IL_0317:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0322:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0317;
		IL_0332:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0322;
		IL_034a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0332;
	}

	private void OnSkinPurchased(SkinData skinData)
	{
		IEnumerator routine = ShowNewItem(skinData);
		Coroutine coroutine = StartCoroutine(routine);
	}

	private void OnItemPurchased(UnlockableBase unlockable)
	{
		IEnumerator routine = ShowNewItem(unlockable);
		Coroutine coroutine = StartCoroutine(routine);
	}

	private void OnAchievementClaimed(MyAchievement achievement)
	{
	}

	private void Update()
	{
		Animate();
	}

	private void Test()
	{
	}

	private void Animate()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_004c: Invalid comparison between I4 and F4
		//IL_0097: Expected F4, but got I4
		//IL_044f: Invalid comparison between I4 and F4
		//IL_00d3: Expected F4, but got I4
		//IL_048e: Invalid comparison between I4 and F4
		//IL_013f: Expected F4, but got I4
		//IL_0148: Expected F4, but got I4
		//IL_04bd: Invalid comparison between I4 and F4
		//IL_0184: Expected F4, but got I4
		//IL_04fe: Expected I, but got O
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0282: Invalid comparison between I4 and F4
		//IL_02cd: Expected F4, but got I4
		//IL_05bf: Expected I, but got O
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected O, but got Unknown
		//IL_0620: Expected I, but got O
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		float num = animatorTime * 0.85f;
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
		float num2 = animatorTime * 0.5f;
		if (!(0f > num2))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = animatorTime - 0.1f;
		float num4 = num3 * 0.5f;
		float t;
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
				t = 1f;
			}
			else
			{
				float num5 = animatorTime - 0.1f;
				t = num5 * 0.5f;
			}
		}
		else
		{
			num4 = 0f;
			t = 0f;
		}
		float num6 = animatorTime - 0.5f;
		if (!(0f > num6))
		{
			if (num6 > 1f)
			{
				num6 = 1f;
			}
		}
		else
		{
			num6 = 0f;
		}
		float num7 = Easing.OutElastic(num);
		float num8 = Easing.OutElastic(num2);
		Transform transform = itemDisplay.transform;
		nint num9 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ rcx_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num10 = 0;
		float num11 = num7 * (float)Vector3.oneVector;
		float num12 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num13 = num12 * 0f;
		float num14 = num7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num15 = num14 * 0f;
		Vector3 localScale = (Vector3)(obj - 57);
		transform.localScale = localScale;
		Transform transform2 = itemDisplay.transform;
		float num16 = num8 - 1f;
		_ = 0;
		Vector3 euler = (Vector3)(obj - 57);
		float num17 = num16 * 10f;
		float num18 = num17 * ((float)Math.PI / 180f);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		Quaternion localRotation = (Quaternion)(obj - 57);
		_ = quaternion.x;
		transform2.localRotation = localRotation;
		float deltaTime = Time.deltaTime;
		float num19 = deltaTime * 3f;
		if (!(0f > num19))
		{
			if (num19 > 1f)
			{
				num19 = 1f;
			}
		}
		else
		{
			num19 = 0f;
		}
		float num20 = 0f - yRotation;
		float num21 = num20 * num19;
		float num22 = num21 + yRotation;
		yRotation = num22;
		float num23 = Easing.OutPower(num4, 20);
		float num24 = Easing.OutElastic(t);
		Transform transform3 = itemNameText.transform;
		nint num25 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v12 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num26 = 0;
		float num27 = num23 * (float)Vector3.oneVector;
		float num28 = num23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num29 = num28 * 0f;
		float num30 = num23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rdx_v13 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num31 = num30 * 0f;
		Vector3 localScale2 = (Vector3)(obj - 57);
		transform3.localScale = localScale2;
		Transform transform4 = itemNameText.transform;
		float num32 = num24 - 1f;
		_ = 0;
		Vector3 euler2 = (Vector3)(obj - 57);
		float num33 = num32 * 5f;
		float num34 = num33 * ((float)Math.PI / 180f);
		Quaternion quaternion2 = Quaternion.Internal_FromEulerRad(euler2);
		Quaternion localRotation2 = (Quaternion)(obj - 57);
		_ = quaternion2.x;
		transform4.localRotation = localRotation2;
		float num35 = Easing.OutPower(num6, 10);
		Transform transform5 = extraText.transform;
		nint num36 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num37 = 0;
		float num38 = num35 * (float)Vector3.oneVector;
		float num39 = num35;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
		float num40 = num39 * 0f;
		float num41 = num35;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rdx_v20 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num42 = num41 * 0f;
		Vector3 localScale3 = (Vector3)(obj - 57);
		transform5.localScale = localScale3;
		float deltaTime2 = Time.deltaTime;
		float num43 = deltaTime2 * animatorSpeed;
		float num44 = num43 + animatorTime;
		animatorTime = num44;
	}

	private IEnumerator ShowNewItem(UnlockableBase unlockable)
	{
		_003CShowNewItem_003Ed__24 obj = new _003CShowNewItem_003Ed__24(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.unlockable = unlockable;
		return obj;
	}

	private IEnumerator ShowNewItem(MyAchievement achievement)
	{
		_003CShowNewItem_003Ed__25 obj = new _003CShowNewItem_003Ed__25(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.achievement = achievement;
		return obj;
	}

	public void Close()
	{
		StopAllCoroutines();
		content.SetActive(value: false);
		ps.Stop();
	}
}
