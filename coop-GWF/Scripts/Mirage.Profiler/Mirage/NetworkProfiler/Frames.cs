using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirage.NetworkProfiler
{
	[Serializable]
	public class Frames : IEnumerable<Frame>, IEnumerable
	{
		[SerializeField]
		private Frame[] _frames;

		public Frames()
		{
			_frames = new Frame[300];
			for (int i = 0; i < _frames.Length; i++)
			{
				_frames[i] = new Frame();
			}
		}

		public Frame GetFrame(int frameIndex)
		{
			return _frames[frameIndex % _frames.Length];
		}

		public IEnumerator<Frame> GetEnumerator()
		{
			return ((IEnumerable<Frame>)_frames).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Frame>)_frames).GetEnumerator();
		}

		internal void ValidateSize()
		{
			if (_frames.Length != 300)
			{
				Array.Resize(ref _frames, 300);
			}
		}
	}
}
