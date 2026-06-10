using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval
{
	public class WarningMessageManager : MonoSingleton<WarningMessageManager>, IObserver
	{
		private const int ViewPoolSize = 5;

		[SerializeField]
		private List<MessageTypePrefab> viewPrefabByMessageType;

		[SerializeField]
		private List<MessageTypeTransform> transformByMessageType;

		private readonly Dictionary<WarningMessageCategory, WarningMessageLayoutItemView> prefabsByTypeDict = new Dictionary<WarningMessageCategory, WarningMessageLayoutItemView>();

		private readonly Dictionary<WarningMessageCategory, Transform> transformByTypeDict = new Dictionary<WarningMessageCategory, Transform>();

		private readonly Dictionary<WarningMessageCategory, List<WarningMessageLayoutItemView>> viewPool = new Dictionary<WarningMessageCategory, List<WarningMessageLayoutItemView>>();

		private readonly Dictionary<WarningMessageData, WarningMessageLayoutItemView> messagesShowing = new Dictionary<WarningMessageData, WarningMessageLayoutItemView>();

		public List<WarningMessageData> GetMessagesShowing()
		{
			return messagesShowing.Keys.ToList();
		}

		public bool IsMessageShowing(WarningMessageData message)
		{
			return messagesShowing.ContainsKey(message);
		}

		private static WarningMessageLayoutItemView CreateNewView(WarningMessageLayoutItemView prefab, Transform parent)
		{
			WarningMessageLayoutItemView warningMessageLayoutItemView = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, parent);
			warningMessageLayoutItemView.gameObject.SetActive(value: false);
			return warningMessageLayoutItemView;
		}

		private void Start()
		{
			MonoSingleton<WarningMessageController>.Instance.ShowMessageEvent += OnShowWarningMessage;
			MonoSingleton<WarningMessageController>.Instance.UpdateMessageEvent += OnUpdateWarningMessage;
			MonoSingleton<WarningMessageController>.Instance.HideMessageEvent += OnHideWarningMessage;
			prefabsByTypeDict.Clear();
			foreach (MessageTypePrefab item in viewPrefabByMessageType)
			{
				prefabsByTypeDict.Add(item.messageType, item.prefab);
			}
			transformByTypeDict.Clear();
			foreach (MessageTypeTransform item2 in transformByMessageType)
			{
				transformByTypeDict.Add(item2.messageType, item2.transform);
			}
			CreateViewPools(5);
		}

		private void OnDisable()
		{
			if (MonoSingleton<WarningMessageController>.IsInstantiated())
			{
				MonoSingleton<WarningMessageController>.Instance.ShowMessageEvent -= OnShowWarningMessage;
				MonoSingleton<WarningMessageController>.Instance.UpdateMessageEvent -= OnUpdateWarningMessage;
				MonoSingleton<WarningMessageController>.Instance.HideMessageEvent -= OnHideWarningMessage;
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (messagesShowing == null)
			{
				return;
			}
			foreach (WarningMessageData key in messagesShowing.Keys)
			{
				key.Dispose();
			}
			messagesShowing.Clear();
		}

		private void OnShowWarningMessage(WarningMessageData message)
		{
			WarningMessageLayoutItemView viewForMessage = GetViewForMessage(message);
			viewForMessage.SetData(message);
			viewForMessage.Show();
		}

		private void OnUpdateWarningMessage(WarningMessageData message)
		{
			WarningMessageLayoutItemView viewForMessage = GetViewForMessage(message, searchOnlyExisting: true);
			if (viewForMessage == null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(58, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WarningMessageManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot update message. View not found for warning message ");
					messageBuilder.AppendFormatted(message);
				}
				Log.Info(messageBuilder);
			}
			else
			{
				viewForMessage.SetData(message);
			}
		}

		private void OnHideWarningMessage(WarningMessageData message)
		{
			WarningMessageLayoutItemView viewForMessage = GetViewForMessage(message, searchOnlyExisting: true);
			if (viewForMessage == null)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(56, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WarningMessageManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Cannot hide message. View not found for warning message ");
					messageBuilder.AppendFormatted(message);
				}
				Log.Info(messageBuilder);
			}
			else
			{
				viewForMessage.Hide();
				messagesShowing.Remove(message);
				viewPool[message.Category].Remove(viewForMessage);
			}
		}

		private void CreateViewPools(int maxItems)
		{
			WarningMessageCategory[] warningMessageCategories = EnumValues.WarningMessageCategories;
			foreach (WarningMessageCategory warningMessageCategory in warningMessageCategories)
			{
				if (warningMessageCategory == WarningMessageCategory.None)
				{
					continue;
				}
				viewPool.Add(warningMessageCategory, new List<WarningMessageLayoutItemView>());
				bool isEnabled;
				if (!prefabsByTypeDict.ContainsKey(warningMessageCategory) || !transformByTypeDict.ContainsKey(warningMessageCategory))
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(90, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WarningMessageManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Can't create view pool for type ");
						messageBuilder.AppendFormatted(warningMessageCategory);
						messageBuilder.AppendLiteral(". No prefab of parent transform defined in ");
						messageBuilder.AppendFormatted(GetType().Name);
						messageBuilder.AppendLiteral(" component on ");
						messageBuilder.AppendFormatted(base.gameObject.name);
						messageBuilder.AppendLiteral(".");
					}
					Log.Error(messageBuilder);
				}
				else if (prefabsByTypeDict[warningMessageCategory] == null || transformByTypeDict[warningMessageCategory] == null)
				{
					FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(80, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\WarningMessageManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Can't create view pool for type ");
						messageBuilder.AppendFormatted(warningMessageCategory);
						messageBuilder.AppendLiteral(". No prefab or parent is null in ");
						messageBuilder.AppendFormatted(GetType().Name);
						messageBuilder.AppendLiteral(" component on ");
						messageBuilder.AppendFormatted(base.gameObject.name);
						messageBuilder.AppendLiteral(".");
					}
					Log.Error(messageBuilder);
				}
				else
				{
					for (int j = 0; j < maxItems; j++)
					{
						WarningMessageLayoutItemView item = CreateNewView(prefabsByTypeDict[warningMessageCategory], transformByTypeDict[warningMessageCategory]);
						viewPool[warningMessageCategory].Add(item);
					}
				}
			}
		}

		private WarningMessageLayoutItemView GetViewForMessage(WarningMessageData message, bool searchOnlyExisting = false)
		{
			if (messagesShowing.ContainsKey(message))
			{
				return messagesShowing[message];
			}
			if (searchOnlyExisting)
			{
				return null;
			}
			WarningMessageLayoutItemView viewFromPool = GetViewFromPool(message);
			messagesShowing.Add(message, viewFromPool);
			viewPool[message.Category].Remove(viewFromPool);
			return viewFromPool;
		}

		private WarningMessageLayoutItemView GetViewFromPool(WarningMessageData message)
		{
			WarningMessageCategory category = message.Category;
			if (viewPool == null || !viewPool.ContainsKey(category))
			{
				return null;
			}
			if (viewPool[message.Category].Count > 0)
			{
				return viewPool[message.Category].First();
			}
			WarningMessageLayoutItemView warningMessageLayoutItemView = CreateNewView(prefabsByTypeDict[category], transformByTypeDict[category]);
			viewPool[category].Add(warningMessageLayoutItemView);
			return warningMessageLayoutItemView;
		}
	}
}
