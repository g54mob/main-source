using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class JobMaintenanceDescription : JobDescription
	{
		public JobMaintenance.JobDescription Description;

		public override Sprite GetIcon()
		{
			return null;
		}

		public override bool IsSuitable(Staff staff)
		{
			if (Description == JobMaintenance.JobDescription.Vehicular)
			{
				return staff.CanRepairVehicles;
			}
			if (staff.Definition._type == StaffDefinition.Type.Janitor)
			{
				return !staff.Definition.IsUniqueVehicularMechanic;
			}
			return false;
		}

		public override bool MatchesJob(Job job)
		{
			if (job is JobMaintenance jobMaintenance)
			{
				return jobMaintenance.Item.Definition.MaintenanceDescription == Description;
			}
			return false;
		}

		public override string ToString()
		{
			return Description switch
			{
				JobMaintenance.JobDescription.None => string.Empty, 
				JobMaintenance.JobDescription.BrokenMachine => ScriptLocalization.Tooltip.JobDescription_BrokenMachine_CS, 
				JobMaintenance.JobDescription.BlockedToilet => ScriptLocalization.Tooltip.JobDescription_BlockedToilet_CS, 
				JobMaintenance.JobDescription.OutOfStock => ScriptLocalization.Tooltip.JobDescription_OutOfStock_CS, 
				JobMaintenance.JobDescription.WiltedPlant => ScriptLocalization.Tooltip.JobDescription_WiltedPlant_CS, 
				JobMaintenance.JobDescription.Litter => ScriptLocalization.Tooltip.JobDescription_Litter_CS, 
				JobMaintenance.JobDescription.MedicalWaste => ScriptLocalization.Tooltip.JobDescription_MedicalWaste_CS, 
				JobMaintenance.JobDescription.Ghost => ScriptLocalization.Tooltip.JobDescription_Ghost_CS, 
				JobMaintenance.JobDescription.Vehicular => ScriptLocalization.Tooltip.JobDescription_Vehicular_CS, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public override string ToLocalisedString()
		{
			return ToString();
		}

		public override bool Equals(JobDescription desc)
		{
			if (!(desc is JobMaintenanceDescription jobMaintenanceDescription))
			{
				return false;
			}
			if (Description != jobMaintenanceDescription.Description)
			{
				return false;
			}
			return true;
		}

		public override string RequiredQualificationString()
		{
			if (Description == JobMaintenance.JobDescription.Vehicular)
			{
				return ScriptLocalization.Tooltip.JobDescription_Vehicular_CS;
			}
			return string.Empty;
		}
	}
}
