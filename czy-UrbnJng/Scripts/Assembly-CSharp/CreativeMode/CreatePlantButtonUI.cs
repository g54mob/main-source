using NewGameplayScripts;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeMode
{
	public class CreatePlantButtonUI : MonoBehaviour
	{
		[SerializeField]
		private Image buttonImage;

		[SerializeField]
		private Image lockImage;

		private Button button;

		private ObjectSO objectSO;

		private int variantNumber;

		private string guid;

		public void CreateButton(ObjectSO objectSo, int variant)
		{
			objectSO = objectSo;
			variantNumber = variant;
			button = base.transform.GetComponent<Button>();
			if (objectSO == null)
			{
				Debug.Log("Нет Scriptable Object у кнопки!");
				return;
			}
			guid = ((objectSO.variantsList.Count == 0) ? objectSO.GUID : objectSO.variantsList[variantNumber].GUID);
			buttonImage.sprite = objectSO.variantsList[variantNumber].variantSprite;
			if (CollectionManager.Instance.GetCollectedPlantsList().ContainsKey(objectSO.variantsList[variantNumber].GUID))
			{
				button.onClick.AddListener(CreatePlant);
			}
			else
			{
				lockImage.gameObject.SetActive(value: true);
			}
		}

		private void OnDestroy()
		{
			if (button != null)
			{
				button.onClick.RemoveAllListeners();
			}
		}

		private void CreatePlant()
		{
			if (objectSO == null)
			{
				Debug.Log("Нет Scriptable Object у кнопки!");
			}
			else
			{
				PlantCreatingSystem.Instance.CreatePlant(objectSO, guid);
			}
		}
	}
}
