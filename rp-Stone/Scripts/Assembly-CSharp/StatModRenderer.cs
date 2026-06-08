using UnityEngine;

public class StatModRenderer : MonoBehaviour
{
	private AsciiSprite mySprite;

	private void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
		if (mySprite != null)
		{
			mySprite.Load();
		}
	}

	public virtual void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, Character character)
	{
		if (mySprite != null)
		{
			offsetX += character.HeadPivotX;
			offsetY += character.HeadPivotY;
			mySprite.Draw(r, offsetX, offsetY);
		}
	}
}
