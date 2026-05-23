using System.IO;
using Data.Operator;
using Events.FactoryFloor;
using Logic.Factory.Blueprint;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaceFactoryBlueprintButtonUI : MonoBehaviour
{
	[SerializeField]
	private Button _placeBlueprintBtn;

	[SerializeField]
	private TextMeshProUGUI _blueprintName;

	[SerializeField]
	private FactoryObjectDatabase _factoryObjectDatabase;

	[SerializeField]
	private BlueprintDtoEvent _placeBlueprintToolEvent;

	[Space]
	[SerializeField]
	private Button _deleteBtn;

	private string _blueprintFilePath;

	private BlueprintDto _blueprintDto;

	public void Setup(BlueprintDto blueprintDto, string filePath, bool enableBtn = true)
	{
		_blueprintFilePath = filePath;
		_blueprintDto = blueprintDto;
		_blueprintName.SetText(Path.GetFileNameWithoutExtension(filePath));
		if (enableBtn)
		{
			base.gameObject.SetActive(value: true);
		}
	}

	private void OnEnable()
	{
		_deleteBtn.onClick.AddListener(DeleteBlueprint);
		_placeBlueprintBtn.onClick.AddListener(PlaceBlueprint);
	}

	private void OnDisable()
	{
		_deleteBtn.onClick.RemoveListener(DeleteBlueprint);
		_placeBlueprintBtn.onClick.RemoveListener(PlaceBlueprint);
	}

	private void PlaceBlueprint()
	{
		_placeBlueprintToolEvent.Fire(_blueprintDto);
	}

	private void DeleteBlueprint()
	{
		SaveSystem.DeleteFile(_blueprintFilePath);
		if (SaveSystem.DoesFileExist(_blueprintFilePath + ".meta"))
		{
			SaveSystem.DeleteFile(_blueprintFilePath + ".meta");
		}
		SaveSystem.DeleteFile(_blueprintFilePath);
		base.gameObject.SetActive(value: false);
	}
}
