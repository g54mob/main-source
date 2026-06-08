using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StarSystemNode : MonoBehaviour
{
	public List<GameObject> ChildVisualNodes = new List<GameObject>();

	public Material InRangeMaterial;

	public Material TooFarMaterial;

	public Material VisitedMaterial;

	public StarSystemInfo Info;

	private Vector3 initialScale;

	public GameObject selectionIconPrefab;

	private static GameObject selectionIcon;

	private bool _mouseIsOverMe;

	private GUIStyle _guiStyleFore;

	private GUIStyle _guiStyleBack;

	private string _currentToolTipText1;

	private string _currentToolTipText2;

	public bool IsVisible
	{
		get
		{
			return ChildVisualNodes.Any((GameObject x) => x.GetComponent<Renderer>().enabled);
		}
		set
		{
			if (!value)
			{
				OnMouseExit();
			}
			ChildVisualNodes.ForEach(delegate(GameObject x)
			{
				x.GetComponent<Renderer>().enabled = value;
			});
			if (selectionIcon.GetComponent<Renderer>().enabled != value)
			{
				selectionIcon.GetComponent<Renderer>().enabled = value;
			}
		}
	}

	public List<DungeonNode> DungeonNodes { get; set; }

	private void Awake()
	{
		ChildVisualNodes.ForEach(delegate(GameObject x)
		{
			x.GetComponent<Renderer>().material = TooFarMaterial;
		});
		initialScale = base.transform.localScale;
		if (selectionIcon == null)
		{
			selectionIcon = (GameObject)Object.Instantiate(selectionIconPrefab, selectionIconPrefab.transform.position, selectionIconPrefab.transform.rotation);
			selectionIcon.transform.localScale *= 2f;
			selectionIcon.GetComponent<Renderer>().enabled = false;
		}
	}

	private void Start()
	{
		_currentToolTipText1 = string.Empty;
		_currentToolTipText2 = string.Empty;
		_guiStyleFore = new GUIStyle();
		_guiStyleFore.normal.textColor = Color.white;
		_guiStyleFore.alignment = TextAnchor.UpperLeft;
		_guiStyleFore.wordWrap = true;
		_guiStyleBack = new GUIStyle();
		_guiStyleBack.normal.textColor = Color.black;
		_guiStyleBack.alignment = TextAnchor.UpperLeft;
		_guiStyleBack.wordWrap = true;
	}

	private void Update()
	{
	}

	private void OnMouseEnter()
	{
		if (IsVisible && !GlobalSettings.IsGamePaused)
		{
			_currentToolTipText1 = Info.Name;
			_currentToolTipText2 = string.Format("Objects: {0}", Info.TotalObjects);
			_mouseIsOverMe = true;
		}
	}

	private void OnMouseExit()
	{
		if (IsVisible && !GlobalSettings.IsGamePaused)
		{
			_currentToolTipText1 = string.Empty;
			_currentToolTipText2 = string.Empty;
			_mouseIsOverMe = false;
		}
	}

	private void OnMouseUp()
	{
		if (IsVisible && !GlobalSettings.IsGamePaused && _mouseIsOverMe && Info.OnStarSystemEvent != null)
		{
			Info.OnStarSystemEvent(StarSystemEventType.Clicked, Info);
		}
	}

	private void OnGUI()
	{
		if (_mouseIsOverMe && !GlobalSettings.IsGamePaused)
		{
			float x = Event.current.mousePosition.x;
			float y = Event.current.mousePosition.y;
			GUI.Label(new Rect(x + 15f, y + 10f, 300f, 60f), _currentToolTipText1, _guiStyleBack);
			GUI.Label(new Rect(x + 15f, y + 10f, 300f, 60f), _currentToolTipText1, _guiStyleFore);
			GUI.Label(new Rect(x + 15f, y + 30f, 300f, 60f), _currentToolTipText2, _guiStyleBack);
			GUI.Label(new Rect(x + 15f, y + 30f, 300f, 60f), _currentToolTipText2, _guiStyleFore);
		}
	}

	public void SetSelected(bool selected)
	{
		if (selected)
		{
			selectionIcon.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, selectionIcon.transform.position.z);
			base.transform.localScale = initialScale * 2f;
		}
		else
		{
			base.transform.localScale = initialScale;
		}
	}

	public void SetInRange(bool inRange)
	{
		if (Info.Dungeons == null || !Info.Dungeons.Any((DungeonInfo x) => x.HaveVisited))
		{
			if (inRange)
			{
				ChildVisualNodes.ForEach(delegate(GameObject x)
				{
					x.GetComponent<Renderer>().material = InRangeMaterial;
				});
			}
			else
			{
				ChildVisualNodes.ForEach(delegate(GameObject x)
				{
					x.GetComponent<Renderer>().material = TooFarMaterial;
				});
			}
		}
		else
		{
			ChildVisualNodes.ForEach(delegate(GameObject x)
			{
				x.GetComponent<Renderer>().material = VisitedMaterial;
			});
		}
	}
}
