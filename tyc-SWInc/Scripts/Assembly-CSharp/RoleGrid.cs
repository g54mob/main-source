using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoleGrid : MaskableGraphic, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler
{
	private static float[] _uiScales = new float[11]
	{
		1f, 0.965f, 0.963f, 0.985f, 0.96f, 1f, 0.976f, 0.974f, 0.99f, 0.97f,
		1f
	};

	public float LineHeight;

	public float ColumnWidth;

	public Toggle[] RoleToggles;

	public Gradient SkillGrad;

	public Toggle RelativeToggle;

	public Color BackColor;

	public Color CheckColor;

	public Color CheckBackColor;

	public Color CheckSecondaryColor;

	public List<Actor> Actors = new List<Actor>();

	public Text RowLabels;

	public GUIWindow Window;

	public RectTransform ContentPanel;

	public RectTransform selfRect;

	public RectTransform SkillRect;

	public RectTransform BackRect;

	public float Padding = 2f;

	public float CheckSize = 8f;

	public float CheckSpace = 24f;

	private int _lastScale;

	private bool _isUpdatingRoleToggle;

	private bool _actorLabelDirty;

	public void Show(IEnumerable<Actor> actors)
	{
		Actors = (from x in actors
			orderby (x.GetTeam() != null) ? x.GetTeam().Name : "", x.employee.FullName
			select x).ToList();
		if (Actors.Count > 0)
		{
			Window.Show();
			UpdateActorLabel(true);
			selfRect.sizeDelta = new Vector2(selfRect.sizeDelta.x, (float)Mathf.Max(4, Actors.Count) * LineHeight);
			ContentPanel.sizeDelta = new Vector2(ContentPanel.sizeDelta.x, (float)Mathf.Max(4, Actors.Count + 1) * LineHeight);
			SetVerticesDirty();
			LayoutRebuilder.ForceRebuildLayoutImmediate(RowLabels.rectTransform.parent.GetComponent<RectTransform>());
			for (int num = 0; num < RoleToggles.Length; num++)
			{
				UpdateRoleToggle(num);
			}
		}
	}

	private void UpdateActorLabel(bool now)
	{
		if (now)
		{
			_actorLabelDirty = false;
			RowLabels.text = string.Join("\n", Actors.Select((Actor x) => ((x.employee.CurrentRoleBit | x.employee.SecondaryRole) == Employee.RoleBit.None) ? ("<color=#ff0000ff>" + x.employee.FullName + "</color>") : x.employee.FullName).ToArray());
		}
		else
		{
			_actorLabelDirty = true;
		}
	}

	public void OnToggle(int role)
	{
		if (_isUpdatingRoleToggle)
		{
			return;
		}
		for (int i = 0; i < Actors.Count; i++)
		{
			Actor actor = Actors[i];
			if (actor != null)
			{
				actor.ChangeRole((Employee.EmployeeRole)role, false, RoleToggles[role].isOn);
			}
		}
		SetVerticesDirty();
		UpdateActorLabel(true);
	}

	public void UpdateRoleToggle(int r)
	{
		_isUpdatingRoleToggle = true;
		RoleToggles[r].isOn = Actors.Where((Actor x) => x != null).All((Actor x) => x.employee.IsRoleIndex(r, true));
		_isUpdatingRoleToggle = false;
	}

	private void Update()
	{
		if (Application.isPlaying)
		{
			int num = Mathf.RoundToInt((Options.UISize - 1f) * 10f) % 10;
			if (num != _lastScale)
			{
				_lastScale = num;
				RectTransform skillRect = SkillRect;
				Vector3 localScale = (BackRect.localScale = new Vector3(1f, _uiScales[_lastScale], 1f));
				skillRect.localScale = localScale;
			}
			if (_actorLabelDirty)
			{
				UpdateActorLabel(true);
			}
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		bool isOn = RelativeToggle.isOn;
		for (int i = 0; i < Actors.Count; i++)
		{
			Actor actor = Actors[i];
			if (actor == null)
			{
				Actors.RemoveAt(i);
				i--;
				UpdateActorLabel(false);
			}
			float num = 0.01f;
			if (isOn)
			{
				for (int j = 0; j < 5; j++)
				{
					num = Mathf.Max(num, actor.employee.GetSkillI(j));
				}
			}
			for (int k = 0; k < 5; k++)
			{
				bool num2 = actor.employee.IsRoleIndex(k);
				bool flag = actor.employee.IsSecondaryRoleIndex(k);
				float num3 = ColumnWidth * (float)k;
				float num4 = LineHeight * (float)i;
				Color color = ((num2 || flag) ? BackColor : CheckBackColor);
				DrawRect(num3, num4, ColumnWidth - Padding / 2f, LineHeight, color, color, vh);
				float num5 = actor.employee.GetSkillI(k);
				if (isOn)
				{
					num5 /= num;
				}
				Color color2 = SkillGrad.Evaluate(num5);
				DrawRect(num3 + Padding / 2f, num4 + Padding / 2f, Mathf.Round((ColumnWidth - CheckSpace - Padding) * num5), LineHeight - Padding, SkillGrad.Evaluate(0f), color2, vh);
				DrawRect(num3 + ColumnWidth - CheckSpace, num4 + Padding / 2f, CheckSpace - Padding, LineHeight - Padding, color2, color2, vh);
				if (num2 || flag)
				{
					Color color3 = (flag ? CheckSecondaryColor : CheckColor);
					DrawRect(num3 + ColumnWidth - CheckSpace / 2f - CheckSize / 2f - Padding / 2f, num4 + LineHeight / 2f - CheckSize / 2f, CheckSize, CheckSize, color3, color3, vh);
				}
			}
		}
	}

	public void DrawRect(float x, float y, float w, float h, Color col, Color col2, VertexHelper vh)
	{
		vh.AddUIVertexQuad(new UIVertex[4]
		{
			new UIVertex
			{
				color = col,
				position = new Vector3(x, 0f - y, 0f)
			},
			new UIVertex
			{
				color = col2,
				position = new Vector3(x + w, 0f - y, 0f)
			},
			new UIVertex
			{
				color = col2,
				position = new Vector3(x + w, 0f - y - h, 0f)
			},
			new UIVertex
			{
				color = col,
				position = new Vector3(x, 0f - y - h, 0f)
			}
		});
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Vector2 localPoint = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(selfRect, eventData.position, UICamSize.GetUICam(), out localPoint);
		int num = Mathf.FloorToInt((0f - localPoint.y) / LineHeight);
		if (num < 0 || num >= Actors.Count)
		{
			return;
		}
		int num2 = Mathf.FloorToInt(localPoint.x / ColumnWidth);
		if (num2 >= 0 && num2 < 5)
		{
			Employee.EmployeeRole role = (Employee.EmployeeRole)num2;
			bool flag = eventData.button == PointerEventData.InputButton.Right;
			if (flag)
			{
				SelectorController.CanClick = false;
			}
			bool flag2 = Actors[num].employee.IsSecondaryRole(role);
			bool flag3 = Actors[num].employee.IsRole(role) || flag2;
			Actors[num].ChangeRole(role, flag, flag2 != flag || !flag3);
			SetVerticesDirty();
			UpdateActorLabel(true);
			UpdateRoleToggle(num2);
		}
	}

	public void PointerClickName(BaseEventData bEventData)
	{
		PointerEventData pointerEventData = (PointerEventData)bEventData;
		Vector2 localPoint = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(selfRect, pointerEventData.position, UICamSize.GetUICam(), out localPoint);
		int num = Mathf.FloorToInt((0f - localPoint.y) / LineHeight);
		if (num >= 0 && num < Actors.Count)
		{
			Actor actor = Actors[num];
			Employee.RoleBit currentRoleBit = actor.employee.CurrentRoleBit;
			Employee.RoleBit roleBit = currentRoleBit & Employee.RoleBit.Lead;
			if ((currentRoleBit & Employee.RoleBit.AnyRole) == Employee.RoleBit.AnyRole)
			{
				actor.ChangeRole(roleBit, Employee.RoleBit.None);
			}
			else
			{
				actor.ChangeRole(roleBit | Employee.RoleBit.AnyRole, Employee.RoleBit.None);
			}
			SetVerticesDirty();
			UpdateActorLabel(true);
			for (int i = 0; i < RoleToggles.Length; i++)
			{
				UpdateRoleToggle(i);
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
