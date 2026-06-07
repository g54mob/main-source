using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Exceptions;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer.Exceptions;
using Assets.Scripts.Storage;
using Assets.Scripts.UI;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Cache;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class NetworkAircraftLoader
	{
		public delegate UniTask LoadCompleteCallback(AircraftScript craft, bool success, Exception exception);

		private static class Profile
		{
			public static readonly ProfilerMarker ComputeHash = new ProfilerMarker("NetworkAircraftLoader.ComputeHash");

			public static readonly ProfilerMarker ContainsHash = new ProfilerMarker("NetworkAircraftLoader.ContainsHash");

			public static readonly ProfilerMarker LoadAircraftData = new ProfilerMarker("NetworkAircraftLoader.LoadAircraftFromBytes Load Aircraft Data");
		}

		private static FileCache _cache;

		private LoadCompleteCallback _loadCompleteCallback;

		private NetworkAircraftScript _networkAircraft;

		private Action<AircraftScript> _onInitialized;

		private IAircraftLoadingStatus _status;

		public static string CacheRootPath => GameData.GetPath("Cache", "Multiplayer");

		public XElement CraftXml { get; private set; }

		public NetworkAircraftLoader(NetworkAircraftScript networkAircraft, FlightScenePlayer player, LoadCompleteCallback loadCompleteCallback, IAircraftLoadingStatus status)
		{
			if (_cache == null)
			{
				_cache = new FileCache(Path.Combine(CacheRootPath, player.NetworkPlayer.OwnerId.ToString()), 50000000L);
			}
			_networkAircraft = networkAircraft;
			_loadCompleteCallback = loadCompleteCallback;
			_status = status;
		}

		public static string ComputeHash(byte[] data)
		{
			using (Profile.ComputeHash.Auto())
			{
				using SHA256 sHA = SHA256.Create();
				return Convert.ToBase64String(sHA.ComputeHash(data));
			}
		}

		public bool ContainsHash(string hash)
		{
			using (Profile.ContainsHash.Auto())
			{
				return _cache.ContainsFile(hash);
			}
		}

		public async UniTask LoadAircraft(byte[] craftXmlBytes, string hash, int maxPartCount, float maxCraftSize)
		{
			await LoadAircraftFromBytes(craftXmlBytes, maxPartCount, maxCraftSize);
			if (!ContainsHash(hash))
			{
				_cache.AddOrUpdateBinary(hash, craftXmlBytes);
				_cache.SaveMetaData();
			}
		}

		public async UniTask LoadAircraftFromCache(string hash)
		{
			byte[] binary = _cache.GetBinary(hash);
			await LoadAircraftFromBytes(binary, 0, 0f);
		}

		private async UniTask LoadAircraftFromBytes(byte[] craftXmlBytes, int maxPartCount, float maxCraftSize)
		{
			AircraftData aircraftData = await UniTask.RunOnThreadPool(delegate
			{
				using (Profile.LoadAircraftData.Auto())
				{
					CraftXml = Utility.LoadCompressedCraftXml(craftXmlBytes);
					return new AircraftData(CraftXml, CraftLoadContext.Flight);
				}
			});
			if (maxPartCount > 0 && aircraftData.Assembly.Parts.Count > maxPartCount)
			{
				throw new NetworkAircraftLoadException($"Could not load craft because it has {aircraftData.Assembly.Parts.Count} parts, which exceeds the maximum allowed part count for the server of {maxPartCount}.");
			}
			if (maxCraftSize > 0f && aircraftData.Size.magnitude > maxCraftSize)
			{
				throw new NetworkAircraftLoadException($"Could not load craft because its physical size ({aircraftData.Size.magnitude:n0}m) exceeds the server limit of {maxCraftSize:n0}m.");
			}
			Debug.Log((_networkAircraft.Player.IsLocal ? "Local Player" : "Remote Player") + " '" + _networkAircraft.Player.Name + "' loading craft '" + aircraftData.Name + "' " + (string.IsNullOrEmpty(aircraftData.Url) ? string.Empty : aircraftData.Url));
			PartData.PartCreationInfo partCreationInfo = new PartData.PartCreationInfo();
			partCreationInfo.RemoteAircraft = !_networkAircraft.IsOwner;
			AircraftScript aircraftScript = _networkAircraft.gameObject.AddComponent<AircraftScript>();
			aircraftScript.Initialize(aircraftData, _networkAircraft.Player.TeamId, (AircraftScript x) => new PlayerTarget(_networkAircraft.Player), partCreationInfo.RemoteAircraft, _networkAircraft);
			UniTask.Void(async delegate
			{
				Exception exception = null;
				try
				{
					await aircraftScript.Aircraft.Assembly.CreateGameObjectsMultipleFramesAsync(aircraftScript, partCreationInfo, aircraftScript.Children, activateCraft: false, _status);
				}
				catch (CraftLoadAbortedException ex)
				{
					exception = ex;
				}
				catch (Exception ex2)
				{
					Debug.LogException(ex2);
					exception = ex2;
				}
				try
				{
					await _loadCompleteCallback(aircraftScript, exception == null, exception);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
					Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, "An unexpected and unhandled exception occurred loading a craft.");
				}
			});
		}
	}
}
