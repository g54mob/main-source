using System;

namespace MathNet.Numerics.Providers.LinearAlgebra
{
	public static class LinearAlgebraControl
	{
		private const string EnvVarLAProvider = "MathNetNumericsLAProvider";

		private static ILinearAlgebraProvider _linearAlgebraProvider;

		private static readonly object StaticLock = new object();

		private const string MklTypeName = "MathNet.Numerics.Providers.MKL.LinearAlgebra.MklLinearAlgebraControl, MathNet.Numerics.Providers.MKL";

		private static readonly ProviderProbe<ILinearAlgebraProvider> MklProbe = new ProviderProbe<ILinearAlgebraProvider>("MathNet.Numerics.Providers.MKL.LinearAlgebra.MklLinearAlgebraControl, MathNet.Numerics.Providers.MKL", AppSwitches.DisableMklNativeProvider);

		private const string OpenBlasTypeName = "MathNet.Numerics.Providers.OpenBLAS.LinearAlgebra.OpenBlasLinearAlgebraControl, MathNet.Numerics.Providers.OpenBLAS";

		private static readonly ProviderProbe<ILinearAlgebraProvider> OpenBlasProbe = new ProviderProbe<ILinearAlgebraProvider>("MathNet.Numerics.Providers.OpenBLAS.LinearAlgebra.OpenBlasLinearAlgebraControl, MathNet.Numerics.Providers.OpenBLAS", AppSwitches.DisableOpenBlasNativeProvider);

		private const string CudaTypeName = "MathNet.Numerics.Providers.CUDA.LinearAlgebra.CudaLinearAlgebraControl, MathNet.Numerics.Providers.CUDA";

		private static readonly ProviderProbe<ILinearAlgebraProvider> CudaProbe = new ProviderProbe<ILinearAlgebraProvider>("MathNet.Numerics.Providers.CUDA.LinearAlgebra.CudaLinearAlgebraControl, MathNet.Numerics.Providers.CUDA", AppSwitches.DisableCudaNativeProvider);

		public static string HintPath { get; set; }

		public static ILinearAlgebraProvider Provider
		{
			get
			{
				if (_linearAlgebraProvider == null)
				{
					lock (StaticLock)
					{
						if (_linearAlgebraProvider == null)
						{
							UseDefault();
						}
					}
				}
				return _linearAlgebraProvider;
			}
			set
			{
				value.InitializeVerify();
				_linearAlgebraProvider = value;
			}
		}

		public static void UseManaged()
		{
			Provider = ManagedLinearAlgebraProvider.Instance;
		}

		public static void UseNativeMKL()
		{
			Provider = MklProbe.Create();
		}

		public static bool TryUseNativeMKL()
		{
			return TryUse(MklProbe.TryCreate());
		}

		public static void UseNativeCUDA()
		{
			Provider = CudaProbe.Create();
		}

		public static bool TryUseNativeCUDA()
		{
			return TryUse(CudaProbe.TryCreate());
		}

		public static void UseNativeOpenBLAS()
		{
			Provider = OpenBlasProbe.Create();
		}

		public static bool TryUseNativeOpenBLAS()
		{
			return TryUse(OpenBlasProbe.TryCreate());
		}

		public static bool TryUseNative()
		{
			if (AppSwitches.DisableNativeProviders || AppSwitches.DisableNativeProviderProbing)
			{
				return false;
			}
			if (!TryUseNativeMKL() && !TryUseNativeOpenBLAS())
			{
				return TryUseNativeCUDA();
			}
			return true;
		}

		public static bool TryUse(ILinearAlgebraProvider provider)
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
			string environmentVariable = Environment.GetEnvironmentVariable("MathNetNumericsLAProvider");
			switch ((environmentVariable != null) ? environmentVariable.ToUpperInvariant() : string.Empty)
			{
			case "MKL":
				UseNativeMKL();
				break;
			case "CUDA":
				UseNativeCUDA();
				break;
			case "OPENBLAS":
				UseNativeOpenBLAS();
				break;
			default:
				UseBest();
				break;
			}
		}

		public static void FreeResources()
		{
			Provider.FreeResources();
		}
	}
}
