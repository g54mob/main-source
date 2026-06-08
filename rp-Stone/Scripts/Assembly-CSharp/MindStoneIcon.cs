using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public class MindStoneIcon : MonoBehaviour
{
	public AsciiSprite runLoopSprite;

	private AsciiSprite mySprite;

	private void HandleDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (MindStoneController.singleton.enabled)
		{
			runLoopSprite.Draw(r, offsetX, offsetY);
		}
	}

	private void Start()
	{
		mySprite = GetComponent<AsciiSprite>();
		mySprite.OnDraw += HandleDraw;
		runLoopSprite.Load();
	}

	private void OnDestroy()
	{
		if (mySprite != null)
		{
			mySprite.OnDraw -= HandleDraw;
		}
	}
}
