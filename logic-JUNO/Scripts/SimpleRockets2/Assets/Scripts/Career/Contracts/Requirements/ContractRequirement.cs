using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.State;
using ModApi.Common.Extensions;
using ModApi.Craft;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public abstract class ContractRequirement
	{
		public class ButtonInformation
		{
			public string Sprite { get; set; }

			public string Tooltip { get; set; }

			public ButtonInformation(string tooltip, string sprite)
			{
				Tooltip = tooltip;
				Sprite = sprite;
			}
		}

		private List<ContractRequirement> _children = new List<ContractRequirement>();

		private string[] _prereqIds;

		private bool _startBypassed;

		public bool AlwaysEvaluate { get; private set; }

		public bool AlwaysEvaluateChildren { get; }

		public int AnalyticsId { get; set; }

		public virtual ButtonInformation ButtonInfo { get; }

		public IReadOnlyList<ContractRequirement> Children => _children;

		public Contract Contract { get; }

		public bool CrewedOnComplete { get; private set; }

		public virtual bool DefaultListedInMenu => true;

		public virtual bool DefaultResetChildrenWhenNotPassing => true;

		public virtual RequirementVisibilityType DefaultVisibility => RequirementVisibilityType.Visible;

		public string Description { get; set; }

		public virtual string DisplayValue { get; }

		public IFlightContext FlightContext { get; private set; }

		public virtual string FlightDescription => Description;

		public bool HasPassedAtLeastOnce { get; private set; }

		public string Id { get; }

		public bool IsActive
		{
			get
			{
				if (Status != RequirementStatus.Active)
				{
					return Status == RequirementStatus.Pass;
				}
				return true;
			}
		}

		public bool IsBypassed { get; set; }

		public bool IsSequential { get; set; }

		public bool IsVisible
		{
			get
			{
				if (Status != RequirementStatus.Inactive && !IsBypassed)
				{
					ContractRequirement parent = Parent;
					if (parent == null || parent.Status != RequirementStatus.Pass)
					{
						ContractRequirement parent2 = Parent;
						if (parent2 == null || !parent2.AlwaysEvaluateChildren)
						{
							goto IL_0063;
						}
					}
					if (VisibilityType == RequirementVisibilityType.Visible)
					{
						return true;
					}
					if (VisibilityType == RequirementVisibilityType.HiddenWhenPassed)
					{
						if (Status != RequirementStatus.Active)
						{
							return Status == RequirementStatus.Fail;
						}
						return true;
					}
				}
				goto IL_0063;
				IL_0063:
				return false;
			}
		}

		public bool ListedInMenu { get; private set; }

		public RequirementFailureType OnFail { get; protected set; }

		public ContractRequirement Parent { get; private set; }

		public List<ContractRequirement> Prereqs { get; private set; } = new List<ContractRequirement>();

		public bool ResetChildrenWhenNotPassing { get; private set; }

		public bool ShowCheckmarkWhenPassed { get; set; } = true;

		public bool ShowDisplayValue { get; private set; }

		public RequirementStatus Status { get; private set; }

		public virtual string Type => Xml.Name.LocalName;

		public RequirementVisibilityType VisibilityType { get; set; }

		protected virtual ICraftNode CraftNodeOverride => null;

		protected XElement Xml { get; private set; }

		public ContractRequirement(XElement xml, Contract contract)
		{
			Xml = xml;
			Contract = contract;
			Id = xml.GetStringAttribute("id");
			_prereqIds = xml.GetStringAttribute("prereqs")?.Split(new char[1] { ',' });
			Description = xml.Attribute("description")?.Value;
			VisibilityType = xml.GetEnumAttribute("visibility", DefaultVisibility);
			ListedInMenu = xml.GetBoolAttribute("listedInMenu", DefaultListedInMenu);
			ResetChildrenWhenNotPassing = xml.GetBoolAttribute("resetChildrenWhenNotPassing", DefaultResetChildrenWhenNotPassing);
			OnFail = xml.GetEnumAttribute("onFail", RequirementFailureType.Keep);
			Status = xml.GetEnumAttribute("status", RequirementStatus.Inactive);
			_startBypassed = xml.GetBoolAttribute("startBypassed");
			IsBypassed = xml.GetBoolAttribute("bypass", _startBypassed);
			IsSequential = xml.GetBoolAttribute("sequential", defaultValue: true);
			AlwaysEvaluate = xml.GetBoolAttribute("alwaysEvaluate");
			AlwaysEvaluateChildren = xml.GetBoolAttribute("alwaysEvaluateChildren");
			ShowDisplayValue = xml.GetBoolAttribute("showValue", defaultValue: true);
			HasPassedAtLeastOnce = xml.GetBoolAttribute("hasPassedAtLeastOnce");
			CrewedOnComplete = xml.GetBoolAttribute("crewedOnComplete");
			ListedInMenu = ListedInMenu && !IsBypassed;
			IEnumerable<XElement> enumerable = xml.Elements();
			if (enumerable == null)
			{
				return;
			}
			ContractRequirement contractRequirement = null;
			foreach (XElement item in enumerable)
			{
				if (item.Name.LocalName.Contains("."))
				{
					continue;
				}
				try
				{
					ContractRequirement contractRequirement2 = CreateChildRequirement(item);
					_children.Add(contractRequirement2);
					if (contractRequirement2.IsSequential && contractRequirement != null)
					{
						contractRequirement2.Prereqs.Add(contractRequirement);
					}
					contractRequirement = contractRequirement2;
				}
				catch (Exception innerException)
				{
					throw new ContractException($"Failed to create requirement '{item?.Name}' in contract '{contract.Id}'", innerException);
				}
			}
		}

		public virtual string CanWarp()
		{
			return null;
		}

		public virtual void OnClick(Action refreshUI)
		{
		}

		public virtual void OnContractClosed(FlightStateData flightStateData)
		{
		}

		public virtual void OnFlightEnd()
		{
			foreach (ContractRequirement child in _children)
			{
				child.OnFlightEnd();
			}
			FlightContext = null;
		}

		public virtual void OnFlightStart(IFlightContext flightContext)
		{
			FlightContext = flightContext;
			foreach (ContractRequirement child in _children)
			{
				child.OnFlightStart(flightContext);
			}
		}

		public virtual void OnFlightUpdate(ICraftNode craftNode, bool parentsPassing)
		{
			craftNode = CraftNodeOverride ?? craftNode;
			if (Status == RequirementStatus.Complete && !AlwaysEvaluate)
			{
				return;
			}
			RequirementStatus requirementStatus = RequirementStatus.Inactive;
			bool crewed = false;
			if (CheckPrereqs(Prereqs))
			{
				requirementStatus = RequirementStatus.Active;
				if (IsBypassed || Evaluate(craftNode))
				{
					requirementStatus = RequirementStatus.Pass;
				}
				else if (Status != RequirementStatus.Complete && Status != RequirementStatus.Fail)
				{
					if (OnFail == RequirementFailureType.Cancel || OnFail == RequirementFailureType.Stop)
					{
						requirementStatus = RequirementStatus.Fail;
					}
					else if (OnFail == RequirementFailureType.Skip)
					{
						requirementStatus = RequirementStatus.Complete;
					}
				}
				else
				{
					requirementStatus = Status;
				}
				parentsPassing = parentsPassing && requirementStatus == RequirementStatus.Pass;
				if ((AlwaysEvaluateChildren || parentsPassing) && UpdateChildren(craftNode, parentsPassing) && requirementStatus == RequirementStatus.Pass)
				{
					requirementStatus = RequirementStatus.Complete;
					crewed = (craftNode.CraftScript?.NumAstronauts ?? 0) > 0;
				}
			}
			SetStatus(requirementStatus, crewed);
		}

		public virtual void OnRequirementsCreated()
		{
			UpdatePrereqs(_prereqIds);
		}

		public virtual void OnTheFlyUpdateFromTargetRequirement(ContractRequirement target)
		{
			Description = target.Description;
			OnFail = target.OnFail;
			IsSequential = target.IsSequential;
			ListedInMenu = target.ListedInMenu;
			VisibilityType = target.VisibilityType;
		}

		public void ResetRequirementStatusRecursive()
		{
			ResetRequirementStatus();
			foreach (ContractRequirement child in Children)
			{
				child.ResetRequirementStatusRecursive();
			}
		}

		public virtual void SaveStatusToXml()
		{
			Xml.SetAttributeValue("status", Status);
			Xml.SetAttributeValue("bypass", IsBypassed);
		}

		public virtual void Validate(ValidationResult result)
		{
		}

		protected virtual ContractRequirement CreateChildRequirement(XElement xml)
		{
			ContractRequirement contractRequirement = Contract.CreateRequirement(xml);
			contractRequirement.Parent = this;
			return contractRequirement;
		}

		protected abstract bool Evaluate(ICraftNode craftNode);

		protected T GetParentRequirement<T>() where T : ContractRequirement
		{
			if (Parent != null && Parent is T result)
			{
				return result;
			}
			ContractRequirement parent = Parent;
			if (parent == null)
			{
				return null;
			}
			return parent.GetParentRequirement<T>();
		}

		protected void MarkAsComplete()
		{
			SetStatus(RequirementStatus.Complete, crewed: true, ignoreChildren: true);
		}

		protected void MarkAsFailed()
		{
			SetStatus(RequirementStatus.Fail);
		}

		protected virtual void OnStatusChanged()
		{
		}

		protected virtual void ResetRequirementStatus()
		{
			HasPassedAtLeastOnce = false;
			CrewedOnComplete = false;
			IsBypassed = _startBypassed;
			SetStatus(RequirementStatus.Inactive);
		}

		protected virtual bool UpdateChildren(ICraftNode craftNode, bool parentsPassing)
		{
			bool result = true;
			foreach (ContractRequirement child in _children)
			{
				child.OnFlightUpdate(craftNode, parentsPassing);
				if (child.Status != RequirementStatus.Complete)
				{
					result = false;
				}
			}
			return result;
		}

		private static bool CheckPrereqs(List<ContractRequirement> prereqs)
		{
			if (prereqs != null)
			{
				foreach (ContractRequirement prereq in prereqs)
				{
					if (prereq.Status != RequirementStatus.Complete)
					{
						return false;
					}
				}
			}
			return true;
		}

		private void SetStatus(RequirementStatus status, bool crewed = false, bool ignoreChildren = false)
		{
			if (Status == status)
			{
				return;
			}
			Status = status;
			switch (status)
			{
			case RequirementStatus.Complete:
			{
				bool flag = true;
				foreach (ContractRequirement child in _children)
				{
					if (child.Status == RequirementStatus.Complete)
					{
						flag &= child.CrewedOnComplete;
					}
					if (child.Status == RequirementStatus.Active)
					{
						child.SetStatus(RequirementStatus.Inactive);
					}
				}
				CrewedOnComplete = crewed && (flag || ignoreChildren);
				break;
			}
			default:
				if (!ResetChildrenWhenNotPassing)
				{
					break;
				}
				foreach (ContractRequirement child2 in _children)
				{
					child2.SetStatus(RequirementStatus.Inactive);
				}
				break;
			case RequirementStatus.Pass:
				break;
			}
			if (Status == RequirementStatus.Fail && OnFail == RequirementFailureType.Cancel)
			{
				Contract.Status = ContractStatus.Terminated;
			}
			else if (Status == RequirementStatus.Fail && OnFail == RequirementFailureType.Stop)
			{
				Contract.Status = ContractStatus.Failed;
			}
			HasPassedAtLeastOnce |= Status == RequirementStatus.Pass || Status == RequirementStatus.Complete;
			OnStatusChanged();
		}

		private void UpdatePrereqs(string[] prereqIds)
		{
			if (prereqIds == null)
			{
				return;
			}
			foreach (string text in prereqIds)
			{
				bool flag = text.EndsWith("?");
				if (flag)
				{
					text.Substring(0, text.Length - 1);
				}
				ContractRequirement requirementById = Contract.GetRequirementById(text);
				if (requirementById != null)
				{
					Prereqs.Add(requirementById);
				}
				else if (!flag)
				{
					throw new Exception("Unable to find prereq requirement '" + text + "' on contract '" + Contract.Id + "'");
				}
			}
		}
	}
}
