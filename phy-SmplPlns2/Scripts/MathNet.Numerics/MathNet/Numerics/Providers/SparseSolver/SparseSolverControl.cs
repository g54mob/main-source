using System;

namespace MathNet.Numerics.Providers.SparseSolver
{
	public static class SparseSolverControl
	{
		private const string EnvVarSSProvider = "MathNetNumericsSSProvider";

		private static ISparseSolverProvider _sparseSolverProvider;

		private static readonly object StaticLock = new object();

		private const string MklTypeName = "MathNet.Numerics.Providers.MKL.SparseSolver.MklSparseSolverControl, MathNet.Numerics.Providers.MKL";

		private static readonly ProviderProbe<ISparseSolverProvider> MklProbe = new ProviderProbe<ISparseSolverProvider>("MathNet.Numerics.Providers.MKL.SparseSolver.MklSparseSolverControl, MathNet.Numerics.Providers.MKL", AppSwitches.DisableMklNativeProvider);

		public static string HintPath { get; set; }

		public static ISparseSolverProvider Provider
		{
			get
			{
				if (_sparseSolverProvider == null)
				{
					lock (StaticLock)
					{
						if (_sparseSolverProvider == null)
						{
							UseDefault();
						}
					}
				}
				return _sparseSolverProvider;
			}
			set
			{
				value.InitializeVerify();
				_sparseSolverProvider = value;
			}
		}

		public static void UseManaged()
		{
			Provider = ManagedSparseSolverProvider.Instance;
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

		public static bool TryUse(ISparseSolverProvider provider)
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
			string environmentVariable = Environment.GetEnvironmentVariable("MathNetNumericsSSProvider");
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
