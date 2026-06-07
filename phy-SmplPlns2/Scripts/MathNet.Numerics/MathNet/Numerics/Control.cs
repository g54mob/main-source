using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Providers.FourierTransform;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Providers.SparseSolver;

namespace MathNet.Numerics
{
	public static class Control
	{
		private static int _maxDegreeOfParallelism;

		private static int _parallelizeOrder;

		private static int _parallelizeElements;

		private static string _nativeProviderHintPath;

		public static bool CheckDistributionParameters { get; set; }

		public static bool ThreadSafeRandomNumberGenerators { get; set; }

		public static string NativeProviderPath
		{
			get
			{
				return _nativeProviderHintPath;
			}
			set
			{
				_nativeProviderHintPath = value;
				LinearAlgebraControl.HintPath = value;
				FourierTransformControl.HintPath = value;
				SparseSolverControl.HintPath = value;
			}
		}

		public static int MaxDegreeOfParallelism
		{
			get
			{
				return _maxDegreeOfParallelism;
			}
			set
			{
				_maxDegreeOfParallelism = Math.Max(1, Math.Min(1024, value));
				LinearAlgebraControl.Provider.InitializeVerify();
				FourierTransformControl.Provider.InitializeVerify();
				SparseSolverControl.Provider.InitializeVerify();
			}
		}

		public static TaskScheduler TaskScheduler { get; set; }

		internal static int ParallelizeOrder
		{
			get
			{
				return _parallelizeOrder;
			}
			set
			{
				_parallelizeOrder = Math.Max(3, value);
			}
		}

		internal static int ParallelizeElements
		{
			get
			{
				return _parallelizeElements;
			}
			set
			{
				_parallelizeElements = Math.Max(3, value);
			}
		}

		static Control()
		{
			ConfigureAuto();
		}

		public static void ConfigureAuto()
		{
			CheckDistributionParameters = true;
			ThreadSafeRandomNumberGenerators = true;
			_maxDegreeOfParallelism = Environment.ProcessorCount;
			_parallelizeOrder = 64;
			_parallelizeElements = 300;
			TaskScheduler = TaskScheduler.Default;
		}

		public static void UseManaged()
		{
			LinearAlgebraControl.UseManaged();
			FourierTransformControl.UseManaged();
			SparseSolverControl.UseManaged();
		}

		public static void UseDefaultProviders()
		{
			if (AppSwitches.DisableNativeProviders)
			{
				UseManaged();
				return;
			}
			LinearAlgebraControl.UseDefault();
			FourierTransformControl.UseDefault();
			SparseSolverControl.UseDefault();
		}

		public static void UseBestProviders()
		{
			if (AppSwitches.DisableNativeProviders || AppSwitches.DisableNativeProviderProbing)
			{
				UseManaged();
				return;
			}
			LinearAlgebraControl.UseBest();
			FourierTransformControl.UseBest();
			SparseSolverControl.UseBest();
		}

		public static void UseNativeMKL()
		{
			LinearAlgebraControl.UseNativeMKL();
			FourierTransformControl.UseNativeMKL();
			SparseSolverControl.UseNativeMKL();
		}

		public static bool TryUseNativeMKL()
		{
			bool num = LinearAlgebraControl.TryUseNativeMKL();
			bool flag = FourierTransformControl.TryUseNativeMKL();
			bool flag2 = SparseSolverControl.TryUseNativeMKL();
			return num || flag || flag2;
		}

		public static void UseNativeCUDA()
		{
			LinearAlgebraControl.UseNativeCUDA();
		}

		public static bool TryUseNativeCUDA()
		{
			return LinearAlgebraControl.TryUseNativeCUDA();
		}

		public static void UseNativeOpenBLAS()
		{
			LinearAlgebraControl.UseNativeOpenBLAS();
		}

		public static bool TryUseNativeOpenBLAS()
		{
			return LinearAlgebraControl.TryUseNativeOpenBLAS();
		}

		public static bool TryUseNative()
		{
			if (AppSwitches.DisableNativeProviders || AppSwitches.DisableNativeProviderProbing)
			{
				return false;
			}
			bool num = LinearAlgebraControl.TryUseNative();
			bool flag = FourierTransformControl.TryUseNative();
			bool flag2 = SparseSolverControl.TryUseNative();
			return num || flag || flag2;
		}

		public static void FreeResources()
		{
			LinearAlgebraControl.FreeResources();
			FourierTransformControl.FreeResources();
			SparseSolverControl.FreeResources();
		}

		public static void UseSingleThread()
		{
			_maxDegreeOfParallelism = 1;
			ThreadSafeRandomNumberGenerators = false;
			LinearAlgebraControl.Provider.InitializeVerify();
			FourierTransformControl.Provider.InitializeVerify();
			SparseSolverControl.Provider.InitializeVerify();
		}

		public static void UseMultiThreading()
		{
			_maxDegreeOfParallelism = Environment.ProcessorCount;
			ThreadSafeRandomNumberGenerators = true;
			LinearAlgebraControl.Provider.InitializeVerify();
			FourierTransformControl.Provider.InitializeVerify();
			SparseSolverControl.Provider.InitializeVerify();
		}

		public static string Describe()
		{
			AssemblyInformationalVersionAttribute assemblyInformationalVersionAttribute = typeof(Control).GetTypeInfo().Assembly.GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("Math.NET Numerics Configuration:");
			stringBuilder.AppendLine("Version " + assemblyInformationalVersionAttribute?.InformationalVersion);
			stringBuilder.AppendLine("Built for .NET Framework 4.8");
			stringBuilder.AppendLine($"Linear Algebra Provider: {LinearAlgebraControl.Provider}");
			stringBuilder.AppendLine($"Fourier Transform Provider: {FourierTransformControl.Provider}");
			stringBuilder.AppendLine($"Sparse Solver Provider: {SparseSolverControl.Provider}");
			stringBuilder.AppendLine($"Max Degree of Parallelism: {MaxDegreeOfParallelism}");
			stringBuilder.AppendLine($"Parallelize Elements: {ParallelizeElements}");
			stringBuilder.AppendLine($"Parallelize Order: {ParallelizeOrder}");
			stringBuilder.AppendLine($"Check Distribution Parameters: {CheckDistributionParameters}");
			stringBuilder.AppendLine($"Thread-Safe RNGs: {ThreadSafeRandomNumberGenerators}");
			stringBuilder.AppendLine("Operating System: " + RuntimeInformation.OSDescription);
			stringBuilder.AppendLine($"Operating System Architecture: {RuntimeInformation.OSArchitecture}");
			stringBuilder.AppendLine("Framework: " + RuntimeInformation.FrameworkDescription);
			stringBuilder.AppendLine($"Process Architecture: {RuntimeInformation.ProcessArchitecture}");
			string environmentVariable = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
			if (!string.IsNullOrEmpty(environmentVariable))
			{
				stringBuilder.AppendLine("Processor Architecture: " + environmentVariable);
			}
			string environmentVariable2 = Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER");
			if (!string.IsNullOrEmpty(environmentVariable2))
			{
				stringBuilder.AppendLine("Processor Identifier: " + environmentVariable2);
			}
			return stringBuilder.ToString();
		}
	}
}
