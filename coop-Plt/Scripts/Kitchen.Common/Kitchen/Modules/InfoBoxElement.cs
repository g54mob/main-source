using KitchenData;
using TMPro;
using UnityEngine;

namespace Kitchen.Modules
{
	public class InfoBoxElement : LabelElement
	{
		public new InfoBoxElement SetStyle(ElementStyle style)
		{
			TextMeshPro label = Label;
			TMP_FontAsset font = ((style != ElementStyle.MainMenu) ? GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.Default] : GameData.Main.GlobalLocalisation.Fonts[KitchenData.Font.MainMenu]);
			label.font = font;
			TextMeshPro label2 = Label;
			Color color = ((style != ElementStyle.MainMenu) ? new Color(0.34f, 0.36f, 0.42f) : new Color(0.52f, 0.5f, 0.49f));
			label2.color = color;
			return this;
		}
	}
}
