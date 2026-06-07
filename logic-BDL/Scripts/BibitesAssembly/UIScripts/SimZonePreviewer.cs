using System.Collections.Generic;
using SettingScripts;
using UIScripts.UIReferences;
using UnityEngine;
using Utility;

namespace UIScripts
{
	public class SimZonePreviewer : MonoBehaviour
	{
		private ItemDictPool<ZoneSettings, ZonePreview> zonePreviews;

		public Transform previewHolder;

		public GameObject previewPrefab;

		public void InitPreview()
		{
			zonePreviews = new ItemDictPool<ZoneSettings, ZonePreview>(previewPrefab, previewHolder);
		}

		public void UpdateSettings(List<ZoneSettings> settings, int timeIndex = -1)
		{
			zonePreviews.RetireAll();
			foreach (ZoneSettings setting in settings)
			{
				zonePreviews.GetItemWithKey(setting).UpdatePoint(timeIndex);
			}
		}

		private void OnRectTransformDimensionsChange()
		{
			if (zonePreviews == null || zonePreviews.activeCount < 1)
			{
				return;
			}
			foreach (ZonePreview activeItems in zonePreviews.activeItemsList)
			{
				activeItems.OnParentRectTransformChange();
			}
		}
	}
}
