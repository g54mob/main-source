using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUICombobox : MonoBehaviour
{
	public class ComboAction
	{
		public string Label;

		public Action DoAction;

		public ComboAction(string label, Action doAction)
		{
			Label = label;
			DoAction = doAction;
		}

		public override string ToString()
		{
			return Label;
		}
	}

	public Text text;

	public int MaxItems;

	public bool LocalizeContent;

	public bool SoftwareTypes;

	public bool SWCategory;

	public bool FeatureComb;

	public bool ActionCombo;

	public string Software;

	public string NullName = "None";

	public bool LocalizeNullName = true;

	public string NoSelectionName = "Nothing selected";

	private List<object> _items;

	public string[] ToolTips;

	public UnityEvent OnSelectedChanged;

	private int _selected;

	private CanvasScaler comboPanelParent;

	public RectTransform rectTransform;

	public List<object> Items
	{
		get
		{
			return _items;
		}
		set
		{
			UpdateContent(value);
		}
	}

	public bool interactable
	{
		get
		{
			return GetComponent<Button>().interactable;
		}
		set
		{
			GetComponent<Button>().interactable = value;
		}
	}

	public int Selected
	{
		get
		{
			return _selected;
		}
		set
		{
			_selected = value;
			UpdateLabel();
			if (ActionCombo)
			{
				ComboAction selected = GetSelected<ComboAction>();
				if (selected != null)
				{
					selected.DoAction();
				}
			}
			if (OnSelectedChanged != null && Items != null && Items.Count > 0)
			{
				OnSelectedChanged.Invoke();
			}
		}
	}

	public bool IsShown
	{
		get
		{
			return ComboboxPanel.OpenCombo == this;
		}
	}

	public object SelectedItem
	{
		get
		{
			if (Items == null || Selected <= -1 || Selected >= Items.Count)
			{
				return null;
			}
			return Items[Selected];
		}
		set
		{
			Selected = Items.IndexOf(value);
		}
	}

	public string SelectedItemString
	{
		get
		{
			if (Items == null || Selected <= -1 || Selected >= Items.Count)
			{
				return null;
			}
			if (Items[Selected] == null)
			{
				return null;
			}
			return Items[Selected].ToString();
		}
	}

	public T GetSelected<T>()
	{
		if (!(SelectedItem is T))
		{
			return default(T);
		}
		return (T)SelectedItem;
	}

	public void UpdateLabel()
	{
		if (ActionCombo || Items == null || Selected < 0 || Selected >= Items.Count)
		{
			this.text.text = NoSelectionName.Loc();
		}
		else if (Items[Selected] == null)
		{
			this.text.text = NoSelectionName.Loc();
			_selected = -1;
		}
		else if (FeatureComb)
		{
			string text = Items[Selected].ToString();
			if ("Any".Equals(text))
			{
				this.text.text = "Any".Loc();
				return;
			}
			if ("Nothing selected".Equals(text))
			{
				this.text.text = "Nothingselected".Loc();
				return;
			}
			string[] feature = Localization.GetFeature(Software, text);
			this.text.text = feature[0];
		}
		else if (SoftwareTypes)
		{
			string value = Items[Selected].ToString();
			if ("All".Equals(value))
			{
				this.text.text = "All".Loc();
			}
			else if (SWCategory)
			{
				SoftwareCategory softwareCategory = SelectedItem as SoftwareCategory;
				if (softwareCategory != null)
				{
					this.text.text = softwareCategory.Name.LocSWC(softwareCategory.Parent.Name);
				}
				else
				{
					this.text.text = SelectedItem.ToString().LocSWC(Software);
				}
			}
			else
			{
				this.text.text = SelectedItem.ToString().LocSW();
			}
		}
		else
		{
			object obj = Items[Selected];
			IFormatColorObject formatColorObject = obj as IFormatColorObject;
			if (formatColorObject != null)
			{
				this.text.text = formatColorObject.GetActualString();
			}
			else
			{
				this.text.text = (LocalizeContent ? obj.ToString().LocTry() : Items[Selected].ToString());
			}
		}
	}

	public void OnSelectedChangedRemoveAllListeners()
	{
		if (OnSelectedChanged == null)
		{
			OnSelectedChanged = new UnityEvent();
		}
		else
		{
			OnSelectedChanged.RemoveAllListeners();
		}
	}

	private void Awake()
	{
		if (Items == null)
		{
			Items = new List<object>();
		}
	}

	public void UpdateContent<T>(IEnumerable<T> newListt)
	{
		List<object> items = newListt.Cast<object>().ToList();
		object selectedItem = SelectedItem;
		_items = items;
		ToolTips = null;
		if (!ActionCombo)
		{
			int num = Items.IndexOf(selectedItem);
			if (num >= 0)
			{
				_selected = num;
				UpdateLabel();
			}
			else
			{
				Selected = 0;
			}
		}
		else
		{
			UpdateLabel();
		}
	}

	public string[] GetLabelFromObject(object o, int i)
	{
		if (o != null)
		{
			string[] array = new string[2] { "Error", "Error" };
			if (SoftwareTypes && "All".Equals(o.ToString()))
			{
				array = new string[2]
				{
					"All".Loc(),
					"N/A"
				};
			}
			else if (FeatureComb && "Any".Equals(o.ToString()))
			{
				array = new string[2]
				{
					"Any".Loc(),
					"N/A"
				};
			}
			else
			{
				if (SoftwareTypes)
				{
					if (SWCategory)
					{
						SoftwareCategory softwareCategory = o as SoftwareCategory;
						if (softwareCategory != null)
						{
							return Localization.GetSoftwareCat(softwareCategory.Parent, softwareCategory.Name);
						}
					}
					SoftwareType softwareType = (o as SoftwareType) ?? MarketSimulation.Active.SoftwareTypes.GetOrNull(SWCategory ? Software : o.ToString());
					if (softwareType != null)
					{
						array = (SWCategory ? Localization.GetSoftwareCat(softwareType, o.ToString()) : Localization.GetSoftware(softwareType));
					}
				}
				if (FeatureComb)
				{
					array = Localization.GetFeature(Software, o.ToString());
				}
			}
			return new string[2]
			{
				GetElementLabel(o, array[0]),
				(SoftwareTypes && array.Length > 1) ? array[1] : ((ToolTips == null) ? "" : ToolTips[i])
			};
		}
		return new string[2]
		{
			LocalizeNullName ? NullName.Loc() : NullName,
			""
		};
	}

	private string GetElementLabel(object element, string swLoc)
	{
		if (element == null)
		{
			if (!LocalizeNullName)
			{
				return NullName;
			}
			return NullName.Loc();
		}
		if (SoftwareTypes || FeatureComb)
		{
			return swLoc;
		}
		IFormatColorObject formatColorObject = element as IFormatColorObject;
		if (formatColorObject != null)
		{
			return formatColorObject.GetActualString();
		}
		if (!LocalizeContent)
		{
			return element.ToString();
		}
		return element.ToString().LocTry();
	}

	public void UpdateContent<T>(IEnumerable<T> newListt, IEnumerable<string> toolTips)
	{
		List<object> items = newListt.Cast<object>().ToList();
		ToolTips = toolTips.ToArray();
		object selectedItem = SelectedItem;
		_items = items;
		if (!ActionCombo)
		{
			int num = Items.IndexOf(selectedItem);
			if (num >= 0)
			{
				_selected = num;
			}
			else
			{
				Selected = 0;
			}
		}
		else
		{
			UpdateLabel();
		}
	}

	public void ToggleDropDown()
	{
		ComboboxPanel.Instance.Show(this);
	}

	public void UpdateSelection(int idx)
	{
		Selected = ((idx < Items.Count) ? idx : (-1));
	}

	public void UpdateSelectionSupressEvents(int idx)
	{
		_selected = idx;
		text.text = ((Items != null && Selected < Items.Count) ? Items[Selected].ToString() : "");
	}

	private void OnDisable()
	{
		if (ComboboxPanel.OpenCombo == this)
		{
			ComboboxPanel.Instance.Close();
		}
	}
}
