namespace NSubstitute.Core
{
	public class CallInfoFactory : ICallInfoFactory
	{
		public CallInfo Create(ICall call)
		{
			return new CallInfo(GetArgumentsFromCall(call));
		}

		private static Argument[] GetArgumentsFromCall(ICall call)
		{
			Argument[] array = new Argument[call.GetOriginalArguments().Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new Argument(call, i);
			}
			return array;
		}
	}
}
