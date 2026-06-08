using UnityEngine;

public class TableIcon : Icon
{
	protected override void Awake()
	{
		iconBackground = base.transform.parent.Find("Selected Name").gameObject;
		audioPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		tableManager = canvas.GetComponent<PanelManager>();
		animator = base.transform.parent.GetComponent<Animator>();
		notificationIcon = base.transform.GetChild(0).gameObject;
		notificationIcon.SetActive(value: false);
		clickDrag = GetComponentInParent<ClickDrag>();
		taskbarManager = base.transform.parent.GetComponentInParent<TaskbarManager>();
	}

	public override void PlayAnimation()
	{
		if (!Save.IsIconClicked(tableName))
		{
			notificationIcon.SetActive(value: true);
			animator.Play("Icon Web Browser Wiggle");
		}
	}
}
