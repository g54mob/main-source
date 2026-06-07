using System.Numerics;
using Assets.Behaviour.UI;
using Assets.Source.Item;
using Assets.Source.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICraftedItem : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _text;

	[SerializeField]
	private Image _icon;

	public void SetItem(ItemType type, BigInteger count)
	{
		_text.text = "+" + GameMath.FormatNumber(count);
		_icon.sprite = type.Icon;
		if (type == ItemType.GlitchedWidget)
		{
			base.gameObject.AddComponent<GlitchedIcon>().SetWidget(v: true);
		}
	}
}
