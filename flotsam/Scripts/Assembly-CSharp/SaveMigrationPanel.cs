using TMPro;
using UnityEngine;

public class SaveMigrationPanel : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _saveThatRequireMigration;

	[SerializeField]
	private TextMeshProUGUI _savesThatMigrated;

	private void OnEnable()
	{
		_saveThatRequireMigration.text = $"Found <b>{SaveFileMigration.ReturnSaveRequiredMigrationAmount()}</b> saves that require migration.";
	}

	public void Migrate()
	{
		int num = SaveFileMigration.ReturnSaveRequiredMigrationAmount();
		int num2 = SaveFileMigration.MigrateFiles();
		string text = ((num2 < num) ? $"Uh-oh, something went wrong. We managed to migrate <b>{num2.ToString()}/{num.ToString()}</b> saves. Other saves may have duplicate or invalid names." : $"Succesfully migrated <b>{num2.ToString()}/{num.ToString()}</b> saves!");
		_savesThatMigrated.text = text;
	}

	public void ShowSaveExplorer()
	{
		Extensions.ShowExplorer(SaveInfo.PLAYER_SAVES_DIRECTORY);
	}
}
