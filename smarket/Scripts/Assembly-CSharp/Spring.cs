public abstract class Spring<T>
{
	public T Current { get; set; }

	public T Target { get; set; }

	public float SmoothTime { get; set; }

	public abstract T Update();
}
