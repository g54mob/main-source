using OUSystems.Basics.UI;
using UnityEngine;

public class UpgradeCustomCursorProvider : HoverListener
{
	public UpgradeDef UpgradeDef;

	[SerializeField]
	private DefaultCustomCursor _cursor;

	private CustomCursor _appliedCursor;

	private bool UpgradeUnlocked;

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnUpgradeUnlocked(int level)
	{
	}

	public override void OnEnable()
	{
	}

	public override void OnDisable()
	{
	}

	public override void OnHover()
	{
	}

	public override void OnHoverEnd()
	{
	}
}
