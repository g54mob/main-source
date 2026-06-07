using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using UnityEngine;

namespace Assets.Scripts.OperatingSystem
{
	public struct DirectXAdapterInfo
	{
		public string Description { get; }

		public Version DriverVersion { get; }

		public DateTime LastSeen { get; }

		public DirectXAdapterInfo(string description, Version version, DateTime lastSeen)
		{
			Description = description;
			DriverVersion = version;
			LastSeen = lastSeen;
		}

		public static List<DirectXAdapterInfo> QueryAll()
		{
			List<DirectXAdapterInfo> list = new List<DirectXAdapterInfo>();
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\DirectX\\");
				if (registryKey != null)
				{
					string[] subKeyNames = registryKey.GetSubKeyNames();
					foreach (string name in subKeyNames)
					{
						RegistryKey registryKey2 = registryKey.OpenSubKey(name);
						if (registryKey2 != null && ((long?)registryKey2.GetValue("AdapterLuid")).GetValueOrDefault() != 0L)
						{
							string description = (string)registryKey2.GetValue("Description");
							byte[] bytes = BitConverter.GetBytes((long)registryKey2.GetValue("DriverVersion"));
							Version version = new Version(BitConverter.ToInt16(bytes, 6), BitConverter.ToInt16(bytes, 4), BitConverter.ToInt16(bytes, 2), BitConverter.ToInt16(bytes, 0));
							DateTime lastSeen = DateTime.FromFileTimeUtc((long)registryKey2.GetValue("LastSeen"));
							list.Add(new DirectXAdapterInfo(description, version, lastSeen));
						}
					}
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return list;
		}

		public static string ToString(List<DirectXAdapterInfo> list)
		{
			if (list == null || list.Count == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("DirectX Adapters:");
			foreach (DirectXAdapterInfo item in list)
			{
				stringBuilder.Append("  ");
				stringBuilder.AppendLine(item.Description);
				stringBuilder.Append("     Driver Version: ");
				stringBuilder.AppendLine(item.DriverVersion.ToString());
				stringBuilder.Append("     Last Seen: ");
				stringBuilder.AppendLine(item.LastSeen.ToString("yyyy-MM-dd  HH:mm"));
			}
			return stringBuilder.ToString();
		}
	}
}
