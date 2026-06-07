using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Xml
{
	public abstract class ElementTagHandler
	{
		protected struct EventData
		{
			public string methodName;

			public string value;
		}

		private static Dictionary<Type, Dictionary<string, FieldInfo>> cachedComponentFields = new Dictionary<Type, Dictionary<string, FieldInfo>>();

		private List<string> _eventAttributeNames = new List<string>
		{
			"onClick", "onMouseEnter", "onMouseExit", "onElementDropped", "onBeginDrag", "onEndDrag", "onDrag", "onSubmit", "onShow", "onHide",
			"onMouseUp", "onMouseDown"
		};

		private string _prefabPath;

		protected string _elementName;

		private AttributeDictionary _defaultAttributeValues = new AttributeDictionary();

		private static int m_uiLayer = -1;

		private static Dictionary<Type, Dictionary<string, PropertyInfo>> _lookup = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

		public virtual MonoBehaviour primaryComponent => null;

		public RectTransform currentInstanceTransform { get; protected set; }

		public XmlLayout currentXmlLayoutInstance { get; protected set; }

		protected virtual Image imageComponent
		{
			get
			{
				if (currentInstanceTransform == null)
				{
					return null;
				}
				return currentInstanceTransform.GetComponent<Image>();
			}
		}

		protected LayoutElement layoutElement
		{
			get
			{
				if (currentInstanceTransform == null)
				{
					return null;
				}
				return currentInstanceTransform.GetComponent<LayoutElement>();
			}
		}

		protected XmlElement currentXmlElement
		{
			get
			{
				if (currentInstanceTransform == null)
				{
					return null;
				}
				return currentInstanceTransform.GetComponent<XmlElement>();
			}
		}

		public virtual RectTransform transformToAddChildrenTo
		{
			get
			{
				if (currentInstanceTransform == null)
				{
					return null;
				}
				return currentInstanceTransform;
			}
		}

		protected EventTrigger eventTrigger => currentXmlElement.EventTrigger;

		protected virtual List<string> eventAttributeNames => _eventAttributeNames;

		public virtual string prefabPath
		{
			get
			{
				if (_prefabPath == null)
				{
					_prefabPath = string.Format("XmlLayout Prefabs/{0}", GetType().Name.Replace("TagHandler", string.Empty));
				}
				return _prefabPath;
			}
		}

		public string tagType
		{
			get
			{
				if (_elementName == null)
				{
					_elementName = XmlLayoutUtilities.GetTagName(GetType());
				}
				return _elementName;
			}
		}

		public virtual string elementGroup => "default";

		public virtual string elementChildType => "default";

		public virtual bool isCustomElement => false;

		public virtual bool renderElement => true;

		public virtual Dictionary<string, string> attributes => new Dictionary<string, string>();

		public virtual List<string> attributeGroups => new List<string>();

		public virtual List<Type> customAttributeGroups => new List<Type>();

		public virtual string extension => "base";

		protected virtual bool dontCallHandleDataSourceAttributeAutomatically => false;

		protected virtual AttributeDictionary defaultAttributeValues => _defaultAttributeValues;

		public static int uiLayer
		{
			get
			{
				if (m_uiLayer == -1)
				{
					m_uiLayer = LayerMask.NameToLayer("UI");
				}
				return m_uiLayer;
			}
		}

		public virtual bool UseParseChildElements => false;

		private static Dictionary<string, FieldInfo> GetComponentXmlFields(Type type)
		{
			if (!cachedComponentFields.ContainsKey(type))
			{
				Dictionary<string, FieldInfo> dictionary = new Dictionary<string, FieldInfo>(StringComparer.OrdinalIgnoreCase);
				BindingFlags bindingAttr = BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public;
				FieldInfo[] fields = type.GetFields(bindingAttr);
				foreach (FieldInfo fieldInfo in fields)
				{
					XmlFieldName xmlFieldName = ((XmlFieldName[])fieldInfo.GetCustomAttributes(typeof(XmlFieldName), inherit: false)).FirstOrDefault();
					if (xmlFieldName != null)
					{
						dictionary.Add(xmlFieldName.fieldName, fieldInfo);
					}
					else
					{
						dictionary.Add(fieldInfo.Name, fieldInfo);
					}
				}
				cachedComponentFields.Add(type, dictionary);
			}
			return cachedComponentFields[type];
		}

		private static FieldInfo GetComponentXmlField(Type type, string fieldName)
		{
			Dictionary<string, FieldInfo> componentXmlFields = GetComponentXmlFields(type);
			if (componentXmlFields.ContainsKey(fieldName))
			{
				return componentXmlFields[fieldName];
			}
			return null;
		}

		public virtual XmlElement GetInstance(RectTransform parent, XmlLayout xmlLayout, string overridePrefabPath = null)
		{
			currentInstanceTransform = Instantiate(parent, overridePrefabPath ?? prefabPath);
			XmlElement xmlElement = currentInstanceTransform.gameObject.GetComponent<XmlElement>() ?? currentInstanceTransform.gameObject.AddComponent<XmlElement>();
			xmlElement.Initialise(xmlLayout, currentInstanceTransform, this);
			XmlElement component = parent.GetComponent<XmlElement>();
			if (component != null)
			{
				component.AddChildElement(xmlElement);
			}
			xmlElement.gameObject.layer = uiLayer;
			return xmlElement;
		}

		public virtual void SetInstance(RectTransform instanceTransform, XmlLayout xmlLayout)
		{
			currentInstanceTransform = instanceTransform;
			currentXmlLayoutInstance = xmlLayout;
			XmlElement xmlElement = currentXmlElement;
			if (instanceTransform != null && xmlElement == null)
			{
				xmlElement = currentInstanceTransform.gameObject.AddComponent<XmlElement>();
			}
			if (xmlElement != null)
			{
				xmlElement.Initialise(xmlLayout, instanceTransform, this);
			}
		}

		public virtual void SetInstance(XmlElement element)
		{
			SetInstance(element.rectTransform, element.xmlLayoutInstance);
		}

		public virtual void ApplyAttributes(AttributeDictionary attributesToApply)
		{
			if (currentInstanceTransform == null || currentXmlLayoutInstance == null)
			{
				Debug.LogWarning("[XmlLayout][Warning] Please call ElementTagHandler.SetInstance() before using XmlElement.ApplyAttributes()");
				return;
			}
			attributesToApply = HandleCustomAttributes(attributesToApply);
			MonoBehaviour monoBehaviour = primaryComponent;
			if (attributesToApply.Any((KeyValuePair<string, string> a) => !string.Equals("onValueChanged", a.Key, StringComparison.OrdinalIgnoreCase) && eventAttributeNames.Contains(a.Key, StringComparer.OrdinalIgnoreCase)))
			{
				attributesToApply.AddIfKeyNotExists("raycastTarget", "true");
			}
			else if (!string.IsNullOrEmpty(attributesToApply.GetValue("tooltip")))
			{
				attributesToApply.AddIfKeyNotExists("raycastTarget", "true");
			}
			if (attributesToApply.ContainsKey("allowDragging") && attributesToApply["allowDragging"].ToBoolean() && currentXmlElement.GetComponent<XmlLayoutDragEventHandler>() == null)
			{
				currentXmlElement.gameObject.AddComponent<XmlLayoutDragEventHandler>();
			}
			foreach (KeyValuePair<string, string> item in attributesToApply)
			{
				string text = item.Key.ToLower();
				string value = item.Value;
				if (eventAttributeNames.Contains(text, StringComparer.OrdinalIgnoreCase))
				{
					if (Application.isPlaying)
					{
						HandleEventAttribute(text, value);
					}
				}
				else if ((!(monoBehaviour != null) || !SetPropertyValue(monoBehaviour, text, value)) && !SetPropertyValue(currentInstanceTransform, text, value) && !SetPropertyValue(layoutElement, text, value) && !SetPropertyValue(currentXmlElement, text, value) && imageComponent != null)
				{
					SetPropertyValue(imageComponent, text, value);
				}
			}
			if (!dontCallHandleDataSourceAttributeAutomatically && attributesToApply.ContainsKey("vm-dataSource"))
			{
				HandleDataSourceAttribute(attributesToApply["vm-dataSource"]);
			}
			if (!currentXmlElement.attributes.ContainsKey("vm-dataSource"))
			{
				currentXmlLayoutInstance.ElementDataSources.RemoveAll((XmlElementDataSource ed) => ed.XmlElement == currentXmlElement);
			}
		}

		private static PropertyInfo GetTypeProperty(Type type, string propertyName)
		{
			Dictionary<string, PropertyInfo> value = null;
			if (!_lookup.TryGetValue(type, out value))
			{
				value = new Dictionary<string, PropertyInfo>();
				_lookup[type] = value;
			}
			PropertyInfo value2 = null;
			if (!value.TryGetValue(propertyName, out value2))
			{
				value2 = (value[propertyName] = type.GetProperty(propertyName, XmlLayoutUtilities.BindingFlags));
			}
			return value2;
		}

		protected bool SetPropertyValue(object o, string propertyName, string value)
		{
			if (o == null)
			{
				return false;
			}
			Type type = o.GetType();
			FieldInfo componentXmlField = GetComponentXmlField(type, propertyName);
			bool flag = !defaultAttributeValues.ContainsKey(propertyName);
			object obj = null;
			bool result = false;
			try
			{
				if (componentXmlField != null)
				{
					if (flag)
					{
						obj = componentXmlField.GetValue(o);
					}
					componentXmlField.SetValue(o, value.ChangeToType(componentXmlField.FieldType, currentXmlLayoutInstance));
					result = true;
				}
				else
				{
					PropertyInfo typeProperty = GetTypeProperty(type, propertyName);
					if (typeProperty != null && typeProperty.GetSetMethod(nonPublic: false) != null)
					{
						if (flag && typeProperty.GetGetMethod(nonPublic: false) != null)
						{
							obj = typeProperty.GetValue(o, XmlLayoutUtilities.BindingFlags, null, null, null);
						}
						object obj2 = value.ChangeToType(typeProperty.PropertyType, currentXmlLayoutInstance);
						if ((type == typeof(InputField) || type == typeof(TMP_InputField)) && propertyName == "text")
						{
							try
							{
								typeProperty.SetValue(o, StringExtensions.DecodeEncodedNonAsciiCharacters((string)obj2), null);
							}
							catch
							{
							}
						}
						else if (typeof(Graphic).IsAssignableFrom(type) && propertyName.Equals("raycastTarget", StringComparison.OrdinalIgnoreCase) && !((Graphic)o).IsActive())
						{
							Graphic graphic = (Graphic)o;
							graphic.raycastTarget = (bool)obj2;
							GraphicRegistry.UnregisterRaycastGraphicForCanvas(graphic.canvas, graphic);
						}
						else
						{
							typeProperty.SetValue(o, obj2, null);
						}
						result = true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log("[XmlLayout] " + ex.Message + " (propertyName == '" + propertyName + "', value == '" + value + "')");
			}
			if (flag && obj != null)
			{
				string value2 = obj.ConvertToAttributeString();
				defaultAttributeValues.SetValue(propertyName, value2);
				if (propertyName == "sprite")
				{
					defaultAttributeValues.SetValue("image", value2);
				}
			}
			return result;
		}

		internal void ApplyEventAttributes()
		{
			foreach (KeyValuePair<string, string> item in currentXmlElement.attributes.Where((KeyValuePair<string, string> a) => eventAttributeNames.Contains(a.Key, StringComparer.OrdinalIgnoreCase)).ToList())
			{
				HandleEventAttribute(item.Key.ToLower(), item.Value);
			}
		}

		protected EventData GetEventValueData(string eventValue)
		{
			string[] array = eventValue.Trim(')', ';').Split(',', '(');
			string value = null;
			if (array.Count() > 1)
			{
				value = array[1];
			}
			return new EventData
			{
				methodName = array[0],
				value = value
			};
		}

		protected virtual void HandleEventAttribute(string eventName, string eventValue)
		{
			XmlLayout layout = currentXmlLayoutInstance;
			if (layout.XmlLayoutController == null)
			{
				Debug.LogError("[XmlLayout] Attempted to process an event attribute for an XmlLayout with no XmlLayoutController attached.");
				return;
			}
			EventData eventData = GetEventValueData(eventValue);
			if (eventName.Equals("OnElementDropped", StringComparison.OrdinalIgnoreCase))
			{
				HandleOnDroppedEventAttribute(eventData.methodName);
				return;
			}
			RectTransform transform = currentInstanceTransform;
			MonoBehaviour _component = primaryComponent;
			PropertyInfo interactablePropertyInfo = null;
			if (_component != null)
			{
				Type type = _component.GetType();
				interactablePropertyInfo = type.GetProperty("interactable");
			}
			XmlElement component = currentInstanceTransform.GetComponent<XmlElement>();
			Action action = delegate
			{
				bool flag = true;
				if (interactablePropertyInfo != null)
				{
					flag = (bool)interactablePropertyInfo.GetValue(_component, null);
				}
				if (flag)
				{
					layout.XmlLayoutController.ReceiveMessage(eventData.methodName, eventData.value, transform);
				}
			};
			switch (eventName.ToLower())
			{
			case "onclick":
				component.AddOnClickEvent(action, clearExisting: true);
				break;
			case "onmouseenter":
				component.AddOnMouseEnterEvent(action, clearExisting: true);
				break;
			case "onmouseexit":
				component.AddOnMouseExitEvent(action, clearExisting: true);
				break;
			case "ondrag":
				component.AddOnDragEvent(action, clearExisting: true);
				break;
			case "onbegindrag":
				component.AddOnBeginDragEvent(action, clearExisting: true);
				break;
			case "onenddrag":
				component.AddOnEndDragEvent(action, clearExisting: true);
				break;
			case "onsubmit":
				component.AddOnSubmitEvent(action, clearExisting: true);
				break;
			case "onshow":
				component.AddOnShowEvent(action, clearExisting: true);
				break;
			case "onhide":
				component.AddOnHideEvent(action, clearExisting: true);
				break;
			case "onmousedown":
				component.AddOnMouseDownEvent(action, clearExisting: true);
				break;
			case "onmouseup":
				component.AddOnMouseUpEvent(action, clearExisting: true);
				break;
			default:
				Debug.LogWarning("[XmlLayout] Unknown event type: '" + eventName + "'");
				break;
			}
		}

		protected void HandleOnDroppedEventAttribute(string value)
		{
			XmlElement component = currentInstanceTransform.GetComponent<XmlElement>();
			XmlLayout layout = currentXmlLayoutInstance;
			Action<XmlElement, XmlElement> action = delegate(XmlElement item, XmlElement droppedOn)
			{
				layout.XmlLayoutController.ReceiveElementDroppedMessage(value, item, droppedOn);
			};
			component.AddOnElementDroppedEvent(action);
		}

		protected AttributeDictionary HandleCustomAttributes(AttributeDictionary attributes)
		{
			string tagName = XmlLayoutUtilities.GetTagName(GetType());
			foreach (KeyValuePair<string, string> item in attributes.Where((KeyValuePair<string, string> k) => XmlLayoutUtilities.IsCustomAttribute(k.Key)).ToList())
			{
				CustomXmlAttribute customAttribute = XmlLayoutUtilities.GetCustomAttribute(item.Key);
				if (!customAttribute.RestrictToPermittedElementsOnly || customAttribute.PermittedElements.Contains(tagName, StringComparer.OrdinalIgnoreCase))
				{
					if (customAttribute.UsesConvertMethod)
					{
						attributes = XmlLayoutUtilities.MergeAttributes(attributes, customAttribute.Convert(item.Value, attributes.AsReadOnly(), currentXmlElement));
					}
					if (customAttribute.UsesApplyMethod)
					{
						customAttribute.Apply(currentXmlElement, item.Value, attributes.AsReadOnly());
					}
					if (customAttribute.UsesApplyMethod && !defaultAttributeValues.ContainsKey(item.Key))
					{
						defaultAttributeValues.Add(item.Key, customAttribute.DefaultValue);
					}
					if (!customAttribute.KeepOriginalTag)
					{
						attributes.Remove(item.Key);
					}
				}
			}
			return attributes;
		}

		protected RectTransform Instantiate(RectTransform parent, string name = "")
		{
			GameObject gameObject = XmlLayoutUtilities.LoadResource<GameObject>(name);
			GameObject gameObject2 = null;
			RectTransform rectTransform = null;
			if (gameObject != null)
			{
				gameObject2 = UnityEngine.Object.Instantiate(gameObject);
				rectTransform = gameObject2.GetComponent<RectTransform>();
				rectTransform.SetParent(parent);
				FixInstanceTransform(gameObject.transform as RectTransform, rectTransform);
			}
			else
			{
				if (!string.IsNullOrEmpty(name))
				{
					Debug.Log("Warning: prefab '" + name + "' not found.");
				}
				gameObject2 = new GameObject(name);
			}
			if (rectTransform == null)
			{
				rectTransform = gameObject2.AddComponent<RectTransform>();
			}
			if (name != null && name.Contains("/") && !name.EndsWith("/"))
			{
				name = name.Substring(name.LastIndexOf("/") + 1);
			}
			gameObject2.name = name ?? "Xml Element";
			if (rectTransform.parent != parent)
			{
				rectTransform.SetParent(parent);
			}
			return rectTransform;
		}

		protected static void FixInstanceTransform(RectTransform baseTransform, RectTransform instanceTransform)
		{
			instanceTransform.localPosition = baseTransform.localPosition;
			instanceTransform.position = baseTransform.position;
			instanceTransform.rotation = default(Quaternion);
			instanceTransform.localScale = baseTransform.localScale;
			instanceTransform.anchoredPosition = baseTransform.anchoredPosition;
			instanceTransform.sizeDelta = baseTransform.sizeDelta;
			instanceTransform.position = new Vector3(instanceTransform.position.x, instanceTransform.position.y, 0f);
			instanceTransform.anchoredPosition3D = new Vector3(baseTransform.anchoredPosition3D.x, baseTransform.anchoredPosition3D.y, 0f);
		}

		public virtual void Open(AttributeDictionary elementAttributes)
		{
		}

		public virtual void Close()
		{
		}

		public virtual void ParseChildElements(XmlNode xmlNode)
		{
		}

		public void RemoveElement()
		{
			if (currentXmlElement.parentElement != null)
			{
				currentXmlElement.parentElement.RemoveChildElement(currentXmlElement);
			}
			if (Application.isPlaying)
			{
				UnityEngine.Object.Destroy(currentXmlElement.gameObject);
			}
			else
			{
				UnityEngine.Object.DestroyImmediate(currentXmlElement.gameObject);
			}
		}

		public virtual void SetValue(string newValue, bool fireEventHandlers = true)
		{
			ApplyAttributes(new AttributeDictionary { { "text", newValue } });
		}

		public virtual void ClassChanged()
		{
			if (currentXmlLayoutInstance.defaultAttributeValues.ContainsKey(tagType))
			{
				AttributeDictionary attributeDictionary = new AttributeDictionary();
				AttributeDictionary elementAttributes = new AttributeDictionary(currentXmlElement.elementAttributes.ToDictionary((string k) => k, (string v) => currentXmlElement.GetAttribute(v)));
				attributeDictionary = currentXmlLayoutInstance.MergeDefaultAttributesWithElementAttributes(currentXmlElement, tagType, elementAttributes);
				attributeDictionary = new AttributeDictionary(attributeDictionary.Where((KeyValuePair<string, string> a) => !currentXmlElement.elementAttributes.Contains(a.Key)).ToDictionary((KeyValuePair<string, string> k) => k.Key, (KeyValuePair<string, string> v) => v.Value));
				currentXmlElement.ApplyAttributes(attributeDictionary);
			}
		}

		public string GetDefaultValueForAttribute(string attribute)
		{
			if (!defaultAttributeValues.ContainsKey(attribute))
			{
				return string.Empty;
			}
			return defaultAttributeValues[attribute];
		}

		protected void MatchParentDimensions()
		{
			RectTransform rectTransform = currentInstanceTransform.parent as RectTransform;
			currentInstanceTransform.localPosition = Vector3.zero;
			currentInstanceTransform.anchoredPosition3D = Vector3.zero;
			currentInstanceTransform.anchorMin = Vector2.zero;
			currentInstanceTransform.anchorMax = Vector2.one;
			currentInstanceTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, rectTransform.rect.width);
			currentInstanceTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTransform.rect.height);
			currentXmlElement.currentOffset = Vector2.zero;
		}

		protected bool ElementHasAttribute(string attributeName, AttributeDictionary attributesToApply, XmlElement element = null)
		{
			if (element == null)
			{
				element = currentXmlElement;
			}
			if (!attributesToApply.ContainsKey(attributeName))
			{
				return element.HasAttribute(attributeName);
			}
			return true;
		}

		public virtual void SetListData(IObservableList list)
		{
		}

		protected virtual void HandleDataSourceAttribute(string dataSource, string additionalDataSource = null)
		{
			XmlElementDataSource xmlElementDataSource = new XmlElementDataSource(dataSource, currentXmlElement);
			currentXmlLayoutInstance.ElementDataSources.RemoveAll((XmlElementDataSource ed) => ed.XmlElement == currentXmlElement);
			currentXmlLayoutInstance.ElementDataSources.Add(xmlElementDataSource);
			if (xmlElementDataSource.BindingType == ViewModelBindingType.TwoWay)
			{
				EnableGenericTwoWayBinding(dataSource);
			}
			if (!currentXmlLayoutInstance.rebuildInProgress && currentXmlLayoutInstance.XmlLayoutController != null && currentXmlLayoutInstance.XmlLayoutController is XmlLayoutControllerMVVM)
			{
				((XmlLayoutControllerMVVM)currentXmlLayoutInstance.XmlLayoutController).ViewModelMemberChanged(dataSource);
			}
		}

		private void EnableGenericTwoWayBinding(string dataSource)
		{
			if (primaryComponent == null)
			{
				return;
			}
			MemberInfo memberInfo = primaryComponent.GetType().GetMember("onValueChanged").FirstOrDefault();
			if (!(memberInfo != null))
			{
				return;
			}
			object memberValue = memberInfo.GetMemberValue(primaryComponent);
			Type type = memberValue.GetType().GetMethod("AddListener").GetParameters()[0].ParameterType.GetGenericArguments()[0];
			XmlLayoutControllerMVVM controller = (XmlLayoutControllerMVVM)currentXmlLayoutInstance.XmlLayoutController;
			if (type == typeof(float))
			{
				((UnityEvent<float>)memberValue).AddListener(delegate(float v)
				{
					controller.SetViewModelValue(dataSource, v, fromTwoWayBinding: true);
				});
			}
			else if (type == typeof(int))
			{
				((UnityEvent<int>)memberValue).AddListener(delegate(int v)
				{
					controller.SetViewModelValue(dataSource, v, fromTwoWayBinding: true);
				});
			}
			else if (type == typeof(string))
			{
				((UnityEvent<string>)memberValue).AddListener(delegate(string v)
				{
					controller.SetViewModelValue(dataSource, v, fromTwoWayBinding: true);
				});
			}
			else if (type == typeof(bool))
			{
				((UnityEvent<bool>)memberValue).AddListener(delegate(bool v)
				{
					controller.SetViewModelValue(dataSource, v, fromTwoWayBinding: true);
				});
			}
		}
	}
}
