using UnityEngine;
using UnityEngine.UI;

public class FlipbookEffect : MonoBehaviour
{
	[SerializeField]
	private RawImage _rawImage;

	[SerializeField]
	private int _rows = 4;

	[SerializeField]
	private int _columns = 4;

	[SerializeField]
	private float _frameDuration = 0.1f;

	private void Update()
	{
		int num = _rows * _columns;
		int frame = (int)(Time.time / _frameDuration % (float)num);
		UpdateUV(frame);
	}

	private void UpdateUV(int frame)
	{
		int num = frame / _columns;
		int num2 = frame % _columns;
		Vector2 vector = new Vector2(1f / (float)_columns, 1f / (float)_rows);
		_rawImage.uvRect = new Rect((float)num2 * vector.x, 1f - (float)(num + 1) * vector.y, vector.x, vector.y);
	}
}
