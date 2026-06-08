namespace MLAPI.Messaging
{
	public class RpcResponse<T> : RpcResponseBase
	{
		public T Value { get; private set; }

		internal override object Result
		{
			set
			{
				Value = (T)value;
			}
		}
	}
}
