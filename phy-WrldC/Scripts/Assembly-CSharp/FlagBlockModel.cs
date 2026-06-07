using UnityEngine;

public class FlagBlockModel : ComponentModel
{
	public const string FlagPaint = "flag_paint";

	public const string FlagColor = "flag_color";

	public FlagBlockModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		ComboBoxPropertyModel flagPaintComboBox = base.ParentBlockBodyModel.AddOverridableProperty(new ComboBoxPropertyModel("flag_paint", "00_white")
		{
			IsUsingIcons = true
		});
		SetFlagLabels(flagPaintComboBox);
		LanguagesManager.Instance.OnLanguageChangedEvent += delegate
		{
			SetFlagLabels(flagPaintComboBox);
		};
		base.ParentBlockBodyModel.AddOverridableProperty(new ColorPickerPropertyModel("flag_color", "#FFFFFF"));
	}

	private void SetFlagLabels(ComboBoxPropertyModel flagPaintComboBox)
	{
		flagPaintComboBox.Clear();
		string[] allKeys = GameManager.Instance.FlagTextureCollection.GetAllKeys();
		foreach (string text in allKeys)
		{
			string text2 = LanguagesManager.Instance.GetText("flag." + text, text);
			Sprite sprite = GameManager.Instance.FlagTextureCollection.GetSprite(text);
			flagPaintComboBox.AddItem(text, text2, sprite);
		}
	}
}
