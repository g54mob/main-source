using UnityEngine;

public class Airplane : MonoBehaviour
{
	public LocalSfx2Controller LocalSfx2Controller;

	private float _dumpTimer;

	private float _dumpDelay = 0.4f;

	private bool _smallGarbage = true;

	private bool _mediumGarbage;

	private bool _largeGarbage;

	public const int SMALL_VALUE = 5;

	public const int MEDIUM_VALUE = 35;

	public const int LARGE_VALUE = 245;

	private void Start()
	{
		LocalSfx2Controller.PlayLoopFromDistance(SoundManager.SoundTypeEnum.ga_airplane, base.transform.position.x);
	}

	private void FixedUpdate()
	{
		base.transform.position += new Vector3(5f * Time.fixedDeltaTime, 0f, 0f);
		LocalSfx2Controller.ChangeLoopDistance(base.transform.position.x);
		_dumpTimer += Time.fixedDeltaTime;
		if (_dumpTimer >= _dumpDelay)
		{
			_dumpTimer -= _dumpDelay;
			if (_largeGarbage)
			{
				GameController.Instance.GarbageController.Generate(base.transform.position, 245, GarbageInfo.GarbageTypeEnum.GarbageL, GarbageInfo.CameFromEnum.None, isEvil: false);
			}
			else if (_mediumGarbage)
			{
				GameController.Instance.GarbageController.Generate(base.transform.position, 35, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.None, isEvil: false);
			}
			else if (_smallGarbage)
			{
				GameController.Instance.GarbageController.Generate(base.transform.position, 5, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.None, isEvil: false);
			}
		}
		if (base.transform.position.x >= 19f)
		{
			base.gameObject.SetActive(value: false);
			Object.Destroy(this, 1f);
		}
	}

	public void DropSmallGarbage(bool smallGarbage, bool mediumGarbage, bool largeGarbage)
	{
		_smallGarbage = smallGarbage;
		_mediumGarbage = mediumGarbage;
		_largeGarbage = largeGarbage;
	}
}
