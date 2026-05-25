using DG.Tweening;
using UnityEngine;

public class Cloud : MonoBehaviour
{
	public enum CloudTypeEnum
	{
		V1 = 0,
		V2 = 1,
		V3 = 2,
		V4 = 3,
		V5 = 4,
		V6 = 5
	}

	public LocalSfx2Controller LocalSfx2Controller;

	public CloudTypeEnum CloudType;

	private bool _isAlive = true;

	private Tween _currentTween;

	private int _clickCount;

	private float _randomHeight;

	private float _randomSpeedDelta;

	private bool _isClicking;

	private float _autoClickTimer = 0.2f;

	private const float DELAY_BETWEEN_CLICK = 0.2f;

	public bool IsAlive => _isAlive;

	public float RandomHeight => _randomHeight;

	public float RandomSpeedDelta => _randomSpeedDelta;

	public static bool CanLevelUp(CloudTypeEnum cloudType)
	{
		if (cloudType == CloudTypeEnum.V6)
		{
			return false;
		}
		return true;
	}

	public static CloudTypeEnum NextLevel(CloudTypeEnum cloudType)
	{
		return cloudType switch
		{
			CloudTypeEnum.V1 => CloudTypeEnum.V2, 
			CloudTypeEnum.V2 => CloudTypeEnum.V3, 
			CloudTypeEnum.V3 => CloudTypeEnum.V4, 
			CloudTypeEnum.V4 => CloudTypeEnum.V5, 
			CloudTypeEnum.V5 => CloudTypeEnum.V6, 
			_ => cloudType, 
		};
	}

	private void Start()
	{
		_randomHeight = Random.Range(-0.5f, 0.5f);
		_randomSpeedDelta += Random.Range(-0.1f, 0.1f);
	}

	private void Update()
	{
		if (_isClicking)
		{
			_autoClickTimer -= Time.deltaTime;
		}
		if (_autoClickTimer <= 0f)
		{
			_autoClickTimer = 0.2f;
			int num = 1;
			GlobalSfx2Controller.Instance.PlayOneWithPitch(SoundManager.SoundTypeEnum.ga_cloud_click);
			if (Drone.GlobalInfo.CanClickPowerIncreaseAttribute.IsEnabled)
			{
				num += 2 * Drone.GlobalInfo.CanClickPowerIncreaseAttribute.Level;
			}
			if (HandleClick(num, 0))
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ga_cloud_destroy);
				GameController.TotalCloudClickDestroyed++;
			}
			GameController.TotalCloudClick++;
		}
	}

	public void HandleParticles(int amount, int extraOutput)
	{
		if (HandleClick(amount, extraOutput))
		{
			GlobalSfx2Controller.Instance.PlayFromDistance(SoundManager.SoundTypeEnum.ga_cloud_destroy, base.transform.position.x);
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent)
		{
			_isClicking = true;
			_autoClickTimer = 0f;
		}
	}

	private void OnMouseUp()
	{
		_isClicking = false;
	}

	private bool HandleClick(int clickForce, int extraOutput)
	{
		int num = 1;
		bool result = false;
		if (CloudType == CloudTypeEnum.V1)
		{
			num = 1;
		}
		else if (CloudType == CloudTypeEnum.V2)
		{
			num = 2;
		}
		else if (CloudType == CloudTypeEnum.V3)
		{
			num = 3;
		}
		else if (CloudType == CloudTypeEnum.V4)
		{
			num = 4;
		}
		else if (CloudType == CloudTypeEnum.V5)
		{
			num = 5;
		}
		else if (CloudType == CloudTypeEnum.V6)
		{
			num = 6;
		}
		_currentTween?.Kill();
		float duration = 0.1f;
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		_currentTween = base.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), duration).OnComplete(delegate
		{
			base.transform.DOScale(Vector3.one, duration);
		});
		_clickCount += clickForce;
		if (_clickCount > GetClickNeeded())
		{
			clickForce -= _clickCount - GetClickNeeded();
		}
		int num2 = 0;
		for (int num3 = 0; num3 < clickForce; num3++)
		{
			num2 += 1 + Drone.GlobalInfo.CanCloudOutputMoreAttribute.Level;
		}
		if (_clickCount >= GetClickNeeded())
		{
			num2 += GetAmountGenerated() + extraOutput + Drone.GlobalInfo.CanCloudOutputMoreAttribute.Level;
			_isAlive = false;
			result = true;
			GameController.TotalCloudDestroyed++;
			if (Drone.GlobalInfo.CanCloudMakeRPAttribute.IsEnabled)
			{
				if (CloudType == CloudTypeEnum.V1)
				{
					GameController.Instance.GainRP(Drone.GlobalInfo.CanCloudMakeRPAttribute.Level);
				}
				else if (CloudType == CloudTypeEnum.V2)
				{
					GameController.Instance.GainRP(Drone.GlobalInfo.CanCloudMakeRPAttribute.Level * 3);
				}
				else if (CloudType == CloudTypeEnum.V3)
				{
					GameController.Instance.GainRP(Drone.GlobalInfo.CanCloudMakeRPAttribute.Level * 9);
				}
				else if (CloudType == CloudTypeEnum.V4)
				{
					GameController.Instance.GainRP(Drone.GlobalInfo.CanCloudMakeRPAttribute.Level * 27);
				}
				else if (CloudType == CloudTypeEnum.V5)
				{
					GameController.Instance.GainRP(Drone.GlobalInfo.CanCloudMakeRPAttribute.Level * 81);
				}
				else if (CloudType == CloudTypeEnum.V6)
				{
					GameController.Instance.GainRP(Drone.GlobalInfo.CanCloudMakeRPAttribute.Level * 243);
				}
			}
		}
		if (Drone.GlobalInfo.CanCloudOutputBiggerAttribute.IsEnabled)
		{
			int num4 = num2 / 4;
			num2 %= 4;
			for (int num5 = 0; num5 < num4; num5++)
			{
				Vector3 vector = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
				GameController.Instance.GarbageController.Generate(base.transform.position + vector, num * 4, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.Cloud, isEvil: false).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), Random.Range(0, 3)), ForceMode2D.Impulse);
			}
		}
		for (int num6 = 0; num6 < num2; num6++)
		{
			Vector3 vector2 = new Vector3(Random.Range(-0.1f, 0.1f), 0f, 0f);
			GameController.Instance.GarbageController.Generate(base.transform.position + vector2, num, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Cloud, isEvil: false).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), Random.Range(0, 3)), ForceMode2D.Impulse);
		}
		return result;
	}

	private int GetClickNeeded()
	{
		return 15;
	}

	private int GetAmountGenerated()
	{
		return 5;
	}
}
