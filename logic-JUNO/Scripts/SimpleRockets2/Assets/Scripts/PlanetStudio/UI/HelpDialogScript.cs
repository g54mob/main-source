using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PlanetStudio.UI
{
	public class HelpDialogScript : DialogScript
	{
		private Transform _inactiveSections;

		private XmlElement _panel;

		private RectTransform _scrollRectContent;

		private string _sectionId;

		private XmlLayout _xmlLayout;

		public static HelpDialogScript Create(Transform parent, bool fadeIn = true)
		{
			return Game.Instance.UserInterface.CreateDialog("Ui/Xml/PlanetStudio/HelpDialog", parent, delegate(HelpDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			}, null, fadeIn);
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				Object.Destroy(base.gameObject);
			});
		}

		protected override void Start()
		{
			base.Start();
			_panel.Show();
			SelectSection("intro");
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this && (UnityEngine.Input.GetKeyDown(KeyCode.Escape) || UnityEngine.Input.GetKeyDown(KeyCode.Return)))
			{
				OnCloseClicked();
			}
		}

		private void EnableSection(string sectionId, bool enabled)
		{
			if (string.IsNullOrWhiteSpace(sectionId))
			{
				return;
			}
			XmlElement elementByInternalId = _panel.GetElementByInternalId(sectionId);
			XmlElement elementById = _xmlLayout.GetElementById(sectionId);
			elementById.SetActive(enabled);
			if (enabled)
			{
				elementByInternalId.AddClass("btn-primary");
				TextMeshProUGUI[] componentsInChildren = elementById.GetComponentsInChildren<TextMeshProUGUI>(includeInactive: true);
				foreach (TextMeshProUGUI obj in componentsInChildren)
				{
					obj.text = obj.text.Replace("\n ", "\n");
				}
				elementById.transform.SetParent(_scrollRectContent, worldPositionStays: false);
			}
			else
			{
				elementByInternalId.RemoveClass("btn-primary");
				elementById.transform.SetParent(_inactiveSections, worldPositionStays: false);
			}
			elementByInternalId.ApplyAttributesRecursive();
		}

		private void OnCloseClicked()
		{
			Close();
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_xmlLayout = xmlLayout;
			_panel = xmlLayout.GetElementById("panel");
			_inactiveSections = xmlLayout.GetElementById("panel").transform;
			_scrollRectContent = xmlLayout.GetElementById<ScrollRect>("scroll-rect").content;
			_panel.SetAttribute("active", "false");
		}

		private void OnSectionLinkClicked(XmlElement element)
		{
			string internalId = element.internalId;
			SelectSection(internalId);
			_scrollRectContent.anchoredPosition = Vector2.zero;
		}

		private void SelectSection(string sectionId)
		{
			EnableSection(_sectionId, enabled: false);
			_sectionId = sectionId;
			EnableSection(_sectionId, enabled: true);
		}
	}
}
