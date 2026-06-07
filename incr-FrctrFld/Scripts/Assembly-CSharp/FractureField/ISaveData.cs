namespace FractureField
{
	public interface ISaveData<T, TSaveData>
	{
		TSaveData Save();

		T Load();
	}
}
