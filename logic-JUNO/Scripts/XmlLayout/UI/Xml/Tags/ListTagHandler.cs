using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using UI.Tables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Xml.Tags
{
	public class ListTagHandler : ElementTagHandler, IObservableListTagHandler
	{
		private class ListItemAttributeMatch
		{
			public string attribute;

			public string field;

			public ViewModelBindingType bindingType = ViewModelBindingType.TwoWay;
		}

		internal Dictionary<string, XmlLayoutList> ListElements = new Dictionary<string, XmlLayoutList>();

		protected XmlLayoutList currentListElement;

		public override string prefabPath => null;

		public override bool renderElement => false;

		public override bool isCustomElement => false;

		public override string extension => "blank";

		public override Dictionary<string, string> attributes => new Dictionary<string, string>
		{
			{ "vm-dataSource", "xs:string" },
			{ "itemShowAnimation", "None,Grow,Grow_Vertical,Grow_Horizontal,FadeIn,SlideIn_Left,SlideIn_Right,SlideIn_Top,SlideIn_Bottom" }
		};

		public override RectTransform transformToAddChildrenTo
		{
			get
			{
				if (!(base.currentInstanceTransform != null))
				{
					return null;
				}
				return base.currentInstanceTransform.parent as RectTransform;
			}
		}

		public override bool UseParseChildElements => true;

		public override void SetInstance(RectTransform instanceTransform, XmlLayout xmlLayout)
		{
			base.SetInstance(instanceTransform, xmlLayout);
			if (instanceTransform != null)
			{
				currentListElement = instanceTransform.GetComponent<XmlLayoutList>();
			}
		}

		public override void ParseChildElements(XmlNode xmlNode)
		{
			if (string.IsNullOrEmpty(base.currentXmlElement.DataSource))
			{
				return;
			}
			string dataSource = base.currentXmlElement.DataSource;
			XmlLayoutController xmlLayoutController = base.currentXmlLayoutInstance.XmlLayoutController;
			if (xmlLayoutController == null)
			{
				return;
			}
			PropertyInfo property = xmlLayoutController.GetType().GetProperty("viewModel");
			if (property == null)
			{
				Debug.LogWarning("[XmlLayout] Warning: Useage of the <List> element requires the XmlLayoutController to have a view model type defined.");
				return;
			}
			object value = property.GetValue(xmlLayoutController, null);
			PropertyInfo property2 = value.GetType().GetProperty(dataSource);
			FieldInfo field = value.GetType().GetField(dataSource);
			IList list = null;
			if (property2 != null)
			{
				if (!property2.PropertyType.IsGenericType || !(property2.PropertyType.GetGenericTypeDefinition() == typeof(ObservableList<>)))
				{
					Debug.LogWarning("[XmlLayout] Warning: Usage of the <List> element requires a property with a type of ObservableList.");
					return;
				}
				list = (IList)property2.GetValue(value, XmlLayoutUtilities.BindingFlags, null, null, null);
			}
			else
			{
				if (!(field != null))
				{
					Debug.LogWarning("[XmlLayout] Warning: View Model does not contain a field or property for data source '" + dataSource + "'.");
					return;
				}
				if (!field.FieldType.IsGenericType || !(field.FieldType.GetGenericTypeDefinition() == typeof(ObservableList<>)))
				{
					Debug.LogWarning("[XmlLayout] Warning: Usage of the <List> element requires a property with a type of ObservableList.");
					return;
				}
				list = (IList)field.GetValue(value);
			}
			IObservableList observableList = (IObservableList)list;
			if (list == null || observableList == null)
			{
				return;
			}
			XmlElement parent = transformToAddChildrenTo.GetComponent<XmlElement>();
			if (!parent.attributes.ContainsKey("id"))
			{
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					parent.SetAndApplyAttribute("id", observableList.guid);
				}, parent, forceEvenIfObjectIsInactive: true);
			}
			XmlElement itemTemplate = GetItemTemplate(xmlNode.InnerXml);
			XmlLayoutList xmlLayoutList = parent.GetComponent<XmlLayoutList>();
			if (xmlLayoutList == null)
			{
				xmlLayoutList = parent.gameObject.AddComponent<XmlLayoutList>();
			}
			xmlLayoutList.itemTemplate = itemTemplate;
			xmlLayoutList.DataSource = dataSource;
			xmlLayoutList.baseSiblingIndex = base.currentXmlElement.transform.GetSiblingIndex();
			xmlLayoutList.list = observableList;
			xmlLayoutList.isCalculatedList = !property2.IsAutoProperty();
			xmlLayoutList.itemAnimationDuration = (base.currentXmlElement.attributes.ContainsKey("itemAnimationDuration") ? base.currentXmlElement.attributes.GetValue<float>("itemAnimationDuration") : 0.25f);
			xmlLayoutList.itemShowAnimation = (base.currentXmlElement.attributes.ContainsKey("itemShowAnimation") ? base.currentXmlElement.attributes.GetValue<ShowAnimation>("itemShowAnimation") : ShowAnimation.None);
			xmlLayoutList.itemHideAnimation = (base.currentXmlElement.attributes.ContainsKey("itemHideAnimation") ? base.currentXmlElement.attributes.GetValue<HideAnimation>("itemHideAnimation") : HideAnimation.None);
			currentListElement = xmlLayoutList;
			if (ListElements.ContainsKey(observableList.guid))
			{
				ListElements[observableList.guid] = xmlLayoutList;
			}
			else
			{
				ListElements.Add(observableList.guid, xmlLayoutList);
			}
			for (int num = 0; num < list.Count; num++)
			{
				RenderListItem(list[num], dataSource, itemTemplate, observableList);
			}
		}

		internal void ProcessCalculatedListUpdate(IObservableList updatedList)
		{
			IObservableList list = currentListElement.list;
			currentListElement.list = updatedList;
			int num = Math.Max(list.Count, updatedList.Count);
			for (int i = 0; i < num; i++)
			{
				XmlLayoutListItem xmlLayoutListItem = ((i < currentListElement.listItems.Count) ? currentListElement.listItems[i] : null);
				if (xmlLayoutListItem != null)
				{
					if (i < updatedList.Count)
					{
						ApplyViewModelData(xmlLayoutListItem.xmlElement, updatedList[i], currentListElement.DataSource, currentListElement.itemTemplate, updatedList);
					}
					else if (i >= updatedList.Count)
					{
						RemoveListItemByIndexFromCurrentList(list, i, currentListElement.DataSource);
					}
				}
				else if (i < updatedList.Count)
				{
					RenderListItem(updatedList[i], currentListElement.DataSource, currentListElement.itemTemplate, updatedList);
				}
			}
		}

		private void RemoveListItemByIndexFromCurrentList(IObservableList list, int index, string listName)
		{
			XmlLayoutListItem item = currentListElement.listItems[index];
			_RemoveListItem(currentListElement, item);
		}

		public void RemoveListItem(IObservableList list, object item, string listName)
		{
			XmlLayoutList listElement = ListElements[list.guid];
			string itemGuid = list.GetGUID(item);
			XmlLayoutListItem itemElement = listElement.listItems.FirstOrDefault((XmlLayoutListItem f) => f.guid == itemGuid);
			if (itemElement != null)
			{
				itemElement.xmlElement.Hide(recursiveCall: false, delegate
				{
					_RemoveListItem(listElement, itemElement);
				});
			}
		}

		private void _RemoveListItem(XmlLayoutList list, XmlLayoutListItem item)
		{
			if (item.xmlElement != null)
			{
				list.listItems.Remove(item);
				list.listElement.RemoveChildElement(item.xmlElement);
			}
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(item.gameObject);
			}
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(list.rectTransform);
			}, list);
		}

		private XmlElement GetItemTemplate(string xml)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(xml);
			string text = "ListItemTemplate-" + Guid.NewGuid().ToString();
			xmlDocument.DocumentElement.SetAttribute("id", text);
			xmlDocument.DocumentElement.SetAttribute("active", "false");
			XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocument.DocumentElement.OuterXml));
			xmlReader.Read();
			base.currentXmlLayoutInstance.ParseNode(xmlReader, transformToAddChildrenTo);
			return base.currentXmlLayoutInstance.GetElementById(text);
		}

		internal void RenderListItem(object itemData, string dataSource, XmlElement itemTemplate, IObservableList list)
		{
			XmlElement element = UnityEngine.Object.Instantiate(itemTemplate);
			currentListElement.listElement.AddChildElement(element);
			element.SetAttribute("active", "true");
			XmlLayoutListItem xmlLayoutListItem = element.gameObject.GetComponent<XmlLayoutListItem>() ?? element.gameObject.AddComponent<XmlLayoutListItem>();
			xmlLayoutListItem.guid = list.GetGUID(itemData);
			int index = list.IndexOf(itemData);
			currentListElement.listItems.Insert(index, xmlLayoutListItem);
			ApplyViewModelData(element, itemData, dataSource, itemTemplate, list, null, isTopLevel: true, isFirstCall: true);
			element.Initialise(base.currentXmlLayoutInstance, element.rectTransform, element.tagHandler);
			element.ApplyAttributes();
			element.AnimationDuration = currentListElement.itemAnimationDuration;
			element.ShowAnimation = currentListElement.itemShowAnimation;
			element.HideAnimation = currentListElement.itemHideAnimation;
			if (element.ShowAnimation != ShowAnimation.None)
			{
				element.Show();
			}
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				LayoutRebuilder.MarkLayoutForRebuild(element.rectTransform);
			}, element);
		}

		internal void ApplyViewModelData(XmlElement element, object itemData, string dataSource, XmlElement elementTemplate, IObservableList list, string changedField = null, bool isTopLevel = true, bool isFirstCall = false)
		{
			for (int i = 0; i < element.childElements.Count; i++)
			{
				XmlElement element2 = element.childElements[i];
				ApplyViewModelData(element2, itemData, dataSource, elementTemplate.childElements[i], list, changedField, isTopLevel: false, isFirstCall);
			}
			List<ListItemAttributeMatch> list2 = new List<ListItemAttributeMatch>();
			Dictionary<string, string> attributesToCheck = elementTemplate.attributes.Where((KeyValuePair<string, string> a) => a.Value.StartsWith("{") && a.Value.EndsWith("}")).ToDictionary((KeyValuePair<string, string> k) => k.Key, (KeyValuePair<string, string> v) => v.Value.Replace("{", string.Empty).Replace("}", string.Empty));
			if (attributesToCheck.Count > 0)
			{
				foreach (MemberInfo field in (from m in (from m in itemData.GetType().GetMembers()
						where changedField == null || m.Name == changedField || (m is PropertyInfo && !((PropertyInfo)m).IsAutoProperty())
						where m is PropertyInfo || m is FieldInfo
						select m).ToList()
					where attributesToCheck.Values.ToList().Any((string a) => a.StripChars('?') == dataSource + "." + m.Name)
					select m).ToList())
				{
					KeyValuePair<string, string> keyValuePair = attributesToCheck.FirstOrDefault((KeyValuePair<string, string> a) => a.Value.StripChars('?') == dataSource + "." + field.Name);
					string value = ConversionExtensions.ToString(((field is PropertyInfo) ? ((PropertyInfo)field).GetValue(itemData, null) : ((FieldInfo)field).GetValue(itemData)) ?? string.Empty);
					element.SetAttribute(keyValuePair.Key, value);
					list2.Add(new ListItemAttributeMatch
					{
						attribute = keyValuePair.Key,
						field = field.Name,
						bindingType = ((!keyValuePair.Value.StartsWith("?")) ? ViewModelBindingType.TwoWay : ViewModelBindingType.OneWay)
					});
				}
			}
			if (isFirstCall || list2.Count > 0)
			{
				element.ApplyAttributes(element.attributes.Clone());
			}
			XmlLayoutListItem component = element.GetComponent<XmlLayoutListItem>();
			if (component != null && currentListElement != null && isTopLevel)
			{
				HandleListItemPositioning(component);
			}
			if (list2.Count > 0)
			{
				HandleTwoWayBinding(element, dataSource, list, itemData, list2);
			}
		}

		private void HandleTwoWayBinding(XmlElement element, string dataSource, IObservableList list, object itemData, List<ListItemAttributeMatch> attributes)
		{
			if (element.HasAttribute("__twoWayBindingSetupComplete"))
			{
				return;
			}
			ElementTagHandler tagHandler = element.tagHandler;
			if (!(tagHandler is IHasXmlFormValue))
			{
				return;
			}
			ListItemAttributeMatch listItemAttributeMatch = attributes.FirstOrDefault((ListItemAttributeMatch a) => a.bindingType == ViewModelBindingType.TwoWay && (a.attribute.Equals("value", StringComparison.OrdinalIgnoreCase) || a.attribute.Equals("text", StringComparison.OrdinalIgnoreCase) || a.attribute.Equals("ison", StringComparison.OrdinalIgnoreCase)));
			if (listItemAttributeMatch == null)
			{
				return;
			}
			string memberName = listItemAttributeMatch.field;
			tagHandler.SetInstance(element.rectTransform, base.currentXmlLayoutInstance);
			if (tagHandler.primaryComponent == null)
			{
				return;
			}
			MemberInfo memberInfo = tagHandler.primaryComponent.GetType().GetMember("onValueChanged").FirstOrDefault();
			if (!(memberInfo != null))
			{
				return;
			}
			object memberValue = memberInfo.GetMemberValue(tagHandler.primaryComponent);
			Type type = memberValue.GetType().GetMethod("AddListener").GetParameters()[0].ParameterType.GetGenericArguments()[0];
			XmlLayoutControllerMVVM controller = (XmlLayoutControllerMVVM)base.currentXmlLayoutInstance.XmlLayoutController;
			if (type == typeof(float))
			{
				((UnityEvent<float>)memberValue).AddListener(delegate(float v)
				{
					controller.SetViewModelListItemValue(dataSource, list.IndexOf(itemData), memberName, v, fromTwoWayBinding: true);
				});
			}
			else if (type == typeof(int))
			{
				((UnityEvent<int>)memberValue).AddListener(delegate(int v)
				{
					controller.SetViewModelListItemValue(dataSource, list.IndexOf(itemData), memberName, v, fromTwoWayBinding: true);
				});
			}
			else if (type == typeof(string))
			{
				((UnityEvent<string>)memberValue).AddListener(delegate(string v)
				{
					controller.SetViewModelListItemValue(dataSource, list.IndexOf(itemData), memberName, v, fromTwoWayBinding: true);
				});
			}
			else if (type == typeof(bool))
			{
				((UnityEvent<bool>)memberValue).AddListener(delegate(bool v)
				{
					controller.SetViewModelListItemValue(dataSource, list.IndexOf(itemData), memberName, v, fromTwoWayBinding: true);
				});
			}
			element.SetAttribute("__twoWayBindingSetupComplete", string.Empty);
		}

		private void HandleListItemPositioning(XmlLayoutListItem listItem)
		{
			if (currentListElement.listItems.Count > 0 && currentListElement.listItems.IndexOf(listItem) != 0)
			{
				XmlLayoutListItem xmlLayoutListItem = currentListElement.listItems.FirstOrDefault();
				if (xmlLayoutListItem != null)
				{
					int num = currentListElement.listItems.IndexOf(listItem);
					if (num != -1)
					{
						int siblingIndex = xmlLayoutListItem.transform.GetSiblingIndex() + num;
						listItem.xmlElement.rectTransform.SetSiblingIndex(siblingIndex);
					}
				}
			}
			else
			{
				listItem.xmlElement.rectTransform.SetSiblingIndex(currentListElement.baseSiblingIndex);
			}
		}

		public void UpdateListItem(IObservableList list, int index, object item, string listName, string changedField = null)
		{
			XmlLayoutList listElement = ListElements[list.guid];
			string itemGuid = list.GetGUID(item);
			XmlLayoutListItem xmlLayoutListItem = listElement.listItems.FirstOrDefault((XmlLayoutListItem f) => f.guid == itemGuid);
			SetInstance(listElement.rectTransform, listElement.listElement.xmlLayoutInstance);
			ApplyViewModelData(xmlLayoutListItem.xmlElement, item, listElement.DataSource, listElement.itemTemplate, list, changedField);
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(listElement.rectTransform);
			}, listElement);
		}

		public void AddListItem(IObservableList list, object item, string listName)
		{
			XmlLayoutList listElement = ListElements[list.guid];
			SetInstance(listElement.rectTransform, listElement.listElement.xmlLayoutInstance);
			RenderListItem(item, listElement.DataSource, listElement.itemTemplate, list);
			TableRow component = listElement.GetComponent<TableRow>();
			if (component != null)
			{
				component.NotifyTableRowPropertiesChanged();
			}
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(listElement.rectTransform);
			}, listElement);
		}

		public bool IsHandlingList(IObservableList list)
		{
			return ListElements.ContainsKey(list.guid);
		}
	}
}
