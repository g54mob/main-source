using System.Collections.Generic;
using NSEipix;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Repository;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class TooltipNew : MonoBehaviour
	{
		private static Vector3[] tmpCorners = new Vector3[4];

		[SerializeField]
		private RectTransform rect;

		[SerializeField]
		private ContentSizeFitterWithMax sizeFitterWithMax;

		[SerializeField]
		private GameObject linePrefab;

		[SerializeField]
		private RectTransform contentText;

		[SerializeField]
		private RectTransform contentPrefabs;

		[SerializeField]
		private RectTransform contentCanvasTransform;

		[SerializeField]
		private Image blurBackground;

		[SerializeField]
		private Animator fadingAnimator;

		private List<GameObject> lineObjects = new List<GameObject>();

		private readonly List<GameObject> prefabObjects = new List<GameObject>();

		private readonly List<string> lines = new List<string>();

		private bool showing;

		private const float PointerOffsetXY = 16f;

		private float delay;

		private TooltipViewNew tooltipViewShowing;

		private TMP_Style defaultStyle;

		private Vector2 CanvasSize => contentCanvasTransform.GetWorldSize();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			tmpCorners = new Vector3[4];
		}

		public void Show(IEnumerable<string> lines, TooltipViewNew source)
		{
			tooltipViewShowing = source;
			showing = false;
			if (contentText.gameObject.activeSelf)
			{
				contentText.gameObject.SetActive(value: false);
			}
			if (contentPrefabs.gameObject.activeSelf)
			{
				contentPrefabs.gameObject.SetActive(value: false);
			}
			bool flag = tooltipViewShowing != null && tooltipViewShowing.ShowPrefabsFirst;
			contentPrefabs.SetSiblingIndex((!flag) ? 1 : 0);
			contentText.SetSiblingIndex(flag ? 1 : 0);
			this.lines.Clear();
			this.lines.AddRange(lines);
			foreach (GameObject prefabObject in prefabObjects)
			{
				if (prefabObject.activeSelf)
				{
					prefabObject.SetActive(value: false);
				}
			}
			prefabObjects.Clear();
			if (source != null && source.Prefabs != null)
			{
				foreach (GameObject prefab in source.Prefabs)
				{
					prefab.transform.localScale = Vector3.one;
				}
				prefabObjects.AddRange(source.Prefabs);
			}
			delay = 0.25f;
		}

		public void RefreshTooltip(IEnumerable<string> newLines)
		{
			lines.Clear();
			lines.AddRange(newLines);
			FillLinesAndShow();
		}

		public void Hide()
		{
			fadingAnimator.SetBool("Visible", value: false);
			delay = 0f;
			showing = false;
			if (contentText.gameObject.activeSelf)
			{
				contentText.gameObject.SetActive(value: false);
			}
			if (contentPrefabs.gameObject.activeSelf)
			{
				contentPrefabs.gameObject.SetActive(value: false);
			}
			foreach (GameObject prefabObject in prefabObjects)
			{
				if (prefabObject.activeSelf)
				{
					prefabObject.SetActive(value: false);
				}
			}
			prefabObjects.Clear();
			blurBackground.enabled = false;
			tooltipViewShowing = null;
		}

		private void Start()
		{
			linePrefab.gameObject.SetActive(value: false);
			defaultStyle = MonoRepository<StyleSheetRepository, KeyStyleSheetPair>.Instance.GeStyleSheet("Default").GetStyle("TooltipDefault");
			Hide();
		}

		private void Update()
		{
			if (delay > 0f)
			{
				delay -= Time.unscaledDeltaTime;
				if (delay <= 0f)
				{
					FillLinesAndShow();
				}
			}
			if (showing)
			{
				SetPivotAndPosition();
			}
		}

		private void SetPivotAndPosition()
		{
			Vector2 worldSizeNonAlloc = GetComponent<RectTransform>().GetWorldSizeNonAlloc(ref tmpCorners);
			contentPrefabs.localScale = Vector3.one;
			bool activeSelf = contentPrefabs.gameObject.activeSelf;
			if (!activeSelf && tooltipViewShowing != null)
			{
				sizeFitterWithMax.maxWidth = tooltipViewShowing.MaxWidth;
			}
			Vector2 vector = (activeSelf ? contentPrefabs.GetWorldSize() : Vector2.zero);
			Vector2 vector2 = (contentText.gameObject.activeSelf ? contentText.GetWorldSize() : Vector2.zero);
			Vector2 vector3 = new Vector2(Mathf.Max(vector.x, vector2.x), vector.y + vector2.y);
			Vector3 vector4 = Input.mousePosition;
			float num = ((tooltipViewShowing == null || tooltipViewShowing.AnchoringPosition == AnchoringPosition.None) ? 16f : 0f);
			Vector3 zero = Vector3.zero;
			if (tooltipViewShowing != null && tooltipViewShowing.AnchoringPosition != AnchoringPosition.None)
			{
				tooltipViewShowing.RectTransform.GetWorldCorners(tmpCorners);
				Vector3 vector5 = (tmpCorners[0] + tmpCorners[2]) * 0.5f;
				Vector3 vector6 = Vector3.Max(tmpCorners[0], tmpCorners[2]) - Vector3.Min(tmpCorners[0], tmpCorners[2]);
				vector4 = vector5;
				if (tooltipViewShowing.AnchoringPosition == AnchoringPosition.LeftOrRight)
				{
					zero.x = vector6.x / 2f;
					zero.y = vector3.y / 2f;
				}
				if (tooltipViewShowing.AnchoringPosition == AnchoringPosition.Corners)
				{
					zero.x = vector6.x / 2f;
					zero.y = (0f - vector6.y) / 2f;
				}
				if (tooltipViewShowing.AnchoringPosition == AnchoringPosition.TopOrBottom)
				{
					zero.x = (0f - vector3.x) / 2f;
					zero.y = (0f - vector6.y) / 2f;
				}
			}
			vector4.y -= vector3.y;
			Vector3 vector7 = vector4 + zero + Vector3.right * vector3.x;
			if (vector7.y < num)
			{
				vector4.y += vector3.y + num;
				zero.y *= -1f;
			}
			else
			{
				vector4.y -= num;
			}
			if (vector7.x + num > worldSizeNonAlloc.x)
			{
				vector4.x -= vector3.x + num;
				zero.x *= -1f;
			}
			else
			{
				vector4.x += num;
			}
			vector4 += zero;
			vector4.x = Mathf.Max(0f, Mathf.Min(worldSizeNonAlloc.x - vector3.x, vector4.x));
			vector4.y = Mathf.Max(0f, Mathf.Min(worldSizeNonAlloc.y - vector3.y, vector4.y));
			rect.pivot = Vector2.zero;
			rect.position = vector4;
			Vector4 vector8 = rect.worldToLocalMatrix * vector3;
			rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, vector8.x);
			rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vector8.y);
		}

		private void FillLinesAndShow()
		{
			blurBackground.enabled = true;
			int num = 0;
			foreach (string line in lines)
			{
				GameObject at = GetAt(ref lineObjects, num, contentText.transform);
				TMP_Text tMP_Text = at.GetComponent<TextMeshProUGUI>();
				if (tMP_Text == null)
				{
					tMP_Text = at.AddComponent<TextMeshProUGUI>();
				}
				tMP_Text.textStyle = defaultStyle;
				tMP_Text.text = line;
				tMP_Text.raycastTarget = false;
				num++;
			}
			for (int i = num; i < lineObjects.Count; i++)
			{
				lineObjects[i]?.SetActive(value: false);
			}
			foreach (GameObject prefabObject in prefabObjects)
			{
				prefabObject.transform.SetParent(contentPrefabs.transform, worldPositionStays: false);
				prefabObject.transform.localPosition = Vector3.zero;
			}
			showing = true;
			fadingAnimator.SetBool("Visible", value: true);
			if (lines != null && lines.Count > 0 && !contentText.gameObject.activeSelf)
			{
				contentText.gameObject.SetActive(value: true);
			}
			if (prefabObjects != null && prefabObjects.Count > 0 && !contentPrefabs.gameObject.activeSelf)
			{
				contentPrefabs.gameObject.SetActive(value: true);
				contentPrefabs.transform.localPosition = Vector3.zero;
			}
			if (contentText.gameObject.activeInHierarchy)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(contentText.transform as RectTransform);
			}
			SetPivotAndPosition();
		}

		private GameObject GetAt(ref List<GameObject> gameObjects, int index, Transform parent)
		{
			if (gameObjects.Count > index)
			{
				GameObject gameObject = gameObjects[index];
				if (gameObject != null)
				{
					if (gameObject.transform.parent != parent)
					{
						gameObject.transform.parent = parent;
					}
					if (!gameObject.activeSelf)
					{
						gameObject.SetActive(value: true);
					}
					return gameObject;
				}
			}
			GameObject gameObject2 = Object.Instantiate(linePrefab.gameObject, parent, worldPositionStays: true);
			gameObject2.layer = base.gameObject.layer;
			gameObject2.transform.localScale = Vector3.one;
			gameObject2.transform.localPosition = Vector3.zero;
			gameObjects.Add(gameObject2);
			gameObject2.SetActive(value: true);
			return gameObject2;
		}
	}
}
