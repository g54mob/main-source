using System;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Controllers;
using NSMedieval.Dialogs.Data;
using NSMedieval.Serialization;
using NSMedieval.Utils.TimeHelpers;
using NSMedieval.WorldMap;
using UnityEngine;

namespace Managers
{
	[FVSerializableKey("NewsData", "")]
	public class NewsData : IFVSerializable
	{
		private readonly uint id;

		private string message;

		private string iconName;

		private string tooltip;

		private DialogContent dialogContent;

		private TimeInterval activeTimeInterval;

		private Vector3 jumpToPosition;

		private int jumpToPositionOptionIndex;

		private IWorldMapPlaceReference jumpToWorldMapMarker;

		public uint Id => id;

		public string Message => message;

		public string IconName => iconName;

		public string Tooltip => tooltip;

		public DialogContent DialogContent => dialogContent;

		public Vector3 JumpToPosition => jumpToPosition;

		public bool HasExpired => activeTimeInterval.HasEnded;

		public IWorldMapPlaceReference JumpToWorldMapMarker
		{
			get
			{
				return jumpToWorldMapMarker;
			}
			set
			{
				jumpToWorldMapMarker = value;
			}
		}

		public int JumpToPositionOptionIndex
		{
			get
			{
				return jumpToPositionOptionIndex;
			}
			set
			{
				jumpToPositionOptionIndex = value;
			}
		}

		public NewsData(string message, string iconName, string tooltip, DialogContent dialogContent, TimeInterval? activeTimeInterval = null)
		{
			id = GlobalSaveController.CurrentVillageData.NewsMessageIdProvider.GetNextId();
			this.message = message;
			this.iconName = iconName;
			this.tooltip = tooltip;
			this.activeTimeInterval = activeTimeInterval ?? TimeInterval.FromNowHours(999);
			this.dialogContent = dialogContent;
			jumpToPosition = new Vector3(float.NaN, float.NaN, float.NaN);
		}

		public NewsData(string message, string iconName, string tooltip, DialogContent dialogContent, Vector3 jumpToPosition, int jumpToPositionOptionIndex, TimeInterval? activeTimeInterval = null)
			: this(message, iconName, tooltip, dialogContent, activeTimeInterval)
		{
			this.jumpToPosition = jumpToPosition;
			this.jumpToPositionOptionIndex = jumpToPositionOptionIndex;
		}

		public NewsData(string message, string iconName, string tooltip, DialogContent dialogContent, IWorldMapPlaceReference jumpToWorldMapMarker, int jumpToPositionOptionIndex, TimeInterval? activeTimeInterval = null)
			: this(message, iconName, tooltip, dialogContent, activeTimeInterval)
		{
			this.jumpToWorldMapMarker = jumpToWorldMapMarker;
			this.jumpToPositionOptionIndex = jumpToPositionOptionIndex;
		}

		public void Localize()
		{
			Format(LocalizeKey, skipImage: true);
			static string LocalizeKey(string locKey)
			{
				return MonoSingleton<LocalizationController>.Instance.GetText(locKey);
			}
		}

		public void Replace(string src, string dest)
		{
			Format(ReplaceText);
			string ReplaceText(string text)
			{
				return text.Replace(src, dest);
			}
		}

		public void Format(Func<string, string> formatFunction, bool skipImage = false)
		{
			dialogContent.Format(formatFunction, skipImage);
			message = NullCheckedFormatFunc(message);
			if (!skipImage)
			{
				iconName = NullCheckedFormatFunc(iconName);
			}
			tooltip = NullCheckedFormatFunc(tooltip);
			string NullCheckedFormatFunc(string text)
			{
				if (text != null)
				{
					return formatFunction(text);
				}
				return null;
			}
		}

		public bool HasJumpTo(int chosenOptionIndex)
		{
			if (jumpToPositionOptionIndex == chosenOptionIndex)
			{
				if (float.IsNaN(jumpToPosition.x))
				{
					return jumpToWorldMapMarker != null;
				}
				return true;
			}
			return false;
		}

		public void Serialize(FVSerializer serializer)
		{
			serializer.Write("id", id);
			serializer.Write("message", message);
			serializer.Write("iconName", iconName);
			serializer.Write("tooltip", tooltip);
			serializer.Write("dialogContent", dialogContent);
			serializer.Write("activeTimeInterval", activeTimeInterval);
			serializer.Write("jumpToPosition", jumpToPosition);
			serializer.Write("jumpToPositionOptionIndex", jumpToPositionOptionIndex);
			serializer.Write("jumpToWorldMapMarker", jumpToWorldMapMarker);
		}

		public NewsData(FVDeserializer deserializer)
		{
			id = deserializer.ReadUInt("id");
			message = deserializer.ReadString("message");
			iconName = deserializer.ReadString("iconName");
			tooltip = deserializer.ReadString("tooltip");
			dialogContent = deserializer.ReadObject<DialogContent>("dialogContent");
			activeTimeInterval = deserializer.ReadObject<TimeInterval>("activeTimeInterval");
			jumpToPosition = deserializer.ReadVector3("jumpToPosition", new Vector3(float.NaN, float.NaN, float.NaN));
			jumpToPositionOptionIndex = deserializer.ReadInt("jumpToPositionOptionIndex", -1);
			jumpToWorldMapMarker = deserializer.ReadObject<WorldMapMarkerReference>("jumpToWorldMapMarker");
		}
	}
}
