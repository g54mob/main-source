using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class NoticeBadge : MonoBehaviour
	{
		[SerializeField]
		private GameObject noticeBadgeGroup;

		[SerializeField]
		private Image emphasisImage;

		private bool _unRead;

		private Tween _tween;

		public bool UnRead
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void UpdateBadge(bool on)
		{
		}

		public void OnDestroy()
		{
		}
	}
}
