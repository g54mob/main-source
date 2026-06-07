using System.ComponentModel;

namespace NGenerics.Threading
{
	public class DoWorkEventArgs<TArgument, TResult> : CancelEventArgs
	{
		[Description("BackgroundWorker_DoWorkEventArgs_Argument")]
		public TArgument Argument { get; private set; }

		[Description("BackgroundWorker_DoWorkEventArgs_Result")]
		public TResult Result { get; set; }

		public DoWorkEventArgs(TArgument argument)
		{
			Argument = argument;
		}
	}
}
