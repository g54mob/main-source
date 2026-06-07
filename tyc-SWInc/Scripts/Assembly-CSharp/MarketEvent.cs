using System;
using System.IO;
using System.Text;
using AltSerialize;
using UnityEngine;

public struct MarketEvent : IByteData, IAltSerializable
{
	public enum EventType
	{
		ProductRelease = 0,
		IPTrade = 1,
		BuyOut = 2,
		Founded = 3,
		Update = 4,
		Port = 5,
		PriceChange = 6,
		PublisherChange = 7,
		TechResearch = 8,
		IPO = 9,
		SoldStock = 10,
		BoughtStock = 11,
		StockDilution = 12,
		StockBuyBack = 13,
		Bankrupt = 14,
		BoughtOut = 15,
		Patent = 16,
		Subsidiary = 17,
		ProductTrade = 18
	}

	[Flags]
	public enum Filter
	{
		None = 0,
		Product = 1,
		Company = 2,
		Update = 4,
		Port = 8,
		Price = 0x10,
		Research = 0x20,
		Stock = 0x40
	}

	public static Filter AllFilters = Filter.Product | Filter.Company | Filter.Update | Filter.Port | Filter.Price | Filter.Research | Filter.Stock;

	public readonly byte TypeByte;

	public readonly ushort DateInt;

	public readonly string[] Desc;

	public readonly uint[] Subjects;

	public readonly float Value;

	public readonly float Value2;

	public EventType Type
	{
		get
		{
			return (EventType)TypeByte;
		}
	}

	public SDateTime Date
	{
		get
		{
			return ConvertDate(DateInt);
		}
	}

	public bool CanCache
	{
		get
		{
			return false;
		}
	}

	public static SDateTime ConvertDate(ushort d)
	{
		return new SDateTime(0, 0, 0, d % 12, d / 12);
	}

	public static ushort ConvertDate(SDateTime date)
	{
		return (ushort)(date.Year * 12 + date.Month);
	}

	public MarketEvent(EventType type, SDateTime date, string[] desc, uint[] subjects, float value = 0f, float value2 = 0f)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = desc;
		Subjects = subjects;
		Value = value;
		Value2 = value2;
	}

	public MarketEvent(EventType type, SDateTime date, string desc, uint subject)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = new string[1] { desc };
		Subjects = new uint[1] { subject };
		Value = 0f;
		Value2 = 0f;
	}

	public MarketEvent(EventType type, SDateTime date, params uint[] subjects)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = null;
		Subjects = subjects;
		Value = 0f;
		Value2 = 0f;
	}

	public MarketEvent(EventType type, SDateTime date, float value, params uint[] subjects)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = null;
		Subjects = subjects;
		Value = value;
		Value2 = 0f;
	}

	public MarketEvent(EventType type, SDateTime date, float value, float value2, params uint[] subjects)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = null;
		Subjects = subjects;
		Value = value;
		Value2 = value2;
	}

	public MarketEvent(EventType type, SDateTime date, params string[] desc)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = desc;
		Subjects = null;
		Value = 0f;
		Value2 = 0f;
	}

	public MarketEvent(EventType type, SDateTime date, float value, params string[] desc)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = desc;
		Subjects = null;
		Value = value;
		Value2 = 0f;
	}

	public MarketEvent(EventType type, SDateTime date)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = null;
		Subjects = null;
		Value = 0f;
		Value2 = 0f;
	}

	public MarketEvent(EventType type, SDateTime date, float value, float value2 = 0f)
	{
		TypeByte = (byte)type;
		DateInt = ConvertDate(date);
		Desc = null;
		Subjects = null;
		Value = value;
		Value2 = value2;
	}

	public bool IsValid()
	{
		switch (Type)
		{
		case EventType.ProductRelease:
		case EventType.IPTrade:
			return MarketSimulation.Active.GetProduct(Subjects[0], true, false, true) != null;
		case EventType.Port:
			return MarketSimulation.Active.GetProduct(Subjects[0], true) != null;
		case EventType.SoldStock:
		case EventType.BoughtStock:
			return MarketSimulation.Active.GetCompany(Subjects[0]) != null;
		default:
			return true;
		}
	}

	public string GetDescription()
	{
		switch (Type)
		{
		case EventType.ProductRelease:
		{
			SoftwareProduct product3 = MarketSimulation.Active.GetProduct(Subjects[0], true, false, true);
			if (product3 != null)
			{
				if (Subjects.Length > 1)
				{
					AddOnProduct addon = product3.GetAddon(Subjects[1]);
					if (addon == null)
					{
						return null;
					}
					return "MarketEventRelease".LocColorAll(addon);
				}
				return "MarketEventRelease".LocColorAll(product3);
			}
			return null;
		}
		case EventType.IPTrade:
		{
			SoftwareProduct product = MarketSimulation.Active.GetProduct(Subjects[0], true, false, true);
			if (product == null)
			{
				return null;
			}
			return "MarketEventIPTrade".LocColorAll(product, MarketSimulation.Active.GetCompany(Subjects[1]), MarketSimulation.Active.GetCompany(Subjects[2]), Value.Currency());
		}
		case EventType.BuyOut:
			return "MarketEventBuyOut".LocColorAll(Desc[0]);
		case EventType.Founded:
			return "MarketEventFounded".LocColorAll((Desc != null && Desc.Length != 0) ? ((object)Desc[0]) : ((object)MarketSimulation.Active.GetCompany(Subjects[0])));
		case EventType.Update:
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("MarketEventUpdate".Loc(Desc[0].BlueHighlight()));
			if (Subjects != null)
			{
				stringBuilder.Append(" " + "MarketEventUpdateBug".Loc(Subjects[0].ToString().BlueHighlight()));
			}
			if (Desc.Length > 1)
			{
				for (int i = 1; i < Desc.Length; i++)
				{
					if (i > 1 || Subjects != null)
					{
						if (i == Desc.Length - 1)
						{
							stringBuilder.Append("AndSeperator".Loc());
						}
						else
						{
							stringBuilder.Append(", ");
						}
					}
					else
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append((i > 1) ? Desc[i].LocTry().BlueHighlight() : "MarketEventUpdateTech".Loc(Desc[i].LocTry().BlueHighlight()));
				}
			}
			return stringBuilder.ToString().TrimEnd();
		}
		case EventType.Port:
		{
			SoftwareProduct product2 = MarketSimulation.Active.GetProduct(Subjects[0], true);
			if (product2 == null)
			{
				return null;
			}
			return "MarketEventPort".LocColor(product2);
		}
		case EventType.PriceChange:
			return "MarketEventPriceChange".LocColorAll(Value.Currency());
		case EventType.PublisherChange:
			if (!(Value < 0f))
			{
				return "MarketEventPublisherGain".LocColorAll(Desc[0]);
			}
			return "MarketEventPublisherLost".LocColorAll(Desc[0]);
		case EventType.TechResearch:
			return "MarketEventTechResearch".LocColorAll(Desc[0].LocTry() + " " + Subjects[0]);
		case EventType.IPO:
			return "MarketEventIPO".LocColorAll((1f - Value).ToPercent());
		case EventType.SoldStock:
		{
			Company company3 = MarketSimulation.Active.GetCompany(Subjects[0]);
			if (company3 != null)
			{
				return "MarketEventSoldStock".LocColorAll(company3, Value.Currency(), Value2.ToPercent());
			}
			return null;
		}
		case EventType.BoughtStock:
		{
			Company company2 = MarketSimulation.Active.GetCompany(Subjects[0]);
			if (company2 != null)
			{
				return "MarketEventBoughtStock".LocColorAll(company2, Value.Currency(), Value2.ToPercent());
			}
			return null;
		}
		case EventType.StockDilution:
			return "MarketEventStockDilution".LocColorAll((1f - Value).ToPercent());
		case EventType.StockBuyBack:
			return "MarketEventStockBuyBack".LocColorAll(Value.ToPercent());
		case EventType.Bankrupt:
			return "MarketEventBankrupt".Loc();
		case EventType.BoughtOut:
			return "MarketEventBoughtOut".LocColorAll(MarketSimulation.Active.GetCompany(Subjects[0]));
		case EventType.Patent:
			return "MarketEventPatent".LocColorAll(Desc[0].LocTry() + " " + Subjects[0]);
		case EventType.Subsidiary:
		{
			Company company = MarketSimulation.Active.GetCompany(Subjects[1]);
			if (company != null)
			{
				return "MarketEventSubsidiary".LocColorAll(Desc[0], company.Name);
			}
			return null;
		}
		case EventType.ProductTrade:
			return "MarketEventProductTrade".LocColorAll(Desc[0]);
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public Filter GetFilter()
	{
		switch (Type)
		{
		case EventType.ProductRelease:
		case EventType.IPTrade:
			return Filter.Product;
		case EventType.BuyOut:
		case EventType.Founded:
		case EventType.PublisherChange:
		case EventType.Bankrupt:
		case EventType.BoughtOut:
		case EventType.Subsidiary:
		case EventType.ProductTrade:
			return Filter.Company;
		case EventType.Update:
			return Filter.Update;
		case EventType.Port:
			return Filter.Port;
		case EventType.PriceChange:
			return Filter.Price;
		case EventType.TechResearch:
		case EventType.Patent:
			return Filter.Research;
		case EventType.IPO:
		case EventType.SoldStock:
		case EventType.BoughtStock:
		case EventType.StockDilution:
		case EventType.StockBuyBack:
			return Filter.Stock;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public bool CheckFilter(Filter f)
	{
		return f.HasFlag(GetFilter());
	}

	public Color GetColor()
	{
		switch (Type)
		{
		case EventType.ProductRelease:
			if (Subjects.Length != 1)
			{
				return HUD.GetThemeColor(6);
			}
			return HUD.GetThemeColor(0);
		case EventType.Update:
			return HUD.GetThemeColor(1);
		case EventType.Port:
			return HUD.GetThemeColor(2);
		case EventType.PriceChange:
			return HUD.GetThemeColor(3);
		case EventType.PublisherChange:
		case EventType.ProductTrade:
			return HUD.GetThemeColor(4);
		case EventType.TechResearch:
			return HUD.GetThemeColor(5);
		case EventType.Founded:
		case EventType.Subsidiary:
			return HUD.GetThemeColor(1);
		case EventType.BuyOut:
			return HUD.GetThemeColor(2);
		case EventType.IPTrade:
			return HUD.GetThemeColor(3);
		case EventType.SoldStock:
		case EventType.BoughtStock:
			return HUD.GetThemeColor(4);
		case EventType.IPO:
		case EventType.StockDilution:
		case EventType.StockBuyBack:
		case EventType.Bankrupt:
		case EventType.BoughtOut:
			return HUD.GetThemeColor(5);
		case EventType.Patent:
			return HUD.GetThemeColor(7);
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public string GetIcon()
	{
		switch (Type)
		{
		case EventType.ProductRelease:
			if (Subjects.Length != 1)
			{
				return "SoftwarePlus";
			}
			return "Software";
		case EventType.IPTrade:
			return "Deal";
		case EventType.BuyOut:
			return "Money";
		case EventType.Founded:
		case EventType.Subsidiary:
			return "Skyskraper";
		case EventType.Update:
			return "SoftwarePlus";
		case EventType.Port:
			return "MoreSoftware";
		case EventType.PriceChange:
			return "Money";
		case EventType.PublisherChange:
		case EventType.ProductTrade:
			return "Deal";
		case EventType.TechResearch:
		case EventType.Patent:
			return "Research";
		case EventType.IPO:
		case EventType.SoldStock:
		case EventType.BoughtStock:
		case EventType.StockDilution:
		case EventType.StockBuyBack:
			return "PieChart";
		case EventType.Bankrupt:
		case EventType.BoughtOut:
			return "Trash";
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public Action GetAction()
	{
		switch (Type)
		{
		case EventType.ProductRelease:
		case EventType.IPTrade:
		case EventType.Port:
		{
			SoftwareProduct p = MarketSimulation.Active.GetProduct(Subjects[0], false);
			if (p == null)
			{
				break;
			}
			if (Type == EventType.ProductRelease && Subjects.Length > 1)
			{
				AddOnProduct a = p.GetAddon(Subjects[1]);
				if (a != null)
				{
					return delegate
					{
						HUD.Instance.GetProductWindow(null).ShowAddonDetails(a);
					};
				}
				return null;
			}
			return delegate
			{
				HUD.Instance.GetProductWindow(null).ShowProductDetails(p);
			};
		}
		case EventType.SoldStock:
		case EventType.BoughtStock:
		case EventType.BoughtOut:
		case EventType.ProductTrade:
		{
			Company c2 = MarketSimulation.Active.GetCompany(Subjects[0]);
			if (c2 != null)
			{
				return delegate
				{
					HUD.Instance.companyWindow.ShowCompanyDetails(c2);
				};
			}
			break;
		}
		case EventType.Subsidiary:
		{
			Company c = MarketSimulation.Active.GetCompany((Value > 0f) ? Subjects[0] : Subjects[1]);
			if (c != null)
			{
				return delegate
				{
					HUD.Instance.companyWindow.ShowCompanyDetails(c);
				};
			}
			break;
		}
		}
		return null;
	}

	public void WriteData(Stream st)
	{
		st.WriteByte(TypeByte);
		st.WriteByte((byte)(DateInt & 0xFF));
		st.WriteByte((byte)((DateInt >> 8) & 0xFF));
		st.WriteBools(Desc != null, Subjects != null, Value != 0f, Value2 != 0f);
		if (Value != 0f)
		{
			st.WriteFloat(Value);
		}
		if (Value2 != 0f)
		{
			st.WriteFloat(Value2);
		}
		if (Desc != null)
		{
			st.WriteArray(Desc, delegate(Stream x, string y)
			{
				x.WriteStringUTF8(y);
			});
		}
		if (Subjects != null)
		{
			st.WriteArray(Subjects, delegate(Stream x, uint y)
			{
				x.WriteUInt(y);
			});
		}
	}

	public static MarketEvent ReadData(Stream st)
	{
		int type = st.ReadByte();
		ushort d = (ushort)(st.ReadByte() | (st.ReadByte() << 8));
		bool b;
		bool b2;
		bool b3;
		bool b4;
		st.ReadBools(out b, out b2, out b3, out b4);
		float value = (b3 ? st.ReadFloat() : 0f);
		float value2 = (b4 ? st.ReadFloat() : 0f);
		string[] desc = null;
		uint[] subjects = null;
		if (b)
		{
			desc = st.ReadArray((Stream x) => x.ReadStringUTF8());
		}
		if (b2)
		{
			subjects = st.ReadArray((Stream x) => x.ReadUInt());
		}
		return new MarketEvent((EventType)type, ConvertDate(d), desc, subjects, value, value2);
	}

	public void Serialize(AltSerializer serializer, int depth)
	{
		WriteData(serializer.Stream);
	}

	public IAltSerializable Deserialize(AltSerializer deserializer)
	{
		return ReadData(deserializer.Stream);
	}
}
