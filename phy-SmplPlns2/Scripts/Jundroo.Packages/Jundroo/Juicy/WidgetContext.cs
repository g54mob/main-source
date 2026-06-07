using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Jundroo.Juicy.Widgets.Extra;
using UnityEngine;

namespace Jundroo.Juicy
{
	public class WidgetContext : IWidgetContext
	{
		private object _eventHandler;

		private RectTransform _parent;

		private WidgetContextSound _sound;

		private TooltipWidget _tooltip;

		private Widget _tooltipTarget;

		private float _tooltipTimer;

		public static float GlobalSoundVolume { get; set; } = 1f;

		public List<string> Devices { get; private set; } = new List<string>();

		public IDynamicExpressionSource ExpressionSource { get; set; }

		public ILinkHandler LinkHandler { get; set; }

		public IResourceLoader ResourceLoader { get; private set; }

		public Widget Root { get; private set; }

		public ITooltipService TooltipService { get; set; }

		public WidgetContext(RectTransform parent, object eventHandler, IResourceLoader resourceLoader, AudioSource audioSource)
		{
			ResourceLoader = resourceLoader;
			_parent = parent.GetComponent<RectTransform>();
			_eventHandler = eventHandler;
			_sound = new WidgetContextSound(audioSource, resourceLoader);
		}

		public Widget CreateWidget(XElement widgetElement, Widget parent, Stylesheet stylesheet)
		{
			stylesheet.ProcessConstants(widgetElement);
			string localName = widgetElement.Name.LocalName;
			if (localName == "File" && widgetElement.GetBoolAttribute("inline", defaultValue: true))
			{
				string stringAttribute = widgetElement.GetStringAttribute("path");
				return LoadWidgetFromXml(stringAttribute, parent);
			}
			if (localName == "Instance")
			{
				return CreateWidgetFromTemplate(widgetElement, parent, stylesheet);
			}
			GameObject gameObject = ResourceLoader.LoadWidgetGameObject(localName);
			if (gameObject != null)
			{
				Widget component = gameObject.GetComponent<Widget>();
				WidgetStyle elementStyle = new WidgetStyle("Instance", widgetElement);
				try
				{
					component.Initialize(this, widgetElement);
					if (parent != null)
					{
						parent.AddWidget(component);
					}
					else
					{
						component.Rect.SetParent(_parent, worldPositionStays: false);
					}
					if (!widgetElement.GetBoolAttribute("lazyLoadChildren"))
					{
						component.LoadChildren(stylesheet);
					}
					List<string> list = widgetElement.GetStringAttribute("class", string.Empty)?.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
					list.Add(localName);
					component.InitializeStyles(stylesheet, elementStyle, list);
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
					Debug.LogError("Could not initialize widget from XML element '" + widgetElement.Name.LocalName + "'. Error: " + ex.Message);
				}
				return component;
			}
			throw new Exception("Could not find widget " + widgetElement.Name.LocalName);
		}

		public Widget CreateWidgetFromTemplate(string templateId, Widget parent, IEnumerable<XAttribute> instanceAttributes = null, Stylesheet stylesheet = null)
		{
			if (parent == null)
			{
				throw new ArgumentNullException("parent");
			}
			XElement template = parent.Stylesheet.GetTemplate(templateId);
			if (template == null)
			{
				throw new WidgetException("Could not find template with ID '" + templateId + "'");
			}
			XElement template2 = CreateTemplateInstance(template, null);
			return CreateWidgetFromTemplate(parent, stylesheet ?? parent.Stylesheet, template, template2, instanceAttributes);
		}

		public void HideTooltip(Widget widget)
		{
			if (_tooltipTarget == widget)
			{
				DestroyTooltip();
			}
		}

		public void LateUpdate()
		{
			Root?.UpdateWidget(null);
			if (_tooltip != null)
			{
				_tooltipTimer -= Time.deltaTime;
				if (_tooltipTimer <= 0f)
				{
					DestroyTooltip();
				}
			}
		}

		public Widget LoadWidgetFromXml(string xmlPath, Widget parent)
		{
			try
			{
				XElement xml = ResourceLoader.LoadXml(xmlPath);
				return LoadWidgetFromXml(xml, parent);
			}
			catch (Exception inner)
			{
				throw new WidgetException("Could not load widget from path " + xmlPath, inner);
			}
		}

		public Widget LoadWidgetFromXml(XElement xml, Widget parent)
		{
			Stylesheet stylesheet = new Stylesheet();
			IEnumerable<XElement> enumerable = xml.Element("Stylesheets")?.Elements("Stylesheet");
			if (enumerable != null)
			{
				foreach (XElement item in enumerable)
				{
					string stringAttribute = item.GetStringAttribute("path");
					if (stringAttribute != null)
					{
						XElement xml2 = ResourceLoader.LoadXml(stringAttribute);
						stylesheet.LoadXml(xml2, this);
					}
					else
					{
						stylesheet.LoadXml(item, this);
					}
				}
			}
			XElement widgetElement = xml.Element("Widgets").Elements().FirstOrDefault();
			Widget widget = CreateWidget(widgetElement, parent, stylesheet);
			if (Root == null && parent == null)
			{
				Root = widget;
				Root.Destroyed += OnRootDestroyed;
				if (Root.EventHandler == null)
				{
					Root.EventHandler = _eventHandler;
				}
			}
			return widget;
		}

		public void PlaySound(SoundData sound, float volumeMultiplier = 1f)
		{
			_sound.PlaySound(sound, volumeMultiplier);
		}

		public bool PreprocessElement(XElement childElement)
		{
			string text = childElement.Attribute("device")?.Value;
			if (text != null)
			{
				bool flag = false;
				if (text.StartsWith("-"))
				{
					flag = true;
					text = text.Substring(1);
				}
				bool flag2 = Devices.Contains(text);
				return flag != flag2;
			}
			return true;
		}

		public void ShowTooltip(Widget widget)
		{
			DestroyTooltip();
			if (widget != null)
			{
				_tooltipTarget = widget;
				_tooltip = CreateWidgetFromTemplate("tooltip", Root, null, widget.Stylesheet) as TooltipWidget;
				_tooltip.ConfigureForWidget(widget);
				_tooltipTimer = _tooltip.TooltipDuration;
				_tooltip.Visible = false;
				_tooltip.Show();
			}
		}

		private static XElement CreateTemplateInstance(XElement templateContainer, List<XElement> instanceSections)
		{
			XElement xElement = new XElement(templateContainer.FirstNode as XElement);
			foreach (XElement item in xElement.Descendants("TemplateSection").ToList())
			{
				string sectionId = item.GetStringAttribute("sectionId");
				XElement xElement2 = instanceSections?.Where((XElement x) => x.GetStringAttribute("sectionId") == sectionId).FirstOrDefault();
				if (xElement2 != null)
				{
					item.AddAfterSelf(xElement2.Elements());
				}
				item.Remove();
			}
			return xElement;
		}

		private Widget CreateWidgetFromTemplate(XElement instance, Widget parent, Stylesheet stylesheet)
		{
			try
			{
				string stringAttribute = instance.GetStringAttribute("templateId");
				XElement template = stylesheet.GetTemplate(stringAttribute);
				if (template == null)
				{
					throw new WidgetException("Could not find template with ID " + stringAttribute);
				}
				List<XElement> instanceSections = instance.Descendants("Section").ToList();
				XElement template2 = CreateTemplateInstance(template, instanceSections);
				List<XAttribute> instanceAttributes = instance.Attributes().ToList();
				return CreateWidgetFromTemplate(parent, stylesheet, template, template2, instanceAttributes);
			}
			catch (Exception inner)
			{
				throw new WidgetException("Could not create widget from template " + instance.ToString(), inner);
			}
		}

		private Widget CreateWidgetFromTemplate(Widget parent, Stylesheet stylesheet, XElement templateContainer, XElement template, IEnumerable<XAttribute> instanceAttributes)
		{
			stylesheet.PushConstantsLayer();
			foreach (XAttribute item in templateContainer.Attributes().ToList())
			{
				string localName = item.Name.LocalName;
				string value = item.Value;
				if (localName != "templateId")
				{
					stylesheet.SetConstant(localName, value);
				}
			}
			if (instanceAttributes != null)
			{
				foreach (XAttribute instanceAttribute in instanceAttributes)
				{
					string localName2 = instanceAttribute.Name.LocalName;
					string value2 = instanceAttribute.Value;
					if (localName2 != "templateId")
					{
						stylesheet.SetConstant(localName2, value2);
					}
				}
			}
			Widget result = CreateWidget(template, parent, stylesheet);
			stylesheet.PopConstantsLayer();
			return result;
		}

		private void DestroyTooltip()
		{
			_tooltipTarget = null;
			if (_tooltip != null)
			{
				_tooltip.Destroy();
				_tooltip = null;
			}
		}

		private void OnRootDestroyed(Widget widget)
		{
			Root.Destroyed -= OnRootDestroyed;
			Root = null;
		}
	}
}
