using TMPro;
using UnityEngine;

public class TurnableTextRenderer : TurnableRenderer
{
	public bool disableTextRotation;

	public bool flipVerticallyWhenRotated;

	private TextMeshPro textRenderer;

	public override bool enabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override int sortingLayerID
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override string sortingLayerName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override int sortingOrder
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override SpriteMaskInteraction maskInteraction
	{
		get
		{
			return default(SpriteMaskInteraction);
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void Init()
	{
	}

	public override void SetRotation(int rotationI)
	{
	}

	public void Refresh()
	{
	}

	private void LateUpdate()
	{
	}

	public void SetColor(int colorI)
	{
	}
}
