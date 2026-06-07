using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	public class AGridView<T> : AUIView
	{
		public delegate void IndexChangeDelegate(AGridView<T> sender);

		public GameObject viewElementPrefab;

		public GameObject dummyElementPrefab;

		public bool showDummyElement;

		public bool placeDummyElementLast;

		public bool allowHoveringAndSelecting = true;

		private AViewElement<T> selectedItem;

		private AViewElement<T> hoveredItem;

		protected Transform poolContainer;

		protected int indexOffset;

		private bool reentrancyCheck;

		private bool _prevAllowHoveringAndSelecting;

		public ObservableCollection<T> Model { get; private set; }

		protected int SelectedViewIndex_internal
		{
			get
			{
				if (!(selectedItem == null))
				{
					return selectedItem.transform.GetSiblingIndex();
				}
				return -1;
			}
		}

		public int SelectedModelIndex
		{
			get
			{
				int num = SelectedViewIndex_internal - indexOffset;
				if (num >= 0 && num < Model.Count)
				{
					return num;
				}
				return -1;
			}
		}

		protected int HoveredViewIndex_internal
		{
			get
			{
				if (!(hoveredItem == null))
				{
					return hoveredItem.transform.GetSiblingIndex();
				}
				return -1;
			}
		}

		public int HoveredModelIndex
		{
			get
			{
				int num = HoveredViewIndex_internal - indexOffset;
				if (num >= 0 && num < Model.Count)
				{
					return num;
				}
				return -1;
			}
		}

		protected Transform PoolContainer
		{
			get
			{
				if (poolContainer == null)
				{
					GameObject gameObject = new GameObject("[pool for '" + GetType().Name + "' on '" + base.gameObject.name + "']");
					gameObject.SetActive(value: false);
					poolContainer = gameObject.transform;
				}
				return poolContainer;
			}
		}

		public event IndexChangeDelegate SelectedIndexChanged;

		public event IndexChangeDelegate HoveredIndexChanged;

		protected virtual void Awake()
		{
		}

		protected virtual void OnValidate()
		{
			Validate(ref viewElementPrefab);
			if ((bool)dummyElementPrefab)
			{
				Validate(ref dummyElementPrefab);
			}
		}

		protected virtual void Validate(ref GameObject prefab)
		{
			if (prefab != null)
			{
				Selectable component;
				if (prefab.GetComponent<AViewElement<T>>() == null)
				{
					Debug.LogError("Assigned " + prefab.name + " doesn't contain a proper AViewElement component, resetting it to null", prefab);
					prefab = null;
				}
				else if (prefab.GetComponent<IMarkable>() == null)
				{
					Debug.LogError("Assigned prefab doesn't contain IMarkable component, resetting it to null", prefab);
					prefab = null;
				}
				else if (prefab.TryGetComponent<Selectable>(out component) && component.navigation.mode == Navigation.Mode.None)
				{
					Debug.LogError("Assigned prefab Selectable Navigation shouldn't be set to None (clicking it wouldn't select it), fix the prefab (change it to Automatic) and re-assign it", prefab);
				}
			}
		}

		public void SetModel(ObservableCollection<T> model)
		{
			if (reentrancyCheck)
			{
				Debug.LogError(GetType().Name + " reentrancy check fail!", this);
			}
			reentrancyCheck = true;
			SetupListeners(on: false);
			RemoveAllItems();
			Model = model;
			if (Model != null)
			{
				AddAllItems();
				SetupListeners(on: true);
			}
			AddDummyItem();
			reentrancyCheck = false;
		}

		public void SetSelected(int viewIndex)
		{
			UpdateSelectedItem(viewIndex);
		}

		public void Deselect()
		{
			if (SelectedViewIndex_internal < 0 || selectedItem == null)
			{
				Debug.LogError("Nothing is selected, can't deselect", this);
				return;
			}
			selectedItem.SetSelected(selected: false);
			selectedItem = null;
			this.SelectedIndexChanged?.Invoke(this);
		}

		private void SetupListeners(bool on)
		{
			if (Model != null)
			{
				if (on)
				{
					Model.CollectionChanged += OnCollectionChanged;
				}
				else
				{
					Model.CollectionChanged -= OnCollectionChanged;
				}
			}
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
			{
				for (int i = 0; i < e.NewItems.Count; i++)
				{
					T modelItem = (T)e.NewItems[i];
					AddItemAt(modelItem, e.NewStartingIndex + i, i == e.NewItems.Count - 1);
				}
				break;
			}
			case NotifyCollectionChangedAction.Remove:
			{
				for (int num = e.OldItems.Count - 1; num >= 0; num--)
				{
					RemoveViewItemAt(e.OldStartingIndex + indexOffset, num == 0);
				}
				break;
			}
			case NotifyCollectionChangedAction.Move:
				Move(e.OldStartingIndex, e.NewStartingIndex);
				break;
			case NotifyCollectionChangedAction.Replace:
				ReplaceViewElementData(e.OldStartingIndex);
				break;
			case NotifyCollectionChangedAction.Reset:
				RemoveAllItems();
				AddDummyItem();
				break;
			}
		}

		private void UpdateSelectedItem(int viewIndex)
		{
			if (viewIndex < 0 || viewIndex >= base.transform.childCount)
			{
				Debug.LogWarning($"Index {viewIndex} is out of range (childCount: {base.transform.childCount}", this);
				return;
			}
			Transform child = base.transform.GetChild(viewIndex);
			AViewElement<T> component = child.GetComponent<AViewElement<T>>();
			if ((bool)component)
			{
				UpdateSelectedItem(component);
			}
			else
			{
				Debug.LogError(string.Format("expecting child {0} to have {1} component attached", viewIndex, "AViewElement"), child);
			}
		}

		private void UpdateSelectedItem(AViewElement<T> sender)
		{
			_ = SelectedViewIndex_internal;
			if ((bool)selectedItem)
			{
				if (selectedItem != sender)
				{
					selectedItem.SetSelected(selected: false);
					selectedItem = sender;
					selectedItem.SetSelected(selected: true);
					this.SelectedIndexChanged?.Invoke(this);
				}
			}
			else
			{
				selectedItem = sender;
				selectedItem.SetSelected(selected: true);
				this.SelectedIndexChanged?.Invoke(this);
			}
		}

		private void UpdateHover(AViewElement<T> sender, bool hovered)
		{
			int hoveredModelIndex = HoveredModelIndex;
			hoveredItem = (hovered ? sender : null);
			if (HoveredModelIndex != hoveredModelIndex)
			{
				this.HoveredIndexChanged?.Invoke(this);
			}
		}

		private void AddAllItems()
		{
			int selectedModelIndex = SelectedModelIndex;
			foreach (T item in Model)
			{
				AddItemAt(item, -1, fireEvent: false);
			}
			if (selectedModelIndex != SelectedModelIndex)
			{
				this.SelectedIndexChanged?.Invoke(this);
			}
		}

		private void RemoveAllItems()
		{
			int selectedViewIndex_internal = SelectedViewIndex_internal;
			for (int num = base.transform.childCount - 1; num >= 0; num--)
			{
				RemoveViewItemAt(num, fireEvent: false);
			}
			if (selectedViewIndex_internal != SelectedViewIndex_internal)
			{
				this.SelectedIndexChanged?.Invoke(this);
			}
		}

		private void AddDummyItem()
		{
			if ((bool)dummyElementPrefab && showDummyElement)
			{
				AddDummyItemAt(placeDummyElementLast ? (-1) : 0);
				indexOffset = ((!placeDummyElementLast) ? 1 : 0);
			}
			else
			{
				indexOffset = 0;
			}
		}

		private void AddDummyItemAt(int i)
		{
			_ = SelectedViewIndex_internal;
			GameObject gameObject = Object.Instantiate(dummyElementPrefab.gameObject, Vector3.zero, Quaternion.identity);
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			if (i >= 0)
			{
				gameObject.transform.SetSiblingIndex(i);
			}
			AViewElement<T> component = gameObject.GetComponent<AViewElement<T>>();
			component.SelectionRequested += UpdateSelectedItem;
			component.HoverChanged += UpdateHover;
		}

		private void AddItemAt(T modelItem, int i, bool fireEvent)
		{
			int selectedModelIndex = SelectedModelIndex;
			GameObject orInstantiate = GetOrInstantiate(viewElementPrefab);
			orInstantiate.transform.SetParent(base.transform, worldPositionStays: false);
			if (i >= 0)
			{
				orInstantiate.transform.SetSiblingIndex(i + indexOffset);
			}
			AViewElement<T> component = orInstantiate.GetComponent<AViewElement<T>>();
			component.SetData(modelItem, this);
			component.SetInteractable(allowHoveringAndSelecting);
			component.SelectionRequested += UpdateSelectedItem;
			component.HoverChanged += UpdateHover;
			if (fireEvent && selectedModelIndex != SelectedModelIndex)
			{
				this.SelectedIndexChanged?.Invoke(this);
			}
		}

		private GameObject GetOrInstantiate(GameObject prefab)
		{
			GameObject gameObject = ((PoolContainer.childCount <= 0) ? Object.Instantiate(prefab) : PoolContainer.GetChild(0).gameObject);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = prefab.transform.localRotation;
			gameObject.transform.localScale = prefab.transform.localScale;
			return gameObject;
		}

		private void RemoveViewItemAt(int transformChildIndex, bool fireEvent)
		{
			if (transformChildIndex < 0 || transformChildIndex >= base.transform.childCount)
			{
				Debug.LogWarning(string.Format("{0} got invalid index {1}, ignoring", "RemoveViewItemAt", transformChildIndex), this);
				return;
			}
			int selectedModelIndex = SelectedModelIndex;
			AViewElement<T> component = base.transform.GetChild(transformChildIndex).GetComponent<AViewElement<T>>();
			component.SelectionRequested -= UpdateSelectedItem;
			component.HoverChanged -= UpdateHover;
			if (component == selectedItem)
			{
				Deselect();
			}
			component.transform.SetParent(PoolContainer, worldPositionStays: false);
			if (fireEvent && selectedModelIndex != SelectedModelIndex)
			{
				this.SelectedIndexChanged?.Invoke(this);
			}
		}

		private void Move(int from, int to)
		{
			int selectedModelIndex = SelectedModelIndex;
			base.transform.GetChild(from + indexOffset).SetSiblingIndex(to + indexOffset);
			if (selectedModelIndex != SelectedModelIndex)
			{
				this.SelectedIndexChanged?.Invoke(this);
			}
		}

		private void ReplaceViewElementData(int index)
		{
			AViewElement<T> component = base.transform.GetChild(index + indexOffset).GetComponent<AViewElement<T>>();
			component.SetData(Model[index], this);
			component.SetInteractable(allowHoveringAndSelecting);
		}

		private void Update()
		{
			if (_prevAllowHoveringAndSelecting == allowHoveringAndSelecting)
			{
				return;
			}
			_prevAllowHoveringAndSelecting = allowHoveringAndSelecting;
			AViewElement<T>[] componentsInChildren = GetComponentsInChildren<AViewElement<T>>();
			foreach (AViewElement<T> aViewElement in componentsInChildren)
			{
				aViewElement.SetInteractable(allowHoveringAndSelecting);
				if (!allowHoveringAndSelecting)
				{
					aViewElement.SetSelected(selected: false);
				}
			}
		}
	}
}
