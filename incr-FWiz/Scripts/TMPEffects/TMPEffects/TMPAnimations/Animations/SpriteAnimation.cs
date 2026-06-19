using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	internal class SpriteAnimation : ITMPAnimation, ITMPParameterValidator
	{
		private class Data
		{
			public int start;

			public int end;

			public int framerate;

			public string evaluation;

			public int iterations;

			public Dictionary<int, Data2> datas;
		}

		private class Data2
		{
			public int currentFrame;

			public float baseSpriteScale;

			public float targetTime;

			public int finishedIterations;

			public Vector2 uv0_0;

			public Vector2 uv0_1;

			public Vector2 uv0_2;

			public Vector2 uv0_3;

			public Vector3 vert_0;

			public Vector3 vert_1;

			public Vector3 vert_2;

			public Vector3 vert_3;

			public bool init;
		}

		public void Animate(CharData cData, IAnimationContext context)
		{
		}

		public object GetNewCustomData()
		{
			return null;
		}

		public void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}
	}
}
