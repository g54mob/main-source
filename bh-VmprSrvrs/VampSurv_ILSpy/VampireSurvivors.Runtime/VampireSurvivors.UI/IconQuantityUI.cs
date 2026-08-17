using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class IconQuantityUI : MonoBehaviour
{
	private TextMeshProUGUI _QuantityText;

	private Image _Icon;

	private Image _Frame;

	public void SetQuantity(string i)
	{
		_QuantityText.text = i;
	}

	public void SetQuantity(int i)
	{
		int num = default(int);
		string text = num.ToString();
		_QuantityText.text = text;
	}

	public void SetIcon(Sprite sprite)
	{
		_Icon.sprite = sprite;
	}

	public unsafe void SetTextColor(Color c)
	{
		//IL_000f: Expected O, but got Ref
		object obj = default(object);
		_QuantityText.color = (Color)(&obj);
	}

	public void SetFrame(Sprite s)
	{
		_Frame.sprite = s;
		_Frame.enabled = true;
	}

	public IconQuantityUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
