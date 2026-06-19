using System;
using System.Collections;
using System.Collections.Generic;
using ModIO.Util;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class QueueRunner : SelfInstancingMonoSingleton<QueueRunner>
	{
		private List<Action> sequences = new List<Action>();

		private Coroutine coroutine;

		public void Add(Action sequence)
		{
			if (sequence != null)
			{
				sequences.Add(sequence);
				if (coroutine == null)
				{
					coroutine = StartCoroutine(Run());
				}
			}
		}

		private IEnumerator Run()
		{
			while (sequences.Count > 0)
			{
				yield return 0;
				sequences[0]();
				sequences.RemoveAt(0);
			}
			coroutine = null;
		}

		public void AddSpriteCreation(Texture2D texture, Action<Sprite> onConversion)
		{
			Add(delegate
			{
				onConversion(TextureToSprite(texture));
			});
		}

		private static Sprite TextureToSprite(Texture2D texture)
		{
			Rect rect = new Rect(Vector2.zero, new Vector2(texture.width, texture.height));
			int num = 100;
			SpriteMeshType meshType = SpriteMeshType.FullRect;
			return Sprite.Create(texture, rect, Vector2.zero, num, 0u, meshType);
		}
	}
}
