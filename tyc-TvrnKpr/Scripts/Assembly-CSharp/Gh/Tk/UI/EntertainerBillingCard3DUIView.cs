using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class EntertainerBillingCard3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProI18n _nameText;

		[SerializeField]
		private TextMeshProI18n _timeText;

		[SerializeField]
		private List<GameObject> _stars;

		[SerializeField]
		private Container3DUIView _starsContainer;

		private GameObject[] _previewObjects;

		private EntertainerProfile _currentProfile;

		[SerializeField]
		private List<AnimationClip> _poseClips;

		[SerializeField]
		private Transform _previewSocket;

		public void SetEntertainer(EntertainerProfile entertainerProfile, BookedEntertainerEvent bookedEntertainerEvent, bool isNowPlaying)
		{
		}

		private void SetEntertainerPreview(EntertainerProfile profile)
		{
		}
	}
}
