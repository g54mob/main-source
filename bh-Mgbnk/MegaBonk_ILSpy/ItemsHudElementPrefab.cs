using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemsHudElementPrefab : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_amount;

	public void Set(ItemData itemData)
	{
		Texture texture = itemData.GetIcon();
		icon.texture = texture;
	}

	public void SetAmount(int amount)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F4A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		int num = default(int);
		if (num > 1)
		{
			int num2 = default(int);
			string text = num2.ToString();
			string text2 = "x" + text;
			t_amount.text = text2;
		}
		else
		{
			t_amount.text = "";
		}
	}
}
