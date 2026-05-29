using System;
using UnityEngine;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class SaveCard : MonoBehaviour, IComparable<SaveCard>
	{
		public RawImage image;

		public Texture2D bigTexture;

		public CanvasGroup canvasGroup;

		public BaseButton baseButton;

		public SaveData saveData;

		public MetaSave metaSave;

		public string filePath;

		private UpdateState scaleZ;

		private UpdateState scaleXY;

		[NonSerialized]
		[HideInInspector]
		private bool hasBeenEnabled;

		public int index => 0;

		public void Setup(UiMaster master = null)
		{
		}

		int IComparable<SaveCard>.CompareTo(SaveCard other)
		{
			return 0;
		}
	}
}
