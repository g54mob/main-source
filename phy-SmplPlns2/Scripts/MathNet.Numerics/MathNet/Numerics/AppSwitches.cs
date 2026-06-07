using System;

namespace MathNet.Numerics
{
	public static class AppSwitches
	{
		private const string AppSwitchDisableNativeProviderProbing = "Switch.MathNet.Numerics.Providers.DisableNativeProviderProbing";

		private const string AppSwitchDisableNativeProviders = "Switch.MathNet.Numerics.Providers.DisableNativeProviders";

		private const string AppSwitchDisableMklNativeProvider = "Switch.MathNet.Numerics.Providers.DisableMklNativeProvider";

		private const string AppSwitchDisableCudaNativeProvider = "Switch.MathNet.Numerics.Providers.DisableCudaNativeProvider";

		private const string AppSwitchDisableOpenBlasNativeProvider = "Switch.MathNet.Numerics.Providers.DisableOpenBlasNativeProvider";

		public static bool DisableNativeProviderProbing
		{
			get
			{
				return IsEnabled("Switch.MathNet.Numerics.Providers.DisableNativeProviderProbing");
			}
			set
			{
				SetSwitch("Switch.MathNet.Numerics.Providers.DisableNativeProviderProbing", value);
			}
		}

		public static bool DisableNativeProviders
		{
			get
			{
				return IsEnabled("Switch.MathNet.Numerics.Providers.DisableNativeProviders");
			}
			set
			{
				SetSwitch("Switch.MathNet.Numerics.Providers.DisableNativeProviders", value);
			}
		}

		public static bool DisableMklNativeProvider
		{
			get
			{
				return IsEnabled("Switch.MathNet.Numerics.Providers.DisableMklNativeProvider");
			}
			set
			{
				SetSwitch("Switch.MathNet.Numerics.Providers.DisableMklNativeProvider", value);
			}
		}

		public static bool DisableCudaNativeProvider
		{
			get
			{
				return IsEnabled("Switch.MathNet.Numerics.Providers.DisableCudaNativeProvider");
			}
			set
			{
				SetSwitch("Switch.MathNet.Numerics.Providers.DisableCudaNativeProvider", value);
			}
		}

		public static bool DisableOpenBlasNativeProvider
		{
			get
			{
				return IsEnabled("Switch.MathNet.Numerics.Providers.DisableOpenBlasNativeProvider");
			}
			set
			{
				SetSwitch("Switch.MathNet.Numerics.Providers.DisableOpenBlasNativeProvider", value);
			}
		}

		private static void SetSwitch(string switchName, bool isEnabled)
		{
			AppContext.SetSwitch(switchName, isEnabled);
		}

		private static bool IsEnabled(string switchName)
		{
			bool isEnabled;
			return AppContext.TryGetSwitch(switchName, out isEnabled) && isEnabled;
		}
	}
}
