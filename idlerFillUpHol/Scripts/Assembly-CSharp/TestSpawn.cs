using TMPro;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
	private int _state;

	private int _normalSpawn;

	public TMP_Text TestNormalCount;

	public TMP_Text TestFPS;

	public TMP_Text TestSleep;

	private float _deltaTime;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			_state = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			_state = 0;
		}
		if (_state == 1)
		{
			for (int i = 0; i < 5; i++)
			{
				GameController.Instance.GarbageController.Generate(base.transform.position, 1, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.None, isEvil: false).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
				_normalSpawn++;
			}
		}
		_deltaTime += (Time.unscaledDeltaTime - _deltaTime) * 0.1f;
		float f = 1f / _deltaTime;
		TestNormalCount.text = "1- Normal: " + _normalSpawn;
		TestFPS.text = "FPS: " + Mathf.RoundToInt(f);
	}
}
