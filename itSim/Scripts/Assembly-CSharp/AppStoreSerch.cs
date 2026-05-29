using TMPro;
using UnityEngine;

public class AppStoreSerch : MonoBehaviour
{
	[Header("Component")]
	public AppStoreBase appStoreBase;

	public AppStore appStore;

	[Header("UI")]
	public TMP_InputField SerchField;

	public RectTransform noResultsText;

	[Header("Apps")]
	public RectTransform AppPrefab;

	public Transform AppParent;

	[Header("Star Icons")]
	public Sprite starOutlineTexture;

	public Sprite starFilledTexture;

	public Sprite star075Texture;

	public Sprite star050Texture;

	public Sprite star025Texture;

	public void Serch()
	{
	}

	public void SerchNotEnter()
	{
	}

	public void RunSerch()
	{
	}

	public AppStoreBaseData[] Search(string text)
	{
		return null;
	}
}
