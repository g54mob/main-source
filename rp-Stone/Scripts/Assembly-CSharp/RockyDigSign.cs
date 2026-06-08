using UnityEngine;

public class RockyDigSign : MonoBehaviour
{
	public AsciiString label;

	private AsciiSprite mySprite;

	private void HandleDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (GameStates.Singleton.level.gameTime > 870 && Mathf.Repeat(Time.realtimeSinceStartup, 1f) < 0.5f && (GameStates.Singleton.hero.RightHand == null || !GameStates.Singleton.hero.RightHand.id.StartsWith("shovel")))
		{
			offsetY -= 3;
			label.Draw(r, offsetX, offsetY);
			AsciiCellProcedural cell = r.GetCell(offsetX, offsetY);
			if (cell != null)
			{
				cell.SetValue(SpecialSymbols.Map('↓'));
				cell.SetForeground(label.color);
			}
		}
	}

	private void OnDestroy()
	{
		mySprite.OnDraw -= HandleDraw;
	}

	private void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
		mySprite.OnDraw += HandleDraw;
	}
}
