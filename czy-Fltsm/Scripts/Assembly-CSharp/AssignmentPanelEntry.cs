using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using PajamaLlama.Debugs;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AssignmentPanelEntry : MonoBehaviour, IAgentReference
{
	[Header("Agent")]
	[SerializeField]
	[Tooltip("Agent's name.")]
	private TextMeshProUGUI _name;

	[SerializeField]
	private GameObject _selectionHighlight;

	[SerializeField]
	private GameObject _drifterInfoParent;

	[Header("Assignments")]
	[SerializeField]
	[Tooltip("The transform that is parent to the priority boxes.")]
	private Transform _priorityParent;

	[Tooltip("'Burger' Image that indicates this panel is draggable.")]
	[SerializeField]
	public Image DragImage;

	[Header("Prefabs")]
	[SerializeField]
	[Tooltip("Prefab for the priority box.")]
	private GameObject _priorityBoxPrefab;

	[Header("Localization")]
	[SerializeField]
	[Tooltip("Name to put in assignment template.")]
	private LocalizedString _templateName = null;

	private List<AssignmentBox> _assignmentBoxes = new List<AssignmentBox>();

	private DoubleClickDetector _doubleClickDetector = new DoubleClickDetector();

	[HideInInspector]
	public bool IsTemplate;

	private AssignmentPanel AssignmentPanel;

	private Draggable _draggable;

	public Agent Drifter { get; private set; }

	public Agent AgentReference => Drifter;

	public UnityEvent OnAgentUpdated { get; private set; } = new UnityEvent();

	public void Initialize(Agent agent, AssignmentPanel assignmentPanel, bool isTemplate)
	{
		_draggable = GetComponent<Draggable>();
		IsTemplate = isTemplate;
		AssignmentPanel = assignmentPanel;
		base.transform.localScale = Vector3.one;
		if (!IsTemplate)
		{
			Drifter = agent;
			Drifter.OnSelectedEvent.AddListener(OnAgentSelected);
			Drifter.OnDeselectedEvent.AddListener(OnAgentDeselected);
			_selectionHighlight.gameObject.SetActive(Selector.ReturnIsSelected(Drifter.gameObject));
			OnAgentUpdated.Invoke();
			agent.AssignmentPanelEntry = this;
		}
		else
		{
			_draggable.enabled = false;
		}
		_drifterInfoParent.SetActive(!IsTemplate);
		foreach (AssignmentType assignment in assignmentPanel.DisplayedAssignments)
		{
			Transform obj = Object.Instantiate(_priorityBoxPrefab, _priorityParent).transform;
			obj.name = $"Priority box ({assignment.ToString()})";
			obj.localScale = Vector3.one;
			Assignment assignment2 = null;
			assignment2 = ((!IsTemplate || !ProjectSettings.TryGetAssignmentSettings(out var settings, assignment)) ? agent.Assignments.Find((Assignment asssignmentEntry) => asssignmentEntry.Type == assignment) : new Assignment(settings, GameManager.AgentManager.AssignmentPriorityTemplates[assignment], 0, null));
			AssignmentBox component = obj.GetComponent<AssignmentBox>();
			component.Initialize(agent, assignment2, IsTemplate);
			_assignmentBoxes.Add(component);
		}
		UpdateEntry();
	}

	public void UpdateEntry()
	{
		if (IsTemplate)
		{
			string text = _templateName;
			base.gameObject.name = $"{text} entry";
			_name.text = text;
		}
		else
		{
			string text2 = Drifter.Name;
			base.gameObject.name = $"{text2} entry";
			_name.text = text2;
		}
		foreach (AssignmentBox assignmentBox in _assignmentBoxes)
		{
			assignmentBox.Refresh();
		}
	}

	private void OnDestroy()
	{
		if (Drifter != null)
		{
			Drifter.OnSelectedEvent.RemoveListener(OnAgentSelected);
			Drifter.OnDeselectedEvent.RemoveListener(OnAgentDeselected);
		}
	}

	public void UpdatePriority(bool increase, AssignmentType type)
	{
		if (IsTemplate || Drifter.ReturnAcceptsAssignmentType(type))
		{
			AssignmentBox assignmentBox = _assignmentBoxes.FirstOrDefault((AssignmentBox box) => box.Assignment.Type == type);
			if (assignmentBox == null)
			{
				Debugger.Error($"Couldn't retrieve assignment box for type {type}.");
				return;
			}
			assignmentBox.UpdatePriority(increase);
			assignmentBox.Refresh();
		}
	}

	public void UpdatePriorityForAllTypes(bool increase)
	{
		foreach (AssignmentType displayedAssignment in AssignmentPanel.DisplayedAssignments)
		{
			if (displayedAssignment != AssignmentType.None)
			{
				UpdatePriority(increase, displayedAssignment);
			}
		}
	}

	public void SelectAgent()
	{
		if (!IsTemplate)
		{
			Selector.Select(Drifter.gameObject, ObjectType.CommunityMember);
			if (_doubleClickDetector.IsDoubleClick())
			{
				CameraController.Instance.Lock(Drifter.gameObject);
			}
		}
	}

	private void OnAgentSelected()
	{
		_selectionHighlight.SetActive(value: true);
	}

	private void OnAgentDeselected()
	{
		_selectionHighlight.SetActive(value: false);
	}
}
