using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Battlehub.UIControls;
using UnityEngine;
using UnityEngine.UI;

namespace Battlehub.RTEditor
{
	public class RuntimeHierarchy : MonoBehaviour
	{
		public GameObject TreeViewPrefab;

		private TreeView m_treeView;

		public Type TypeCriteria = typeof(GameObject);

		public Color DisabledItemColor = new Color(0.5f, 0.5f, 0.5f);

		public Color EnabledItemColor = new Color(0.2f, 0.2f, 0.2f);

		private bool m_lockSelection;

		private void Start()
		{
			if (!TreeViewPrefab)
			{
				Debug.LogError("Set TreeViewPrefab field");
				return;
			}
			m_treeView = UnityEngine.Object.Instantiate(TreeViewPrefab).GetComponent<TreeView>();
			m_treeView.transform.SetParent(base.transform, worldPositionStays: false);
			m_treeView.ItemDataBinding += OnItemDataBinding;
			m_treeView.SelectionChanged += OnSelectionChanged;
			m_treeView.ItemsRemoved += OnItemsRemoved;
			m_treeView.ItemExpanding += OnItemExpanding;
			m_treeView.ItemBeginDrag += OnItemBeginDrag;
			m_treeView.ItemDrop += OnItemDrop;
			m_treeView.ItemEndDrag += OnItemEndDrag;
			RuntimeSelection.SelectionChanged += OnRuntimeSelectionChanged;
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			GameObject[] array = Resources.FindObjectsOfTypeAll<GameObject>();
			foreach (GameObject gameObject in array)
			{
				if (gameObject == null || RuntimePrefabs.IsPrefab(gameObject.transform))
				{
					continue;
				}
				if (TypeCriteria == typeof(GameObject))
				{
					hashSet.Add(gameObject);
					continue;
				}
				Component component = gameObject.GetComponent(TypeCriteria);
				if ((bool)component && !hashSet.Contains(component.gameObject))
				{
					hashSet.Add(component.gameObject);
				}
			}
			m_treeView.Items = from t in hashSet
				where t.transform.parent == null && CanExposeToEditor(t)
				orderby t.transform.GetSiblingIndex()
				select t;
			ExposeToEditor.Awaked += OnObjectAwaked;
			ExposeToEditor.Started += OnObjectStarted;
			ExposeToEditor.Enabled += OnObjectEnabled;
			ExposeToEditor.Disabled += OnObjectDisabled;
			ExposeToEditor.Destroyed += OnObjectDestroyed;
			ExposeToEditor.ParentChanged += OnParentChanged;
			ExposeToEditor.NameChanged += OnNameChanged;
		}

		private bool CanExposeToEditor(GameObject go)
		{
			return go.GetComponent<ExposeToEditor>() != null;
		}

		private void OnDestroy()
		{
			if ((bool)m_treeView)
			{
				m_treeView.ItemDataBinding -= OnItemDataBinding;
				m_treeView.SelectionChanged -= OnSelectionChanged;
				m_treeView.ItemsRemoved -= OnItemsRemoved;
				m_treeView.ItemExpanding -= OnItemExpanding;
				m_treeView.ItemBeginDrag -= OnItemBeginDrag;
				m_treeView.ItemDrop -= OnItemDrop;
				m_treeView.ItemEndDrag -= OnItemEndDrag;
				RuntimeSelection.SelectionChanged -= OnRuntimeSelectionChanged;
				ExposeToEditor.Awaked -= OnObjectAwaked;
				ExposeToEditor.Started -= OnObjectStarted;
				ExposeToEditor.Enabled -= OnObjectEnabled;
				ExposeToEditor.Disabled -= OnObjectDisabled;
				ExposeToEditor.Destroyed -= OnObjectDestroyed;
				ExposeToEditor.ParentChanged -= OnParentChanged;
				ExposeToEditor.NameChanged -= OnNameChanged;
			}
		}

		private void OnApplicationQuit()
		{
			ExposeToEditor.Awaked -= OnObjectAwaked;
			ExposeToEditor.Started -= OnObjectStarted;
			ExposeToEditor.Enabled -= OnObjectEnabled;
			ExposeToEditor.Disabled -= OnObjectDisabled;
			ExposeToEditor.Destroyed -= OnObjectDestroyed;
			ExposeToEditor.ParentChanged -= OnParentChanged;
			ExposeToEditor.NameChanged -= OnNameChanged;
		}

		private void OnItemExpanding(object sender, ItemExpandingArgs e)
		{
			ExposeToEditor component = ((GameObject)e.Item).GetComponent<ExposeToEditor>();
			if (component.ChildCount > 0)
			{
				e.Children = from obj in component.GetChildren()
					select obj.gameObject;
				OnTreeViewSelectionChanged(m_treeView.SelectedItems, m_treeView.SelectedItems);
			}
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
				m_treeView.SelectedItems = RuntimeSelection.gameObjects;
				m_lockSelection = false;
			}
		}

		private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			OnTreeViewSelectionChanged(e.OldItems, e.NewItems);
		}

		private void OnTreeViewSelectionChanged(IEnumerable oldItems, IEnumerable newItems)
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

		private void OnItemDataBinding(object sender, TreeViewItemDataBindingArgs e)
		{
			GameObject gameObject = e.Item as GameObject;
			if (gameObject != null)
			{
				Text componentInChildren = e.ItemPresenter.GetComponentInChildren<Text>(includeInactive: true);
				componentInChildren.text = gameObject.name;
				if (gameObject.activeInHierarchy)
				{
					componentInChildren.color = EnabledItemColor;
				}
				else
				{
					componentInChildren.color = DisabledItemColor;
				}
				e.HasChildren = gameObject.GetComponent<ExposeToEditor>().ChildCount > 0;
			}
		}

		private void OnItemBeginDrag(object sender, ItemDragArgs e)
		{
		}

		private void OnItemDrop(object sender, ItemDropArgs e)
		{
			if (e.IsExternal)
			{
				if (e.DragItems == null)
				{
					return;
				}
				for (int i = 0; i < e.DragItems.Length; i++)
				{
					GameObject gameObject = e.DragItems[i] as GameObject;
					if (gameObject != null && RuntimePrefabs.IsPrefab(gameObject.transform))
					{
						GameObject obj = UnityEngine.Object.Instantiate(gameObject);
						ExposeToEditor component = obj.GetComponent<ExposeToEditor>();
						if (component != null)
						{
							component.SetName(gameObject.name);
						}
						obj.transform.position = gameObject.transform.position;
						obj.transform.rotation = gameObject.transform.rotation;
						obj.transform.localScale = gameObject.transform.localScale;
						RuntimeSelection.activeGameObject = obj;
					}
				}
				return;
			}
			Transform transform = ((GameObject)e.DropTarget).transform;
			if (e.Action == ItemDropAction.SetLastChild)
			{
				for (int j = 0; j < e.DragItems.Length; j++)
				{
					Transform obj2 = ((GameObject)e.DragItems[j]).transform;
					obj2.SetParent(transform, worldPositionStays: true);
					obj2.SetAsLastSibling();
				}
			}
			else if (e.Action == ItemDropAction.SetNextSibling)
			{
				for (int k = 0; k < e.DragItems.Length; k++)
				{
					Transform transform2 = ((GameObject)e.DragItems[k]).transform;
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
				for (int l = 0; l < e.DragItems.Length; l++)
				{
					Transform transform3 = ((GameObject)e.DragItems[l]).transform;
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

		private void OnObjectAwaked(ExposeToEditor obj)
		{
			GameObject parent = null;
			if (obj.Parent != null)
			{
				parent = obj.Parent.gameObject;
			}
			m_treeView.AddChild(parent, obj.gameObject);
		}

		private void OnObjectStarted(ExposeToEditor obj)
		{
		}

		private void OnObjectEnabled(ExposeToEditor obj)
		{
			TreeViewItem treeViewItem = (TreeViewItem)m_treeView.GetItemContainer(obj.gameObject);
			if (!(treeViewItem == null))
			{
				treeViewItem.GetComponentInChildren<Text>().color = EnabledItemColor;
			}
		}

		private void OnObjectDisabled(ExposeToEditor obj)
		{
			TreeViewItem treeViewItem = (TreeViewItem)m_treeView.GetItemContainer(obj.gameObject);
			if (!(treeViewItem == null))
			{
				treeViewItem.GetComponentInChildren<Text>().color = DisabledItemColor;
			}
		}

		private void OnObjectDestroyed(ExposeToEditor obj)
		{
			m_treeView.Remove(obj.gameObject);
		}

		private void OnParentChanged(ExposeToEditor obj, ExposeToEditor oldParent, ExposeToEditor newParent)
		{
			GameObject parent = null;
			if (newParent != null)
			{
				parent = newParent.gameObject;
			}
			m_treeView.ChangeParent(parent, obj.gameObject);
		}

		private void OnNameChanged(ExposeToEditor obj)
		{
			TreeViewItem treeViewItem = (TreeViewItem)m_treeView.GetItemContainer(obj.gameObject);
			if (!(treeViewItem == null))
			{
				treeViewItem.GetComponentInChildren<Text>().text = obj.gameObject.name;
			}
		}
	}
}
