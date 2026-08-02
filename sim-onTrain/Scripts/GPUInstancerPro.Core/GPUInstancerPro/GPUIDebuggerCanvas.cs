using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GPUInstancerPro
{
	public class GPUIDebuggerCanvas : MonoBehaviour
	{
		private class DebugUIData
		{
			public GameObject uiGO;

			public Text text;

			public string name;

			private int _instanceCount;

			public int lodCount;

			public int[] visibleCounts;

			private string _text;

			private bool _isShowVisibility;

			public DebugUIData(GameObject uiGO, Text text, string name, int lodCount)
			{
				this.uiGO = uiGO;
				this.text = text;
				this.name = name;
				text.text = name;
				this.lodCount = lodCount;
				visibleCounts = new int[8];
				_instanceCount = -1;
			}

			public void UpdateText(int instanceCount, bool isShowVisibility)
			{
				if (_instanceCount == instanceCount && !_isShowVisibility && _isShowVisibility == isShowVisibility)
				{
					return;
				}
				_isShowVisibility = isShowVisibility;
				_instanceCount = instanceCount;
				_text = "<b>" + name + "</b>\nIC: " + _instanceCount;
				if (_isShowVisibility)
				{
					for (int i = 0; i < lodCount; i++)
					{
						_text = _text + "    LOD" + i + ": " + visibleCounts[i];
					}
				}
				text.text = _text;
			}
		}

		public Toggle showVisibilityToggle;

		public RectTransform contentTransform;

		private Dictionary<int, DebugUIData> _rsgUIs;

		private Action<GPUIDataBuffer<GPUIVisibilityData>> _callback;

		private static readonly float START_Y = -25f;

		private static readonly float SPACING_Y = 50f;

		private static readonly float HEIGHT = 45f;

		private static readonly float WIDTH = 380f;

		private static readonly int FONT_SIZE = 18;

		private void OnEnable()
		{
			_rsgUIs = new Dictionary<int, DebugUIData>();
			_callback = VisibilityCallback;
		}

		private void OnDisable()
		{
			if (_rsgUIs == null)
			{
				return;
			}
			foreach (DebugUIData value in _rsgUIs.Values)
			{
				if (value != null)
				{
					UnityEngine.Object.Destroy(value.uiGO);
				}
			}
			_rsgUIs = null;
		}

		private void Update()
		{
			if (!GPUIRenderingSystem.IsActive || !(contentTransform != null))
			{
				return;
			}
			bool flag = showVisibilityToggle != null && showVisibilityToggle.isOn;
			foreach (KeyValuePair<int, GPUIRenderSourceGroup> item in GPUIRenderingSystem.Instance.RenderSourceGroupProvider)
			{
				if (!_rsgUIs.ContainsKey(item.Key))
				{
					GameObject obj = new GameObject(item.Value.Name);
					obj.transform.parent = contentTransform;
					Text text = obj.AddComponent<Text>();
					text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
					text.fontSize = FONT_SIZE;
					text.resizeTextForBestFit = true;
					text.resizeTextMaxSize = FONT_SIZE;
					text.resizeTextMinSize = 1;
					text.color = Color.white;
					DebugUIData value = new DebugUIData(obj, text, item.Value.Name, item.Value.LODGroupData.Length);
					RectTransform component = obj.GetComponent<RectTransform>();
					component.anchorMin = Vector2.up;
					component.anchorMax = Vector2.one;
					component.anchoredPosition = new Vector2(0f, START_Y - SPACING_Y * (float)_rsgUIs.Count);
					component.sizeDelta = new Vector2(WIDTH, HEIGHT);
					component.offsetMin = new Vector2(10f, component.offsetMin.y);
					component.offsetMax = new Vector2(10f, component.offsetMax.y);
					_rsgUIs.Add(item.Key, value);
				}
			}
			foreach (KeyValuePair<int, DebugUIData> rsgUI in _rsgUIs)
			{
				if (GPUIRenderingSystem.Instance.RenderSourceGroupProvider.TryGetData(rsgUI.Key, out var result))
				{
					rsgUI.Value.UpdateText(result.InstanceCount, flag);
				}
			}
			contentTransform.sizeDelta = new Vector2(0f, SPACING_Y * (float)_rsgUIs.Count);
			if (flag)
			{
				GPUICameraData firstValue = GPUIRenderingSystem.Instance.CameraDataProvider.GetFirstValue();
				if (firstValue != null && firstValue._visibilityBuffer != null)
				{
					firstValue._visibilityBuffer.AsyncDataRequest(_callback, writeToDataAfterReadback: false);
				}
			}
		}

		private void VisibilityCallback(GPUIDataBuffer<GPUIVisibilityData> buffer)
		{
			NativeArray<GPUIVisibilityData> requestedData = buffer.GetRequestedData();
			if (!requestedData.IsCreated)
			{
				return;
			}
			GPUIVisibilityBuffer gPUIVisibilityBuffer = buffer as GPUIVisibilityBuffer;
			foreach (KeyValuePair<int, DebugUIData> rsgUI in _rsgUIs)
			{
				if (gPUIVisibilityBuffer.cameraData.TryGetVisibilityBufferIndex(rsgUI.Key, out var visibilityBufferIndex) && requestedData.Length > visibilityBufferIndex)
				{
					for (int i = 0; i < rsgUI.Value.lodCount; i++)
					{
						rsgUI.Value.visibleCounts[i] = (int)requestedData[visibilityBufferIndex + i].visibleCount;
					}
				}
			}
		}
	}
}
