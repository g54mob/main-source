using UnityEngine;

public class MoneyTree : MonoBehaviour
{
	public Renderer MoneyRend;

	public Furniture Furn;

	public float Speed = 1f;

	public float Worth = 100f;

	public float Notes = 10f;

	private float _prog;

	private bool _canHarvest;

	private MaterialPropertyBlock _matBlock;

	private int _lastTick = -1;

	private void Start()
	{
		_matBlock = new MaterialPropertyBlock();
		RefreshMat();
	}

	private void RefreshMat()
	{
		_matBlock.SetFloat("_CutOff", _prog);
		MoneyRend.SetPropertyBlock(_matBlock);
	}

	private void FixedUpdate()
	{
		if (_lastTick < 0)
		{
			_lastTick = SDateTime.Now().ToInt();
		}
		if (_prog < 1f)
		{
			int num = SDateTime.Now().ToInt();
			float num2 = (float)(num - _lastTick) / 60f / 24f / (float)GameSettings.DaysPerMonth;
			_prog = Mathf.Min(_prog + num2 * Speed, 1f);
			_lastTick = num;
		}
		if (Furn.IsSelected)
		{
			if (_canHarvest)
			{
				float num3 = (float)Mathf.FloorToInt(_prog * Notes) / Notes * Worth;
				if (num3 > 0f)
				{
					GameSettings.Instance.OffshoreAccount += num3;
					UISoundFX.PlaySFX("Kaching");
					CostDisplay.Instance.Show(num3, base.transform.position + Vector3.up * 2f);
					CostDisplay.Instance.FloatAway();
					_prog = 0f;
				}
			}
			_canHarvest = false;
		}
		else
		{
			_canHarvest = true;
		}
		RefreshMat();
	}
}
