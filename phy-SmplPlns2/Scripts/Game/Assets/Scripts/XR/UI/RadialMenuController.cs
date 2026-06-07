using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.XR.UI
{
	public class RadialMenuController : MonoBehaviour
	{
		public Image firstImage;

		public int numTiles;

		[Range(0f, 0.5f)]
		public float padding = 0.05f;

		private List<Image> _images = new List<Image>();

		[ContextMenu("Run Setup")]
		private void SetupImages()
		{
			int num = 0;
			while (num < _images.Count)
			{
				if (_images[num] == null)
				{
					_images.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			if (_images.Count == 0)
			{
				_images.Add(firstImage);
			}
			Debug.Log(_images.Count);
			while (_images.Count < numTiles)
			{
				Image image = Object.Instantiate(firstImage, firstImage.transform.parent);
				image.transform.localPosition = firstImage.transform.localPosition;
				image.transform.localRotation = firstImage.transform.localRotation;
				image.transform.localScale = firstImage.transform.localScale;
				image.gameObject.name = $"{firstImage.gameObject.name} {_images.Count}";
				_images.Add(image);
			}
			float num2 = padding / (float)numTiles;
			float fillAmount = 1f / (float)numTiles - num2 - num2;
			for (int i = 0; i < _images.Count; i++)
			{
				Image image2 = _images[i];
				if (i < numTiles)
				{
					float num3 = (float)i / (float)numTiles + num2;
					image2.fillAmount = fillAmount;
					Quaternion quaternion = Quaternion.AngleAxis(num3 * 360f, Vector3.back);
					image2.transform.localRotation = quaternion;
					image2.transform.GetChild(0).localRotation = Quaternion.Inverse(quaternion);
					image2.gameObject.SetActive(value: true);
				}
				else
				{
					image2.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
