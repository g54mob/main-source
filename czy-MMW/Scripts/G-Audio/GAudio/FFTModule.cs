using System;
using UnityEngine;

namespace GAudio
{
	public class FFTModule : MonoBehaviour
	{
		public enum WindowFunction
		{
			Hanning = 0,
			Hamming = 1
		}

		public enum FFTOutput
		{
			Real = 0,
			SquareMagnitudes = 1,
			Magnitudes = 2,
			Decibels = 3
		}

		public enum FFTSize
		{
			AudioBufferSize = 0,
			Custom = 1
		}

		public bool useWindowFunction = true;

		public int fromFrequency = 40;

		public int toFrequency = 22000;

		public WindowFunction window;

		public FFTOutput output = FFTOutput.Magnitudes;

		public FFTSize fftSize;

		public int customFftSize = 1024;

		private float[] _windowData;

		private float[] _im;

		private FloatFFT _fft;

		private int _appliedFFTSize;

		public int FirstOutputBinIndex { get; private set; }

		public int LastOutputBinIndex { get; private set; }

		public void SetWindow(WindowFunction windowFunction)
		{
			if (_windowData == null || _windowData.Length != _appliedFFTSize)
			{
				_windowData = new float[_appliedFFTSize];
			}
			switch (window)
			{
			case WindowFunction.Hanning:
				GATMaths.MakeHanningWindow(_windowData);
				break;
			case WindowFunction.Hamming:
				GATMaths.MakeHammingWindow(_windowData);
				break;
			}
		}

		public void RealFFT(float[] data)
		{
			if (data.Length != _appliedFFTSize)
			{
				Debug.LogError("Expected data lengt: " + _appliedFFTSize + ", received " + data.Length);
				return;
			}
			if (useWindowFunction)
			{
				for (int i = 0; i < _appliedFFTSize; i++)
				{
					data[i] *= _windowData[i];
				}
			}
			_fft.run(data, _im);
			switch (output)
			{
			case FFTOutput.Decibels:
				ComputeDB(data);
				break;
			case FFTOutput.Magnitudes:
				ComputeMagnitudes(data);
				break;
			case FFTOutput.SquareMagnitudes:
				ComputeSquareMagnitudes(data);
				break;
			}
			Array.Clear(_im, 0, _im.Length);
		}

		private void Awake()
		{
			if (fftSize == FFTSize.Custom)
			{
				_appliedFFTSize = Mathf.NextPowerOfTwo(customFftSize);
				if (_appliedFFTSize != customFftSize)
				{
					Debug.LogWarning("This FFT implementation only supports power of 2 lengths, defaulting to next possible value: " + _appliedFFTSize);
					customFftSize = _appliedFFTSize;
				}
			}
			else
			{
				_appliedFFTSize = GATInfo.AudioBufferSizePerChannel;
			}
			if (useWindowFunction)
			{
				SetWindow(window);
			}
			_im = new float[_appliedFFTSize];
			_fft = new FloatFFT();
			uint logN = (uint)Mathf.Log(_appliedFFTSize, 2f);
			_fft.init(logN);
			FirstOutputBinIndex = fromFrequency * _appliedFFTSize / GATInfo.OutputSampleRate;
			LastOutputBinIndex = toFrequency * _appliedFFTSize / GATInfo.OutputSampleRate;
		}

		private void ComputeSquareMagnitudes(float[] data)
		{
			for (int i = FirstOutputBinIndex; i < LastOutputBinIndex; i++)
			{
				data[i] = data[i] * data[i] + _im[i] * _im[i];
			}
		}

		private void ComputeMagnitudes(float[] data)
		{
			for (int i = FirstOutputBinIndex; i < LastOutputBinIndex; i++)
			{
				data[i] = Mathf.Sqrt(data[i] * data[i] + _im[i] * _im[i]);
			}
		}

		private void ComputeDB(float[] data)
		{
			for (int i = FirstOutputBinIndex; i < LastOutputBinIndex; i++)
			{
				data[i] = 8.685889f * Mathf.Log(Mathf.Sqrt(data[i] * data[i] + _im[i] * _im[i]) + float.Epsilon);
			}
		}
	}
}
