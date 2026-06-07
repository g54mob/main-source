using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using UnityEngine;
using UnityEngine.Video;

namespace Assets.Nimbatus.Scripts.Tutorial
{
	[Serializable]
	public class TutorialSlide
	{
		public Texture Image;

		public VideoClip VideoClip;

		public TranslationTerm Description;
	}
}
