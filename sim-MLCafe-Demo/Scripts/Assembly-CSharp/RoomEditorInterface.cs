using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomEditorInterface : MonoBehaviour
{
	[SerializeField]
	private GameObject roomButtonPrefab;

	[SerializeField]
	private RectTransform buttonContent;

	[SerializeField]
	private GridLayoutGroup gridLayoutGroup;

	private Vector2Int size;

	private List<RoomButton> roomButtons;

	[SerializeField]
	private Image roomPlan;

	[SerializeField]
	[Range(1f, 8f)]
	private int resolution = 1;

	private Texture2D cafeAreaMask;

	private Texture2D staffAreaMask;

	[SerializeField]
	private TMP_Text labelRoomExtensions;

	[SerializeField]
	private TMP_Text labelMaxCafeCapacity;

	private bool loadGameData;

	private bool buttonsCreated;

	private void Awake()
	{
		ShopBuilder.OnUpdateRoomExtensions.AddListener(delegate
		{
			UpdateStats();
		});
		CustomerManager.OnUpdateMaxCustomerCapacity.AddListener(delegate
		{
			UpdateStats();
		});
	}

	private void Start()
	{
		if (!loadGameData)
		{
			Init();
		}
	}

	private void Init()
	{
		CreateInterface();
		InitInterface();
		ShopBuilder.OnUpdateRoomExtensions.AddListener(delegate
		{
			ReloadInterface();
		});
	}

	private void CreateInterface()
	{
		if (buttonsCreated)
		{
			return;
		}
		size = ShopBuilder.GetMaxSize();
		gridLayoutGroup.constraintCount = size.x;
		roomButtons = new List<RoomButton>();
		int num = 0;
		for (int i = 0; i < size.y; i++)
		{
			for (int j = 0; j < size.x; j++)
			{
				RoomButton component = Object.Instantiate(roomButtonPrefab, buttonContent).GetComponent<RoomButton>();
				Vector2Int position = new Vector2Int(j, i);
				component.Init(position);
				roomButtons.Add(component);
				num++;
			}
		}
		buttonsCreated = true;
	}

	private void InitInterface()
	{
		UpdateRoomState();
		if (ShopBuilder.GetAvailableExtensionsCount() > 0)
		{
			return;
		}
		foreach (RoomButton roomButton in roomButtons)
		{
			roomButton.gameObject.SetActive(value: false);
		}
	}

	private void ReloadInterface()
	{
		if (ShopBuilder.GetAvailableExtensionsCount() <= 0)
		{
			foreach (RoomButton roomButton in roomButtons)
			{
				roomButton.gameObject.SetActive(value: false);
			}
			cafeAreaMask = UpdateBitMask(cafeAreaMask, "_CafeAreaMask", RoomComponent.RoomType.CafeArea);
			staffAreaMask = UpdateBitMask(staffAreaMask, "_StaffAreaMask", RoomComponent.RoomType.StaffArea);
		}
		else
		{
			UpdateRoomState();
		}
	}

	private void UpdateStats()
	{
		labelRoomExtensions.text = ShopBuilder.GetAvailableExtensionsCount().ToString();
		labelMaxCafeCapacity.text = CustomerManager.GetMaxCapacity().ToString();
	}

	public void UpdateRoomState()
	{
		if (!buttonsCreated)
		{
			CreateInterface();
		}
		if (roomButtons == null || roomButtons.Equals(null) || roomButtons.Count == 0)
		{
			return;
		}
		if (roomButtons[0].Equals(null))
		{
			Debug.LogError("Room Buttons Are NULL AGAIN!!");
			return;
		}
		for (int i = 0; i < roomButtons.Count; i++)
		{
			RoomButton roomButton = roomButtons[i];
			roomButton.gameObject.SetActive(value: true);
			if (!roomButton.unlocked)
			{
				if (ShopBuilder.Exists(roomButton.GetPosition()))
				{
					roomButton.UpdateLockState(isUnlocked: true, isNeighbour: false);
					continue;
				}
				bool isNeighbour = ShopBuilder.IsNeighbourOfExisting(roomButton.GetNeighbourPositions());
				roomButton.UpdateLockState(isUnlocked: false, isNeighbour);
			}
		}
		cafeAreaMask = UpdateBitMask(cafeAreaMask, "_CafeAreaMask", RoomComponent.RoomType.CafeArea);
		staffAreaMask = UpdateBitMask(staffAreaMask, "_StaffAreaMask", RoomComponent.RoomType.StaffArea);
	}

	private Texture2D UpdateBitMask(Texture2D mask, string materialParameter, RoomComponent.RoomType area)
	{
		if (mask == null || mask.width < 1 || mask.height < 1)
		{
			mask = CreateBitmask();
		}
		for (int i = 0; i < roomButtons.Count; i++)
		{
			for (int j = 0; j < resolution; j++)
			{
				for (int k = 0; k < resolution; k++)
				{
					int x = 2 + k + roomButtons[i].GetPosition().x * resolution;
					int y = 2 + j + roomButtons[i].GetPosition().y * resolution;
					Color color = Color.black;
					if (!roomButtons[i].unlocked)
					{
						mask.SetPixel(x, y, color);
						continue;
					}
					if (ShopBuilder.Exists(roomButtons[i].GetPosition()) && ShopBuilder.GetRoomType(roomButtons[i].GetPosition()) == area)
					{
						color = Color.white;
					}
					mask.SetPixel(x, y, color);
				}
			}
		}
		mask.Apply();
		roomPlan.material.SetTexture(materialParameter, mask);
		return mask;
	}

	private Texture2D CreateBitmask()
	{
		Texture2D texture2D = new Texture2D(size.x * resolution + 4, size.y * resolution + 4);
		for (int i = 0; i < texture2D.width; i++)
		{
			for (int j = 0; j < texture2D.height; j++)
			{
				texture2D.SetPixel(i, j, Color.black);
			}
		}
		texture2D.Apply();
		return texture2D;
	}
}
