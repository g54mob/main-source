using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(menuName = "Motorways/NewsAndNotifications")]
	public class NewsAndNotificationData : ScriptableObject
	{
		[Tooltip("The individual news and notifications.")]
		[SerializeField]
		private List<NewsAndNotificationObject> _newsAndNotificationObjects;

		[NotNull]
		public List<NewsAndNotificationObject> GetNotifications(RuntimePlatform platform)
		{
			List<NewsAndNotificationObject> list = new List<NewsAndNotificationObject>();
			NewsAndNotificationObject.RuntimeVariant runtimeVariant = NewsAndNotificationObject.EnvironmentToVariant(AppContainer.Environment);
			foreach (NewsAndNotificationObject newsAndNotificationObject in _newsAndNotificationObjects)
			{
				if (newsAndNotificationObject.StartDateTime() < DateTime.UtcNow && newsAndNotificationObject.EndDateTime() > DateTime.UtcNow && newsAndNotificationObject.AvailablePlatform == platform && newsAndNotificationObject.AvailableVariant == runtimeVariant)
				{
					list.Add(newsAndNotificationObject);
				}
			}
			return list;
		}
	}
}
