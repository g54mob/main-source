using UnityEngine;

public class ShopOutdoorSign : MonoBehaviour
{
	public AsciiString label;

	public AsciiSprite leftSignSprite;

	public AsciiSprite rightSignSprite;

	public AsciiSprite postSprite;

	private void HandleDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		label.Draw(r, offsetX, offsetY);
	}

	private void Start()
	{
		string text = Te.xt("tid_mushroom_7");
		label.SetValue(text);
		if (text.Length > 13)
		{
			int num = Mathf.CeilToInt((float)(text.Length - 13) / 2f);
			leftSignSprite.pivotX += num;
			rightSignSprite.pivotX -= num;
		}
		else if (text.Length < 9)
		{
			int num2 = Mathf.CeilToInt((float)(9 - text.Length) / 2f);
			leftSignSprite.pivotX -= num2;
			rightSignSprite.pivotX += num2;
		}
	}

	private void OnDestroy()
	{
		postSprite.OnDraw -= HandleDraw;
	}

	private void Awake()
	{
		postSprite.OnDraw += HandleDraw;
	}
}
