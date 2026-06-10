using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sound Clip Data", menuName = "Super Text Mesh/Sound Clip Data", order = 1)]
public class STMSoundClipData : ScriptableObject
{
	[Serializable]
	public class AutoClip
	{
		public enum Type
		{
			Character = 0,
			Quad = 1,
			LineBreak = 2,
			Tab = 3
		}

		public Type type;

		[SerializeField]
		private char _character;

		public string quadName;

		public AudioClip clip;

		public char character
		{
			get
			{
				if (type == Type.LineBreak)
				{
					return '\n';
				}
				if (type == Type.Tab)
				{
					return '\t';
				}
				return _character;
			}
		}
	}

	public List<AutoClip> clips = new List<AutoClip>();
}
