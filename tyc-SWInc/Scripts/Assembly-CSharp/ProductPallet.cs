using System;
using System.Collections.Generic;
using UnityEngine;

public class ProductPallet : Writeable, IManufacturingConverter
{
	public float[] BoxCutoff;

	public int MaxOrders = 27;

	[NonSerialized]
	public ProductPrintOrder[] Orders;

	public Renderer Boxes;

	public int CurrentAmount;

	public MaterialPropertyBlock MatBlock;

	public Furniture Furn;

	public bool StaticBox = true;

	public TiledBox DynamicBox;

	private bool _canFetch = true;

	public Transform[] ConnectSpots;

	public GameObject[] ConnectMesh;

	private bool _dump;

	public bool BeingFetched;

	private float _wait;

	public bool CanFetch
	{
		get
		{
			return _canFetch;
		}
		set
		{
			_canFetch = value;
			if (_canFetch)
			{
				HUD.Instance.FetchBlocked.Remove(this);
			}
			else
			{
				HUD.Instance.FetchBlocked.Add(this);
			}
		}
	}

	private void Awake()
	{
		if (Orders == null)
		{
			Orders = new ProductPrintOrder[(!StaticBox) ? 1 : MaxOrders];
		}
		MatBlock = new MaterialPropertyBlock();
		RefreshBoxes();
	}

	public void FixReferences()
	{
		Orders.FixMyReferences();
		if (StaticBox)
		{
			for (int i = 0; i < Orders.Length; i++)
			{
				if (Orders[i] != null)
				{
					continue;
				}
				bool flag = false;
				for (int j = i + 1; j < Orders.Length; j++)
				{
					if (Orders[j] != null)
					{
						Orders[i] = Orders[j];
						Orders[j] = null;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			CurrentAmount = 0;
			for (int num = Orders.Length - 1; num >= 0; num--)
			{
				if (Orders[num] != null)
				{
					CurrentAmount = num + 1;
					break;
				}
			}
		}
		else if (Orders[0] == null)
		{
			CurrentAmount = 0;
		}
		RefreshBoxes();
	}

	private void Start()
	{
		if (GameSettings.Instance.IsReferenceNull() || Furn.Map != null)
		{
			return;
		}
		lock (GameSettings.Instance.ProductPallets)
		{
			GameSettings.Instance.ProductPallets.Add(this);
		}
		if (!Deserialized)
		{
			DID = Furn.DID;
			TutorialSystem.Instance.StartTutorial("Physical distribution");
			if (!StaticBox)
			{
				CheckBlocked();
			}
		}
	}

	public void CheckBlocked()
	{
		int num = Furn.Floor + 1;
		bool flag = true;
		Vector2 vector = base.transform.position.FlattenVector3();
		if (num == 0)
		{
			for (int i = 0; i < RoadManager.Floors; i++)
			{
				if (RoadManager.Instance.GetRoad(vector, i) > 0)
				{
					flag = false;
					break;
				}
			}
		}
		if (flag)
		{
			for (int j = num + 1; j < GameSettings.MaxFloor; j++)
			{
				if (GameSettings.Instance.sRoomManager.GetRoomFromPoint(j, vector) != null)
				{
					flag = false;
					break;
				}
			}
		}
		CanFetch = flag;
	}

	public void AddOrder(ProductPrintOrder order, bool threaded = false)
	{
		lock (this)
		{
			if (_dump)
			{
				order.RemoveFromStorage();
				return;
			}
			if (StaticBox)
			{
				Orders[CurrentAmount] = order;
			}
			else
			{
				if (Orders[0] == null)
				{
					Orders[0] = order;
				}
				else
				{
					Orders[0].MergeWith(order);
				}
				_wait = 0f;
			}
			CurrentAmount++;
			if (threaded)
			{
				GameSettings.Instance.BoxController.UpdatePallet.AddThreaded(Furn);
			}
			else
			{
				RefreshBoxes();
			}
			if (!StaticBox && !BeingFetched && CanFetch && CurrentAmount >= MaxOrders)
			{
				GameSettings.Instance.BoxController.SendHelicopter(this);
			}
		}
	}

	public void SendNow()
	{
		if (!StaticBox && !BeingFetched && CanFetch && CurrentAmount > 0)
		{
			GameSettings.Instance.BoxController.SendHelicopter(this);
			_wait = 0f;
		}
	}

	public void RefreshBoxes()
	{
		bool flag = GameSettings.Instance.BoxController.Highlight != null && Orders.Any((ProductPrintOrder x) => x != null && x.Stockables.Any((IStockable z) => z == GameSettings.Instance.BoxController.Highlight));
		if (StaticBox)
		{
			MatBlock.SetFloat("_CutOff", BoxCutoff[CurrentAmount]);
			MatBlock.SetFloat("_Highlight", flag ? 1 : 0);
			Boxes.SetPropertyBlock(MatBlock);
			return;
		}
		if (CurrentAmount == 0)
		{
			if (DynamicBox != null)
			{
				GameSettings.Instance.BoxController.ReleaseBox(DynamicBox);
				DynamicBox = null;
			}
			return;
		}
		if (DynamicBox == null)
		{
			DynamicBox = GameSettings.Instance.BoxController.GetBox();
			DynamicBox.transform.SetParent(Furn.OnRoofObject.transform);
			DynamicBox.transform.localPosition = Vector3.zero;
			DynamicBox.transform.localRotation = Quaternion.identity;
		}
		DynamicBox.SetBoxes(CurrentAmount, flag);
	}

	public void RefreshReach()
	{
		if (Furn.Conveyor.HasAnyOutput())
		{
			Furn.InteractionPoints.ForEachEnum(delegate(InteractionPoint x)
			{
				x.NeedsReachCheck = false;
			});
			if (HUD.Instance.UnreachableFuniture.Contains(Furn))
			{
				Furn.UpdateFreeNavs();
			}
		}
		else
		{
			Furn.InteractionPoints.ForEachEnum(delegate(InteractionPoint x)
			{
				x.NeedsReachCheck = true;
			});
			Furn.UpdateFreeNavs();
		}
	}

	public void FixStorage()
	{
		for (int i = 0; i < Orders.Length; i++)
		{
			ProductPrintOrder obj = Orders[i];
			if (obj != null)
			{
				obj.AddToStorage();
			}
		}
	}

	public bool CanTakeOrder()
	{
		return CurrentAmount < MaxOrders;
	}

	public void Tick(float delta)
	{
		if (StaticBox)
		{
			if (CurrentAmount <= 0)
			{
				return;
			}
			Conveyor conveyor = Furn.Conveyor;
			for (int i = 0; i < conveyor.OutputLength; i++)
			{
				Conveyor output = conveyor.GetOutput(i);
				if (!(output != null) || !output.IsEmpty())
				{
					continue;
				}
				Conveyor output2 = output.GetOutput(0);
				if (output2 != null && output2.IsEmpty() && output2.CanTake())
				{
					int boxes;
					ProductPrintOrder order = Take(out boxes, 1, true);
					if (boxes > 0)
					{
						GameSettings.Instance.BoxController.CreateBox(order, output, 0);
					}
				}
			}
		}
		else if (_wait < 81f * (float)GameSettings.DaysPerMonth)
		{
			if (CurrentAmount > 0)
			{
				_wait += delta;
			}
		}
		else if (CanFetch && !BeingFetched && CurrentAmount > 0)
		{
			GameSettings.Instance.BoxController.SendHelicopter(this);
			_wait = 0f;
		}
	}

	public ProductPrintOrder Take(out int boxes, int max, bool threaded = false)
	{
		ProductPrintOrder result = null;
		lock (this)
		{
			if (StaticBox)
			{
				int num = Mathf.Min(max, CurrentAmount);
				List<ProductPrintOrder> list = null;
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					if (CurrentAmount <= 0)
					{
						break;
					}
					ProductPrintOrder productPrintOrder = Orders[CurrentAmount - 1];
					if (productPrintOrder != null)
					{
						if (list == null)
						{
							list = new List<ProductPrintOrder>();
						}
						list.Add(productPrintOrder);
						Orders[CurrentAmount - 1] = null;
						CurrentAmount--;
						num2++;
					}
					else
					{
						CurrentAmount--;
						i--;
					}
				}
				boxes = num2;
				if (boxes > 0)
				{
					result = ProductPrintOrder.Merge(list);
				}
			}
			else if (Orders[0] != null)
			{
				boxes = 1;
				CurrentAmount = 0;
				result = Orders[0];
				Orders[0] = null;
			}
			else
			{
				boxes = 0;
			}
		}
		if (threaded)
		{
			GameSettings.Instance.BoxController.UpdatePallet.AddThreaded(Furn);
		}
		else
		{
			RefreshBoxes();
		}
		return result;
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		Orders = dictionary.Get<ProductPrintOrder[]>("PalletOrders2", null) ?? new ProductPrintOrder[MaxOrders];
		CurrentAmount = Orders.Count((ProductPrintOrder x) => x != null);
		if (!StaticBox)
		{
			CurrentAmount = dictionary.Get("CurrentAmount", CurrentAmount);
			_wait = dictionary.Get("Wait", _wait);
			if (loading)
			{
				BeingFetched = dictionary.Get("BeingFetched", BeingFetched);
			}
		}
		RefreshBoxes();
		return this;
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		dictionary["PalletOrders2"] = Orders;
		if (!StaticBox)
		{
			dictionary["CurrentAmount"] = CurrentAmount;
			dictionary["Wait"] = _wait;
			dictionary["BeingFetched"] = BeingFetched;
		}
	}

	private void OnDestroy()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			lock (GameSettings.Instance.ProductPallets)
			{
				GameSettings.Instance.ProductPallets.Remove(this);
			}
			for (int i = 0; i < Orders.Length; i++)
			{
				ProductPrintOrder productPrintOrder = Orders[i];
				if (productPrintOrder != null)
				{
					productPrintOrder.RemoveFromStorage();
				}
			}
		}
		if (HUD.Instance != null)
		{
			HUD.Instance.FetchBlocked.Remove(this);
		}
	}

	protected override bool WriteDID()
	{
		return false;
	}

	public bool TakeOrder(TransportBox box)
	{
		ProductPrintOrder order;
		if ((order = box.Order as ProductPrintOrder) != null && CanTakeOrder())
		{
			AddOrder(order, true);
			return true;
		}
		return false;
	}
}
