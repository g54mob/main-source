using System.Collections.Generic;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

[SerializeField]
public class MapNode : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerMoveHandler
{
	public MapNodeData mapNodeData;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private CanvasGroup canvasGroup;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private List<MapNodePathLine> list_PathLines;

	[SerializeField]
	private ParticleSystem particle_FOWMask;

	[SerializeField]
	private TwoMouseButtonButton button;

	[SerializeField]
	private Gradient gradient_NormalLine;

	[SerializeField]
	private Gradient gradient_AvaliableLine;

	[SerializeField]
	private Gradient gradient_PreviewLine;

	[SerializeField]
	private Gradient gradient_GuideLine;

	[SerializeField]
	private Color color_PathLineUnlit;

	[SerializeField]
	private Color color_PathLineLit;

	[SerializeField]
	private Material material_NormalLine;

	[SerializeField]
	private Material material_AvaliableLine;

	[SerializeField]
	private Material material_PreviewLine;

	[SerializeField]
	private Material material_GuideLine;

	[SerializeField]
	private float pathToIconOffset;

	[SerializeField]
	private TMP_Text text_NodeName;

	[SerializeField]
	private GameObject node_NextStageArrow;

	[SerializeField]
	private GameObject node_CompleteReward;

	[SerializeField]
	private GridLayoutGroup layout_Rewards;

	[SerializeField]
	private Image image_CompleteRewardIcon_Tower;

	[SerializeField]
	private Image image_CompleteRewardIcon_Gem;

	[SerializeField]
	[FormerlySerializedAs("image_CompleteRewardIcon_Other")]
	private Image image_CompleteRewardIcon_Tetris;

	[SerializeField]
	private Image image_CompleteRewardIcon_Relic;

	[SerializeField]
	private Image image_CompleteRewardIcon_MiniShop;

	[SerializeField]
	private Image image_CompleteRewardIcon_Quest;

	[SerializeField]
	private Image image_CompleteRewardIcon_RerollCount;

	[SerializeField]
	private SpriteRenderer sprite_Fogmask;

	[SerializeField]
	private Sprite sprite_Fogmask_Normal;

	[SerializeField]
	private Sprite sprite_Fogmask_World4;

	[SerializeField]
	private Sprite sprite_Fogmask_World100;

	[SerializeField]
	private ParticleSystem particle_Fogmask_World100;

	[SerializeField]
	private ParticleSystem particle_StageComplete;

	[SerializeField]
	private UI_Obj_MapNodeReward ui_MapNodeReward;

	[SerializeField]
	private GameObject node_AnomalyEffect_Single;

	[SerializeField]
	private GameObject node_AnomalyEffect_Duo_1;

	[SerializeField]
	private GameObject node_AnomalyEffect_Duo_2;

	[SerializeField]
	private Image image_AnomalyEffect_Single;

	[SerializeField]
	private Image image_AnomalyEffect_Duo_1;

	[SerializeField]
	private Image image_AnomalyEffect_Duo_2;

	[SerializeField]
	private GameObject node_SelectedBorder;

	[SerializeField]
	[Header("Debug文字")]
	private TMP_Text text_DebugState;

	private List<int> list_LineConnectedIndex;

	private MapData mapdata;

	private Map mapManager;

	private float buttonPressCooldown;

	private bool isSelected;

	private bool isLineAvaliable;

	private bool isMouseOver;

	private bool isTooltipOn;

	private List<MapNode> list_PreviousConnectedStepMapNodes;

	public IMapElement MapElement { get; private set; }

	public TwoMouseButtonButton Button => null;

	private void Awake()
	{
	}

	public void Initialize(MapNodeData mapNodeData, MapData mapData, Map mapManager)
	{
	}

	public void UpdateAnomalyIcon()
	{
	}

	public void UpdateRewardUI()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnInputSourceChanged(ControllerType type)
	{
	}

	private void OnButtonSelected()
	{
	}

	private void OnButtonDeselected()
	{
	}

	private void UpdateSelectedBorder()
	{
	}

	private void Update()
	{
	}

	private void OnLanguageChanged()
	{
	}

	private void OnButtonClick()
	{
	}

	private void OnButtonClick_LeftMouseButton()
	{
	}

	private void OnButtonClick_RightMouseButton()
	{
	}

	public void ToggleInteraction(bool isOn)
	{
	}

	public void SwitchState(eMapNodeState state)
	{
	}

	public void UpdateNodeName()
	{
	}

	public bool IsState(eMapNodeState state)
	{
		return false;
	}

	public bool DoShowLightLine()
	{
		return false;
	}

	private void SetLineRendererStyle(bool isLineAvaliable, List<bool> doShowLightLine)
	{
	}

	public void Toggle(bool isOn, float sndPitch = 1f)
	{
	}

	public void ToggleImmediate(bool isOn)
	{
	}

	public void DisableAdditionalElements()
	{
	}

	public void CalculateLines(List<MapNode> list_TargetNodes)
	{
	}

	public void SetPathShowPercentage(float percentage)
	{
	}

	public void SetCompleted(bool isCompleted, bool isFastForward)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerMove(PointerEventData eventData)
	{
	}

	private void ShowTooltip()
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	private void ToggleGuideLine(bool isOn, List<MapNode> list_GuideNodes)
	{
	}

	private void TogglePreviewLine(bool isOn)
	{
	}

	private void UpdateLineMaterial(MapNodePathLine path, MapNodePathLine.eLineType lineType, bool doShowLightLine)
	{
	}
}
