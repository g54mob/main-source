using System.Linq;
using UnityEngine;

public class FloorGizmo : MonoBehaviour
{
	public enum ActionButton
	{
		Angle = 0,
		PlusSize = 1,
		Reset = 2,
		MinuesSize = 3
	}

	public bool IsActive = true;

	public Transform LabelTransform;

	public Transform TopRingT;

	public Transform ExtraCyl;

	public MeshRenderer Label;

	public MeshRenderer BottomRing;

	public MeshRenderer Cylinder;

	public MeshRenderer InnerRing;

	public MeshRenderer[] ActionButtons;

	public string[] ActionButtonDesc;

	public MeshRenderer MoveB;

	public Texture NoMoveTex;

	public Texture MoveTex;

	public Texture RingButton;

	public Texture RingNoButtons;

	public Texture[] AngleSnapTex;

	public static bool IsMoving;

	public TextMesh LabelText;

	public TextMesh ActionLabel;

	public Color ButtonActive;

	public Color ButtonInactive;

	public Color MoveActive;

	public float CamFactor = 30f;

	public float MoveFactor = 1f;

	public int MaxZoom = 10;

	private Vector2? _lockPosition;

	private Matrix4x4 _originalMatrix;

	private void Awake()
	{
		for (int i = 0; i < ActionButtons.Length; i++)
		{
			InitMat(ActionButtons[i]);
		}
		InitMat(MoveB);
		InitMat(InnerRing);
	}

	private void InitMat(MeshRenderer rend)
	{
		rend.sharedMaterial = new Material(rend.sharedMaterial);
	}

	private void SetVisible(bool vis)
	{
		Label.enabled = vis;
		BottomRing.enabled = vis;
		TopRingT.gameObject.SetActive(vis);
		Cylinder.enabled = vis;
	}

	private int GetActiveButton(Vector2 mouse)
	{
		for (int i = 0; i < ActionButtons.Length; i++)
		{
			MeshRenderer meshRenderer = ActionButtons[i];
			Vector2 vector = meshRenderer.transform.position.FlattenVector3();
			if ((mouse - vector).magnitude < meshRenderer.transform.localScale.x * base.transform.localScale.x)
			{
				return i;
			}
		}
		return -1;
	}

	public void StartMove()
	{
		_lockPosition = null;
		InnerRing.sharedMaterial.mainTexture = RingNoButtons;
		for (int i = 0; i < ActionButtons.Length; i++)
		{
			ActionButtons[i].gameObject.SetActive(false);
		}
		ActionLabel.gameObject.SetActive(false);
		MoveB.sharedMaterial.color = MoveActive;
		MoveB.sharedMaterial.mainTexture = MoveTex;
		MoveB.gameObject.SetActive(true);
		IsMoving = true;
		_originalMatrix = BuildController.Instance.GridMatrix;
	}

	private void OnDestroy()
	{
		IsMoving = false;
	}

	private void SetExtraCyl(Vector2 a, Vector2 b)
	{
		if (a == b)
		{
			ExtraCyl.gameObject.SetActive(false);
			return;
		}
		Vector2 v = a - b;
		ExtraCyl.SetPositionAndRotation(((a + b) * 0.5f).ToVector3((float)GameSettings.Instance.ActiveFloor * 2f), Quaternion.LookRotation(v.ToVector3(0f)));
		ExtraCyl.localScale = new Vector3(ExtraCyl.localScale.x, ExtraCyl.localScale.y, v.magnitude);
		ExtraCyl.gameObject.SetActive(true);
	}

	private Matrix4x4 GetGridChange(ref Vector2 pos)
	{
		ExtraCyl.gameObject.SetActive(false);
		Matrix4x4 result = BuildController.Instance.GridMatrix;
		float num = 1f / BuildController.Instance.GetGridSize();
		bool flag = false;
		foreach (RaycastHit item in from x in Physics.RaycastAll(CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition))
			orderby x.distance
			select x)
		{
			Furniture component = item.collider.GetComponent<Furniture>();
			if (component != null && component.Parent.Floor == GameSettings.Instance.ActiveFloor)
			{
				Vector3 vector = component.transform.rotation * (Vector3.one * 0.5f);
				pos = new Vector2(component.OriginalPosition.x + (component.OnXEdge ? 0f : vector.x), component.OriginalPosition.z + (component.OnYEdge ? 0f : vector.z));
				result = Matrix4x4.TRS(pos.ToVector3(0f), component.transform.rotation, Vector3.one * num).inverse;
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			Vector2 p = pos;
			foreach (Room item2 in GameSettings.Instance.sRoomManager.Rooms.Where((Room x) => x.Floor == GameSettings.Instance.ActiveFloor && x.IsInsideBounds(p, BuildController.GetSnapDistance())))
			{
				for (int num2 = 0; num2 < item2.Edges.Count; num2++)
				{
					Vector2 pos2 = item2.Edges[num2].Pos;
					Vector2 pos3 = item2.Edges[(num2 + 1) % item2.Edges.Count].Pos;
					Vector2 res;
					if (!Utilities.ProjectToLine(p, pos2, pos3, out res) || !(res.Dist(p) < BuildController.GetSnapDistance()))
					{
						continue;
					}
					Vector2 vector2 = pos2;
					Vector2 vector3 = pos3;
					float num3 = (pos2 - res).magnitude;
					float magnitude = (pos3 - res).magnitude;
					float num4 = Mathf.Abs(num3 - magnitude);
					if (num4 < 1f)
					{
						pos = (vector2 + vector3) * 0.5f;
						if (num4 > 0.5f)
						{
							Vector2 a = pos;
							pos += (res - pos).normalized * 0.5f;
							SetExtraCyl(a, pos);
						}
						else
						{
							SetExtraCyl(pos2, pos3);
						}
						result = Matrix4x4.TRS(pos.ToVector3(0f), Quaternion.LookRotation((vector2 - vector3).ToVector3(0f)), Vector3.one * num).inverse;
						continue;
					}
					if (magnitude < num3)
					{
						vector2 = pos3;
						num3 = magnitude;
					}
					Vector2 vector4 = (res - vector2) * (1f / num3);
					num3 = Mathf.Round(num3 / num) * num;
					pos = vector2 + vector4 * num3;
					SetExtraCyl(vector2, pos);
					result = Matrix4x4.TRS(pos.ToVector3(0f), Quaternion.LookRotation(vector4.ToVector3(0f)), Vector3.one * num).inverse;
				}
			}
		}
		return result;
	}

	private void LateUpdate()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		bool flag = WindowManager.Instance.MainPanel.activeSelf && HUD.Instance.BuildMode && (bool)WindowManager.Instance.Canvas;
		if (flag != IsActive)
		{
			IsActive = flag;
			SetVisible(IsActive);
			IsMoving &= IsActive;
		}
		if (!IsActive)
		{
			return;
		}
		if (IsMoving && Input.GetMouseButtonUp(1))
		{
			BuildController.Instance.GridMatrix = _originalMatrix;
			BuildController.Instance.UpdateGridVisual();
			ExtraCyl.gameObject.SetActive(false);
			IsMoving = false;
			SelectorController.CanClick = false;
		}
		float num = (0f - CameraScript.Instance.mainCam.transform.localPosition.z) * CameraScript.Instance.mainCam.fieldOfView;
		int num2 = Mathf.Clamp(Mathf.RoundToInt(num / CamFactor), 1, MaxZoom);
		base.transform.localScale = new Vector3(num2, 1f, num2);
		LabelText.text = ((GameSettings.Instance.ActiveFloor < 0) ? "Basement".Loc() : ((GameSettings.Instance.ActiveFloor > 0) ? "FloorPostfix".Loc(GameSettings.Instance.ActiveFloor) : "Groundfloor".Loc()));
		MoveB.transform.localRotation = Quaternion.Euler(0f, BuildController.Instance.GetGridRotation(), 0f);
		LabelTransform.localRotation = Quaternion.Euler(0f, CameraScript.Instance.transform.rotation.eulerAngles.y, 0f);
		LabelTransform.transform.localPosition = new Vector3(0f, (float)Mathf.Max(0, GameSettings.Instance.ActiveFloor) * 2f, 0f);
		Cylinder.transform.localScale = Cylinder.transform.localScale.ReplaceY(Mathf.Max(0, GameSettings.Instance.ActiveFloor) + (IsMoving ? 1 : 0));
		if (GameSettings.Instance.ActiveFloor > 0)
		{
			BottomRing.gameObject.SetActive(true);
			BottomRing.transform.localPosition = Vector3.zero;
			TopRingT.localPosition = new Vector3(0f, (float)GameSettings.Instance.ActiveFloor * 2f, 0f);
		}
		else
		{
			TopRingT.localPosition = Vector3.zero;
			BottomRing.gameObject.SetActive(false);
		}
		if (IsMoving)
		{
			Vector2 pos = HUD.Instance.GetMouseProj();
			LabelTransform.localRotation = Quaternion.Euler(0f, CameraScript.Instance.transform.rotation.eulerAngles.y, 0f);
			LabelTransform.transform.localPosition = new Vector3(0f, (float)Mathf.Max(0, GameSettings.Instance.ActiveFloor) * 2f, 0f);
			BuildController.Instance.GridMatrix = GetGridChange(ref pos);
			BuildController.Instance.UpdateGridVisual();
			base.transform.position = pos.ToVector3((float)Mathf.Min(0, GameSettings.Instance.ActiveFloor) * 2f + 0.02f);
			if (Input.GetMouseButtonUp(0))
			{
				SelectorController.CanClick = false;
				ExtraCyl.gameObject.SetActive(false);
				BuildController.Instance.ApplyMatrix();
				if (BuildController.Instance.CurrentFurnitureBuilder != null)
				{
					BuildController.Instance.CurrentFurnitureBuilder.ResetRotation();
				}
				IsMoving = false;
			}
			return;
		}
		Vector2 vector;
		if (_lockPosition.HasValue)
		{
			vector = _lockPosition.Value + CameraScript.Instance.transform.position.FlattenVector3();
		}
		else
		{
			vector = CameraScript.Instance.transform.position.FlattenVector3() + (Quaternion.Euler(0f, CameraScript.Instance.transform.rotation.eulerAngles.y, 0f) * new Vector3(1f, 0f, (float)Screen.height / (float)Screen.width) * (num / MoveFactor)).FlattenVector3();
			vector = BuildController.Instance.CorrectMousePos(vector);
		}
		base.transform.position = vector.ToVector3((float)Mathf.Min(0, GameSettings.Instance.ActiveFloor) * 2f + 0.02f);
		Vector2 mouseProj = HUD.Instance.GetMouseProj();
		float magnitude = (vector - mouseProj).magnitude;
		if (!GameSettings.FreezeGame && (!BuildController.Instance.IsActive() || HUD.Instance.roofEditWindow.Window.Shown) && !WindowManager.HasModal && !GUICheck.OverGUI && !SelectorController.Instance.MouseOverObject())
		{
			InnerRing.sharedMaterial.mainTexture = RingButton;
			for (int i = 0; i < ActionButtons.Length; i++)
			{
				ActionButtons[i].gameObject.SetActive(true);
			}
			if (magnitude <= (float)num2)
			{
				_lockPosition = vector - CameraScript.Instance.transform.position.FlattenVector3();
				if (magnitude < (float)num2 / 3f)
				{
					for (int j = 0; j < ActionButtons.Length; j++)
					{
						ActionButtons[j].sharedMaterial.color = ButtonInactive;
					}
					MoveB.sharedMaterial.color = MoveActive;
					MoveB.sharedMaterial.mainTexture = MoveTex;
					MoveB.gameObject.SetActive(true);
					string fullKeyBindString = InputController.GetFullKeyBindString(InputController.Keys.AnchorGrid, false, true);
					if (fullKeyBindString != null)
					{
						ActionLabel.text = fullKeyBindString;
						ActionLabel.gameObject.SetActive(true);
					}
					else
					{
						ActionLabel.gameObject.SetActive(false);
					}
					if (Input.GetMouseButtonDown(0))
					{
						StartMove();
					}
				}
				else
				{
					int activeButton = GetActiveButton(mouseProj);
					for (int k = 0; k < ActionButtons.Length; k++)
					{
						ActionButtons[k].sharedMaterial.color = ((k == activeButton) ? ButtonActive : ButtonInactive);
					}
					MoveB.sharedMaterial.color = ButtonInactive;
					MoveB.sharedMaterial.mainTexture = NoMoveTex;
					if (activeButton >= 0)
					{
						ActionButton actionButton = (ActionButton)activeButton;
						if (Input.GetMouseButtonUp(0))
						{
							SelectorController.CanClick = false;
							UISoundFX.PlaySFX("ButtonClick");
							switch (actionButton)
							{
							case ActionButton.Angle:
								BuildController.Instance.AngleToggle();
								break;
							case ActionButton.PlusSize:
								BuildController.Instance.SizeGrid(0.5f);
								break;
							case ActionButton.Reset:
								BuildController.Instance.ResetGrid();
								break;
							case ActionButton.MinuesSize:
								BuildController.Instance.SizeGrid(2f);
								break;
							}
						}
						ActionLabel.text = ActionButtonDesc[activeButton].Loc().Replace(" ", "\n");
						if (actionButton == ActionButton.Reset)
						{
							string fullKeyBindString2 = InputController.GetFullKeyBindString(InputController.Keys.ResetGrid, false, true);
							if (fullKeyBindString2 != null)
							{
								TextMesh actionLabel = ActionLabel;
								actionLabel.text = actionLabel.text + "\n(" + fullKeyBindString2 + ")";
							}
						}
						if (actionButton == ActionButton.Angle)
						{
							TextMesh actionLabel2 = ActionLabel;
							actionLabel2.text = actionLabel2.text + "\n" + BuildController.Instance.FurnitureAngle + "°";
						}
						ActionLabel.gameObject.SetActive(true);
						MoveB.gameObject.SetActive(false);
					}
					else
					{
						ActionLabel.gameObject.SetActive(false);
						MoveB.gameObject.SetActive(true);
					}
				}
			}
			else
			{
				_lockPosition = null;
				for (int l = 0; l < ActionButtons.Length; l++)
				{
					ActionButtons[l].sharedMaterial.color = ButtonInactive;
				}
				MoveB.sharedMaterial.color = ButtonInactive;
				MoveB.sharedMaterial.mainTexture = NoMoveTex;
				MoveB.gameObject.SetActive(true);
				ActionLabel.gameObject.SetActive(false);
			}
		}
		else
		{
			_lockPosition = null;
			InnerRing.sharedMaterial.mainTexture = RingNoButtons;
			for (int m = 0; m < ActionButtons.Length; m++)
			{
				ActionButtons[m].gameObject.SetActive(false);
			}
			MoveB.sharedMaterial.color = ButtonInactive;
			MoveB.sharedMaterial.mainTexture = NoMoveTex;
			MoveB.gameObject.SetActive(true);
			ActionLabel.gameObject.SetActive(false);
		}
		ActionButtons[0].sharedMaterial.mainTexture = AngleSnapTex[BuildController.Instance.AngleNum];
		InnerRing.transform.localRotation = Quaternion.Euler(0f, CameraScript.Instance.transform.rotation.eulerAngles.y, 0f);
	}
}
