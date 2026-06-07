using System.Collections.Generic;
using AirFishLab.ScrollingList.ContentManagement;
using UnityEngine;

namespace AirFishLab.ScrollingList
{
	public class ListSetupData
	{
		public readonly CircularScrollingList ScrollingList;

		public readonly ListSetting ListSetting;

		public readonly RectTransform RectTransform;

		public readonly Camera CanvasRefCamera;

		public readonly List<IListBox> ListBoxes;

		public readonly ListContentProvider ListContentProvider;

		public ListSetupData(CircularScrollingList scrollingList, ListSetting listSetting, RectTransform rectTransform, Camera canvasRefCamera, List<IListBox> listBoxes, ListContentProvider listContentProvider)
		{
			ScrollingList = scrollingList;
			ListSetting = listSetting;
			RectTransform = rectTransform;
			CanvasRefCamera = canvasRefCamera;
			ListBoxes = listBoxes;
			ListContentProvider = listContentProvider;
		}
	}
}
