using UnityEngine;

namespace ModApi.Ui
{
	public interface IFlyout
	{
		bool IsHidden { get; set; }

		bool IsOpen { get; }

		string Title { get; set; }

		RectTransform Transform { get; }

		float Width { get; set; }

		event FlyoutDelegate Closed;

		event FlyoutDelegate Closing;

		event FlyoutDelegate Opened;

		event FlyoutDelegate Opening;

		void AddClass(string className);

		void Close(bool immediate = false);

		void Open(bool immediate = false);

		void RemoveClass(string className);
	}
}
