using System;
using System.Collections.Generic;

public class SteamCloud : LocalFileStorage
{
	public override void LoadAll(Action loadCompleteCallback)
	{
		foreach (string cloudFile in SteamworksShared.GetCloudFiles())
		{
			string playerId;
			string deviceId;
			IStorableTypeHandler handlerForFilename = _storableTypeHandlerRegistry.GetHandlerForFilename(cloudFile, out playerId, out deviceId);
			if (handlerForFilename == null)
			{
				LocalFileStorage.Log.Info("Found unrecognised file {0} in Steam Cloud.", cloudFile);
				continue;
			}
			byte[] array = SteamworksShared.ReadCloudFile(cloudFile);
			if (array == null)
			{
				LocalFileStorage.Log.Warn("The file {0} could not be read from Steam Cloud.", cloudFile);
				continue;
			}
			IStorable storable = handlerForFilename.Load(array);
			if (storable == null)
			{
				LocalFileStorage.Log.Warn("The file {0} was unable to be parsed as the type {1}.", cloudFile, handlerForFilename);
				continue;
			}
			storable.IsAuthoritative = true;
			if (!handlerForFilename.ProcessLoadedStorable(storable, playerId, deviceId))
			{
				_scope.Release(storable);
			}
		}
		base.LoadAll(loadCompleteCallback);
	}

	public override bool Store(string filename, byte[] data, NamedStoreCompleted storeCompleteCallback)
	{
		SteamworksShared.WriteCloudFile(filename, data);
		return base.Store(filename, data, storeCompleteCallback);
	}

	public override bool Delete(string filename)
	{
		SteamworksShared.DeleteCloudFile(filename);
		return base.Delete(filename);
	}

	public override bool DeletePlayer(string playerIdToDelete)
	{
		List<string> list = new List<string>();
		foreach (string cloudFile in SteamworksShared.GetCloudFiles())
		{
			if (_storableTypeHandlerRegistry.IsFilenameRecognized(cloudFile, out var playerId, out var _) && playerId == playerIdToDelete)
			{
				list.Add(cloudFile);
			}
		}
		foreach (string item in list)
		{
			SteamworksShared.DeleteCloudFile(item);
		}
		return base.DeletePlayer(playerIdToDelete);
	}
}
