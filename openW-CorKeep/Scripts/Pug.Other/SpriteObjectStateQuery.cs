using System;
using System.Collections.Generic;
using Pug.Sprite;
using UnityEngine;

[RequireComponent(typeof(SpriteObject))]
public class SpriteObjectStateQuery : MonoBehaviour
{
	[Serializable]
	public class State
	{
		public string name;

		public string[] activeDuring = new string[0];

		private HashSet<string> m_animationNames;

		private HashSet<int> m_animationHashes;

		public void Initialize()
		{
			m_animationNames = new HashSet<string>();
			m_animationHashes = new HashSet<int>();
			for (int i = 0; i < activeDuring.Length; i++)
			{
				m_animationNames.Add(activeDuring[i]);
				m_animationHashes.Add(SpriteAsset.StringToHash(activeDuring[i]));
			}
		}

		public bool IsCurrentlyActive(int animationHash)
		{
			return m_animationHashes.Contains(animationHash);
		}
	}

	public List<State> states = new List<State>();

	private Dictionary<string, State> m_stateLookup;

	private Dictionary<int, State> m_stateLookupHash;

	public SpriteObject spriteObject { get; private set; }

	private void Awake()
	{
		spriteObject = GetComponent<SpriteObject>();
		m_stateLookup = new Dictionary<string, State>();
		m_stateLookupHash = new Dictionary<int, State>();
		for (int i = 0; i < states.Count; i++)
		{
			State state = states[i];
			state.Initialize();
			m_stateLookup.Add(state.name, state);
			m_stateLookupHash.Add(SpriteAsset.StringToHash(state.name), state);
		}
	}

	public bool IsStateActive(string name)
	{
		if (m_stateLookup.TryGetValue(name, out var value) && value.IsCurrentlyActive(spriteObject.currentAnimationHash))
		{
			return true;
		}
		return false;
	}

	public bool IsStateActive(int hash)
	{
		if (m_stateLookupHash.TryGetValue(hash, out var value) && value.IsCurrentlyActive(spriteObject.currentAnimationHash))
		{
			return true;
		}
		return false;
	}
}
