using System;
using UnityEngine;

namespace GAudio
{
	public class DrawFFTModule : DrawAudioModule
	{
		public FFTModule fftModule;

		private int _fromIndex;

		private int _toIndex;

		private int _vertexCount;

		protected override void Start()
		{
			_fromIndex = fftModule.FirstOutputBinIndex;
			_toIndex = fftModule.LastOutputBinIndex;
			_vertexCount = _toIndex - _fromIndex;
			base.Start();
		}

		protected override void SetVertexCount()
		{
			_lineRenderer.positionCount = _vertexCount;
		}

		protected override void HandleAudioDataUpdate()
		{
			if (!(fftModule == null))
			{
				fftModule.RealFFT(_data);
				int num = _fromIndex;
				for (int i = 0; i < _vertexCount; i++)
				{
					_lineRenderer.SetPosition(i, new Vector3((float)i * xFactor, _data[num] * yFactor, 0f));
					num++;
				}
				Array.Clear(_data, 0, _data.Length);
			}
		}

		protected override void HandleNoMoreData()
		{
			for (int i = 0; i < _vertexCount; i++)
			{
				_lineRenderer.SetPosition(i, new Vector3((float)i * xFactor, 0f, 0f));
			}
		}
	}
}
