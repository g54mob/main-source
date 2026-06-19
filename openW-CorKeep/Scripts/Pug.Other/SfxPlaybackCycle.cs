using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Mathematics;

public class SfxPlaybackCycle
{
	private List<List<SfxTable.SFXSound>> _shuffledSounds;

	private int _cycleIndex;

	private readonly Queue<List<SfxTable.SFXSound>> _lastPlayedQueue = new Queue<List<SfxTable.SFXSound>>(2);

	private List<SfxTable.SFXSound> _lastPlayed;

	private Unity.Mathematics.Random _rng;

	private bool _singleSoundMode;

	private List<SfxTable.SFXSound> _singleSound;

	public SfxPlaybackCycle(List<SfxTable.SFXSound> baseSounds, List<SfxTable.SFXSoundVariant> variants)
	{
		_shuffledSounds = new List<List<SfxTable.SFXSound>>();
		if (baseSounds != null)
		{
			_shuffledSounds.Add(baseSounds);
		}
		if (variants != null)
		{
			foreach (SfxTable.SFXSoundVariant variant in variants)
			{
				if (variant.soundVariant != null)
				{
					_shuffledSounds.Add(variant.soundVariant);
				}
			}
		}
		if (_shuffledSounds.Count == 1)
		{
			_singleSoundMode = true;
			_singleSound = _shuffledSounds[0];
		}
		else
		{
			_rng = PugRandom.GetRng((uint)DateTime.Now.Ticks);
			StartNewCycle();
		}
	}

	private void StartNewCycle()
	{
		if (_singleSoundMode)
		{
			return;
		}
		_shuffledSounds.Shuffle();
		if (_shuffledSounds.Count >= 3 && _lastPlayedQueue.Count == 2)
		{
			for (int i = 0; i < Math.Min(2, _shuffledSounds.Count); i++)
			{
				if (_lastPlayedQueue.Contains(_shuffledSounds[i]))
				{
					int j;
					for (j = 2; j < _shuffledSounds.Count && _lastPlayedQueue.Contains(_shuffledSounds[j]); j++)
					{
					}
					if (j < _shuffledSounds.Count)
					{
						List<List<SfxTable.SFXSound>> shuffledSounds = _shuffledSounds;
						int index = i;
						List<List<SfxTable.SFXSound>> shuffledSounds2 = _shuffledSounds;
						int index2 = j;
						List<SfxTable.SFXSound> list = _shuffledSounds[j];
						List<SfxTable.SFXSound> list2 = _shuffledSounds[i];
						List<SfxTable.SFXSound> list3 = (shuffledSounds[index] = list);
						list3 = (shuffledSounds2[index2] = list2);
					}
				}
			}
		}
		else if (_shuffledSounds.Count > 1 && _shuffledSounds[0] == _lastPlayed)
		{
			int num = 1 + _rng.NextInt(0, _shuffledSounds.Count - 1);
			List<List<SfxTable.SFXSound>> shuffledSounds3 = _shuffledSounds;
			List<List<SfxTable.SFXSound>> shuffledSounds2 = _shuffledSounds;
			int index2 = num;
			List<SfxTable.SFXSound> list2 = _shuffledSounds[num];
			List<SfxTable.SFXSound> list = _shuffledSounds[0];
			List<SfxTable.SFXSound> list3 = (shuffledSounds3[0] = list2);
			list3 = (shuffledSounds2[index2] = list);
		}
		_cycleIndex = 0;
	}

	public List<SfxTable.SFXSound> GetNextSound()
	{
		if (_singleSoundMode)
		{
			return _singleSound;
		}
		if (_shuffledSounds == null || _shuffledSounds.Count == 0)
		{
			return null;
		}
		if (_cycleIndex >= _shuffledSounds.Count)
		{
			StartNewCycle();
		}
		List<SfxTable.SFXSound> list = _shuffledSounds[_cycleIndex];
		_cycleIndex++;
		if (_shuffledSounds.Count >= 3)
		{
			if (_lastPlayedQueue.Count == 2)
			{
				_lastPlayedQueue.Dequeue();
			}
			_lastPlayedQueue.Enqueue(list);
		}
		else
		{
			_lastPlayedQueue.Clear();
			_lastPlayedQueue.Enqueue(list);
		}
		_lastPlayed = list;
		return list;
	}
}
