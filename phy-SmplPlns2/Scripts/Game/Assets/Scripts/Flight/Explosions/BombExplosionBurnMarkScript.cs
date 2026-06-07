using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Flight.Explosions
{
	public class BombExplosionBurnMarkScript : MonoBehaviour
	{
		private DecalProjector _projector;

		private float _sizeLerpCurrentTime;

		private float _sizeLerpEnd;

		private float _sizeLerpStart;

		private float _sizeLerpTotalTime;

		public void LerpSize(float startSize, float endSize, float time)
		{
			_sizeLerpStart = startSize;
			_sizeLerpEnd = endSize;
			_sizeLerpTotalTime = time;
			_sizeLerpCurrentTime = 0f;
			if (_sizeLerpTotalTime <= 0f)
			{
				_projector.size = new Vector3(endSize * 2f, endSize * 2f, 500f);
			}
		}

		protected virtual void Awake()
		{
			_projector = GetComponent<DecalProjector>();
			_projector.size = Vector3.zero;
		}

		protected virtual void Update()
		{
			if ((double)_sizeLerpTotalTime > 0.01)
			{
				_sizeLerpCurrentTime += Time.deltaTime;
				float num = Mathf.Lerp(_sizeLerpStart, _sizeLerpEnd, _sizeLerpCurrentTime / _sizeLerpTotalTime) * 2f;
				_projector.size = new Vector3(num, num, 500f);
				if (_sizeLerpCurrentTime >= _sizeLerpTotalTime)
				{
					_sizeLerpTotalTime = 0f;
				}
			}
		}
	}
}
