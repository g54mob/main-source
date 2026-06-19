using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Internal
{
	internal class InstallationIdHelper
	{
		private readonly object _installationIdLock;

		private string? _installationId;

		public InstallationIdHelper(SentryOptions options)
		{
			_003Coptions_003EP = options;
			_installationIdLock = new object();
			base._002Ector();
		}

		public string? TryGetInstallationId()
		{
			if (!string.IsNullOrWhiteSpace(_installationId))
			{
				return _installationId;
			}
			lock (_installationIdLock)
			{
				if (!string.IsNullOrWhiteSpace(_installationId))
				{
					return _installationId;
				}
				string text = TryGetPersistentInstallationId() ?? TryGetHardwareInstallationId() ?? GetMachineNameInstallationId();
				if (!string.IsNullOrWhiteSpace(text))
				{
					_003Coptions_003EP.LogDebug("Resolved installation ID '{0}'.", text);
				}
				else
				{
					_003Coptions_003EP.LogDebug("Failed to resolve installation ID.");
				}
				return _installationId = text;
			}
		}

		private string? TryGetPersistentInstallationId()
		{
			if (_003Coptions_003EP.DisableFileWrite)
			{
				_003Coptions_003EP.LogDebug("File write has been disabled via the options. Skipping trying to get persistent installation ID.");
				return null;
			}
			try
			{
				string text = Path.Combine(_003Coptions_003EP.CacheDirectoryPath ?? Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sentry", _003Coptions_003EP.Dsn.GetHashString());
				IFileSystem fileSystem = _003Coptions_003EP.FileSystem;
				if (!fileSystem.CreateDirectory(text))
				{
					_003Coptions_003EP.LogDebug("Failed to create a directory for installation ID file ({0}).", text);
					return null;
				}
				_003Coptions_003EP.LogDebug("Created directory for installation ID file ({0}).", text);
				string text2 = Path.Combine(text, ".installation");
				if (fileSystem.FileExists(text2))
				{
					return fileSystem.ReadAllTextFromFile(text2);
				}
				_003Coptions_003EP.LogDebug("File containing installation ID does not exist ({0}).", text2);
				string text3 = Guid.NewGuid().ToString();
				if (!fileSystem.WriteAllTextToFile(text2, text3))
				{
					_003Coptions_003EP.LogDebug("Failed to write Installation ID to file ({0}).", text2);
					return null;
				}
				_003Coptions_003EP.LogDebug("Saved installation ID '{0}' to file '{1}'.", text3, text2);
				return text3;
			}
			catch (Exception exception)
			{
				_003Coptions_003EP.LogError(exception, "Failed to resolve persistent installation ID.");
				return null;
			}
		}

		private string? TryGetHardwareInstallationId()
		{
			try
			{
				string text = (from nic in NetworkInterface.GetAllNetworkInterfaces()
					where nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback
					select nic.GetPhysicalAddress().ToString()).FirstOrDefault();
				if (string.IsNullOrWhiteSpace(text))
				{
					_003Coptions_003EP.LogError("Failed to find an appropriate network interface for installation ID.");
					return null;
				}
				return text;
			}
			catch (Exception exception)
			{
				_003Coptions_003EP.LogError(exception, "Failed to resolve hardware installation ID.");
				return null;
			}
		}

		internal static string GetMachineNameInstallationId()
		{
			return Environment.MachineName.GetHashString();
		}
	}
}
