using System;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace VampireSurvivors.UI;

public class ForceParseEscapeCharacters : MonoBehaviour
{
	private TextMeshProUGUI _tmp;

	private Localize _localize;

	private void Awake()
	{
		TextMeshProUGUI tmp = _tmp;
		if ((object)_tmp == null || ((UnityEngine.Object)tmp).m_CachedPtr == (IntPtr)0)
		{
			TextMeshProUGUI component = GetComponent<TextMeshProUGUI>();
			_tmp = component;
		}
		Localize localize = _localize;
		if ((object)_localize == null || ((UnityEngine.Object)localize).m_CachedPtr == (IntPtr)0)
		{
			Localize component2 = GetComponent<Localize>();
			_localize = component2;
		}
		Localize localize2 = _localize;
		if ((object)_localize != null && ((UnityEngine.Object)localize2).m_CachedPtr != (IntPtr)0)
		{
			Localize localize3 = _localize;
			UnityAction call = Parse;
			localize3.LocalizeEvent.AddListener(call);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 468 Invalid \"Jump target not found in method: 0x186CC7E20\"");
		throw new NullReferenceException();
	}

	private void Start()
	{
		Parse();
	}

	private void OnEnable()
	{
		Parse();
	}

	public void Parse()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A31A3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		while (true)
		{
			string text = _tmp.text;
			string text2 = text.Replace("\\n", "<br>");
			_tmp.text = text2;
			string text3 = _tmp.text;
			string text4 = text3.Replace("\n", "<br>");
			_tmp.text = text4;
			string text5 = _tmp.text;
			if (!text5.Contains("\\n"))
			{
				string text6 = _tmp.text;
				if (!text6.Contains("\n"))
				{
					break;
				}
			}
		}
	}

	public ForceParseEscapeCharacters()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
