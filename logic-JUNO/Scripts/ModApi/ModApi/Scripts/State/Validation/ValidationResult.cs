using System.Collections.Generic;
using System.Linq;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;

namespace ModApi.Scripts.State.Validation
{
	public class ValidationResult
	{
		public int ErrorCount => Messages.Where((ValidationMessage x) => x.MessageType == ValidationMessageType.Error).Count();

		public long LaunchCost { get; set; }

		public List<ValidationMessage> Messages { get; private set; } = new List<ValidationMessage>();

		public bool Successful => Messages.Count == 0;

		public int WarningCount => Messages.Where((ValidationMessage x) => x.MessageType == ValidationMessageType.Warning).Count();

		public void AddFuelWarning(PartData data, FuelType fuelType)
		{
			AddPartWarning("NoFuel", data, "Requires " + fuelType.Name + " to operate.");
		}

		public ValidationMessage AddMessage(string id, string message, PartData part = null, ValidationMessageType messageType = ValidationMessageType.Error, int priority = 0)
		{
			ValidationMessage validationMessage = new ValidationMessage
			{
				Message = message,
				Priority = priority,
				MessageType = messageType,
				PartID = (part?.Id ?? 0)
			};
			Messages.Add(validationMessage);
			return validationMessage;
		}

		public void AddPartWarning(string id, PartData part, string message, int priority = 0)
		{
			AddMessage(id, message, part, ValidationMessageType.Warning, priority);
		}

		public string GetShortErrorMessage()
		{
			string text = string.Empty;
			List<ValidationMessage> list = Messages.OrderByDescending((ValidationMessage x) => x.Priority).Take(5).ToList();
			foreach (ValidationMessage item in list)
			{
				if (text.Length > 0)
				{
					text += "\n\n";
				}
				text += item.Message;
			}
			int num = Messages.Count - list.Count;
			if (num > 0)
			{
				text += $"\n\n{num} more issue(s).";
			}
			return text;
		}

		public void ValidatFuel(PartModifierScript modifier, IFuelSource fuelSource, float lowFuelThreshold = 0f)
		{
			if (fuelSource?.FuelType == FuelType.Battery)
			{
				if (fuelSource == null || fuelSource.IsEmpty)
				{
					AddPartWarning("NoBattery", modifier.PartScript.Data, "Requires battery to operate.");
				}
				else if (fuelSource.TotalFuel < (double)lowFuelThreshold)
				{
					AddPartWarning("LowBattery", modifier.PartScript.Data, "May need more battery to operate.");
				}
			}
			else if (fuelSource == null || fuelSource.IsEmpty)
			{
				AddPartWarning("NoFuel", modifier.PartScript.Data, "Is missing a " + fuelSource?.FuelType.Name + " source.");
			}
		}
	}
}
