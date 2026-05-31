using UnityEngine;

public class Temple_Entity : MonoBehaviour
{
	public LocalSfx2Controller LocalSfx2Controller;

	public SpriteRenderer Center;

	private float _timeUntilFire;

	private float _timeRp;

	private int _force;

	private void Start()
	{
		_timeUntilFire = 0f;
		_timeRp = 0f;
	}

	private void Update()
	{
		_timeUntilFire += Time.deltaTime;
		_timeRp += Time.deltaTime;
		if (_timeRp >= 5f)
		{
			_timeRp = 0f;
			if (Temple.GlobalInfo.CanMoreRPAttribute.IsEnabled)
			{
				GameController.Instance.GainRP(2);
			}
		}
		if (_timeUntilFire >= 0.5f && !GameController.Instance.IsHoleFilled())
		{
			_timeUntilFire = 0f;
			for (int i = 0; i < _force; i++)
			{
				if (Random.Range(1, 10) == 5)
				{
					Garbage garbage = ((!Temple.GlobalInfo.CanBiggerOutputAttribute.IsEnabled) ? GameController.Instance.GarbageController.Generate(base.transform.position, 10, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.Temple, isEvil: true) : GameController.Instance.GarbageController.Generate(base.transform.position, 10, GarbageInfo.GarbageTypeEnum.GarbageL, GarbageInfo.CameFromEnum.Temple, isEvil: true));
					garbage.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
				}
				else
				{
					Garbage garbage2 = ((!Temple.GlobalInfo.CanBiggerOutputAttribute.IsEnabled) ? GameController.Instance.GarbageController.Generate(base.transform.position, 1, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Temple, isEvil: true) : GameController.Instance.GarbageController.Generate(base.transform.position, 1, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.Temple, isEvil: true));
					garbage2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
				}
			}
		}
		base.transform.Rotate(0f, 0f, 30f * Time.deltaTime);
	}

	public void SetForce(int force)
	{
		if (_force == 0 && force > 0)
		{
			LocalSfx2Controller.PlayLoopFromDistance(SoundManager.SoundTypeEnum.bs_portal, base.transform.position.x);
		}
		if (_force > 0 && force == 0)
		{
			LocalSfx2Controller.StopLoop();
		}
		_force = force;
	}
}
