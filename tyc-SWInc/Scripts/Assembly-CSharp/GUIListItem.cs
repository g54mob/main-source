using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIListItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	public int Idx;

	[SerializeField]
	private Text _label;

	[SerializeField]
	private Image _backgroundImage;

	[SerializeField]
	private SimpleIconPanel _icon;

	[SerializeField]
	private Slider _slider;

	[SerializeField]
	private IconFillBar _iconBar;

	[SerializeField]
	private SheetTipGraphic _roleBar;

	[SerializeField]
	private Toggle _toggle;

	[SerializeField]
	private GUIProgressBar _progBar;

	[SerializeField]
	private RawImage _logo;

	public GUIColumn Parent;

	private bool _inputEnabled = true;

	public bool Odd;

	public float PreferredWidth
	{
		get
		{
			if (Parent == null)
			{
				return 0f;
			}
			switch (Parent.Type)
			{
			case GUIColumn.ColumnType.Label:
			case GUIColumn.ColumnType.Action:
				return _label.preferredWidth;
			case GUIColumn.ColumnType.Stars:
				return 68f;
			case GUIColumn.ColumnType.Stars5:
				return 85f;
			case GUIColumn.ColumnType.Role:
				return 120f;
			case GUIColumn.ColumnType.Trait:
				return 96f;
			case GUIColumn.ColumnType.WarningIcon:
			case GUIColumn.ColumnType.Color:
			case GUIColumn.ColumnType.Toggle:
			case GUIColumn.ColumnType.Logo:
				return 24f;
			default:
				return 64f;
			}
		}
	}

	public void SetValue(object value)
	{
		_inputEnabled = false;
		switch (Parent.Type)
		{
		case GUIColumn.ColumnType.Label:
		case GUIColumn.ColumnType.Action:
		case GUIColumn.ColumnType.PlusMinus:
			_label.text = ((value == null) ? "" : value.ToString());
			break;
		case GUIColumn.ColumnType.ProgressBar:
		{
			float value2 = (float)value;
			_label.text = value2.ToPercent();
			_progBar.Value = value2;
			break;
		}
		case GUIColumn.ColumnType.Slider:
			_slider.value = (float)value;
			break;
		case GUIColumn.ColumnType.Stars:
			_iconBar.Values[1] = (float)value;
			_iconBar.SetVerticesDirty();
			break;
		case GUIColumn.ColumnType.Stars5:
			_iconBar.Values[0] = 5f;
			_iconBar.Values[1] = (float)value;
			_iconBar.SetVerticesDirty();
			break;
		case GUIColumn.ColumnType.Role:
		{
			Actor actor = value as Actor;
			if (actor != null)
			{
				Employee employee = actor.employee;
				_roleBar.DotMask = employee.GetExpBit(actor);
				_roleBar.DotMask2 = actor.GetCourseBit();
				_roleBar.DotMask |= _roleBar.DotMask2;
				if (actor.IsMentor)
				{
					_roleBar.DotMask |= 512;
				}
				Employee.RoleBit roleBit = employee.CurrentRoleBit | employee.SecondaryRole;
				_roleBar.Sprites[0] = (((roleBit & Employee.RoleBit.Lead) <= Employee.RoleBit.None) ? (-1) : 0);
				_roleBar.Sprites[1] = (((roleBit & Employee.RoleBit.Designer) > Employee.RoleBit.None) ? 2 : (-1));
				_roleBar.Sprites[2] = (((roleBit & Employee.RoleBit.Programmer) > Employee.RoleBit.None) ? 1 : (-1));
				_roleBar.Sprites[3] = (((roleBit & Employee.RoleBit.Artist) > Employee.RoleBit.None) ? 3 : (-1));
				_roleBar.Sprites[4] = (((roleBit & Employee.RoleBit.Service) > Employee.RoleBit.None) ? 4 : (-1));
				_roleBar.Colors[0] = GetRoleColor(employee.CurrentRoleBit, employee.SecondaryRole, Employee.RoleBit.Lead);
				_roleBar.Colors[1] = GetRoleColor(employee.CurrentRoleBit, employee.SecondaryRole, Employee.RoleBit.Designer);
				_roleBar.Colors[2] = GetRoleColor(employee.CurrentRoleBit, employee.SecondaryRole, Employee.RoleBit.Programmer);
				_roleBar.Colors[3] = GetRoleColor(employee.CurrentRoleBit, employee.SecondaryRole, Employee.RoleBit.Artist);
				_roleBar.Colors[4] = GetRoleColor(employee.CurrentRoleBit, employee.SecondaryRole, Employee.RoleBit.Service);
				_roleBar.SetVerticesDirty();
			}
			else if (value is Employee.RoleBit)
			{
				Employee.RoleBit roleBit2 = (Employee.RoleBit)value;
				_roleBar.Sprites[0] = (((roleBit2 & Employee.RoleBit.Lead) <= Employee.RoleBit.None) ? (-1) : 0);
				_roleBar.Sprites[1] = (((roleBit2 & Employee.RoleBit.Designer) > Employee.RoleBit.None) ? 2 : (-1));
				_roleBar.Sprites[2] = (((roleBit2 & Employee.RoleBit.Programmer) > Employee.RoleBit.None) ? 1 : (-1));
				_roleBar.Sprites[3] = (((roleBit2 & Employee.RoleBit.Artist) > Employee.RoleBit.None) ? 3 : (-1));
				_roleBar.Sprites[4] = (((roleBit2 & Employee.RoleBit.Service) > Employee.RoleBit.None) ? 4 : (-1));
				_roleBar.SetVerticesDirty();
			}
			break;
		}
		case GUIColumn.ColumnType.WarningIcon:
		{
			string[] array = value.ToString().Split('|');
			_icon.SetIcon(array[0], array[1], array[2]);
			break;
		}
		case GUIColumn.ColumnType.Color:
		{
			Color color;
			ColorUtility.TryParseHtmlString(value.ToString(), out color);
			_backgroundImage.color = color;
			break;
		}
		case GUIColumn.ColumnType.Toggle:
		{
			bool flag = (bool)value;
			if (_toggle.isOn != flag)
			{
				_toggle.isOn = flag;
			}
			break;
		}
		case GUIColumn.ColumnType.Trait:
		{
			Employee.Trait a = (Employee.Trait)value;
			int num = 0;
			foreach (Employee.Trait item in Enum.GetValues(typeof(Employee.Trait)).OfType<Employee.Trait>().OrderBy(Employee.TraitOrder))
			{
				if (item != Employee.Trait.None && a.HasBits(item))
				{
					_roleBar.SpritesB[num] = ObjectDatabase.Instance.GetTrait(item);
					Vector3 vector = Utilities.RGBToHSV((Employee.Trait.FastLearner | Employee.Trait.Independant | Employee.Trait.BigBrain | Employee.Trait.Humble | Employee.Trait.Capacitor | Employee.Trait.WalkItOff | Employee.Trait.ThisIsFine | Employee.Trait.Sunshine | Employee.Trait.Skyscraper | Employee.Trait.RGBThumb | Employee.Trait.Clean).HasBits(item) ? HUD.GetThemeColor(0) : ((Employee.Trait.NightOwl | Employee.Trait.BornLeader | Employee.Trait.FirmwareInc | Employee.Trait.SuperFocus | Employee.Trait.Unphased | Employee.Trait.JustTheFlu | Employee.Trait.Detached | Employee.Trait.Watch | Employee.Trait.FriendMaker).HasBits(item) ? HUD.GetThemeColor(1) : HUD.GetThemeColor(2)));
					_roleBar.Colors[num] = Utilities.HSVToRGBA(vector.x, 1f, 0.63f);
					_roleBar.Tips[num] = "Trait" + item;
					num++;
				}
				if (num == 4)
				{
					break;
				}
			}
			for (int i = num; i < 4; i++)
			{
				_roleBar.SpritesB[i] = null;
				_roleBar.Tips[i] = null;
			}
			_roleBar.SetVerticesDirty();
			break;
		}
		case GUIColumn.ColumnType.Logo:
		{
			Company company = (Company)value;
			_logo.uvRect = ((company == null) ? Rect.zero : LogoController.Instance.GetLogoRect(company));
			break;
		}
		}
		_inputEnabled = true;
	}

	private static Color GetRoleColor(Employee.RoleBit main, Employee.RoleBit secondary, Employee.RoleBit role)
	{
		bool flag = (main & role) > Employee.RoleBit.None;
		bool flag2 = (secondary & role) > Employee.RoleBit.None;
		return (false ? new Color(0f, 0.7f, 0f) : new Color(0.2f, 0.2f, 0.2f)).Alpha(flag ? 1f : (flag2 ? 0.5f : 0.25f));
	}

	private Color GetBGColor(bool highlight, int theme = 0)
	{
		if (!highlight)
		{
			return new Color(0f, 0f, 0f, Odd ? 0.1f : 0f);
		}
		return HUD.GetThemeColor(theme).Alpha(Odd ? 0.6f : 1f);
	}

	public void Highlight(bool highlight, bool sumLine = false)
	{
		switch (Parent.Type)
		{
		case GUIColumn.ColumnType.Label:
			if (sumLine)
			{
				_backgroundImage.color = new Color(0f, 0f, 0f, 0.2f);
				_label.fontStyle = FontStyle.Bold;
			}
			else
			{
				_backgroundImage.color = GetBGColor(highlight);
				_label.fontStyle = FontStyle.Normal;
			}
			break;
		case GUIColumn.ColumnType.WarningIcon:
		case GUIColumn.ColumnType.Logo:
		case GUIColumn.ColumnType.PlusMinus:
			_backgroundImage.color = GetBGColor(highlight);
			break;
		case GUIColumn.ColumnType.Stars:
		case GUIColumn.ColumnType.Stars5:
			_iconBar.Highlight = highlight || Odd;
			_iconBar.HighlightColor = GetBGColor(highlight);
			_iconBar.SetVerticesDirty();
			break;
		case GUIColumn.ColumnType.Trait:
			_roleBar.Highlight = highlight || Odd;
			_roleBar.HighlightColor = GetBGColor(highlight);
			_roleBar.SetVerticesDirty();
			break;
		case GUIColumn.ColumnType.Role:
			_roleBar.Highlight = highlight || Odd;
			_roleBar.HighlightColor = GetBGColor(highlight);
			_roleBar.SetVerticesDirty();
			break;
		case GUIColumn.ColumnType.Action:
		case GUIColumn.ColumnType.Slider:
		case GUIColumn.ColumnType.Color:
		case GUIColumn.ColumnType.Toggle:
		case GUIColumn.ColumnType.ProgressBar:
			break;
		}
	}

	public void OnClick()
	{
		Parent.OnClickAction(Idx);
	}

	public void SetDiff(int diff)
	{
		if (_inputEnabled && Parent.Type == GUIColumn.ColumnType.PlusMinus)
		{
			Parent.SetValue(Idx, diff);
		}
	}

	public void SetCallBack()
	{
		if (!_inputEnabled)
		{
			return;
		}
		switch (Parent.Type)
		{
		case GUIColumn.ColumnType.Slider:
			Parent.SetValue(Idx, _slider.value);
			break;
		case GUIColumn.ColumnType.Color:
			Parent.Parent.DisableRefresh = true;
			WindowManager.SpawnColorDialog(delegate(Color x)
			{
				Parent.SetValue(Idx, x);
			}, _backgroundImage.color, null, delegate
			{
				Parent.Parent.DisableRefresh = false;
			});
			break;
		case GUIColumn.ColumnType.Toggle:
			Parent.SetValue(Idx, _toggle.isOn);
			break;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Parent.OnHoverAction(Idx, this);
	}
}
