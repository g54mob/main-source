using System;
using System.Collections;
using System.Linq;
using Battlehub.UIControls;
using UnityEngine;
using UnityEngine.UI;

namespace Battlehub.RTEditor
{
	public class RuntimePrefabs : MonoBehaviour
	{
		public GameObject ListBoxPrefab;

		private ListBox m_listBox;

		public Type TypeCriteria = typeof(GameObject);

		public RuntimeEditor Editor;

		private bool m_lockSelection;

		public static bool IsPrefab(Transform This)
		{
			if (Application.isEditor && !Application.isPlaying)
			{
				throw new InvalidOperationException("Does not work in edit mode");
			}
			return This.gameObject.scene.buildIndex < 0;
		}

		private void Start()
		{
			if (!ListBoxPrefab)
			{
				Debug.LogError("Set ListBoxPrefab field");
				return;
			}
			m_listBox = UnityEngine.Object.Instantiate(ListBoxPrefab).GetComponent<ListBox>();
			m_listBox.CanDrag = false;
			m_listBox.MultiselectKey = KeyCode.None;
			m_listBox.RangeselectKey = KeyCode.None;
			m_listBox.RemoveKey = KeyCode.None;
			m_listBox.transform.SetParent(base.transform, worldPositionStays: false);
			m_listBox.ItemDataBinding += OnItemDataBinding;
			m_listBox.SelectionChanged += OnSelectionChanged;
			m_listBox.ItemsRemoved += OnItemsRemoved;
			m_listBox.ItemBeginDrag += OnItemBeginDrag;
			m_listBox.ItemDrop += OnItemDrop;
			m_listBox.ItemEndDrag += OnItemEndDrag;
			RuntimeSelection.SelectionChanged += OnRuntimeSelectionChanged;
			if (Editor != null)
			{
				if (Editor.Prefabs != null)
				{
					for (int i = 0; i < Editor.Prefabs.Length; i++)
					{
						GameObject gameObject = Editor.Prefabs[i];
						if (gameObject != null && !gameObject.GetComponent<ExposeToEditor>())
						{
							gameObject.AddComponent<ExposeToEditor>();
						}
					}
				}
				m_listBox.Items = Editor.Prefabs;
			}
			ExposeToEditor.Destroyed += OnObjectDestroyed;
		}

		private void OnDestroy()
		{
			if ((bool)m_listBox)
			{
				m_listBox.ItemDataBinding -= OnItemDataBinding;
				m_listBox.SelectionChanged -= OnSelectionChanged;
				m_listBox.ItemsRemoved -= OnItemsRemoved;
				m_listBox.ItemBeginDrag -= OnItemBeginDrag;
				m_listBox.ItemDrop -= OnItemDrop;
				m_listBox.ItemEndDrag -= OnItemEndDrag;
				RuntimeSelection.SelectionChanged -= OnRuntimeSelectionChanged;
				ExposeToEditor.Destroyed -= OnObjectDestroyed;
			}
		}

		private void OnApplicationQuit()
		{
			ExposeToEditor.Destroyed -= OnObjectDestroyed;
		}

		private void OnEditorSelectionChanged()
		{
			if (!m_lockSelection)
			{
				m_lockSelection = true;
				m_lockSelection = false;
			}
		}

		private void OnRuntimeSelectionChanged(UnityEngine.Object[] unselected)
		{
			if (!m_lockSelection)
			{
				m_lockSelection = true;
				m_listBox.SelectedItems = RuntimeSelection.gameObjects;
				m_lockSelection = false;
			}
		}

		private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			OnListBoxSelectionChanged(e.OldItems, e.NewItems);
		}

		private void OnListBoxSelectionChanged(IEnumerable oldItems, IEnumerable newItems)
		{
			if (!m_lockSelection)
			{
				m_lockSelection = true;
				if (newItems == null)
				{
					newItems = new GameObject[0];
				}
				UnityEngine.Object[] objects = newItems.OfType<GameObject>().ToArray();
				RuntimeSelection.objects = objects;
				m_lockSelection = false;
			}
		}

		private void OnItemsRemoved(object sender, ItemsRemovedArgs e)
		{
			for (int i = 0; i < e.Items.Length; i++)
			{
				GameObject gameObject = (GameObject)e.Items[i];
				if (gameObject != null)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
		}

		private void OnItemDataBinding(object sender, ItemDataBindingArgs e)
		{
			GameObject gameObject = e.Item as GameObject;
			if (gameObject != null)
			{
				e.ItemPresenter.GetComponentInChildren<Text>(includeInactive: true).text = gameObject.name;
			}
		}

		private void OnItemBeginDrag(object sender, ItemDragArgs e)
		{
		}

		private void OnItemDrop(object sender, ItemDropArgs e)
		{
			Transform transform = ((GameObject)e.DropTarget).transform;
			if (e.Action == ItemDropAction.SetLastChild)
			{
				for (int i = 0; i < e.DragItems.Length; i++)
				{
					Transform obj = ((GameObject)e.DragItems[i]).transform;
					obj.SetParent(transform, worldPositionStays: true);
					obj.SetAsLastSibling();
				}
			}
			else if (e.Action == ItemDropAction.SetNextSibling)
			{
				for (int j = 0; j < e.DragItems.Length; j++)
				{
					Transform transform2 = ((GameObject)e.DragItems[j]).transform;
					if (transform2.parent != transform.parent)
					{
						transform2.SetParent(transform.parent, worldPositionStays: true);
					}
					int siblingIndex = transform.GetSiblingIndex();
					transform2.SetSiblingIndex(siblingIndex + 1);
				}
			}
			else
			{
				if (e.Action != ItemDropAction.SetPrevSibling)
				{
					return;
				}
				for (int k = 0; k < e.DragItems.Length; k++)
				{
					Transform transform3 = ((GameObject)e.DragItems[k]).transform;
					if (transform3.parent != transform.parent)
					{
						transform3.SetParent(transform.parent, worldPositionStays: true);
					}
					int siblingIndex2 = transform.GetSiblingIndex();
					transform3.SetSiblingIndex(siblingIndex2);
				}
			}
		}

		private void OnItemEndDrag(object sender, ItemDragArgs e)
		{
		}

		private void OnObjectDestroyed(ExposeToEditor obj)
		{
			m_listBox.Remove(obj.gameObject);
		}
	}
}
