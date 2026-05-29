using DG.Tweening;
using UnityEngine;

public class BuildingProgressBar : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer bar;

	[SerializeField]
	private SpriteRenderer background;

	private Vector3 initialBarPos;

	private float rechargeBarSize = 1f;

	private float rechargeBarHeight = 0.125f;

	private void Start()
	{
		if ((bool)bar)
		{
			initialBarPos = bar.transform.localPosition;
		}
		ResetBuildBar();
	}

	public void BuildFor(int timeInSeconds)
	{
		DOVirtual.Float(0f, rechargeBarSize, (float)timeInSeconds - 0.1f, UpdateBar);
		if ((bool)background)
		{
			background.enabled = true;
		}
	}

	private void UpdateBar(float newSize)
	{
		if ((bool)bar)
		{
			bar.size = new Vector2(newSize, rechargeBarHeight);
		}
		if ((bool)bar)
		{
			bar.transform.localPosition = new Vector3(initialBarPos.x - rechargeBarSize * 0.5f + newSize * 0.5f, initialBarPos.y, 0f);
		}
	}

	public void ResetBuildBar()
	{
		if ((bool)bar)
		{
			bar.size = new Vector2(0f, rechargeBarHeight);
		}
		if ((bool)bar)
		{
			bar.transform.localPosition = new Vector3(initialBarPos.x - rechargeBarSize * 0.5f, initialBarPos.y, 0f);
		}
		if ((bool)background)
		{
			background.enabled = false;
		}
	}
}
