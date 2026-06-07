using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MaterialPreviewer : MonoBehaviour
{
	[Flags]
	public enum Mode
	{
		Room = 1,
		Fence = 2,
		Roof = 4,
		Path = 8,
		Furniture = 0x10,
		Balcony = 0x20
	}

	public class StyleType
	{
		public Mode ViewMode;

		public string Loc;

		public WallSnap Prefab;

		public StyleType(Mode v)
		{
			ViewMode = v;
			switch (v)
			{
			case Mode.Room:
				Loc = "Rooms".Loc();
				break;
			case Mode.Fence:
				Loc = "OutdoorAreas".Loc();
				break;
			case Mode.Balcony:
				Loc = "Balconies".Loc();
				break;
			case Mode.Roof:
				Loc = "Roofs".Loc();
				break;
			case Mode.Path:
				Loc = "Paths".Loc();
				break;
			}
		}

		public StyleType(WallSnap f)
		{
			ViewMode = Mode.Furniture;
			if (string.IsNullOrEmpty(f._defaultColorGroup))
			{
				Loc = f.GetActualString();
			}
			else
			{
				Loc = ("Style" + f._defaultColorGroup).Loc();
			}
			Prefab = f;
		}

		public override string ToString()
		{
			return Loc;
		}
	}

	public static MaterialPreviewer Instance;

	public MaterialPreviewButton ButtonPrefab;

	private MaterialPreviewButton[] _buttons;

	private int _buttonCount;

	public MaterialPreviewRenderer Renderer;

	public Renderer BFloor;

	public Renderer BExt;

	public Renderer BInt;

	public Renderer FFloor;

	public Renderer Roof;

	public Renderer Gable;

	public Renderer Path;

	public GameObject Building;

	public GameObject Fence;

	public GameObject Roofing;

	public GameObject Furniture;

	public GameObject StylePanel;

	public GameObject MaterialButton;

	public GameObject ColorButton;

	public GameObject RoomFilter;

	public Toggle RandomizeStyle;

	[NonSerialized]
	public int LastRandom;

	public GUICombobox Combo;

	public Toggle RoomInterior;

	public Toggle RoomExterior;

	public Transform FenceGroups;

	[NonSerialized]
	private List<MeshRenderer> _furnRends = new List<MeshRenderer>();

	[NonSerialized]
	private List<MeshFilter> _furnMeshes = new List<MeshFilter>();

	public RectTransform ContentRect;

	public RectTransform SelfRect;

	public Mode ViewMode = Mode.Room;

	public int Offset;

	public int Toggled = -1;

	public bool CanAdd;

	public RectTransform GoUp;

	public RectTransform GoDown;

	[NonSerialized]
	private Tweener _activeTween;

	private bool _open;

	private WallSnap _furnPrefab;

	public AnimationCurve UpDownBob;

	private Dictionary<Mode, IStyle> _lastUsed = new Dictionary<Mode, IStyle>();

	public float MinYDistance;

	public RawImage[] AtlasImages;

	public Toggle[] AtlasToggles;

	public GameObject AtlasPanel;

	private int _atlas;

	private bool _enableAtlasChange;

	private bool _disableAtlasRefresh;

	private IStyle _uniqueStyle;

	private List<StyleType> _styleTypes = new List<StyleType>();

	private float _lastHeight;

	public bool ShouldAdd
	{
		get
		{
			if (CanAdd)
			{
				return _uniqueStyle != null;
			}
			return false;
		}
	}

	public WallSnap CurrentPrefab
	{
		get
		{
			return _furnPrefab;
		}
	}

	public int Atlas
	{
		get
		{
			return _atlas;
		}
		set
		{
			_atlas = Mathf.Clamp(value, 0, AtlasToggles.Length - 1);
			AtlasToggles[_atlas].isOn = true;
		}
	}

	public bool Open
	{
		get
		{
			return _open;
		}
	}

	public void Scroll(BaseEventData d)
	{
		PointerEventData pointerEventData = d as PointerEventData;
		if (pointerEventData != null)
		{
			int offset = Offset;
			Offset = Mathf.Clamp(Offset - Mathf.RoundToInt(pointerEventData.scrollDelta.y), 0, Mathf.Max(0, GetCount() - _buttonCount));
			if (offset != Offset)
			{
				Refresh();
			}
		}
	}

	public void ScrollOne(int d)
	{
		int offset = Offset;
		Offset = Mathf.Clamp(Offset + d, 0, Mathf.Max(0, GetCount() - _buttonCount));
		if (offset != Offset)
		{
			Refresh();
		}
	}

	private void Update()
	{
		float num = UpDownBob.Evaluate(Time.realtimeSinceStartup);
		GoUp.anchoredPosition = new Vector2(GoUp.anchoredPosition.x, -2f + num);
		GoDown.anchoredPosition = new Vector2(GoDown.anchoredPosition.x, 2f + num);
	}

	private void RefreshArrows()
	{
		GoUp.gameObject.SetActive(Offset > 0);
		int num = Mathf.Max(0, GetCount() - _buttonCount);
		GoDown.gameObject.SetActive(Offset < num);
	}

	private void Awake()
	{
		Instance = this;
		for (int i = 0; i < AtlasImages.Length; i++)
		{
			AtlasImages[i].material = new Material(AtlasImages[i].material);
		}
	}

	public int GetActiveAtlas()
	{
		if (ViewMode != Mode.Furniture)
		{
			return 0;
		}
		return Atlas * _furnPrefab.AtlasSkip + _furnPrefab.AtlasOff;
	}

	public void RefreshAtlas()
	{
		_enableAtlasChange = false;
		if (ViewMode == Mode.Furniture && _furnPrefab.AtlasObject != null)
		{
			AtlasPanel.SetActive(true);
			Vector2 atlasDimensions = _furnPrefab.AtlasDimensions;
			Furniture furniture;
			Texture texture = (((object)(furniture = _furnPrefab as Furniture) == null) ? _furnPrefab.AtlasObject.sharedMaterial.mainTexture : ((_furnPrefab.AtlasObject == furniture.TheScreen && furniture.OnMat != null) ? furniture.OnMat.mainTexture : _furnPrefab.AtlasObject.sharedMaterial.mainTexture));
			int num = Mathf.Min(AtlasImages.Length, _furnPrefab.AtlasCount / _furnPrefab.AtlasSkip);
			_atlas = 0;
			if (CanAdd)
			{
				HashSet<int> hashSet = (from wallSnap in GetRelevantSelected<WallSnap>(true)
					select wallSnap.AtlasIndex).ToHashSet();
				if (hashSet.Count == 1)
				{
					_atlas = (hashSet.First() - _furnPrefab.AtlasOff) / _furnPrefab.AtlasSkip;
				}
			}
			_disableAtlasRefresh = true;
			for (int num2 = 0; num2 < num; num2++)
			{
				AtlasToggles[num2].gameObject.SetActive(true);
				int num3 = num2 * _furnPrefab.AtlasSkip + _furnPrefab.AtlasOff;
				float x = (float)num3 % atlasDimensions.x / atlasDimensions.x;
				float y = (atlasDimensions.y - 1f - Mathf.Floor((float)num3 / atlasDimensions.x)) / atlasDimensions.y;
				RawImage rawImage = AtlasImages[num2];
				rawImage.texture = texture;
				rawImage.uvRect = new Rect(x, y, 1f / atlasDimensions.x, 1f / atlasDimensions.y);
				if (_furnPrefab.AtlasColorable)
				{
					rawImage.material.SetColor("_Color1", _furnPrefab.ColorPrimaryDefault);
					rawImage.material.SetColor("_Color2", _furnPrefab.ColorSecondaryDefault);
					rawImage.material.SetColor("_Color3", _furnPrefab.ColorTertiaryDefault);
				}
				else
				{
					rawImage.material.SetColor("_Color1", Color.red);
					rawImage.material.SetColor("_Color2", Color.green);
					rawImage.material.SetColor("_Color3", Color.blue);
				}
				AtlasToggles[num2].isOn = num2 == _atlas;
			}
			for (int num4 = num; num4 < AtlasImages.Length; num4++)
			{
				AtlasToggles[num4].gameObject.SetActive(false);
			}
			_enableAtlasChange = CanAdd;
			_disableAtlasRefresh = false;
		}
		else
		{
			AtlasPanel.SetActive(false);
		}
	}

	public void Show(List<StyleType> types, bool canAdd, bool canRandomize = false)
	{
		CanAdd = canAdd;
		Combo.UpdateContent(from x in types
			orderby x.ViewMode, x.Loc
			select x);
		Combo.Selected = 0;
		Combo.gameObject.SetActive(types.Count > 1);
		RandomizeStyle.gameObject.SetActive(canRandomize);
		RandomizeStyle.isOn = false;
		ComboChange();
	}

	public void ComboChange()
	{
		StyleType styleType = Combo.SelectedItem as StyleType;
		if (styleType.ViewMode == Mode.Furniture)
		{
			Show(styleType.Prefab, CanAdd);
		}
		else
		{
			Show(styleType.ViewMode, CanAdd);
		}
	}

	public void Show(WallSnap f, bool canAdd)
	{
		ViewMode = Mode.Furniture;
		CanAdd = canAdd;
		_furnPrefab = ((f is Furniture) ? ((WallSnap)ObjectDatabase.Instance.GetFurnitureComponent(f.name)) : ((WallSnap)ObjectDatabase.Instance.GetSegmentComponent(f.name)));
		RoomFilter.SetActive(false);
		int num = RefreshUniqueStyle();
		Toggled = (CanAdd ? num : 0);
		if (CanAdd)
		{
			UserImageFrame component;
			MaterialButton.SetActive(_furnPrefab.AtlasObject != null || (_furnPrefab.ReplacementGroups != null && _furnPrefab.ReplacementGroups.Length != 0) || _furnPrefab.TryGetComponent<UserImageFrame>(out component));
			ColorButton.SetActive(_furnPrefab.ColorEditEnabled);
			StylePanel.SetActive(MaterialButton.activeSelf || ColorButton.activeSelf);
		}
		else
		{
			StylePanel.SetActive(false);
		}
		ActualShow();
	}

	public void Show(Mode mode, bool canAdd)
	{
		ViewMode = mode;
		CanAdd = canAdd;
		int toggled = RefreshUniqueStyle();
		RoomFilter.SetActive(mode == Mode.Room && canAdd);
		IStyle last;
		if (!canAdd && _lastUsed.TryGetValue(mode, out last))
		{
			Toggled = GameSettings.Instance.RoomStyles.FindIndexWhere((RoomStyle x) => x.Match(mode), (RoomStyle x) => x.Match(last)) + 1;
		}
		else
		{
			Toggled = toggled;
		}
		if (CanAdd)
		{
			StylePanel.SetActive(true);
			ColorButton.SetActive(true);
			MaterialButton.SetActive(true);
		}
		else
		{
			StylePanel.SetActive(false);
		}
		ActualShow();
	}

	private void ActualShow()
	{
		InitializeThumbnails();
		RefreshAtlas();
		Offset = 0;
		base.gameObject.SetActive(true);
		RefreshThumbnailCount();
		Refresh();
		if (ShouldDoTween(true))
		{
			_activeTween = SelfRect.DOAnchorPos(new Vector2(0f, SelfRect.anchoredPosition.y), 0.5f).SetEase(Ease.OutBounce);
		}
		_open = true;
	}

	public static void RefreshSelectedStyle(Mode viewMode)
	{
		MaterialPreviewer instance = Instance;
		if (instance != null && instance.gameObject.activeSelf && (instance.ViewMode & viewMode) != 0)
		{
			instance.RefreshUniqueStyle();
			if (instance.ShouldAdd && instance.Offset == 0)
			{
				instance.SetObject(instance._buttons[0], 0);
				instance.Renderer.StartRender(instance.GetNextRender());
			}
			instance.Refresh();
		}
	}

	public void ColorClick()
	{
		switch (ViewMode)
		{
		case Mode.Room:
		case Mode.Fence:
		case Mode.Balcony:
		{
			Selectable[] xs = GetRelevantSelected<Room>().ToArray();
			SelectorController.RoomColorAction(xs, SelectorController.Instance);
			break;
		}
		case Mode.Roof:
		{
			Selectable[] xs = GetRelevantSelected<Roof>().ToArray();
			SelectorController.RoofColorAction(xs, SelectorController.Instance);
			break;
		}
		case Mode.Path:
		{
			Selectable[] xs = GetRelevantSelected<PathObject>().ToArray();
			SelectorController.PathColorAction(xs, SelectorController.Instance);
			break;
		}
		case Mode.Furniture:
		{
			Selectable[] xs = GetRelevantSelected<WallSnap>().ToArray();
			SelectorController.FurnitureColor(xs, SelectorController.Instance);
			break;
		}
		}
	}

	public void MaterialClick()
	{
		switch (ViewMode)
		{
		case Mode.Room:
		case Mode.Fence:
		case Mode.Balcony:
		{
			Selectable[] xs = GetRelevantSelected<Room>().ToArray();
			SelectorController.MaterialAction(xs, SelectorController.Instance);
			break;
		}
		case Mode.Roof:
		{
			Selectable[] xs = GetRelevantSelected<Roof>().ToArray();
			SelectorController.RoofMaterialAction(xs, SelectorController.Instance);
			break;
		}
		case Mode.Path:
		{
			Selectable[] xs = GetRelevantSelected<PathObject>().ToArray();
			SelectorController.PathMaterialAction(xs, SelectorController.Instance);
			break;
		}
		case Mode.Furniture:
		{
			Selectable[] xs = GetRelevantSelected<WallSnap>().ToArray();
			SelectorController.FurnitureStyle(xs, SelectorController.Instance);
			break;
		}
		}
	}

	public int RefreshUniqueStyle()
	{
		if (CanAdd)
		{
			Selectable firstRelevantSelected = GetFirstRelevantSelected();
			if (firstRelevantSelected != null)
			{
				IStyle style = firstRelevantSelected.GetStyle();
				if (style != null)
				{
					int num = GetStyles().FindIndex((IStyle x) => x.Match(style));
					if (num >= 0)
					{
						_uniqueStyle = null;
						return num;
					}
					_uniqueStyle = style;
					return 0;
				}
			}
		}
		_uniqueStyle = null;
		return -1;
	}

	public IEnumerable<IStyle> GetStyles()
	{
		switch (ViewMode)
		{
		case Mode.Room:
		case Mode.Fence:
		case Mode.Roof:
		case Mode.Path:
		case Mode.Balcony:
			yield return GetDefaultStyle();
			foreach (RoomStyle roomStyle in GameSettings.Instance.RoomStyles)
			{
				if (roomStyle.Match(ViewMode))
				{
					yield return roomStyle;
				}
			}
			break;
		case Mode.Furniture:
			foreach (FurnitureStyle style in GameSettings.Instance.GetStyles(_furnPrefab))
			{
				yield return style;
			}
			break;
		}
	}

	public void Hide()
	{
		if (ShouldDoTween(false))
		{
			_activeTween = SelfRect.DOAnchorPos(new Vector2(140f, SelfRect.anchoredPosition.y), 0.5f).SetEase(Ease.OutCubic).OnComplete(delegate
			{
				base.gameObject.SetActive(false);
			});
		}
		_open = false;
	}

	public bool ShouldDoTween(bool open)
	{
		if (_activeTween == null)
		{
			return true;
		}
		if (_activeTween.IsActive())
		{
			if (_open != open)
			{
				_activeTween.Kill();
				return true;
			}
			return false;
		}
		return true;
	}

	private int GetCount()
	{
		int num = 0;
		switch (ViewMode)
		{
		case Mode.Room:
		case Mode.Fence:
		case Mode.Roof:
		case Mode.Path:
		case Mode.Balcony:
			num = GameSettings.Instance.RoomStyles.Count((RoomStyle x) => x.Match(ViewMode)) + 1;
			break;
		case Mode.Furniture:
			num = GameSettings.Instance.GetStyleCount(_furnPrefab);
			break;
		}
		if (ShouldAdd)
		{
			return num + 1;
		}
		return num;
	}

	public IStyle GetDefaultStyle(Mode viewMode)
	{
		switch (viewMode)
		{
		case Mode.Room:
			return GameSettings.Instance.DefaultIndoorRoomStyle;
		case Mode.Fence:
			return GameSettings.Instance.DefaultOutdoorRoomStyle;
		case Mode.Balcony:
			return GameSettings.Instance.DefaultBalconyStyle;
		case Mode.Roof:
			return GameSettings.Instance.DefaultRoofStyle;
		case Mode.Path:
			return GameSettings.Instance.DefaultPathStyle;
		case Mode.Furniture:
			return new FurnitureStyle(_furnPrefab, true);
		default:
			return null;
		}
	}

	public IStyle GetDefaultStyle()
	{
		switch (ViewMode)
		{
		case Mode.Room:
			return GameSettings.Instance.DefaultIndoorRoomStyle;
		case Mode.Fence:
			return GameSettings.Instance.DefaultOutdoorRoomStyle;
		case Mode.Balcony:
			return GameSettings.Instance.DefaultBalconyStyle;
		case Mode.Roof:
			return GameSettings.Instance.DefaultRoofStyle;
		case Mode.Path:
			return GameSettings.Instance.DefaultPathStyle;
		case Mode.Furniture:
			return new FurnitureStyle(_furnPrefab, true);
		default:
			return null;
		}
	}

	public IStyle GetActiveStyle()
	{
		int num = Mathf.Clamp(Toggled, 0, GetCount() - 1);
		switch (ViewMode)
		{
		case Mode.Room:
		case Mode.Fence:
		case Mode.Roof:
		case Mode.Path:
		case Mode.Balcony:
			if (num == 0)
			{
				return GetDefaultStyle();
			}
			return GameSettings.Instance.RoomStyles.GetIndexWhere(num - 1, (RoomStyle x) => x.Match(ViewMode));
		case Mode.Furniture:
			return GameSettings.Instance.GetStyles(_furnPrefab).GetAt(num);
		default:
			return GetDefaultStyle();
		}
	}

	public void RefreshState()
	{
		_styleTypes.Clear();
		if (GameSettings.Instance.IsReferenceNull() || SelectorController.Instance == null)
		{
			return;
		}
		if (!HUD.Instance.BuildMode)
		{
			Hide();
			return;
		}
		if (BuildController.Instance.CurrentSegments != null || BuildController.Instance.RectPoints != null)
		{
			_styleTypes.Add(new StyleType((!BuildController.Instance.FenceMode) ? Mode.Room : Mode.Fence));
			Show(_styleTypes, false);
			return;
		}
		bool shown = HUD.Instance.roofEditWindow.Window.Shown;
		if (shown && HUD.Instance.roofEditWindow.DestroyOnClose && HUD.Instance.roofEditWindow.CurrentRoof != null)
		{
			_styleTypes.Add(new StyleType(Mode.Roof));
			Show(_styleTypes, false);
			return;
		}
		if (PathBuilder.Instance.enabled)
		{
			if (!PathBuilder.Instance.DeleteMode)
			{
				_styleTypes.Add(new StyleType(Mode.Path));
				Show(_styleTypes, false);
			}
			else
			{
				Hide();
			}
			return;
		}
		if (BuildController.Instance.CurrentFurnitureBuilder != null)
		{
			FurnitureBuilder currentFurnitureBuilder = BuildController.Instance.CurrentFurnitureBuilder;
			if (currentFurnitureBuilder.Children.Count == 0 && !currentFurnitureBuilder.CopyProto && !currentFurnitureBuilder.IsProto)
			{
				Furniture component = currentFurnitureBuilder.FurnPrefab.GetComponent<Furniture>();
				if (component.IsCustomizable() && ObjectDatabase.Instance.GetFurniture(component.name) != null)
				{
					_styleTypes.Add(new StyleType(component));
					Show(_styleTypes, false, component.AtlasObject != null);
					return;
				}
			}
			Hide();
			return;
		}
		if (BuildController.Instance.CurrentTempSegment != null && BuildController.Instance.WallSegmentPrefab != null)
		{
			RoomSegment component2 = BuildController.Instance.WallSegmentPrefab.GetComponent<RoomSegment>();
			if (component2.IsCustomizable() && ObjectDatabase.Instance.GetSegmentComponent(component2.name) != null)
			{
				_styleTypes.Add(new StyleType(component2));
				Show(_styleTypes, false);
			}
			else
			{
				Hide();
			}
			return;
		}
		if (!shown && BuildController.Instance.IsActive())
		{
			Hide();
			return;
		}
		HashSet<Selectable> selected = SelectorController.Instance.Selected;
		if (!GameSettings.Instance.RentMode || GameSettings.Instance.EditMode)
		{
			if (selected.AnyOf((Room x) => !x.Outdoors && !x.IsBalcony))
			{
				_styleTypes.Add(new StyleType(Mode.Room));
			}
			if (selected.AnyOf((Room x) => x.Outdoors))
			{
				_styleTypes.Add(new StyleType(Mode.Fence));
			}
			if (selected.AnyOf((Room x) => x.IsBalcony))
			{
				_styleTypes.Add(new StyleType(Mode.Balcony));
			}
			if (selected.OfType<PathObject>().Any())
			{
				_styleTypes.Add(new StyleType(Mode.Path));
			}
			if (selected.OfType<Roof>().Any())
			{
				_styleTypes.Add(new StyleType(Mode.Roof));
			}
		}
		foreach (IGrouping<string, WallSnap> item in from x in selected.OfType<WallSnap>()
			where x.IsCustomizable()
			group x by x.DefaultColorGroup)
		{
			foreach (WallSnap item2 in item)
			{
				WallSnap wallSnap = ((item2 is Furniture) ? ((WallSnap)ObjectDatabase.Instance.GetFurnitureComponent(item2.name)) : ((WallSnap)ObjectDatabase.Instance.GetSegmentComponent(item2.name)));
				if (wallSnap != null)
				{
					_styleTypes.Add(new StyleType(wallSnap));
					break;
				}
			}
		}
		if (_styleTypes.Count > 0)
		{
			Show(_styleTypes, true);
		}
		else
		{
			Hide();
		}
	}

	private int GetRoomStyleIndex(Selectable s, Mode viewMode)
	{
		if (GetDefaultStyle(viewMode).Match(s))
		{
			return 0;
		}
		int num = GameSettings.Instance.RoomStyles.FindIndexWhere((RoomStyle x) => x.Match(viewMode), (RoomStyle x) => x.Match(s));
		if (num >= 0)
		{
			num++;
		}
		return num;
	}

	private void SetObject(MaterialPreviewButton b, int i)
	{
		b.NeedsRender = true;
		if (i == Toggled)
		{
			b.ToggleImg.gameObject.SetActive(true);
		}
		else
		{
			b.ToggleImg.gameObject.SetActive(false);
		}
		if (ShouldAdd && i == 0)
		{
			b.DeleteButton.gameObject.SetActive(false);
			b.HelperColor.gameObject.SetActive(false);
			b.AdditionImg.SetActive(true);
			b.SetStyle(_uniqueStyle, _furnPrefab, GetActiveAtlas());
			b.Caption.text = "ActionSaveStyle".Loc();
			return;
		}
		if (ShouldAdd)
		{
			i--;
		}
		b.DeleteButton.gameObject.SetActive(i > 0);
		b.AdditionImg.SetActive(false);
		switch (ViewMode)
		{
		case Mode.Room:
		case Mode.Fence:
		case Mode.Roof:
		case Mode.Path:
		case Mode.Balcony:
		{
			IStyle style;
			if (i != 0)
			{
				IStyle indexWhere = GameSettings.Instance.RoomStyles.GetIndexWhere(i - 1, (RoomStyle x) => x.Match(ViewMode));
				style = indexWhere;
			}
			else
			{
				style = GetDefaultStyle();
			}
			b.SetStyle(style, null, 0);
			break;
		}
		case Mode.Furniture:
			b.SetStyle(GameSettings.Instance.GetStyles(_furnPrefab).GetAt(i), _furnPrefab, GetActiveAtlas());
			break;
		}
	}

	public void AddClick()
	{
		switch (ViewMode)
		{
		case Mode.Room:
		case Mode.Fence:
		case Mode.Roof:
		case Mode.Path:
		case Mode.Balcony:
		{
			RoomStyle style = _uniqueStyle as RoomStyle;
			if (style != null)
			{
				WindowManager.SpawnInputDialog("SaveStylePrompt".Loc(), "", "Roomstyle".Loc(), delegate(string x)
				{
					style.StyleName = x;
					GameSettings.Instance.RoomStyles.Add(style);
					_uniqueStyle = null;
					Toggled = GetCount() - 1;
					Refresh();
				});
			}
			break;
		}
		case Mode.Furniture:
		{
			FurnitureStyle furnitureStyle = _uniqueStyle as FurnitureStyle;
			if (furnitureStyle != null)
			{
				GameSettings.Instance.AddStyle(furnitureStyle, _furnPrefab);
				_uniqueStyle = null;
				Toggled = GetCount() - 1;
				Refresh();
			}
			break;
		}
		}
	}

	public IEnumerable<T> GetRelevantSelected<T>(bool strict = false) where T : class
	{
		switch (ViewMode)
		{
		case Mode.Room:
			foreach (Room item in from x in SelectorController.Instance.Selected.OfType<Room>()
				where x != null && !x.Outdoors && !x.IsBalcony
				select x)
			{
				yield return item as T;
			}
			break;
		case Mode.Fence:
			foreach (Room item2 in from x in SelectorController.Instance.Selected.OfType<Room>()
				where x != null && x.Outdoors
				select x)
			{
				yield return item2 as T;
			}
			break;
		case Mode.Balcony:
			foreach (Room item3 in from x in SelectorController.Instance.Selected.OfType<Room>()
				where x != null && x.IsBalcony
				select x)
			{
				yield return item3 as T;
			}
			break;
		case Mode.Roof:
			foreach (Roof item4 in SelectorController.Instance.Selected.OfType<Roof>())
			{
				yield return item4 as T;
			}
			break;
		case Mode.Path:
			foreach (PathObject item5 in SelectorController.Instance.Selected.OfType<PathObject>())
			{
				yield return item5 as T;
			}
			break;
		case Mode.Furniture:
			foreach (WallSnap item6 in SelectorController.Instance.Selected.OfType<WallSnap>())
			{
				if ((item6 != null && strict && item6.name.Equals(_furnPrefab.name)) || (!strict && item6.DefaultColorGroup.Equals(_furnPrefab.DefaultColorGroup) && (GameSettings.Instance.EditMode || item6.IsActuallyPlayerControlled())))
				{
					yield return item6 as T;
				}
			}
			break;
		}
	}

	public Selectable GetFirstRelevantSelected()
	{
		switch (ViewMode)
		{
		case Mode.Room:
			return SelectorController.Instance.Selected.OfType<Room>().FirstOrDefault((Room x) => !x.Outdoors && !x.IsBalcony);
		case Mode.Fence:
			return SelectorController.Instance.Selected.OfType<Room>().FirstOrDefault((Room x) => x.Outdoors);
		case Mode.Balcony:
			return SelectorController.Instance.Selected.OfType<Room>().FirstOrDefault((Room x) => x.IsBalcony);
		case Mode.Roof:
			return SelectorController.Instance.Selected.FirstOrDefaultOf<Roof>();
		case Mode.Path:
			return SelectorController.Instance.Selected.FirstOrDefaultOf<PathObject>();
		case Mode.Furniture:
			return SelectorController.Instance.Selected.OfType<WallSnap>().FirstOrDefault((WallSnap x) => x.name.Equals(_furnPrefab.name));
		default:
			return null;
		}
	}

	public void Click(int i)
	{
		int num = i + Offset;
		if (ShouldAdd)
		{
			if (num == 0)
			{
				AddClick();
				return;
			}
			num--;
		}
		Toggled = num;
		Refresh();
		if (ViewMode == Mode.Furniture && BuildController.Instance.CurrentFurnitureBuilder != null)
		{
			BuildController.Instance.CurrentFurnitureBuilder.BuildMesh();
		}
		if (!CanAdd)
		{
			_lastUsed[ViewMode] = GetActiveStyle();
			return;
		}
		IStyle activeStyle = GetActiveStyle();
		switch (ViewMode)
		{
		case Mode.Room:
		{
			if (!RoomExterior.isOn && !RoomInterior.isOn)
			{
				break;
			}
			RoomStyle roomStyle = activeStyle as RoomStyle;
			if (roomStyle != null)
			{
				List<Room> list = GetRelevantSelected<Room>().ToList();
				UndoObject.UndoAction undoAction2 = new UndoObject.UndoAction(list, true, true);
				for (int k = 0; k < list.Count; k++)
				{
					roomStyle.Apply(list[k], RoomExterior.isOn, RoomInterior.isOn);
					list[k].UpdateStyleNetwork();
				}
				GameSettings.Instance.AddUndo(undoAction2);
			}
			break;
		}
		case Mode.Fence:
		case Mode.Balcony:
		{
			List<Room> list3 = GetRelevantSelected<Room>().ToList();
			List<UndoObject.UndoAction> list4 = new List<UndoObject.UndoAction>
			{
				new UndoObject.UndoAction(list3, true, true)
			};
			for (int n = 0; n < list3.Count; n++)
			{
				activeStyle.Apply(list3[n], list4);
				list3[n].UpdateStyleNetwork();
			}
			GameSettings.Instance.AddUndo(list4.ToArray());
			break;
		}
		case Mode.Roof:
		{
			List<Roof> list2 = GetRelevantSelected<Roof>().ToList();
			UndoObject.UndoAction undoAction3 = new UndoObject.UndoAction(list2);
			for (int l = 0; l < list2.Count; l++)
			{
				activeStyle.Apply(list2[l], null);
				list2[l].UpdateStyleNetwork();
			}
			GameSettings.Instance.AddUndo(undoAction3);
			break;
		}
		case Mode.Path:
		{
			PathObject[] array2 = GetRelevantSelected<PathObject>().ToArray();
			UndoObject.UndoAction undoAction4 = new UndoObject.UndoAction(true, array2);
			for (int m = 0; m < array2.Length; m++)
			{
				activeStyle.Apply(array2[m], null);
			}
			GameSettings.Instance.AddUndo(undoAction4);
			break;
		}
		case Mode.Furniture:
		{
			WallSnap[] array = GetRelevantSelected<WallSnap>().ToArray();
			UndoObject.UndoAction undoAction = new UndoObject.UndoAction(array, true, true);
			for (int j = 0; j < array.Length; j++)
			{
				activeStyle.Apply(array[j], null);
				array[j].UpdateStyleNetwork();
			}
			GameSettings.Instance.AddUndo(undoAction);
			break;
		}
		}
		Toggled = RefreshUniqueStyle();
		Refresh();
	}

	public void Delete(int i)
	{
		int num = i + Offset;
		if (ShouldAdd)
		{
			num--;
		}
		switch (ViewMode)
		{
		case Mode.Room:
		case Mode.Fence:
		case Mode.Roof:
		case Mode.Path:
		case Mode.Balcony:
		{
			RoomStyle indexWhere = GameSettings.Instance.RoomStyles.GetIndexWhere(num - 1, (RoomStyle x) => x.Match(ViewMode));
			GameSettings.Instance.RoomStyles.Remove(indexWhere);
			break;
		}
		case Mode.Furniture:
			GameSettings.Instance.RemoveStyles(_furnPrefab, GameSettings.Instance.GetStyles(_furnPrefab).GetAt(num));
			break;
		}
		Toggled = RefreshUniqueStyle();
		Refresh();
	}

	public void Refresh()
	{
		int count = GetCount();
		for (int i = 0; i < _buttonCount && i < _buttons.Length; i++)
		{
			int num = Offset + i;
			if (num < count)
			{
				_buttons[i].gameObject.SetActive(true);
				SetObject(_buttons[i], num);
			}
			else
			{
				_buttons[i].gameObject.SetActive(false);
			}
		}
		RenderTexture nextRender = GetNextRender();
		if (nextRender != null)
		{
			Renderer.StartRender(nextRender);
		}
		RefreshArrows();
	}

	public void RenderRoom(MaterialPreviewButton b)
	{
		Building.SetActive(true);
		SetBuildingTex(BFloor, b.Mats[0]);
		BFloor.material.SetColor("_Color", b.Colors[0]);
		BFloor.material.SetColor("_Color2", b.Colors[1]);
		SetBuildingTex(BInt, b.Mats[1]);
		BInt.material.SetColor("_Color", b.Colors[2]);
		BInt.material.SetColor("_Color2", b.Colors[3]);
		SetBuildingTex(BExt, b.Mats[2]);
		BExt.material.SetColor("_Color", b.Colors[4]);
		BExt.material.SetColor("_Color2", b.Colors[5]);
	}

	public void RenderPath(MaterialPreviewButton b)
	{
		Path.gameObject.SetActive(true);
		SetBuildingTex(Path, b.Mats[0]);
		Path.material.SetColor("_Color", b.Colors[0]);
		Path.material.SetColor("_Color2", b.Colors[1]);
	}

	public void RenderFence(MaterialPreviewButton b)
	{
		Fence.SetActive(true);
		ActivateFence(b.Mats[1]).material.color = b.Colors[2];
		SetBuildingTex(FFloor, b.Mats[0]);
		FFloor.material.SetColor("_Color", b.Mats[0].Equals("None") ? TimeOfDay.Instance.GetGroundColor() : b.Colors[0]);
		FFloor.material.SetColor("_Color2", b.Colors[1]);
	}

	public void RenderRoof(MaterialPreviewButton b)
	{
		Roofing.SetActive(true);
		SetBuildingTex(Roof, b.Mats[0]);
		Roof.material.SetColor("_Color", b.Colors[0]);
		Roof.material.SetColor("_Color2", b.Colors[1]);
		SetBuildingTex(Gable, b.Mats[1]);
		Gable.material.SetColor("_Color", b.Colors[2]);
		Gable.material.SetColor("_Color2", b.Colors[3]);
	}

	public void RenderFurniture(MaterialPreviewButton b)
	{
		Furniture.SetActive(true);
		MeshRenderer[] componentsInChildren = _furnPrefab.GetComponentsInChildren<MeshRenderer>(true);
		HashSet<Renderer> hashSet = _furnPrefab.Colorable.ToHashSet();
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetColor("_Color1", (!_furnPrefab.ColorPrimaryEnabled || _furnPrefab.ForceColorPrimary) ? _furnPrefab.ColorPrimaryDefault : b.Colors[0]);
		materialPropertyBlock.SetColor("_Color2", (!_furnPrefab.ColorSecondaryEnabled || _furnPrefab.ForceColorSecondary) ? _furnPrefab.ColorSecondaryDefault : b.Colors[1]);
		materialPropertyBlock.SetColor("_Color3", (!_furnPrefab.ColorTertiaryEnabled || _furnPrefab.ForceColorTertiary) ? _furnPrefab.ColorTertiaryDefault : b.Colors[2]);
		materialPropertyBlock.SetFloat("_EmissionFact", 1f);
		if (_furnPrefab.AtlasObject != null)
		{
			float x = (float)b.AtlasIndex % _furnPrefab.AtlasDimensions.x / _furnPrefab.AtlasDimensions.x;
			float y = Mathf.Floor((float)b.AtlasIndex / _furnPrefab.AtlasDimensions.x) / _furnPrefab.AtlasDimensions.y;
			materialPropertyBlock.SetVector("_Offset", new Vector4(x, y, 1f / _furnPrefab.AtlasDimensions.x, 1f / _furnPrefab.AtlasDimensions.y));
		}
		int num = 0;
		Quaternion quaternion = Quaternion.Euler(0f, _furnPrefab.CustomizationRotation, 0f);
		ReplacementMesh[] replacementMeshes = _furnPrefab.ReplacementMeshes;
		Dictionary<MeshFilter, ReplacementMesh> dictionary = ((replacementMeshes != null) ? replacementMeshes.ToDictionary((ReplacementMesh replacementMesh) => replacementMesh.MF, (ReplacementMesh result) => result) : null) ?? new Dictionary<MeshFilter, ReplacementMesh>();
		Dictionary<string, ValueTuple<Mesh, Material>> dictionary2 = new Dictionary<string, ValueTuple<Mesh, Material>>();
		if (_furnPrefab.ReplacementGroups != null && _furnPrefab.ReplacementGroups.Length != 0)
		{
			for (int num2 = 0; num2 < _furnPrefab.ReplacementGroups.Length; num2++)
			{
				string key = _furnPrefab.ReplacementGroups[num2];
				ObjectDatabase.ReplacementGroup group;
				ObjectDatabase.ReplacementObject o;
				if (ObjectDatabase.Instance.GetReplacementGroup(key, out group) && group.GetReplacement(b.Mats[num2], out o))
				{
					for (int num3 = 0; num3 < o.Keys.Count; num3++)
					{
						ObjectDatabase.ReplacementKey replacementKey = o.Keys[num3];
						dictionary2[replacementKey.Key] = new ValueTuple<Mesh, Material>(replacementKey.Mesh, o.Material);
					}
				}
			}
		}
		Renderer image = null;
		Transform transform = null;
		Transform transform2 = null;
		Transform transform3 = null;
		Transform transform4 = null;
		UserImageFrame component = _furnPrefab.GetComponent<UserImageFrame>();
		foreach (MeshRenderer item in componentsInChildren.Where((MeshRenderer meshRenderer2) => !"HideUnaffected".Equals(meshRenderer2.tag) && !"IgnoreMesh".Equals(meshRenderer2.tag)))
		{
			MeshFilter component2 = item.GetComponent<MeshFilter>();
			if (component2 == null)
			{
				continue;
			}
			if (num >= _furnRends.Count)
			{
				GameObject gameObject = new GameObject();
				gameObject.layer = 9;
				gameObject.transform.SetParent(Furniture.transform);
				_furnRends.Add(gameObject.AddComponent<MeshRenderer>());
				_furnMeshes.Add(gameObject.AddComponent<MeshFilter>());
			}
			MeshRenderer meshRenderer = _furnRends[num];
			if (component != null)
			{
				if (item == component.Image)
				{
					image = meshRenderer;
				}
				else if (item.transform == component.Bottom)
				{
					transform4 = meshRenderer.transform;
				}
				else if (item.transform == component.Left)
				{
					transform = meshRenderer.transform;
				}
				else if (item.transform == component.Right)
				{
					transform2 = meshRenderer.transform;
				}
				else if (item.transform == component.Top)
				{
					transform3 = meshRenderer.transform;
				}
			}
			meshRenderer.name = item.name;
			meshRenderer.transform.position = quaternion * item.transform.position + Furniture.transform.position;
			meshRenderer.transform.rotation = quaternion * item.transform.rotation;
			meshRenderer.transform.localScale = item.transform.lossyScale;
			meshRenderer.sharedMaterial = item.sharedMaterial;
			_furnMeshes[num].sharedMesh = component2.sharedMesh;
			ReplacementMesh value;
			ValueTuple<Mesh, Material> value2;
			if (dictionary.TryGetValue(component2, out value) && dictionary2.TryGetValue(value.ReplacementName, out value2))
			{
				_furnMeshes[num].sharedMesh = value2.Item1;
				meshRenderer.sharedMaterial = value2.Item2;
			}
			Furniture furniture;
			if (hashSet.Contains(item) || item == _furnPrefab.AtlasObject)
			{
				meshRenderer.SetPropertyBlock(materialPropertyBlock);
			}
			else if ((object)(furniture = _furnPrefab as Furniture) != null && furniture.TheScreen != null && furniture.TheScreen.gameObject == item.gameObject)
			{
				meshRenderer.sharedMaterial = furniture.OnMat;
			}
			meshRenderer.gameObject.SetActive(true);
			num++;
		}
		if (component != null)
		{
			Material mat = ((b.Mats[2] == null) ? GameData.UserImages["defaultuserimage"] : (GameData.UserImages.GetOrNull(b.Mats[2]) ?? GameData.UserImages["defaultuserimage"]));
			GameObject gameObject2 = new GameObject("Temp");
			gameObject2.transform.position = quaternion * component.FrameHolder.transform.position + Furniture.transform.position;
			gameObject2.transform.rotation = quaternion * component.FrameHolder.transform.rotation;
			gameObject2.transform.localScale = component.FrameHolder.transform.lossyScale;
			gameObject2.transform.SetParent(Furniture.transform, true);
			SetParent(transform, gameObject2.transform);
			SetParent(transform2, gameObject2.transform);
			SetParent(transform3, gameObject2.transform);
			SetParent(transform4, gameObject2.transform);
			UserImageFrame.ApplyTo(mat, component.Scale, component.FrameThickness, image, transform, transform2, transform3, transform4, gameObject2.transform);
			SetParent(transform, Furniture.transform);
			SetParent(transform2, Furniture.transform);
			SetParent(transform3, Furniture.transform);
			SetParent(transform4, Furniture.transform);
			UnityEngine.Object.Destroy(gameObject2);
		}
		CompanySignage component3 = _furnPrefab.GetComponent<CompanySignage>();
		if (component3 != null && !component3.JustLogo)
		{
			_furnRends[0].sharedMaterial = GameSettings.Instance.GetCompanyBuildingName(GameSettings.Instance.MyCompany).Item2;
		}
		for (int num4 = num; num4 < _furnRends.Count; num4++)
		{
			_furnRends[num4].gameObject.SetActive(false);
		}
	}

	private static void SetParent(Transform a, Transform b)
	{
		if (a != null)
		{
			a.SetParent(b, true);
		}
	}

	public Renderer ActivateFence(string type)
	{
		Renderer result = null;
		for (int i = 0; i < FenceGroups.childCount; i++)
		{
			Transform child = FenceGroups.GetChild(i);
			if (child.name.Equals(type))
			{
				child.gameObject.SetActive(true);
				result = child.GetComponent<Renderer>();
			}
			else
			{
				child.gameObject.SetActive(false);
			}
		}
		return result;
	}

	private void Reset()
	{
		Building.SetActive(false);
		Fence.SetActive(false);
		Roofing.SetActive(false);
		Furniture.SetActive(false);
		Path.gameObject.SetActive(false);
	}

	public RenderTexture GetNextRender()
	{
		for (int i = 0; i < _buttonCount; i++)
		{
			MaterialPreviewButton materialPreviewButton = _buttons[i];
			if (materialPreviewButton.gameObject.activeSelf && materialPreviewButton.NeedsRender)
			{
				Reset();
				switch (ViewMode)
				{
				case Mode.Room:
					RenderRoom(materialPreviewButton);
					break;
				case Mode.Fence:
				case Mode.Balcony:
					RenderFence(materialPreviewButton);
					break;
				case Mode.Roof:
					RenderRoof(materialPreviewButton);
					break;
				case Mode.Path:
					RenderPath(materialPreviewButton);
					break;
				case Mode.Furniture:
					RenderFurniture(materialPreviewButton);
					break;
				}
				materialPreviewButton.NeedsRender = false;
				return materialPreviewButton.Thumbnail.texture as RenderTexture;
			}
		}
		return null;
	}

	private void Start()
	{
		for (int i = 0; i < AtlasToggles.Length; i++)
		{
			int i2 = i;
			AtlasToggles[i].onValueChanged.AddListener(delegate(bool x)
			{
				if (x && !_disableAtlasRefresh)
				{
					_atlas = i2;
					if (ViewMode == Mode.Furniture && _furnPrefab.AtlasObject != null)
					{
						if (CanAdd && _enableAtlasChange)
						{
							int activeAtlas = GetActiveAtlas();
							WallSnap[] array = GetRelevantSelected<WallSnap>(true).ToArray();
							UndoObject.UndoAction undoAction = new UndoObject.UndoAction(array, true);
							for (int j = 0; j < array.Length; j++)
							{
								array[j].AtlasIndex = activeAtlas;
							}
							GameSettings.Instance.AddUndo(undoAction);
						}
						Refresh();
					}
				}
			});
		}
		base.gameObject.SetActive(false);
	}

	private void RefreshThumbnailCount()
	{
		LayoutRebuilder.ForceRebuildLayoutImmediate(SelfRect);
		float num = 0f - SelfRect.offsetMax.y - ContentRect.anchoredPosition.y;
		float num2 = (_lastHeight = (float)Screen.height / Options.UISize - num - 24f) / 132f;
		num2 = Mathf.Min((float)Screen.height / Options.UISize - num - 24f - MinYDistance, num2 * 132f) / 132f;
		_buttonCount = Mathf.FloorToInt(num2);
		ContentRect.sizeDelta = new Vector2(ContentRect.sizeDelta.x, (float)_buttonCount * 128f + (float)(Mathf.Max(0, _buttonCount - 1) * 8) + 24f);
		for (int i = _buttonCount; i < _buttons.Length; i++)
		{
			_buttons[i].gameObject.SetActive(false);
		}
	}

	private void InitializeThumbnails()
	{
		float num = 0f - SelfRect.offsetMax.y + 25f;
		float num2 = (float)Screen.height / Options.UISize - num - 24f;
		if (num2 == _lastHeight)
		{
			return;
		}
		_lastHeight = num2;
		float num3 = num2 / 132f;
		num3 = Mathf.Min((float)Screen.height / Options.UISize - num - 24f - MinYDistance, num3 * 132f) / 132f;
		int num4 = Mathf.FloorToInt(num3);
		ContentRect.sizeDelta = new Vector2(ContentRect.sizeDelta.x, (float)num4 * 128f + (float)(Mathf.Max(0, num4 - 1) * 8) + 24f);
		if (_buttons == null)
		{
			_buttons = new MaterialPreviewButton[num4];
			for (int i = 0; i < num4; i++)
			{
				_buttons[i] = CreateButton(i);
			}
		}
		else
		{
			if (_buttons.Length == num4)
			{
				return;
			}
			MaterialPreviewButton[] array = new MaterialPreviewButton[num4];
			for (int j = 0; j < Mathf.Min(num4, _buttons.Length); j++)
			{
				array[j] = _buttons[j];
			}
			if (_buttons.Length > num4)
			{
				for (int k = num4; k < _buttons.Length; k++)
				{
					UnityEngine.Object.Destroy(_buttons[k].Thumbnail.texture);
					UnityEngine.Object.Destroy(_buttons[k].gameObject);
				}
			}
			else if (_buttons.Length < num4)
			{
				for (int l = _buttons.Length; l < num4; l++)
				{
					array[l] = CreateButton(l);
				}
			}
			_buttons = array;
		}
	}

	private MaterialPreviewButton CreateButton(int i)
	{
		MaterialPreviewButton materialPreviewButton = UnityEngine.Object.Instantiate(ButtonPrefab);
		materialPreviewButton.transform.SetParent(ContentRect, false);
		materialPreviewButton.ClickButton.onClick.AddListener(delegate
		{
			Click(i);
		});
		materialPreviewButton.DeleteButton.onClick.AddListener(delegate
		{
			Delete(i);
		});
		RenderTexture texture = new RenderTexture(128, 128, 0, RenderTextureFormat.ARGB32)
		{
			antiAliasing = 4
		};
		materialPreviewButton.Thumbnail.texture = texture;
		return materialPreviewButton;
	}

	private void OnDestroy()
	{
		if (_buttons != null)
		{
			for (int i = 0; i < _buttons.Length; i++)
			{
				UnityEngine.Object.Destroy(_buttons[i].Thumbnail.texture);
			}
		}
	}

	private void SetBuildingTex(Renderer rend, string tex)
	{
		bool num = tex.Equals("None");
		RoomMaterialController.WallMaterial wallMaterial = ((!num) ? RoomMaterialController.Instance.AllMaterials.GetOrDefault(tex, RoomMaterialController.Instance.RoomMaterials[0]) : null);
		Texture mainTexture = RoomMaterialController.Instance.DefaultBase;
		if (!num && wallMaterial.Base != null)
		{
			mainTexture = wallMaterial.Base;
		}
		rend.material.mainTexture = mainTexture;
		mainTexture = RoomMaterialController.Instance.DefaultExtra;
		if (!num && wallMaterial.Extra != null)
		{
			mainTexture = wallMaterial.Extra;
		}
		rend.material.SetTexture("_ExtraTex", mainTexture);
		mainTexture = RoomMaterialController.Instance.DefaultBump;
		if (!num && wallMaterial.Bump != null)
		{
			mainTexture = wallMaterial.Bump;
		}
		rend.material.SetTexture("_BumpTex", mainTexture);
		if (!num && wallMaterial.AddSkirting)
		{
			rend.material.EnableKeyword("_SKIRT");
		}
		else
		{
			rend.material.DisableKeyword("_SKIRT");
		}
	}
}
