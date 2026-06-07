using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class ReplaceSpriteInAdventure : MonoBehaviour
	{
		[SerializeField]
		private string SpriteToReplaceWith;

		private Sprite _baseSprite;

		private Image _image;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}
	}
}
