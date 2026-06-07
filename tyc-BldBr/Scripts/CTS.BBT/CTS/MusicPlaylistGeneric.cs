using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class MusicPlaylistGeneric<T> : ScriptableObject
	{
		[SerializeField]
		private List<T> _musicList = new List<T>();

		private Queue<T> _queue = new Queue<T>();

		private List<T> _shuffleList = new List<T>();

		public T GetNextMusicClip()
		{
			if (_queue.Count == 0)
			{
				Shuffle();
			}
			return _queue.Dequeue();
		}

		private void Shuffle()
		{
			if (_queue.Count > 0)
			{
				return;
			}
			if (_shuffleList.Count == 0)
			{
				_shuffleList = _musicList;
			}
			_shuffleList.Shuffle();
			foreach (T shuffle in _shuffleList)
			{
				_queue.Enqueue(shuffle);
			}
		}
	}
}
