using UnityEngine;

public class GrowingRingSprite : AsciiSprite
{
	public float animatorSpeed = 1f;

	public float radius = 5f;

	public float thickness = 2f;

	public float centerX;

	public float centerY;

	public float scaleY = 0.58f;

	private bool skipDraw;

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (!base.gameObject.activeInHierarchy || skipDraw)
		{
			return;
		}
		offsetX -= pivotX;
		offsetY -= pivotY;
		if ((double)radius < 0.25)
		{
			return;
		}
		float num = radius - thickness;
		float num2 = (float)offsetX + centerX;
		float num3 = (float)offsetY + centerY;
		Color white = Color.white;
		int num4 = Mathf.Max(0, Mathf.FloorToInt(num2 - radius));
		int num5 = Mathf.Min(r.width - 1, Mathf.CeilToInt(num2 + radius));
		int num6 = Mathf.Max(0, Mathf.FloorToInt(num3 - radius));
		int num7 = Mathf.Min(r.height - 1, Mathf.CeilToInt(num3 + radius));
		for (int i = num4; i <= num5; i++)
		{
			float num8 = i;
			float num9 = num2 - num8;
			float num10 = num9 * num9;
			for (int j = num6; j <= num7; j++)
			{
				AsciiCellProcedural cell = r.GetCell(i, j);
				if (cell == null)
				{
					continue;
				}
				float num11 = j;
				float num12 = (num3 - num11) / scaleY;
				float num13 = Mathf.Sqrt(num10 + num12 * num12);
				float num14 = num13 - radius;
				if (num14 < 0f)
				{
					num14 = num13 - num - 1f;
					if (num14 >= 0f)
					{
						cell.SetValue(SpecialSymbols.Map('█'));
						cell.SetForeground(white);
					}
					else if (num14 >= -0.25f)
					{
						cell.SetValue(SpecialSymbols.Map('▓'));
						cell.SetForeground(white);
					}
					else if (num14 >= -0.5f)
					{
						cell.SetValue(SpecialSymbols.Map('▒'));
						cell.SetForeground(white);
					}
					else if (num14 >= -0.75f)
					{
						cell.SetValue(SpecialSymbols.Map('░'));
						cell.SetForeground(white);
					}
				}
				else if (num14 < 0.25f)
				{
					cell.SetValue(SpecialSymbols.Map('▓'));
					cell.SetForeground(white);
				}
				else if (num14 < 0.5f)
				{
					cell.SetValue(SpecialSymbols.Map('▒'));
					cell.SetForeground(white);
				}
				else if (num14 < 0.75f)
				{
					cell.SetValue(SpecialSymbols.Map('░'));
					cell.SetForeground(white);
				}
			}
		}
	}

	private void Update()
	{
		skipDraw = false;
	}

	private void OnEnable()
	{
		skipDraw = true;
	}

	private void Start()
	{
		Animator component = GetComponent<Animator>();
		if (component != null)
		{
			component.speed = animatorSpeed;
		}
	}
}
