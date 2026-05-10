namespace CTS
{
	public class UI_MachineMgr_FeatureBloodQuality : UI_MachineMgr_FeatureMinusPlus<MachineBase>
	{
		protected override void OnMinusButtonTick()
		{
			if (base._furniture is MachineBase machineBase && (bool)machineBase.MachineBloodQuality)
			{
				machineBase.MachineBloodQuality.SetBloodQuality(machineBase.MachineBloodQuality.CurrentBloodQuality - 1);
			}
		}

		protected override void OnPlusButtonTick()
		{
			if (base._furniture is MachineBase machineBase && (bool)machineBase.MachineBloodQuality)
			{
				machineBase.MachineBloodQuality.SetBloodQuality(machineBase.MachineBloodQuality.CurrentBloodQuality + 1);
			}
		}

		protected override bool IsPlusButtonLocked(MachineBase current)
		{
			if ((object)current.MachineBloodQuality == null)
			{
				return true;
			}
			return current.MachineBloodQuality.CurrentBloodQuality >= 10;
		}

		protected override bool IsMinusButtonLocked(MachineBase current)
		{
			if ((object)current.MachineBloodQuality == null)
			{
				return true;
			}
			return current.MachineBloodQuality.CurrentBloodQuality <= 1;
		}

		protected override string RepaintText(MachineBase current)
		{
			if ((object)current.MachineBloodQuality == null)
			{
				return string.Empty;
			}
			return current.MachineBloodQuality.CurrentBloodQuality.ToString();
		}

		protected override bool CanBeDisplayedForFurniture(MachineBase furniture)
		{
			return (object)furniture.MachineBloodQuality != null;
		}

		protected override void OnFurnitureSet(MachineBase furniture)
		{
			if ((object)furniture.MachineBloodQuality != null)
			{
				furniture.MachineBloodQuality.BloodyQualityChanged += OnBloodQualityChanged;
			}
		}

		protected override void OnFurnitureUnset(MachineBase furniture)
		{
			if ((object)furniture.MachineBloodQuality != null)
			{
				furniture.MachineBloodQuality.BloodyQualityChanged -= OnBloodQualityChanged;
			}
		}

		private void OnBloodQualityChanged(int obj)
		{
			OnRepaint();
		}
	}
}
