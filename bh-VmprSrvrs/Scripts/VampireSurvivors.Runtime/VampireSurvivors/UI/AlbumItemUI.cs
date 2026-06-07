using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;

namespace VampireSurvivors.UI
{
	public class AlbumItemUI : CarouselItemUI
	{
		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private Image _Icon;

		private bool _isSelected;

		private bool _previouslyIsSelected;

		private Tween _colorTween;

		private Tween _fadeTween;

		private AlbumType _albumType;

		private AlbumData _albumData;

		public void SetData(string name, AlbumType t, AlbumData d)
		{
		}

		public override void Initialize(float maxDistance)
		{
		}

		public AlbumType GetAlbumType()
		{
			return default(AlbumType);
		}

		public AlbumData GetAlbumData()
		{
			return null;
		}

		private void KillTweens()
		{
		}

		private void OnDisable()
		{
		}

		protected override void ApplyProgress()
		{
		}

		public override void Deselect(bool completeImmediately = false)
		{
		}

		public override void Select(bool completeImmediately = false)
		{
		}
	}
}
