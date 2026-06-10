using System;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class ForbiddenAreaInfo
	{
		[SerializeField]
		private int forbiddenAreaFrontOffset;

		[SerializeField]
		private int forbiddenAreaBackOffset;

		[SerializeField]
		private int forbiddenAreaRightOffset;

		[SerializeField]
		private int forbiddenAreaLeftOffset;

		public int ForbiddenAreaFrontOffset => forbiddenAreaFrontOffset;

		public int ForbiddenAreaBackOffset => forbiddenAreaBackOffset;

		public int ForbiddenAreaRightOffset => forbiddenAreaRightOffset;

		public int ForbiddenAreaLeftOffset => forbiddenAreaLeftOffset;

		public bool HasFrontOffset => forbiddenAreaFrontOffset != 0;

		public bool HasBackOffset => forbiddenAreaBackOffset != 0;

		public bool HasRightOffset => forbiddenAreaRightOffset != 0;

		public bool HasLeftOffset => forbiddenAreaLeftOffset != 0;

		public bool HasForbiddenArea
		{
			get
			{
				if (forbiddenAreaFrontOffset == 0 && forbiddenAreaBackOffset == 0 && forbiddenAreaRightOffset == 0)
				{
					return forbiddenAreaLeftOffset != 0;
				}
				return true;
			}
		}
	}
}
