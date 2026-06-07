using System;
using System.Collections.Generic;
using UnityEngine;

namespace SE.EvilLib.AudioManager
{
	[Serializable]
	public class AudioClassSfx : AudioClass
	{
		public int type;

		public Vector2 pitchRange;

		public List<ClipClassSfx> clipClasses;
	}
}
