namespace Kitchen
{
	public interface IPersist
	{
		void BeforeLoading(SaveSystemType system_type);

		void AfterLoading(SaveSystemType system_type);

		void BeforeSaving(SaveSystemType system_type);

		void AfterSaving(SaveSystemType system_type);
	}
}
