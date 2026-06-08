using System;
using System.Globalization;
using System.IO;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces.Internal;
using Amazon.RuntimeDependencies;
using Amazon.Util.Internal;
using ThirdParty.RuntimeBackports;

namespace AWSSDK.Runtime.Internal.Util
{
	public static class ChecksumCRTWrapper
	{
		internal const string CRT_WRAPPER_ASSEMBLY_NAME = "AWSSDK.Extensions.CrtIntegration";

		private const string CRT_WRAPPER_NUGET_PACKAGE_NAME = "AWSSDK.Extensions.CrtIntegration";

		internal const string CRT_WRAPPER_CLASS_NAME = "AWSSDK.Extensions.CrtIntegration.CrtChecksums";

		private static readonly object _lock = new object();

		private static volatile IChecksumProvider _instance;

		private static bool? _isAvailable;

		private static readonly byte[] _emptyArray = new byte[0];

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		private static IChecksumProvider Instance
		{
			get
			{
				if (_instance != null)
				{
					return _instance;
				}
				lock (_lock)
				{
					if (_instance == null)
					{
						_instance = GlobalRuntimeDependencyRegistry.Instance.GetInstance<IChecksumProvider>("AWSSDK.Extensions.CrtIntegration", "AWSSDK.Extensions.CrtIntegration.CrtChecksums", new CreateInstanceContext(new CheckSumProviderContext()));
						if (_instance != null)
						{
							return _instance;
						}
						try
						{
							_instance = ServiceClientHelpers.LoadTypeFromAssembly("AWSSDK.Extensions.CrtIntegration", "AWSSDK.Extensions.CrtIntegration.CrtChecksums").GetConstructor(new Type[0]).Invoke(null) as IChecksumProvider;
						}
						catch (Exception ex)
						{
							if (InternalSDKUtils.IsRunningNativeAot())
							{
								throw new MissingRuntimeDependencyException("AWSSDK.Extensions.CrtIntegration", "AWSSDK.Extensions.CrtIntegration.CrtChecksums", "RegisterChecksumProvider");
							}
							if (ex is FileNotFoundException)
							{
								throw new AWSCommonRuntimeException(string.Format(CultureInfo.InvariantCulture, "Attempting to handle a request that requires additional checksums. Add a reference to the AWSSDK.Extensions.CrtIntegration NuGet package to your project to include the AWS Common Runtime checksum implementation."));
							}
							throw;
						}
					}
				}
				return _instance;
			}
		}

		public static bool IsCrtAvailable()
		{
			if (_isAvailable.HasValue)
			{
				return _isAvailable.Value;
			}
			lock (_lock)
			{
				if (_isAvailable.HasValue)
				{
					return _isAvailable.Value;
				}
				try
				{
					if (Instance != null)
					{
						Instance.Crc64NVME(_emptyArray);
						_isAvailable = true;
					}
					else
					{
						_isAvailable = false;
					}
				}
				catch (Exception ex)
				{
					Logger.GetLogger(typeof(ChecksumCRTWrapper)).Debug(ex, "Unable to use the AWS Common Runtime checksum implementation: {0}", ex.Message);
					_isAvailable = false;
				}
				return _isAvailable.Value;
			}
		}

		public static string Crc32(byte[] source)
		{
			return Instance.Crc32(source);
		}

		public static uint Crc32(byte[] source, uint previous)
		{
			return Instance.Crc32(source, previous);
		}

		public static string Crc32C(byte[] source)
		{
			return Instance.Crc32C(source);
		}

		public static uint Crc32C(byte[] source, uint previous)
		{
			return Instance.Crc32C(source, previous);
		}

		public static string Crc64NVME(byte[] source)
		{
			return Instance.Crc64NVME(source);
		}

		public static ulong Crc64NVME(byte[] source, ulong previous)
		{
			return Instance.Crc64NVME(source, previous);
		}
	}
}
