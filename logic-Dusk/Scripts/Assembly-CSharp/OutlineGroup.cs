using UnityEngine;

public class OutlineGroup
{
	private GameObject parentObject;

	private IObjectState objectState;

	private LineRenderer topLine;

	private LineRenderer bottomLine;

	private LineRenderer leftLine;

	private LineRenderer rightLine;

	private Renderer topLineRenderer;

	private Renderer bottomLineRenderer;

	private Renderer leftLineRenderer;

	private Renderer rightLineRenderer;

	private ColorBlinkManager blinkManager;

	private Color colorBeforeBlinking = Color.white;

	public RoomFlagsEnum IsState { get; set; }

	public RoomFlagsEnum IsNotState { get; set; }

	public float ScaleAdjustment { get; set; }

	public float LineWidth { get; set; }

	public float LineCapSize { get; set; }

	public float Alpha { get; set; }

	public bool EnableDynamicScaling { get; set; }

	public bool IsDotted { get; set; }

	public bool IsBlinking { get; set; }

	public Color LineColor { get; set; }

	public string ChildNameQualifier { get; set; }

	public float InflateAmount { get; set; }

	private OutlineGroup()
	{
	}

	public OutlineGroup(GameObject room)
		: this(room, string.Empty)
	{
	}

	public OutlineGroup(GameObject room, string childNameQualifier)
		: this(room, null, childNameQualifier)
	{
	}

	public OutlineGroup(GameObject room, IObjectState objectState)
		: this(room, objectState, string.Empty)
	{
	}

	public OutlineGroup(GameObject room, IObjectState objectState, string childNameQualifier)
	{
		parentObject = room;
		ChildNameQualifier = childNameQualifier;
		IsNotState = RoomFlagsEnum.Disabled;
		LineColor = Color.white;
		LineWidth = 0.1f;
		LineCapSize = 0.01f;
		Alpha = 1f;
		if (objectState == null)
		{
			this.objectState = (IObjectState)parentObject.GetComponent(typeof(IObjectState));
		}
		else
		{
			this.objectState = objectState;
		}
		AddLines();
		RefreshLines();
		HideLines();
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			ShowLines();
		}
	}

	public void Update()
	{
		if (IsBlinking)
		{
			Color lineColor = blinkManager.Update(Time.deltaTime);
			if (blinkManager.IsActive)
			{
				LineColor = lineColor;
			}
			else
			{
				IsBlinking = false;
				SetColor(colorBeforeBlinking);
			}
			RefreshLines();
		}
	}

	public void RefreshLines()
	{
		Vector3 zero = Vector3.zero;
		Vector3 zero2 = Vector3.zero;
		float z = -5f;
		Vector3 localScale = parentObject.transform.localScale;
		if (ScaleAdjustment != 0f)
		{
			float num = localScale.x;
			float num2 = localScale.y;
			float num3 = ScaleAdjustment - 1f;
			float num4 = ScaleAdjustment - 1f;
			if (EnableDynamicScaling)
			{
				if (num4 != 0f)
				{
					num *= 1f + num4 * (8f / parentObject.transform.localScale.x);
				}
				if (num3 != 0f)
				{
					num2 *= 1f + num3 * (8f / parentObject.transform.localScale.y);
				}
			}
			else
			{
				num *= ScaleAdjustment;
				num2 *= ScaleAdjustment;
			}
			localScale.x = num;
			localScale.y = num2;
		}
		if (parentObject.transform.rotation.w != 1f)
		{
			float y = localScale.y;
			localScale.y = localScale.x;
			localScale.x = y;
		}
		if (topLine != null)
		{
			zero = parentObject.transform.position;
			zero2 = parentObject.transform.position;
			zero.x -= localScale.x / 2f + InflateAmount + LineCapSize;
			zero.y += localScale.y / 2f + InflateAmount;
			zero.z = z;
			zero2.x += localScale.x / 2f + InflateAmount + LineCapSize;
			zero2.y += localScale.y / 2f + InflateAmount;
			zero2.z = z;
			topLine.SetPosition(0, zero);
			topLine.SetPosition(1, zero2);
			Color lineColor = LineColor;
			lineColor.a = Alpha;
			topLine.SetColors(lineColor, lineColor);
			topLine.SetWidth(LineWidth, LineWidth);
			if (IsDotted)
			{
				float num5 = Mathf.Abs(zero.x - zero2.x);
				float num6 = 10f;
				if (num5 > 0f)
				{
					num6 = num5 / num6;
				}
				topLineRenderer.material.mainTextureScale = new Vector2(num6, 1f);
			}
		}
		if (bottomLine != null)
		{
			zero = parentObject.transform.position;
			zero2 = parentObject.transform.position;
			zero.x -= localScale.x / 2f + InflateAmount + LineCapSize;
			zero.y -= localScale.y / 2f + InflateAmount;
			zero.z = z;
			zero2.x += localScale.x / 2f + InflateAmount + LineCapSize;
			zero2.y -= localScale.y / 2f + InflateAmount;
			zero2.z = z;
			bottomLine.SetPosition(0, zero);
			bottomLine.SetPosition(1, zero2);
			Color lineColor2 = LineColor;
			lineColor2.a = Alpha;
			bottomLine.SetColors(lineColor2, lineColor2);
			bottomLine.SetWidth(LineWidth, LineWidth);
			if (IsDotted)
			{
				float num7 = Mathf.Abs(zero.x - zero2.x);
				float num8 = 10f;
				if (num7 > 0f)
				{
					num8 = num7 / num8;
				}
				bottomLineRenderer.material.mainTextureScale = new Vector2(num8, 1f);
			}
		}
		if (leftLine != null)
		{
			zero = parentObject.transform.position;
			zero2 = parentObject.transform.position;
			zero.x -= localScale.x / 2f + InflateAmount;
			zero.y += localScale.y / 2f + InflateAmount + LineCapSize;
			zero.z = z;
			zero2.x -= localScale.x / 2f + InflateAmount;
			zero2.y -= localScale.y / 2f + InflateAmount + LineCapSize;
			zero2.z = z;
			leftLine.SetPosition(0, zero);
			leftLine.SetPosition(1, zero2);
			Color lineColor3 = LineColor;
			lineColor3.a = Alpha;
			leftLine.SetColors(lineColor3, lineColor3);
			leftLine.SetWidth(LineWidth, LineWidth);
			if (IsDotted)
			{
				float num9 = Mathf.Abs(zero.y - zero2.y);
				float num10 = 10f;
				if (num9 > 0f)
				{
					num10 = num9 / num10;
				}
				leftLineRenderer.material.mainTextureScale = new Vector2(num10, 1f);
			}
		}
		if (!(rightLine != null))
		{
			return;
		}
		zero = parentObject.transform.position;
		zero2 = parentObject.transform.position;
		zero.x += localScale.x / 2f + InflateAmount;
		zero.y += localScale.y / 2f + InflateAmount + LineCapSize;
		zero.z = z;
		zero2.x += localScale.x / 2f + InflateAmount;
		zero2.y -= localScale.y / 2f + InflateAmount + LineCapSize;
		zero2.z = z;
		rightLine.SetPosition(0, zero);
		rightLine.SetPosition(1, zero2);
		Color lineColor4 = LineColor;
		lineColor4.a = Alpha;
		rightLine.SetColors(lineColor4, lineColor4);
		rightLine.SetWidth(LineWidth, LineWidth);
		if (IsDotted)
		{
			float num11 = Mathf.Abs(zero.y - zero2.y);
			float num12 = 10f;
			if (num11 > 0f)
			{
				num12 = num11 / num12;
			}
			rightLineRenderer.material.mainTextureScale = new Vector2(num12, 1f);
		}
	}

	public void HideLines()
	{
		if ((bool)topLine)
		{
			topLine.enabled = false;
		}
		if ((bool)bottomLine)
		{
			bottomLine.enabled = false;
		}
		if ((bool)leftLine)
		{
			leftLine.enabled = false;
		}
		if ((bool)rightLine)
		{
			rightLine.enabled = false;
		}
	}

	public void ShowLines()
	{
		bool flag = (IsState & RoomFlagsEnum.Any) == RoomFlagsEnum.Any;
		bool flag2 = (IsState & RoomFlagsEnum.Explored) == RoomFlagsEnum.Explored;
		bool flag3 = false;
		bool flag4 = false;
		if ((IsState & RoomFlagsEnum.Any) == RoomFlagsEnum.Any)
		{
			flag3 = true;
		}
		if (!flag3 && objectState.isExplored && (IsState & RoomFlagsEnum.Explored) == RoomFlagsEnum.Explored)
		{
			flag3 = true;
		}
		if (!flag3 && objectState.isScanned && (IsState & RoomFlagsEnum.Scanned) == RoomFlagsEnum.Scanned)
		{
			flag3 = true;
		}
		if (!flag3 && objectState.isPowered && (IsState & RoomFlagsEnum.Powered) == RoomFlagsEnum.Powered)
		{
			flag3 = true;
		}
		if (!flag3 && objectState.onSchematic && (IsState & RoomFlagsEnum.OnSchematic) == RoomFlagsEnum.OnSchematic)
		{
			flag3 = true;
		}
		if ((IsNotState & RoomFlagsEnum.Disabled) != RoomFlagsEnum.Disabled)
		{
			if ((IsNotState & RoomFlagsEnum.Any) == RoomFlagsEnum.Any)
			{
				flag4 = true;
			}
			if (!flag4 && objectState.isExplored && (IsNotState & RoomFlagsEnum.Explored) == RoomFlagsEnum.Explored)
			{
				flag4 = true;
			}
			if (!flag4 && objectState.isScanned && (IsNotState & RoomFlagsEnum.Scanned) == RoomFlagsEnum.Scanned)
			{
				flag4 = true;
			}
			if (!flag4 && objectState.isPowered && (IsNotState & RoomFlagsEnum.Powered) == RoomFlagsEnum.Powered)
			{
				flag4 = true;
			}
			if (!flag4 && objectState.onSchematic && (IsNotState & RoomFlagsEnum.OnSchematic) == RoomFlagsEnum.OnSchematic)
			{
				flag4 = true;
			}
		}
		if (flag3 && !flag4)
		{
			if ((bool)topLine)
			{
				topLine.enabled = true;
			}
			if ((bool)bottomLine)
			{
				bottomLine.enabled = true;
			}
			if ((bool)leftLine)
			{
				leftLine.enabled = true;
			}
			if ((bool)rightLine)
			{
				rightLine.enabled = true;
			}
		}
	}

	public void SetColor(Color newColor)
	{
		LineColor = newColor;
		RefreshLines();
		if (IsBlinking)
		{
			blinkManager.startColor = newColor;
			colorBeforeBlinking = newColor;
		}
	}

	public void SetAlpha(float newAlpha)
	{
		Alpha = newAlpha;
		RefreshLines();
	}

	public void StartBlink(float cycleTime, int numberOfCycles)
	{
		if (blinkManager == null)
		{
			blinkManager = new ColorBlinkManager();
		}
		colorBeforeBlinking = LineColor;
		blinkManager.Start(LineColor, Color.black, cycleTime, numberOfCycles);
		IsBlinking = true;
	}

	public void StopBlink()
	{
		IsBlinking = false;
		blinkManager = null;
		SetColor(colorBeforeBlinking);
	}

	private void AddLines()
	{
		Transform transform = parentObject.transform;
		if (!string.IsNullOrEmpty(ChildNameQualifier))
		{
			transform = parentObject.transform.FindChild(ChildNameQualifier);
		}
		Transform transform2 = transform.FindChild("TopLine");
		if ((bool)transform2)
		{
			topLine = transform2.gameObject.GetComponent<LineRenderer>();
			topLineRenderer = topLine.GetComponent<Renderer>();
		}
		transform2 = transform.FindChild("BottomLine");
		if ((bool)transform2)
		{
			bottomLine = transform2.gameObject.GetComponent<LineRenderer>();
			bottomLineRenderer = bottomLine.GetComponent<Renderer>();
		}
		transform2 = transform.FindChild("LeftLine");
		if ((bool)transform2)
		{
			leftLine = transform2.gameObject.GetComponent<LineRenderer>();
			leftLineRenderer = leftLine.GetComponent<Renderer>();
		}
		transform2 = transform.FindChild("RightLine");
		if ((bool)transform2)
		{
			rightLine = transform2.gameObject.GetComponent<LineRenderer>();
			rightLineRenderer = rightLine.GetComponent<Renderer>();
		}
	}
}
