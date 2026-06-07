using R3;

public static class ObservableWhereExtensions
{
	public static Observable<Datacenter> ForDatacenter(this Observable<Datacenter> source, Datacenter value)
	{
		return source.Where(value, (Datacenter dc, Datacenter datacenter) => dc == datacenter);
	}

	public static Observable<Datacenter> ForDatacenter(this Observable<Datacenter> source, Datacenter value1, Datacenter value2)
	{
		return source.Where((value1, value2), (Datacenter dc, (Datacenter value1, Datacenter value2) state) => dc == state.value1 || dc == state.value2);
	}
}
