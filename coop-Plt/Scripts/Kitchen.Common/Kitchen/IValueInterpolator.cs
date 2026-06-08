namespace Kitchen
{
	public interface IValueInterpolator<T>
	{
		T Lerp(T t1, T t2, float f);

		float Distance(T t1, T t2);
	}
}
