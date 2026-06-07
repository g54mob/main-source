using System;
using UnityEngine;

namespace Gh.Tk
{
	public class CollectibleCardInspector3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private CollectibleCard3DUIView _cardView;

		public CollectibleCardData CardData { get; private set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void FeedbackWindow3DUIViewOnOpenStateChanged(object sender, EventArgs e)
		{
		}

		public void SetData(CollectibleCardData cardData)
		{
		}
	}
}
