using Data;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeMode
{
	public class CreatingItemButtonUI : MonoBehaviour
	{
		[SerializeField]
		private ItemsForCreativeModeSO itemSO;

		[SerializeField]
		private Image image;

		[SerializeField]
		private Image imageLock;

		private Button button;

		private bool buttonActive;

		private void Awake()
		{
			button = base.transform.GetComponent<Button>();
			button.onClick.AddListener(CreateItem);
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.OpenedLevels.Contains(itemSO.Level))
			{
				buttonActive = true;
			}
			if (image != null && itemSO.sprite != null)
			{
				image.sprite = itemSO.sprite;
			}
			if (buttonActive)
			{
				imageLock.gameObject.SetActive(value: false);
			}
		}

		private void OnDestroy()
		{
			button.onClick.RemoveAllListeners();
		}

		public void CreateItem()
		{
			if (itemSO == null)
			{
				Debug.Log("Нет Scriptable Object у кнопки!");
			}
			else if (buttonActive)
			{
				ItemCreatingSystem.Instance.CreateItem(itemSO.Level, itemSO.guid);
			}
		}
	}
}
