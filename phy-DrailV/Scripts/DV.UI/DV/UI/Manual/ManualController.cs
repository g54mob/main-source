using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DV.UIFramework;
using I2.Loc;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI.Manual
{
	public class ManualController : NullCheckingMonoBehaviour
	{
		private static readonly string[] LONG_LANGUAGE_CODES = new string[4] { "de", "fr", "nl", "pl" };

		[SerializeField]
		[NullCheck]
		private AManualProvider provider;

		[SerializeField]
		[NullCheck]
		private string pageToShowOnStart;

		[Header("Text")]
		[SerializeField]
		[NullCheck]
		private TextMeshProUGUI manualText;

		[SerializeField]
		[NullCheck]
		private TextMeshProUGUI manualTextTitle;

		[SerializeField]
		[NullCheck]
		private TextMeshProUGUI statsText;

		[Header("Keybinds")]
		[SerializeField]
		private KeyCode homeKey = KeyCode.Home;

		[SerializeField]
		private KeyCode prevPageKey = KeyCode.PageUp;

		[SerializeField]
		private KeyCode nextPageKey = KeyCode.PageDown;

		[Header("Navigation")]
		[SerializeField]
		[NullCheck]
		private TMP_InputField searchInput;

		[SerializeField]
		[NullCheck]
		private Image searchMagnifierIcon;

		[SerializeField]
		[NullCheck]
		private ButtonDV searchClearButton;

		[SerializeField]
		[NullCheck]
		private ButtonDV backHistoryButton;

		[SerializeField]
		[NullCheck]
		private ButtonDV forwardHistoryButton;

		[SerializeField]
		[NullCheck]
		private ButtonDV openInBrowserButton;

		[SerializeField]
		[NullCheck]
		private GameObject navigationButtonPrefab;

		[SerializeField]
		[NullCheck]
		private Transform navigationContainer;

		[SerializeField]
		[NullCheck]
		private ScrollRect navigationScroll;

		[SerializeField]
		[NullCheck]
		private ScrollRect contentScroll;

		[SerializeField]
		[NullCheck]
		private RectTransform articleContainer;

		[SerializeField]
		[NullCheck]
		private TextMeshProLinkHandler_DV linkHandler;

		[SerializeField]
		private Vector2 navigationButtonIndentation = new Vector2(8f, 0f);

		[SerializeField]
		private TMP_Text historyDebug;

		public readonly Dictionary<string, string> KeyToPageTitle = new Dictionary<string, string>();

		private ManualDisplayData data;

		private ManualTreeNode currentNode;

		private readonly Dictionary<CollapsibleElement, ManualTreeNode> navigationButtonToNode = new Dictionary<CollapsibleElement, ManualTreeNode>();

		private readonly Dictionary<ManualTreeNode, CollapsibleElement> nodeToNavigationButton = new Dictionary<ManualTreeNode, CollapsibleElement>();

		private readonly List<ManualTreeNode> history = new List<ManualTreeNode>();

		private int historyCurrent = -1;

		private Coroutine searchCoro;

		private string SearchInput
		{
			get
			{
				if (searchInput.text.Length > 2 && !string.IsNullOrWhiteSpace(searchInput.text))
				{
					return searchInput.text;
				}
				return "";
			}
		}

		public event Action Navigated;

		protected override void Awake()
		{
			base.Awake();
			data = ManualDataLoader.GetLocalizedData();
			if (data == null)
			{
				base.enabled = false;
				return;
			}
			InstantiateNavigationAndHyperlinkButtons();
			ToggleNavigationListeners(on: true);
			ManualTreeNode targetNode = data.root;
			if (!string.IsNullOrWhiteSpace(pageToShowOnStart))
			{
				ManualTreeNode manualTreeNode = data.root.FindNodeByKey(pageToShowOnStart);
				if (manualTreeNode != null)
				{
					targetNode = manualTreeNode;
				}
			}
			ChangeCurrentNode(targetNode, toLeaf: true, pushToHistory: true);
			LocalizationManager.OnLocalizeEvent += CheckLanguageLength;
			CheckLanguageLength();
			searchInput.onValueChanged.AddListener(OnSearchInputChanged);
			searchClearButton.Clicked += OnSearchClearClicked;
			searchClearButton.gameObject.SetActive(value: false);
			backHistoryButton.Clicked += OnBackHistoryClicked;
			forwardHistoryButton.Clicked += OnForwardHistoryClicked;
			openInBrowserButton.Clicked += OnOpenInBrowserClicked;
			linkHandler.LinkClicked += OnLinkClicked;
			UIEffectsReferences refs = GetComponentInParent<UIEffectsReferences>();
			if (!refs)
			{
				Debug.LogWarning("'" + GetType().Name + "' won't play navigation sounds, couldn't find UIEffectsReferences in hierarchy", base.gameObject);
				return;
			}
			Navigated += delegate
			{
				UISoundEffects.Play(refs.clickSound);
			};
		}

		private void OnDestroy()
		{
			LocalizationManager.OnLocalizeEvent -= CheckLanguageLength;
			ToggleNavigationListeners(on: false);
		}

		private void CheckLanguageLength()
		{
			bool flag = LONG_LANGUAGE_CODES.Contains(LocalizationManager.CurrentLanguageCode);
			manualText.alignment = (flag ? TextAlignmentOptions.TopLeft : TextAlignmentOptions.TopJustified);
		}

		private void InstantiateNavigationAndHyperlinkButtons()
		{
			ManualTreeNode root = data.root;
			InstantiateNavigationBranches(null, root);
			void InstantiateNavigationBranches(CollapsibleElement parentElement, ManualTreeNode node)
			{
				for (int i = 0; i < node.children.Count; i++)
				{
					ManualTreeNode manualTreeNode = node.children[i];
					CollapsibleElement collapsibleElement = InstantiateCollapsibleElement(parentElement, manualTreeNode);
					navigationButtonToNode.Add(collapsibleElement, manualTreeNode);
					nodeToNavigationButton.Add(manualTreeNode, collapsibleElement);
					if (!manualTreeNode.IsLeaf)
					{
						InstantiateNavigationBranches(collapsibleElement, node.children[i]);
					}
				}
			}
		}

		private CollapsibleElement InstantiateCollapsibleElement(CollapsibleElement parentElement, ManualTreeNode node)
		{
			if (navigationButtonPrefab == null)
			{
				Debug.LogError("ManualController: Missing prefab. Instantiation aborted.", this);
				return null;
			}
			if (navigationContainer == null)
			{
				Debug.LogError("ManualController: Missing element container. Instantiation aborted.", this);
				return null;
			}
			if (navigationButtonPrefab.GetComponent<CollapsibleElement>() == null)
			{
				Debug.LogError("ManualController: Prefab does not have a CollapsibleElement component. Instantiation aborted.", this);
				return null;
			}
			RectTransform component = UnityEngine.Object.Instantiate(navigationButtonPrefab).GetComponent<RectTransform>();
			CollapsibleElement component2 = component.GetComponent<CollapsibleElement>();
			if (parentElement != null)
			{
				parentElement.AddChild(component2);
			}
			Vector2 zero = Vector2.zero;
			CollapsibleElement collapsibleElement = parentElement;
			while (collapsibleElement != null)
			{
				zero += navigationButtonIndentation;
				collapsibleElement = collapsibleElement.parentElement;
			}
			component2.layoutIndentation = zero;
			component.transform.SetParent(navigationContainer, worldPositionStays: false);
			Vector3 localPosition = component.localPosition;
			localPosition.z = 0f;
			component.localPosition = localPosition;
			component2.isLeaf = node.IsLeaf;
			component2.SetText(node.displayData.title);
			KeyToPageTitle.Add(node.key, node.displayData.title);
			UIElementTooltipNonLocalizedText componentInChildren = component2.GetComponentInChildren<UIElementTooltipNonLocalizedText>(includeInactive: true);
			if (componentInChildren != null)
			{
				componentInChildren.text = node.displayData.title;
			}
			return component2;
		}

		private void ChangeCurrentNode(ManualTreeNode targetNode, bool toLeaf, bool pushToHistory)
		{
			if (targetNode == null)
			{
				Debug.LogError("ManualController: Target node is null");
				return;
			}
			if (targetNode == currentNode)
			{
				if (nodeToNavigationButton.TryGetValue(targetNode, out var value))
				{
					value.Select();
				}
				return;
			}
			if (currentNode != null && nodeToNavigationButton.TryGetValue(currentNode, out var value2) && value2.isLeaf)
			{
				value2.Deselect();
			}
			CollapsibleElement value3;
			if (!targetNode.IsLeaf)
			{
				if (toLeaf)
				{
					if (nodeToNavigationButton.TryGetValue(targetNode, out value3))
					{
						value3.Expand(expandAll: false);
					}
					ChangeCurrentNode(targetNode.children[0], toLeaf: true, pushToHistory: true);
				}
				else if (nodeToNavigationButton.TryGetValue(targetNode, out value3))
				{
					value3.Toggle();
				}
				return;
			}
			currentNode = targetNode;
			UpdateSearchMarksInContentTMPro();
			manualTextTitle.text = currentNode.displayData.title;
			if (nodeToNavigationButton.TryGetValue(targetNode, out value3))
			{
				value3.Select();
			}
			string text = "";
			if (data.langCode != "en")
			{
				if (currentNode.displayData.usedFallback)
				{
					text = "Showing an English version of the article";
				}
				else if (currentNode.displayData.stats.Percentage < 100)
				{
					text = $"This page is {currentNode.displayData.stats.Percentage}% translated";
				}
			}
			statsText.text = text;
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(navigationContainer as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(articleContainer);
			contentScroll.verticalScrollbar.value = 1f;
			StartCoroutine(ScrollToButton(value3));
			if (pushToHistory)
			{
				historyCurrent++;
				if (history.Count > historyCurrent)
				{
					history.RemoveRange(historyCurrent, history.Count - historyCurrent);
				}
				history.Add(currentNode);
			}
			backHistoryButton.ToggleInteractable(historyCurrent > 0);
			forwardHistoryButton.ToggleInteractable(historyCurrent < history.Count - 1);
			this.Navigated?.Invoke();
		}

		private void GoThroughHistory(bool back)
		{
			int num = ((!back) ? 1 : (-1));
			int num2 = Mathf.Clamp(historyCurrent + num, 0, history.Count - 1);
			if (num2 != historyCurrent)
			{
				historyCurrent = num2;
				ChangeCurrentNode(history[historyCurrent], toLeaf: false, pushToHistory: false);
			}
		}

		private IEnumerator ScrollToButton(CollapsibleElement targetElement)
		{
			if (targetElement == null)
			{
				yield break;
			}
			yield return new WaitForEndOfFrame();
			RectTransform obj = targetElement.transform as RectTransform;
			float height = navigationScroll.viewport.rect.height;
			float height2 = navigationScroll.content.rect.height;
			float y = navigationScroll.content.anchoredPosition.y;
			float num = y + height - 25f;
			float num2 = 0f - obj.anchoredPosition.y;
			if (!num2.IsInRange(y, num) && !Mathf.Approximately(height2 - height, 0f))
			{
				float num3 = (y + num) * 0.5f;
				if (!(num2 < num3))
				{
					num2 = y + (num2 - num);
				}
				float value = Mathf.Clamp01(1f - num2 / (height2 - height));
				navigationScroll.verticalScrollbar.value = value;
			}
		}

		private void ToggleNavigationListeners(bool on)
		{
			foreach (CollapsibleElement key in navigationButtonToNode.Keys)
			{
				if (!(key == null))
				{
					key.CollapsibleElementClicked -= OnNavigationButtonClicked;
					if (on)
					{
						key.CollapsibleElementClicked += OnNavigationButtonClicked;
					}
				}
			}
		}

		private void OnNavigationButtonClicked(CollapsibleElement element)
		{
			if (navigationButtonToNode.TryGetValue(element, out var value))
			{
				ChangeCurrentNode(value, toLeaf: false, pushToHistory: true);
			}
			else
			{
				Debug.LogError(string.Format("{0}: could not find node for button {1}", "ManualController", element), element);
			}
		}

		private IEnumerator DelayedSearch()
		{
			float time = (string.IsNullOrWhiteSpace(searchInput.text) ? 0f : 0.7f);
			yield return new WaitForSecondsRealtime(time);
			searchCoro = null;
			DoSearch();
		}

		private void OnSearchInputChanged(string _)
		{
			if (searchCoro != null)
			{
				StopCoroutine(searchCoro);
			}
			searchCoro = StartCoroutine(DelayedSearch());
			bool flag = searchInput.text.Length == 0;
			searchClearButton.gameObject.SetActive(!flag);
			searchMagnifierIcon.gameObject.SetActive(flag);
		}

		private void DoSearch()
		{
			if (SearchInput == "")
			{
				foreach (CollapsibleElement value3 in nodeToNavigationButton.Values)
				{
					value3.SetSearchMatched(matched: false);
				}
			}
			else
			{
				string value = SearchInput.ToLower();
				foreach (KeyValuePair<ManualTreeNode, CollapsibleElement> item in nodeToNavigationButton)
				{
					ManualTreeNode key = item.Key;
					CollapsibleElement value2 = item.Value;
					if (key.IsLeaf)
					{
						if (key.key.ToLower().Contains(value))
						{
							value2.SetSearchMatched(matched: true);
						}
						else if (key.displayData.title.ToLower().Contains(value))
						{
							value2.SetSearchMatched(matched: true);
						}
						else if (key.displayData.content.ToLower().Contains(value))
						{
							value2.SetSearchMatched(matched: true);
						}
						else
						{
							value2.SetSearchMatched(matched: false);
						}
					}
				}
			}
			UpdateSearchMarksInContentTMPro();
		}

		private void UpdateSearchMarksInContentTMPro()
		{
			if (!currentNode.IsLeaf)
			{
				manualText.text = "";
				return;
			}
			if (SearchInput == "")
			{
				manualText.text = currentNode.displayData.content;
				return;
			}
			string replace = "<style=\"search\">" + SearchInput + "</style>";
			string text = ReplaceOutsideHtmlTags(currentNode.displayData.content, SearchInput, replace);
			manualText.text = text;
		}

		private static string ReplaceOutsideHtmlTags(string input, string search, string replace)
		{
			string pattern = "<[^>]*>|([^<>]+)";
			return Regex.Replace(input, pattern, (Match match) => match.Value.StartsWith("<") ? match.Value : Regex.Replace(match.Value, Regex.Escape(search), replace, RegexOptions.IgnoreCase));
		}

		private void OnSearchClearClicked(IClickable _)
		{
			searchInput.text = "";
		}

		private void OnBackHistoryClicked(IClickable clickable)
		{
			GoThroughHistory(back: true);
		}

		private void OnForwardHistoryClicked(IClickable clickable)
		{
			GoThroughHistory(back: false);
		}

		private void OnOpenInBrowserClicked(IClickable _)
		{
			string text = data.wikiUrlPrefix + currentNode.key;
			if (data.langCode != "en")
			{
				text = text + "/" + data.langCode;
			}
			provider.OpenURL(text);
		}

		private void OnLinkClicked(string linkId)
		{
			if (string.IsNullOrWhiteSpace(linkId))
			{
				Debug.LogError("ManualController: null link clicked, ignoring.", this);
				return;
			}
			foreach (ManualTreeNode key in nodeToNavigationButton.Keys)
			{
				if (key.key == linkId)
				{
					ChangeCurrentNode(key, toLeaf: true, pushToHistory: true);
					return;
				}
			}
			if (string.IsNullOrWhiteSpace(linkId))
			{
				Debug.LogError("ManualController: invalid link '" + linkId + "' clicked, ignoring.", this);
			}
		}

		private bool HasHistoryInput(out bool usedBackButton)
		{
			bool num = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) || Input.GetKey(KeyCode.AltGr);
			bool keyDown = Input.GetKeyDown(KeyCode.LeftArrow);
			bool keyDown2 = Input.GetKeyDown(KeyCode.RightArrow);
			if (num && (keyDown || keyDown2))
			{
				usedBackButton = keyDown;
				return true;
			}
			bool buttonDown = ReInput.controllers.Mouse.GetButtonDown(3);
			bool buttonDown2 = ReInput.controllers.Mouse.GetButtonDown(4);
			if (buttonDown || buttonDown2)
			{
				usedBackButton = buttonDown;
				return true;
			}
			usedBackButton = false;
			return false;
		}

		private void Update()
		{
			if ((bool)historyDebug)
			{
				string text = "";
				for (int i = 0; i < history.Count; i++)
				{
					if (i == historyCurrent)
					{
						text += "> ";
					}
					text = text + history[i].key + "\n";
				}
				historyDebug.text = text;
			}
			if (HasHistoryInput(out var usedBackButton))
			{
				if (currentNode == null || !currentNode.IsLeaf)
				{
					return;
				}
				GoThroughHistory(usedBackButton);
			}
			bool keyDown = Input.GetKeyDown(prevPageKey);
			bool keyDown2 = Input.GetKeyDown(nextPageKey);
			if (keyDown || keyDown2)
			{
				if (currentNode == null || !currentNode.IsLeaf)
				{
					return;
				}
				ChangeCurrentNode(keyDown ? currentNode.previousNode : currentNode.nextNode, toLeaf: false, pushToHistory: true);
			}
			if (Input.GetKeyDown(homeKey) && data?.root != null)
			{
				ChangeCurrentNode(data.root, toLeaf: true, pushToHistory: true);
			}
		}
	}
}
