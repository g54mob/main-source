using System.Collections.Generic;
using Libs;
using UnityEngine;

namespace UI
{
	public class RecastGageCtrl : SingletonMonoBehaviour<RecastGageCtrl>
	{
		[SerializeField]
		private RectTransform recastContent;

		[SerializeField]
		private RecastItem recastImagePrefab;

		[SerializeField]
		private Vector3 lastBossAnchoredPos;

		private List<RecastItem> recastIcons;

		private Vector3? _initAnchoredPos;

		private void Awake()
		{
		}

		public void CreateHeroRecastGroup(List<PlayUnlockData> recastHeros, bool isLastBoss = false)
		{
		}

		private void Clear()
		{
		}

		public RecastItem CreateRecastImage()
		{
			return null;
		}

		public void UpdataOutputInterval(eLuggage id, double newInterval)
		{
		}

		public void UpdateGages()
		{
		}

		public void DisplayUI(bool on)
		{
		}

		public void LockRecast(eLuggage id, double lockTime)
		{
		}
	}
}
