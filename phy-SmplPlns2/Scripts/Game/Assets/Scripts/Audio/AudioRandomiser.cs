using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
	public class AudioRandomiser
	{
		private readonly int _dimension;

		private List<AudioClip[]> _arrays;

		private AudioSource _audioSource;

		private int _current = -1;

		public int Count => _arrays.Count;

		public int Dimension => _dimension;

		public AudioClip this[int index] => _arrays[GetCurrentIndex()][index];

		public AudioRandomiser(int dimension, AudioSource source)
		{
			_dimension = dimension;
			if (dimension <= 0)
			{
				throw new ArgumentOutOfRangeException($"dimension = {dimension}");
			}
			_audioSource = source ?? throw new ArgumentNullException("source");
			_arrays = new List<AudioClip[]>();
		}

		public void AddFiles(params AudioClip[] files)
		{
			if (files == null)
			{
				throw new ArgumentNullException("files");
			}
			if (files.Length != _dimension)
			{
				throw new ArgumentOutOfRangeException("files");
			}
			for (int i = 0; i < files.Length; i++)
			{
				if (files[i] == null)
				{
					throw new ArgumentNullException("files");
				}
			}
			_arrays.Add(files);
		}

		public void AddFiles(params string[] paths)
		{
			if (paths == null)
			{
				throw new ArgumentNullException("paths");
			}
			if (paths.Length != _dimension)
			{
				throw new ArgumentOutOfRangeException("paths");
			}
			AudioClip[] array = new AudioClip[_dimension];
			for (int i = 0; i < paths.Length; i++)
			{
				string text = paths[i];
				if (text == null)
				{
					throw new ArgumentNullException("paths");
				}
				array[i] = Resources.Load<AudioClip>(text);
				if (array[i] == null)
				{
					throw new ArgumentException("Audio clip not found: " + text);
				}
			}
			_arrays.Add(array);
		}

		public void Play(int slot, bool randomise, bool loop = false)
		{
			if (randomise)
			{
				Randomise();
			}
			if (_audioSource == null)
			{
				throw new InvalidOperationException("Audio source was deleted");
			}
			AudioClip clip = this[slot];
			_audioSource.Stop();
			_audioSource.clip = clip;
			if (loop)
			{
				_audioSource.loop = true;
			}
			_audioSource.PlayDelayed(0.05f * UnityEngine.Random.value);
		}

		public void Randomise()
		{
			_current = UnityEngine.Random.Range(0, _arrays.Count);
		}

		private int GetCurrentIndex()
		{
			if (_current == -1)
			{
				Randomise();
			}
			return _current;
		}
	}
}
