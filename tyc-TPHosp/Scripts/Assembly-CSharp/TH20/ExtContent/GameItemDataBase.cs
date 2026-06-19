using UnityEngine;

namespace TH20.ExtContent
{
	public class GameItemDataBase
	{
		private string _itemContentID;

		public string ItemContentID => _itemContentID;

		public void Init(string contentID)
		{
			SetContentID(contentID);
		}

		public virtual void SetContentID(string contentID)
		{
			_itemContentID = contentID;
		}

		public virtual void OnLevelLoaded()
		{
		}

		public virtual bool HaveAssetsBeenLoaded()
		{
			return false;
		}

		public virtual bool AreAssetsUnloadable()
		{
			return true;
		}

		public virtual void UnloadAllAssets()
		{
		}

		public virtual bool ReloadAllAssets()
		{
			return true;
		}

		public virtual GameObject GetRootAssetGameObject()
		{
			return null;
		}

		public void LogError(EMessageType msgType, string param)
		{
			ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(msgType), _itemContentID, param));
		}

		public void LogError(EMessageType msgType)
		{
			ExtContentMessages.LogError(string.Format(ExtContentMessages.GetMessageString(msgType), _itemContentID));
		}

		public void LogMessage(EMessageType msgType, string param)
		{
			ExtContentMessages.LogDebug(string.Format(ExtContentMessages.GetMessageString(msgType), _itemContentID, param));
		}
	}
}
