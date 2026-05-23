using System.Collections.Generic;
using MG_BlocksEngine2.Block;
using MG_BlocksEngine2.Core;
using MG_BlocksEngine2.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.UI
{
	[ExecuteInEditMode]
	public class BE2_UI_BlocksSelectionViewer : MonoBehaviour
	{
		private static BE2_UI_BlocksSelectionViewer _instance;

		public List<BE2_UI_SelectionPanel> selectionPanelsList;

		[Header("Add Block To Panel")]
		public Transform blockToAddTransform;

		public int panelIndex;

		public bool addBlock;

		private ScrollRect _scrollRect;

		public static BE2_UI_BlocksSelectionViewer Instance
		{
			get
			{
				if (!_instance)
				{
					_instance = Object.FindObjectOfType<BE2_UI_BlocksSelectionViewer>();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		private void Awake()
		{
			Instance = this;
			selectionPanelsList = new List<BE2_UI_SelectionPanel>();
			_scrollRect = GetComponent<ScrollRect>();
		}

		private void Start()
		{
			BE2_UI_SelectionPanel[] componentsInChildren = GetComponentsInChildren<BE2_UI_SelectionPanel>();
			foreach (BE2_UI_SelectionPanel item in componentsInChildren)
			{
				if (!selectionPanelsList.Contains(item))
				{
					selectionPanelsList.AddRange(GetComponentsInChildren<BE2_UI_SelectionPanel>());
				}
			}
		}

		public void UpdateSelectionPanels()
		{
			selectionPanelsList = new List<BE2_UI_SelectionPanel>();
			BE2_UI_SelectionPanel[] componentsInChildren = GetComponentsInChildren<BE2_UI_SelectionPanel>();
			foreach (BE2_UI_SelectionPanel item in componentsInChildren)
			{
				if (!selectionPanelsList.Contains(item))
				{
					selectionPanelsList.AddRange(GetComponentsInChildren<BE2_UI_SelectionPanel>());
				}
			}
		}

		public void AddBlockToPanel(Transform blockTransform, BE2_UI_SelectionPanel selectionPanel)
		{
			Transform obj = Object.Instantiate(blockTransform, Vector3.zero, Quaternion.identity, selectionPanel.transform);
			obj.name = obj.name.Replace("(Clone)", "");
			BE2_BlockUtils.RemoveEngineComponents(obj);
			BE2_BlockUtils.AddSelectionMenuComponents(obj);
			Debug.Log("+ Block added to selection menu");
			GameObject prefabBlock = BE2_BlockUtils.CreatePrefab(blockTransform.GetComponent<I_BE2_Block>());
			BE2_UI_SelectionBlock component = obj.GetComponent<BE2_UI_SelectionBlock>();
			component.prefabBlock = prefabBlock;
			component.PerformCleanAndResize();
			Debug.Log("+ Block prefab created");
		}

		private void OnEnable()
		{
			BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnPrimaryKeyUpEnd, EnableScroll);
		}

		private void OnDisable()
		{
			BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnPrimaryKeyUpEnd, EnableScroll);
		}

		private void EnableScroll()
		{
			_scrollRect.enabled = true;
		}

		public void ForceRebuildLayout()
		{
			((RectTransform)base.transform).ForceRebuildLayout();
		}
	}
}
