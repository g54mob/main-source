public interface ISpecController
{
	string[][] GetUnlockedSpecializations();

	int GetMaxPoints(Employee.EmployeeRole r);

	int GetMaxPoints(Employee.EmployeeRole r, int founder);
}
