namespace DV.Utils
{
	public class RequestSystem : CustomRequestSystem<float>
	{
		public RequestSystem(float defaultValue = float.NegativeInfinity, bool higherValueFirst = true, bool ignorePriority = false)
			: base(defaultValue, higherValueFirst, ignorePriority)
		{
		}
	}
}
