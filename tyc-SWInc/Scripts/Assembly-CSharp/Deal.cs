using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public abstract class Deal : ICalenderItem, IByteData, IReferenceFix
{
	public bool Request;

	public bool Active;

	private readonly uint _client;

	private readonly uint _bidder;

	private uint _company;

	public readonly uint ID;

	public float Performance = 1f;

	public float PerfDiff;

	public SDateTime Accepted;

	public static Dictionary<byte, Func<Stream, uint, Company, Deal>> NetworkDeals = new Dictionary<byte, Func<Stream, uint, Company, Deal>>
	{
		{
			0,
			delegate(Stream st, uint id, Company c)
			{
				SimulatedCompany simulatedCompany = c as SimulatedCompany;
				SimulatedCompany.ProductPrototype prototype = simulatedCompany.GetPrototype(st.ReadUInt());
				if (prototype == null)
				{
					Debug.Log("Got print deal with missing prototype");
					return (Deal)null;
				}
				return new PrintDeal(simulatedCompany, prototype, st.ReadFloat(), st.ReadFloat(), st.ReadUInt(), id);
			}
		},
		{
			1,
			(Stream st, uint id, Company c) => new IPDeal(c, id, st.ReadArray((Stream s) => s.ReadUInt()), st.ReadUInt(), st.ReadUInt(), st.ReadUInt(), st.ReadFloat(), SDateTime.ReadData(st))
		},
		{
			2,
			(Stream st, uint id, Company c) => new ServerDeal(c, id, st.ReadUInt(), st.ReadFloat())
		},
		{
			3,
			delegate(Stream st, uint id, Company c)
			{
				bool num = st.ReadBool();
				uint num2 = st.ReadUInt();
				SoftwareProduct softwareProduct = null;
				SimulatedCompany.ProductPrototype productPrototype = null;
				if (num)
				{
					productPrototype = (c as SimulatedCompany).GetPrototype(num2);
					if (productPrototype == null)
					{
						Debug.Log("Got work deal with missing prototype");
						return (Deal)null;
					}
				}
				else
				{
					softwareProduct = MarketSimulation.Active.GetProduct(num2, false);
					if (softwareProduct == null)
					{
						Debug.Log("Got work deal with missing product");
						return (Deal)null;
					}
				}
				return new WorkDeal(c, id, productPrototype, softwareProduct, st.ReadEnum<WorkDeal.WorkType>(true), st.ReadFloat(), SDateTime.ReadData(st), st.ReadInt());
			}
		}
	};

	public bool Incoming
	{
		get
		{
			if (!Request)
			{
				return Client != GameSettings.Instance.MyCompany;
			}
			return true;
		}
	}

	public Company Client
	{
		get
		{
			GameSettings instance = GameSettings.Instance;
			if ((object)instance == null)
			{
				return null;
			}
			return instance.simulation.GetCompany(_client);
		}
	}

	public Company Bidder
	{
		get
		{
			GameSettings instance = GameSettings.Instance;
			if ((object)instance == null)
			{
				return null;
			}
			return instance.simulation.GetCompany(_bidder);
		}
	}

	public Company Company
	{
		get
		{
			GameSettings instance = GameSettings.Instance;
			if ((object)instance == null)
			{
				return null;
			}
			return instance.simulation.GetCompany(_company);
		}
	}

	public Company OtherCompany
	{
		get
		{
			if (!Request)
			{
				return Client;
			}
			return Bidder;
		}
	}

	public string CompanyName
	{
		get
		{
			Company company = (Request ? Bidder : Client);
			if (company != null)
			{
				return company.Name;
			}
			return "";
		}
	}

	public static float GetPlayerWorth(float min, float max)
	{
		return Utilities.RandomBucketed(GameSettings.Instance.MyCompany.BusinessStars, 6, min, max);
	}

	public Deal(Company company, bool request = false)
	{
		Request = request;
		if (Request)
		{
			_bidder = company.ID;
		}
		else
		{
			_client = company.ID;
		}
		ID = GameSettings.Instance.simulation.GetDealID();
	}

	public abstract void RecalculateWorth();

	public Deal(Company company, uint id, bool request = false)
	{
		Request = request;
		if (Request)
		{
			_bidder = company.ID;
		}
		else
		{
			_client = company.ID;
		}
		ID = id;
	}

	public Deal()
	{
	}

	public abstract float Worth();

	public virtual bool Cancel()
	{
		if (!Active)
		{
			return false;
		}
		Active = false;
		return true;
	}

	public abstract float Payout();

	public abstract float ReputationEffect(bool ending);

	public abstract string ReputationCategory();

	public virtual void Accept(Company company)
	{
		Accepted = SDateTime.Now();
		_company = company.ID;
		if (!CancelOnAccept())
		{
			Active = true;
		}
	}

	public abstract string Description();

	public abstract string Title();

	public abstract void HandleUpdate();

	public abstract void GetDetailedDescription(List<string> vars, List<string> values);

	public virtual bool StillValid(bool active)
	{
		if (Performance > 0f)
		{
			return Client != null;
		}
		return false;
	}

	public virtual bool CancelOnAccept()
	{
		return false;
	}

	public virtual void MadePayment(float amount)
	{
	}

	public string GetTitle()
	{
		return Title();
	}

	public string GetDescription()
	{
		return Description();
	}

	public virtual SDateTime? GetTime()
	{
		return null;
	}

	public ComingReleaseWindow.EventType GetEventType()
	{
		return ComingReleaseWindow.EventType.DealDeadline;
	}

	public virtual bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
	{
		return false;
	}

	public abstract byte GetTypeID();

	public abstract void WriteTypeData(Stream st);

	public virtual void WriteData(Stream st)
	{
		st.WriteByte(GetTypeID());
		st.WriteUInt(ID);
		st.WriteBool(Request);
		st.WriteUInt(Request ? _bidder : _client);
		WriteTypeData(st);
	}

	public static Deal ReadData(Stream st)
	{
		int num = st.ReadByte();
		uint arg = st.ReadUInt();
		st.ReadBool();
		Company company = MarketSimulation.Active.GetCompany(st.ReadUInt());
		if (company == null)
		{
			Debug.Log("Got deal with missing company");
			return null;
		}
		Func<Stream, uint, Company, Deal> value;
		if (NetworkDeals.TryGetValue((byte)num, out value))
		{
			return value(st, arg, company);
		}
		Debug.Log("Tried to deserialize unknown deal type: " + num);
		return null;
	}

	public virtual IReferenceFix FixReferences()
	{
		if (_bidder != 0 && Bidder == null)
		{
			return null;
		}
		if (_client != 0 && Client == null)
		{
			return null;
		}
		if (_company != 0 && Company == null)
		{
			return null;
		}
		return this;
	}
}
