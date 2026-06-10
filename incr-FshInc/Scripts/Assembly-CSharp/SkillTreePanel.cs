using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreePanel : MonoBehaviour
{
	[Header("Configuration")]
	[Tooltip("If true, only unlocked skills and their immediate neighbors will be visible.")]
	public bool enableFogOfWar = true;

	[Tooltip("The parent transform where auto-generated nodes will be spawned. If null, spawns on this object.")]
	public Transform nodeParentTransform;

	[Header("Line Connector")]
	public GameObject lineConnectorPrefab;

	public Transform lineParent;

	[Header("Line Colors")]
	public Color unlockedLineColor = Color.yellow;

	public Color availableLineColor = Color.white;

	public Color lockedLineColor = Color.gray;

	public Color hoverLineColor = Color.cyan;

	[Header("Hint System")]
	public SuperTextMesh skillHintText;

	public GameObject controlsHintParent;

	private float lastInteractionTime;

	private const float HINT_DELAY = 5f;

	private SuperTextMesh[] cachedControlHints;

	[Header("Animation Settings")]
	public float lineDrawDuration = 0.4f;

	public Ease lineDrawEase = Ease.InOutQuad;

	public float nodeAppearDuration = 0.3f;

	public Ease nodeAppearEase = Ease.OutBack;

	public List<SkillNodeUI> allSkillNodes = new List<SkillNodeUI>();

	private SkillNodeUI hoveredNode;

	private readonly Dictionary<GameObject, (SkillNodeUI startNode, SkillNodeUI endNode)> _lineConnections = new Dictionary<GameObject, (SkillNodeUI, SkillNodeUI)>();

	public Action UpdateVisualsEvent;

	private float _timer;

	private const float TICK_INTERVAL = 1f;

	[Header("Editor Tools")]
	[Tooltip("The grid size to snap nodes to (e.g., 5).")]
	public float gridSnapValue = 5f;

	public static SkillTreePanel Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Update()
	{
		_timer += Time.unscaledDeltaTime;
		if (_timer >= 1f)
		{
			_timer = 0f;
			UpdateVisualsEvent?.Invoke();
		}
		HandleHintSystem();
	}

	private void HandleHintSystem()
	{
		if (Time.timeScale == 0f)
		{
			lastInteractionTime = Time.unscaledTime;
		}
		if (hoveredNode != null)
		{
			lastInteractionTime = Time.unscaledTime;
		}
		float target = ((Time.unscaledTime - lastInteractionTime >= 5f) ? 1f : 0f);
		float num = 0f;
		if (skillHintText != null)
		{
			num = skillHintText.color.a;
		}
		else if (cachedControlHints != null && cachedControlHints.Length != 0 && cachedControlHints[0] != null)
		{
			num = cachedControlHints[0].color.a;
		}
		float num2 = Mathf.MoveTowards(num, target, Time.unscaledDeltaTime * 2f);
		if (!(Mathf.Abs(num - num2) > Mathf.Epsilon))
		{
			return;
		}
		if (skillHintText != null)
		{
			SetTextAlpha(skillHintText, num2);
		}
		if (cachedControlHints == null)
		{
			return;
		}
		SuperTextMesh[] array = cachedControlHints;
		foreach (SuperTextMesh superTextMesh in array)
		{
			if (superTextMesh != null)
			{
				SetTextAlpha(superTextMesh, num2);
			}
		}
	}

	private void SetTextAlpha(SuperTextMesh stm, float alpha)
	{
		Color color = stm.color;
		color.a = alpha;
		stm.color = color;
		stm.Rebuild();
	}

	private void Start()
	{
		UpdateTreeVisuals();
	}

	private void OnEnable()
	{
		UpdateAllNodeVisuals();
		lastInteractionTime = Time.unscaledTime;
		if (controlsHintParent != null)
		{
			cachedControlHints = controlsHintParent.GetComponentsInChildren<SuperTextMesh>(includeInactive: true);
		}
		ForceHideHints();
	}

	private void OnDisable()
	{
		ForceHideHints();
	}

	private void ForceHideHints()
	{
		if (skillHintText != null)
		{
			SetTextAlpha(skillHintText, 0f);
		}
		if (!(controlsHintParent != null))
		{
			return;
		}
		SuperTextMesh[] array = cachedControlHints ?? controlsHintParent.GetComponentsInChildren<SuperTextMesh>(includeInactive: true);
		foreach (SuperTextMesh superTextMesh in array)
		{
			if (superTextMesh != null)
			{
				SetTextAlpha(superTextMesh, 0f);
			}
		}
	}

	public void SetHoveredNode(SkillNodeUI node)
	{
		if (Application.isPlaying)
		{
			hoveredNode = node;
			if (hoveredNode != null)
			{
				lastInteractionTime = Time.unscaledTime;
			}
			UpdateLineColors();
		}
	}

	public bool AttemptUnlockSkill(SkillNodeUI nodeToUnlock)
	{
		lastInteractionTime = Time.unscaledTime;
		if (!Application.isPlaying)
		{
			return false;
		}
		Skill skillData = nodeToUnlock.skillData;
		if (SkillManager.Instance.GetSkillLevel(skillData.ID) >= skillData.MaxLevel)
		{
			return false;
		}
		double num = SkillManager.Instance.CalculateUpgradeCost(skillData);
		if (GameManager.Instance.SpendMoney(num, "Unlock Skill_" + skillData.ID))
		{
			SkillManager.Instance.LevelUpSkill(skillData.ID);
			int skillLevel = SkillManager.Instance.GetSkillLevel(skillData.ID);
			AnalyticsLogger.Instance.LogUpgradeBought(skillData.ID, num, GameManager.Instance.totalMoney, skillLevel);
			SkillManager.Instance.SaveSkillData();
			if (PlayerStats.Instance != null)
			{
				PlayerStats.Instance.RecalculateAllStats();
			}
			StartCoroutine(UnlockSkillAnimationRoutine(nodeToUnlock));
			SoundManager.PlaySound("Purchase");
			if (skillData.bonusType == SkillBonusType.mult_pond_unlock_cost || skillData.bonusType == SkillBonusType.mult_all_costs)
			{
				ZoneSelectionPanel zoneSelectionPanel = UnityEngine.Object.FindObjectOfType<ZoneSelectionPanel>();
				if (zoneSelectionPanel != null)
				{
					zoneSelectionPanel.RefreshUI();
				}
			}
			if (skillData.bonusType == SkillBonusType.add_rare_fish_chance || skillData.bonusType == SkillBonusType.mult_rare_fish_chance)
			{
				Debug.Log($"[SkillTreePanel] Skill {skillData.skillName} affects rare fish chances (bonusType: {skillData.bonusType}), refreshing Fish Log UI");
				FishLogPanel fishLogPanel = UnityEngine.Object.FindObjectOfType<FishLogPanel>();
				if (fishLogPanel != null)
				{
					fishLogPanel.RefreshUI();
					Debug.Log("[SkillTreePanel] Fish Log UI refreshed successfully");
				}
				else
				{
					Debug.LogWarning("[SkillTreePanel] Fish Log Panel not found, cannot refresh UI");
				}
			}
		}
		else
		{
			Debug.Log("Not enough money for next level of " + skillData.skillName);
		}
		UpdateAllNodeVisuals();
		return true;
	}

	private IEnumerator UnlockSkillAnimationRoutine(SkillNodeUI unlockedNode)
	{
		unlockedNode.UpdateVisualState();
		UpdateLineColors();
		Sequence sequence = DOTween.Sequence();
		foreach (KeyValuePair<GameObject, (SkillNodeUI, SkillNodeUI)> lineConnection in _lineConnections)
		{
			GameObject key = lineConnection.Key;
			SkillNodeUI item = lineConnection.Value.Item1;
			SkillNodeUI item2 = lineConnection.Value.Item2;
			if (!(item == unlockedNode))
			{
				continue;
			}
			bool activeInHierarchy = item2.gameObject.activeInHierarchy;
			item2.UpdateVisualState();
			if (item2.gameObject.activeInHierarchy && !activeInHierarchy)
			{
				RectTransform component = key.GetComponent<RectTransform>();
				Image component2 = key.transform.GetChild(0).GetComponent<Image>();
				float x = component.sizeDelta.x;
				component.sizeDelta = new Vector2(0f, component.sizeDelta.y);
				component2.color = lockedLineColor;
				sequence.Join(component.DOSizeDelta(new Vector2(x, component.sizeDelta.y), lineDrawDuration).SetEase(lineDrawEase));
				sequence.Join(component2.DOColor(availableLineColor, lineDrawDuration));
				item2.transform.localScale = Vector3.zero;
				sequence.Join(item2.transform.DOScale(1f, nodeAppearDuration).SetEase(nodeAppearEase).SetDelay(lineDrawDuration * 0.25f));
				Tween unlockShineAnimation = item2.GetUnlockShineAnimation();
				if (unlockShineAnimation != null)
				{
					float delay = lineDrawDuration * 0.25f + nodeAppearDuration;
					unlockShineAnimation.SetDelay(delay);
					sequence.Join(unlockShineAnimation);
				}
			}
		}
		yield return sequence.WaitForCompletion();
		UpdateLineColors();
	}

	public void UpdateTreeVisuals()
	{
		allSkillNodes.Clear();
		GetComponentsInChildren(includeInactive: true, allSkillNodes);
		foreach (SkillNodeUI allSkillNode in allSkillNodes)
		{
			allSkillNode.Setup(this);
		}
		DrawConnectionLines();
		UpdateAllNodeVisuals();
		UpdateLineColors();
	}

	private void DrawConnectionLines()
	{
		while (lineParent.childCount > 0)
		{
			UnityEngine.Object.DestroyImmediate(lineParent.GetChild(0).gameObject);
		}
		_lineConnections.Clear();
		foreach (SkillNodeUI allSkillNode in allSkillNodes)
		{
			if (!(allSkillNode.skillData != null) || allSkillNode.skillData.prerequisites.Count <= 0)
			{
				continue;
			}
			foreach (Skill prerequisite in allSkillNode.skillData.prerequisites)
			{
				SkillNodeUI skillNodeUI = FindNodeForSkill(prerequisite);
				if (!(skillNodeUI != null))
				{
					continue;
				}
				RectTransform component = skillNodeUI.GetComponent<RectTransform>();
				RectTransform component2 = allSkillNode.GetComponent<RectTransform>();
				if (component != null && component2 != null)
				{
					Color lineColor = GetLineColor(prerequisite, allSkillNode.skillData);
					GameObject gameObject = DrawLine(component, component2, lineColor);
					if (gameObject != null)
					{
						_lineConnections.Add(gameObject, (skillNodeUI, allSkillNode));
					}
				}
			}
		}
	}

	private void UpdateLineColors()
	{
		foreach (KeyValuePair<GameObject, (SkillNodeUI, SkillNodeUI)> lineConnection in _lineConnections)
		{
			GameObject key = lineConnection.Key;
			SkillNodeUI item = lineConnection.Value.Item1;
			SkillNodeUI item2 = lineConnection.Value.Item2;
			if (item.skillData == null || item2.skillData == null)
			{
				continue;
			}
			if (enableFogOfWar && (!item.gameObject.activeInHierarchy || !item2.gameObject.activeInHierarchy))
			{
				key.SetActive(value: false);
				continue;
			}
			key.SetActive(value: true);
			Color lineColor = GetLineColor(item.skillData, item2.skillData);
			if (hoveredNode != null && (item2 == hoveredNode || item == hoveredNode))
			{
				lineColor = hoverLineColor;
			}
			Image component = key.transform.GetChild(0).GetComponent<Image>();
			if (component != null)
			{
				component.DOColor(lineColor, 0.2f);
			}
		}
	}

	private Color GetLineColor(Skill prerequisiteSkill, Skill skill)
	{
		if (!Application.isPlaying)
		{
			return availableLineColor;
		}
		bool flag = SkillManager.Instance.IsSkillUnlocked(prerequisiteSkill.ID);
		bool flag2 = SkillManager.Instance.IsSkillUnlocked(skill.ID);
		if (flag && flag2)
		{
			return unlockedLineColor;
		}
		if (flag)
		{
			return availableLineColor;
		}
		return lockedLineColor;
	}

	private SkillNodeUI FindNodeForSkill(Skill skillToFind)
	{
		foreach (SkillNodeUI allSkillNode in allSkillNodes)
		{
			if (allSkillNode.skillData == skillToFind)
			{
				return allSkillNode;
			}
		}
		return null;
	}

	private void UpdateAllNodeVisuals()
	{
		foreach (SkillNodeUI allSkillNode in allSkillNodes)
		{
			allSkillNode.UpdateVisualState();
		}
	}

	private GameObject DrawLine(RectTransform startRect, RectTransform endRect, Color lineColor)
	{
		if (lineConnectorPrefab == null || startRect == null || endRect == null)
		{
			return null;
		}
		GameObject obj = UnityEngine.Object.Instantiate(lineConnectorPrefab, lineParent);
		Image component = obj.transform.GetChild(0).GetComponent<Image>();
		if (component != null)
		{
			component.color = lineColor;
		}
		RectTransform component2 = obj.GetComponent<RectTransform>();
		component2.anchorMin = new Vector2(0.5f, 0.5f);
		component2.anchorMax = new Vector2(0.5f, 0.5f);
		component2.pivot = new Vector2(0.5f, 0.5f);
		component2.localScale = Vector3.one;
		float y = 8f;
		Vector3 vector = lineParent.InverseTransformPoint(startRect.position);
		Vector3 vector2 = lineParent.InverseTransformPoint(endRect.position);
		Vector2 normalized = ((Vector2)(vector2 - vector)).normalized;
		float num = Vector2.Distance(vector, vector2);
		component2.sizeDelta = new Vector2(num, y);
		component2.localPosition = vector + (Vector3)(normalized * num * 0.5f);
		float z = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
		component2.localRotation = Quaternion.Euler(0f, 0f, z);
		return obj;
	}

	[ContextMenu("Redraw Lines Only")]
	public void RedrawLinesOnly()
	{
		allSkillNodes.Clear();
		GetComponentsInChildren(includeInactive: true, allSkillNodes);
		if (allSkillNodes.Count == 0)
		{
			Debug.LogWarning("[SkillTreePanel] No SkillNodeUI children found.");
			return;
		}
		foreach (SkillNodeUI allSkillNode in allSkillNodes)
		{
			if (!string.IsNullOrEmpty(allSkillNode.skillID) && allSkillNode.skillData == null)
			{
				allSkillNode.skillData = Resources.Load<Skill>("Skills/" + allSkillNode.skillID);
			}
		}
		DrawConnectionLines();
		Debug.Log($"[SkillTreePanel] Redrew {_lineConnections.Count} connection lines.");
	}

	[ContextMenu("Snap All Nodes to Grid")]
	public void SnapAllNodesToGrid()
	{
		allSkillNodes.Clear();
		GetComponentsInChildren(includeInactive: true, allSkillNodes);
		if (allSkillNodes.Count == 0)
		{
			Debug.LogWarning("[SkillTreePanel] No SkillNodeUI children found to snap.");
			return;
		}
		if (gridSnapValue <= 0f)
		{
			Debug.LogWarning("[SkillTreePanel] Grid Snap Value must be greater than 0.");
			return;
		}
		Debug.Log($"[SkillTreePanel] Snapping {allSkillNodes.Count} nodes to grid size {gridSnapValue} with collision resolution...");
		Dictionary<Vector2Int, SkillNodeUI> dictionary = new Dictionary<Vector2Int, SkillNodeUI>();
		foreach (SkillNodeUI allSkillNode in allSkillNodes)
		{
			RectTransform component = allSkillNode.GetComponent<RectTransform>();
			if (component != null)
			{
				Vector3 localPosition = component.localPosition;
				Vector2Int vector2Int = new Vector2Int(Mathf.RoundToInt(localPosition.x / gridSnapValue), Mathf.RoundToInt(localPosition.y / gridSnapValue));
				if (dictionary.ContainsKey(vector2Int))
				{
					vector2Int = FindNearestFreeGridSpot(vector2Int, dictionary);
				}
				dictionary[vector2Int] = allSkillNode;
				component.localPosition = new Vector3((float)vector2Int.x * gridSnapValue, (float)vector2Int.y * gridSnapValue, localPosition.z);
			}
		}
		DrawConnectionLines();
	}

	private Vector2Int FindNearestFreeGridSpot(Vector2Int center, Dictionary<Vector2Int, SkillNodeUI> occupied)
	{
		for (int i = 1; i < 100; i++)
		{
			for (int j = -i; j <= i; j++)
			{
				for (int k = -i; k <= i; k++)
				{
					if (Mathf.Abs(j) == i || Mathf.Abs(k) == i)
					{
						Vector2Int vector2Int = center + new Vector2Int(j, k);
						if (!occupied.ContainsKey(vector2Int))
						{
							return vector2Int;
						}
					}
				}
			}
		}
		return center;
	}

	private float SnapValue(float value, float snap)
	{
		if (snap <= 0f)
		{
			return value;
		}
		return Mathf.Round(value / snap) * snap;
	}
}
