using UnityEngine;

namespace TH20
{
	[ExecuteAlways]
	public class UVAnimator : MonoBehaviour
	{
		[SerializeField]
		private int TextureSheetRows = 4;

		[SerializeField]
		private int TextureSheetColumns = 4;

		[SerializeField]
		private int CycleAtFrame = 16;

		[SerializeField]
		private int FPS = 30;

		[SerializeField]
		private bool SyncInstance;

		[SerializeField]
		private bool RandomStartFrame;

		private int _index;

		private Vector2 _size;

		private Vector2 _offset;

		private float _elapsedTime;

		private Renderer _renderer;

		private MaterialPropertyBlock _propertyBlock;

		private void Start()
		{
			_renderer = GetComponent<Renderer>();
			_propertyBlock = new MaterialPropertyBlock();
			if (RandomStartFrame)
			{
				_elapsedTime = RandomUtils.GlobalRandomInstance.Next(0, CycleAtFrame);
			}
		}

		private void Update()
		{
			if (SyncInstance)
			{
				_index = (int)(GameTime.time * (float)FPS);
			}
			else
			{
				_elapsedTime += Time.deltaTime;
				_index = (int)(_elapsedTime * (float)FPS);
			}
			_index %= CycleAtFrame;
			_size = new Vector2(1f / (float)TextureSheetColumns, 1f / (float)TextureSheetRows);
			int num = _index % TextureSheetColumns;
			int num2 = _index / TextureSheetColumns;
			_offset = new Vector2((float)num * _size.x, 1f - _size.y - (float)num2 * _size.y);
			_propertyBlock.SetVector("_MainTex_ST", new Vector4(_size.x, _size.y, _offset.x, _offset.y));
			_renderer.SetPropertyBlock(_propertyBlock);
		}
	}
}
