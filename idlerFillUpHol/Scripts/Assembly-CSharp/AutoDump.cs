using UnityEngine;

public class AutoDump : MonoBehaviour
{
	private Vector2 _center;

	private Vector2 _size;

	private bool _isRunning;

	private float _timer;

	private BaseBuilding _building;

	private void Start()
	{
		_center = GetComponent<BoxCollider2D>().offset;
		_size = GetComponent<BoxCollider2D>().bounds.size;
		_center += new Vector2(base.transform.position.x, base.transform.position.y);
		GetComponent<BoxCollider2D>().enabled = false;
	}

	private void FixedUpdate()
	{
		if (_isRunning)
		{
			_timer += Time.fixedDeltaTime;
			if (_timer >= 0.5f)
			{
				_timer = 0f;
				DumpGarbage();
			}
		}
	}

	public void Init(BaseBuilding building)
	{
		_building = building;
	}

	public void SetRunning(bool isRunning)
	{
		_isRunning = isRunning;
	}

	private void DumpGarbage()
	{
		Collider2D[] array = Physics2D.OverlapBoxAll(_center, _size, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			Garbage component = array[i].gameObject.GetComponent<Garbage>();
			if (component != null && component.Info.IsGarbage && _building.CanDumbGarbage(component, ignoreBan: true))
			{
				_building.DumpGarbage(component);
			}
		}
	}
}
