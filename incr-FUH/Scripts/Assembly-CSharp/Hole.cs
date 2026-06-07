using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Hole : MonoBehaviour
{
	public List<ParticleSystem> Particles;

	public HoleGarbage HoleGarbageTemplate;

	public GameObject TopSection;

	public GameObject BackgroundImage;

	public GameObject BackgroundImage2;

	public GameObject LeftSection;

	public GameObject RightSection;

	private int _lastExecuted;

	private float _updateDelay;

	public static bool KeepGarbage = true;

	private List<HoleGarbage> _dynamicList = new List<HoleGarbage>();

	private List<HoleGarbage> _staticList = new List<HoleGarbage>();

	private Queue<HoleGarbage> _destroyedList = new Queue<HoleGarbage>();

	private float _backgroundLowY = -18.373f;

	private float _backgroundHighY = -7.18f;

	private float _topForGarbage = -5f;

	private float _bottomForGarbage = -16.94f;

	private float _deltaRangeForDestroy = 3f;

	private float _backgroundOriginalX;

	private float _background2OriginalX;

	private float _topElement = -999f;

	private int _maxElements = 2000;

	public int DeadPeonCount;

	private const int MAX_DYNAMIC = 200;

	private List<float> _removeTime = new List<float> { 0f, 0f, 0f, 0f };

	private void Start()
	{
		_backgroundOriginalX = BackgroundImage.transform.localPosition.x;
		_background2OriginalX = BackgroundImage2.transform.localPosition.x;
		_topElement = -999f;
		UpdateBackgroundY();
	}

	private void Update()
	{
		_updateDelay += Time.deltaTime;
		if (_updateDelay >= 1f)
		{
			_updateDelay = 0f;
			UpdateBackgroundY();
		}
	}

	public Vector3 GetThrowLocation()
	{
		return new Vector3(UnityEngine.Random.Range(LeftSection.transform.position.x, RightSection.transform.position.x), _topForGarbage, 0f);
	}

	public float GetRightDumpPosition()
	{
		return RightSection.transform.position.x;
	}

	public void SetBackgroundParallax(float cameraX)
	{
		cameraX /= 8f;
		float num = cameraX - MathF.Floor(cameraX);
		BackgroundImage.transform.localPosition = new Vector3(_backgroundOriginalX + num, BackgroundImage.transform.localPosition.y, BackgroundImage.transform.localPosition.z);
		cameraX /= 4f;
		num = cameraX - MathF.Floor(cameraX);
		BackgroundImage2.transform.localPosition = new Vector3(_backgroundOriginalX + num, BackgroundImage2.transform.localPosition.y, BackgroundImage2.transform.localPosition.z);
	}

	private void UpdateBackgroundY()
	{
		float holePercentage = GameController.Instance.GetHolePercentage();
		float num = Mathf.Lerp(_backgroundLowY, _backgroundHighY, holePercentage);
		BackgroundImage.transform.DOLocalMoveY(num, 0.5f);
		BackgroundImage2.transform.DOLocalMoveY(num - 1f, 0.5f);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Garbage component = collision.gameObject.GetComponent<Garbage>();
		if (component != null)
		{
			ProcessGarbage(component);
		}
		CharV2 component2 = collision.gameObject.GetComponent<CharV2>();
		if (component2 != null)
		{
			bool flag = true;
			component2.DropGarbage();
			component2.UnreserveGarbage();
			if (component2.IsSuperSad)
			{
				flag = false;
			}
			if (GameController.Instance.PeonController.GetCharacterCount() > SignChar.UpgradeInfo.GetMaxCharacterCount())
			{
				flag = false;
			}
			if (Training.GlobalInfo.CanNoDeathAttribute.IsEnabled)
			{
				flag = true;
			}
			if (flag)
			{
				GameController.Instance.PeonController.ReSpawnCharacter(component2);
			}
			else
			{
				GameController.Instance.GainMoney(10);
				Particles[_lastExecuted].emission.SetBurst(0, new ParticleSystem.Burst(0f, 10));
				Particles[_lastExecuted].Play();
				_lastExecuted++;
				if (_lastExecuted >= Particles.Count)
				{
					_lastExecuted = 0;
				}
				GenerateGarbage(component2);
				GameController.Instance.PeonController.DestroyCharacter(component2);
			}
		}
		Bulldozer component3 = collision.gameObject.GetComponent<Bulldozer>();
		if (component3 != null)
		{
			while (component3.StoredGarbage.Count > 0)
			{
				GarbageInfo g = component3.StoredGarbage.Dequeue();
				ProcessGarbage(g, 0f);
				GameController.Instance.DropGarbage(g);
			}
			GenerateGarbage(component3);
			component3.StopMoving();
		}
	}

	public void ProcessGarbage(Garbage g)
	{
		g.RemoveDrag();
		if (g.Info.IsGarbage)
		{
			ProcessGarbage(g.Info, g.transform.position.x);
			GenerateGarbage(g);
			GameController.Instance.DropGarbage(g.Info);
			GameController.Instance.GarbageController.DestroyGarbage(g);
		}
		else
		{
			ProcessGarbage(g.Info, g.transform.position.x);
			GenerateGarbage(g);
			GameController.Instance.GarbageController.DestroyGarbage(g);
		}
	}

	public void ProcessGarbage(GarbageInfo g, float x)
	{
		if (g.IsGarbage)
		{
			ParticleSystem.EmissionModule emission = Particles[_lastExecuted].emission;
			int num = g.Weight;
			if (num > 5)
			{
				num /= 5;
			}
			emission.SetBurst(0, new ParticleSystem.Burst(0f, num));
			if (x == 0f)
			{
				x = -24.91f;
			}
			Particles[_lastExecuted].transform.position = new Vector3(x, Particles[_lastExecuted].transform.position.y, Particles[_lastExecuted].transform.position.z);
			Particles[_lastExecuted].Play();
			_lastExecuted++;
			if (_lastExecuted >= Particles.Count)
			{
				_lastExecuted = 0;
			}
		}
		else if (g.GarbageType == GarbageInfo.GarbageTypeEnum.ShardBlue)
		{
			GameController.Instance.GainBluePoint(1);
		}
		else if (g.GarbageType == GarbageInfo.GarbageTypeEnum.ShardYellow)
		{
			GameController.Instance.GainYellowPoint(1);
		}
		else if (g.GarbageType == GarbageInfo.GarbageTypeEnum.ShardRed)
		{
			GameController.Instance.GainRedPoint(1);
		}
		else if (g.GarbageType == GarbageInfo.GarbageTypeEnum.Book)
		{
			if (GameController.Instance.Book.TotalAmount == 0)
			{
				GameController.Instance.ToastPanel.AddItem(LanguageText.GetText("GainedBook"));
			}
			GameController.Instance.GainBook(1);
		}
		else if (g.GarbageType == GarbageInfo.GarbageTypeEnum.Golem)
		{
			GameController.Instance.DropGarbage(g);
			GameController.Instance.HoleFilled.AddAmount(GameController.Instance.Golem.GetSize());
		}
	}

	public void DestroyAll()
	{
		foreach (HoleGarbage dynamic in _dynamicList)
		{
			dynamic.gameObject.SetActive(value: false);
			_destroyedList.Enqueue(dynamic);
		}
		foreach (HoleGarbage @static in _staticList)
		{
			@static.gameObject.SetActive(value: false);
			_destroyedList.Enqueue(@static);
		}
		_topElement = -999f;
		_dynamicList.Clear();
		_staticList.Clear();
	}

	public void DestroyGarbage(HoleGarbage g)
	{
		_dynamicList.Remove(g);
		_staticList.Remove(g);
		g.gameObject.SetActive(value: false);
		_destroyedList.Enqueue(g);
	}

	private void GenerateGarbage(Garbage g)
	{
		if (g.Info.IsGarbage)
		{
			if (!g.Info.IsEvil)
			{
				if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageS)
				{
					GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.GarbageS, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
				}
				if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageM)
				{
					GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.GarbageM, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
				}
				if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageL)
				{
					GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.GarbageL, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
				}
				if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageXL)
				{
					GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.GarbageXL, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
				}
			}
			else
			{
				if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageS)
				{
					GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.GarbageSEvil, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
				}
				if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageM)
				{
					GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.GarbageMEvil, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
				}
				if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageL)
				{
					GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.GarbageLEvil, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
				}
				if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageXL)
				{
					GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.GarbageXLEvil, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
				}
			}
		}
		else
		{
			if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.ShardBlue)
			{
				GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.ShardBlue, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
			}
			if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.ShardYellow)
			{
				GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.ShardYellow, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
			}
			if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.ShardRed)
			{
				GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.ShardRed, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
			}
			if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.Book)
			{
				GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.Book, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
			}
			if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.Golem)
			{
				GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.Golem, g.Info.CurColor, g.transform.position, g.transform.rotation, g.GetComponent<Rigidbody2D>().angularVelocity, g.GetComponent<Rigidbody2D>().linearVelocity);
			}
		}
	}

	private void GenerateGarbage(Bulldozer b)
	{
		GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.Peon, Color.white, b.transform.position + new Vector3(0f, 1f, 0f), b.transform.rotation, b.GetComponent<Rigidbody2D>().angularVelocity, b.GetComponent<Rigidbody2D>().linearVelocity);
		GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.Bulldozer, Color.white, b.transform.position, b.transform.rotation, b.GetComponent<Rigidbody2D>().angularVelocity, b.GetComponent<Rigidbody2D>().linearVelocity);
	}

	private void GenerateGarbage(CharV2 c)
	{
		GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum.Peon, Color.white, c.transform.position, c.transform.rotation, c.GetComponent<Rigidbody2D>().angularVelocity, c.GetComponent<Rigidbody2D>().linearVelocity);
		DeadPeonCount++;
		if (DeadPeonCount == 5 && !Installation.IsDemo())
		{
			Vector3 location = GameController.Instance.SpawnLocation.transform.position + new Vector3(-7f, 0f, 0f);
			for (int i = 0; i < 10; i++)
			{
				GameController.Instance.GarbageController.Generate(c.transform.position + new Vector3(0f, 1f, 0f), 20, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.None, isEvil: true).ThrowToLocation(location);
			}
			for (int j = 0; j < 8; j++)
			{
				GameController.Instance.GarbageController.Generate(c.transform.position + new Vector3(0f, 1f, 0f), 75, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.None, isEvil: true).ThrowToLocation(location);
			}
			AchievementDefinition.ProcessSacrifice(GameController.Instance.Achievements);
		}
	}

	private void GenerateGarbage(HoleGarbage.HoleGarbageTypeEnum type, Color color, Vector3 position, Quaternion rotation, float angularVelocity, Vector2 linearVelocity)
	{
		HoleGarbage holeGarbage = null;
		if (_destroyedList.Count > 0)
		{
			holeGarbage = _destroyedList.Dequeue();
		}
		else
		{
			holeGarbage = UnityEngine.Object.Instantiate(HoleGarbageTemplate, base.transform);
			holeGarbage.SetParent(this);
		}
		holeGarbage.Initialize(type, color, position, rotation, angularVelocity, linearVelocity);
		_dynamicList.Add(holeGarbage);
	}

	public void SetAsStatic(HoleGarbage g)
	{
		if (KeepGarbage)
		{
			_dynamicList.Remove(g);
			_staticList.Add(g);
			int num = 0;
			foreach (HoleGarbage @static in _staticList)
			{
				num += @static.GetWidth();
			}
			if (_topElement < g.transform.position.y)
			{
				_topElement = g.transform.position.y;
			}
			if (_dynamicList.Count > 200)
			{
				RemoveSomeDynamicGarbage();
			}
			if (_topElement > _topForGarbage - _deltaRangeForDestroy - 2f || num >= _maxElements)
			{
				RemoveBottomGarbage();
			}
		}
		else
		{
			DestroyGarbage(g);
		}
	}

	private void RemoveSomeDynamicGarbage()
	{
		for (int num = _dynamicList.Count - 200 + 50; num >= 0; num--)
		{
			DestroyGarbage(_dynamicList[num]);
		}
	}

	private void RemoveBottomGarbage()
	{
		_removeTime[3] = _removeTime[2];
		_removeTime[2] = _removeTime[1];
		_removeTime[1] = _removeTime[0];
		_removeTime[0] = Time.time;
		float num = 9999f;
		if (_removeTime[3] != 0f)
		{
			num = _removeTime[0] - _removeTime[3];
		}
		if (num < 5f)
		{
			for (int num2 = _staticList.Count - 1; num2 >= 0; num2--)
			{
				DestroyGarbage(_staticList[num2]);
			}
			for (int num3 = _dynamicList.Count - 1; num3 >= 0; num3--)
			{
				DestroyGarbage(_dynamicList[num3]);
			}
			_topElement = -999f;
			return;
		}
		foreach (HoleGarbage dynamic in _dynamicList)
		{
			dynamic.AddToTimer();
		}
		Vector3 vector = new Vector3(0f, 0f - _deltaRangeForDestroy, 0f);
		_topElement -= _deltaRangeForDestroy;
		for (int num4 = _staticList.Count - 1; num4 >= 0; num4--)
		{
			if (_staticList[num4].transform.position.y < _bottomForGarbage + _deltaRangeForDestroy)
			{
				DestroyGarbage(_staticList[num4]);
			}
			else
			{
				_staticList[num4].transform.position += vector;
			}
		}
	}
}
