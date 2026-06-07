using System.Collections;
using UnityEngine;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.NotificationServicesCore
{
	public abstract class NotificationBase : NativeObjectBase, INotification
	{
		[SerializeField]
		private string m_id;

		public string Id => null;

		public string Title => null;

		public string Subtitle => null;

		public string Body => null;

		public int Badge => 0;

		public IDictionary UserInfo => null;

		public string SoundFileName => null;

		public NotificationTriggerType TriggerType => default(NotificationTriggerType);

		public INotificationTrigger Trigger => null;

		public bool IsLaunchNotification => false;

		public NotificationIosProperties IosProperties => null;

		public NotificationAndroidProperties AndroidProperties => null;

		protected NotificationBase(string id)
		{
		}

		protected abstract string GetTitleInternal();

		protected abstract string GetSubtitleInternal();

		protected abstract string GetBodyInternal();

		protected abstract int GetBadgeInternal();

		protected abstract IDictionary GetUserInfoInternal();

		protected abstract string GetSoundFileNameInternal();

		protected abstract INotificationTrigger GetTriggerInternal();

		protected abstract bool GetIsLaunchNotificationInternal();

		protected abstract NotificationIosProperties GetIosPropertiesInternal();

		protected abstract NotificationAndroidProperties GetAndroidPropertiesInternal();

		public override string ToString()
		{
			return null;
		}
	}
}
