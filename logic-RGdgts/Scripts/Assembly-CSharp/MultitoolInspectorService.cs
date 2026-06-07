using TMPro;
using UI.Apps;
using UI.Elements;
using UnityEngine;

public class MultitoolInspectorService : MultitoolService
{
	public Transform linesRoot;

	public TextMeshProUGUI nameLabel;

	public MultitoolInspectorSelectionPopup selectionPopup;

	public MultitoolInspectorContainerPopup containerPopup;

	public MultitoolInspectorInputSourcePopup inputSourcePopup;

	private LayoutHelper<Transform> layout;

	private Module module;

	[SerializeField]
	private UIButton expandDescriptionButton;

	[SerializeField]
	private Sprite plusIcon;

	[SerializeField]
	private Sprite minusIcon;

	private Transform description;

	public override void Init(MultiTool multitool)
	{
	}

	public override void Enable()
	{
	}

	public override void Disable()
	{
	}

	private void Update()
	{
	}

	private void SetTarget(Module module)
	{
	}

	public Module GetTarget()
	{
		return null;
	}

	private void Refresh()
	{
	}

	private Transform AddTitleElement(string title)
	{
		return null;
	}

	private Transform AddDescriptionElement(string documentationSymbol)
	{
		return null;
	}

	private void ExpandDescription()
	{
	}

	private int AddPropertiesElements(ModuleGestalt.Property.Type propertyType)
	{
		return 0;
	}

	public override void OnSelectModule(Module module)
	{
	}

	public override void OnMultitoolAppStart(MultiToolAppInfo appInfo)
	{
	}
}
