using UnityEngine;
using UnityEngine.UI;

namespace AllIn1VfxToolkit.DemoAssets.TexturesDemo.Scripts
{
	public class AllIn1VfxTextureDemoManager : MonoBehaviour
	{
		[SerializeField]
		private int startingCollectionIndex;

		[SerializeField]
		private int startingPageIndex;

		[Space]
		[Header("Demo Textures")]
		[SerializeField]
		private All1VfxDemoTextureCollection[] textureCollections;

		[Space]
		[Header("Demo Controller Input")]
		[SerializeField]
		private KeyCode nextPageKey = KeyCode.RightArrow;

		[SerializeField]
		private KeyCode nextPageKeyAlt = KeyCode.D;

		[SerializeField]
		private KeyCode previousPageKey = KeyCode.LeftArrow;

		[SerializeField]
		private KeyCode previousPageKeyAlt = KeyCode.A;

		[SerializeField]
		private KeyCode nextCollectionKey = KeyCode.UpArrow;

		[SerializeField]
		private KeyCode nextCollectionKeyAlt = KeyCode.W;

		[SerializeField]
		private KeyCode previousCollectionKey = KeyCode.DownArrow;

		[SerializeField]
		private KeyCode previousCollectionKeyAlt = KeyCode.S;

		[Space]
		[Header("References")]
		[SerializeField]
		private RawImage[] images;

		[SerializeField]
		private Text collectionText;

		[SerializeField]
		private Text pageText;

		[SerializeField]
		private AllIn1DemoScaleTween expositorTween;

		[SerializeField]
		private AllIn1DemoScaleTween nextPageButtTween;

		[SerializeField]
		private AllIn1DemoScaleTween prevPageButtTween;

		[SerializeField]
		private AllIn1DemoScaleTween nextCollectionButtTween;

		[SerializeField]
		private AllIn1DemoScaleTween prevCollectionButtTween;

		private int currTextureCollectionIndex;

		private int currTextureIndex;

		private int numberOfImagesPerPage;

		private void Start()
		{
			currTextureCollectionIndex = startingCollectionIndex;
			currTextureIndex = startingPageIndex;
			numberOfImagesPerPage = images.Length;
			RefreshCollectionAndPageText();
			AssignCurrentImages();
		}

		private void Update()
		{
			if (Input.GetKeyDown(nextPageKey) || Input.GetKeyDown(nextPageKeyAlt))
			{
				ChangeTextureIndex(1);
			}
			if (Input.GetKeyDown(previousPageKey) || Input.GetKeyDown(previousPageKeyAlt))
			{
				ChangeTextureIndex(-1);
			}
			if (Input.GetKeyDown(nextCollectionKey) || Input.GetKeyDown(nextCollectionKeyAlt))
			{
				ChangeCollectionIndex(1);
			}
			if (Input.GetKeyDown(previousCollectionKey) || Input.GetKeyDown(previousCollectionKeyAlt))
			{
				ChangeCollectionIndex(-1);
			}
		}

		public void ChangeTextureIndex(int pagesAmount)
		{
			currTextureIndex += pagesAmount * numberOfImagesPerPage;
			if (pagesAmount > 0)
			{
				nextPageButtTween.ScaleDownTween();
			}
			else
			{
				prevPageButtTween.ScaleDownTween();
			}
			expositorTween.ScaleDownTween();
			bool flag = false;
			if (currTextureIndex < 0)
			{
				flag = true;
				ChangeCollectionIndex(-1);
			}
			else if (currTextureIndex >= textureCollections[currTextureCollectionIndex].demoTextureCollection.Length)
			{
				flag = true;
				ChangeCollectionIndex(1);
			}
			if (!flag)
			{
				AssignCurrentImages();
				RefreshCollectionAndPageText();
			}
		}

		public void ChangeCollectionIndex(int collectionChangeAmount)
		{
			currTextureCollectionIndex += collectionChangeAmount;
			if (collectionChangeAmount > 0)
			{
				nextCollectionButtTween.ScaleDownTween();
			}
			else
			{
				prevCollectionButtTween.ScaleDownTween();
			}
			expositorTween.ScaleDownTween();
			if (currTextureCollectionIndex < 0)
			{
				currTextureCollectionIndex = textureCollections.Length - 1;
			}
			else if (currTextureCollectionIndex >= textureCollections.Length)
			{
				currTextureCollectionIndex = 0;
			}
			if (collectionChangeAmount > 0)
			{
				currTextureIndex = 0;
			}
			else
			{
				int num = textureCollections[currTextureCollectionIndex].demoTextureCollection.Length % numberOfImagesPerPage;
				if (num == 0)
				{
					num = numberOfImagesPerPage;
				}
				currTextureIndex = textureCollections[currTextureCollectionIndex].demoTextureCollection.Length - num;
			}
			AssignCurrentImages();
			RefreshCollectionAndPageText();
		}

		private void RefreshCollectionAndPageText()
		{
			collectionText.text = textureCollections[currTextureCollectionIndex].collectionName + " Collection";
			int num = 0;
			int num2 = (int)Mathf.Ceil((float)textureCollections[currTextureCollectionIndex].demoTextureCollection.Length / (float)numberOfImagesPerPage);
			if (currTextureIndex > 1)
			{
				num = currTextureIndex / numberOfImagesPerPage;
			}
			pageText.text = num + 1 + "/" + num2;
		}

		private void AssignCurrentImages()
		{
			int num = 0;
			RawImage[] array = images;
			foreach (RawImage rawImage in array)
			{
				if (currTextureIndex + num >= textureCollections[currTextureCollectionIndex].demoTextureCollection.Length)
				{
					rawImage.enabled = false;
					continue;
				}
				rawImage.enabled = true;
				rawImage.texture = textureCollections[currTextureCollectionIndex].demoTextureCollection[currTextureIndex + num];
				num++;
			}
		}
	}
}
