using System;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.UI;

public class AdventureStarsCurrencyUI : MonoBehaviour
{
	private TextMeshProUGUI _StarsCurrencyText;

	private PlayerOptions _playerOptions;

	private void Construct(PlayerOptions playerOptions)
	{
		_playerOptions = playerOptions;
	}

	private void Awake()
	{
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	private void Start()
	{
		//IL_0062: Expected I, but got O
		//IL_0119: Expected O, but got I
		PlayerOptions.OnValueChanged b = UpdateStarsText;
		Delegate obj = PlayerOptions.AdventureStarsUpdated;
		while (true)
		{
			Delegate obj2 = Delegate.Combine(obj, b);
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
					break;
				}
			}
			nint num = (nint)typeof(PlayerOptions);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+B8]");
			object obj4 = (nint)0 + (nint)8;
			bool flag3 = obj == obj4;
			Delegate obj5;
			if (obj == obj4)
			{
				obj4 = obj3;
				obj5 = obj;
			}
			else
			{
				obj5 = (Delegate)obj4;
			}
			Delegate obj6 = obj;
			if (!flag3)
			{
				obj6 = obj5;
			}
			bool flag4 = (object)obj6 != obj;
			obj = obj6;
			if (!flag4)
			{
				UpdateStarsText();
				return;
			}
		}
		throw new InvalidCastException();
	}

	private void OnEnable()
	{
		UpdateStarsText();
	}

	private void OnDestroy()
	{
		//IL_0062: Expected I, but got O
		//IL_0113: Expected O, but got I
		PlayerOptions.OnValueChanged value = UpdateStarsText;
		Delegate obj = PlayerOptions.AdventureStarsUpdated;
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
					break;
				}
			}
			nint num = (nint)typeof(PlayerOptions);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.PlayerOptions>)+B8]");
			object obj4 = (nint)0 + (nint)8;
			bool flag3 = obj == obj4;
			Delegate obj5;
			if (obj == obj4)
			{
				obj4 = obj3;
				obj5 = obj;
			}
			else
			{
				obj5 = (Delegate)obj4;
			}
			Delegate obj6 = obj;
			if (!flag3)
			{
				obj6 = obj5;
			}
			bool flag4 = (object)obj6 != obj;
			obj = obj6;
			if (!flag4)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	private unsafe void UpdateStarsText()
	{
		//IL_00cb: Expected O, but got Ref
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		if (mainGameConfig._003CAdventureStars_003Ek__BackingField < 2.1474836E+09f && -2.1474836E+09f < mainGameConfig._003CAdventureStars_003Ek__BackingField)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,xmm0\"");
			int num = default(int);
			switch (num)
			{
			}
		}
		object obj = default(object);
		string text = System.Number.FormatInt32(9999999, (ReadOnlySpan<char>)(&obj), null);
		_StarsCurrencyText.text = text;
	}

	public AdventureStarsCurrencyUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
