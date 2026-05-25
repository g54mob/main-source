using DG.Tweening;
using UnityEngine;

public class FlyingMinion : MonoBehaviour
{
	public LocalSfx2Controller LocalSfx2Controller;

	public static int FlyingSpeed;

	private void Start()
	{
	}

	public static float GetDeltaSpeed()
	{
		if (FlyingSpeed == 0)
		{
			return 9999f;
		}
		if (FlyingSpeed == 1)
		{
			return 10f;
		}
		if (FlyingSpeed == 2)
		{
			return 8f;
		}
		if (FlyingSpeed == 3)
		{
			return 6f;
		}
		if (FlyingSpeed == 4)
		{
			return 4f;
		}
		_ = FlyingSpeed;
		_ = 5;
		return 2f;
	}

	public void Setup(float dropX)
	{
		base.transform.position = new Vector3(dropX - 7f, 17f, 0f);
		Vector3 position = base.transform.position;
		Sequence sequence = DOTween.Sequence();
		sequence.Append(base.transform.DOMoveY(position.y - 14f, 1f).SetEase(Ease.InOutCubic).OnComplete(DropGarbage));
		sequence.Append(base.transform.DOMoveY(position.y, 1f).SetEase(Ease.InOutCubic));
		Tween t = base.transform.DOMoveX(position.x + 14f, 2f).SetEase(Ease.Linear);
		Sequence sequence2 = DOTween.Sequence();
		sequence2.Join(sequence);
		sequence2.Join(t);
		sequence2.OnComplete(MovementComplete);
	}

	private void DropGarbage()
	{
		float num = Random.Range(0f, 1f);
		LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.ga_minion, base.transform.position.x);
		if ((double)num >= 0.9)
		{
			GameController.Instance.GarbageController.Generate(base.transform.position, 0, GarbageInfo.GarbageTypeEnum.GarbageL, GarbageInfo.CameFromEnum.None, isEvil: true);
		}
		else if ((double)num >= 0.65)
		{
			GameController.Instance.GarbageController.Generate(base.transform.position, 0, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.None, isEvil: true);
		}
		else
		{
			GameController.Instance.GarbageController.Generate(base.transform.position, 0, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.None, isEvil: true);
		}
	}

	private void MovementComplete()
	{
		base.gameObject.SetActive(value: false);
		Object.Destroy(this, 1f);
	}
}
