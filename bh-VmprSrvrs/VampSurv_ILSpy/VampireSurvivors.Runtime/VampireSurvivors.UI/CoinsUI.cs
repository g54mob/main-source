using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class CoinsUI : MonoBehaviour
{
	private TextMeshProUGUI PriceValue;

	private Image _MoneyImage;

	private Image _FrameImage;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventureManager;

	private void Construct(PlayerOptions playerOptions, AdventureManager adventureManager)
	{
		_playerOptions = playerOptions;
		_adventureManager = adventureManager;
	}

	private unsafe void Start()
	{
		//IL_00eb: Expected O, but got Ref
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
				float num = default(float);
				float num3;
				if (config._003CCoins_003Ek__BackingField < 2.1474836E+09f)
				{
					bool flag = !(-2.1474836E+09f < config._003CCoins_003Ek__BackingField);
					num = -2.1474836E+09f;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
						int num2 = default(int);
						bool flag2 = num2 <= 9999999;
						num = -2.1474836E+09f;
						num3 = -2.1474836E+09f;
						if (flag2)
						{
							goto IL_00dc;
						}
					}
				}
				num3 = num;
				goto IL_00dc;
			}
		}
		goto IL_0395;
		IL_00dc:
		object obj = default(object);
		string text = System.Number.FormatInt32(9999999, (ReadOnlySpan<char>)(&obj), null);
		if ((object)PriceValue == null)
		{
			goto IL_0395;
		}
		PriceValue.text = text;
		PlayerOptions.OnValueChanged b = UpdatePrice;
		Delegate obj2 = PlayerOptions.GoldUpdated;
		while (true)
		{
			Delegate obj3 = Delegate.Combine(obj2, b);
			bool flag3 = (object)obj3 == null;
			Delegate obj4 = null;
			if (!flag3)
			{
				bool flag4 = (object)obj3.GetType() != typeof(PlayerOptions.OnValueChanged);
				obj4 = null;
				if (!flag4)
				{
					obj4 = obj3;
				}
				if ((object)obj4 == null)
				{
					break;
				}
			}
			bool flag5 = (object)obj2 == PlayerOptions.GoldUpdated;
			Delegate obj5;
			if ((object)obj2 == PlayerOptions.GoldUpdated)
			{
				PlayerOptions.GoldUpdated = (PlayerOptions.OnValueChanged)obj4;
				obj5 = obj2;
			}
			else
			{
				obj5 = PlayerOptions.GoldUpdated;
			}
			Delegate obj6 = obj2;
			if (!flag5)
			{
				obj6 = obj5;
			}
			bool flag6 = (object)obj6 != obj2;
			obj2 = obj6;
			if (flag6)
			{
				continue;
			}
			goto IL_01e4;
		}
		goto IL_0498;
		IL_04a4:
		throw new InvalidCastException();
		IL_01e4:
		AdventureManager adventureManager = _adventureManager;
		if (_adventureManager != null)
		{
			Action<AdventureType> b2 = OnAdventureStarted;
			Delegate obj7 = Delegate.Combine(adventureManager._003COnAdventureStartedEvent_003Ek__BackingField, b2);
			Delegate obj8 = default(Delegate);
			if ((object)obj7 == null)
			{
				obj8 = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if ((object)obj8 == null)
				{
					InvalidCastException ex = new InvalidCastException();
					goto IL_0498;
				}
			}
			adventureManager._003COnAdventureStartedEvent_003Ek__BackingField = (Action<AdventureType>)obj8;
			AdventureManager adventureManager2 = _adventureManager;
			if (_adventureManager != null)
			{
				Action b3 = OnAdventureEnded;
				Delegate obj9 = Delegate.Combine(adventureManager2._003COnAdventureExitEvent_003Ek__BackingField, b3);
				bool flag7 = (object)obj9 == null;
				Delegate obj10 = null;
				if (!flag7)
				{
					bool flag8 = (object)obj9.GetType() != typeof(Action);
					obj10 = null;
					if (!flag8)
					{
						obj10 = obj9;
					}
					if ((object)obj10 == null)
					{
						goto IL_04a4;
					}
				}
				adventureManager2._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj10;
				if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
				{
					SwitchCoinsUI();
				}
				return;
			}
		}
		goto IL_0395;
		IL_0395:
		NullReferenceException ex2 = new NullReferenceException();
		goto IL_04a4;
		IL_0498:
		throw new InvalidCastException();
	}

	private void OnDestroy()
	{
		PlayerOptions.OnValueChanged value = UpdatePrice;
		Delegate obj = PlayerOptions.GoldUpdated;
		Delegate obj7 = default(Delegate);
		while (true)
		{
			Delegate obj2 = Delegate.Remove(obj, value);
			bool flag = (object)obj2 == null;
			Delegate obj3 = null;
			if (!flag)
			{
				bool flag2 = (object)obj2.GetType() != typeof(PlayerOptions.OnValueChanged);
				obj3 = null;
				if (!flag2)
				{
					obj3 = obj2;
				}
				if ((object)obj3 == null)
				{
					InvalidCastException ex = new InvalidCastException();
					break;
				}
			}
			bool flag3 = (object)obj == PlayerOptions.GoldUpdated;
			Delegate obj4;
			if ((object)obj == PlayerOptions.GoldUpdated)
			{
				PlayerOptions.GoldUpdated = (PlayerOptions.OnValueChanged)obj3;
				obj4 = obj;
			}
			else
			{
				obj4 = PlayerOptions.GoldUpdated;
			}
			Delegate obj5 = obj;
			if (!flag3)
			{
				obj5 = obj4;
			}
			bool flag4 = (object)obj5 != obj;
			obj = obj5;
			if (flag4)
			{
				continue;
			}
			AdventureManager adventureManager = _adventureManager;
			Action<AdventureType> value2 = OnAdventureStarted;
			Delegate obj6 = Delegate.Remove(adventureManager._003COnAdventureStartedEvent_003Ek__BackingField, value2);
			if ((object)obj6 == null)
			{
				obj7 = null;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if ((object)obj7 == null)
				{
					throw new InvalidCastException();
				}
			}
			adventureManager._003COnAdventureStartedEvent_003Ek__BackingField = (Action<AdventureType>)obj7;
			AdventureManager adventureManager2 = _adventureManager;
			Action value3 = OnAdventureEnded;
			Delegate obj8 = Delegate.Remove(adventureManager2._003COnAdventureExitEvent_003Ek__BackingField, value3);
			bool flag5 = (object)obj8 == null;
			Delegate obj9 = null;
			if (!flag5)
			{
				bool flag6 = (object)obj8.GetType() != typeof(Action);
				obj9 = null;
				if (!flag6)
				{
					obj9 = obj8;
				}
				if ((object)obj9 == null)
				{
					break;
				}
			}
			adventureManager2._003COnAdventureExitEvent_003Ek__BackingField = (Action)obj9;
			return;
		}
		throw new InvalidCastException();
	}

	private unsafe void UpdatePrice()
	{
		//IL_00be: Expected O, but got Ref
		PlayerOptionsData config = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		if (config._003CCoins_003Ek__BackingField < 2.1474836E+09f && -2.1474836E+09f < config._003CCoins_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
			int num = default(int);
			switch (num)
			{
			}
		}
		object obj = default(object);
		string text = System.Number.FormatInt32(9999999, (ReadOnlySpan<char>)(&obj), null);
		PriceValue.text = text;
	}

	private void OnAdventureStarted(AdventureType adventureType)
	{
		SwitchCoinsUI();
	}

	private void OnAdventureEnded()
	{
		SwitchCoinsUI();
	}

	private unsafe void SwitchCoinsUI()
	{
		//IL_00b3: Expected O, but got Ref
		//IL_003a: Expected O, but got Ref
		object obj = default(object);
		Image frameImage;
		bool ignoreExtension;
		string textureName;
		string spriteName;
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			PriceValue.color = (Color)(&obj);
			Sprite sprite = SpriteManager.GetSprite("MoneyPile", "UI");
			_MoneyImage.sprite = sprite;
			frameImage = _FrameImage;
			ignoreExtension = true;
			textureName = "UI";
			spriteName = "frameB9";
		}
		else
		{
			PriceValue.color = (Color)(&obj);
			Sprite sprite2 = SpriteManager.GetSprite("MoneyPile_ADV", "UI");
			_MoneyImage.sprite = sprite2;
			frameImage = _FrameImage;
			ignoreExtension = true;
			textureName = "UI";
			spriteName = "frameB9_ADV";
		}
		Sprite sprite3 = SpriteManager.GetSprite(spriteName, textureName, ignoreExtension);
		frameImage.sprite = sprite3;
	}

	public CoinsUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
