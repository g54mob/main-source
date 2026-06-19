using System.Runtime.InteropServices;

namespace ATM
{
	public class Wrapper
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void RegressionFinishedCallback();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void CommandExecutor([MarshalAs(UnmanagedType.LPStr)] string input);

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		public static extern bool AtmCreateConfigurator(int argv, [In] string[] argc);

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool AtmSetStandAlone(bool standalone);

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool AtmCreateAgent();

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool AtmStartAgent();

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool AtmExecuteNextCommand();

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool AtmDestroyAgent();

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool AtmRegisterCommandHandler([MarshalAs(UnmanagedType.LPStr)] string commandName, [MarshalAs(UnmanagedType.LPStr)] string commandDescription, [MarshalAs(UnmanagedType.FunctionPtr)] CommandExecutor executor);

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern void AtmReportCommandSuccess([MarshalAs(UnmanagedType.LPStr)] string result);

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern void AtmReportCommandFailure([MarshalAs(UnmanagedType.LPStr)] string message);

		[DllImport("AtmAgent_v02", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool AtmRegisterRegressionFinishedCallback([MarshalAs(UnmanagedType.FunctionPtr)] RegressionFinishedCallback callback);
	}
}
