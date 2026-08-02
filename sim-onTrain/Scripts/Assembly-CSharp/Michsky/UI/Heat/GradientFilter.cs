using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Image))]
	public class GradientFilter : MonoBehaviour
	{
		public enum Filter
		{
			Aqua = 0,
			Dawn = 1,
			Dusk = 2,
			Emerald = 3,
			Kylo = 4,
			Memory = 5,
			Mice = 6,
			Pinky = 7,
			Retro = 8,
			Rock = 9,
			Sunset = 10,
			Violet = 11,
			Warm = 12,
			Random = 13
		}

		public Filter selectedFilter = Filter.Dawn;

		[Range(0.1f, 0.9f)]
		public float opacity = 0.5f;

		private Image bgImage;

		public List<Sprite> filters = new List<Sprite>();

		private void Awake()
		{
			bgImage = GetComponent<Image>();
		}

		private void OnEnable()
		{
			UpdateFilter();
		}

		public void UpdateFilter()
		{
			if (selectedFilter == Filter.Random && Application.isPlaying)
			{
				bgImage.sprite = filters[Random.Range(0, filters.Count - 1)];
			}
			else if (filters.Count >= (int)(selectedFilter + 1))
			{
				bgImage.sprite = filters[(int)selectedFilter];
			}
			bgImage.color = new Color(bgImage.color.r, bgImage.color.g, bgImage.color.g, opacity);
		}
	}
}
