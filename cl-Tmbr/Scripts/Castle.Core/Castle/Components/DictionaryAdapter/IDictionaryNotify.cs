using System;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public interface IDictionaryNotify : INotifyPropertyChanging, INotifyPropertyChanged
	{
		bool CanNotify { get; }

		bool ShouldNotify { get; }

		IDisposable SuppressNotificationsBlock();

		void SuppressNotifications();

		void ResumeNotifications();
	}
}
