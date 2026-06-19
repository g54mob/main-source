using System.Collections.Generic;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public class RandomSpriteOnStart : MonoBehaviour
	{
		public List<Sprite> spritesToChooseFrom;

		private void Awake()
		{
			GetComponent<SpriteRenderer>().sprite = spritesToChooseFrom.RandomElement();
			base.enabled = false;
		}
	}
}
