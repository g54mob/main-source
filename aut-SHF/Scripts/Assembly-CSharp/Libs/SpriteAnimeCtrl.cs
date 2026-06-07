using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Libs
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SpriteAnimeCtrl : MonoBehaviour
	{
		public SpriteRenderer render;

		[SerializeField]
		private Sprite[] animeSprites;

		[SerializeField]
		private Sprite stopSprite;

		private NamedSprites[] partsSprites;

		private string partsNameCache;

		private float animeStep;

		private float timer;

		private int index;

		private int frames;

		[SerializeField]
		private bool isPlayingAnime;

		[SerializeField]
		private bool isLoopOnce;

		public void Awake()
		{
		}

		private void Start()
		{
		}

		private void Refresh()
		{
		}

		private void Update()
		{
		}

		private void UpdateSprite(bool manual = false, float? specificRate = null)
		{
		}

		public void SetSprites(NamedSprites[] parts, float step, bool loopOnce = false)
		{
		}

		public void PlayAnimation(bool play, string partsName = null, int? manualIndex = null, bool? loopOnce = null, float? specificRate = null, bool keepIndex = false)
		{
		}

		private void ChangeParts(string partsName)
		{
		}

		public void SetView(bool view)
		{
		}

		public void ChangeStopSprite(string path)
		{
		}

		private void StopSpriteLoaded(AsyncOperationHandle<Sprite> obj)
		{
		}
	}
}
