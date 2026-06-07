using DG.Tweening;
using NewGameplayScripts;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlantButtonUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Image image;

	[SerializeField]
	private Button button;

	[SerializeField]
	private TextMeshProUGUI quantityText;

	private ObjectSO objectSO;

	private int ID;

	private string GUID;

	public static PlantButtonUI Create(Transform plantButtonTemplate, ObjectSO objeсtSO, string GUID)
	{
		Transform newPlantButton = Object.Instantiate(plantButtonTemplate, plantButtonTemplate.parent);
		newPlantButton.gameObject.SetActive(value: true);
		PlantButtonUI component = newPlantButton.GetComponent<PlantButtonUI>();
		component.objectSO = objeсtSO;
		component.image.sprite = component.GetSprite(GUID);
		component.GUID = GUID;
		newPlantButton.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		newPlantButton.DOScale(1.1f, 0.1f).SetEase(Ease.InOutSine).OnComplete(delegate
		{
			newPlantButton.DOScale(1f, 0.2f).SetEase(Ease.InOutSine);
		});
		return component;
	}

	private Sprite GetSprite(string GUID)
	{
		Sprite result = null;
		if (objectSO.variantsList.Count > 0)
		{
			foreach (Variant variants in objectSO.variantsList)
			{
				if (GUID == variants.GUID)
				{
					result = variants.variantSprite;
					break;
				}
			}
		}
		else
		{
			result = objectSO.journalSprite;
		}
		return result;
	}

	private void OnDestroy()
	{
		button.onClick.RemoveAllListeners();
	}

	public ObjectSO GetObjectSO()
	{
		return objectSO;
	}

	public int GetID()
	{
		return ID;
	}

	public string GetGUID()
	{
		return GUID;
	}

	public void DeleteButton()
	{
		ProgressManager.Instance.GetPlantsOnPanel().Remove(GUID);
		DestroySelf();
	}

	private void DestroySelf()
	{
		Object.Destroy(base.gameObject);
	}

	public void OnClick()
	{
		PlantCreatingSystem.Instance.CreatePlant(objectSO, GUID);
		base.transform.DOScale(0.8f, 0.05f).OnComplete(delegate
		{
			base.transform.DOScale(1.2f, 0.1f).OnComplete(delegate
			{
				base.transform.DOScale(1f, 0.1f);
			});
		});
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Select();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Deselect();
	}

	public void Select()
	{
		float num = 1.15f;
		image.transform.DOScale(new Vector3(num, num, num), 0.35f);
	}

	public void Deselect()
	{
		image.transform.DOComplete();
		image.transform.localScale = Vector3.one;
	}

	private void CardTilt()
	{
		float num = Mathf.Sin(Time.time);
		float num2 = Mathf.Cos(Time.time);
		_ = base.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float num3 = 0f;
		float num4 = 0f;
		float b = 0f;
		float x = Mathf.LerpAngle(image.transform.eulerAngles.x, num3 + num * 20f, 10f * Time.deltaTime);
		float y = Mathf.LerpAngle(image.transform.eulerAngles.y, num4 + num2 * 20f, 10f * Time.deltaTime);
		float z = Mathf.LerpAngle(image.transform.eulerAngles.z, b, 5f * Time.deltaTime);
		image.transform.eulerAngles = new Vector3(x, y, z);
	}
}
