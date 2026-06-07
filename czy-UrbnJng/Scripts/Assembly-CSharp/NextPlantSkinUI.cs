using System;
using UnityEngine;
using UnityEngine.UI;

public class NextPlantSkinUI : MonoBehaviour
{
	public class OnSkinChosenEventArgs : EventArgs
	{
		public NextPlantSkinUI chosenSkin;
	}

	[SerializeField]
	private Image skinImage;

	[SerializeField]
	private Transform outline;

	[SerializeField]
	private Button skinButton;

	private string GUID;

	private int price;

	private bool isUnlocked;

	private Sprite sprite;

	private Sprite spriteBW;

	private int size;

	public event EventHandler<OnSkinChosenEventArgs> OnSkinChosen;

	public static NextPlantSkinUI Create(ObjectSO objectSO, string variantGUID, Sprite variantSprite, Sprite variantSpriteBW, Vector2Int size, Transform skinTemplate, NextPlantUI nextPlantUI)
	{
		Transform transform = UnityEngine.Object.Instantiate(skinTemplate, skinTemplate.parent);
		NextPlantSkinUI nextPlantSkinUI = transform.GetComponent<NextPlantSkinUI>();
		transform.gameObject.SetActive(value: true);
		nextPlantSkinUI.sprite = variantSprite;
		nextPlantSkinUI.spriteBW = variantSpriteBW;
		nextPlantSkinUI.skinImage.sprite = nextPlantSkinUI.sprite;
		nextPlantSkinUI.GUID = variantGUID;
		nextPlantSkinUI.size = size.x;
		nextPlantSkinUI.price = CollectionManager.Instance.GetPrice(objectSO, variantGUID);
		nextPlantSkinUI.isUnlocked = true;
		nextPlantSkinUI.skinButton.onClick.AddListener(delegate
		{
			nextPlantSkinUI.OnSkinButtonClick();
		});
		return nextPlantSkinUI;
	}

	private void OnSkinButtonClick()
	{
		this.OnSkinChosen?.Invoke(this, new OnSkinChosenEventArgs
		{
			chosenSkin = this
		});
	}

	public void HidePrice()
	{
	}

	private void OnDestroy()
	{
		skinButton.onClick.RemoveAllListeners();
	}

	public string GetGUID()
	{
		return GUID;
	}

	public Sprite GetSkinSprite()
	{
		return sprite;
	}

	public int GetSkinPrice()
	{
		return price;
	}

	public bool IsUnlocked()
	{
		return isUnlocked;
	}

	public int GetSize()
	{
		return size;
	}

	public void Unlock()
	{
		isUnlocked = true;
		ReturnImageColor();
	}

	private void ReturnImageColor()
	{
		skinImage.sprite = sprite;
	}

	public void ToggleOutline(bool value)
	{
		outline.gameObject.SetActive(value);
	}
}
