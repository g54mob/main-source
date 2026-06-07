using UnityEngine;

public class SpriteSheet : MonoBehaviour
{
	public int _uvTieX = 1;

	public int _uvTieY = 1;

	public int _fps = 10;

	private Vector2 _size;

	private Renderer _renderer;

	private int _lastIndex = -1;

	private float _startTime;

	private void Start()
	{
		_size = new Vector2(1f / (float)_uvTieX, 1f / (float)_uvTieY);
		_renderer = GetComponent<Renderer>();
		if (_renderer == null)
		{
			base.enabled = false;
		}
		else
		{
			_renderer.enabled = false;
		}
		_startTime = Time.timeSinceLevelLoad;
	}

	private void Update()
	{
		int num = (int)((Time.timeSinceLevelLoad - _startTime) * (float)_fps);
		if (num > 15)
		{
			Object.Destroy(base.gameObject);
		}
		else if (num != _lastIndex)
		{
			_renderer.enabled = true;
			int num2 = num % _uvTieX;
			int num3 = num / _uvTieY;
			Vector2 value = new Vector2((float)num2 * _size.x, 1f - _size.y - (float)num3 * _size.y);
			_renderer.material.SetTextureOffset("_MainTex", value);
			_renderer.material.SetTextureScale("_MainTex", _size);
			_lastIndex = num;
		}
	}
}
