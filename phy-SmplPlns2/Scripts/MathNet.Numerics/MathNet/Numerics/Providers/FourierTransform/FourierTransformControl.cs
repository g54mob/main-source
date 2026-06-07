using System;

namespace MathNet.Numerics.Providers.FourierTransform
{
	public static class FourierTransformControl
	{
		private const string EnvVarFFTProvider = "MathNetNumericsFFTProvider";

		private static IFourierTransformProvider _fourierTransformProvider;

		private static readonly object StaticLock = new object();

		private const string MklTypeName = "MathNet.Numerics.Providers.MKL.FourierTransform.MklFourierTransformControl, MathNet.Numerics.Providers.MKL";

		private static readonly ProviderProbe<IFourierTransformProvider> MklProbe = new ProviderProbe<IFourierTransformProvider>("MathNet.Numerics.Providers.MKL.FourierTransform.MklFourierTransformControl, MathNet.Numerics.Providers.MKL", AppSwitches.DisableMklNativeProvider);

		public static string HintPath { get; set; }

		public static IFourierTransformProvider Provider
		{
			get
			{
				if (_fourierTransformProvider == null)
				{
					lock (StaticLock)
					{
						if (_fourierTransformProvider == null)
						{
							UseDefault();
						}
					}
				}
				return _fourierTransformProvider;
			}
			set
			{
				value.InitializeVerify();
				_fourierTransformProvider = value;
			}
		}

		public static void UseManaged()
		{
			Provider = ManagedFourierTransformProvider.Instance;
		}

		public static void UseNativeMKL()
		{
			Provider = MklProbe.Create();
		}

		public static bool TryUseNativeMKL()
		{
			return TryUse(MklProbe.TryCreate());
		}

		public static bool TryUseNative()
		{
			if (AppSwitches.DisableNativeProviders || AppSwitches.DisableNativeProviderProbing)
			{
				return false;
			}
			return TryUseNativeMKL();
		}

		public static bool TryUse(IFourierTransformProvider provider)
		{
			try
			{
				if (provider == null || !provider.IsAvailable())
				{
					return false;
				}
				Provider = provider;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static void UseBest()
		{
			if (AppSwitches.DisableNativeProviders || AppSwitches.DisableNativeProviderProbing)
			{
				UseManaged();
			}
			else if (!TryUseNative())
			{
				UseManaged();
			}
		}

		public static void UseDefault()
		{
			if (AppSwitches.DisableNativeProviders)
			{
				UseManaged();
				return;
			}
			string environmentVariable = Environment.GetEnvironmentVariable("MathNetNumericsFFTProvider");
			if (((environmentVariable != null) ? environmentVariable.ToUpperInvariant() : string.Empty) == "MKL")
			{
				UseNativeMKL();
			}
			else
			{
				UseBest();
			}
		}

		public static void FreeResources()
		{
			Provider.FreeResources();
		}
	}
}
