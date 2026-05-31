using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	public class SgCircleSlice : MonoBehaviour
	{
		private SgFillableCircleImage m_Image;

		private RectTransform m_RectTransform;

		private SgSelectable m_Selectable;

		public SgCircleData circleData;

		public int sliceIndex;

		public SgFillableCircleImage Image => null;

		public RectTransform RectTransform => null;

		public SgSelectable Selectable => null;
	}
}
