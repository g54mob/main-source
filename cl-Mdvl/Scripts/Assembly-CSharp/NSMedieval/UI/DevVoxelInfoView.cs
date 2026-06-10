using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.DevConsole;
using NSMedieval.Map;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class DevVoxelInfoView : MonoSingleton<DevVoxelInfoView>
	{
		[SerializeField]
		private GameObject allContentObject;

		[SerializeField]
		private DevVoxelInfoLineView lineViewObject;

		[SerializeField]
		private GameObject currentVoxelMarker;

		[SerializeField]
		private GameObject raycastHitMarker;

		[SerializeField]
		private GameObject playerDevVoxelInfo;

		private List<DevVoxelInfoLineView> lineObjects = new List<DevVoxelInfoLineView>();

		private int visibleLines;

		private void Update()
		{
			if (MonoSingleton<World>.IsInstantiated() && raycastHitMarker != null && MonoSingleton<DevVoxelInfoController>.IsInstantiated())
			{
				raycastHitMarker.transform.position = MonoSingleton<DevVoxelInfoController>.Instance.LastHitPoint;
			}
		}

		public void ToggleDevVoxelInfoEvent(bool isEnabled)
		{
			allContentObject.SetActive(isEnabled);
			currentVoxelMarker.SetActive(isEnabled);
			raycastHitMarker.SetActive(isEnabled);
			playerDevVoxelInfo.SetActive(isEnabled);
			if (isEnabled)
			{
				ForceRebuildLayout();
			}
		}

		private void ForceRebuildLayout()
		{
			RectTransform[] componentsInChildren = GetComponentsInChildren<RectTransform>();
			if (componentsInChildren != null)
			{
				RectTransform[] array = componentsInChildren;
				for (int i = 0; i < array.Length; i++)
				{
					LayoutRebuilder.ForceRebuildLayoutImmediate(array[i]);
				}
			}
		}

		public void HoverGridPositionChanged(DevVoxelInfo devVoxelInfo)
		{
			visibleLines = 0;
			foreach (DevVoxelInfoLineView lineObject in lineObjects)
			{
				lineObject.gameObject.SetActive(value: false);
			}
			for (int i = 0; i < devVoxelInfo.Info.Count; i++)
			{
				AddLine(devVoxelInfo.Info[i], devVoxelInfo.IsInfoLine[i], devVoxelInfo.ButtonText[i], devVoxelInfo.ButtonAction[i]);
			}
			if (currentVoxelMarker != null)
			{
				currentVoxelMarker.transform.position = GridUtils.GetWorldPosition(devVoxelInfo.CurrentGridPosition);
			}
		}

		private void AddLine(string text, bool isInfoLineOnly, string buttonLabel = null, UnityAction buttonClickAction = null)
		{
			visibleLines++;
			if (lineObjects.Count < visibleLines)
			{
				CreateLineGameObjects(visibleLines - lineObjects.Count);
			}
			lineObjects[visibleLines - 1].gameObject.SetActive(value: true);
			lineObjects[visibleLines - 1].SetText(text, isInfoLineOnly);
			if (buttonLabel != null && buttonClickAction != null)
			{
				lineObjects[visibleLines - 1].SetButton(buttonLabel, buttonClickAction);
			}
			else
			{
				lineObjects[visibleLines - 1].ClearButton();
			}
		}

		private void CreateLineGameObjects(int lineObjectsCount)
		{
			for (int i = 0; i < lineObjectsCount; i++)
			{
				GameObject obj = lineViewObject.gameObject;
				GameObject gameObject = Object.Instantiate(obj, obj.transform.parent, worldPositionStays: true);
				gameObject.SetActive(value: true);
				lineObjects.Add(gameObject.GetComponent<DevVoxelInfoLineView>());
			}
		}
	}
}
