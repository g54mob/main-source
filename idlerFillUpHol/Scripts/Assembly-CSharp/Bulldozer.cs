using System.Collections.Generic;
using UnityEngine;

public class Bulldozer : MonoBehaviour
{
	public LocalSfx2Controller LocalSfx2Controller;

	public CharDisplay Peon;

	public DustGenerator Dust;

	public GameObject BoxDetector;

	private Rigidbody2D _rb;

	private float _oldX;

	private float _nextDust;

	private Vector2 _detectorCenter;

	private Vector2 _detectorSize;

	public Queue<GarbageInfo> StoredGarbage = new Queue<GarbageInfo>();

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_rb.mass = 50000f;
		_oldX = -99999f;
	}

	private void Start()
	{
		_detectorCenter = BoxDetector.GetComponent<BoxCollider2D>().offset;
		_detectorSize = BoxDetector.GetComponent<BoxCollider2D>().bounds.size;
		BoxDetector.GetComponent<BoxCollider2D>().enabled = false;
		Peon.ChangeSide(CharDisplay.SideEnum.Right);
		LocalSfx2Controller.PlayLoopFromDistance(SoundManager.SoundTypeEnum.ga_bulldozer, base.transform.position.x);
	}

	private void Update()
	{
		_nextDust += Time.deltaTime;
		float num = 2f;
		if (Industry.GlobalInfo.CanBulldozerCloudAttribute.IsEnabled)
		{
			num = 1f;
		}
		if (_nextDust >= num)
		{
			_nextDust -= num;
			Dust.Generate(generateBig: true);
		}
	}

	private void FixedUpdate()
	{
		float x = 5f;
		float num = 0f;
		if (base.transform.position.x > _oldX)
		{
			_oldX = base.transform.position.x;
		}
		else
		{
			base.transform.position += new Vector3(0f, 0.05f, 0f);
		}
		LocalSfx2Controller.ChangeLoopDistance(base.transform.position.x);
		_rb.linearVelocity = new Vector2(x, _rb.linearVelocity.y + num);
		Garbage.HasBulldozer = true;
		Garbage.BulldozerPosition = base.transform.position.x;
		Collider2D[] array = Physics2D.OverlapBoxAll(_detectorCenter + new Vector2(base.transform.position.x, base.transform.position.y), _detectorSize, 0f);
		for (int i = 35; i < array.Length; i++)
		{
			Garbage component = array[i].gameObject.GetComponent<Garbage>();
			if (component != null)
			{
				StoredGarbage.Enqueue(component.Info);
				GameController.Instance.GarbageController.DestroyGarbage(component);
			}
		}
	}

	public void StopMoving()
	{
		Garbage.HasBulldozer = false;
		base.gameObject.SetActive(value: false);
		Object.Destroy(this, 1f);
	}
}
