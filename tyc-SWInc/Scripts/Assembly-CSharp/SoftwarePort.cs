using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SINetworking;
using UnityEngine;

[Serializable]
public class SoftwarePort : WorkItem
{
	[Serializable]
	public class PortProgress
	{
		public SoftwareProduct Product;

		public float Progress;

		public float Goal = 2f;

		public bool Finished;

		public bool Waiting;

		public bool Ported;

		public bool IsMock
		{
			get
			{
				if (Product.IsMock)
				{
					return Product.MockSucceeded == null;
				}
				return false;
			}
		}

		public SoftwareProduct ActualProduct
		{
			get
			{
				return Product.MockSucceeded ?? Product;
			}
		}

		public PortProgress()
		{
		}

		public PortProgress(SoftwareProduct product)
		{
			Product = product;
		}

		public bool DoPort(SoftwareProduct target)
		{
			if (Finished && !Ported)
			{
				if (Waiting)
				{
					if (!IsMock)
					{
						Waiting = false;
						AddSupport(target);
						return true;
					}
				}
				else
				{
					if (!IsMock)
					{
						AddSupport(target);
						return true;
					}
					Waiting = true;
				}
			}
			return false;
		}

		private void AddSupport(SoftwareProduct target)
		{
			Ported = true;
			GameSettings.Instance.CheckOSLicenses = true;
			SoftwareProduct actualProduct = ActualProduct;
			if (!target.HasOS(actualProduct))
			{
				NetworkMessaging.SendPort(target.ID, actualProduct.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				GameSettings.Instance.simulation.RegisterOSSupport(target.Category, actualProduct);
				target.AddOS(actualProduct);
				target.AddMarketEvent(new MarketEvent(MarketEvent.EventType.Port, SDateTime.Now(), actualProduct.ID), true);
				ProductDetailWindow productDetailWindow = WindowManager.FindWindowType<ProductDetailWindow>().FirstOrDefault((ProductDetailWindow x) => x.product == target);
				if (productDetailWindow != null)
				{
					productDetailWindow.UpdateMe();
				}
			}
		}
	}

	private ActiveWorkerManager _workerManager = new ActiveWorkerManager();

	public SoftwareProduct Product;

	public List<PortProgress> OSs;

	public PortProgress Current;

	private bool WaitingForMock;

	public override Color BackColor
	{
		get
		{
			return new Color32(121, 42, 191, byte.MaxValue);
		}
	}

	public override bool CanOutsourceNetwork
	{
		get
		{
			return OSs.None((PortProgress x) => x.IsMock);
		}
	}

	public override string UnitName
	{
		get
		{
			return "SoftwarePort";
		}
	}

	public override bool HasNaturalNetworkEnd
	{
		get
		{
			return true;
		}
	}

	public override byte ByteTypeID
	{
		get
		{
			return 3;
		}
	}

	public override IReferenceFix FixReferences()
	{
		string name = Product.Name;
		Product = Product.FixReferences() as SoftwareProduct;
		if (Product == null)
		{
			SelectorController.MissingDataHost.Add(name);
			Kill();
			return null;
		}
		OSs.ForEach(delegate(PortProgress x)
		{
			x.Product = x.Product.FixReferences() as SoftwareProduct;
		});
		for (int num = 0; num < OSs.Count; num++)
		{
			if (OSs[num].Product == null)
			{
				OSs.RemoveAt(num);
				num--;
			}
		}
		PortProgress current = Current;
		if (((current != null) ? current.Product : null) == null && !RefreshCurrent())
		{
			return null;
		}
		return base.FixReferences();
	}

	public SoftwarePort(string name)
		: base(name, null, 0u, null)
	{
	}

	public SoftwarePort()
	{
	}

	public SoftwarePort(SoftwareProduct product, SoftwareProduct[] os, uint networkID = 0u, NetworkDeal networkDeal = null)
		: base("Porting".Loc() + " " + product.Name, null, networkID, networkDeal)
	{
		Product = product;
		OSs = os.SelectInPlaceList((SoftwareProduct x) => new PortProgress(x));
		Current = OSs[0];
		RunScripts(product.Features, false, false);
	}

	public override string GetWorkTypeName()
	{
		return "Port";
	}

	public override string GetIcon()
	{
		return "ArrowRight";
	}

	public override float GetProgress()
	{
		return ((float)OSs.Count((PortProgress x) => x.Finished) + ((Current == null) ? 0f : (Current.Progress / Current.Goal))) / (float)OSs.Count;
	}

	public override void DevTeamChange()
	{
		GameSettings.Instance.CheckOSLicenses = true;
	}

	public override string Category()
	{
		return OSs.Count((PortProgress x) => x.Finished) + "/" + OSs.Count;
	}

	public override string CollapseLabel()
	{
		if (Current != null)
		{
			return Current.Product.Name + " / " + OSs.Count((PortProgress x) => !x.Finished);
		}
		return Category();
	}

	public override string CurrentStage()
	{
		if (WaitingForMock)
		{
			return "MockOSPortWait".Loc();
		}
		if (Current != null)
		{
			return "PortTo".Loc(Current.Product.Name);
		}
		return "";
	}

	public override byte[] SerializeProgressData()
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			PortProgress current = Current;
			memoryStream.WriteStringUTF8((current != null) ? current.Product.Name : null);
			memoryStream.WriteInt(OSs.Count((PortProgress x) => x.Finished));
			memoryStream.WriteInt(OSs.Count);
			return memoryStream.ToArray();
		}
	}

	public override void DeserializeProgressData(byte[] data)
	{
		using (MemoryStream stream = new MemoryStream(data))
		{
			string text = stream.ReadStringUTF8();
			NetworkStage = ((text == null) ? "" : "PortTo".Loc(text));
			NetworkCategory = stream.ReadInt() + "/" + stream.ReadInt();
			NetworkProgressLabel = GetProgressLabel();
		}
	}

	public override float StressMultiplier()
	{
		return 0.5f;
	}

	private float GetOSDevTime(SoftwareProduct p)
	{
		return 1f + p.DevTime / 2f;
	}

	public override void DoWork(Actor actor, float effectiveness, float delta, bool secondary)
	{
		if (base.ActiveDeal == null && Product.DevCompany != GetWorkOwner())
		{
			Kill();
		}
		else if (Current != null)
		{
			_workerManager.UpdateWorker(actor.DID, SDateTime.Now());
			float skill = actor.employee.GetSkill(Employee.EmployeeRole.Programmer);
			RecordSkill(Employee.EmployeeRole.Programmer, skill, delta);
			effectiveness = Utilities.PerDay(effectiveness * skill.MapRange(0f, 1f, 0.25f, 1f, true) * SoftwareType.GetEmployeeCountEffect(Mathf.Max(1, _workerManager.Count), GetOSDevTime(Product), false) * actor.GetPCAddonBonus(Employee.EmployeeRole.Programmer), delta) * actor.LeaderEffectivenessFactor(3);
			Current.Progress = Mathf.Min(Current.Goal, Current.Progress + effectiveness * 3f);
			if (Current.Progress >= Current.Goal)
			{
				Current.Finished = true;
				RefreshCurrent();
			}
		}
	}

	public override bool CanUseCompany()
	{
		return true;
	}

	public override bool HasCompanyWork()
	{
		if (WaitingForMock && !RefreshCurrent() && WaitingForMock)
		{
			return false;
		}
		return true;
	}

	public override float CompanyWork(float delta)
	{
		if (base.ActiveDeal == null && Product.DevCompany != GetWorkOwner())
		{
			Kill();
			return 0f;
		}
		if (Current == null)
		{
			return 0f;
		}
		int num = SoftwareType.GetOptimalEmployeeCount(GetOSDevTime(Product))[1];
		float num2 = Utilities.PerDay(1f, delta, false);
		float num3 = base.CompanyWorker.AverageQuality * num2;
		Current.Progress = Mathf.Min(Current.Goal, Current.Progress + num3 * 3f);
		if (Current.Progress >= Current.Goal)
		{
			Current.Finished = true;
			RefreshCurrent();
		}
		return num2 * base.CompanyWorker.BusinessSavy.MapRange(0f, 1f, 4f, 2f) * (float)num * Employee.AverageWage * Employee.GetRoleSalary(Employee.EmployeeRole.Programmer);
	}

	public override IEnumerable<KeyValuePair<string, Action>> GetButtons()
	{
		NetworkDealState state = GetNetworkDealState();
		if (state == NetworkDealState.Sender)
		{
			yield return new KeyValuePair<string, Action>("FinishDeal", delegate
			{
				NetworkCancel(true);
			});
			yield return new KeyValuePair<string, Action>("CancelDeal", delegate
			{
				NetworkCancel(false);
			});
			yield break;
		}
		yield return new KeyValuePair<string, Action>("Assign", delegate
		{
			Assign("Porting");
		});
		if (state == NetworkDealState.Receiver)
		{
			yield return new KeyValuePair<string, Action>("CancelDeal", base.NetworkComplete);
			yield break;
		}
		yield return new KeyValuePair<string, Action>("Add", AddOSs);
		yield return new KeyValuePair<string, Action>("Change", Alter);
		yield return new KeyValuePair<string, Action>("Cancel", delegate
		{
			Kill(true);
		});
	}

	public override void GetNeeds(Dictionary<HRManagement.EdNeed, int>[] needs)
	{
	}

	public override string GetTypeName()
	{
		return "SoftwarePort";
	}

	public override string GetGroupType()
	{
		return "Port";
	}

	public override string GetGroupProject()
	{
		return Product.Name;
	}

	public bool RefreshCurrent()
	{
		Current = null;
		bool flag = false;
		for (int i = 0; i < OSs.Count; i++)
		{
			PortProgress portProgress = OSs[i];
			if (portProgress.DoPort(Product))
			{
				TotalNetworkUnits += 1f;
			}
			flag |= portProgress.Waiting;
			if (Current == null && !portProgress.Finished)
			{
				Current = portProgress;
			}
		}
		if (Current == null)
		{
			if (!flag)
			{
				if (GetNetworkDealState() != NetworkDealState.Receiver)
				{
					Kill();
				}
				return false;
			}
			WaitingForMock = true;
		}
		else
		{
			WaitingForMock = false;
		}
		return true;
	}

	public override Employee.EmployeeRole? GetBoostRole(Actor act, bool secondary)
	{
		if (act.employee.IsRole(Employee.RoleBit.Programmer, secondary))
		{
			return Employee.EmployeeRole.Programmer;
		}
		return null;
	}

	public override Actor.WorkParticle EmitType(Actor actor, bool secondary)
	{
		return Actor.WorkParticle.Binary;
	}

	public override HasWorkReturn HasWork(Actor actor, bool secondary, bool actualCheck)
	{
		if (GetNetworkDealState() == NetworkDealState.Sender)
		{
			return HasWorkReturn.Ignore;
		}
		if (WaitingForMock && (!RefreshCurrent() || WaitingForMock))
		{
			return HasWorkReturn.Ignore;
		}
		return actor.employee.IsRoleSecondary(Employee.RoleBit.Programmer, secondary);
	}

	public void Alter()
	{
		List<PortProgress> canRemove = OSs.Where((PortProgress x) => !x.Finished).ToList();
		WindowManager.Instance.MultiWindow.ShowMulti("Operating system", canRemove.Select((PortProgress x) => x.Product.Name), canRemove.SelectInPlace((PortProgress x) => true), delegate(int[] ix)
		{
			if (ix.Length != 0)
			{
				for (int i = 0; i < ix.Length; i++)
				{
					OSs.Remove(canRemove[ix[i]]);
				}
				RefreshCurrent();
			}
		}, true, false, true);
	}

	public void AddOSs()
	{
		ProductWindow.ShowPortWindow(Product, delegate(SoftwareProduct[] x)
		{
			OSs.AddRange(x.Select((SoftwareProduct z) => new PortProgress(z)));
		});
	}

	public override void AddLoss(float cost, SoftwareProduct.LossType type, bool immediate, bool fromNetwork = false)
	{
		Product.AddLoss(cost, type, immediate, fromNetwork);
	}

	public override string GetSubjectName()
	{
		SoftwareProduct product = Product;
		if (product == null)
		{
			return "NotApplicableAbbr".Loc();
		}
		return product.Name;
	}

	public override void Kill(bool wasCancelled = false)
	{
		if (Product != null)
		{
			RunScripts(Product.Features, true, wasCancelled);
		}
		base.Kill(wasCancelled);
	}

	public override void OnNetworkComplete(Stream st)
	{
		LoadCompletionData(st, true);
	}

	public override byte[] GetNetworkCompletionData(bool success)
	{
		using (MemoryStream memoryStream = new MemoryStream())
		{
			memoryStream.WriteArray(OSs, delegate(Stream s, PortProgress x)
			{
				s.WriteUInt(x.Product.ID);
				s.WriteFloat(x.Progress);
			});
			return memoryStream.ToArray();
		}
	}

	public override List<KeyValuePair<string, string>> GetInfo()
	{
		return new List<KeyValuePair<string, string>>
		{
			new KeyValuePair<string, string>("Product".Loc(), Product.Name),
			new KeyValuePair<string, string>("Type".Loc(), Product.Category.GetActualString()),
			new KeyValuePair<string, string>("Release".Loc(), Product.Release.ToCompactString()),
			new KeyValuePair<string, string>("Operatingsystems".Loc(), OSs.Count((PortProgress x) => !x.IsMock).ToString())
		};
	}

	public override void WriteSubData(Stream st)
	{
		st.WriteUInt(Product.ID);
		st.WriteArray(OSs.Where((PortProgress x) => !x.IsMock), delegate(Stream s, PortProgress x)
		{
			s.WriteUInt(x.Product.ID);
		});
		st.WriteArray(OSs.Where((PortProgress x) => !x.IsMock), delegate(Stream s, PortProgress x)
		{
			s.WriteUInt(x.Product.ID);
			s.WriteFloat(x.Progress);
		});
	}

	public void LoadCompletionData(Stream st, bool removeMissing)
	{
		HashSet<PortProgress> found = (removeMissing ? new HashSet<PortProgress>() : null);
		st.ExecuteArray(delegate(Stream s)
		{
			uint id = s.ReadUInt();
			float progress = s.ReadFloat();
			PortProgress portProgress2 = OSs.FirstOrDefault((PortProgress x) => x.Product.ID == id);
			if (portProgress2 != null)
			{
				HashSet<PortProgress> hashSet = found;
				if (hashSet != null)
				{
					hashSet.Add(portProgress2);
				}
				portProgress2.Progress = progress;
				if (portProgress2.Progress >= 1f)
				{
					OSs.Remove(portProgress2);
				}
			}
		});
		if (removeMissing)
		{
			for (int num = 0; num < OSs.Count; num++)
			{
				PortProgress portProgress = OSs[num];
				if (!portProgress.IsMock && !found.Contains(portProgress))
				{
					OSs.RemoveAt(num);
					num--;
				}
			}
		}
		RefreshCurrent();
	}

	public override bool IsDoneForNetworkDeal()
	{
		return !RefreshCurrent();
	}

	public override IRoyaltyItem GetRoyaltyItem()
	{
		return Product;
	}
}
