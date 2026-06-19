using I2.Loc;

public interface IFilteringBuilding
{
	bool RequiresElectricity();

	bool HasElectricity();

	LocalizedString GetUITitle();
}
