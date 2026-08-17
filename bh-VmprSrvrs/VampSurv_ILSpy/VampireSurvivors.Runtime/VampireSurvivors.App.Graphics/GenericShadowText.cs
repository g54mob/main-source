using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace VampireSurvivors.App.Graphics;

public class GenericShadowText : MonoBehaviour
{
	private TextMeshPro _Text;

	private TextMeshPro _ShadowText;

	public TextMeshPro Text => _Text;

	public TextMeshPro ShadowText => _ShadowText;

	public void SetText(string text)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	public void SetShadowEnabled(bool value)
	{
		GameObject gameObject = _ShadowText.gameObject;
		gameObject.SetActive(value);
	}

	public unsafe void SetTextColor(Color col)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		_Text.color = (Color)(&obj);
	}

	public unsafe void SetShadowColor(Color col)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		_ShadowText.color = (Color)(&obj);
	}

	public void ForceTextUpdates()
	{
		_Text.ForceMeshUpdate();
		_ShadowText.ForceMeshUpdate();
	}

	public void SetDepth(int depth)
	{
		_Text.sortingOrder = depth;
		int sortingOrder = depth - 1;
		_ShadowText.sortingOrder = sortingOrder;
	}

	public unsafe void SetAlpha(float alpha)
	{
		//IL_0023: Expected O, but got Ref
		//IL_0046: Expected O, but got Ref
		Color color = _Text.color;
		object obj = default(object);
		_Text.color = (Color)(&obj);
		Color color2 = _ShadowText.color;
		_ShadowText.color = (Color)(&obj);
	}

	public GenericShadowText()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
