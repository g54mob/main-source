using System;
using System.Text;
using HeathenEngineering.SteamworksIntegration.API;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.SteamworksIntegration
{
	[HelpURL("https://kb.heathenengineering.com/assets/steamworks/data-models")]
	public abstract class DataModel : ScriptableObject
	{
		public string extension;

		[Header("Events")]
		public UnityEvent evtDataUpdated = new UnityEvent();

		[NonSerialized]
		public RemoteStorageFile[] availableFiles;

		public abstract Type DataType { get; }

		public void Refresh()
		{
			availableFiles = RemoteStorage.Client.GetFiles(extension);
		}

		public abstract void LoadByteArray(byte[] data);

		public abstract void LoadJson(string json);

		public abstract void LoadFileAddress(RemoteStorageFile address);

		public abstract void LoadFileAddress(string address);

		public abstract void LoadFileAddressAsync(RemoteStorageFile address, Action<bool> callback);

		public abstract void LoadFileAddressAsync(string address, Action<bool> callback);

		public abstract byte[] ToByteArray();

		public abstract string ToJson();

		public abstract bool Save(string filename);

		public abstract void SaveAsync(string filename, Action<RemoteStorageFileWriteAsyncComplete_t, bool> callback);
	}
	public abstract class DataModel<T> : DataModel
	{
		public T data;

		public override Type DataType => typeof(T);

		public override void LoadByteArray(byte[] data)
		{
			this.data = JsonUtility.FromJson<T>(Encoding.UTF8.GetString(data));
			evtDataUpdated.Invoke();
		}

		public override void LoadJson(string json)
		{
			data = JsonUtility.FromJson<T>(json);
			evtDataUpdated.Invoke();
		}

		public override string ToJson()
		{
			return JsonUtility.ToJson(data);
		}

		public override byte[] ToByteArray()
		{
			return Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
		}

		public override void SaveAsync(string filename, Action<RemoteStorageFileWriteAsyncComplete_t, bool> callback)
		{
			if (filename.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
			{
				RemoteStorage.Client.FileWriteAsync(filename, ToByteArray(), callback);
			}
			else
			{
				RemoteStorage.Client.FileWriteAsync(filename + extension, ToByteArray(), callback);
			}
		}

		public override bool Save(string filename)
		{
			if (filename.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
			{
				return RemoteStorage.Client.FileWrite(filename, ToByteArray());
			}
			return RemoteStorage.Client.FileWrite(filename + extension, ToByteArray());
		}

		public override void LoadFileAddress(RemoteStorageFile address)
		{
			data = RemoteStorage.Client.FileReadJson<T>(address.name, Encoding.UTF8);
			evtDataUpdated?.Invoke();
		}

		public override void LoadFileAddressAsync(RemoteStorageFile address, Action<bool> callback)
		{
			RemoteStorage.Client.FileReadAsync(address.name, delegate(byte[] r, bool e)
			{
				if (!e)
				{
					string json = Encoding.UTF8.GetString(r);
					data = JsonUtility.FromJson<T>(json);
					evtDataUpdated?.Invoke();
				}
				else
				{
					callback?.Invoke(!e);
				}
			});
		}

		public override void LoadFileAddress(string address)
		{
			data = RemoteStorage.Client.FileReadJson<T>(address, Encoding.UTF8);
			evtDataUpdated?.Invoke();
		}

		public override void LoadFileAddressAsync(string address, Action<bool> callback)
		{
			RemoteStorage.Client.FileReadAsync(address, delegate(byte[] r, bool e)
			{
				if (!e)
				{
					string json = Encoding.UTF8.GetString(r);
					data = JsonUtility.FromJson<T>(json);
					evtDataUpdated?.Invoke();
				}
				else
				{
					callback?.Invoke(!e);
				}
			});
		}
	}
}
