using System;
using GameCreator.Runtime.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Show Floating Text")]
	[Image(typeof(IconString), ColorTheme.Type.Blue)]
	[Category("UI/Show Floating Text")]
	[Description("Displays a text in a world-space canvas when the Hotspot is enabled and hides it when is disabled. If no Prefab is provided, a default UI is displayed")]
	public class SpotShowText : Spot
	{
		private const float CANVAS_WIDTH = 600f;

		private const float CANVAS_HEIGHT = 300f;

		private const float SIZE_X = 2f;

		private const float SIZE_Y = 1f;

		private const int PADDING = 50;

		private const string FONT_NAME = "LegacyRuntime.ttf";

		private const int FONT_SIZE = 32;

		private static readonly Color COLOR_BACKGROUND = new Color(0f, 0f, 0f, 0.5f);

		[SerializeField]
		protected PropertyGetString m_Text = new PropertyGetString("Text");

		[SerializeField]
		protected PropertyGetDirection m_Offset = GetDirectionVector3Zero.Create();

		[Space]
		[SerializeField]
		protected GameObject m_Prefab;

		[NonSerialized]
		private GameObject m_Tooltip;

		[NonSerialized]
		private Text m_TooltipText;

		[NonSerialized]
		private TMP_Text m_TooltipTMPText;

		public override string Title => $"Show {m_Text}";

		public override void OnUpdate(Hotspot hotspot)
		{
			base.OnUpdate(hotspot);
			GameObject gameObject = RequireInstance(hotspot);
			if (!(gameObject == null))
			{
				Vector3 vector = m_Offset.Get(hotspot.Args);
				gameObject.transform.SetPositionAndRotation(hotspot.transform.position + vector, ShortcutMainCamera.Transform.rotation);
				bool active = EnableInstance(hotspot);
				gameObject.SetActive(active);
			}
		}

		public override void OnDisable(Hotspot hotspot)
		{
			base.OnDisable(hotspot);
			if (m_Tooltip != null)
			{
				m_Tooltip.SetActive(value: false);
			}
		}

		public override void OnDestroy(Hotspot hotspot)
		{
			base.OnDestroy(hotspot);
			if (m_Tooltip != null)
			{
				UnityEngine.Object.Destroy(m_Tooltip);
			}
		}

		protected virtual bool EnableInstance(Hotspot hotspot)
		{
			return hotspot.IsActive;
		}

		private GameObject RequireInstance(Hotspot hotspot)
		{
			if (m_Tooltip == null)
			{
				Vector3 position = m_Offset.Get(hotspot.Args);
				if (m_Prefab != null)
				{
					m_Tooltip = UnityEngine.Object.Instantiate(m_Prefab, position, hotspot.transform.rotation);
					m_TooltipText = m_Tooltip.GetComponentInChildren<Text>();
					m_TooltipTMPText = m_Tooltip.GetComponentInChildren<TMP_Text>();
				}
				else
				{
					m_Tooltip = new GameObject("Tooltip");
					m_Tooltip.transform.SetPositionAndRotation(hotspot.transform.TransformPoint(position), ShortcutMainCamera.Transform.rotation);
					Canvas canvas = m_Tooltip.AddComponent<Canvas>();
					m_Tooltip.AddComponent<CanvasScaler>();
					canvas.renderMode = RenderMode.WorldSpace;
					canvas.worldCamera = ShortcutMainCamera.Get<Camera>();
					RectTransform rectTransform = m_Tooltip.Get<RectTransform>();
					rectTransform.sizeDelta = new Vector2(600f, 300f);
					rectTransform.localScale = new Vector3(0.0033333334f, 0.0033333334f, 1f);
					RectTransform parent = ConfigureBackground(rectTransform);
					ConfigureText(parent);
				}
				m_Tooltip.hideFlags = HideFlags.HideAndDontSave;
				Args args = new Args(hotspot.gameObject, hotspot.Target);
				if (m_TooltipText != null)
				{
					m_TooltipText.text = m_Text.Get(args);
				}
				if (m_TooltipTMPText != null)
				{
					m_TooltipTMPText.text = m_Text.Get(args);
				}
			}
			return m_Tooltip;
		}

		private RectTransform ConfigureBackground(RectTransform parent)
		{
			GameObject gameObject = new GameObject("Background");
			gameObject.AddComponent<Image>().color = COLOR_BACKGROUND;
			VerticalLayoutGroup verticalLayoutGroup = gameObject.AddComponent<VerticalLayoutGroup>();
			verticalLayoutGroup.padding = new RectOffset(50, 50, 50, 50);
			verticalLayoutGroup.childAlignment = TextAnchor.MiddleCenter;
			verticalLayoutGroup.childControlWidth = true;
			verticalLayoutGroup.childControlHeight = true;
			verticalLayoutGroup.childScaleWidth = true;
			verticalLayoutGroup.childScaleHeight = true;
			verticalLayoutGroup.childForceExpandWidth = true;
			verticalLayoutGroup.childForceExpandHeight = true;
			ContentSizeFitter contentSizeFitter = gameObject.AddComponent<ContentSizeFitter>();
			contentSizeFitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
			contentSizeFitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
			RectTransform component = gameObject.GetComponent<RectTransform>();
			RectTransformUtils.SetAndCenterToParent(component, parent);
			return component;
		}

		private GameObject ConfigureText(RectTransform parent)
		{
			GameObject gameObject = new GameObject("Text");
			m_TooltipText = gameObject.AddComponent<Text>();
			Font font = (Font)Resources.GetBuiltinResource(typeof(Font), "LegacyRuntime.ttf");
			m_TooltipText.font = font;
			m_TooltipText.fontSize = 32;
			RectTransformUtils.SetAndCenterToParent(gameObject.GetComponent<RectTransform>(), parent);
			Shadow shadow = gameObject.AddComponent<Shadow>();
			shadow.effectColor = COLOR_BACKGROUND;
			shadow.effectDistance = Vector2.one;
			return gameObject;
		}
	}
}
