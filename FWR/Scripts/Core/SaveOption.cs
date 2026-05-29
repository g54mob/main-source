using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveOption : MonoBehaviour
{
	private const int MAX_NAME_SIZE = 20;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private TMP_InputField nameEditInput;

	private string fileName;

	private SaveChooser saveChooser;

	public void Setup(string fileName, SaveChooser saveChooser)
	{
		this.fileName = fileName;
		this.saveChooser = saveChooser;
		nameText.text = fileName;
	}

	public void Load()
	{
		saveChooser.LoadSave(fileName);
	}

	public void Delete()
	{
		saveChooser.DeleteSave(fileName);
	}

	public void Edit()
	{
		nameEditInput.gameObject.SetActive(value: true);
		nameText.gameObject.SetActive(value: false);
		nameEditInput.text = fileName;
		nameEditInput.Select();
	}

	public void EditFinished()
	{
		string text = nameEditInput.text;
		if (saveChooser.RenameSave(fileName, text))
		{
			fileName = text;
			nameText.text = text;
		}
		nameEditInput.gameObject.SetActive(value: false);
		nameText.gameObject.SetActive(value: true);
	}

	public void NameChanged()
	{
		string text = nameEditInput.text;
		if (text.Length > 20)
		{
			nameEditInput.text = text.Substring(0, 20);
		}
	}

	private void OnEnable()
	{
		ThemeManager.Inst.OnThemeChanged += OnThemeChanged;
	}

	private void OnDisable()
	{
		ThemeManager.Inst.OnThemeChanged -= OnThemeChanged;
	}

	protected virtual void OnThemeChanged(ColorTheme theme)
	{
		if (TryGetComponent<Image>(out var component))
		{
			component.color = theme.ui.OptionBackgroundColor;
		}
		nameText.color = theme.ui.OptionTextColor;
		theme.ui.text.ApplyTo(nameEditInput);
	}
}
